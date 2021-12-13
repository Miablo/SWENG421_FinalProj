using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        Source source = new Source();
        string[] database;
        
        public Form1()
        {
            InitializeComponent();
            stateDisabled();

            this.Size = new Size(600, 600);

            add.Text = "Add Row";
            add.Location = new Point(100, 20);
            remove.Location = new Point(300, 20);
            updateList.Location = new Point(200, 20);
            getList.Location = new Point(10, 20);
            add.Click += new EventHandler(add_Click);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            database = source.GetData();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //dataGridView1.Size = new Size(600, 500);
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
            var input = dataGridView1.CurrentCell.Value;
            Console.WriteLine(input);

            
        }

        private void updateList_Click(object sender, EventArgs e)
        {
            
            

        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CurrentCell.Value = dataGridView1.CurrentCell.Value;

            }

        }

        private void add_Click(object sender, EventArgs e)
        {

        }

        private void getList_Click(object sender, EventArgs e)
        {
            stateEnabled();

            string[] rows = database;
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Location");
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

            dataGridView1.DataSource = dt;

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

        private void prodID_Search_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!string.IsNullOrEmpty(t.Text))
            {
                stateEnabled();

                string productID = t.Text.ToString();
                Console.WriteLine(productID);
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
                Console.WriteLine(location);
            }
            else
            {
                stateDisabled();
            }

        }
    }
}
