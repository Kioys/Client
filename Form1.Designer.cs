namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uHostTB = new System.Windows.Forms.TextBox();
            this.uPortTB = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.displayRTB = new System.Windows.Forms.RichTextBox();
            this.messageTB = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.statusLight = new System.Windows.Forms.PictureBox();
            this.uUsernameTB = new System.Windows.Forms.TextBox();
            this.sPasswordTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusLight)).BeginInit();
            this.SuspendLayout();
            // 
            // uHostTB
            // 
            this.uHostTB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uHostTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uHostTB.Location = new System.Drawing.Point(14, 12);
            this.uHostTB.Name = "uHostTB";
            this.uHostTB.Size = new System.Drawing.Size(100, 20);
            this.uHostTB.TabIndex = 0;
            this.uHostTB.Text = "localhost";
            this.uHostTB.Click += new System.EventHandler(this.uHostTB_Click);
            // 
            // uPortTB
            // 
            this.uPortTB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uPortTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uPortTB.Location = new System.Drawing.Point(14, 38);
            this.uPortTB.Name = "uPortTB";
            this.uPortTB.Size = new System.Drawing.Size(100, 20);
            this.uPortTB.TabIndex = 1;
            this.uPortTB.Text = "443";
            this.uPortTB.Click += new System.EventHandler(this.uPortTB_Click);
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Location = new System.Drawing.Point(14, 116);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(100, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // displayRTB
            // 
            this.displayRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayRTB.BackColor = System.Drawing.Color.Black;
            this.displayRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.displayRTB.Cursor = System.Windows.Forms.Cursors.No;
            this.displayRTB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayRTB.ForeColor = System.Drawing.Color.Aqua;
            this.displayRTB.Location = new System.Drawing.Point(127, 12);
            this.displayRTB.Name = "displayRTB";
            this.displayRTB.ReadOnly = true;
            this.displayRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.displayRTB.Size = new System.Drawing.Size(473, 171);
            this.displayRTB.TabIndex = 3;
            this.displayRTB.Text = "";
            this.displayRTB.TextChanged += new System.EventHandler(this.displayRTB_TextChanged);
            // 
            // messageTB
            // 
            this.messageTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.messageTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageTB.Location = new System.Drawing.Point(127, 189);
            this.messageTB.Name = "messageTB";
            this.messageTB.Size = new System.Drawing.Size(473, 20);
            this.messageTB.TabIndex = 4;
            this.messageTB.Text = "Message";
            this.messageTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageTB_KeyDown);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.statusLabel.Location = new System.Drawing.Point(11, 152);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(109, 13);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status: Disconnected";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.hostLabel.Location = new System.Drawing.Point(12, 172);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(97, 13);
            this.hostLabel.TabIndex = 7;
            this.hostLabel.Text = "Host:   Unspecified";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.portLabel.Location = new System.Drawing.Point(12, 192);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(97, 13);
            this.portLabel.TabIndex = 8;
            this.portLabel.Text = "Port:    Unspecified";
            // 
            // statusLight
            // 
            this.statusLight.BackColor = System.Drawing.Color.DarkRed;
            this.statusLight.Location = new System.Drawing.Point(114, 194);
            this.statusLight.Name = "statusLight";
            this.statusLight.Size = new System.Drawing.Size(10, 10);
            this.statusLight.TabIndex = 9;
            this.statusLight.TabStop = false;
            // 
            // uUsernameTB
            // 
            this.uUsernameTB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uUsernameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uUsernameTB.Location = new System.Drawing.Point(14, 64);
            this.uUsernameTB.Name = "uUsernameTB";
            this.uUsernameTB.Size = new System.Drawing.Size(100, 20);
            this.uUsernameTB.TabIndex = 10;
            this.uUsernameTB.Text = "Username";
            this.uUsernameTB.Click += new System.EventHandler(this.uUsernameTB_Click_1);
            // 
            // sPasswordTB
            // 
            this.sPasswordTB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sPasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sPasswordTB.Location = new System.Drawing.Point(14, 90);
            this.sPasswordTB.Name = "sPasswordTB";
            this.sPasswordTB.Size = new System.Drawing.Size(100, 20);
            this.sPasswordTB.TabIndex = 11;
            this.sPasswordTB.Text = "Server Password";
            this.sPasswordTB.Click += new System.EventHandler(this.sPasswordTB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(612, 218);
            this.Controls.Add(this.sPasswordTB);
            this.Controls.Add(this.uUsernameTB);
            this.Controls.Add(this.statusLight);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.messageTB);
            this.Controls.Add(this.displayRTB);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.uPortTB);
            this.Controls.Add(this.uHostTB);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Chat Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.statusLight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uHostTB;
        private System.Windows.Forms.TextBox uPortTB;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox messageTB;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label portLabel;
        public System.Windows.Forms.RichTextBox displayRTB;
        private System.Windows.Forms.PictureBox statusLight;
        private System.Windows.Forms.TextBox uUsernameTB;
        private System.Windows.Forms.TextBox sPasswordTB;
    }
}

