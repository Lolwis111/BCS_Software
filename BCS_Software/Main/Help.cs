using System;
using System.Windows.Forms;
using BCS_Software.Types;

namespace BCS_Software
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Soldat",
                "Soldat",
                $"{(Constants.SoldierOnSoldier * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Soldat",
                "Panzer",
                $"{(Constants.SoldierOnTank * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Soldat",
                "Flugzeug",
                $"{(Constants.SoldierOnJet * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));


            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "",
                "",
                "",
                ""
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Panzer",
                "Soldat",
                $"{(Constants.TankOnSoldier * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Panzer",
                "Panzer",
                $"{(Constants.TankOnTank * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Panzer",
                "Flugzeug",
                $"{(Constants.TankOnJet * 100)}%",
                $"{(Constants.TankOnJetHitChance * 100)}%",
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "",
                "",
                "",
                ""
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Flugzeug",
                "Soldat",
                $"{(Constants.JetOnSoldier * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Flugzeug",
                "Panzer",
                $"{(Constants.JetOnTank * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));

            listViewHelp.Items.Add(new ListViewItem(new string[] {
                "Flugzeug",
                "Flugzeug",
                $"{(Constants.JetOnJet * 100)}%",
                $"{(Constants.HitChance * 100)}%",
            }));
        }
    }
}
