namespace MessageGeneratorApp
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblThreadCount = new System.Windows.Forms.Label();
            this.numThreadCount = new System.Windows.Forms.NumericUpDown();
            this.lstvResults = new System.Windows.Forms.ListView();
            this.colThreadId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResults = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(332, 29);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblThreadCount
            // 
            this.lblThreadCount.AutoSize = true;
            this.lblThreadCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreadCount.Location = new System.Drawing.Point(14, 38);
            this.lblThreadCount.Name = "lblThreadCount";
            this.lblThreadCount.Size = new System.Drawing.Size(89, 16);
            this.lblThreadCount.TabIndex = 2;
            this.lblThreadCount.Text = "Thread count:";
            // 
            // numThreadCount
            // 
            this.numThreadCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numThreadCount.Location = new System.Drawing.Point(109, 36);
            this.numThreadCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numThreadCount.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numThreadCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numThreadCount.Name = "numThreadCount";
            this.numThreadCount.Size = new System.Drawing.Size(72, 23);
            this.numThreadCount.TabIndex = 3;
            this.numThreadCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThreadCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lstvResults
            // 
            this.lstvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colThreadId,
            this.colMessage});
            this.lstvResults.FullRowSelect = true;
            this.lstvResults.GridLines = true;
            this.lstvResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstvResults.Location = new System.Drawing.Point(17, 92);
            this.lstvResults.Name = "lstvResults";
            this.lstvResults.Size = new System.Drawing.Size(397, 433);
            this.lstvResults.TabIndex = 4;
            this.lstvResults.TabStop = false;
            this.lstvResults.UseCompatibleStateImageBehavior = false;
            this.lstvResults.View = System.Windows.Forms.View.Details;
            // 
            // colThreadId
            // 
            this.colThreadId.Text = "Thread ID";
            this.colThreadId.Width = 90;
            // 
            // colMessage
            // 
            this.colMessage.Text = "Message";
            this.colMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMessage.Width = 300;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(14, 72);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(54, 16);
            this.lblResults.TabIndex = 5;
            this.lblResults.Text = "Results:";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(327, 544);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 35);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(429, 601);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lstvResults);
            this.Controls.Add(this.numThreadCount);
            this.Controls.Add(this.lblThreadCount);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Message generator";
            ((System.ComponentModel.ISupportInitialize)(this.numThreadCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblThreadCount;
        private System.Windows.Forms.NumericUpDown numThreadCount;
        private System.Windows.Forms.ListView lstvResults;
        private System.Windows.Forms.ColumnHeader colThreadId;
        private System.Windows.Forms.ColumnHeader colMessage;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button btnStop;
    }
}

