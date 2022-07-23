using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MYSQLsize
{
    public partial class Main : Form
    {
        // initializing components, ignore
        public Main() { InitializeComponent(); }

        // ran on startup, select textnum that's milion lightyears away
        // this is so it doesn't select first num and it looks bad if it does
        private void Main_Load(object sender, EventArgs e) { forSelection.Select(); }

        // calculates and outputs size
        private void CALCULATEbutton_Click(object sender, EventArgs e)
        {
            // calculate total bytes based on mysql sizes
            decimal totalBytes = ((TINYINTnum.Value * 1) + (SMALLINTnum.Value * 2) +
            (MEDIUMINTnum.Value * 3) + (INTINTEGERnum.Value * 4) + (BIGINTnum.Value * 8) +
            (INTINTEGERnum.Value * 4) + (BIGINTnum.Value * 4) + (FLOATnum.Value * 4) +
            (DOUBLEnum.Value * 8) + (DECIMALnum.Value * 2) + (BITnum.Value * 1) +
            (YEARnum.Value * 1) + (DATEnum.Value * 3) + (TIMEnum.Value * 3) +
            (DATETIMEnum.Value * 8) + (TIMESTAMPnum.Value * 4) +
            (TEXTANYTYPEnum.Value * AVGLENGTHnum.Value)) *
            ROWSnum.Value;

            // store to string for later formatting
            string kilobytes = (totalBytes / 1024).ToString("0.00", CultureInfo.InvariantCulture);
            string megabytes = (totalBytes / 1048576).ToString("0.00", CultureInfo.InvariantCulture);
            string gigabytes = (totalBytes / 1073741824).ToString("0.00", CultureInfo.InvariantCulture);
            string terabytes = (totalBytes / 1099511627776).ToString("0.00", CultureInfo.InvariantCulture);

            // assign formatted strings to labels
            KILOBYTEStextnum.Text = kilobytes;
            MEGABYTEStextnum.Text = megabytes;
            GIGABYTEStextnum.Text = gigabytes;
            TERABYTEStextnum.Text = terabytes;
        }
    }
}
