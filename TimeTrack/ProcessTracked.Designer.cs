namespace TimeTrack
{
    partial class ProcessTracked
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelProcessTitle = new System.Windows.Forms.Label();
            this.labelProcessName = new System.Windows.Forms.Label();
            this.checkboxIsTracked = new System.Windows.Forms.CheckBox();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProcessTitle
            // 
            this.labelProcessTitle.Location = new System.Drawing.Point(72, 3);
            this.labelProcessTitle.Name = "labelProcessTitle";
            this.labelProcessTitle.Size = new System.Drawing.Size(212, 14);
            this.labelProcessTitle.TabIndex = 0;
            this.labelProcessTitle.Text = "label1";
            this.labelProcessTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelProcessName
            // 
            this.labelProcessName.Location = new System.Drawing.Point(3, 3);
            this.labelProcessName.Name = "labelProcessName";
            this.labelProcessName.Size = new System.Drawing.Size(92, 14);
            this.labelProcessName.TabIndex = 1;
            this.labelProcessName.Text = "label1";
            // 
            // checkboxIsTracked
            // 
            this.checkboxIsTracked.AutoSize = true;
            this.checkboxIsTracked.Location = new System.Drawing.Point(182, 20);
            this.checkboxIsTracked.Name = "checkboxIsTracked";
            this.checkboxIsTracked.Size = new System.Drawing.Size(102, 17);
            this.checkboxIsTracked.TabIndex = 2;
            this.checkboxIsTracked.Text = "Track Program?";
            this.checkboxIsTracked.UseVisualStyleBackColor = true;
            this.checkboxIsTracked.CheckedChanged += new System.EventHandler(this.CheckboxIsTracked_CheckedChanged);
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTime.Location = new System.Drawing.Point(3, 17);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(176, 23);
            this.labelTotalTime.TabIndex = 3;
            this.labelTotalTime.Text = "0:0:00";
            this.labelTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcessTracked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTotalTime);
            this.Controls.Add(this.checkboxIsTracked);
            this.Controls.Add(this.labelProcessName);
            this.Controls.Add(this.labelProcessTitle);
            this.Name = "ProcessTracked";
            this.Size = new System.Drawing.Size(287, 43);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProcessTitle;
        private System.Windows.Forms.Label labelProcessName;
        private System.Windows.Forms.CheckBox checkboxIsTracked;
        private System.Windows.Forms.Label labelTotalTime;
    }
}
