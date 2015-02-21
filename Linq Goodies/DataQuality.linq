<Query Kind="Statements">
  <Connection>
    <ID>37498bb5-ad8e-4846-b76f-d0675e194394</ID>
    <Persist>true</Persist>
    <Server>cyrusz-desktop</Server>
    <Database>DataQualityMetaData</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio 11.0\Visual Studio Tools for Office\PIA\Office14\Microsoft.Office.Interop.Excel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>\\searchdata\Apps\Foray\VcClient.dll</Reference>
  <GACReference>Microsoft.AnalysisServices.AdomdClient, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <Namespace>Microsoft.AnalysisServices.AdomdClient</Namespace>
  <Namespace>Microsoft.Office.Interop.Excel</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

int defaultLookbackStart = 183;
int defaultLookbackEnd   = 4;
string cosmosDir = "https://cosmos09.osdinfra.net/cosmos/searchDM/users/cyrusz/DmsDataCheck/";

StringBuilder resultBuilder = new StringBuilder();
DataSet resultDataSet = new DataSet();
foreach(var ccr in CubeCheckRules) {
	DateTime startTime = DateTime.Today.AddDays(-(ccr.Retention ?? defaultLookbackStart));
	DateTime endTime =  DateTime.Today.AddDays(-defaultLookbackEnd);

	string connectionString = BuildAdomdConnectionString(ccr);
	string query = BuildCheckQuery(ccr, startTime, endTime);
	
	System.Data.DataTable result = RetrieveDataTable(connectionString, query);
	result.TableName = ccr.Server;
	
	string analysisResult = AnalyzeResult(ccr, result, startTime, endTime);
	analysisResult.Dump();
	
	resultBuilder.Append(analysisResult);
	resultDataSet.Tables.Add(result);
}

// ExportDataSetToExcel(resultDataSet);
UploadResultToCosmos(cosmosDir, resultBuilder.ToString());

} // LINQPAD C# HELPER CODE HACK: extra } for closure


// support classes and methods

string BuildAdomdConnectionString(CubeCheckRule ccr){
	return String.Format("Data Source={0};Catalog={1}", ccr.Server, ccr.DbName);
}

string BuildCheckQuery(CubeCheckRule ccr, DateTime start, DateTime end){
	return String.Format("SELECT [Measures].[{0}] on 0, [{1}].[Date].&[{2}]:[{1}].[Date].&[{3}] on 1 FROM [{4}];", 
						ccr.Measure, ccr.DateColumn, start.ToString("s"), end.ToString("s"), ccr.CubeName);
}

System.Data.DataTable RetrieveDataTable(string connectionString, string query){
	System.Data.DataTable result = new System.Data.DataTable();
	using(AdomdConnection connection = new AdomdConnection(connectionString)) {
		result.Clear();
		AdomdDataAdapter da = new AdomdDataAdapter(new AdomdCommand(query, connection));
		connection.Open();
		da.Fill(result);
		connection.Close();
	}
	return result;
}

// given data, return digest of check result on the cube
string AnalyzeResult(CubeCheckRule ccr, System.Data.DataTable result, DateTime start, DateTime end) {
	int checkRange = (end-start).Days + 1;
	int missingCount = 0;
	for(int j=0; j<result.Rows.Count; ++j)
		if(result.Rows[j].ItemArray[1].ToString().Length == 0)
			++ missingCount;
	missingCount += checkRange - result.Rows.Count;
	
	return String.Format(
	@"Server: {0}
Database: {1}
Cube: {2}
Checked date range: {3} - {4} ({5} days)
Missing days: {6}
Missing ratio: {7}
	
", ccr.Server, ccr.DbName, ccr.CubeName, start.ToString("d"), end.ToString("d"), checkRange, missingCount, (float)missingCount/checkRange);
}

void ExportDataSetToExcel(DataSet ds)
{
  //Creae an Excel application instance
  Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
  
  //Create an Excel workbook instance and open it from the predefined location
  Workbook excelWorkBook = excelApp.Workbooks.Add();

  foreach (System.Data.DataTable table in ds.Tables)
  {
      //Add a new worksheet to workbook with the Datatable name
      Worksheet excelWorkSheet = (Worksheet)excelWorkBook.Sheets.Add();
      excelWorkSheet.Name = table.TableName.Substring(0, table.TableName.Length - 3).Substring(0,Math.Min(31,table.TableName.Length - 3));

      for (int i = 1; i < table.Columns.Count + 1; i++)
          excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;

      for (int j = 0; j < table.Rows.Count; j++)
      {
          for (int k = 0; k < table.Columns.Count; k++)
          {
              excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
          }
      }
  }

  SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
  saveDlg.Filter = "Execl files (*.xlsx)|*.xlsx";
  saveDlg.FilterIndex = 0;
  saveDlg.RestoreDirectory = true;
  saveDlg.CreatePrompt = true;
  saveDlg.Title = "Export Excel File To";
  if (saveDlg.ShowDialog() == DialogResult.OK)
  {
    excelWorkBook.SaveAs(saveDlg.FileName);
  }
  excelWorkBook.Saved = true;
  excelWorkBook.Close();
  excelApp.Quit();
}

void UploadResultToCosmos(string cosmosDir, string result)
{
	string fileName = DateTime.Today.ToString("yyyy-M-d") + ".txt";
	string localPath = string.Format("d:\\{0}", fileName);
	string cosmosPath = Path.Combine(cosmosDir, DateTime.Today.ToString("yyyy-M-d") + ".txt");
	File.WriteAllText(localPath,result);
	if(VcClient.VC.StreamExists(cosmosPath))
		VcClient.VC.Delete(cosmosPath);
	VcClient.VC.Upload(localPath, cosmosPath, false);
	File.Delete(localPath);
}

void DummyTail()
{
// LINQPAD C# HELPER CODE HACK: omit the last }