using System;
using System.Collections.Generic;

using System.Data;
using System.IO;


namespace USBmodify.Src
{
    public class Attributes
    {
             
    }


    public class Method:Attributes
    {
        private WmiUsbMethod wmiUsbMethod = new WmiUsbMethod();                 //來源
        private DataTableMethod dataTableMethod = new DataTableMethod();        //HeadLine參數輸入

        public DataTable Load(string filePath)
        {
            DataTable dataTable = new DataTable();
            FileStream fs = new FileStream(filePath,System.IO.FileMode.Open,System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string strLine = "";
            string[] aryLine = null;
            string[] headLine = null;
            int columnCount = 0;
            bool isFirst = true;

            while((strLine = sr.ReadLine())!=null)
            {
                if(isFirst)
                {
                    headLine = strLine.Split(',');
                    isFirst = false;
                    columnCount = headLine.Length;

                    //建立列
                    for(int i =0;i<columnCount;i++)
                    {
                        DataColumn dc = new DataColumn(headLine[i]);
                        dataTable.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dataTable.NewRow();
                    for(int j=0;j<columnCount;j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dataTable.Rows.Add(dr);
                }
            }
            sr.Close();
            fs.Close();

            return dataTable;
        }

        public void Save(DataTable dataTable, string filePath)
        {
            FileInfo fi = new System.IO.FileInfo(filePath);
            if(!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(filePath,System.IO.FileMode.Create,System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs,System.Text.Encoding.Default);

            string data = "";
            for(int i=0;i<dataTable.Columns.Count;i++)
            {
                data += dataTable.Columns[i].ColumnName.ToString();
                if(i<dataTable.Columns.Count-1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);

            for(int i=0; i<dataTable.Rows.Count; i++)
            {
                data = "";
                for(int j=0; j<dataTable.Columns.Count;j++)
                {
                    string str = dataTable.Rows[i][j].ToString();
                    str = str.Replace("\"","\"\"");
                    if(str.Contains(",")||str.Contains("\"")||str.Contains("\r") ||str.Contains("\n"))
                    {
                        str = string.Format("\"{0}\"",str);
                    }
                    data += str;

                    if(j< dataTable.Columns.Count-1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }

        public void ChangePort(string comPortBefore,string pnpDeviceID, string comPortAfter)
        {          
            RegistryMethod registryMethod = new RegistryMethod();
            registryMethod.comPortBefore = comPortBefore;
            registryMethod.pnpDeviceID = pnpDeviceID;
            registryMethod.comPortAfter = comPortAfter;

            registryMethod.Change1();
            registryMethod.Change2();
            registryMethod.Change3();
            //registryMethod.Change4();
        }

        public DataTable PnPEntityToDatatable()
        {
            //創新DataTable
            DataTable dataTable = new DataTable();
            //建立headLine
            DataColumn dc = new DataColumn();
            foreach (string headLine in dataTableMethod.headLine)
            {
                dc = dataTable.Columns.Add(headLine);
            }
            //建立Rows
            int rowCount = 0;
            foreach (PnPEntityInfo AllPnPEntitie in wmiUsbMethod.AllPnPEntities)
            {
                DataRow dr = dataTable.NewRow();
                dr["PNPDeviceID"] = AllPnPEntitie.PNPDeviceID;
                dr["VID"] = AllPnPEntitie.VID;
                dr["PID"] = AllPnPEntitie.PID;
                dr["ComPort"] = AllPnPEntitie.ComPort;
                dataTable.Rows.Add(dr);
                rowCount++;
            }
            return dataTable;
        }        
    }   
}
