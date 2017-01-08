using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using Newtonsoft.Json.Linq;

namespace k8asd {
    public partial class ClientView : UserControl {
        private InfoModel infoModel;
        private CooldownModel cooldownModel;
        private McuModel mcuModel;
        private List<IPacketReader> packetReaders;

        public int num;
        public int updateflag = 0;

        public JToken loadtoken;

        public TimeSpan sys;

        private WayPoint HDVS = new WayPoint();
        private WayPoint.Player camppl;

        private LoginHelper loginHelper;
        private PacketHandler packetHandler;

        private KryptonButton[,] btnCampMap;
        private KryptonPage[] pagChat = new KryptonPage[7];
        private RichTextBoxEx[] txtChatBox = new RichTextBoxEx[7];

        private Point campxy;
        private R47107.Block campbl;
        private R12200 r12200;
        private R12400 r12400;
        private R13100 r13100;
        private R14101 r14101;
        private R14103 r14103;
        private R33100 r33100;
        private R33201 r33201;
        private R34100 r34100;
        private R39100 r39100;
        private R39301 r39301;
        private R45200 r45200;
        private R45201 r45201;
        private R45300 r45300;
        private R47008 r47008;
        private R47107 r47107;

        private bool armyok, plusok, armyok2, weaveok;
        private bool weaveautoupdate, weavecreate;
        private bool armynext;
        private bool campend, campmap;

        private int curpower;
        private int makecd, forcefreecd, refreshcd;
        private int campcd, campactcd, camprecd;
        private int traincycle, armycycle;
        private int lastbagindex;
        private int lastupgindex;

        private int[] traincd = new int[8];
        private int[] chatcd = new int[4];
        private int[] listarmy;
        private int[] bindcd = new int[60];

        private string tokencdusable, techcdusable, imposecdusable, guidecdusable, upgradeusable;
        private string campid;
        private string isimposelimit;
        private string magic, foodprice;

        private int mcu;
        private int maxMcu;
        private int mcuCooldown;

        private Configuration config;

        public Configuration Configuration {
            get {
                return config;
            }
            set {
                config = value;
            }
        }

        private string[] listpower = new string[25];

        public ClientView() {
            InitializeComponent();

            infoModel = new InfoModel();
            cooldownModel = new CooldownModel();
            mcuModel = new McuModel();

            packetReaders = new List<IPacketReader>();
            packetReaders.Add(infoModel);
            packetReaders.Add(cooldownModel);
            packetReaders.Add(mcuModel);

            infoView.SetModel(infoModel);
            cooldownView.SetModel(cooldownModel);
            mcuView.SetModel(mcuModel);

            this.Size = new Size(236, 145);

            /*
            for (int i = 0; i < 6; i++)
                cbbChat.Items.Add(V.listchat[i]);
            cbbChat.SelectedIndex = 3;

            for (int i = 0; i < 7; i++) {
                pagChat[i] = new KryptonPage();
                txtChatBox[i] = new RichTextBoxEx();
                txtChatBox[i].Dock = DockStyle.Fill;
                txtChatBox[i].BackColor = Color.Black;
                txtChatBox[i].ForeColor = V.listcolorchat[i];
                txtChatBox[i].Font = new Font("Sogue", 9.25f);
                txtChatBox[i].ReadOnly = true;
                txtChatBox[i].ScrollBars = RichTextBoxScrollBars.ForcedVertical;
                pagChat[i].Controls.Add(txtChatBox[i]);
                pagChat[i].Text = V.listchat[i];
                navChat.Pages.Add(pagChat[i]);
            }
            navChat.SelectedIndex = 6;

            cbbArmyMode.Items.AddRange(V.listarmymode);
            cbbArmyMode.SelectedIndex = 0;

            cbbWeaveMode.Items.AddRange(V.listweavemode);
            cbbWeaveMode.SelectedIndex = 0;

            int asz = 18;
            int sz = 30;
            int dist = 1;
            btnCampMap = new KryptonButton[asz, asz];
            for (int i = 0; i < asz; i++)
                for (int j = 0; j < asz; j++) {
                    btnCampMap[i, j] = new KryptonButton();
                    btnCampMap[i, j].Size = new Size(sz, sz);
                    btnCampMap[i, j].Location = new Point(dist + i * (sz + dist), dist + j * (sz + dist));
                    btnCampMap[i, j].Tag = i.ToString() + "." + j.ToString();
                    btnCampMap[i, j].Click += btnCampMap_Click;
                    pnlCampMap.Controls.Add(btnCampMap[i, j]);
                }
            cbbCamp.Items.AddRange(V.listcamp);
            cbbCamp.SelectedIndex = 0;

            WayPoint.Player player = new WayPoint.Player(new Point(0, 1));

            player.Add(new Point(0, 0), new Point(3, 6));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(0, 8));
            player.Add(new Point(0, 7), new Point(2, 14));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(0, 17));
            player.Add(new Point(0, 15), new Point(7, 17));
            player.Add(new Point(3, 12), new Point(7, 14));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(7, 0));
            player.Add(new Point(4, 0), new Point(7, 5));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(7, 5));
            player.Add(new Point(5, 6), new Point(7, 17));
            HDVS.listplayer.Add(player);

            cbbUpg1.SelectedIndexChanged -= cbbUpg2_SelectedIndexChanged;
            cbbUpg1.Items.AddRange(V.listequiptype);
            cbbUpg1.SelectedIndex = 0;
            cbbUpg1.SelectedIndexChanged += cbbUpg2_SelectedIndexChanged;
            */
        }

        private void ClientView_Load(object sender, EventArgs e) {
            //
        }

        private void LogText(string s) {
            //  txtLogs.AppendText("\n" + F.GetTime(sys) + " " + s);
        }

        private void SendMsg(string cmd, params string[] para) {
            bool succeeded = false;
            try {
                succeeded = packetHandler.SendCommand(cmd, para);
            } catch {

            }

            if (!succeeded) {
                LogText("[Kết nối] Mất kết nối đến máy chủ");
                tmrCd.Stop();
                tmrData.Stop();
                tmrReq.Stop();
            }
        }

        public void LogIn() {
            LogIn(Configuration.ServerId, Configuration.Username, Configuration.Password);
        }

        private void LogIn(int serverId, string username, string password) {
            loginHelper = new LoginHelper(username, password);

            // LogText("Bắt đầu đăng nhập tài khoản...");
            var loginAccountStatus = loginHelper.LoginAccount();
            switch (loginAccountStatus) {
            case LoginStatus.NoConnection:
                // LogText("Không có kết nối mạng.");
                return;
            case LoginStatus.WrongUsernameOrPassword:
                // LogText("Sai tên người dùng hoặc mật khẩu.");
                return;
            case LoginStatus.UnknownError:
                // LogText("Có lỗi xảy ra.");
                return;
            }
            // LogText("Đăng nhập tài khoản thành công.");

            // LogText("Bắt đầu lấy thông tin để kết nối với máy chủ...");
            var loginServerStatus = loginHelper.LoginServer(serverId);
            switch (loginServerStatus) {
            case LoginStatus.NoConnection:
                // LogText("Không có kết nối mạng.");
                return;
            case LoginStatus.UnknownError:
                // LogText("Có lỗi xảy ra.");
                return;
            }
            // LogText("Lấy thông tin thành công.");

            // LogText("Bắt đầu kết nối với máy chủ...");
            packetHandler = new PacketHandler(loginHelper.Session);
            if (!packetHandler.Connect()) {
                // LogText("Kết nối với máy chủ thất bại.");
            }

            tmrData.Start(); ;
            packetHandler.SendCommand("10100");
        }

        private void tmrData_Tick(object sender, EventArgs e) {
            var packet = packetHandler.ReadPacket();
            if (packet == null) {
                return;
            }

            foreach (var reader in packetReaders) {
                reader.OnPacketReceived(packet);
            }

            if (packet.Message.Length == 0) {
                return;
            }



            var cmd = packet.CommandId;
            var cdata = packet.Raw;

            switch (cmd) {
            #region 10100
            case "10100":
                tmrCd.Start();
                LogText("[Kết nối] Kết nối với server thành công");
                LogText("[Cập nhật] Thông tin nhân vật...");
                SendMsg("11102");
                break;
            #endregion

            #region 10103
            case "10103": {
                    /*
                    if (packet.Message.Length > 0) {
                        R10103 r10103 = new R10103(cdata);
                        int cat = Convert.ToInt32(r10103.category);
                        string msg = r10103.text;
                        int start = txtChatBox[6].TextLength;

                        txtChatBox[6].AppendText("\n" + msg);
                        if (cat != 8)
                            txtChatBox[cat - 1].AppendText("\n" + msg);

                        if (r10103.href != "") {
                            txtChatBox[6].InsertLink(r10103.disp, r10103.href);
                            if (cat != 8)
                                txtChatBox[cat - 1].InsertLink(r10103.disp, r10103.href);
                        }

                        txtChatBox[6].ScrollToCaret();
                        if (cat != 8)
                            txtChatBox[cat - 1].ScrollToCaret();

                        txtChatBox[6].Select(start, txtChatBox[6].TextLength - start);
                        txtChatBox[6].SelectionColor = r10103.color;
                        txtChatBox[6].SelectionLength = 0;
                    }*/
                }
                break;
            #endregion

            #region 11102
            case "11102": {
                    var token = JToken.Parse(cdata);

                    /*
                    systime = (string) player["systime"];
                    avoidWarStatus = (string) token["avoidWarStatus"];
                    protectcd = (string) player["protectcd"];
                    legionkey = (string) player["legionkey"];
                    guidestep = (string) player["guidestep"];
                    techcdusable = (string) player["techcdusable"];
                    vip = (string) player["vip"];
                    tokencdusable = (string) player["tokencdusable"];
                    trainnum = (string) player["trainnum"];
                    legionname = (string) player["legionname"];
                    year = (string) player["year"];
                    imposecdusable = (string) player["imposecdusable"];
                    guidecdusable = (string) player["guidecdusable"];
                    isimposelimit = (string) player["isimposelimit"];
                    arealevel = (string) player["arealevel"];
                    nation = (string) player["nation"];
                    newmail = (string) player["newmail"];
                    season = (string) player["season"];
                    id = (string) player["id"];
                    techcd = (string) player["techcd"];
                    guidecd = (string) player["guidecd"];
                    generalname = (string) player["generalname"];
                    map = (string) player["map"];            
                    imposecd = (string) player["imposecd"];                    
                    legionid = (string) player["legionid"];
                    */

                    // FIXME: handle case character not yet created.


                    /*
                        // FIXME.
                        // characterBox.Text = r11102.playername + " Lv." + r11102.playerlevel + " [" + V.listnation[Convert.ToInt32(r11102.nation)] + "]";
                        grpCd.Text = r11102.year + V.listseason[Convert.ToInt32(r11102.season) - 1];

                        numForces.Maximum = Convert.ToInt32(maxforces);

                        lblToken.Text = "Lượt: " + r11102.token + "/" + r11102.maxtoken;

                        isimposelimit = r11102.isimposelimit;
                        imposecd = Convert.ToInt32(r11102.imposecd);
                        tokencd = Convert.ToInt32(r11102.tokencd);
                        guidecd = Convert.ToInt32(r11102.guidecd);
                        techcd = Convert.ToInt32(r11102.techcd);

                        tokencdusable = r11102.tokencdusable;
                        techcdusable = r11102.techcdusable;

                        if (updateflag == 0) {
                            LogText("[Cập nhật] Thông tin bang hội...");
                            SendMsg("32121");
                        }
                    } else
                        LogText("[Kết nối] Nhân vật không tồn tại");
                        */
                    break;
                }
            #endregion

            #region 11104
            case "11104":
                R11104 r11104 = new R11104(cdata);

                refreshcd = 50000;
                // if (r11104.message == null)
                //  goto case "11103";

                break;
            #endregion

            #region 12200
            case "12200":
                r12200 = new R12200(cdata);
                //lstBuild.Items.Clear();

                forcefreecd = Convert.ToInt32(r12200.rightcd);

                //foreach (R12200.Main dt in dt_12200.listmain)
                //    if (dt != null)
                //        lstBuild.Items.Add(dt.buildname + " (" + dt.buildlevel + ")");
                //lstBuild.SelectedIndex = 0;
                //for (int i = 0; i < dt_12200.listconstruct.Count; i++)
                //    buildcd[i] = Convert.ToInt32(dt_12200.listconstruct[i].ctime);

                // btnWorkshop.Enabled = r12200.listmain[24] != null;

                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin thu thuế...");
                    SendMsg("12400");
                }
                // goto case "11103";
                break;
            #endregion

            /*
        #region 13100
        case "13100":
            r13100 = new R13100(cdata);
            foodprice = r13100.price + V.arrow[Convert.ToInt32(Convert.ToBoolean(r13100.isup))];
            txtFoodPrice.Text = foodprice;
            txtFoodTrade.Text = r13100.crutrade + "/" + r13100.maxtrade;
            barFoodBuy.Value = barFoodSell.Value = 1;
            CheckFoodTrade(r13100.crutrade);
            if (updateflag == 0) {
                LogText("[Cập nhật] Thông tin thành trì...");
                SendMsg("12200", "1");
            }
            grpCd.Values.Description = "Lúa: " + foodprice + " - " + magic;
            break;
        #endregion
            */

            /*
            #region 13101
            case "13101":
                R13101 r13101 = new R13101(cdata);
                if (r13101.m == null) {
                    txtFoodTrade.Text = r13101.cde + "/" + r13100.maxtrade;
                    CheckFoodTrade(r13101.cde);
                    goto case "11103";
                } else
                    LogText("[Giao dịch lúa] " + r13101.m);
                break;
            #endregion
                */

            #region 14100
            case "14100": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["cde"] != null) {
                        forcefreecd = Convert.ToInt32(token["cde"].ToString());
                        // goto case "11103";
                    } else {
                        LogText("[Lính] " + token["message"].ToString().Replace("\"", ""));
                        if (forcefreecd == 0)
                            forcefreecd += 600000;
                    }
                }
                break;
            #endregion

            #region 14101
            case "14101":
                r14101 = new R14101(cdata);
                // numForcesRecruit.Maximum = Convert.ToInt32(r14101.forcemax);
                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin cửa tiệm...");
                    SendMsg("39301", "0", "0", "0");
                }
                break;
            #endregion

            #region 14102
            case "14102": {
                    JToken token = JObject.Parse(cdata)["m"];
                    //if (token["playerupdateinfo"] != null)
                    //  goto case "11103";
                }
                break;
            #endregion

            #region 32101
            case "32101":
                // R32101 r32101 = new R32101(cdata);
                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin binh doanh...");
                    SendMsg("14101");
                }
                break;
            #endregion

            #region 32121
            case "32121":
                R32121 r32121 = new R32121(cdata);
                //txtLegionName.Text = dt_32121.legionname;
                //txtLegionDate.Text = dt_32121.createdate;
                //txtLegionLv.Text = dt_32121.legionlv;
                //txtLegionMemnum.Text = dt_32121.memnum + "/" + dt_32121.maxnum;
                //txtLegionNation.Text = sNation[Convert.ToInt32(dt_32121.nation)];
                //txtLegionCreater.Text = dt_32121.creater;
                //lblLegion.Text = "<b>Bang chủ: </b>" + dt_32121.jtz
                //    + "<br/><b>Đốc quân: </b>" + dt_32121.dj
                //    + "<br/><b>Doanh trưởng: </b>" + dt_32121.yz
                //    + "<br/><b>Thiên phu trưởng: </b>" + dt_32121.qfz
                //    + "<br/><b>Bách phu trưởng: </b>" + dt_32121.bfz
                //    + "<br/><br/><b>" + dt_32121.message + "</b>";
                if (updateflag == 0)
                    SendMsg("32101", "0", "1", "\x20");
                break;
            #endregion

            #region 33100
            case "33100":
                r33100 = new R33100(cdata);
                if (updateflag == 0) {
                    listpower[Convert.ToInt32(r33100.powerid) - 1] = r33100.powername;
                    // nextpower = false;

                    int id = Convert.ToInt32(r33100.nextpowerid);
                    if (r33100.nextattackble == "1" && listpower[id - 1] == null) {
                        SendMsg("33100", r33100.nextpowerid);
                        // nextpower = true;
                    } else
                        for (; curpower <= 17; curpower++)
                            if (r33201.listpower[curpower].powerState == "1") {
                                SendMsg("33100", (4 + curpower++).ToString());
                                // nextpower = true;
                                break;
                            }

                    // if (!nextpower)
                    //     UpdateComplete();
                }

                /*
                cbbArmy2.Items.Clear();
                if (r33100.listarmy != null) {
                    foreach (R33100.Army dt in r33100.listarmy)
                        cbbArmy2.Items.Add(dt.armyname + " (" + dt.armylevel + ")");
                    cbbArmy2.SelectedIndex = 0;
                }
                */
                break;
            #endregion

            #region 33101
            case "33101":
                /// FIXME.
                /*
                R33101 r33101 = new R33101(cdata);
                if (r33101.m == null) {
                    lblExtraYinkuang.Visible = r33101.extrayinkuang.Equals("1");
                    lblExtraNongtian.Visible = r33101.extranongtian.Equals("1");
                    lblExtraZhengzhan.Visible = r33101.extrazhengzhan.Equals("1");
                    lblExtraZhengfu.Visible = r33101.extrazhengfu.Equals("1");
                    lblExtraGongji.Visible = r33101.extragongji.Equals("1");
                    sysgold = r33101.sys_gold;
                    usergold = r33101.user_gold;
                    txtGold.Text = (Convert.ToInt32(sysgold) + Convert.ToInt32(usergold)).ToString();
                    tokencd = Convert.ToInt32(r33101.tokencd);
                    tokencdusable = r33101.tokencdusable;
                    forces = r33101.forces;
                    txtForces.Text = forces + "/" + maxforces;
                    lblToken.Text = "Lượt: " + r33101.token + "/" + r11102.maxtoken;
                    txtJyungong.Text = r33101.jyungong;
                    LogText("[Chiến] Tỉ lệ: " + r33101.winp + ": " + r33101.message);
                    if (r33101.items != "")
                        txtLogs.AppendText(". Nhận được:" + r33101.items);
                    txtLogs.AppendText(" ");
                    //txtLogs.InsertLink("[Chiến báo]", r33101.id);
                } else
                    LogText("[Chiến] " + r33101.m);
                armynext = true;
                armyok = true;
                */
                break;
            #endregion


            #region 41100
            case "41100":
            /// FIXME
            /// Parse guide cd + guidecdusable.
            #endregion

            #region 41301
            case "41301": {
                    break;
                }

            /*
            R41301 r41301 = new R41301(cdata);
            if (r41301.m == null) {
                lblPlusNew.Text = "D: " + r41302.baseleader + " + " + r41301.plusleader
                        + "\nK: " + r41302.baseforces + " + " + r41301.plusforces
                        + "\nT: " + r41302.baseintelligence + " + " + r41301.plusintelligence;
                pnlPlusNew.Visible = true;
                btnPlusKeep.Enabled = true;
                btnPlusPlus.Enabled = false;
                if (chkPlus.Checked) {
                    LogText("[Cải tiến] " + r41300.listgeneral[lstPlus.SelectedIndex].generalname
                        + ": D" + r41301.plusleader
                        + " K" + r41301.plusforces
                        + " T" + r41301.plusintelligence);
                    int att1 = cbbPlusAtt1.SelectedIndex;
                    int att2 = cbbPlusAtt2.SelectedIndex;
                    int[] org =
                    {
                                Convert.ToInt32(r41302.originalattr.plusleader),
                                Convert.ToInt32(r41302.originalattr.plusforces),
                                Convert.ToInt32(r41302.originalattr.plusintelligence)
                            };
                    int[] bs =
                    {
                                Convert.ToInt32(r41301.plusleader),
                                Convert.ToInt32(r41301.plusforces),
                                Convert.ToInt32(r41301.plusintelligence)
                            };
                    if ((!chkPlusAtt2.Checked && org[att1] < bs[att1])
                        || (chkPlusAtt2.Checked
                        && bs[att1] + 5 >= bs[F.AttPlus(att1, att2)]
                        && (org[att1] + org[F.AttPlus(att1, att2)]
                        < bs[att1] + bs[F.AttPlus(att1, att2)]
                        || (org[att1] + org[F.AttPlus(att1, att2)]
                        == bs[att1] + bs[F.AttPlus(att1, att2)]
                        && Math.Abs(org[att1] - org[F.AttPlus(att1, att2)])
                        > Math.Abs(bs[att1] - bs[F.AttPlus(att1, att2)]))))) {
                        txtLogs.AppendText(" -> Thay");
                        btnPlusChange_Click(null, null);
                    } else {
                        txtLogs.AppendText(" -> Giữ");
                        btnPlusKeep_Click(null, null);
                    }
                }
                goto case "11103";
            } else {
                LogText("[Cải tiến] " + r41301.m);
                chkPlus.Checked = false;
            }
            break;
            */
            #endregion

            #region 41302
            case "41302":
                // FIXME 

                /*
                r41302 = new R41302(cdata);
                grpPlusInfo.Text = r41302.generalname + " Lv." + r41302.generallevel;
                lstPlus.SelectedIndexChanged -= lstPlus_SelectedIndexChanged;
                lstPlus.Items[lstPlus.SelectedIndex] = r41302.generalname + " (" + r41302.generallevel + ")";
                lstPlus.SelectedIndexChanged += lstPlus_SelectedIndexChanged;
                txtPlusInfo1.Text = r41302.solidernum + "/" + r41302.maxsolidernum;
                txtPlusInfo2.Text = "D" + r41302.leader + " K" + r41302.forces + " T" + r41302.intelligence;
                txtPlusInfo3.Text = r41302.troopname;
                txtPlusInfo4.Text = r41302.troopstagename + " - " + r41302.trooplevel;
                txtPlusInfo5.Text = r41302.skillname;
                txtPlusInfo6.Text = "Tướng Lv. " + r41302.shiftlv + " trở lên";
                btnShift.Enabled = Convert.ToInt32(r41302.shiftlv) <= Convert.ToInt32(r41302.generallevel);
                lblPlusOrigin.Text = "D: " + r41302.baseleader + " + " + r41302.originalattr.plusleader
                    + "\nK: " + r41302.baseforces + " + " + r41302.originalattr.plusforces
                    + "\nT: " + r41302.baseintelligence + " + " + r41302.originalattr.plusintelligence;
                if (r41302.refreshable == "0") {
                    lblPlusNew.Text = "D: " + r41302.baseleader + " + " + r41302.newattr.plusleader
                        + "\nK: " + r41302.baseforces + " + " + r41302.newattr.plusforces
                        + "\nT: " + r41302.baseintelligence + " + " + r41302.newattr.plusintelligence;
                    pnlPlusNew.Visible = true;
                    btnPlusKeep.Enabled = true;
                    btnPlusPlus.Enabled = false;
                } else {
                    pnlPlusNew.Visible = false;
                    btnPlusKeep.Enabled = false;
                    btnPlusPlus.Enabled = true;
                }
                plusok = true;
                */
                break;
            #endregion

            #region 41304
            case "41304":
                // c41304 = true;
                // goto case "11103";
                break;
            #endregion



            #region 47001
            case "47001":
                break;
            #endregion

            #region 47007
            case "47007": {
                    JToken token = JObject.Parse(cdata)["m"];
                    var campaignId = (string) token["campaignId"];
                    var id = (string) token["id"];
                    SendMsg("47101", "1", id);
                }
                break;
                #endregion

            /*
        #region 47008
        case "47008":
            r47008 = new R47008(cdata);

            if (r47008.m == null) {
                btnCampTeam.Text = r47008.listteam.Count.ToString() + " tổ đội";

                KryptonContextMenu context = new KryptonContextMenu();
                KryptonContextMenuItems items = new KryptonContextMenuItems();

                foreach (RTeam.Team tm in r47008.listteam) {
                    KryptonContextMenuItem item = new KryptonContextMenuItem();
                    item.Text = tm.teamname + " ["
                        + tm.condition + "] ("
                        + tm.currentnum + "/"
                        + tm.maxnum + ")";
                    item.Tag = tm.teamid;
                    item.Click += btnCampTeam_Click;

                    item.Enabled = r47008.listmember.Count == 0;
                    items.Items.Add(item);
                }

                if (items.Items.Count > 0) {
                    context.Items.Add(items);
                    btnCampTeam.KryptonContextMenu = context;
                } else
                    btnCampTeam.KryptonContextMenu = null;

                lstCampMember.Items.Clear();
                foreach (RTeam.Member mem in r47008.listmember)
                    lstCampMember.Items.Add(mem.playername + " (" + mem.playerlevel + ")");

                if (r47008.listmember.Count == 0) {
                    btnCampInfo.Enabled = true && campid == null;
                    btnCampCreate.Enabled = true;
                    btnCampAttack.Enabled = false;
                    btnCampDisband.Enabled = false;
                    btnCampQuit.Enabled = false;
                    btnCampInvite.Enabled = false;
                } else {
                    btnCampInfo.Enabled = false;
                    btnCampCreate.Enabled = false;

                    /*
                    if (r47008.listmember[0].playername == r11102.playername) {
                        btnCampAttack.Enabled = true;
                        btnCampDisband.Enabled = true;
                        btnCampQuit.Enabled = false;
                    } else {
                        btnCampAttack.Enabled = false;
                        btnCampDisband.Enabled = false;
                        btnCampQuit.Enabled = true;
                    }

                    btnCampInvite.Enabled = r47008.listmember.Count < Convert.ToInt32(r47008.maxplayer);
                    if (r47008.listmember.Count < Convert.ToInt32(r47008.minplayer))
                        btnCampAttack.Enabled = false;
                }
            } else
                LogText("[Chiến dịch] " + r47008.m);
            break;
        #endregion

        #region 47100
        case "47100":
            R47100 r47100 = new R47100(cdata);
            foreach (R47100.Reward rw in r47100.listreward)
                LogText("[Chiến dịch] Nhận được " + rw.award + " " + rw.name);
            break;
        #endregion

        #region 47101
        case "47101": {
                JToken token = JObject.Parse(cdata)["m"];
                campcd = Convert.ToInt32(token["cd"].ToString());
                campid = (string) token["id"];
                SendMsg("47107", campid, "1");
            }
            break;
        #endregion

        #region 47102
        case "47102": {
                JToken token = JObject.Parse(cdata)["m"];
                if (token["message"] != null)
                    LogText("[Chiến dịch] " + token["message"].ToString().Replace("\"", ""));
            }
            break;
        #endregion

        #region 47103
        case "47103": {
                JToken token = JObject.Parse(cdata)["m"];
                if (token["message"] != null)
                    LogText("[Chiến dịch] " + token["message"].ToString().Replace("\"", ""));
            }
            break;
        #endregion

        #region 47106
        case "47106":
            lblCampCd.Text = "";
            pnlCampMap.SendToBack();
            btnCampQuitIn.Visible = false;
            grpCampInfo.Visible = false;
            btnCampInfo.Enabled = true;
            campend = true;
            break;
        #endregion

        #region 47107
        case "47107":
            r47107 = new R47107(cdata);
            if (btnCampInfo.Text == "Thoát")
                btnCampInfo_Click(null, null);
            btnCampInfo.Enabled = false;
            for (int i = 0; i < 18; i++)
                for (int j = 0; j < 18; j++) {
                    btnCampMap[i, j].Visible = false;
                    btnCampMap[i, j].Text = "";
                }
            campmap = false;
            campend = false;
            goto case "47107s";
        #endregion

        #region 47107s
        case "47107s": {
                int w = Convert.ToInt32(r47107.width);
                int h = Convert.ToInt32(r47107.height);

                for (int i = 0; i < r47107.listblock.Count; i++) {
                    R47107.Block bl = r47107.listblock[i];

                    Point p = new Point(Convert.ToInt32(bl.x), Convert.ToInt32(bl.y));

                    KryptonButton bt = btnCampMap[p.Y, p.X];

                    Color color = Color.AliceBlue;

                    bt.Text = "";
                    //bt.Tooltip = "";
                    if (bl.solider != null) {
                        //bt.Tooltip = bl.solider.name + " (" + bl.solider.level + ")"
                        //+ "\r\nBinh lực: " + bl.solider.currforcesnum + "/" + bl.solider.maxforcesnum;
                        /*bt.Tooltip +=
                               + "\r\neffects: " + bl.solider.effects
                               + "\r\nfiretime: " + bl.solider.firetime
                               + "\r\nfx: " + bl.solider.fx
                               + "\r\nhit: " + bl.solider.hit
                               + "\r\nskill: " + bl.solider.skill;

        }

        if (bl.dx != "0") {
            if (bl.dx == "2")
                if (bl.solider.id == loginHelper.Session.UserId) {
                    color = Color.Yellow;
                    campxy = p;
                    campbl = bl;
                    if (!campmap)
                        foreach (WayPoint.Player player in HDVS.listplayer)
                            if (player.player.Equals(campxy))
                                camppl = player;
                    //bt.Tooltip += "\r\nTấn công: " + bl.solider.konum;
                } else
                    color = Color.Blue;
            else if (bl.dx == "1")
                color = Color.DarkRed;
        } else
            color = Color.FromArgb(150, 150, 150);

        F.CampBt(ref bt, color);

        //bt.Tooltip += "\r\nflag: " + bl.flag
        //    + "\r\nmap: " + bl.map
        //    + "\r\ntoken: " + bl.token;
    }

                if (!campmap) {
                    btnCampMap[campxy.Y, campxy.X].Visible = true;
                    F.CampMap(campbl.moveInfo, campxy, ref btnCampMap, r47107);
                    campmap = true;
                }

                for (int k = 0; k< 4; k++)
                    if (campbl.moveInfo[k] == '1') {
                        int m = campxy.Y + (k - 1) % 2;
    int n = campxy.X + (k - 2) % 2;

                        if (0 <= n && n<w
                            && 0 <= m && m<h) {
                            btnCampMap[m, n].Text = "▲";
                            int[] orient = { 2, 0, 3, 1 };

    btnCampMap[m, n].Orientation = (VisualOrientation) orient[k];
                            if (r47107.listblock[m * w + n].solider != null)
                                btnCampMap[m, n].Text = "■";
                        }
                    }

                txtCampInfo1.Text = r47107.info.armynum + "/" + r47107.maxarmynum;
                campactcd = Convert.ToInt32(r47107.info.nextactiontime);
                camprecd = Convert.ToInt32(r47107.info.remaintime);

                /*btnCampaign.Tooltip =
                    "interval: " + dt_47107.info.interval
                    + "\r\nmapCount: " + dt_47107.info.mapCount
                    + "\r\nreducetime: " + dt_47107.info.reducetime
                    + "r\nreduceusetime: " + dt_47107.info.reduceusetime;
        }
        break;
        #endregion

        #region 47108
        case "47108":
            R47107 r47108 = new R47107(cdata);
        {
            int w = Convert.ToInt32(r47108.width);
            int h = Convert.ToInt32(r47108.height);

            foreach (R47107.Block bl in r47108.listblock) {
                if (bl.dx == "2" && bl.solider == null)
                    bl.dx = "0";
                r47107.listblock[Convert.ToInt32(bl.y) * w + Convert.ToInt32(bl.x)] = bl;
            }

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++) {
                    R47107.Block bl2 = r47107.listblock[i * w + j];
                    if (bl2.dx == "1")
                        bl2 = new R47107.Block("0", "0", "0", null, bl2.moveInfo, "0", bl2.x, bl2.y);
                }

            r47107.info = r47108.info;
        }
        goto case "47107s";
        #endregion

        #region 47109
        case "47109":
            R47109 r47109 = new R47109(cdata);
        LogText("[Chiến dịch] " + r47109.result);

        TimeSpan span = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(r47109.time));
        txtLogs.AppendText(". Thời gian: " + F.GetTimewH(span));

        if (r47109.rank != "-1") {
            txtLogs.AppendText(" [" + V.listcamprank[Convert.ToInt32(r47109.rank) - 1] + "]");
            LogText("[Chiến dịch] Mở tàng bảo đồ...");

            SendMsg("47100", "1");
        }
        goto case "47106";
        #endregion

        case "64005": {
            break;
        }

        case "64007": {
            break;
        }

        default:
            break;
    }
    }

    public event EventHandler AccInfoChanged;

    #region Timer

    private void tmrCd_Tick(object sender, EventArgs e) {
    if (sys.Seconds == 1 && (sys.Minutes == 0 || sys.Minutes == 30)) {
        SendMsg("39301", "0", "0", "0");
        SendMsg("13100");
    }

    if (btnAuto.Text == "Dừng") {
        if (chkArmy.Checked)
            armyok = true;
        if (chkWeave.Checked)
            weaveok = true;
    }

    for (int i = 0; i < 60; i++) {
        F.DecTime(ref bindcd[i]);
        if (i == cbbBag.SelectedIndex)
            F.ShowTimemH(txtBagBindCd, bindcd[i]);
    }

    for (int i = 0; i < 4; i++)
        F.DecTime(ref chatcd[i]);

    F.DecTime(ref forcefreecd);

    F.DecTime(ref refreshcd);

    /*
    #region TrainCd

    {
        for (int i = 0; i < 8; i++)
            F.DecTime(ref traincd[i]);

        int index = lstTrain.SelectedIndex;
        if (index >= 0)
            F.ShowTime(txtTrainTime, traincd[index]);
    }

    #endregion
    */


                #region CampaignOpenCd

            /*

            if (campcd == 0) {
                lblCampCd.Text = "";

                if (campid != null) {
                    lblCampCd.SendToBack();
                    grpCampInfo.Visible = true;
                    btnCampQuitIn.Visible = true;
                    campid = null;
                }
            } else {
                TimeSpan span = new TimeSpan(0, 0, 0, 0, campcd);
                lblCampCd.Text = "Chiến dịch bắt đầu sau " + span.Seconds.ToString() + " giây...";
            }

            F.DecTime(ref campcd);
            */

                #endregion

                #region CampaignInnerCd

            /*
            if (r47107 != null) {
                int elapsed = Convert.ToInt32(r47107.info.interval) - camprecd;

                F.ShowTime(txtCampInfo2, elapsed);

                string[] slice = r47107.slice.Split(',');
                for (int i = 0; i < slice.Length; i++) {
                    int elapsedr = Convert.ToInt32(slice[i]) * 1000;
                    if (elapsed < elapsedr) {
                        int campslcd = elapsedr - elapsed;

                        TimeSpan span = new TimeSpan(0, 0, 0, 0, campslcd);
                        txtCampInfo4.Text = V.listcamprank[4 - i] + " " + F.GetTimewH(span);
                        break;
                    }
                }
            }

            */
                #endregion

            // F.ShowDecTime(txtCampInfo3, ref camprecd);

            //F.ShowDecTime(txtCampInfo5, ref campactcd);

            //F.CoolDown(txtImposeCd, ref imposecd, ref imposecdusable);

            //F.CoolDown(txtGuideCd, ref guidecd, ref guidecdusable);

            //F.CoolDown(lblTokenCd, ref tokencd, ref tokencdusable);

            // F.CoolDown(txtTechCd, ref techcd, ref techcdusable);

            // F.CoolDown(txtUpgradeCd, ref upgradecd, ref upgradeusable);

            // string makecdusable = makecd == 0 ? "1" : "0";

            //F.CoolDown(txtWeaveCd, ref makecd, ref makecdusable);

            /*
            if (updateflag != 0) {
                btnImpose.Enabled = isimposelimit == "1" && imposecdusable == "1";
                btnGuide.Enabled = guidecdusable == "1";
                if (cbbUpg2.SelectedIndex >= 0) {
                    R39301.Item it = r39301.listitem[cbbUpg2.SelectedIndex];
                    btnUpgUp.Enabled = it.upgradeable == "1"
                        && Convert.ToInt32(it.coppercost)
                        <= Convert.ToInt32(copper)
                        && upgradeusable == "1";
                }
            }
        }

    private void tmrReq_Tick(object sender, EventArgs e) {
        tmrReq.Interval = Convert.ToInt32(numUpdate.Value);

        #region Refresh

        if (refreshcd == 0)
            SendMsg("11104");

        #endregion

        /*
        if (btnArmyInfo.Text == "Thoát"
            && armyok2) {
            armyok2 = false;
            SendMsg("34100", r33100.listarmy[cbbArmy2.SelectedIndex].armyid);
        }

        if (btnCampInfo.Text == "Thoát")
            SendMsg("47008", V.listcampid[cbbCamp.SelectedIndex].ToString());

        if (btnAuto.Text == "Dừng") {
        */

                #region Impose

            {
                    /*
                    string s = txtImposeNum.Text;
                    if (chkImpose.Checked
                        && isimposelimit == "1"
                        && imposecdusable == "1"
                        && Convert.ToInt32(copper)
                        + Convert.ToInt32(txtImposeCopper.Text)
                        <= Convert.ToInt32(maxcopper)
                        && Convert.ToInt32(s.Remove(s.IndexOf("/"))) > 0)
                        SendMsg("12401", "0");
                        */
                }

                #endregion

                #region Train

                /*
                if (chkTrain.Checked
                    && lstGuide.Items.Count > 0) {
                    F.Cycle(ref traincycle, lstGuide.Items.Count - 1);

                    int index = 0;
                    int lv = 0;

                    TagItem it = (TagItem) lstGuide.Items[traincycle];
                    for (int i = 0; i < r41100.listgeneral.Count; i++) {
                        R41100.General gen = r41100.listgeneral[i];
                        if (it.tag == gen.generalid) {
                            lv = Convert.ToInt32(gen.generallevel);
                            index = i;
                            break;
                        }
                    }

                    int trainnum = 0;
                    for (int i = 0; i < r41100.listgeneral.Count; i++)
                        if (traincd[i] > 0)
                            trainnum++;

                    if (it.tag != null && lv < Convert.ToInt32(r11102.playerlevel)) {
                        if (trainnum < Convert.ToInt32(r41100.maxnum)
                            && traincd[index] == 0)
                            SendMsg("41101", it.tag, "1");

                        if (guidecdusable == "1"
                            && traincd[index] > 0
                            && lstGuide.CheckedIndices.Contains(traincycle)
                            && Convert.ToInt32(txtJyungong.Text) >= Convert.ToInt32(r41100.jyungong))
                            SendMsg("41102", it.tag, "1", "1");
                    }
                }
                */

                #endregion

                #region Army
                /*

                        {
                            bool ok = false;
                            if (!chkArmyRefresh.Checked)
                                ok = true;
                            else {
                                TimeSpan span2 = new TimeSpan(0, 30 + Convert.ToInt32(numArmyRefresh.Value), 0);
                                foreach (TimeSpan span in V.listtimerefresh)
                                    if (sys >= span && sys <= span + span2) {
                                        ok = true;
                                        break;
                                    }
                            }

                            /*
                            if (ok) {
                                string s = lblToken.Text;
                                s = s.Remove(s.IndexOf("/")).Substring(s.IndexOf(" ") + 1);
                                if (chkArmy.Checked
                                    && tokencdusable == "1"
                                    && lstArmyList.CheckedIndices.Count > 0
                                    && Convert.ToInt32(s) > 0
                                    && armyok
                                    && (!chkArmyCd.Checked
                                    || (chkArmyCd.Checked
                                    && tokencd == 0))) {
                                    listarmy = new int[lstArmyList.CheckedIndices.Count];

                                    for (int i = 0; i < listarmy.Length; i++)
                                        listarmy[i] = Convert.ToInt32(lstArmyList.CheckedIndices[i]);

                                    armyok = false;
                                    if (armynext)
                                        F.Cycle2(ref armycycle, listarmy);

                                    TagItem it = (TagItem) lstArmyList.Items[listarmy[armycycle]];
                                    if (armynext) {
                                        armynext = false;
                                        LogText("[Chiến] Chờ " + it.text);
                                    }

                                    if (Convert.ToInt32(it.tag) > 900000)
                                        SendMsg("34100", it.tag);
                                    else
                                        SendMsg("33101", it.tag, "0");
                                }
                            }
                        }
                        */

                #endregion

                #region Forces

                /*
                            {
                                if (chkForcesFree.Checked
                                    && forcefreecd == 0)
                                    SendMsg("14100");

                                int diff = Convert.ToInt32(numForces.Value) - Convert.ToInt32(forces);
                                double cost = diff * Convert.ToDouble(r14101.recruits);

                                if (chkForces.Checked
                                    && diff > 0
                                    && cost <= Convert.ToInt32(food)) {
                                    SendMsg("14102", diff.ToString(), "0");
                                    LogText("[Lính] Đào tạo " + diff + " lính");
                                }
                            }
                            */

                #endregion

            }

            #region Plus

            /*
            if (chkPlus.Checked && plusok) {
                plusok = false;
                int index = lstPlus.SelectedIndex;
                int lv = Convert.ToInt32(r41300.listgeneral[index].generallevel);
                int att1 = cbbPlusAtt1.SelectedIndex;
                int att2 = cbbPlusAtt2.SelectedIndex;

                int[] org =
                {
                    Convert.ToInt32(r41302.originalattr.plusleader),
                    Convert.ToInt32(r41302.originalattr.plusforces),
                    Convert.ToInt32(r41302.originalattr.plusintelligence)
                };

                if (org[att1] >= lv + 20
                    && (!chkPlusAtt2.Checked
                    || org[F.AttPlus(att1, att2)] >= lv + 20)) {
                    LogText("[Cải tiến] Chỉ số đạt mức tối đa");
                    chkPlus.Checked = false;
                } else
                    btnPlusPlus_Click(null, null);
            }
            */

            #endregion

            #region Weave
            /*

            if (weaveok) {
                weaveautoupdate = false;
                if (btnAuto.Text == "Dừng"
                    && chkWeave.Checked
                    && makecd == 0
                    && Convert.ToInt32(r45200.info.num) > 0)
                    switch (cbbWeaveMode.SelectedIndex) {
                    case 0:
                        if (r45300 == null) {
                            weaveok = false;
                            weavecreate = true;
                            btnWeaveCreate_Click(null, null);
                        }
                        break;
                    case 1:
                        if (r45300 == null) {
                            weaveautoupdate = true;
                            weaveok = false;
                            SendMsg("45200");
                        }
                        break;
                    case 2:
                        weaveautoupdate = true;
                        weaveok = false;
                        SendMsg("45200");
                        goto case 0;
                    }

                if (navWorkshop.Visible
                    && !weaveautoupdate) {
                    weaveok = false;
                    SendMsg("45200");
                }
            }
            */

            #endregion

            #region Campaign

            /*
                if (chkCamp.Checked
                    && campactcd == 0
                    && !campend) {
                    int w = Convert.ToInt32(r47107.width);
                    int h = Convert.ToInt32(r47107.height);

                    int[,] xfinCost = new int[w, h];
                    List<Point>[,] xfinPath = new List<Point>[w, h];
                    {
                        List<Point> curPath = new List<Point>();
                        for (int i = 0; i < w; i++)
                            for (int j = 0; j < h; j++)
                                xfinCost[i, j] = -1;
                        F.SearchPath(campbl.moveInfo, campxy, curPath, 0, camppl.listmap, r47107, ref xfinCost, ref xfinPath);
                    }

                    List<PointW> listmap = new List<PointW>();
                    for (int i = 0; i < r47107.listblock.Count; i++) {
                        R47107.Block bl = r47107.listblock[i];
                        if (bl.dx == "1") {
                            Point p = new Point(Convert.ToInt32(bl.x), Convert.ToInt32(bl.y));
                            foreach (Point p2 in camppl.listmap)
                                if (p2.Equals(p)) {
                                    int[,] finCost = new int[w, h];
                                    List<Point> curPath = new List<Point>();
                                    List<Point>[,] finPath = new List<Point>[w, h];
                                    for (int k = 0; k < w; k++)
                                        for (int j = 0; j < h; j++)
                                            finCost[k, j] = -1;
                                    F.SearchPath(bl.moveInfo, p, curPath, 0, camppl.listmap, r47107, ref finCost, ref finPath);
                                    listmap.Add(new PointW(p, finCost, r47107));
                                    break;
                                }
                        }
                    }

                    List<int> listmapint = new List<int>();

                    int num = 0;
                    foreach (PointW pw in listmap)
                        listmapint.Add(num++);

                    if (num != 0) {
                        Permutation pm = new Permutation(listmapint);

                        int first = -1;
                        int costlowest = 99999999;

                        foreach (List<int> list in pm.result) {
                            int tempcost = 99999999;

                            F.TotalCost(list, listmap, 0, xfinCost[listmap[list[0]].p.X, listmap[list[0]].p.Y], ref tempcost);
                            if (tempcost <= costlowest) {
                                costlowest = tempcost;
                                first = list[0];
                            }
                        }

                        Point nPoint = listmap[first].p;
                        Point nPath = xfinPath[nPoint.X, nPoint.Y][0];

                        R47107.Block nbl = r47107.listblock[nPath.Y * w + nPath.X];
                        if (nbl.dx != "2")
                            SendMsg(nbl.dx == "1" ? "47103" : "47102",
                                nPath.X.ToString(),
                                nPath.Y.ToString(),
                                r47107.id);

                        LogText("[Chiến dịch] Di chuyển đến toạ độ (" + nPath.X.ToString() + "," + nPath.Y.ToString() + ")");
                    }
                }
                */

            #endregion

        }

        #region Chat

        /*
            private void txtChat_KeyPress(object sender, KeyPressEventArgs e) {
                if (e.KeyChar == 13 && txtChat.Text.Trim() != "") {
                    int n = cbbChat.SelectedIndex - 1;
                    if (chatcd[n] == 0) {
                        switch (n) {
                        case 0:
                        case 1:
                        case 3:
                            chatcd[n] = 3500;
                            break;
                        case 2:
                            chatcd[n] = 10000;
                            break;
                        }

                        // SendMsg("10103", r11102.playername, txtChat.Text, (n + 2).ToString(), " ");
                        txtChat.Text = "";
                    }
                }
            }
            */

        /*
        private void btnChatExpand_Click(object sender, EventArgs e) {
            if (btnChatExpand.Text == "+")
                btnChatExpand.Text = "1";
            navChat.BringToFront();
            if (btnChatExpand.Text == "1") {
                btnChatExpand.Text = "2";
                navChat.Top -= 200;
                navChat.Height += 200;
            } else if (btnChatExpand.Text == "2") {
                btnChatExpand.Text = "3";
                navChat.Width += 500;
            } else if (btnChatExpand.Text == "3") {
                btnChatExpand.Text = "1";
                navChat.Width -= 500;
                navChat.Height -= 200;
                navChat.Top += 200;
            }
        }
        */

        #endregion

        #region Office

        #region Impose

        /*
        private void btnImpose_Click(object sender, EventArgs e) {
            SendMsg("12401", "0");
        }

        private void btnImposeForce_Click(object sender, EventArgs e) {
            SendMsg("12401", "1");
        }

        private void btnImposeAnswer1_Click(object sender, EventArgs e) {
            SendMsg("12406", "1");
        }

        private void btnImposeAnswer2_Click(object sender, EventArgs e) {
            SendMsg("12406", "2");
        }
        */

        #endregion

        #region Salary

        private void btnSalary_Click(object sender, EventArgs e) {
            SendMsg("12302");
        }

        #endregion

        #region Food

        private void btnFoodBuy_Click(object sender, EventArgs e) {
            SendMsg("13101", "0", barFoodBuy.Value.ToString());
        }

        private void btnFoodSell_Click(object sender, EventArgs e) {
            SendMsg("13101", "1", barFoodSell.Value.ToString());
        }

        private void barFoodBuy_Scroll(object sender, EventArgs e) {
            lblFoodBuy.Text = "Tiêu tốn " + barFoodBuy.Value * Convert.ToDouble(r13100.price)
                + " Bạc để mua " + barFoodBuy.Value + " lúa";
        }

        private void barFoodSell_Scroll(object sender, EventArgs e) {
            lblFoodSell.Text = "Bán " + barFoodSell.Value + " lúa, nhận được "
                + barFoodSell.Value * Convert.ToDouble(r13100.price) + " Bạc";
        }

        #endregion

        #endregion

        #region Weave



        #endregion

        #region Others

        private void navOthers_SelectedPageChanged(object sender, EventArgs e) {
            SendMsg("14101");
        }

        #endregion

        #region Misc

        private void btnSave_Click(object sender, EventArgs e) {
            // SaveConfig();
        }

        /*
        private void btnAuto_Click(object sender, EventArgs e) {
            if (btnAuto.Text == "Bắt đầu") {
                btnAuto.Text = "Dừng";
                btnArmyInfo.Enabled = false;
            } else {
                btnAuto.Text = "Bắt đầu";
                btnArmyInfo.Enabled = true;
            }
            chkArmy_CheckedChanged(null, null);
            chkWeave_CheckedChanged(null, null);
        }

        private void txtLogs_TextChanged(object sender, EventArgs e) {
            txtLogs.SelectionStart = txtLogs.TextLength;
            txtLogs.ScrollToCaret();
        }
        */

        #endregion

        #region Forces

        private void btnForcesRecruit_Click(object sender, EventArgs e) {
            //  SendMsg("14102", numForcesRecruit.Value.ToString(), "0");
        }

        private void btnForcesFree_Click(object sender, EventArgs e) {
            SendMsg("14100");
        }

        #endregion



    }
}