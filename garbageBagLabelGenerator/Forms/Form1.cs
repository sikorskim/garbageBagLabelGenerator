using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace garbageBagLabelGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            startup();
        }

        string settingsPath = "settings.xml";
        Settings settings;

        void startup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text += " wersja 1.32";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            radioButton1.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            label2.Text = "Copyright © 2018 by Maciej Sikorski";
            loadSettings();
        }

        void loadSettings()
        {
            settings = new Settings(settingsPath);
            if (settings.importFromXML())
            {
                dataGridView1.DataSource = settings.Units;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                dataGridView1.ColumnHeadersVisible = false;
            }
            else
            {
                string message = "Brak lub uszkodzony plik "+settingsPath+"!\nSkontaktuj się z administratorem.";
                MessageBox.Show(message);
                button1.Enabled = false;
            }
        }

        void generate()
        {
            string unit = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            if (radioButton1.Checked)
            {
                GarbageBagLabel garbageBagLabel = new GarbageBagLabel("komunalne/pozostałe", settings.Company, unit, settings.Labels.Single(p => p.Id == 0));
                FrmPrintPreview frmPrintPreview = new FrmPrintPreview(garbageBagLabel, 0);
                frmPrintPreview.ShowDialog();
            }
            else if (radioButton2.Checked)
            {
                GarbageBagLabel garbageBagLabel = new GarbageBagLabel("18-01-03*", settings.Company, unit, settings.Labels.Single(p => p.Id == 1));
                FrmPrintPreview frmPrintPreview = new FrmPrintPreview(garbageBagLabel, 1);
                frmPrintPreview.ShowDialog();
            }
            else if (radioButton3.Checked)
            {
                GarbageBagLabel garbageBagLabel = new GarbageBagLabel("18-01-02*", settings.Company, unit, settings.Labels.Single(p => p.Id == 1));
                FrmPrintPreview frmPrintPreview = new FrmPrintPreview(garbageBagLabel, 1);
                frmPrintPreview.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = search(textBox1.Text);
        }

        List<Unit> search(string query)
        {
            query = query.ToLower();
            List<Unit> searchResult = settings.Units.Where(p => p.Name.ToLower().Contains(query)).ToList();
            return searchResult;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            generate();
        }
    }
}
