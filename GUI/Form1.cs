using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        Source source = new Source();
        List list = new List();
        string[] database;
        
        public Form1()
        {
            InitializeComponent();
            stateDisabled();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            database = source.readLock();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           dataGridView1.Size = new Size(500, 250);
            var input = dataGridView1.CurrentCell.Value;
            Console.WriteLine(input);

        }

        private void updateList_Click(object sender, EventArgs e)
        {
            string[] rows = list.GetInventory();
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Warehouse");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Van");
            dt.Columns.Add("Total Amount");

            foreach (string r in rows)
            {
                DataRow dr = dt.NewRow();
                if (r != null)
                {
                    string[] values = r.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i];
                    }
                    dt.Rows.Add(dr);
                }

            }
            source.saveLock(rows);
            dataGridView1.DataSource = dt;

    }

    

        private void remove_Click(object sender, EventArgs e)
        {
            list.ChangeCount(textBox4.Text, textBox6.Text, -1);
            updateList_Click(sender, e);
        }

        private void add_Click(object sender, EventArgs e)
        {
            list.ChangeCount(textBox4.Text, textBox6.Text, 1);
            updateList_Click(sender, e);
        }

        private void getList_Click(object sender, EventArgs e)
        {
            string[] rows = database;
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Warehouse");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Van");
            dt.Columns.Add("Total Amount");

            foreach (string r in rows)
            {
                DataRow dr = dt.NewRow();
                if (r != null)
                {
                    string[] values = r.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i];
                    }
                    dt.Rows.Add(dr);
                }

            }

            list.SetCount(rows);

            dataGridView1.DataSource = dt;

            button1.Enabled = false;

        }

        private void prodID_Add_TextChanged(object sender, EventArgs e)
        {
          
            TextBox t = (TextBox)sender;
            if (!string.IsNullOrEmpty(t.Text))
            {
                stateEnabled();

                string productID = t.Text.ToString();
                //Console.WriteLine(productID);
            } else
            {
                stateDisabled();
            }
          
        }

        private void stateEnabled()
        {
            add.Enabled = true;
            updateList.Enabled = true;
            remove.Enabled = true;

        }
        
        private void stateDisabled()
        {
            add.Enabled = false;
            updateList.Enabled = false;
            remove.Enabled = false;
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!string.IsNullOrEmpty(t.Text))
            {
                stateEnabled();

                string quantity = t.Text.ToString();
            }
            else
            {
                stateDisabled();
            }

        }

        private void location_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!string.IsNullOrEmpty(t.Text))
            {
                stateEnabled();

                string location = t.Text.ToString();
            }
            else
            {
                stateDisabled();
            }
        }

        private void prodID_Search_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!string.IsNullOrEmpty(t.Text))
            {
                stateEnabled();

                string productID = t.Text.ToString();
            }
            else
            {
                stateDisabled();
            }

        }

        private void location_Search_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!string.IsNullOrEmpty(t.Text))
            {
                stateEnabled();

                string location = t.Text.ToString();
            }
            else
            {
                stateDisabled();
            }

        }
    }
}
