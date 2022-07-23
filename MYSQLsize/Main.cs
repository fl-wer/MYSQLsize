using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string kilobytes = (totalBytes / 1024).ToString();
            string megabytes = (totalBytes / 1048576).ToString();
            string gigabytes = (totalBytes / 1073741824).ToString();
            string terabytes = (totalBytes / 1099511627776).ToString();

            // leave only 2 numbers after a dot
            if (kilobytes.Contains(".") && kilobytes.Length - kilobytes.IndexOf(".") > 3)
                kilobytes = kilobytes.Remove(kilobytes.IndexOf(".") + 3);

            if (megabytes.Contains(".") && megabytes.Length - megabytes.IndexOf(".") > 3)
                megabytes = megabytes.Remove(megabytes.IndexOf(".") + 3);

            if (gigabytes.Contains(".") && gigabytes.Length - gigabytes.IndexOf(".") > 3)
                gigabytes = gigabytes.Remove(gigabytes.IndexOf(".") + 3);

            if (terabytes.Contains(".") && terabytes.Length - terabytes.IndexOf(".") > 3)
                terabytes = terabytes.Remove(terabytes.IndexOf(".") + 3);

            // leave only 2 numbers after a comma
            if (kilobytes.Contains(",") && kilobytes.Length - kilobytes.IndexOf(",") > 3)
                kilobytes = kilobytes.Remove(kilobytes.IndexOf(",") + 3);

            if (megabytes.Contains(",") && megabytes.Length - megabytes.IndexOf(",") > 3)
                megabytes = megabytes.Remove(megabytes.IndexOf(",") + 3);

            if (gigabytes.Contains(",") && gigabytes.Length - gigabytes.IndexOf(",") > 3)
                gigabytes = gigabytes.Remove(gigabytes.IndexOf(",") + 3);

            if (terabytes.Contains(",") && terabytes.Length - terabytes.IndexOf(",") > 3)
                terabytes = terabytes.Remove(terabytes.IndexOf(",") + 3);

            // assign formatted strings to labels
            KILOBYTEStextnum.Text = kilobytes;
            MEGABYTEStextnum.Text = megabytes;
            GIGABYTEStextnum.Text = gigabytes;
            TERABYTEStextnum.Text = terabytes;
        }
    }
}
