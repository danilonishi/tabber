namespace Tabber
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.actionButton = new System.Windows.Forms.Button();
			this.intervalField = new System.Windows.Forms.NumericUpDown();
			this.countdownField = new System.Windows.Forms.NumericUpDown();
			this.TabTimer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.startDelayField = new System.Windows.Forms.NumericUpDown();
			this.setTabberHotkeyBtn = new System.Windows.Forms.Button();
			this.tabberHotkeyLabel = new System.Windows.Forms.Label();
			this.clearTabberHotkeyBtn = new System.Windows.Forms.Button();
			this.screenSelector = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.blinkingNumber = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.blinkCount = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.clearScreenshotHotkeyBtn = new System.Windows.Forms.Button();
			this.setScreenshotHotkeyBtn = new System.Windows.Forms.Button();
			this.screenshotLabel = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.intervalField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.countdownField)).BeginInit();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.startDelayField)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.blinkingNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blinkCount)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// actionButton
			// 
			this.actionButton.Location = new System.Drawing.Point(180, 16);
			this.actionButton.Name = "actionButton";
			this.actionButton.Size = new System.Drawing.Size(130, 72);
			this.actionButton.TabIndex = 0;
			this.actionButton.Text = "Enable";
			this.actionButton.UseVisualStyleBackColor = true;
			this.actionButton.Click += new System.EventHandler(this.action_Click);
			// 
			// intervalField
			// 
			this.intervalField.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.intervalField.Location = new System.Drawing.Point(98, 16);
			this.intervalField.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.intervalField.Name = "intervalField";
			this.intervalField.Size = new System.Drawing.Size(75, 20);
			this.intervalField.TabIndex = 2;
			this.intervalField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.intervalField.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
			// 
			// countdownField
			// 
			this.countdownField.Location = new System.Drawing.Point(98, 42);
			this.countdownField.Name = "countdownField";
			this.countdownField.Size = new System.Drawing.Size(75, 20);
			this.countdownField.TabIndex = 3;
			this.countdownField.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// TabTimer
			// 
			this.TabTimer.Enabled = true;
			this.TabTimer.Interval = 50;
			this.TabTimer.Tick += new System.EventHandler(this.uiTimer_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Tab Interval (ms)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Execution Count";
			// 
			// statusStrip1
			// 
			this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 320);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusStrip1.Size = new System.Drawing.Size(343, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "Ready.";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Start Delay (s)";
			// 
			// startDelayField
			// 
			this.startDelayField.Location = new System.Drawing.Point(98, 68);
			this.startDelayField.Name = "startDelayField";
			this.startDelayField.Size = new System.Drawing.Size(75, 20);
			this.startDelayField.TabIndex = 9;
			this.startDelayField.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// setTabberHotkeyBtn
			// 
			this.setTabberHotkeyBtn.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.setTabberHotkeyBtn.Location = new System.Drawing.Point(6, 107);
			this.setTabberHotkeyBtn.Name = "setTabberHotkeyBtn";
			this.setTabberHotkeyBtn.Size = new System.Drawing.Size(149, 23);
			this.setTabberHotkeyBtn.TabIndex = 10;
			this.setTabberHotkeyBtn.Text = "Change Hotkey";
			this.setTabberHotkeyBtn.UseVisualStyleBackColor = true;
			this.setTabberHotkeyBtn.Click += new System.EventHandler(this.setTabberHotkeyBtn_Click);
			// 
			// tabberHotkeyLabel
			// 
			this.tabberHotkeyLabel.AutoSize = true;
			this.tabberHotkeyLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.tabberHotkeyLabel.Location = new System.Drawing.Point(6, 91);
			this.tabberHotkeyLabel.Name = "tabberHotkeyLabel";
			this.tabberHotkeyLabel.Size = new System.Drawing.Size(110, 13);
			this.tabberHotkeyLabel.TabIndex = 11;
			this.tabberHotkeyLabel.Text = "Tabber Hotkey: None";
			// 
			// clearTabberHotkeyBtn
			// 
			this.clearTabberHotkeyBtn.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.clearTabberHotkeyBtn.Location = new System.Drawing.Point(161, 107);
			this.clearTabberHotkeyBtn.Name = "clearTabberHotkeyBtn";
			this.clearTabberHotkeyBtn.Size = new System.Drawing.Size(149, 23);
			this.clearTabberHotkeyBtn.TabIndex = 12;
			this.clearTabberHotkeyBtn.Text = "Clear Hotkey";
			this.clearTabberHotkeyBtn.UseVisualStyleBackColor = true;
			this.clearTabberHotkeyBtn.Click += new System.EventHandler(this.clearTabberHotkeyBtn_Click);
			// 
			// screenSelector
			// 
			this.screenSelector.FormattingEnabled = true;
			this.screenSelector.Location = new System.Drawing.Point(9, 38);
			this.screenSelector.Name = "screenSelector";
			this.screenSelector.Size = new System.Drawing.Size(121, 21);
			this.screenSelector.TabIndex = 13;
			this.screenSelector.SelectedIndexChanged += new System.EventHandler(this.handleDisplayChange);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.blinkingNumber);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.blinkCount);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.clearScreenshotHotkeyBtn);
			this.groupBox1.Controls.Add(this.setScreenshotHotkeyBtn);
			this.groupBox1.Controls.Add(this.screenshotLabel);
			this.groupBox1.Controls.Add(this.screenSelector);
			this.groupBox1.Location = new System.Drawing.Point(12, 158);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(318, 148);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Screen Comparison";
			// 
			// blinkingNumber
			// 
			this.blinkingNumber.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.blinkingNumber.Location = new System.Drawing.Point(169, 77);
			this.blinkingNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.blinkingNumber.Name = "blinkingNumber";
			this.blinkingNumber.Size = new System.Drawing.Size(143, 20);
			this.blinkingNumber.TabIndex = 21;
			this.blinkingNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.blinkingNumber.ValueChanged += new System.EventHandler(this.blinkingNumber_ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(169, 61);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Blinking Speed (ms)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(169, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Number of blinks";
			// 
			// blinkCount
			// 
			this.blinkCount.Location = new System.Drawing.Point(169, 38);
			this.blinkCount.Name = "blinkCount";
			this.blinkCount.Size = new System.Drawing.Size(143, 20);
			this.blinkCount.TabIndex = 18;
			this.blinkCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.blinkCount.ValueChanged += new System.EventHandler(this.blinkCount_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "Display";
			// 
			// clearScreenshotHotkeyBtn
			// 
			this.clearScreenshotHotkeyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clearScreenshotHotkeyBtn.Location = new System.Drawing.Point(169, 119);
			this.clearScreenshotHotkeyBtn.Name = "clearScreenshotHotkeyBtn";
			this.clearScreenshotHotkeyBtn.Size = new System.Drawing.Size(143, 23);
			this.clearScreenshotHotkeyBtn.TabIndex = 16;
			this.clearScreenshotHotkeyBtn.Text = "Clear Hotkey";
			this.clearScreenshotHotkeyBtn.UseVisualStyleBackColor = true;
			this.clearScreenshotHotkeyBtn.Click += new System.EventHandler(this.clearScreenshotHotkeyBtn_Click);
			// 
			// setScreenshotHotkeyBtn
			// 
			this.setScreenshotHotkeyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.setScreenshotHotkeyBtn.Location = new System.Drawing.Point(6, 119);
			this.setScreenshotHotkeyBtn.Name = "setScreenshotHotkeyBtn";
			this.setScreenshotHotkeyBtn.Size = new System.Drawing.Size(140, 23);
			this.setScreenshotHotkeyBtn.TabIndex = 15;
			this.setScreenshotHotkeyBtn.Text = "Change Hotkey";
			this.setScreenshotHotkeyBtn.UseVisualStyleBackColor = true;
			this.setScreenshotHotkeyBtn.Click += new System.EventHandler(this.setScreenshotHotkeyBtn_Click);
			// 
			// screenshotLabel
			// 
			this.screenshotLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.screenshotLabel.AutoSize = true;
			this.screenshotLabel.Location = new System.Drawing.Point(6, 103);
			this.screenshotLabel.Name = "screenshotLabel";
			this.screenshotLabel.Size = new System.Drawing.Size(110, 13);
			this.screenshotLabel.TabIndex = 14;
			this.screenshotLabel.Text = "Screen Hotkey: None";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.intervalField);
			this.groupBox2.Controls.Add(this.clearTabberHotkeyBtn);
			this.groupBox2.Controls.Add(this.actionButton);
			this.groupBox2.Controls.Add(this.countdownField);
			this.groupBox2.Controls.Add(this.setTabberHotkeyBtn);
			this.groupBox2.Controls.Add(this.tabberHotkeyLabel);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.startDelayField);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(318, 140);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tabber";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 342);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Tabber 2";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.handleKeyUp);
			((System.ComponentModel.ISupportInitialize)(this.intervalField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.countdownField)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.startDelayField)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.blinkingNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blinkCount)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button actionButton;
		private System.Windows.Forms.NumericUpDown intervalField;
		private System.Windows.Forms.NumericUpDown countdownField;
		private System.Windows.Forms.Timer TabTimer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown startDelayField;
		private System.Windows.Forms.Button setTabberHotkeyBtn;
		private System.Windows.Forms.Label tabberHotkeyLabel;
		private System.Windows.Forms.Button clearTabberHotkeyBtn;
		private System.Windows.Forms.ComboBox screenSelector;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button clearScreenshotHotkeyBtn;
		private System.Windows.Forms.Button setScreenshotHotkeyBtn;
		private System.Windows.Forms.Label screenshotLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown blinkCount;
		private System.Windows.Forms.NumericUpDown blinkingNumber;
		private System.Windows.Forms.Label label7;
	}
}

