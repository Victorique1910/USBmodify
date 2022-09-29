using System;
using System.Collections.Generic;

using System.Data;

namespace USBmodify.Src
{
    public class DataTableAttributes
    {
        public List<string> headLine
        {
            get { return new List<string>() { "Type", "PNPDeviceID", "VID", "PID", "Mark", "ComPort" }; }
        }
    }

    public class DataTableMethod: DataTableAttributes
    {      
        #region DataTableMethod       
        public DataTable dataTableBefore { get; set; }       
        public DataTable dataTableNow { get; set; }      
        public DataTable dataTableAfter
        {
            get { return UpdateDataTable(); }
        }             

        private DataTable UpdateDataTable()
        {
            DataTable _dataTableAfter = dataTableNow.Clone();
          
            for (int rowCount=0;rowCount<dataTableNow.Rows.Count;rowCount++)
            {
                DataRow dr = _dataTableAfter.NewRow();               
                for (int count=0;count<dataTableBefore.Rows.Count;count++)
                {                   
                    if (dataTableNow.Rows[rowCount]["PNPDeviceID"].ToString()==dataTableBefore.Rows[count]["PNPDeviceID"].ToString())
                    {                       
                        for (int colCount=0;colCount<_dataTableAfter.Columns.Count;colCount++)
                        {                            
                            dr[colCount] = dataTableBefore.Rows[count][colCount].ToString();
                        }
                        break;
                    }
                    else
                    {                       
                        for (int colCount = 0; colCount <_dataTableAfter.Columns.Count;colCount++)
                        {                            
                            dr[colCount] = dataTableNow.Rows[rowCount][colCount].ToString();
                        }                      
                    }
                }
                _dataTableAfter.Rows.Add(dr);
            }
            return _dataTableAfter;
        }
        #endregion
    }
}
