namespace Client
{
    partial class ClientForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerIPAddress = new System.Windows.Forms.TextBox();
            this.PortNumber = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ConnectionStatus = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remote Server Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port #";
            // 
            // ServerIPAddress
            // 
            this.ServerIPAddress.Location = new System.Drawing.Point(16, 30);
            this.ServerIPAddress.Name = "ServerIPAddress";
            this.ServerIPAddress.Size = new System.Drawing.Size(125, 20);
            this.ServerIPAddress.TabIndex = 2;
            this.ServerIPAddress.Text = "127.0.0.1";
            // 
            // PortNumber
            // 
            this.PortNumber.Location = new System.Drawing.Point(147, 29);
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(44, 20);
            this.PortNumber.TabIndex = 3;
            this.PortNumber.Text = "8080";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(199, 27);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(38, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "GO";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Connection Status";
            // 
            // ConnectionStatus
            // 
            this.ConnectionStatus.Location = new System.Drawing.Point(243, 29);
            this.ConnectionStatus.Name = "ConnectionStatus";
            this.ConnectionStatus.ReadOnly = true;
            this.ConnectionStatus.Size = new System.Drawing.Size(98, 20);
            this.ConnectionStatus.TabIndex = 6;
            this.ConnectionStatus.Text = "Not Connected";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(16, 56);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(49, 47);
            this.Button1.TabIndex = 7;
            this.Button1.Text = "-";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(74, 56);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(49, 47);
            this.Button2.TabIndex = 8;
            this.Button2.Text = "-";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(129, 56);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(49, 47);
            this.Button3.TabIndex = 9;
            this.Button3.Text = "-";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 47);
            this.button4.TabIndex = 10;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(74, 109);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 47);
            this.button5.TabIndex = 11;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(129, 109);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 47);
            this.button6.TabIndex = 12;
            this.button6.Text = "-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(16, 162);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 47);
            this.button7.TabIndex = 13;
            this.button7.Text = "-";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(74, 162);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(49, 47);
            this.button8.TabIndex = 14;
            this.button8.Text = "-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(129, 162);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(49, 47);
            this.button9.TabIndex = 15;
            this.button9.Text = "-";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(184, 56);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(113, 47);
            this.NewGameButton.TabIndex = 16;
            this.NewGameButton.Text = "NEW GAME";
            this.NewGameButton.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(184, 109);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(113, 47);
            this.button11.TabIndex = 17;
            this.button11.Text = "DISCONNECT";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 215);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ConnectionStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.PortNumber);
            this.Controls.Add(this.ServerIPAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClientForm";
            this.Text = "Client TCP/IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerIPAddress;
        private System.Windows.Forms.TextBox PortNumber;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConnectionStatus;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button button11;
    }
}

