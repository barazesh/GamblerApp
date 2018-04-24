using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamblerFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var gamblergame = new Game(100);
            gamblergame.Initiate();
            int a=gamblergame.ComputeStateValues(0.01);
            textBox1.Text = "finished in " + a.ToString() + " iterations";
        }
    }
}
