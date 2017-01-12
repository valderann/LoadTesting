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
    public partial class frmTest : Form
    {
        private int _intConfigurationNr=-1;
        private bool _blShowTest = false;

        private ListViewColumnSorter _listSort;
        public frmTest()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(int intConfigurationNr,bool showTest)
        {
            _blShowTest = showTest;
            return ShowDialog(intConfigurationNr);
        }

        public DialogResult ShowDialog(int intConfigurationNr)
        {
            _listSort = new ListViewColumnSorter(lstTestResults);
            if (intConfigurationNr != -1)
            {
                _intConfigurationNr = intConfigurationNr;
                lnkUrl.Text=httpTestManager.httpTests[_intConfigurationNr].Url;
            }
            return base.ShowDialog();
        }

        private void loadResults()
        {
            if (_intConfigurationNr != -1)
            {
                httpTest tmpTest = new httpTest();
                tmpTest = httpTestManager.httpTests[_intConfigurationNr];
                if (tmpTest.testResults.Count > 0)
                {
                    long lngAvg = (long)tmpTest.testResults.Average(s => s.intConnectTimeMS);
                    long lngMin = tmpTest.testResults.Min(s => s.intConnectTimeMS);
                    long lngMax = tmpTest.testResults.Max(s => s.intConnectTimeMS);
                    long lngCount = tmpTest.testResults.Count;
                    var sortedByDownTimeList = tmpTest.testResults.OrderBy(s => s.intConnectTimeMS).ToList();
                    long lngMedian = sortedByDownTimeList[(int)(lngCount / 2)-1].intConnectTimeMS;

                    lblStatus.Text = "Date:" + tmpTest.LastStartDate.ToString() + "\nResults: " + Convert.ToString(lngCount) + "\nMedian: " +  Convert.ToString(lngMedian) + "\nAvg: " + Convert.ToString(lngAvg) + " ms.\nMin: " + Convert.ToString(lngMin) + " ms.\nMax: " + Convert.ToString(lngMax) + " ms.\n";
                    lstTestResults.Items.Clear();

                    int intTmpIndex = 1;
                    foreach (testResult tmpTestresults in tmpTest.testResults.Take(100))
                    {
                        string strTimeType= "ms";
                        long intTime=tmpTestresults.intConnectTimeMS;
                        long intTotalTime = intTime;
                        if (intTime / (1000 * 60) > 1) { strTimeType = "m"; intTotalTime = intTotalTime / (1000 * 60); }
                        else if (intTime / 1000 > 1) { strTimeType = "s"; intTotalTime = intTotalTime / (1000 ); }
                        ListViewItem lstViewItem = new ListViewItem(Convert.ToString(intTmpIndex));
                        lstViewItem.SubItems.Add(Convert.ToString(intTime) + " " + strTimeType);
                        lstViewItem.SubItems.Add(Convert.ToString(tmpTestresults.intDownBytes));
                        lstViewItem.SubItems.Add(Convert.ToString(tmpTestresults.intHTTPStatus));
                        lstTestResults.Items.Add(lstViewItem);
                        intTmpIndex += 1;
                    }
                }
            }
        }


        private void frmTest_Load(object sender, EventArgs e)
        {
             loadResults();
             if (_blShowTest)
             {
                 startTesting();
             }

        }

        private void startTesting()
        {
            frmTestProgress testProgressWindow = new frmTestProgress();
            testProgressWindow.ShowDialog(_intConfigurationNr);
            loadResults();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            startTesting();
        }

        private void cmdLoadResults_Click(object sender, EventArgs e)
        {
            loadResults();
            httpTestManager.Save();
        }

        private void lnkUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(lnkUrl.Text.Substring(0,7)=="http://")
            {
            System.Diagnostics.Process.Start(lnkUrl.Text);
            }
        }

        private void lstTestResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _listSort.Sort(e);
        }

        private void lstTestResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
