namespace SatelliteSimulatorGUI
{
    partial class Layout
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
            this.portName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.availableCommands = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendCommand = new System.Windows.Forms.Button();
            this.reportBox = new System.Windows.Forms.TextBox();
            this.ackBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portName
            // 
            this.portName.FormattingEnabled = true;
            this.portName.Location = new System.Drawing.Point(15, 25);
            this.portName.Name = "portName";
            this.portName.Size = new System.Drawing.Size(262, 21);
            this.portName.TabIndex = 0;
            this.portName.SelectedIndexChanged += new System.EventHandler(this.COMPortIndexChanged);
            this.portName.Click += new System.EventHandler(this.checkPortNames);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port of the Ground Station Emulator";
            // 
            // connectButton
            // 
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.connectButton.Location = new System.Drawing.Point(283, 23);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(176, 23);
            this.connectButton.TabIndex = 12;
            this.connectButton.Text = "Connect to Ground Station";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectClicked);
            // 
            // availableCommands
            // 
            this.availableCommands.FormattingEnabled = true;
            this.availableCommands.Location = new System.Drawing.Point(15, 100);
            this.availableCommands.Name = "availableCommands";
            this.availableCommands.Size = new System.Drawing.Size(444, 21);
            this.availableCommands.TabIndex = 13;
            this.availableCommands.SelectedIndexChanged += new System.EventHandler(this.updateCommand);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Command";
            // 
            // sendCommand
            // 
            this.sendCommand.Location = new System.Drawing.Point(15, 127);
            this.sendCommand.Name = "sendCommand";
            this.sendCommand.Size = new System.Drawing.Size(444, 23);
            this.sendCommand.TabIndex = 16;
            this.sendCommand.Text = "Send Command";
            this.sendCommand.UseVisualStyleBackColor = true;
            this.sendCommand.Click += new System.EventHandler(this.sendCommandToProgram);
            // 
            // reportBox
            // 
            this.reportBox.Location = new System.Drawing.Point(15, 237);
            this.reportBox.Name = "reportBox";
            this.reportBox.Size = new System.Drawing.Size(444, 20);
            this.reportBox.TabIndex = 17;
            // 
            // ackBox
            // 
            this.ackBox.Location = new System.Drawing.Point(15, 186);
            this.ackBox.Name = "ackBox";
            this.ackBox.Size = new System.Drawing.Size(444, 20);
            this.ackBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Acknowledgement";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Report";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(244, 58);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(215, 13);
            this.connectionStatusLabel.TabIndex = 21;
            this.connectionStatusLabel.Text = "Connection Status. Please select COM Port.";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 276);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ackBox);
            this.Controls.Add(this.reportBox);
            this.Controls.Add(this.sendCommand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.availableCommands);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portName);
            this.Name = "Layout";
            this.Text = "Satellite Simulator RS232";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox availableCommands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendCommand;
        private System.Windows.Forms.TextBox reportBox;
        private System.Windows.Forms.TextBox ackBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label connectionStatusLabel;
    }
}

