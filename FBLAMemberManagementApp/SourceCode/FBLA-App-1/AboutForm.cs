using System;
using System.Windows.Forms;

namespace FBLA
{
    // AboutForm class provides information about the application - identical to the README document
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
