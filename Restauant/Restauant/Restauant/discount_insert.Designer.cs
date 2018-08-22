namespace Restauant
{
    partial class discount_insert
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
            this.button6 = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.mess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::Restauant.Properties.Resources.xp_blueoff;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(309, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 29);
            this.button6.TabIndex = 30;
            this.button6.Text = "Add";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(162, 20);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(141, 29);
            this.txtRate.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 22);
            this.label1.TabIndex = 32;
            this.label1.Text = "DISCOUNT (%) :";
            // 
            // mess
            // 
            this.mess.AutoSize = true;
            this.mess.BackColor = System.Drawing.Color.Transparent;
            this.mess.Location = new System.Drawing.Point(17, 67);
            this.mess.Name = "mess";
            this.mess.Size = new System.Drawing.Size(35, 13);
            this.mess.TabIndex = 33;
            this.mess.Text = "label2";
            // 
            // discount_insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Restauant.Properties.Resources.dust;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(414, 92);
            this.Controls.Add(this.mess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.button6);
            this.Name = "discount_insert";
            this.Text = "discount_insert";
            ((System.ComponentModel.ISupportInitialize)(this.txtRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.NumericUpDown txtRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mess;
    }
}