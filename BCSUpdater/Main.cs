using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BCSUpdater
{
    public partial class Main : Form
    {
        private Version _localVersion = null;
        private Version _remoteVersion = null;

        private string _installPath = string.Empty;
        private string _executablePath = string.Empty;
        private string _versionPath = string.Empty;
        private bool _versionOk = false;
        private bool _isInstalled = false;

        public Main()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonInstall_Click(object sender, EventArgs e)
        {
            WebClient client = null;
            try
            {
                if (!Directory.Exists(_installPath))
                    Directory.CreateDirectory(_installPath);

                buttonCancel.Enabled = false;
                buttonInstall.Enabled = false;
                buttonStart.Enabled = false;

                if (File.Exists(_executablePath))
                    File.Delete(_executablePath);

                client = new WebClient();

                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);

                if (Environment.Is64BitOperatingSystem)
                {
                    client.DownloadFileAsync(new Uri("http://lolwis.bplaced.net/bcs/updates/BCS_Software64.exe"), _executablePath);
                }
                else
                {
                    client.DownloadFileAsync(new Uri("http://lolwis.bplaced.net/bcs/updates/BCS_Software32.exe"), _executablePath);
                }
            }
            catch(Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Fehler bei: {0}\n", ex.Source);
                builder.Append(ex.Message);

                MessageBox.Show(builder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                client?.Dispose();
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_executablePath);

            Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _installPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BCS");
            _executablePath = Path.Combine(_installPath, "bcs.exe");
            _versionPath = Path.Combine(_installPath, "version.info");

            _isInstalled = true;

            if (!Directory.Exists(_installPath))
            {
                _isInstalled = false;
                buttonStart.Enabled = false;
            }
            else
            {
                if (!File.Exists(_executablePath))
                {
                    _isInstalled = false;
                    buttonStart.Enabled = false;
                }

                if (!File.Exists(_versionPath))
                {
                    _isInstalled = false;
                    buttonStart.Enabled = false;
                    _versionOk = false;
                }
            }

            LoadInformation();
            LoadVersion();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarStatus.Value = e.ProgressPercentage;
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            buttonStart.Enabled = true;
            buttonCancel.Enabled = true;

            _localVersion = _remoteVersion;
            _versionOk = true;
            _isInstalled = true;

            if (File.Exists(_versionPath))
                File.Delete(_versionPath);

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(File.Open(_versionPath, FileMode.Create));
                writer.Write(_localVersion.ToString());
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Fehler bei: {0}\n", ex.Source);
                builder.Append(ex.Message);

                MessageBox.Show(builder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();
            }

            LoadVersion();

            MessageBox.Show("Das Patchen war erfolgreich!");
        }

        private void LoadVersion()
        {
            if (_versionOk)
            {
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader(File.Open(_versionPath, FileMode.Open));
                    string myVersion = reader.ReadToEnd();

                    int major = int.Parse(myVersion.Split('.')[0]);
                    int minor = int.Parse(myVersion.Split('.')[1]);
                    int build = int.Parse(myVersion.Split('.')[2]);
                    int revision = int.Parse(myVersion.Split('.')[3]);

                    _localVersion = new Version(major, minor, build, revision);
                }
                catch (Exception ex)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendFormat("Fehler bei: {0}\n", ex.Source);
                    builder.Append(ex.Message);

                    MessageBox.Show(builder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader?.Dispose();
                }
            }
            else
            {
                _localVersion = new Version(0, 0, 0, 0);
            }

            WebClient client = null;
            try
            {
                client = new WebClient();

                string data = client.DownloadString("http://lolwis.bplaced.net/bcs/version.info");

                int newMajor = int.Parse(data.Split('.')[0]);
                int newMinor = int.Parse(data.Split('.')[1]);
                int newBuild = int.Parse(data.Split('.')[2]);
                int newRevision = int.Parse(data.Split('.')[3]);

                _remoteVersion = new Version(newMajor, newMinor, newBuild, newRevision);

                labelNewVersion.Text = _remoteVersion.ToString();

                if (_isInstalled)
                {
                    labelYourVersion.Text = _localVersion.ToString();

                    if (_localVersion.CompareTo(_remoteVersion) < 0)
                    {
                        labelStatus.Text = "Neue Version verfügbar!";
                        buttonInstall.Enabled = true;
                    }
                    else
                    {
                        labelStatus.Text = "Client ist aktuell.";
                        buttonInstall.Enabled = false;
                    }
                }
                else
                {
                    labelYourVersion.Text = "Nicht Installiert";
                    labelStatus.Text = "Klicken sie auf 'Patch Installieren' um die BCS Software zu installieren!";
                }
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Fehler bei: {0}\n", ex.Source);
                builder.Append(ex.Message);

                MessageBox.Show(builder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                client?.Dispose();
            }
        }

        private void LoadInformation()
        {
            WebClient client = null;
            try
            {
                client = new WebClient();

                textInfoBox.Text = client.DownloadString("http://lolwis.bplaced.net/bcs/info.txt");
            }
            catch(Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Fehler bei: {0}\n", ex.Source);
                builder.Append(ex.Message);

                MessageBox.Show(builder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
        }
    }
}
