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

    public partial class frmAddPostValue : Form
    {   
        public string PostValue{get;set;}
        public string PostName{get;set;}
        public frmAddPostValue()
        {
            InitializeComponent();
        }

        private void frmAddPostValue_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            PostValue=txtValue.Text;
            PostName=txtName.Text;
            Close();
        }
    }
}
