<Query Kind="Statements">
  <Connection>
    <ID>1d72aa85-78a9-4195-8f79-32dee7b454f4</ID>
    <Server>LiveMetricsDatabase.glbdns2.microsoft.com,89</Server>
    <Database>LiveMetricsReporting</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>\\searchdata\Apps\Foray\VcClient.dll</Reference>
</Query>

// 4 weeks rolling window
var start = DateTime.Today.AddDays(-30);
var end = DateTime.Today.AddDays(-2);

var feedname = "LM_DailyPageDataForm";
var datafeedconfig = DataFeedConfigurations.Where(f => f.DataFeedName == feedname).First().Dump();
var datafeedconfigid = datafeedconfig.DataFeedConfigId;

var feeds = 
	(from f in (from f in V_DataFeedLoadStatus where f.DataFeedConfigId == datafeedconfigid && f.StartTime >= start && f.StartTime <= end select f)
	let month = f.StartTime.Month
	let day = f.StartTime.Day
	let FeedUrl = f.ResourcePathUrl.Substring(0, f.ResourcePathUrl.Length-11)
	let SmlUrl = String.Format("https://cosmos09.osdinfra.net/cosmos/searchDM/shares/searchDM/SMLAvailability/2014/{0,2:D2}/MergedLogAvailable_2014_{0,2:D2}_{1,2:D2}.txt", month, day)
	let iBftUrl = String.Format("https://cosmos09.osdinfra.net/cosmos/searchDM/shares/searchDM/UnifiedCache/MSLAPI_NonBot/Availability/2014/{0,2:D2}/UnifiedCache_MSLAPI_NonBot_Available_2014-{0,2:D2}-{1,2:D2}.txt", month, day) 
	select new {f.StartTime, f.LoadedTime, FeedUrl, SmlUrl, iBftUrl}).ToArray();

feeds.First().Dump();

var status = 
	from f in feeds
	let LMStreamReadyTime = VcClient.VC.GetStreamInfo(f.FeedUrl,true).CreateTime
	let SmlStreamReadyTime = VcClient.VC.GetStreamInfo(f.SmlUrl,true).CreateTime
	let iBftStreamReadyTime = VcClient.VC.GetStreamInfo(f.iBftUrl,true).CreateTime
	select new {Date = f.StartTime, SmlStreamReadyTime, iBftStreamReadyTime, LMStreamReadyTime, DatabaseLoadedTime = f.LoadedTime, ProcessingTimeAfterSourceStreamsReady = f.LoadedTime - iBftStreamReadyTime};

status.Dump();