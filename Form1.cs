using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssv_lv1_zad2
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer t;
        DateTime alarmTime;
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(vrijeme);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void vrijeme(object s, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                label1.Text = "Current time:" + DateTime.Now.ToString();
                if(DateTime.Now >= alarmTime)
                {
                    Console.Beep();
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t.Enabled == false)
            {
                t.Start(); 
                button1.Text = "Zaustavi";
                dateTimePicker1.Enabled = false;
                alarmTime = dateTimePicker1.Value;
                alarmTime = alarmTime.AddSeconds(dateTimePicker1.Value.Second * -1);
            }
            else
            {
                t.Stop(); 
                button1.Text = "Pokreni";
                dateTimePicker1.Enabled = true;
                alarmTime = DateTime.MaxValue;
                label1.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
