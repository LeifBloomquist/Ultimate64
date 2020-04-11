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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bReset = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bSaveConfig = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bStartStream = new System.Windows.Forms.Button();
            this.cbConfirmReset = new System.Windows.Forms.CheckBox();
            this.bStopStream = new System.Windows.Forms.Button();
            this.lPackets = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMemory = new System.Windows.Forms.PictureBox();
            this.lSequence = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Address1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bReset.Location = new System.Drawing.Point(829, 42);
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
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(829, 204);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(154, 166);
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
            this.bSaveConfig.Location = new System.Drawing.Point(6, 46);
            this.bSaveConfig.Name = "bSaveConfig";
            this.bSaveConfig.Size = new System.Drawing.Size(154, 57);
            this.bSaveConfig.TabIndex = 2;
            this.bSaveConfig.Text = "Apply+Save";
            this.bSaveConfig.UseVisualStyleBackColor = true;
            this.bSaveConfig.Click += new System.EventHandler(this.bSaveConfig_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 601);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1012, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bStartStream
            // 
            this.bStartStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStartStream.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bStartStream.Location = new System.Drawing.Point(829, 95);
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
            this.cbConfirmReset.Location = new System.Drawing.Point(829, 12);
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
            this.bStopStream.Location = new System.Drawing.Point(829, 143);
            this.bStopStream.Name = "bStopStream";
            this.bStopStream.Size = new System.Drawing.Size(154, 42);
            this.bStopStream.TabIndex = 15;
            this.bStopStream.Text = "Stop Stream";
            this.bStopStream.UseVisualStyleBackColor = true;
            this.bStopStream.Click += new System.EventHandler(this.bStopStream_Click);
            // 
            // lPackets
            // 
            this.lPackets.Location = new System.Drawing.Point(99, 28);
            this.lPackets.Name = "lPackets";
            this.lPackets.Size = new System.Drawing.Size(49, 73);
            this.lPackets.TabIndex = 16;
            this.lPackets.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lPackets);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(829, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 166);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 73);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total Packets:\r\nBad Packets:\r\nPackets Per Sec:\r\nMissed Packets: \r\n";
            // 
            // pbMemory
            // 
            this.pbMemory.BackColor = System.Drawing.Color.Black;
            this.pbMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMemory.Location = new System.Drawing.Point(513, 12);
            this.pbMemory.Name = "pbMemory";
            this.pbMemory.Size = new System.Drawing.Size(256, 256);
            this.pbMemory.TabIndex = 18;
            this.pbMemory.TabStop = false;
            // 
            // lSequence
            // 
            this.lSequence.Location = new System.Drawing.Point(513, 271);
            this.lSequence.Name = "lSequence";
            this.lSequence.Size = new System.Drawing.Size(257, 24);
            this.lSequence.TabIndex = 19;
            this.lSequence.Text = "---";
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
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.grid.RowTemplate.Height = 16;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(495, 576);
            this.grid.TabIndex = 21;
            // 
            // Address1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.NullValue = null;
            this.Address1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Address1.Frozen = true;
            this.Address1.HeaderText = "Address";
            this.Address1.Name = "Address1";
            this.Address1.ReadOnly = true;
            // 
            // Form_Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1012, 623);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.lSequence);
            this.Controls.Add(this.pbMemory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bStopStream);
            this.Controls.Add(this.cbConfirmReset);
            this.Controls.Add(this.bStartStream);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.statusStrip1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bSaveConfig;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Button bStartStream;
        private System.Windows.Forms.CheckBox cbConfirmReset;
        private System.Windows.Forms.Button bStopStream;
        private System.Windows.Forms.Label lPackets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMemory;
        private System.Windows.Forms.Label lSequence;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address1;
    }
}

