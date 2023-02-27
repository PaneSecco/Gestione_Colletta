using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestione_Colletta
{
    public partial class Form1 : Form
    {
        Dictionary<string, float> colletta;
        public Form1()
        {
            InitializeComponent();
            colletta = new Dictionary<string, float>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Persona");
            listView1.Columns.Add("Versamento");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colletta.ContainsKey(textBox1.Text))
            {
                MessageBox.Show("Questa persona ha già effettuato un versamento!");
            }
            else
            {
                string[] row = { textBox1.Text, textBox2.Text };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
                colletta.Add(textBox1.Text, int.Parse(textBox2.Text));
            }
        }
    }
}
