using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;
using BCS_Software.Types;

namespace BCS_Software
{
    internal partial class Main : Form
    {
        #region Fields

        private const int WidthNoChat = 681;
        private const int WidthWithChat = 1043;

        private bool _chatVisible = false;

        private int _startPower = 1000;
        private int _buyPoints = 1000;

        private string _ip = string.Empty;
        private int _port = 0;

        private StringBuilder _commands = new StringBuilder();

        private WarType _atacker = WarType.None;

        private WarType _enemy = WarType.None;

        private Player _playerYou = new Player();

        private Player _playerEnemy = new Player();

        private bool _isHost = false;

        private NetworkManager _connectionObject;

        private Starter _starter;

        private int _startObjectSum = 0;

        private bool _yourTurn = false;

        private bool _debug = false;

        private Random _random = new Random();

        private bool _serverEstablished = false;

        #endregion

        #region Konstruktor

        public Main(string serverIp, int port, bool isHost, Starter starter, bool debugMode, bool firstMove, CustomImages customImages, string stateName, int statePoints)
        {
            _debug = debugMode;
            _starter = starter;
            _ip = serverIp;
            _isHost = isHost;
            _yourTurn = firstMove;
            _playerYou = new Player
            {
                IsReady = false,
                Jets = 0,
                LivePoints = statePoints,
                Name = stateName,
                Soldiers = 0,
                StartPoints = statePoints,
                Tanks = 0
            };
            _port = port;

            InitializeComponent();

            LoadImages(customImages);
        }

        #endregion

        #region Angriff

        private void PcSoldierEnemy_MouseClick(object sender, MouseEventArgs e)
        {
            if (_yourTurn)
            {
                pcJetEnemy.Enabled = false;
                labelJetEnemy.Enabled = false;

                pcSoldierEnemy.Enabled = false;
                labelSoldierEnemy.Enabled = false;

                pcTankEnemy.Enabled = false;
                labelTankEnemy.Enabled = false;

                _yourTurn = false;

                _enemy = WarType.Soldier;

                _commands.Append("/y");

                DefineAtackCommand();
            }
        }

        private void PcTankEnemy_MouseClick(object sender, MouseEventArgs e)
        {
            if (_yourTurn)
            {
                pcJetEnemy.Enabled = false;
                labelJetEnemy.Enabled = false;

                pcSoldierEnemy.Enabled = false;
                labelSoldierEnemy.Enabled = false;

                pcTankEnemy.Enabled = false;
                labelTankEnemy.Enabled = false;

                _yourTurn = false;

                _enemy = WarType.Tank;

                _commands.Append("/y");

                DefineAtackCommand();
            }
        }

        private void PcJetEnemy_MouseClick(object sender, MouseEventArgs e)
        {
            if (_yourTurn)
            {
                pcJetEnemy.Enabled = false;
                labelJetEnemy.Enabled = false;

                pcSoldierEnemy.Enabled = false;
                labelSoldierEnemy.Enabled = false;

                pcTankEnemy.Enabled = false;
                labelTankEnemy.Enabled = false;

                _yourTurn = false;

                _enemy = WarType.Jet;

                _commands.Append("/y");

                DefineAtackCommand();
            }
        }

        private void DefineAtackCommand()
        {
            int rnd = _random.Next(0, 100);
            if (rnd < 10)
            {
                _commands.Append("/a99");
                listBoxLog.Items.Add("Dein Angriff ging daneben!");
                return;
            }


            switch (_atacker)
            {
                case WarType.Jet:
                    switch (_enemy)
                    {
                        case WarType.Jet:
                            {
                                _commands.Append("/a33");
                                listBoxLog.Items.Add("Jet hat einen feindlichen Jet zerstört!");
                                break;
                            }
                        case WarType.Soldier:
                            {
                                _commands.Append("/a31");
                                listBoxLog.Items.Add("Jet hat eine feindliche Bodeneinheit zerstört!");
                                break;
                            }
                        case WarType.Tank:
                            {
                                _commands.Append("/a32");
                                listBoxLog.Items.Add("Panzer wurde von feindlichem Jet stark beschädigt!");
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                case WarType.Soldier:
                    switch (_enemy)
                    {
                        case WarType.Jet:
                            {
                                _commands.Append("/a13");
                                listBoxLog.Items.Add("Bodeneinheit hat einen feindlichen Jet beschädigt!");
                                break;
                            }
                        case WarType.Soldier:
                            {
                                _commands.Append("/a11");
                                listBoxLog.Items.Add("Bodeneinheit hat eine feindliche Bodeneinheit zerstört!");
                                break;
                            }
                        case WarType.Tank:
                            {
                                _commands.Append("/a12");
                                listBoxLog.Items.Add("Bodenheit hat einen feindlichen Panzer beschädigt!");
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                case WarType.Tank:
                    switch (_enemy)
                    {
                        case WarType.Jet:
                            {
                                rnd = _random.Next(0, 100);
                                if (rnd <= 1)
                                {
                                    _commands.Append("/a23a");
                                    listBoxLog.Items.Add("GLÜCKSTREFFER! Dein Panzer zertört einen Jet!");
                                }
                                else
                                {
                                    _commands.Append("/a23");
                                    listBoxLog.Items.Add("Panzer sind nicht effektiv gegen Jets.");
                                }

                                break;
                            }
                        case WarType.Soldier:
                            {
                                _commands.Append("/a21");
                                listBoxLog.Items.Add("Panzer hat zwei Bodeneinheiten zerstört!");
                                break;
                            }
                        case WarType.Tank:
                            {
                                _commands.Append("/a22");
                                listBoxLog.Items.Add("Panzer wurde von feindlichem Panzer zerstört!");
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Deine Knöpfe

        private void PcSoldierYou_MouseClick(object sender, MouseEventArgs e)
        {
            if (_playerEnemy.IsReady && _playerYou.IsReady)
            {
                if (_playerEnemy.Jets <= 0)
                {
                    pcJetEnemy.Enabled = false;
                    labelJetEnemy.Enabled = false;
                }
                else
                {
                    pcJetEnemy.Enabled = true;
                    labelJetEnemy.Enabled = true;
                }

                if (_playerEnemy.Soldiers <= 0)
                {
                    pcSoldierEnemy.Enabled = false;
                    labelSoldierEnemy.Enabled = false;
                }
                else
                {
                    pcSoldierEnemy.Enabled = true;
                    labelSoldierEnemy.Enabled = true;
                }

                if (_playerEnemy.Tanks <= 0)
                {
                    pcTankEnemy.Enabled = false;
                    labelTankEnemy.Enabled = false;
                }
                else
                {
                    pcTankEnemy.Enabled = true;
                    labelTankEnemy.Enabled = true;
                }

                _atacker = WarType.Soldier;
            }
            else if(_playerYou.IsReady)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (_buyPoints - Constants.SoldierPoints <= 0)
                        return;

                    _playerYou.Soldiers++;
                    _buyPoints -= Constants.SoldierPoints;
                    
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (_playerYou.Soldiers == 0)
                        return;

                    _playerYou.Soldiers--;
                    _buyPoints += Constants.SoldierPoints;
                }

                labelSoldierYou.Text = $"Bodeneinheit ({Math.Ceiling(_playerYou.Soldiers).ToString("D2")})";
                buttonReady.Text = $"Fertig ({_buyPoints})";
            }
        }

        private void PcTankYou_MouseClick(object sender, MouseEventArgs e)
        {
            if (_playerEnemy.IsReady && _playerYou.IsReady)
            {
                if (_playerEnemy.Jets <= 0)
                {
                    pcJetEnemy.Enabled = false;
                    labelJetEnemy.Enabled = false;
                }
                else
                {
                    pcJetEnemy.Enabled = true;
                    labelJetEnemy.Enabled = true;
                }

                if (_playerEnemy.Soldiers <= 0)
                {
                    pcSoldierEnemy.Enabled = false;
                    labelSoldierEnemy.Enabled = false;
                }
                else
                {
                    pcSoldierEnemy.Enabled = true;
                    labelSoldierEnemy.Enabled = true;
                }

                if (_playerEnemy.Tanks <= 0)
                {
                    pcTankEnemy.Enabled = false;
                    labelTankEnemy.Enabled = false;
                }
                else
                {
                    pcTankEnemy.Enabled = true;
                    labelTankEnemy.Enabled = true;
                }

                _atacker = WarType.Tank;
            }
            else if(_playerYou.IsReady)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (_buyPoints - Constants.TankPoints <= 0)
                        return;

                    _playerYou.Tanks++;
                    
                    _buyPoints -= Constants.TankPoints;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (_playerYou.Tanks == 0)
                        return;

                    _playerYou.Tanks--;
                    _buyPoints += Constants.TankPoints;
                }

                pcTankYou.Text = $"Panzer ({Math.Ceiling(_playerYou.Tanks).ToString("D2")})";
                buttonReady.Text = $"Fertig ({_buyPoints.ToString()})";
            }
        }

        private void PcJetYou_MouseClick(object sender, MouseEventArgs e)
        {
            if (_playerEnemy.IsReady && _playerYou.IsReady)
            {
                if (_playerEnemy.Jets <= 0)
                {
                    pcJetEnemy.Enabled = false;
                    labelJetEnemy.Enabled = false;
                }
                else
                {
                    pcJetEnemy.Enabled = true;
                    labelJetEnemy.Enabled = true;
                }

                if (_playerEnemy.Soldiers <= 0)
                {
                    pcSoldierEnemy.Enabled = false;
                    labelSoldierEnemy.Enabled = false;
                }
                else
                {
                    pcSoldierEnemy.Enabled = true;
                    labelSoldierEnemy.Enabled = true;
                }

                if (_playerEnemy.Tanks <= 0)
                {
                    pcTankEnemy.Enabled = false;
                    labelTankEnemy.Enabled = false;
                }
                else
                {
                    pcTankEnemy.Enabled = true;
                    labelTankEnemy.Enabled = true;
                }

                _atacker = WarType.Jet;
            }
            else if(_playerYou.IsReady)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (_buyPoints - Constants.JetPoints <= 0)
                        return;

                    _playerYou.Jets++;
                    _buyPoints -= Constants.JetPoints;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (_playerYou.Jets == 0)
                        return;

                    _playerYou.Jets--;
                    
                    _buyPoints += Constants.JetPoints;
                }

                pcJetYou.Text = $"Flugzeug ({Math.Ceiling(_playerYou.Jets).ToString("D2")})";
                buttonReady.Text = $"Fertig ({_buyPoints})";
            }
        }

        #endregion

        #region Hauptfunktionen

        private void Main_Load(object sender, EventArgs e)
        {
            uiTimer.Start();

            labelEnemyName.Text = _playerEnemy.Name;
            labelYourName.Text = _playerYou.Name;

            _startPower = _playerYou.StartPoints;
            _buyPoints = _playerYou.StartPoints;

            progressLifeBarYou.Maximum = _playerYou.ObjectSum;
            labelLifePointsYou.Text = _playerYou.StartPoints.ToString();
            progressLifeBarYou.Value = _playerYou.ObjectSum;

            if (_debug)
                return;

            try
            {
                
                if (_isHost)
                {
                    Thread server = new Thread(ServerThread)
                    {
                        IsBackground = true
                    };
                    server.Start();

                    Thread initThread = new Thread(InitThread)
                    {
                        IsBackground = true
                    };
                    initThread.Start();

                    listBoxLog.Items.Add("Warte auf Client...");
                }
                else
                {
                    _connectionObject = new NetworkManager(IPAddress.Parse(_ip), _port, _isHost);

                    _connectionObject.SendMessage($"/c3/{_playerYou.Name}/{_playerYou.StartPoints}");

                    for (int index = 0; index < 5; index++)
                    {
                        string data = _connectionObject.GetMessage();

                        if (data.StartsWith("/sc"))
                        {
                            string stateInfo = data.Substring(4);

                            string[] segments = stateInfo.Split('/');

                            string enemyName = segments[0];
                            int enemyPoints = int.Parse(segments[1]);

                            progressLifebarEnemy.Maximum = enemyPoints;
                            progressLifebarEnemy.Value = enemyPoints;
                            labelLifePointsEnemy.Text = enemyPoints.ToString();

                            _playerEnemy.StartPoints = enemyPoints;
                            _playerEnemy.Name = enemyName;
                            labelEnemyName.Text = enemyName;

                            listBoxLog.Items.Add("Verbindung zum Partner hergestellt.");
                            break;
                        }
                    }

                    buttonReady.Text = "Fertig (" + _buyPoints.ToString() + ")";
                    mainTimer.Start();
                    _starter.Hide();
                }
            }
            catch (System.Net.Sockets.SocketException sEx)
            {
                MessageBox.Show(sEx.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _starter.Show();

                Dispose();

                return;
            }
            catch (Exception ex)
            {
                if (_connectionObject.IsConnected)
                    _connectionObject.SendMessage("$CLOSEERROR$");

                mainTimer.Stop();

                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Fehler bei: {0}\n", ex.Source);
                builder.Append(ex.Message);

                MessageBox.Show(builder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_isHost)
                {
                    string recieveMessage = _connectionObject.GetMessage();
                    if (recieveMessage != null && recieveMessage != string.Empty)
                    {
                        if (recieveMessage.Contains("$CLOSECONNECTION$"))
                        {
                            mainTimer.Stop();

                            listBoxLog.Items.Add("Verbindung zum Partner verloren.");

                            return;
                        }
                        else if (recieveMessage.Contains("$CLOSEERROR$"))
                        {
                            mainTimer.Stop();

                            listBoxLog.Items.Add("Bei deinem Gegner ist ein Fehler aufgetreten!");
                            MessageBox.Show("Bei deinem Gegner ist ein Fehler aufgetreten!\nDaher wurde die Verbindung aufgelöst!", "Fehler beim Gegner", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                        else if (recieveMessage.Contains("$SURRENDER$"))
                        {
                            mainTimer.Stop();

                            MessageBox.Show("Dein Gegner hat aufgegeben!\nDu gast gewonnen!", "Glückwunsch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            listBoxLog.Items.Add("Dein Gegner hat aufgegeben! Du hast gewonnen!");

                            return;
                        }

                        ParseCommands(recieveMessage);
                    }

                    
                    StringBuilder builder = new StringBuilder();
                    builder.Append("/t");
                    builder.Append((int)Math.Ceiling(_playerYou.Tanks));
                    builder.Append("/j");
                    builder.Append((int)Math.Ceiling(_playerYou.Jets));
                    builder.Append("/s");
                    builder.Append((int)Math.Ceiling(_playerYou.Soldiers));
                    builder.Append("/l");
                    builder.Append((int)_playerYou.LivePoints);
                    builder.Append(_commands.ToString());

                    _commands = new StringBuilder();

                    if (_connectionObject.IsConnected)
                    {
                        _connectionObject.SendMessage(builder.ToString());
                    }
                    else
                    {
                        mainTimer.Stop();

                        MessageBox.Show("FATAL ERROR: VERBINDUNG VERLOREN", "FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }
                else
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("/t");
                    builder.Append((int)Math.Ceiling(_playerYou.Tanks));
                    builder.Append("/j");
                    builder.Append((int)Math.Ceiling(_playerYou.Jets));
                    builder.Append("/s");
                    builder.Append((int)Math.Ceiling(_playerYou.Soldiers));
                    builder.Append("/l");
                    builder.Append(((int)_playerYou.LivePoints));
                    builder.Append(_commands.ToString());

                    _commands = new StringBuilder();

                    string recieveMessage = string.Empty;

                    if (_connectionObject.IsConnected)
                    {
                        _connectionObject.SendMessage(builder.ToString());

                        recieveMessage = _connectionObject.GetMessage();
                    }
                    else
                    {
                        mainTimer.Stop();

                        MessageBox.Show("FATAL ERROR: VERBINDUNG VERLOREN", "FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                     

                    if (recieveMessage != null && recieveMessage != string.Empty)
                    {
                        if (recieveMessage.Contains("$CLOSECONNECTION$"))
                        {
                            mainTimer.Stop();

                            listBoxLog.Items.Add("Verbindung zum Partner verloren.");
                            
                            return;
                        }
                        else if (recieveMessage.Contains("$CLOSEERROR$"))
                        {
                            mainTimer.Stop();

                            listBoxLog.Items.Add("Bei deinem Gegner ist ein Fehler aufgetreten!");
                            MessageBox.Show("Bei deinem Gegner ist ein Fehler aufgetreten!\nDaher wurde die Verbindung aufgelöst!", "Fehler beim Gegner", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                        else if (recieveMessage.Contains("$SURRENDER$"))
                        {
                            mainTimer.Stop();

                            MessageBox.Show("Dein Gegner hat aufgegeben!\nDu gast gewonnen!", "Glückwunsch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            listBoxLog.Items.Add("Dein Gegner hat aufgegeben! Du hast gewonnen!");

                            return;
                        }

                        ParseCommands(recieveMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                if(_connectionObject.IsConnected)
                    _connectionObject.SendMessage("$CLOSEERROR$");

                mainTimer.Stop();

                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Fehler bei: {0}\n", ex.Source);
                builder.Append(ex.Message);

                MessageBox.Show(builder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UITimer_Tick(object sender, EventArgs e)
        {
            _playerYou.Jets = Clamp(_playerYou.Jets, float.MaxValue, 0.0f);
            _playerYou.Soldiers = Clamp(_playerYou.Soldiers, float.MaxValue, 0.0f);
            _playerYou.Tanks = Clamp(_playerYou.Tanks, float.MaxValue, 0.0f);

            _playerEnemy.Jets = Clamp(_playerEnemy.Jets, int.MaxValue, 0);
            _playerEnemy.Soldiers = Clamp(_playerEnemy.Soldiers, int.MaxValue, 0);
            _playerEnemy.Tanks = Clamp(_playerEnemy.Tanks, int.MaxValue, 0);

            if (_playerYou.IsReady && _playerEnemy.IsReady)
            {
                progressLifeBarYou.Value = (int)_playerYou.LivePoints;
                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();

                pcJetYou.Enabled = _yourTurn;
                pcSoldierYou.Enabled = _yourTurn;
                pcTankYou.Enabled = _yourTurn;

                labelJetEnemy.Text = string.Format("Flugzeug ({0:00})", _playerEnemy.Jets);
                labelSoldierEnemy.Text = string.Format("Bodeneinheit ({0:00})", _playerEnemy.Soldiers);
                labelTankEnemy.Text = string.Format("Panzer ({0:00})", _playerEnemy.Tanks);

                if (_yourTurn)
                {
                    pictureBoxTurnYou.Visible = true;
                    pictureBoxTurnEnemy.Visible = false;
                }
                else
                {
                    pictureBoxTurnYou.Visible = false;
                    pictureBoxTurnEnemy.Visible = true;
                }

                if (_playerYou.Jets <= 0.0)
                {
                    pcJetYou.Enabled = false;
                    labelJetYou.Enabled = false;
                }
                else
                {
                    pcJetYou.Enabled = true;
                    labelJetYou.Enabled = true;
                }

                if (_playerYou.Tanks <= 0.0)
                {
                    pcTankYou.Enabled = false;
                    labelTankYou.Enabled = false;
                }
                else
                {
                    pcTankYou.Enabled = true;
                    labelTankYou.Enabled = true;
                }

                if (_playerYou.Soldiers <= 0.0)
                {
                    pcSoldierYou.Enabled = false;
                    labelSoldierYou.Enabled = false;
                }
                else
                {
                    pcSoldierYou.Enabled = true;
                    labelSoldierYou.Enabled = true;
                }

                if (_playerEnemy.Jets <= 0 && _playerEnemy.Soldiers <= 0 && _playerEnemy.Tanks <= 0)
                {
                    if (_connectionObject.IsConnected)
                        _connectionObject.SendMessage("$CLOSECONNECTION$");
                    else
                    {
                        mainTimer.Stop();

                        MessageBox.Show("FATAL ERROR: VERBINDUNG VERLOREN", "FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }


                    mainTimer.Stop();

                    progressLifebarEnemy.Value = 0;

                    MessageBox.Show("Dein Gegner ist kampfunfähig!\nDu gast gewonnen!", "Glückwunsch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    listBoxLog.Items.Add("Du hast gewonnen!");

                    uiTimer.Stop();
                }

                if (_playerYou.Tanks <= 0 && _playerYou.Jets <= 0 && _playerYou.Soldiers <= 0)
                {
                    mainTimer.Stop();

                    progressLifeBarYou.Value = 0;

                    MessageBox.Show("Du bist Kampfunfähig!\nDu hast verloren!", "Schlecht", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    listBoxLog.Items.Add("Du hast verloren!");

                    uiTimer.Stop();
                }
            }

            labelJetYou.Text = string.Format("Flugzeug ({0:00})", _playerYou.Jets);
            labelTankYou.Text = string.Format("Panzer ({0:00})", _playerYou.Tanks);
            labelSoldierYou.Text = string.Format("Bodeneinheit ({0:00})", _playerYou.Soldiers);

            listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
        }

        private void ParseCommands(string cmdString)
        {
            if (cmdString.StartsWith("/chat"))
            {
                listBoxChatLog.Items.Add("Gegner:" + cmdString.Substring(6));

                return;
            }

            foreach (string cmd in cmdString.Split('/'))
            {
                if (cmd.StartsWith("t"))        //Panzeranzahl des Gegners
                {
                    _playerEnemy.Tanks = int.Parse(cmd.Substring(1));
                }
                else if (cmd.StartsWith("j"))   //Jetanzahl des Gegners
                {
                    _playerEnemy.Jets = int.Parse(cmd.Substring(1));
                }
                else if (cmd.StartsWith("s"))   //Soldatenanzahl des Gegners
                {
                    _playerEnemy.Soldiers = int.Parse(cmd.Substring(1));
                }
                else if (cmd.StartsWith("r"))   //Gegner ist bereit
                {
                    _playerEnemy.IsReady = true;

                    listBoxLog.Items.Add("Dein Gegner ist bereit.");
                }
                else if (cmd.StartsWith("l"))   //Lebenspunkte des Gegners
                {
                    int pointsEnemy = int.Parse(cmd.Substring(1));

                    progressLifebarEnemy.Value = pointsEnemy;

                    labelLifePointsEnemy.Text = pointsEnemy.ToString();

                    _playerEnemy.LivePoints = pointsEnemy;
                }
                else if (cmd.StartsWith("y"))   //Client ist am Zug
                {
                    _yourTurn = true;

                    listBoxLog.Items.Add("Du bist am Zug!");
                }
                else if (cmd.StartsWith("a"))   //Angriff
                {
                    switch (cmd.Substring(1))
                    {
                        case "11":  //Soldat vs. Soldat
                            {
                                _playerYou.Soldiers -= Constants.SoldierOnSoldier;

                                listBoxLog.Items.Add("Feindliche Bodeneinheit hat eine Bodeneinheit zerstört!");

                                _playerYou.LivePoints -= Constants.SoldierPoints;

                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();

                                break;
                            }
                        case "12":  //Soldat gegen Panzer
                            {
                                _playerYou.Tanks -= Constants.SoldierOnTank;

                                listBoxLog.Items.Add("Feindliche Bodenheit hat einen Panzer beschädigt!");

                                _playerYou.LivePoints -= Constants.TankPoints;
                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();
                                break;
                            }

                        case "13":  //Soldat gegen Flugzeug
                            {
                                _playerYou.Jets -= Constants.SoldierOnJet;

                                listBoxLog.Items.Add("Feindliche Bodeneinheit hat einen Jet beschädigt!");

                                _playerYou.LivePoints -= Constants.JetPoints;
                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();
                                break;
                            }
                        case "21":  //Panzer gegen Soldat
                            {
                                _playerYou.Soldiers -= Constants.TankOnSoldier;

                                listBoxLog.Items.Add("Feindlicher Panzer hat zwei Bodeneinheiten zerstört!");

                                _playerYou.LivePoints -= Constants.SoldierPoints;
                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();
                                break;
                            }
                        case "22":  //Panzer gegen Panzer
                            {
                                _playerYou.Tanks -= Constants.TankOnTank;
                                listBoxLog.Items.Add("Feindlicher Panzer hat einen Panzer zerstört!");

                                _playerYou.LivePoints -= Constants.TankPoints;
                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();
                                break;
                            }
                        case "23":  //Panzer gegen Flugzeug
                            {
                                listBoxLog.Items.Add("Panzer sind nicht effektiv gegen Jets.");

                                break;
                            }
                        case "23a":
                            {
                                listBoxLog.Items.Add("GLÜCKSTREFFER! Ein feindlicher Panzer hat einen Jet zerstört!");
                                _playerYou.Tanks -= Constants.TankOnJet;
                                _playerYou.LivePoints -= Constants.JetPoints;


                                break;
                            }
                        case "31":  //Flugzeug gegen Soldat
                            {
                                _playerYou.Soldiers -= Constants.JetOnSoldier;
                                listBoxLog.Items.Add("Feindlicher Jet hat drei Bodeneinheiten zerstört!");

                                _playerYou.LivePoints -= Constants.SoldierPoints;
                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();
                                break;
                            }

                        case "32":  //Flugzeug gegen Panzer
                            {
                                _playerYou.Tanks -= Constants.JetOnTank;
                                listBoxLog.Items.Add("Feindlicher Jet hat mehrere Panzer stark beschädigt!");

                                _playerYou.LivePoints -= Constants.TankPoints;
                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();
                                break;
                            }

                        case "33":  //Flugzeug gegen Flugzeug
                            {
                                _playerYou.Jets -= Constants.JetOnJet;
                                listBoxLog.Items.Add("Feindlicher Jet hat einen Jet zerstört!");

                                _playerYou.LivePoints -= Constants.JetPoints;
                                labelLifePointsYou.Text = _playerYou.LivePoints.ToString();
                                break;
                            }

                        case "99":  //Gegner hat nicht getroffen
                            {
                                listBoxLog.Items.Add("Der Angriff deines Gegeners ging daneben!");

                                break;
                            }

                        default:
                            Console.WriteLine("unexpected default case: '{0}'", cmd);
                            break;
                    }
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainTimer.Enabled)
            {
                if (MessageBox.Show("Willst du die laufende Schlacht wirklich beenden?\nDein Gegner würde sofort gewinnen!",
                    "Aufgeben", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (_connectionObject.IsConnected)
                    _connectionObject.SendMessage("$SURRENDER$");

                mainTimer.Stop();
            }

            uiTimer.Stop();

            if (_commands != null)
            {
                _commands.Clear();
                _commands = null;
            }

            if (_random != null)
            {
                _random = null;
            }

            if(_starter != null)
                _starter.Close();            
        }

        private void ButtonReady_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bist du wirklich fertig mit dem erstellen deiner Armee?\nDu kannst später keine Objekte nachkaufen!", "Fertig?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _playerYou.IsReady = true;
                _startObjectSum = (int)_playerYou.Tanks + (int)_playerYou.Soldiers + (int)_playerYou.Jets;

                if(_startObjectSum == 0)
                {
                    if (MessageBox.Show("Es scheint als hättest du kein einziges Objekt gekauft!\n" +
                                    "Bist du sicher das du das möchtest? Du hast sofort ver-\n" +
                                    "loren wenn du das tust!", "Keine Objekte", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }

                _commands.Append("/r");

                listBoxLog.Items.Add("Du bist bereit.");

                if (_yourTurn)
                {
                    listBoxLog.Items.Add("Du bist am Zug!");
                    pictureBoxTurnYou.Visible = true;
                    pictureBoxTurnEnemy.Visible = false;
                }
                else
                {
                    listBoxLog.Items.Add("Dein Gegner ist am Zug!");
                    pictureBoxTurnYou.Visible = false;
                    pictureBoxTurnEnemy.Visible = true;
                }

                buttonReady.Enabled = false;
                labelPrice1.Visible = false;
                labelPrice2.Visible = false;
                labelPrice3.Visible = false;
            }
        }

        private int Clamp(int value, int max, int min)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }

        private float Clamp(float value, float max, float min)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }

        #endregion

        #region Zusatzfunktionen

        private void MenuButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuButtonInfo_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        private void LoadImages(CustomImages customImages)
        {
            if (customImages.JetImagePath == "#std")
            {
                pcJetYou.Image = Resource.jet98;
                pcJetEnemy.Image = Resource.jet98;
            }
            else
            {
                if (File.Exists(customImages.JetImagePath))
                {
                    pcJetYou.Image = Image.FromFile(customImages.JetImagePath);
                    pcJetEnemy.Image = Image.FromFile(customImages.JetImagePath);
                }
                else
                {
                    listBoxLog.Items.Add("Textur für 'Jet' nicht gefunden! Benutze Standart");
                    pcJetYou.Image = Resource.jet98;
                    pcJetEnemy.Image = Resource.jet98;
                }
            }

            if (customImages.SoldierImagePath == "#std")
            {
                pcSoldierYou.Image = Resource.soldier98;
                pcSoldierEnemy.Image = Resource.soldier98;
            }
            else
            {
                if (File.Exists(customImages.JetImagePath))
                {
                    pcSoldierYou.Image = Image.FromFile(customImages.SoldierImagePath);
                    pcSoldierEnemy.Image = Image.FromFile(customImages.SoldierImagePath);
                }
                else
                {
                    listBoxLog.Items.Add("Textur für 'Soldat' nicht gefunden! Benutze Standart");
                    pcSoldierYou.Image = Resource.soldier98;
                    pcSoldierEnemy.Image = Resource.soldier98;
                }
            }

            if (customImages.TankImagePath == "#std")
            {
                pcTankYou.Image = Resource.tank98;
                pcTankEnemy.Image = Resource.tank98;
            }
            else
            {
                if (File.Exists(customImages.JetImagePath))
                {
                    pcTankYou.Image = Image.FromFile(customImages.TankImagePath);
                    pcTankEnemy.Image = Image.FromFile(customImages.TankImagePath);
                }
                else
                {
                    listBoxLog.Items.Add("Textur für 'Panzer' nicht gefunden! Benutze Standart");
                    pcTankYou.Image = Resource.tank98;
                    pcTankEnemy.Image = Resource.tank98;
                }
            }
        }

        #endregion

        #region Mouseevents

        private void PcSoldierEnemy_MouseDown(object sender, MouseEventArgs e)
        {
            if(pcSoldierEnemy.Enabled)
                pcSoldierEnemy.BorderStyle = BorderStyle.Fixed3D;


        }

        private void PcSoldierEnemy_MouseUp(object sender, MouseEventArgs e)
        {
            pcSoldierEnemy.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PcTankEnemy_MouseDown(object sender, MouseEventArgs e)
        {
            if (pcTankEnemy.Enabled)
                pcTankEnemy.BorderStyle = BorderStyle.Fixed3D;
        }

        private void PcTankEnemy_MouseUp(object sender, MouseEventArgs e)
        {
            pcTankEnemy.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PcJetEnemy_MouseDown(object sender, MouseEventArgs e)
        {
            if(pcJetEnemy.Enabled)
                pcJetEnemy.BorderStyle = BorderStyle.Fixed3D;
        }

        private void PcJetEnemy_MouseUp(object sender, MouseEventArgs e)
        {
            pcJetEnemy.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PcSoldierYou_MouseDown(object sender, MouseEventArgs e)
        {
            if (pcSoldierYou.Enabled)
                pcSoldierYou.BorderStyle = BorderStyle.Fixed3D;
        }

        private void PcSoldierYou_MouseUp(object sender, MouseEventArgs e)
        {
            pcSoldierYou.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PcTankYou_MouseDown(object sender, MouseEventArgs e)
        {
            if (pcTankYou.Enabled)
                pcTankYou.BorderStyle = BorderStyle.Fixed3D;
        }

        private void PcTankYou_MouseUp(object sender, MouseEventArgs e)
        {
            pcTankYou.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PcJetYou_MouseDown(object sender, MouseEventArgs e)
        {
            if (pcJetYou.Enabled)
                pcJetYou.BorderStyle = BorderStyle.Fixed3D;
        }

        private void PcJetYou_MouseUp(object sender, MouseEventArgs e)
        {
            pcJetYou.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region Netzwerk

        private void ServerThread()
        {
            _serverEstablished = false;
            _connectionObject = new NetworkManager(IPAddress.Any, _port, true);
            _serverEstablished = true;
        }

        private void InitThread()
        {
            while (!_serverEstablished) ;

            for (int index = 0; index < 5; ++index)
            {
                string data = _connectionObject.GetMessage();

                /*
                 * /cc initalisierung
                 *     /cc/<name>/<points>
                 */

                if (data.StartsWith("/c3"))
                {
                    string stateInfo = data.Substring(4);
                    string enemyName = stateInfo.Split('/')[0];
                    int enemyPoints = int.Parse(stateInfo.Split('/')[1]);

                    Invoke(new Action(() => progressLifebarEnemy.Maximum = enemyPoints));
                    Invoke(new Action(() => progressLifebarEnemy.Value = enemyPoints));
                    Invoke(new Action(() => labelLifePointsEnemy.Text = enemyPoints.ToString()));

                    _playerEnemy.StartPoints = enemyPoints;
                    _playerEnemy.Name = enemyName;

                    Invoke(new Action(() => listBoxLog.Items.Add("Verbindung zum Partner hergestellt.")));
                    Invoke(new Action(() => labelEnemyName.Text = enemyName));

                    _connectionObject.SendMessage($"/sc/{_playerYou.Name}/{_playerYou.LivePoints}");
                    break;
                }
                else if (data.StartsWith("/cc"))
                {
                    Invoke(new Action(() => listBoxLog.Items.Add("Die Version deines Partners ist veraltet!")));
                    Invoke(new Action(() => listBoxLog.Items.Add("Bitte auf Version 3 upgraden!")));
                    _connectionObject.CloseConnection();
                    return;
                }
            }

            Invoke(new Action(() => buttonReady.Text = "Fertig (" + _buyPoints.ToString() + ")"));
            Invoke(new Action(() => mainTimer.Start()));
            Invoke(new Action(() => _starter.Hide()));
        }

        #endregion

        #region Chat

        private void MenuButtonChat_Click(object sender, EventArgs e)
        {
            _chatVisible = !_chatVisible;

            Width = _chatVisible ? WidthWithChat : WidthNoChat;
        }

        private void ButtonChatSend_Click(object sender, EventArgs e)
        {
            if (textBoxChatMessage.TextLength <= 0)
                return;

            _connectionObject.SendMessage($"/chat{textBoxChatMessage.Text}");
            listBoxChatLog.Items.Add("Du: " + textBoxChatMessage.Text);

            textBoxChatMessage.Clear();
        }

        private void TextBoxChatMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ButtonChatSend_Click(sender, null);
        }

        #endregion
    }
}