﻿using System;
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
            this.Text += " wersja 1.00";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            settings = new Settings(settingsPath);
            listBox1.DataSource = settings.Units;
            radioButton1.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            label2.Text = "Copyright © 2018 by Maciej Sikorski";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                GarbageBagLabel garbageBagLabel = new GarbageBagLabel("komunalne/pozostałe", settings.Company.Name, listBox1.SelectedItem.ToString());
                FrmPrintPreview frmPrintPreview = new FrmPrintPreview(garbageBagLabel, 0);
                frmPrintPreview.ShowDialog();
            }
            else if (radioButton2.Checked)
            {
                GarbageBagLabel garbageBagLabel = new GarbageBagLabel("18-01-03*", settings.Company.Name, listBox1.SelectedItem.ToString());
                FrmPrintPreview frmPrintPreview = new FrmPrintPreview(garbageBagLabel, 1);
                frmPrintPreview.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = search(textBox1.Text);
        }

        List<string> search(string query)
        {
            query = query.ToLower();
            List<string> searchResult = settings.Units.Where(p => p.ToLower().Contains(query)).ToList();
            return searchResult;
        }
    }
}