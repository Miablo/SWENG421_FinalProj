using System;
using System.Data;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            database = source.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //System.IO.StreamReader file = new System.IO.StreamReader("C:/Users/miablo/Source/Repos/Miablo/SWENG421_FinalProj/GUI/InventoryList.txt");

            string[] columnnames = database;
            DataTable dt = new DataTable();

                dt.Columns.Add("Name");
                dt.Columns.Add("Amount");
            
            foreach (string r in columnnames)
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
            
            

            //file.Close();
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            String obj = (String)dataGridView1.CurrentRow.DataBoundItem;
            Console.WriteLine(obj);
        }
    }
}
