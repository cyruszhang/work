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

var feedname = "LM_DailyUserCount";
var datafeedconfig = DataFeedConfigurations.Where(f => f.DataFeedName == feedname).First().Dump();
var datafeedconfigid = datafeedconfig.DataFeedConfigId;

var feeds = 
	(from f in (from f in V_DataFeedLoadStatus where f.DataFeedConfigId == datafeedconfigid && f.StartTime >= start && f.StartTime <= end select f)
	let year = f.StartTime.Year
	let month = f.StartTime.Month
	let day = f.StartTime.Day
	let FeedUrl = f.ResourcePathUrl.Substring(0, f.ResourcePathUrl.Length-11)
	let SmlUrl = String.Format("https://cosmos09.osdinfra.net/cosmos/searchDM/shares/searchDM/SMLAvailability/{0,4:D4}/{1,2:D2}/MergedLogAvailable_{0,4:D4}_{1,2:D2}_{2,2:D2}.txt", year, month, day)
	let iBftUrl = String.Format("https://cosmos09.osdinfra.net/cosmos/searchDM/shares/searchDM/UnifiedCache/MSLAPI_NonBot/Availability/{0,4:D4}/{1,2:D2}/UnifiedCache_MSLAPI_NonBot_Available_{0,4:D4}-{1,2:D2}-{2,2:D2}.txt", year, month, day) 
	let usUrl = String.Format("https://cosmos09.osdinfra.net/cosmos/searchDM/shares/searchDM/UnifiedCacheSideStreams/Availability/UserSegSideStream/{0,4:D4}/{1,2:D2}/UserSegSideStream_Available_{0,4:D4}_{1,2:D2}_{2,2:D2}.txt", year, month, day)
	select new {f.StartTime, f.LoadedTime, FeedUrl, SmlUrl, iBftUrl, usUrl}).ToArray();

feeds.First().Dump();

var status = 
	from f in feeds
	let LMUUStreamReadyTime = VcClient.VC.GetStreamInfo(f.FeedUrl,true).CreateTime
	let SmlStreamReadyTime = VcClient.VC.GetStreamInfo(f.SmlUrl,true).CreateTime
	let iBftStreamReadyTime = VcClient.VC.GetStreamInfo(f.iBftUrl,true).CreateTime
	let UserSegSideStreamReadyTime = VcClient.VC.GetStreamInfo(f.usUrl, true).CreateTime
	let SourceStreamsReadyTime = iBftStreamReadyTime > UserSegSideStreamReadyTime ? iBftStreamReadyTime : UserSegSideStreamReadyTime
	select new {Date = f.StartTime, SmlStreamReadyTime, iBftStreamReadyTime, UserSegSideStreamReadyTime, SourceStreamsReadyTime, LMUUStreamReadyTime, DatabaseLoadedTime = f.LoadedTime, ProcessingTimeAfterSourceStreamsReady = f.LoadedTime - SourceStreamsReadyTime};

status.Dump();