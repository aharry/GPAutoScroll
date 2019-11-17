namespace GPAutoScroll
{
    partial class Form1
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
            this.btnAttch = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.scrollTime = new System.Windows.Forms.NumericUpDown();
            this.scrollLines = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scrollTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollLines)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAttch
            // 
            this.btnAttch.Enabled = false;
            this.btnAttch.Location = new System.Drawing.Point(13, 13);
            this.btnAttch.Name = "btnAttch";
            this.btnAttch.Size = new System.Drawing.Size(75, 23);
            this.btnAttch.TabIndex = 0;
            this.btnAttch.Text = "Attach";
            this.btnAttch.UseVisualStyleBackColor = true;
            this.btnAttch.Click += new System.EventHandler(this.btnAttch_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(140, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(140, 42);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // scrollTime
            // 
            this.scrollTime.DecimalPlaces = 1;
            this.scrollTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.scrollTime.Location = new System.Drawing.Point(352, 13);
            this.scrollTime.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.scrollTime.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.scrollTime.Name = "scrollTime";
            this.scrollTime.Size = new System.Drawing.Size(44, 20);
            this.scrollTime.TabIndex = 3;
            this.scrollTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scrollTime.ValueChanged += new System.EventHandler(this.scrollTime_ValueChanged);
            // 
            // scrollLines
            // 
            this.scrollLines.Location = new System.Drawing.Point(352, 40);
            this.scrollLines.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.scrollLines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scrollLines.Name = "scrollLines";
            this.scrollLines.Size = new System.Drawing.Size(44, 20);
            this.scrollLines.TabIndex = 4;
            this.scrollLines.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.scrollLines.ValueChanged += new System.EventHandler(this.scrollLines_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Interval:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Space:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "seconds.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "lines.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 98);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scrollLines);
            this.Controls.Add(this.scrollTime);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAttch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "GP Auto Scroll";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrollTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAttch;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown scrollTime;
        private System.Windows.Forms.NumericUpDown scrollLines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

