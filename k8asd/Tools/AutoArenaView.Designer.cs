﻿namespace k8asd {
    partial class AutoArenaView {
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
            this.nationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.levelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timesColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cascadeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rankColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerList = new BrightIdeasSoftware.ObjectListView();
            this.cooldownColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.refreshButton = new System.Windows.Forms.Button();
            this.duelButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.autoDuelCheck = new System.Windows.Forms.CheckBox();
            this.cooldownLabel = new System.Windows.Forms.Label();
            this.timerArena = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).BeginInit();
            this.SuspendLayout();
            // 
            // nationColumn
            // 
            this.nationColumn.AspectName = "";
            this.nationColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nationColumn.MaximumWidth = 50;
            this.nationColumn.MinimumWidth = 50;
            this.nationColumn.Text = "Q. gia";
            this.nationColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nationColumn.Width = 50;
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "";
            this.nameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameColumn.MaximumWidth = 150;
            this.nameColumn.MinimumWidth = 150;
            this.nameColumn.Text = "Người chơi";
            this.nameColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameColumn.Width = 150;
            // 
            // levelColumn
            // 
            this.levelColumn.AspectName = "";
            this.levelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.levelColumn.MaximumWidth = 40;
            this.levelColumn.MinimumWidth = 40;
            this.levelColumn.Text = "Cấp";
            this.levelColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.levelColumn.Width = 40;
            // 
            // timesColumn
            // 
            this.timesColumn.AspectName = "";
            this.timesColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timesColumn.MaximumWidth = 40;
            this.timesColumn.MinimumWidth = 40;
            this.timesColumn.Text = "Lượt";
            this.timesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timesColumn.Width = 40;
            // 
            // cascadeColumn
            // 
            this.cascadeColumn.AspectName = "";
            this.cascadeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cascadeColumn.MaximumWidth = 60;
            this.cascadeColumn.MinimumWidth = 60;
            this.cascadeColumn.Text = "L. thắng";
            this.cascadeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rankColumn
            // 
            this.rankColumn.AspectName = "";
            this.rankColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rankColumn.MaximumWidth = 60;
            this.rankColumn.MinimumWidth = 60;
            this.rankColumn.Text = "Hạng";
            this.rankColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerList
            // 
            this.playerList.AllColumns.Add(this.rankColumn);
            this.playerList.AllColumns.Add(this.cascadeColumn);
            this.playerList.AllColumns.Add(this.timesColumn);
            this.playerList.AllColumns.Add(this.nationColumn);
            this.playerList.AllColumns.Add(this.nameColumn);
            this.playerList.AllColumns.Add(this.levelColumn);
            this.playerList.AllColumns.Add(this.cooldownColumn);
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.CellEditUseWholeCell = false;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rankColumn,
            this.cascadeColumn,
            this.timesColumn,
            this.nationColumn,
            this.nameColumn,
            this.levelColumn,
            this.cooldownColumn});
            this.playerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerList.FullRowSelect = true;
            this.playerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playerList.Location = new System.Drawing.Point(10, 180);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.SelectColumnsOnRightClick = false;
            this.playerList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.playerList.ShowGroups = false;
            this.playerList.Size = new System.Drawing.Size(480, 270);
            this.playerList.TabIndex = 30;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            // 
            // cooldownColumn
            // 
            this.cooldownColumn.AspectName = "";
            this.cooldownColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cooldownColumn.MaximumWidth = 60;
            this.cooldownColumn.MinimumWidth = 60;
            this.cooldownColumn.Text = "Đ. băng";
            this.cooldownColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(10, 10);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 31;
            this.refreshButton.Text = "Làm mới võ đài";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // duelButton
            // 
            this.duelButton.Location = new System.Drawing.Point(120, 10);
            this.duelButton.Name = "duelButton";
            this.duelButton.Size = new System.Drawing.Size(100, 30);
            this.duelButton.TabIndex = 32;
            this.duelButton.Text = "Khiêu chiến";
            this.duelButton.UseVisualStyleBackColor = true;
            this.duelButton.Click += new System.EventHandler(this.duelButton_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(10, 50);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(480, 120);
            this.logBox.TabIndex = 33;
            // 
            // autoDuelCheck
            // 
            this.autoDuelCheck.AutoSize = true;
            this.autoDuelCheck.Location = new System.Drawing.Point(240, 16);
            this.autoDuelCheck.Name = "autoDuelCheck";
            this.autoDuelCheck.Size = new System.Drawing.Size(125, 17);
            this.autoDuelCheck.TabIndex = 34;
            this.autoDuelCheck.Text = "Tự động khiêu chiến";
            this.autoDuelCheck.UseVisualStyleBackColor = true;
            this.autoDuelCheck.CheckedChanged += new System.EventHandler(this.autoDuelCheck_CheckedChanged);
            // 
            // cooldownLabel
            // 
            this.cooldownLabel.AutoSize = true;
            this.cooldownLabel.Location = new System.Drawing.Point(380, 17);
            this.cooldownLabel.Name = "cooldownLabel";
            this.cooldownLabel.Size = new System.Drawing.Size(108, 13);
            this.cooldownLabel.TabIndex = 35;
            this.cooldownLabel.Text = "Đóng băng: 00:15:20";
            // 
            // timerArena
            // 
            this.timerArena.Interval = 1000;
            this.timerArena.Tick += new System.EventHandler(this.timerArena_Tick);
            // 
            // AutoArenaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 461);
            this.Controls.Add(this.cooldownLabel);
            this.Controls.Add(this.autoDuelCheck);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.duelButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.playerList);
            this.Name = "AutoArenaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoArenaView";
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView playerList;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button duelButton;
        private BrightIdeasSoftware.OLVColumn cooldownColumn;
        private System.Windows.Forms.TextBox logBox;
        private BrightIdeasSoftware.OLVColumn cascadeColumn;
        private BrightIdeasSoftware.OLVColumn rankColumn;
        private System.Windows.Forms.CheckBox autoDuelCheck;
        private System.Windows.Forms.Label cooldownLabel;
        private System.Windows.Forms.Timer timerArena;
        private BrightIdeasSoftware.OLVColumn nationColumn;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn levelColumn;
        private BrightIdeasSoftware.OLVColumn timesColumn;
    }
}