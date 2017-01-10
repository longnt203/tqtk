using System.Windows.Forms;

namespace k8asd {
    partial class ClientView : UserControl {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tmrData = new System.Windows.Forms.Timer(this.components);
            this.tmrCd = new System.Windows.Forms.Timer(this.components);
            this.tmrReq = new System.Windows.Forms.Timer(this.components);
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.btnImposeAnswer1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnImposeAnswer2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblImposeQuest = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.lblVassalLv = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalArea = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalOffice = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalCopper = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalLegion = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblVassalUpdate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barFoodBuy = new System.Windows.Forms.TrackBar();
            this.btnFoodBuy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblFoodBuy = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barFoodSell = new System.Windows.Forms.TrackBar();
            this.btnFoodSell = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblFoodSell = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.heroTrainingTab = new System.Windows.Forms.TabPage();
            this.heroTrainingView = new k8asd.HeroTrainingView();
            this.armyTab = new System.Windows.Forms.TabPage();
            this.messageLogView1 = new k8asd.MessageLogView();
            this.cooldownView = new k8asd.CooldownView();
            this.mcuView = new k8asd.McuView();
            this.infoView = new k8asd.InfoView();
            this.armyView = new k8asd.ArmyView();
            ((System.ComponentModel.ISupportInitialize)(this.barFoodBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFoodSell)).BeginInit();
            this.tabControl.SuspendLayout();
            this.heroTrainingTab.SuspendLayout();
            this.armyTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrData
            // 
            this.tmrData.Interval = 1;
            this.tmrData.Tick += new System.EventHandler(this.tmrData_Tick);
            // 
            // tmrCd
            // 
            this.tmrCd.Interval = 1000;
            // 
            // tmrReq
            // 
            this.tmrReq.Interval = 1000;
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "Menu Item\r\n2121\r\n332\r\n3";
            // 
            // btnImposeAnswer1
            // 
            this.btnImposeAnswer1.Location = new System.Drawing.Point(3, 87);
            this.btnImposeAnswer1.Name = "btnImposeAnswer1";
            this.btnImposeAnswer1.Size = new System.Drawing.Size(382, 25);
            this.btnImposeAnswer1.TabIndex = 10;
            this.btnImposeAnswer1.Values.Text = "Thu thuế";
            // 
            // btnImposeAnswer2
            // 
            this.btnImposeAnswer2.Location = new System.Drawing.Point(3, 118);
            this.btnImposeAnswer2.Name = "btnImposeAnswer2";
            this.btnImposeAnswer2.Size = new System.Drawing.Size(382, 25);
            this.btnImposeAnswer2.TabIndex = 10;
            this.btnImposeAnswer2.Values.Text = "Thu thuế";
            // 
            // lblImposeQuest
            // 
            this.lblImposeQuest.AutoSize = false;
            this.lblImposeQuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImposeQuest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblImposeQuest.Location = new System.Drawing.Point(3, 3);
            this.lblImposeQuest.Name = "lblImposeQuest";
            this.lblImposeQuest.Size = new System.Drawing.Size(382, 81);
            this.lblImposeQuest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVassalLv
            // 
            this.lblVassalLv.Location = new System.Drawing.Point(3, 3);
            this.lblVassalLv.Name = "lblVassalLv";
            this.lblVassalLv.Size = new System.Drawing.Size(32, 20);
            this.lblVassalLv.TabIndex = 4;
            this.lblVassalLv.Values.Text = "Cấp";
            // 
            // lblVassalArea
            // 
            this.lblVassalArea.Location = new System.Drawing.Point(3, 81);
            this.lblVassalArea.Name = "lblVassalArea";
            this.lblVassalArea.Size = new System.Drawing.Size(36, 20);
            this.lblVassalArea.TabIndex = 3;
            this.lblVassalArea.Values.Text = "Vị trí";
            // 
            // lblVassalOffice
            // 
            this.lblVassalOffice.Location = new System.Drawing.Point(3, 29);
            this.lblVassalOffice.Name = "lblVassalOffice";
            this.lblVassalOffice.Size = new System.Drawing.Size(50, 20);
            this.lblVassalOffice.TabIndex = 8;
            this.lblVassalOffice.Values.Text = "Chức vị";
            // 
            // lblVassalCopper
            // 
            this.lblVassalCopper.Location = new System.Drawing.Point(3, 107);
            this.lblVassalCopper.Name = "lblVassalCopper";
            this.lblVassalCopper.Size = new System.Drawing.Size(96, 20);
            this.lblVassalCopper.TabIndex = 7;
            this.lblVassalCopper.Values.Text = "Số bạc được trả";
            // 
            // lblVassalLegion
            // 
            this.lblVassalLegion.Location = new System.Drawing.Point(3, 55);
            this.lblVassalLegion.Name = "lblVassalLegion";
            this.lblVassalLegion.Size = new System.Drawing.Size(38, 20);
            this.lblVassalLegion.TabIndex = 5;
            this.lblVassalLegion.Values.Text = "Bang";
            // 
            // lblVassalUpdate
            // 
            this.lblVassalUpdate.Location = new System.Drawing.Point(3, 133);
            this.lblVassalUpdate.Name = "lblVassalUpdate";
            this.lblVassalUpdate.Size = new System.Drawing.Size(77, 20);
            this.lblVassalUpdate.TabIndex = 6;
            this.lblVassalUpdate.Values.Text = "Lần thu cuối";
            // 
            // barFoodBuy
            // 
            this.barFoodBuy.LargeChange = 100;
            this.barFoodBuy.Location = new System.Drawing.Point(3, 3);
            this.barFoodBuy.Maximum = 1000;
            this.barFoodBuy.Minimum = 1;
            this.barFoodBuy.Name = "barFoodBuy";
            this.barFoodBuy.Size = new System.Drawing.Size(324, 45);
            this.barFoodBuy.TabIndex = 0;
            this.barFoodBuy.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barFoodBuy.Value = 1;
            // 
            // btnFoodBuy
            // 
            this.btnFoodBuy.Location = new System.Drawing.Point(231, 29);
            this.btnFoodBuy.Name = "btnFoodBuy";
            this.btnFoodBuy.Size = new System.Drawing.Size(96, 25);
            this.btnFoodBuy.TabIndex = 1;
            this.btnFoodBuy.Values.Text = "Mua lúa";
            // 
            // lblFoodBuy
            // 
            this.lblFoodBuy.AutoSize = false;
            this.lblFoodBuy.Location = new System.Drawing.Point(3, 29);
            this.lblFoodBuy.Name = "lblFoodBuy";
            this.lblFoodBuy.Size = new System.Drawing.Size(222, 25);
            this.lblFoodBuy.TabIndex = 2;
            this.lblFoodBuy.Values.Text = "kryptonLabel3";
            // 
            // barFoodSell
            // 
            this.barFoodSell.LargeChange = 100;
            this.barFoodSell.Location = new System.Drawing.Point(3, 3);
            this.barFoodSell.Maximum = 1000;
            this.barFoodSell.Minimum = 1;
            this.barFoodSell.Name = "barFoodSell";
            this.barFoodSell.Size = new System.Drawing.Size(324, 45);
            this.barFoodSell.TabIndex = 0;
            this.barFoodSell.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barFoodSell.Value = 1;
            // 
            // btnFoodSell
            // 
            this.btnFoodSell.Location = new System.Drawing.Point(231, 29);
            this.btnFoodSell.Name = "btnFoodSell";
            this.btnFoodSell.Size = new System.Drawing.Size(96, 25);
            this.btnFoodSell.TabIndex = 1;
            this.btnFoodSell.Values.Text = "Bán lúa";
            // 
            // lblFoodSell
            // 
            this.lblFoodSell.AutoSize = false;
            this.lblFoodSell.Location = new System.Drawing.Point(3, 29);
            this.lblFoodSell.Name = "lblFoodSell";
            this.lblFoodSell.Size = new System.Drawing.Size(222, 25);
            this.lblFoodSell.TabIndex = 2;
            this.lblFoodSell.Values.Text = "kryptonLabel3";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.heroTrainingTab);
            this.tabControl.Controls.Add(this.armyTab);
            this.tabControl.Location = new System.Drawing.Point(321, 124);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(556, 483);
            this.tabControl.TabIndex = 33;
            // 
            // heroTrainingTab
            // 
            this.heroTrainingTab.Controls.Add(this.heroTrainingView);
            this.heroTrainingTab.Location = new System.Drawing.Point(4, 22);
            this.heroTrainingTab.Name = "heroTrainingTab";
            this.heroTrainingTab.Padding = new System.Windows.Forms.Padding(3);
            this.heroTrainingTab.Size = new System.Drawing.Size(548, 457);
            this.heroTrainingTab.TabIndex = 0;
            this.heroTrainingTab.Text = "Luyện";
            this.heroTrainingTab.UseVisualStyleBackColor = true;
            // 
            // heroTrainingView
            // 
            this.heroTrainingView.BackColor = System.Drawing.SystemColors.Control;
            this.heroTrainingView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heroTrainingView.Location = new System.Drawing.Point(3, 3);
            this.heroTrainingView.Name = "heroTrainingView";
            this.heroTrainingView.Size = new System.Drawing.Size(542, 451);
            this.heroTrainingView.TabIndex = 32;
            // 
            // armyTab
            // 
            this.armyTab.Controls.Add(this.armyView);
            this.armyTab.Location = new System.Drawing.Point(4, 22);
            this.armyTab.Name = "armyTab";
            this.armyTab.Padding = new System.Windows.Forms.Padding(3);
            this.armyTab.Size = new System.Drawing.Size(548, 457);
            this.armyTab.TabIndex = 1;
            this.armyTab.Text = "Quân đoàn";
            this.armyTab.UseVisualStyleBackColor = true;
            // 
            // messageLogView1
            // 
            this.messageLogView1.Location = new System.Drawing.Point(0, 125);
            this.messageLogView1.Name = "messageLogView1";
            this.messageLogView1.Size = new System.Drawing.Size(315, 180);
            this.messageLogView1.TabIndex = 31;
            // 
            // cooldownView
            // 
            this.cooldownView.Location = new System.Drawing.Point(320, 0);
            this.cooldownView.Name = "cooldownView";
            this.cooldownView.Size = new System.Drawing.Size(270, 100);
            this.cooldownView.TabIndex = 30;
            // 
            // mcuView
            // 
            this.mcuView.Location = new System.Drawing.Point(0, 100);
            this.mcuView.Name = "mcuView";
            this.mcuView.Size = new System.Drawing.Size(272, 22);
            this.mcuView.TabIndex = 29;
            // 
            // infoView
            // 
            this.infoView.Location = new System.Drawing.Point(0, 0);
            this.infoView.Name = "infoView";
            this.infoView.Size = new System.Drawing.Size(310, 100);
            this.infoView.TabIndex = 28;
            // 
            // armyView
            // 
            this.armyView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armyView.Location = new System.Drawing.Point(3, 3);
            this.armyView.Name = "armyView";
            this.armyView.Size = new System.Drawing.Size(542, 451);
            this.armyView.TabIndex = 0;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.messageLogView1);
            this.Controls.Add(this.cooldownView);
            this.Controls.Add(this.mcuView);
            this.Controls.Add(this.infoView);
            this.Name = "ClientView";
            this.Size = new System.Drawing.Size(883, 613);
            this.Load += new System.EventHandler(this.ClientView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barFoodBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFoodSell)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.heroTrainingTab.ResumeLayout(false);
            this.armyTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrData;
        private System.Windows.Forms.Timer tmrCd;
        private System.Windows.Forms.Timer tmrReq;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImposeAnswer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImposeAnswer2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblImposeQuest;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalLv;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalArea;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalOffice;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalCopper;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalLegion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblVassalUpdate;
        private TrackBar barFoodBuy;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFoodBuy;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFoodBuy;
        private TrackBar barFoodSell;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFoodSell;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFoodSell;
        private InfoView infoView;
        private McuView mcuView;
        private CooldownView cooldownView;
        private MessageLogView messageLogView1;
        private HeroTrainingView heroTrainingView;
        private TabControl tabControl;
        private TabPage heroTrainingTab;
        private TabPage armyTab;
        private ArmyView armyView;
    }
}

