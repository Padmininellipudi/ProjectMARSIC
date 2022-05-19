using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
namespace ProjectMARSIC.DataUtility
{
    public class ExcelUtility1
    {
        public List<DataCollection> dcList = new List<DataCollection>();

        public int TotalRows { get; set; }

        public DataTable readExcelDataIntoDataTable(string filename, string sheetName)
        {
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTableCollection tableColl = result.Tables;
                    DataTable dataTable = tableColl[sheetName];
                    return dataTable;
                }
            }
        }

        public void populateDataCollectionList()
        {
            string RootFolder = Directory.GetParent(@"../../../").FullName
                + Path.DirectorySeparatorChar + "Data"
                + Path.DirectorySeparatorChar + "ShareSkillAddListings.xls";
            //Console.WriteLine(RootFolder);
            DataTable dt = readExcelDataIntoDataTable(RootFolder, "Share_Skill_Add_Listing");
            Console.WriteLine(dt);
            TotalRows = dt.Rows.Count;
            Console.WriteLine(dt.Rows.Count);
            Console.WriteLine(dt.Columns.Count);

            for (int row = 0; row < dt.Rows.Count; row++)
            {
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNum = row,
                        colName = dt.Columns[col].ColumnName.ToUpper(),
                        colValue = dt.Rows[row][col].ToString()
                    };
                    dcList.Add(dtTable);
                    //Console.WriteLine(dcList.Count);
                }
            }
        }

        public string readSingleRowData(int rownum, string colname)
        {
            try
            {
                string data = (from colData in dcList
                               where colData.colName == colname && colData.rowNum == rownum
                               select colData.colValue).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}





