namespace Ultimate64Debug
{
    partial class Form_Debug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bReset = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bSaveConfig = new System.Windows.Forms.Button();
            this.bStartStream = new System.Windows.Forms.Button();
            this.cbConfirmReset = new System.Windows.Forms.CheckBox();
            this.bStopStream = new System.Windows.Forms.Button();
            this.lPackets = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lPPS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMemory = new System.Windows.Forms.PictureBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lSequence = new System.Windows.Forms.Label();
            this.lNMI = new System.Windows.Forms.Label();
            this.lROM = new System.Windows.Forms.Label();
            this.lRW = new System.Windows.Forms.Label();
            this.lIRQ = new System.Windows.Forms.Label();
            this.lBA = new System.Windows.Forms.Label();
            this.lEXROM = new System.Windows.Forms.Label();
            this.lGAME = new System.Windows.Forms.Label();
            this.lPHI2 = new System.Windows.Forms.Label();
            this.Address1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bReset.Location = new System.Drawing.Point(12, 37);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(154, 41);
            this.bReset.TabIndex = 0;
            this.bReset.Text = "Send Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbIPAddress);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.bSaveConfig);
            this.groupBox6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(785, 194);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(179, 98);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Configuration";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(34, 20);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(128, 20);
            this.tbIPAddress.TabIndex = 8;
            this.tbIPAddress.Text = "---";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "IP:";
            // 
            // bSaveConfig
            // 
            this.bSaveConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bSaveConfig.Location = new System.Drawing.Point(9, 46);
            this.bSaveConfig.Name = "bSaveConfig";
            this.bSaveConfig.Size = new System.Drawing.Size(154, 42);
            this.bSaveConfig.TabIndex = 2;
            this.bSaveConfig.Text = "Apply+Save";
            this.bSaveConfig.UseVisualStyleBackColor = true;
            this.bSaveConfig.Click += new System.EventHandler(this.bSaveConfig_Click);
            // 
            // bStartStream
            // 
            this.bStartStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStartStream.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bStartStream.Location = new System.Drawing.Point(12, 83);
            this.bStartStream.Name = "bStartStream";
            this.bStartStream.Size = new System.Drawing.Size(154, 42);
            this.bStartStream.TabIndex = 14;
            this.bStartStream.Text = "Start Stream";
            this.bStartStream.UseVisualStyleBackColor = true;
            this.bStartStream.Click += new System.EventHandler(this.bStartStream_Click);
            // 
            // cbConfirmReset
            // 
            this.cbConfirmReset.Checked = true;
            this.cbConfirmReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConfirmReset.Location = new System.Drawing.Point(13, 14);
            this.cbConfirmReset.Name = "cbConfirmReset";
            this.cbConfirmReset.Size = new System.Drawing.Size(154, 24);
            this.cbConfirmReset.TabIndex = 6;
            this.cbConfirmReset.Text = "Confirm Before Reset";
            this.cbConfirmReset.UseVisualStyleBackColor = true;
            // 
            // bStopStream
            // 
            this.bStopStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStopStream.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bStopStream.Location = new System.Drawing.Point(13, 131);
            this.bStopStream.Name = "bStopStream";
            this.bStopStream.Size = new System.Drawing.Size(154, 42);
            this.bStopStream.TabIndex = 15;
            this.bStopStream.Text = "Stop Stream";
            this.bStopStream.UseVisualStyleBackColor = true;
            this.bStopStream.Click += new System.EventHandler(this.bStopStream_Click);
            // 
            // lPackets
            // 
            this.lPackets.Location = new System.Drawing.Point(105, 29);
            this.lPackets.Name = "lPackets";
            this.lPackets.Size = new System.Drawing.Size(68, 42);
            this.lPackets.TabIndex = 16;
            this.lPackets.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lPackets);
            this.groupBox1.Controls.Add(this.lPPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(784, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 99);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // lPPS
            // 
            this.lPPS.Location = new System.Drawing.Point(106, 68);
            this.lPPS.Name = "lPPS";
            this.lPPS.Size = new System.Drawing.Size(62, 17);
            this.lPPS.TabIndex = 19;
            this.lPPS.Text = "---";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 57);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total Packets:\r\nBad Packets:\r\nMissed Packets: \r\nPackets Per Sec:\r\n\r\n";
            // 
            // pbMemory
            // 
            this.pbMemory.BackColor = System.Drawing.Color.Black;
            this.pbMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMemory.Location = new System.Drawing.Point(6, 19);
            this.pbMemory.Name = "pbMemory";
            this.pbMemory.Size = new System.Drawing.Size(256, 256);
            this.pbMemory.TabIndex = 18;
            this.pbMemory.TabStop = false;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.CausesValidation = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.ColumnHeadersVisible = false;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address1});
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.grid.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.RowTemplate.Height = 16;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(470, 385);
            this.grid.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bReset);
            this.groupBox2.Controls.Add(this.bStartStream);
            this.groupBox2.Controls.Add(this.bStopStream);
            this.groupBox2.Controls.Add(this.cbConfirmReset);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(787, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 180);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbMemory);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(499, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 286);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Memory Access";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lSequence);
            this.groupBox4.Controls.Add(this.lNMI);
            this.groupBox4.Controls.Add(this.lROM);
            this.groupBox4.Controls.Add(this.lRW);
            this.groupBox4.Controls.Add(this.lIRQ);
            this.groupBox4.Controls.Add(this.lBA);
            this.groupBox4.Controls.Add(this.lEXROM);
            this.groupBox4.Controls.Add(this.lGAME);
            this.groupBox4.Controls.Add(this.lPHI2);
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(499, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 99);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Signals";
            // 
            // lSequence
            // 
            this.lSequence.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSequence.Location = new System.Drawing.Point(7, 55);
            this.lSequence.Name = "lSequence";
            this.lSequence.Size = new System.Drawing.Size(257, 21);
            this.lSequence.TabIndex = 38;
            this.lSequence.Text = "---";
            // 
            // lNMI
            // 
            this.lNMI.BackColor = System.Drawing.Color.Black;
            this.lNMI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lNMI.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNMI.Location = new System.Drawing.Point(202, 20);
            this.lNMI.Margin = new System.Windows.Forms.Padding(0);
            this.lNMI.Name = "lNMI";
            this.lNMI.Size = new System.Drawing.Size(31, 23);
            this.lNMI.TabIndex = 35;
            this.lNMI.Text = "NMI";
            this.lNMI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lROM
            // 
            this.lROM.BackColor = System.Drawing.Color.Black;
            this.lROM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lROM.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lROM.Location = new System.Drawing.Point(172, 20);
            this.lROM.Margin = new System.Windows.Forms.Padding(0);
            this.lROM.Name = "lROM";
            this.lROM.Size = new System.Drawing.Size(30, 23);
            this.lROM.TabIndex = 37;
            this.lROM.Text = "ROM";
            this.lROM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lRW
            // 
            this.lRW.BackColor = System.Drawing.Color.Black;
            this.lRW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lRW.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRW.Location = new System.Drawing.Point(231, 20);
            this.lRW.Margin = new System.Windows.Forms.Padding(0);
            this.lRW.Name = "lRW";
            this.lRW.Size = new System.Drawing.Size(32, 23);
            this.lRW.TabIndex = 36;
            this.lRW.Text = "R/W";
            this.lRW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lIRQ
            // 
            this.lIRQ.BackColor = System.Drawing.Color.Black;
            this.lIRQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lIRQ.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIRQ.Location = new System.Drawing.Point(142, 20);
            this.lIRQ.Margin = new System.Windows.Forms.Padding(0);
            this.lIRQ.Name = "lIRQ";
            this.lIRQ.Size = new System.Drawing.Size(30, 23);
            this.lIRQ.TabIndex = 34;
            this.lIRQ.Text = "IRQ";
            this.lIRQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lBA
            // 
            this.lBA.BackColor = System.Drawing.Color.Black;
            this.lBA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lBA.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBA.Location = new System.Drawing.Point(114, 20);
            this.lBA.Margin = new System.Windows.Forms.Padding(0);
            this.lBA.Name = "lBA";
            this.lBA.Size = new System.Drawing.Size(28, 23);
            this.lBA.TabIndex = 33;
            this.lBA.Text = "BA";
            this.lBA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lEXROM
            // 
            this.lEXROM.BackColor = System.Drawing.Color.Black;
            this.lEXROM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lEXROM.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEXROM.Location = new System.Drawing.Point(70, 20);
            this.lEXROM.Margin = new System.Windows.Forms.Padding(0);
            this.lEXROM.Name = "lEXROM";
            this.lEXROM.Size = new System.Drawing.Size(44, 23);
            this.lEXROM.TabIndex = 32;
            this.lEXROM.Text = "EXROM";
            this.lEXROM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lGAME
            // 
            this.lGAME.BackColor = System.Drawing.Color.Black;
            this.lGAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lGAME.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGAME.Location = new System.Drawing.Point(30, 20);
            this.lGAME.Margin = new System.Windows.Forms.Padding(0);
            this.lGAME.Name = "lGAME";
            this.lGAME.Size = new System.Drawing.Size(40, 23);
            this.lGAME.TabIndex = 31;
            this.lGAME.Text = "GAME";
            this.lGAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lPHI2
            // 
            this.lPHI2.BackColor = System.Drawing.Color.Black;
            this.lPHI2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lPHI2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPHI2.Location = new System.Drawing.Point(5, 20);
            this.lPHI2.Margin = new System.Windows.Forms.Padding(0);
            this.lPHI2.Name = "lPHI2";
            this.lPHI2.Size = new System.Drawing.Size(25, 23);
            this.lPHI2.TabIndex = 30;
            this.lPHI2.Text = "Φ2";
            this.lPHI2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Address1
            // 
            this.Address1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.NullValue = null;
            this.Address1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Address1.Frozen = true;
            this.Address1.HeaderText = "Address";
            this.Address1.Name = "Address1";
            this.Address1.ReadOnly = true;
            this.Address1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Form_Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(975, 409);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Debug";
            this.Text = "Ultimate 64 Remote Debug View";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Debug_FormClosed);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bSaveConfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Button bStartStream;
        private System.Windows.Forms.CheckBox cbConfirmReset;
        private System.Windows.Forms.Button bStopStream;
        private System.Windows.Forms.Label lPackets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMemory;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lPPS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lNMI;
        private System.Windows.Forms.Label lROM;
        private System.Windows.Forms.Label lRW;
        private System.Windows.Forms.Label lIRQ;
        private System.Windows.Forms.Label lBA;
        private System.Windows.Forms.Label lEXROM;
        private System.Windows.Forms.Label lGAME;
        private System.Windows.Forms.Label lPHI2;
        private System.Windows.Forms.Label lSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address1;
    }
}

