namespace Restauant
{
    partial class close_asking
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
            this.close_end = new System.Windows.Forms.Button();
            this.day_end_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // close_end
            // 
            this.close_end.BackgroundImage = global::Restauant.Properties.Resources.strawberries;
            this.close_end.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_end.Location = new System.Drawing.Point(229, 9);
            this.close_end.Name = "close_end";
            this.close_end.Size = new System.Drawing.Size(218, 120);
            this.close_end.TabIndex = 3;
            this.close_end.Text = "Cancel";
            this.close_end.UseVisualStyleBackColor = true;
            // 
            // day_end_close
            // 
            this.day_end_close.BackgroundImage = global::Restauant.Properties.Resources.bg1;
            this.day_end_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.day_end_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day_end_close.Location = new System.Drawing.Point(5, 9);
            this.day_end_close.Name = "day_end_close";
            this.day_end_close.Size = new System.Drawing.Size(218, 120);
            this.day_end_close.TabIndex = 2;
            this.day_end_close.Text = "Day-End-Close";
            this.day_end_close.UseVisualStyleBackColor = true;
            this.day_end_close.Click += new System.EventHandler(this.day_end_close_Click);
            // 
            // close_asking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 133);
            this.Controls.Add(this.close_end);
            this.Controls.Add(this.day_end_close);
            this.Name = "close_asking";
            this.Text = "close_asking";
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button day_end_close;
        public System.Windows.Forms.Button close_end;
    }
}