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
    public partial class FrmLabelChoose : Form
    {
        public FrmLabelChoose(Settings settings, string unit)
        {
            InitializeComponent();
            this.settings = settings;
            this.unit = unit;
            startup();
        }

        Settings settings;
        string unit;

        void startup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Wybór rozmiaru";
            label1.Text = "Wybierz rozmiar naklejki";
            button1.Text = "standard (52*29mm)";
            button2.Text = "duża (70*67,7mm)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GarbageBagLabel garbageBagLabel = new GarbageBagLabel("18-01-03*", settings.Company, unit, settings.Labels.Single(p => p.Id == 0));
            FrmPrintPreview frmPrintPreview = new FrmPrintPreview(garbageBagLabel, 1);
            frmPrintPreview.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GarbageBagLabel garbageBagLabel = new GarbageBagLabel("18-01-03*", settings.Company, unit, settings.Labels.Single(p => p.Id == 1));
            FrmPrintPreview frmPrintPreview = new FrmPrintPreview(garbageBagLabel, 1);
            frmPrintPreview.ShowDialog();
            this.Close();
        }
    }
}
