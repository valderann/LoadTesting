using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;

namespace LoadTesting
{
    public partial class Processes : Form
    {
        public Processes()
        {
            InitializeComponent();
        }
        private ListViewColumnSorter _listSort;
        private void GetProcessChildren(int? pid)
        {
            int intTmpIndex = 1;
            var myId = Process.GetCurrentProcess().Id;
            var query = (pid == 0) ? "SELECT * FROM Win32_Process WHERE ParentProcessId=processID" : string.Format("SELECT * FROM Win32_Process WHERE ParentProcessId = {0}", pid);
            using (var search = new ManagementObjectSearcher("root\\CIMV2", query))
            {
                foreach (ManagementObject process in search.Get())
                {
                    uint parentId = (uint)process["ParentProcessId"];
                    uint ProcessId=(uint)process["ProcessId"];
                    string name = (string)process["Name"];
                    
                   
                    ListViewItem lstViewItem = new ListViewItem(Convert.ToString(intTmpIndex));
                    lstViewItem.SubItems.Add(Convert.ToString(ProcessId));

                    lstViewItem.SubItems.Add(name);
                    lstViewItem.SubItems.Add("");
                    lstProcesses.Items.Add(lstViewItem);
                    if (ProcessId != 0 ) { GetProcessChildren((int?)ProcessId); }
                }
            }
        }

        private void LoadProcesses()
        {
            lstProcesses.Items.Clear();
           // GetProcessChildren(0);

            int intTmpIndex=1;
            var processList = Process.GetProcesses().OrderBy(s => s.ProcessName);
            foreach (var proc in processList)
            {
               
                 ListViewItem lstViewItem = new ListViewItem(Convert.ToString(intTmpIndex));
                 lstViewItem.SubItems.Add(Convert.ToString(proc.Id));
                 
                 lstViewItem.SubItems.Add( proc.ProcessName);
                 lstViewItem.SubItems.Add("");
                 lstProcesses.Items.Add(lstViewItem);
                 intTmpIndex+=1;
            }
        }

        private void Processes_Load(object sender, EventArgs e)
        {
            _listSort = new ListViewColumnSorter(lstProcesses);
            LoadProcesses();
        }

        private void lstProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void lstProcesses_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lstProcesses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _listSort.Sort(e);
        }
    }
}
