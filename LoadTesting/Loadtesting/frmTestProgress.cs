using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoadTesting;

namespace LoadTesting
{
    

    public partial class frmTestProgress : Form
    {

        
        public frmTestProgress()
        {
            InitializeComponent();
        }
        private int _intConfigurationNr;
        public void UpdateProgressBar(progressResult result)
        {
           if(LoadTestingProgress.InvokeRequired)
           {
               LoadTestingProgress.Invoke(new httpTest.SetProgressBarCallback(UpdateProgressBar), new object[]{result});
           }
           else
           {
               lblProgress.Text = result.PercentageDone+ " %";
               lblRequests.Text = Convert.ToString(result.HttpRequestsDone);
               lblTotal.Text = Convert.ToString(result.HttpTotalRequests);
               LoadTestingProgress.Value = result.PercentageDone;
           }  
       }

        private void frmTestProgress_Load(object sender, EventArgs e)
        {
 
        }

        public DialogResult ShowDialog(int intConfigurationNr)
        {
            _intConfigurationNr = intConfigurationNr;
            if (intConfigurationNr != -1)
            {
                httpTestManager.httpTests[intConfigurationNr].OnProgressChanged+=UpdateProgressBar;
                httpTestManager.httpTests[intConfigurationNr].startTest();
            }
            return base.ShowDialog();
        }

        private void LoadTestingProgress_Click(object sender, EventArgs e)
        {

        }

        private void frmTestProgress_Deactivate(object sender, EventArgs e)
        {
            if (_intConfigurationNr != -1)
            {
                httpTestManager.httpTests[_intConfigurationNr].stopTest();
            }
        }

    }
}
