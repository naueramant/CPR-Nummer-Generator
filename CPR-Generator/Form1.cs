using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPR;

namespace CPR_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool IsMale;

            if(radioButton2.Checked == true)
            {IsMale = true;}else{IsMale = false;}

            textBox1.Text = CPR_utilities.Generate(dateTimePicker1.Value.Date, IsMale, false);
        }
    }
}
