using System;
using System.Windows.Forms;

using USBmodify.Src;
using System.IO;
using System.Data;

using System.Management;

namespace USBmodify
{
    public partial class Form1 : Form
    {
        private DataTableMethod dataTableMethod = new DataTableMethod();
        private Method method = new Method();
        private USB ezUSB = new USB();
        public void Clear()
        {           
            dgv_Data.DataSource = null;            
            dgv_Data.Rows.Clear();           
        }

        public void UpdateDataTable(bool isInitial)
        {                       
            if(isInitial)
            {
                if (File.Exists(Path.Combine(System.Environment.CurrentDirectory, "log" + ".csv")))
                {
                    txt_FilePath.Clear();
                    txt_FilePath.Text = Path.Combine(System.Environment.CurrentDirectory, "log" + ".csv");
                    dataTableMethod.dataTableBefore = method.Load(txt_FilePath.Text);
                }
                else
                {
                    dataTableMethod.dataTableBefore = method.PnPEntityToDatatable();
                }
            }
            else
            {
                dataTableMethod.dataTableBefore = (dgv_Data.DataSource as DataTable);
            }          
                     
            dataTableMethod.dataTableNow = method.PnPEntityToDatatable();           
            dgv_Data.DataSource = dataTableMethod.dataTableAfter;        
            dgv_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }      

        public void Save()
        {
            DateTime dateTime = DateTime.Now;
            string dataTimeString = dateTime.Year.ToString("0000")
                                   + dateTime.Month.ToString("00")
                                   + dateTime.Day.ToString("00")
                                   + dateTime.Hour.ToString("00")
                                   + dateTime.Minute.ToString("00")
                                   + dateTime.Second.ToString("00");

            if (!Directory.Exists(Path.Combine(System.Environment.CurrentDirectory, "log")))
            {
                Directory.CreateDirectory(Path.Combine(System.Environment.CurrentDirectory, "log"));
            }
            method.Save(dgv_Data.DataSource as DataTable,
                Path.Combine(System.Environment.CurrentDirectory, "log", "log_" + dataTimeString + ".csv"));
            method.Save(dgv_Data.DataSource as DataTable,
                Path.Combine(System.Environment.CurrentDirectory, "log" + ".csv"));
        }

        public void Do()
        {
            DataTable nowDataTable = method.PnPEntityToDatatable();

            for (int rowCount = 0; rowCount < dgv_Data.Rows.Count - 1; rowCount++)
            {               
                if (dgv_Data.Rows[rowCount].Cells[dgv_Data.Columns["ComPort"].Index].Value.ToString()
                    != nowDataTable.Rows[rowCount]["ComPort"].ToString())
                {
                    method.ChangePort(nowDataTable.Rows[rowCount]["ComPort"].ToString()
                            , nowDataTable.Rows[rowCount]["PNPDeviceID"].ToString()
                            , dgv_Data.Rows[rowCount].Cells[dgv_Data.Columns["ComPort"].Index].Value.ToString());
                }
            }
        }

        public void StartWatching()
        {
            ezUSB.AddUSBEventWatcher(USBEventHandler, USBEventHandler, new TimeSpan(0, 0, 1));
        }       

        private void USBEventHandler(object sender, EventArrivedEventArgs e)
        {
            this.BeginInvoke((Action)(() => {
                UpdateDataTable(true);
            }));           
        }
    }
}
