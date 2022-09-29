namespace Test_Automation
{
    partial class Form_DrawCurve
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
            this.userCurve1 = new HslCommunication.Controls.UserCurve();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.Transparent;
            this.userCurve1.IsAbscissaStrech = true;
            this.userCurve1.Location = new System.Drawing.Point(53, 24);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(1084, 429);
            this.userCurve1.StrechDataCountMax = 255;
            this.userCurve1.TabIndex = 0;
            this.userCurve1.ValueMaxLeft = 400F;
            this.userCurve1.ValueMaxRight = 400F;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(723, 502);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_DrawCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 581);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userCurve1);
            this.Name = "Form_DrawCurve";
            this.Text = "Form_DrawCurve";
            this.Load += new System.EventHandler(this.Form_DrawCurve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HslCommunication.Controls.UserCurve userCurve1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}