using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using BCS_Software.Types;

namespace BCS_Software
{
    public partial class Starter : Form
    {
        private StarterSettings settingsWindow = null;

        public Starter()
        {
            InitializeComponent();
        }

        private Version GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if(settingsWindow != null)
                settingsWindow.Dispose();

            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (!checkBoxHost.Checked && !IPAddress.TryParse(textBoxPartnerIP.Text, out IPAddress tmp))
            {
                MessageBox.Show("Du hast keine oder eine ungültige IP Adresse\n eingegeben!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tmp = null;

            if (numericUpDownYourScore.Value == 0)
            {
                if (MessageBox.Show("Möchtest du wirklich mit 0 Punkten starten? Du wirst keine Chance haben!", "Wirklich starten?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }

            string stateName = checkBoxDebug.Checked ? "DEBUG" : textBoxYourName.Text;
            int statePoints = (int)numericUpDownYourScore.Value;

            if (checkBoxDebug.Checked)
            {
                new Main(string.Empty, (int)numericUpDownPort.Value, false, this, true, rdStarter.Checked, settingsWindow.CustomImages, stateName, statePoints).Show();
            }
            else
            {
                new Main(textBoxPartnerIP.Text, (int)numericUpDownPort.Value, checkBoxHost.Checked, this, false, rdStarter.Checked, settingsWindow.CustomImages, stateName, statePoints).Show();
            }
        }

        private void CheckHost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHost.Checked)
            {
                rdStarter.Checked = true;
                textBoxPartnerIP.Enabled = false;

                textBoxPartnerIP.Text = "Mögliche Server-IPs: ";

                buttonStart.Text = "Server starten";

                IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress addr in entry.AddressList)
                {
                    if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        textBoxPartnerIP.Text += addr.ToString() + ";";
                    }
                }
            }
            else
            {
                textBoxPartnerIP.Enabled = true;
                buttonStart.Text = "Verbinden";
            }
        }

        private void Starter_Load(object sender, EventArgs e)
        {
            settingsWindow = new StarterSettings
            {
                CustomImages = new CustomImages { JetImagePath = "#std", SoldierImagePath = "#std", TankImagePath = "#std" }
            };

            Version local = GetVersion();
            Version remote = GetOnlineVersion();

            labelVersion.Text = "Version: " + GetVersion().ToString();

            if (local.CompareTo(remote) < 0)
                labelVersion.Text  += "(Neue Version verfügbar)";
        }

        private Version GetOnlineVersion()
        {
            WebClient client = null;
            Version vers = new Version();
            try
            {
                client = new WebClient();

                string data = client.DownloadString("http://lolwis.bplaced.net/bcs/version.info");

                int major = int.Parse(data.Split('.')[0]);
                int minor = int.Parse(data.Split('.')[1]);
                int build = int.Parse(data.Split('.')[2]);
                int revision = int.Parse(data.Split('.')[3]);

                vers = new Version(major, minor, build, revision);
            }
            catch (Exception)
            {
                MessageBox.Show("Onlineversion konnte nicht bestimmt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                client?.Dispose();
            }

            return vers;
        }

        private void TextBoxIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 ||
                e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9 ||
                e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 ||
                e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 ||
                e.KeyCode == Keys.Home || e.KeyCode == Keys.End || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Delete ||
                e.KeyCode == Keys.Back)
                e.SuppressKeyPress = false;
            else
                e.SuppressKeyPress = true;
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            settingsWindow = new StarterSettings();
            settingsWindow.ShowDialog();
        }

        private void CheckBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDebug.Checked)
            {
                if (MessageBox.Show("Bist du sicher das du den Debug-Modus verwenden willst?\nIm Debug-Modus kann keine Verbindung hergestellt werden!\nWenn du nicht weißt was das ist, kannst du diese Option ignorieren!", "Debug", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                {
                    checkBoxDebug.Checked = false;
                    checkBoxDebug.CheckState = CheckState.Unchecked;
                    return;
                }

                buttonStart.Enabled = true;
            }
            else
            {
                if(string.IsNullOrEmpty(textBoxYourName.Text))
                    buttonStart.Enabled = false;
                else
                    buttonStart.Enabled = true;
            }
        }

        private void TextBoxYourName_Enter(object sender, EventArgs e)
        {
            textBoxYourName.Clear();
            textBoxYourName.ForeColor = System.Drawing.Color.Black;
            textBoxYourName.Font = new System.Drawing.Font(textBoxYourName.Font, System.Drawing.FontStyle.Regular);
        }

        private void TextBoxPartnerIP_Enter(object sender, EventArgs e)
        {
            textBoxPartnerIP.Clear();
            textBoxPartnerIP.ForeColor = System.Drawing.Color.Black;
            textBoxPartnerIP.Font = new System.Drawing.Font(textBoxYourName.Font, System.Drawing.FontStyle.Regular);
        }
    }
}
