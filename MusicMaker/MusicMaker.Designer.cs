namespace MusicMaker
{
    partial class MusicMaker
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.openWavFile = new System.Windows.Forms.OpenFileDialog();
            this.charWave = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.charWave)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(115, 27);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(69, 27);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(190, 32);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(132, 17);
            this.lblFile.TabIndex = 3;
            this.lblFile.Text = "No .wav file opened";
            // 
            // openWavFile
            // 
            this.openWavFile.Filter = "wav files (*.wav)|*.wav";
            this.openWavFile.Title = "Open Wav Audio File";
            this.openWavFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openWavFile_FileOk);
            // 
            // charWave
            // 
            this.charWave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.charWave.ChartAreas.Add(chartArea3);
            this.charWave.Location = new System.Drawing.Point(12, 109);
            this.charWave.Name = "charWave";
            this.charWave.Size = new System.Drawing.Size(1652, 338);
            this.charWave.TabIndex = 4;
            this.charWave.Text = "chart1";
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(40, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(40, 60);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(144, 27);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // MusicMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 459);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.charWave);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnOpen);
            this.Name = "MusicMaker";
            this.Text = "MusicMaker";
            ((System.ComponentModel.ISupportInitialize)(this.charWave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.OpenFileDialog openWavFile;
        private System.Windows.Forms.DataVisualization.Charting.Chart charWave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPlay;
    }
}

