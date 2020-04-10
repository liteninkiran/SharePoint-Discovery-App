using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharePoint_Discovery_App
{
    public partial class frm_List : Form
    {
        public frm_List()
        {
            InitializeComponent();
        }

        private void cmd_Get_Lists_Click(object sender, EventArgs e)
        {

        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
