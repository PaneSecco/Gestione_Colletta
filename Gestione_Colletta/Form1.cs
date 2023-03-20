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
        public Dictionary<string, float> versamento;
        public Dictionary<string, string> valuta;
        public Form1()
        {
            InitializeComponent();
            versamento = new Dictionary<string, float>();
            valuta = new Dictionary<string, string>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Persona");
            listView1.Columns.Add("Versamento");
            listView1.Columns.Add("Valuta");
            comboBox1.Items.Add("euro");
            comboBox1.Items.Add("sterline");
            comboBox1.Items.Add("dollari");
            comboBox1.Items.Add("franchi");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1.Text==null || textBox2.Text == null || comboBox1.SelectedItem == null)
            {

            }
            else
            {
                aggiungi();
            }   
        }

        public void cancella()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                versamento.Remove(listView1.SelectedItems[0].Text);
                valuta.Remove(listView1.SelectedItems[0].Text);
                listView1.SelectedItems[0].Remove();
                aggiorna();
            }
            else
            {
                MessageBox.Show("Scegliere l'elemento da eliminare!");
                return;
            }
        }

        public void cambia()
        {
            versamento[textBox1.Text]= Int32.Parse(textBox2.Text);
            valuta[textBox1.Text] = comboBox1.SelectedText;
            aggiorna();
        }

        public void aggiungi()
        {
            if (versamento.ContainsKey(textBox1.Text))
            {
                MessageBox.Show("Questa persona ha già effettuato un versamento!");
                return;
            }
            else
            {
                versamento.Add(textBox1.Text, Int32.Parse(textBox2.Text));
                valuta.Add(textBox1.Text, (String)comboBox1.SelectedItem);
                aggiorna();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        public void totale()
        {
            float somma=0;
            for(int i = 0; versamento.Count > i; i++) 
            {
                somma += versamento.ElementAt(i).Value;
            }
            label4.Text = "Totale: " + somma;
            //da rendere universale per tutte le tipologie di valute
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || comboBox1.SelectedItem == null)
            {

            }
            else
            {
                cancella();
            }
        }

      
        public void aggiorna()
        {
            listView1.Items.Clear();
            for(int a=0;a<versamento.Count;a++)
            {
                string[] row = { valuta.ElementAt(a).Key, versamento.ElementAt(a).Value.ToString(), valuta.ElementAt(a).Value };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            totale();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || comboBox1.SelectedItem == null)
            {

            }
            else
            {
                cambia();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
