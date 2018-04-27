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
            chart1.Series.Clear();
            double eps = double.Parse(txtAccuracy.Text);            
            var gamblergame = new Game(100);
            gamblergame.Initiate();
            double variance = 2 * eps;
            int itr = 0;
            while (variance > eps)
            {
                variance = 0;
                double[] oldstate = gamblergame.Getvalues();
                double[] newState = gamblergame.ComputeStateValues();
                
                for (int i = 0; i < 100; i++)
                {
                    variance = Math.Max(variance, Math.Abs(newState[i] - oldstate[i]));
                }
                itr++;
                string name = "Sweap" + itr.ToString();
                chart1.Series.Add(name);
                chart1.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[name].Points.DataBindY(newState);

            }
            int[] strategies = gamblergame.GetStrategies();
            chart2.Series.Clear();
            chart2.Series.Add("Strategies");
            chart2.Series["Strategies"].Points.DataBindY(strategies);
            textBox1.Text = "finished in " + itr.ToString() + " iterations";
            
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            var gamblergame = new Game(100);
            gamblergame.Initiate();
            double[] newState = gamblergame.ComputeStateValues();
            textBox1.Text = "test was successfull";
        }
    }
}
