namespace Sw_project
{
    partial class signin
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
            this.email_in = new System.Windows.Forms.TextBox();
            this.pass_in = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "password";
            // 
            // email_in
            // 
            this.email_in.Location = new System.Drawing.Point(280, 60);
            this.email_in.Name = "email_in";
            this.email_in.Size = new System.Drawing.Size(270, 22);
            this.email_in.TabIndex = 3;
            // 
            // pass_in
            // 
            this.pass_in.Location = new System.Drawing.Point(280, 114);
            this.pass_in.Name = "pass_in";
            this.pass_in.Size = new System.Drawing.Size(270, 22);
            this.pass_in.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 68);
            this.button1.TabIndex = 5;
            this.button1.Text = "sign in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // signin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pass_in);
            this.Controls.Add(this.email_in);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "signin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signin";
            this.Load += new System.EventHandler(this.signin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox email_in;
        private System.Windows.Forms.TextBox pass_in;
        private System.Windows.Forms.Button button1;
    }
}