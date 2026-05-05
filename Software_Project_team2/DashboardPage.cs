using Software_Project_team2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public partial class DashboardPage : UserControl
    {
        private KlasService klasService;
        private EverytimeService everytimeService;
        public DashboardPage(KlasService klas, EverytimeService every)
        {
            InitializeComponent();

            klasService = klas;
            everytimeService = every;
        }


    }
}