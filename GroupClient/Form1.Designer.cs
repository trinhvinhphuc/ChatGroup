namespace GroupClient
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.messagesBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.signinButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(312, 64);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(147, 23);
            this.passwordBox.TabIndex = 19;
            this.passwordBox.Text = "123";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(312, 35);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(147, 23);
            this.portBox.TabIndex = 20;
            this.portBox.Text = "2009";
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(84, 141);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(277, 23);
            this.messageBox.TabIndex = 22;
            this.messageBox.Text = "Hello World";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(84, 64);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(147, 23);
            this.usernameBox.TabIndex = 23;
            this.usernameBox.Text = "A";
            // 
            // messagesBox
            // 
            this.messagesBox.Location = new System.Drawing.Point(84, 198);
            this.messagesBox.Multiline = true;
            this.messagesBox.Name = "messagesBox";
            this.messagesBox.Size = new System.Drawing.Size(375, 219);
            this.messagesBox.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(84, 35);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(147, 23);
            this.ipBox.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(84, 169);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(375, 23);
            this.sendButton.TabIndex = 16;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Enabled = false;
            this.logoutButton.Location = new System.Drawing.Point(367, 93);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(92, 23);
            this.logoutButton.TabIndex = 17;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(84, 93);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(147, 23);
            this.loginButton.TabIndex = 18;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "IP";
            // 
            // toBox
            // 
            this.toBox.Location = new System.Drawing.Point(392, 141);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(67, 23);
            this.toBox.TabIndex = 22;
            this.toBox.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "To";
            // 
            // signinButton
            // 
            this.signinButton.Location = new System.Drawing.Point(237, 93);
            this.signinButton.Name = "signinButton";
            this.signinButton.Size = new System.Drawing.Size(124, 23);
            this.signinButton.TabIndex = 17;
            this.signinButton.Text = "Signin";
            this.signinButton.UseVisualStyleBackColor = true;
            this.signinButton.Click += new System.EventHandler(this.signinButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(84, 423);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(375, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 450);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.messagesBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.signinButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox passwordBox;
        private TextBox portBox;
        private TextBox messageBox;
        private TextBox usernameBox;
        private TextBox messagesBox;
        private Label label5;
        private TextBox ipBox;
        private Label label2;
        private Button sendButton;
        private Button logoutButton;
        private Button loginButton;
        private Label label4;
        private Label label3;
        private Label label1;
        private TextBox toBox;
        private Label label6;
        private Button signinButton;
        private Button cancelButton;
    }
}