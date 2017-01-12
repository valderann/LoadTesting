using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadTesting
{
    public partial class frmStartScreen : Form
    {
        public frmStartScreen()
        {
            InitializeComponent();
            httpTestManager.Load();
        }

        private void frmLoadTesting_Load(object sender, EventArgs e)
        {
            /*httpTest test = new httpTest();
            test.Url = "http://localhost/linq/datasource.aspx";
            test.numberOfTests = 50;
            test.startTest();*/
            //test.downloadUrl();

            loadList();
        }

        public void loadList()
        {
            lstLoadTesting.Items.Clear();
            int intIndex =1;
            foreach (httpTest tmpTest in httpTestManager.httpTests)
            {
                ListViewItem lstViewItem = new ListViewItem(Convert.ToString(intIndex));
                lstViewItem.SubItems.Add(tmpTest.Name);
                lstViewItem.SubItems.Add(Convert.ToString(tmpTest.numberOfTests));
                lstLoadTesting.Items.Add(lstViewItem);
                intIndex += 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTestSetup frmSetup = new frmTestSetup();
            frmSetup.ShowDialog();
            loadList();
        }


        private void lstLoadTesting_DoubleClick(object sender, EventArgs e)
        {
            int intConfigurationNr=-1;
            if(int.TryParse(lstLoadTesting.SelectedItems[0].Text, out  intConfigurationNr))
            {
                frmTest tmpfrmTest = new frmTest();
                tmpfrmTest.ShowDialog(intConfigurationNr-1);

            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSettings();
        }

        private void deleteSettings()
        {
           int intConfigurationNr=-1;
           if (int.TryParse(lstLoadTesting.SelectedItems[0].Text, out  intConfigurationNr))
           {
                if (MessageBox.Show("Are you sure you want to delete this result set?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    httpTestManager.httpTests.Remove(httpTestManager.httpTests[intConfigurationNr-1]);
                    httpTestManager.Save();
                    loadList();
                }
            }
        }

        private void lstLoadTesting_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstLoadTesting.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    mnList.Show(Cursor.Position);
                }
            } 
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
              int intConfigurationNr=-1;
              if (int.TryParse(lstLoadTesting.SelectedItems[0].Text, out  intConfigurationNr))
              {
                  frmTestSetup frmSetup = new frmTestSetup();
                  frmSetup.ShowDialog(intConfigurationNr-1);
                  loadList();
              }
            
        }

        private void lstLoadTesting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstLoadTesting_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lstLoadTesting_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteSettings();
            }
        }

        private void mnList_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmdProfiler_Click(object sender, EventArgs e)
        {
            Processes procWindow = new Processes();
            procWindow.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int intConfigurationNr = -1;
            if (int.TryParse(lstLoadTesting.SelectedItems[0].Text, out  intConfigurationNr))
            {
                frmTest frmSetup = new frmTest();
                frmSetup.ShowDialog(intConfigurationNr - 1,true);
                loadList();
            }
        }

    }
}
