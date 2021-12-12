using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        //string[] prolist = new Source();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.IO.StreamReader file = new System.IO.StreamReader("C:/Users/miablo/Source/Repos/Miablo/SWENG421_FinalProj/GUI/InventoryList.txt");
           

            string[] columnnames = file.ReadLine().Split(' ');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }

            file.Close();
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            String obj = (String)dataGridView1.CurrentRow.DataBoundItem;
            Console.WriteLine(obj);
        }
    }
}
