using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_sheet
{
    public partial class New_Entry : Form
    {
        public Job NewJob { get; private set; }
        public New_Entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxStarted.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var started = Convert.ToDateTime(textBoxStarted.Text);
            var finished = Convert.ToDateTime(textBoxFinished.Text);

            var total = FindTotal(finished, started);
            var assigned_by = textBoxAssigned.Text;
            var comment = textBoxComment.Text;
            NewJob = new Job(started, finished, total, assigned_by, comment);

        }
        private void buttonFinished_Click(object sender, EventArgs e)
        {
            textBoxFinished.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public string FindTotal(DateTime finished, DateTime started)
        {
            int[] men = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int year = finished.Year - started.Year;
            int month = finished.Month - started.Month;
            TimeSpan all = finished - started;
            Console.WriteLine(all);
            int days = finished.Day - started.Day;
            if (days < 0)
            {
                month -= 1;
            }
            if (month < 0)
            {
                year -= 1;
                month = 12 + month;
                days = men[month - 1] + days;
            }
            else
            {
                if (days < 0)
                {
                    if (month == 0)
                    {
                        days = men[month] + days;
                    }
                    else
                    {
                        days = men[month - 1] + days;
                    }
                }
            }
            if (all.Days % 2 != days % 2)
            {
                days--;
            }
            var total = year.ToString() + " years " + month.ToString() + " months " + days.ToString() + " days " + all.Hours.ToString() + ":" + all.Minutes.ToString() + ":" + all.Seconds.ToString();
            return total;
        }
        public void FormText(string started,string finished,string assigned_by, string comment)
        {
            textBoxStarted.Text = started;
            textBoxFinished.Text = finished;
            textBoxAssigned.Text = assigned_by;
            textBoxComment.Text = comment;
        }
    }
}
