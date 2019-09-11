namespace TimeTrack
{
    partial class MainForm
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
            this.trackerList = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // trackerList
            // 
            this.trackerList.AutoScroll = true;
            this.trackerList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.trackerList.Location = new System.Drawing.Point(12, 12);
            this.trackerList.MaximumSize = new System.Drawing.Size(324, 34590);
            this.trackerList.Name = "trackerList";
            this.trackerList.Size = new System.Drawing.Size(324, 345);
            this.trackerList.TabIndex = 0;
            this.trackerList.WrapContents = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 369);
            this.Controls.Add(this.trackerList);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel trackerList;
    }
}