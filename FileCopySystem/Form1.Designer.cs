namespace FileCopySystem
{
    partial class FileCopySystem
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btncopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(296, 99);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(196, 22);
            this.dtpDate.TabIndex = 0;
            // 
            // btncopy
            // 
            this.btncopy.BackColor = System.Drawing.Color.DodgerBlue;
            this.btncopy.Location = new System.Drawing.Point(345, 162);
            this.btncopy.Name = "btncopy";
            this.btncopy.Size = new System.Drawing.Size(75, 40);
            this.btncopy.TabIndex = 1;
            this.btncopy.Text = "Copy File";
            this.btncopy.UseVisualStyleBackColor = false;
            // 
            // FileCopySystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btncopy);
            this.Controls.Add(this.dtpDate);
            this.MaximizeBox = false;
            this.Name = "FileCopySystem";
            this.ShowIcon = false;
            this.Text = "FileCopy System";
            this.Load += new System.EventHandler(this.FileCopySystem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btncopy;
    }
}

