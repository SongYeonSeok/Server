using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class frmAlertSettings : MetroFramework.Forms.MetroForm
    {
        public frmAlertSettings(double min_temp, double max_temp, int min_moist, int max_moist)
        {
            InitializeComponent();

            tbMinTemp.Text = $"{min_temp}";
            tbMaxTemp.Text = $"{max_temp}";
            tbMinMoist.Text = $"{min_moist}";
            tbMaxMoist.Text = $"{max_moist}";
        }



        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbType.SelectedIndex == 0)
            {
                tbMinTemp.Text = "25";
                tbMaxTemp.Text = "35";
                tbMinMoist.Text = "40";
                tbMaxMoist.Text = "55";
            }
            else if(cbType.SelectedIndex == 1)   // 크레스티드 게코 온습도 범위
            {
                tbMinTemp.Text = "18";
                tbMaxTemp.Text = "27";
                tbMinMoist.Text = "60";
                tbMaxMoist.Text = "80";
            }
            else if (cbType.SelectedIndex == 2)
            {
                tbMinTemp.Text = "23.9";
                tbMaxTemp.Text = "37.7";
                tbMinMoist.Text = "55";
                tbMaxMoist.Text = "65";
            }
            else
            {
                tbMinTemp.Clear();
                tbMaxTemp.Clear();
                tbMinMoist.Clear();
                tbMaxMoist.Clear();
            }
        }
    }
}
