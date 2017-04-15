using System;
using System.Drawing;
using System.Windows.Forms;
using BCS_Software.Types;

namespace BCS_Software
{
    internal partial class StarterSettings : Form
    {
        public CustomImages CustomImages 
        {
            get { return _customImages; }
            set { _customImages = value; }
        }
        private CustomImages _customImages = new CustomImages();

        private bool IsSoldierSet = false;
        private bool IsTankSet = false;
        private bool IsJetSet = false;

        public StarterSettings()
        {
            InitializeComponent();
        }

        private void RdNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNormalIcons.Checked)
            {
                pictureSoldier.Image = Resource.soldier64;
                pictureTank.Image = Resource.tank64;
                pictureJet.Image = Resource.jet64;
                IsSoldierSet = true;
                IsTankSet = true;
                IsJetSet = true;
            }
            else
            {
                pictureSoldier.Image = new Bitmap(64, 64);
                pictureTank.Image = new Bitmap(64, 64);
                pictureJet.Image = new Bitmap(64, 64);
            }
        }

        private void PictureSoldier_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rdCustomIcons.Checked)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Bild Dateien|*.jpg;*.png;*.gif;*.jpeg";
                    openFile.Multiselect = false;
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        pictureSoldier.Image = Image.FromFile(openFile.FileName);
                        _customImages.SoldierImagePath = openFile.FileName;
                        IsSoldierSet = true;
                    }

                    openFile.Dispose();
                }
            }
            else
            {
                _customImages.SoldierImagePath = "#std";
                pictureSoldier.Image = Resource.soldier64;
                IsSoldierSet = true;
            }
        }

        private void PictureTank_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rdCustomIcons.Checked)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Bild Dateien|*.jpg;*.png;*.gif;*.jpeg";
                    openFile.Multiselect = false;
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        pictureTank.Image = Image.FromFile(openFile.FileName);
                        _customImages.TankImagePath = openFile.FileName;
                        IsTankSet = true;
                    }

                    openFile.Dispose();
                }
            }
            else
            {
                _customImages.TankImagePath = "#std";
                pictureTank.Image = Resource.tank64;
                IsTankSet = true;
            }
        }

        private void PictureJet_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rdCustomIcons.Checked)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Bild Dateien|*.jpg;*.png;*.gif;*.jpeg";
                    openFile.Multiselect = false;
                    if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        pictureJet.Image = Image.FromFile(openFile.FileName);
                        _customImages.JetImagePath = openFile.FileName;
                        IsJetSet = true;
                    }

                    openFile.Dispose();
                }
            }
            else
            {
                _customImages.JetImagePath = "#std";
                pictureJet.Image = Resource.jet64;
                IsJetSet = true;
            }
        }

        private void StarterSettings_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!IsSoldierSet)
            {
                MessageBox.Show("Es wurde kein Bild für den Soldaten ausgewählt!", "Kein Bild", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!IsTankSet)
            {
                MessageBox.Show("Es wurde kein Bild für den Panzer ausgewählt!", "Kein Bild", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!IsJetSet)
            {
                MessageBox.Show("Es wurde kein Bild für das Flugzeug ausgewählt!", "Kein Bild", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Close();
        }
    }
}
