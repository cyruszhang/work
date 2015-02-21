<Query Kind="Statements">
  <Connection>
    <ID>8dc5c7bc-252a-4df3-9e3f-8871195602a9</ID>
    <Persist>true</Persist>
    <Server>dmsql05</Server>
    <Database>MetricsMetadataDev</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>\\searchdata\Apps\Foray\VcClient.dll</Reference>
</Query>

var localPath = "C:\\Users\\cyrusz\\Documents\\Visual Studio 2012\\Projects\\CosmosRandomJobs\\FirehoseDataCooking\\Lib";
var cosmosPath = "https://cosmos09.osdinfra.net/cosmos/relevance/users/cyrusz/Projects/SalesPrediction/Twitter/";
string[] files = Directory.GetFiles(localPath);
foreach(var file in files) {
	// get last part of the file path
	// C:\Users\cyrusz\Documents\Visual Studio 2012\Projects\CosmosRandomJobs\FirehoseDataCooking\Lib\BaseMLT.dll
	var fileName = file.Substring(file.LastIndexOf('\\') + 1, file.Length - file.LastIndexOf('\\') - 1);
	fileName.Dump();
	VcClient.VC.Upload(file, Path.Combine(cosmosPath, fileName), false);
}	