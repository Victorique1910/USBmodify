using System;
using System.Windows.Forms;


namespace USBmodify
{
    public partial class Form1 : Form
    {              
        public Form1()
        {
            InitializeComponent();           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartWatching();
        }

        private void Form1_Activated(object sender, EventArgs e)
        { 
            initial();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dgv_Data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReNew();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Save();
            ezUSB.RemoveUSBEventWatcher();
            System.Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
            ezUSB.RemoveUSBEventWatcher();
            System.Environment.Exit(0);
        }
        //*******************************************************************************
        //*******************************************************************************
        #region Status
        private void initial()
        {
            Clear();
            UpdateDataTable(true);
            Do();
            UpdateDataTable(false);
        }       

        private void ReNew()
        {          
            Do();
            UpdateDataTable(false);
            Save();
        }
        #endregion

       
    }
}
