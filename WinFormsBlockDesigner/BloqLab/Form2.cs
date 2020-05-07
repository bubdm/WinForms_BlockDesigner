using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BloqLab
{
    public partial class Form2 : Form
    {

        public int numericWidth;
        public int numericHeight;
        public bool OkButtonState = false;

        public int GetWidth
            {
            get => numericWidth;
            }
        public int GetHeight
        {
            get => numericHeight;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            OkButtonState = true;

            numericWidth = (int)SzerokoscNumeric.Value;
            numericHeight = (int)WysokoscNumeric.Value;

            this.Close();

        }
    }
}
