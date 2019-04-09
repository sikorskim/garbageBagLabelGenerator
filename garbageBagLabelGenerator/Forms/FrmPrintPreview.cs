using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace garbageBagLabelGenerator
{
    public partial class FrmPrintPreview : Form
    {
        public FrmPrintPreview(GarbageBagLabel garbageBagLabel, int code)
        {
            InitializeComponent();
            this.garbageBagLabel = garbageBagLabel;
            this.code = code;
            startup();
        }

        void startup()
        {
            this.WindowState = FormWindowState.Maximized;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            printPreviewControl1.Document = printDocument1;
        }

        int code;
        GarbageBagLabel garbageBagLabel;

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            garbageBagLabel.print(e,code);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult result = printDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument1.PrinterSettings.Copies=printDialog1.PrinterSettings.Copies;
                printDocument1.PrinterSettings.PrinterName=printDialog1.PrinterSettings.PrinterName;
                printDocument1.Print();                
            }
        }
    }
}
