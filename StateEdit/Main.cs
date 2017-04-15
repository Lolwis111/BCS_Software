using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StateEdit
{
    public partial class Main : Form
    {
        public List<State> stateList = new List<State>();

        public Main()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "State File (*.sf)|*.sf";

            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(stateList.Count > 0)
                    stateList.Clear();

                LoadFile(openFile.FileName);
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "State File (*.sf)|*.sf";

            saveFile.OverwritePrompt = true;

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(saveFile.FileName))
                    File.Delete(saveFile.FileName);

                StreamWriter writer = new StreamWriter(saveFile.FileName);

                foreach (State s in stateList)
                {
                    string state = s.DataString + ";PT" + s.Points.ToString();

                    state = state.Replace("ä", "&auml;");
                    state = state.Replace("ö", "&ouml;");
                    state = state.Replace("ü", "&uuml;");

                    state = state.Replace("Ä", "&Auml;");
                    state = state.Replace("Ü", "&Uuml;");
                    state = state.Replace("Ö", "&Ouml;");

                    state = state.Replace("ß", "&szlig;");

                    writer.WriteLine(state);
                }

                if(writer!=null)
                    writer.Dispose();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            reader.Dispose();

            string[] states = data.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string state in states)
            {
                string s = state.Replace("&auml;", "ä");
                s = s.Replace("&ouml;", "ö");
                s = s.Replace("&uuml;", "ü");

                s = s.Replace("&Ouml;", "Ö");
                s = s.Replace("&Uuml;", "Ü");
                s = s.Replace("&Auml;", "Ä");

                s = s.Replace("&szlig;", "ß");

                int end = s.LastIndexOf(';');

                string dataString = s.Substring(0, end);

                string points = s.Substring(end + 3);

                stateList.Add(new State(dataString, int.Parse(points)));
            }

            LoadList();
        }

        private void LoadList()
        {
            listStates.Items.Clear();

            foreach (State s in stateList)
            {
                listStates.Items.Add(s.DataString.Replace(";", " + "));
            }
        }

        private void listStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPoints.Text = "";
            txtFederate1.Text = "";
            txtFederate2.Text = "";
            txtFederate3.Text = "";

            string dataString = stateList[listStates.SelectedIndex].DataString;

            string[] segments = dataString.Split(';');

            txtName.Text = segments[0];

            txtPoints.Text = stateList[listStates.SelectedIndex].Points.ToString();

            if (segments.Length == 2)
            {
                txtFederate1.Text = segments[1];
            }
            else if (segments.Length == 3)
            {
                txtFederate1.Text = segments[1];
                txtFederate2.Text = segments[2];
            }
            else if (segments.Length == 4)
            {
                txtFederate1.Text = segments[1];
                txtFederate2.Text = segments[2];
                txtFederate3.Text = segments[3];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (txtPoints.Text != "")
                {
                    if (listStates.SelectedItem != null)
                    {
                        int index = listStates.SelectedIndex;

                        stateList.RemoveAt(index);
                    }

                    string dataString = txtName.Text;

                    if (txtFederate1.Text != "")
                        dataString += ";" + txtFederate1.Text;

                    if (txtFederate2.Text != "")
                        dataString += ";" + txtFederate2.Text;

                    if (txtFederate3.Text != "")
                        dataString += ";" + txtFederate3.Text;

                    stateList.Add(new State(dataString, int.Parse(txtPoints.Text)));

                    LoadList();
                }
                else
                {
                    MessageBox.Show("Es muss eine Punktanzahl angegeben werden!");
                }
            }
            else
            {
                MessageBox.Show("Es muss ein Name angegeben werden!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listStates.SelectedItem != null)
            {
                int index = listStates.SelectedIndex;

                stateList.RemoveAt(index);

                LoadList();
            }
        }

        private void txtPoints_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || 
                e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Delete || 
                e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
                e.SuppressKeyPress = false;
            else
                e.SuppressKeyPress = true;
        }
    }
}
