namespace Ultimate64Test
{
    partial class MainForm
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
            this.bReset = new System.Windows.Forms.Button();
            this.tbKeyboardZone = new System.Windows.Forms.TextBox();
            this.bSendString = new System.Windows.Forms.Button();
            this.bReadMemory = new System.Windows.Forms.Button();
            this.bWriteMemory = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbConfirmReset = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCommonCommands = new System.Windows.Forms.ComboBox();
            this.cbAppendReturn = new System.Windows.Forms.CheckBox();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.udAddress = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValues = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bSaveConfig = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lDataSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bLoadJump = new System.Windows.Forms.Button();
            this.bLoadRun = new System.Windows.Forms.Button();
            this.bLoadMemory = new System.Windows.Forms.Button();
            this.lLoadAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lFileName = new System.Windows.Forms.Label();
            this.bSelectFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAddress)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bReset.Location = new System.Drawing.Point(9, 151);
            this.bReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(231, 88);
            this.bReset.TabIndex = 0;
            this.bReset.Text = "Send Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // tbKeyboardZone
            // 
            this.tbKeyboardZone.Location = new System.Drawing.Point(178, 29);
            this.tbKeyboardZone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbKeyboardZone.Name = "tbKeyboardZone";
            this.tbKeyboardZone.Size = new System.Drawing.Size(34, 26);
            this.tbKeyboardZone.TabIndex = 1;
            this.tbKeyboardZone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKeyboardZone_KeyDown);
            this.tbKeyboardZone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKeyboardZone_KeyPress);
            // 
            // bSendString
            // 
            this.bSendString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSendString.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bSendString.Location = new System.Drawing.Point(12, 151);
            this.bSendString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSendString.Name = "bSendString";
            this.bSendString.Size = new System.Drawing.Size(231, 88);
            this.bSendString.TabIndex = 2;
            this.bSendString.Text = "Send String";
            this.bSendString.UseVisualStyleBackColor = true;
            this.bSendString.Click += new System.EventHandler(this.bSendString_Click);
            // 
            // bReadMemory
            // 
            this.bReadMemory.Enabled = false;
            this.bReadMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReadMemory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bReadMemory.Location = new System.Drawing.Point(12, 151);
            this.bReadMemory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bReadMemory.Name = "bReadMemory";
            this.bReadMemory.Size = new System.Drawing.Size(231, 88);
            this.bReadMemory.TabIndex = 3;
            this.bReadMemory.Text = "Dump Memory";
            this.bReadMemory.UseVisualStyleBackColor = true;
            this.bReadMemory.Click += new System.EventHandler(this.bReadMemory_Click);
            // 
            // bWriteMemory
            // 
            this.bWriteMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bWriteMemory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bWriteMemory.Location = new System.Drawing.Point(9, 151);
            this.bWriteMemory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bWriteMemory.Name = "bWriteMemory";
            this.bWriteMemory.Size = new System.Drawing.Size(231, 88);
            this.bWriteMemory.TabIndex = 4;
            this.bWriteMemory.Text = "Write Memory";
            this.bWriteMemory.UseVisualStyleBackColor = true;
            this.bWriteMemory.Click += new System.EventHandler(this.bWriteMemory_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbConfirmReset);
            this.groupBox1.Controls.Add(this.bReset);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(846, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(252, 255);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset";
            // 
            // cbConfirmReset
            // 
            this.cbConfirmReset.Checked = true;
            this.cbConfirmReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConfirmReset.Location = new System.Drawing.Point(12, 28);
            this.cbConfirmReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbConfirmReset.Name = "cbConfirmReset";
            this.cbConfirmReset.Size = new System.Drawing.Size(231, 37);
            this.cbConfirmReset.TabIndex = 6;
            this.cbConfirmReset.Text = "Confirm Before Reset";
            this.cbConfirmReset.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbKeyboardZone);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(288, 300);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(252, 255);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keyboard Control";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type Here to Send:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCommonCommands);
            this.groupBox3.Controls.Add(this.cbAppendReturn);
            this.groupBox3.Controls.Add(this.tbCommand);
            this.groupBox3.Controls.Add(this.bSendString);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(288, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(252, 255);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remote Commands";
            // 
            // cbCommonCommands
            // 
            this.cbCommonCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommonCommands.FormattingEnabled = true;
            this.cbCommonCommands.Items.AddRange(new object[] {
            "load\"*\",8,1",
            "load\"$\",8",
            "run",
            "list",
            "sys64738",
            " "});
            this.cbCommonCommands.Location = new System.Drawing.Point(12, 105);
            this.cbCommonCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCommonCommands.Name = "cbCommonCommands";
            this.cbCommonCommands.Size = new System.Drawing.Size(229, 28);
            this.cbCommonCommands.TabIndex = 10;
            this.cbCommonCommands.SelectedIndexChanged += new System.EventHandler(this.cbCommonCommands_SelectedIndexChanged);
            // 
            // cbAppendReturn
            // 
            this.cbAppendReturn.Checked = true;
            this.cbAppendReturn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAppendReturn.Location = new System.Drawing.Point(12, 58);
            this.cbAppendReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAppendReturn.Name = "cbAppendReturn";
            this.cbAppendReturn.Size = new System.Drawing.Size(231, 37);
            this.cbAppendReturn.TabIndex = 9;
            this.cbAppendReturn.Text = "Append RETURN";
            this.cbAppendReturn.UseVisualStyleBackColor = true;
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(12, 26);
            this.tbCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCommand.MaxLength = 10;
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(229, 26);
            this.tbCommand.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.udAddress);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tbValues);
            this.groupBox4.Controls.Add(this.bWriteMemory);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(566, 18);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(252, 255);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "POKE";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Value(s):";
            // 
            // udAddress
            // 
            this.udAddress.Location = new System.Drawing.Point(126, 28);
            this.udAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.udAddress.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.udAddress.Name = "udAddress";
            this.udAddress.Size = new System.Drawing.Size(117, 26);
            this.udAddress.TabIndex = 9;
            this.udAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udAddress.Value = new decimal(new int[] {
            53280,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 35);
            this.label2.TabIndex = 6;
            this.label2.Text = "Address:";
            // 
            // tbValues
            // 
            this.tbValues.Location = new System.Drawing.Point(12, 105);
            this.tbValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbValues.Name = "tbValues";
            this.tbValues.Size = new System.Drawing.Size(229, 26);
            this.tbValues.TabIndex = 3;
            this.tbValues.Text = "0";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bReadMemory);
            this.groupBox5.Enabled = false;
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(566, 300);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(252, 255);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dump Memory";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbIPAddress);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.bSaveConfig);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(846, 300);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(252, 255);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Configuration";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(51, 31);
            this.tbIPAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(190, 26);
            this.tbIPAddress.TabIndex = 8;
            this.tbIPAddress.Text = "---";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 35);
            this.label4.TabIndex = 7;
            this.label4.Text = "IP:";
            // 
            // bSaveConfig
            // 
            this.bSaveConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bSaveConfig.Location = new System.Drawing.Point(12, 151);
            this.bSaveConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSaveConfig.Name = "bSaveConfig";
            this.bSaveConfig.Size = new System.Drawing.Size(231, 88);
            this.bSaveConfig.TabIndex = 2;
            this.bSaveConfig.Text = "Apply+Save";
            this.bSaveConfig.UseVisualStyleBackColor = true;
            this.bSaveConfig.Click += new System.EventHandler(this.bSaveConfig_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1124, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lDataSize);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.bLoadJump);
            this.groupBox7.Controls.Add(this.bLoadRun);
            this.groupBox7.Controls.Add(this.bLoadMemory);
            this.groupBox7.Controls.Add(this.lLoadAddress);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.lFileName);
            this.groupBox7.Controls.Add(this.bSelectFile);
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(18, 18);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(252, 537);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Remote Load and Execute";
            // 
            // lDataSize
            // 
            this.lDataSize.BackColor = System.Drawing.Color.RoyalBlue;
            this.lDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDataSize.ForeColor = System.Drawing.Color.White;
            this.lDataSize.Location = new System.Drawing.Point(141, 149);
            this.lDataSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDataSize.Name = "lDataSize";
            this.lDataSize.Size = new System.Drawing.Size(102, 35);
            this.lDataSize.TabIndex = 20;
            this.lDataSize.Text = "--";
            this.lDataSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 151);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 31);
            this.label7.TabIndex = 19;
            this.label7.Text = "Data Size:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bLoadJump
            // 
            this.bLoadJump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoadJump.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bLoadJump.Location = new System.Drawing.Point(9, 335);
            this.bLoadJump.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bLoadJump.Name = "bLoadJump";
            this.bLoadJump.Size = new System.Drawing.Size(231, 88);
            this.bLoadJump.TabIndex = 18;
            this.bLoadJump.Text = "Load + Jump";
            this.bLoadJump.UseVisualStyleBackColor = true;
            this.bLoadJump.Click += new System.EventHandler(this.bLoadJump_Click);
            // 
            // bLoadRun
            // 
            this.bLoadRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoadRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bLoadRun.Location = new System.Drawing.Point(9, 432);
            this.bLoadRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bLoadRun.Name = "bLoadRun";
            this.bLoadRun.Size = new System.Drawing.Size(231, 88);
            this.bLoadRun.TabIndex = 17;
            this.bLoadRun.Text = "Load + Run";
            this.bLoadRun.UseVisualStyleBackColor = true;
            this.bLoadRun.Click += new System.EventHandler(this.bLoadRun_Click);
            // 
            // bLoadMemory
            // 
            this.bLoadMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoadMemory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bLoadMemory.Location = new System.Drawing.Point(9, 238);
            this.bLoadMemory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bLoadMemory.Name = "bLoadMemory";
            this.bLoadMemory.Size = new System.Drawing.Size(231, 88);
            this.bLoadMemory.TabIndex = 15;
            this.bLoadMemory.Text = "Load";
            this.bLoadMemory.UseVisualStyleBackColor = true;
            this.bLoadMemory.Click += new System.EventHandler(this.bLoadMemory_Click);
            // 
            // lLoadAddress
            // 
            this.lLoadAddress.BackColor = System.Drawing.Color.RoyalBlue;
            this.lLoadAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLoadAddress.ForeColor = System.Drawing.Color.White;
            this.lLoadAddress.Location = new System.Drawing.Point(141, 114);
            this.lLoadAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLoadAddress.Name = "lLoadAddress";
            this.lLoadAddress.Size = new System.Drawing.Size(102, 35);
            this.lLoadAddress.TabIndex = 13;
            this.lLoadAddress.Text = "--";
            this.lLoadAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "Load Address:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lFileName
            // 
            this.lFileName.BackColor = System.Drawing.Color.RoyalBlue;
            this.lFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFileName.ForeColor = System.Drawing.Color.White;
            this.lFileName.Location = new System.Drawing.Point(12, 74);
            this.lFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(231, 35);
            this.lFileName.TabIndex = 11;
            this.lFileName.Text = "--";
            this.lFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bSelectFile
            // 
            this.bSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSelectFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bSelectFile.Location = new System.Drawing.Point(12, 26);
            this.bSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSelectFile.Name = "bSelectFile";
            this.bSelectFile.Size = new System.Drawing.Size(231, 38);
            this.bSelectFile.TabIndex = 10;
            this.bSelectFile.Text = "Select File";
            this.bSelectFile.UseVisualStyleBackColor = true;
            this.bSelectFile.Click += new System.EventHandler(this.bSelectFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1124, 615);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Ultimate 64 Remote Commander v1.01";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAddress)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.TextBox tbKeyboardZone;
        private System.Windows.Forms.Button bSendString;
        private System.Windows.Forms.Button bReadMemory;
        private System.Windows.Forms.Button bWriteMemory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbConfirmReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbValues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAppendReturn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bSaveConfig;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.ComboBox cbCommonCommands;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button bSelectFile;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lLoadAddress;
        private System.Windows.Forms.Button bLoadMemory;
        private System.Windows.Forms.Button bLoadJump;
        private System.Windows.Forms.Button bLoadRun;
        private System.Windows.Forms.Label lDataSize;
        private System.Windows.Forms.Label label7;
    }
}

