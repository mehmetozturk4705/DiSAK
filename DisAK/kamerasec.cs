using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisAK
{
    public partial class kamerasec : Form
    {
        public string[] kameranames;
        public string kamera;
        public kamerasec()
        {
            InitializeComponent();
        }

        private void kamerasec_Load(object sender, EventArgs e)
        {

            
            for (int i = 0; i < kameranames.Length; i++)
                kameralar.Items.Add(kameranames[i]);


            kameralar.SelectedIndex = 0;
        }

        private void tamam_Click(object sender, EventArgs e)
        {
            this.kamera = kameralar.SelectedItem.ToString();
            this.Close();
        }

        
    }
}
