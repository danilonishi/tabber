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
			this.hotkeyButton = new System.Windows.Forms.Button();
			this.hotkeyLabel = new System.Windows.Forms.Label();
			this.clearHotkeyButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.intervalField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.countdownField)).BeginInit();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.startDelayField)).BeginInit();
			this.SuspendLayout();
			// 
			// actionButton
			// 
			this.actionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.actionButton.Location = new System.Drawing.Point(263, 49);
			this.actionButton.Name = "actionButton";
			this.actionButton.Size = new System.Drawing.Size(130, 85);
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
			this.intervalField.Location = new System.Drawing.Point(104, 12);
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
			this.countdownField.Location = new System.Drawing.Point(104, 38);
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
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Tab Interval (ms)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Execution Count";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 137);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(405, 22);
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
			this.label3.Location = new System.Drawing.Point(12, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Start Delay (s)";
			// 
			// startDelayField
			// 
			this.startDelayField.Location = new System.Drawing.Point(104, 64);
			this.startDelayField.Name = "startDelayField";
			this.startDelayField.Size = new System.Drawing.Size(75, 20);
			this.startDelayField.TabIndex = 9;
			this.startDelayField.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// hotkeyButton
			// 
			this.hotkeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hotkeyButton.Location = new System.Drawing.Point(12, 111);
			this.hotkeyButton.Name = "hotkeyButton";
			this.hotkeyButton.Size = new System.Drawing.Size(113, 23);
			this.hotkeyButton.TabIndex = 10;
			this.hotkeyButton.Text = "Change Hotkey";
			this.hotkeyButton.UseVisualStyleBackColor = true;
			this.hotkeyButton.Click += new System.EventHandler(this.hotkeyButton_Click);
			// 
			// hotkeyLabel
			// 
			this.hotkeyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hotkeyLabel.AutoSize = true;
			this.hotkeyLabel.Location = new System.Drawing.Point(12, 95);
			this.hotkeyLabel.Name = "hotkeyLabel";
			this.hotkeyLabel.Size = new System.Drawing.Size(110, 13);
			this.hotkeyLabel.TabIndex = 11;
			this.hotkeyLabel.Text = "Current Hotkey: None";
			// 
			// clearHotkeyButton
			// 
			this.clearHotkeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.clearHotkeyButton.Location = new System.Drawing.Point(131, 111);
			this.clearHotkeyButton.Name = "clearHotkeyButton";
			this.clearHotkeyButton.Size = new System.Drawing.Size(113, 23);
			this.clearHotkeyButton.TabIndex = 12;
			this.clearHotkeyButton.Text = "Clear Hotkey";
			this.clearHotkeyButton.UseVisualStyleBackColor = true;
			this.clearHotkeyButton.Click += new System.EventHandler(this.clearHotkeyButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 159);
			this.Controls.Add(this.clearHotkeyButton);
			this.Controls.Add(this.hotkeyLabel);
			this.Controls.Add(this.hotkeyButton);
			this.Controls.Add(this.startDelayField);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.countdownField);
			this.Controls.Add(this.intervalField);
			this.Controls.Add(this.actionButton);
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Tabber";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.handleKeyUp);
			((System.ComponentModel.ISupportInitialize)(this.intervalField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.countdownField)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.startDelayField)).EndInit();
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
		private System.Windows.Forms.Button hotkeyButton;
		private System.Windows.Forms.Label hotkeyLabel;
		private System.Windows.Forms.Button clearHotkeyButton;
	}
}

