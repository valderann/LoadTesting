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
    public partial class frmTestSetup : Form
    {
        private int _intConfigurationNr=-1;
        public frmTestSetup()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            int intRequestNumber = 0;
            int intSleepSize=0;
            int intBatchSize=0;
            string strError="";

            if(!int.TryParse(txtPerBatch.Text,out intBatchSize))
            {
                intSleepSize=0;
            }
            if(!int.TryParse(txtTimeBetweenBatch.Text,out intSleepSize))
            {
                intBatchSize=0;
            }

            if (!int.TryParse(txtRequestNumber.Text, out intRequestNumber))
            {
                strError+="Number of tests is required\n";
            }

            if (txtName.Text == "")
            {
                strError += "Name is required\n";
            }
            if (txtUrl.Text == "")
            {
                strError += "Url is required\n";
            }
            else
            {
                if (txtUrl.Text.Length > 7)
                {
                    if (txtUrl.Text.Substring(0, 7) != "http://")
                    {
                        strError += "Url is not valid\n";
                    }
                }
                else
                {
                    strError += "Url is not valid\n";
                }
            }


            if (strError == "")
            {
                httpTest tmpHttpTest = new httpTest();

                tmpHttpTest.Name = txtName.Text;
                tmpHttpTest.numberOfTests = intRequestNumber;
                tmpHttpTest.Url = txtUrl.Text;
                tmpHttpTest.userAgent = "";
                tmpHttpTest.BatchSize = intBatchSize;
                tmpHttpTest.SleepTime=intSleepSize;
                for (int i=0;i<lstPostvalues.Items.Count;i++)
                {
                    var PostValueTemp = new postValue();
                    PostValueTemp.Name = lstPostvalues.Items[i].SubItems[1].Text;
                    PostValueTemp.Value = lstPostvalues.Items[i].SubItems[2].Text;
                    tmpHttpTest.postValues.Add(PostValueTemp);
                }
                //
                if (_intConfigurationNr != -1)
                {
                    httpTestManager.httpTests[_intConfigurationNr] = tmpHttpTest;
                }
                else
                {
                    httpTestManager.httpTests.Add(tmpHttpTest);
                }
                httpTestManager.Save();

               this.Close();
            }
            else
            {
                MessageBox.Show(strError);
            }
        }

        public DialogResult ShowDialog(int intConfigurationNr) 
        {
          if (intConfigurationNr != -1) 
          {
            httpTest tmpTest = new httpTest();
            tmpTest= httpTestManager.httpTests[intConfigurationNr];
            txtUrl.Text = tmpTest.Url;
            txtName.Text = tmpTest.Name;
            txtRequestNumber.Text = Convert.ToString(tmpTest.numberOfTests);
            txtTimeBetweenBatch.Text = Convert.ToString(tmpTest.SleepTime);
            txtPerBatch.Text = Convert.ToString(tmpTest.BatchSize);
            _intConfigurationNr = intConfigurationNr;
            loadPostValues(tmpTest);
          }
          return base.ShowDialog();
        }

        private void lstPostvalues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadPostValues(httpTest tmpTest)
        {
            int intTmpIndex=1;
            foreach(var postValueResult in tmpTest.postValues)
            {
                ListViewItem lstViewItem = new ListViewItem(Convert.ToString(intTmpIndex));
                lstViewItem.SubItems.Add(postValueResult.Name);
                lstViewItem.SubItems.Add(postValueResult.Value);
                lstPostvalues.Items.Add(lstViewItem);
                intTmpIndex+=1;
            }
        }

        private void frmTestSetup_Load(object sender, EventArgs e)
        {

        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPostvalues.Items.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete all the post values?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lstPostvalues.Items.Clear();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lstPostvalues.SelectedItems.Count>0)
            {
                if (MessageBox.Show("Are you sure you want to delete these items?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = lstPostvalues.Items.Count-1; i >=0 ; i--)
                    {
                        if (lstPostvalues.Items[i].Selected)
                            lstPostvalues.Items.Remove(lstPostvalues.Items[i]);
                    }
                }
            }

        }

        private void mnPostvalue_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddPostValue frmPostValueTmp = new frmAddPostValue();
            frmPostValueTmp.ShowDialog();
            if ((!string.IsNullOrEmpty(frmPostValueTmp.PostName)) && (!string.IsNullOrEmpty(frmPostValueTmp.PostValue)))
            {
                int intTmpIndex = lstPostvalues.Items.Count + 1;
                ListViewItem lstViewItem = new ListViewItem(Convert.ToString(intTmpIndex));
                lstViewItem.SubItems.Add(frmPostValueTmp.PostName);
                lstViewItem.SubItems.Add(frmPostValueTmp.PostValue);
                lstPostvalues.Items.Add(lstViewItem);
            }
        }

    }
}
