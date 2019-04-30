using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        Dictionary<DateTime, string> tasks = new Dictionary<DateTime, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtTask.Text == string.Empty)
            {
                MessageBox.Show("You Must Enter a Task");
            } 
            else if (tasks.ContainsKey(dtpTaskDate.Value.Date))
            {
                MessageBox.Show("You Can Only Make One Task Per Date");
            }
            else 
            {
                tasks.Add(dtpTaskDate.Value.Date, txtTask.Text);
                lstTasks.Items.Add(tasks.LastOrDefault().Key);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                lblTaskDetails.Text = tasks[Convert.ToDateTime(lstTasks.SelectedItem)];
            }
            else
            {
                lblTaskDetails.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstTasks.Sorted = true;
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select an Item to Delete");
            }
            else
            {
                tasks.Remove(Convert.ToDateTime(lstTasks.SelectedItem));
                lstTasks.Items.Remove(lstTasks.SelectedItem);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            
            foreach (DateTime date in tasks.Keys)
            {
                msg += $"{date.ToShortDateString()} ";
                foreach(string task in tasks.Values)
                {
                    msg += $"{task.ToString()}\n";
                }
            }

            MessageBox.Show(msg);
        }
    }
}

