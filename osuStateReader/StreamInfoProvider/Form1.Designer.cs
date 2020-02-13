namespace osuStateReader
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SongProgress = new System.Windows.Forms.ProgressBar();
			this.ArtistTitleOutput = new System.Windows.Forms.TextBox();
			this.ReadingDelay = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.SongPosition = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.osuRunningLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.Offset = new System.Windows.Forms.NumericUpDown();
			this.TourneyStateLabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.BPM = new System.Windows.Forms.Label();
			this.BPMcircle = new System.Windows.Forms.Label();
			this.PulseLabel = new System.Windows.Forms.Label();
			this.ChatLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ReadingDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Offset)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Product Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(396, 61);
			this.label1.TabIndex = 0;
			this.label1.Text = "osu!StateReader";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(390, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "20200130";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(40, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 21);
			this.label3.TabIndex = 2;
			this.label3.Text = "아티스트 - 제목";
			// 
			// SongProgress
			// 
			this.SongProgress.Location = new System.Drawing.Point(197, 153);
			this.SongProgress.Name = "SongProgress";
			this.SongProgress.Size = new System.Drawing.Size(241, 23);
			this.SongProgress.TabIndex = 3;
			// 
			// ArtistTitleOutput
			// 
			this.ArtistTitleOutput.Location = new System.Drawing.Point(71, 105);
			this.ArtistTitleOutput.Name = "ArtistTitleOutput";
			this.ArtistTitleOutput.Size = new System.Drawing.Size(367, 21);
			this.ArtistTitleOutput.TabIndex = 4;
			// 
			// ReadingDelay
			// 
			this.ReadingDelay.Location = new System.Drawing.Point(154, 226);
			this.ReadingDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.ReadingDelay.Name = "ReadingDelay";
			this.ReadingDelay.Size = new System.Drawing.Size(56, 21);
			this.ReadingDelay.TabIndex = 5;
			this.ReadingDelay.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(40, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 21);
			this.label4.TabIndex = 6;
			this.label4.Text = "곡 위치(ms)";
			// 
			// SongPosition
			// 
			this.SongPosition.Location = new System.Drawing.Point(71, 153);
			this.SongPosition.Name = "SongPosition";
			this.SongPosition.Size = new System.Drawing.Size(120, 21);
			this.SongPosition.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label5.Location = new System.Drawing.Point(41, 226);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "Update Delay (ms)";
			// 
			// osuRunningLabel
			// 
			this.osuRunningLabel.AutoSize = true;
			this.osuRunningLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.osuRunningLabel.ForeColor = System.Drawing.Color.Red;
			this.osuRunningLabel.Location = new System.Drawing.Point(41, 179);
			this.osuRunningLabel.Name = "osuRunningLabel";
			this.osuRunningLabel.Size = new System.Drawing.Size(138, 15);
			this.osuRunningLabel.TabIndex = 9;
			this.osuRunningLabel.Text = "osu! Process Not Found.";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label7.Location = new System.Drawing.Point(310, 226);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 15);
			this.label7.TabIndex = 10;
			this.label7.Text = "Offset (ms)";
			// 
			// Offset
			// 
			this.Offset.Location = new System.Drawing.Point(383, 226);
			this.Offset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.Offset.Name = "Offset";
			this.Offset.Size = new System.Drawing.Size(55, 21);
			this.Offset.TabIndex = 11;
			// 
			// TourneyStateLabel
			// 
			this.TourneyStateLabel.AutoSize = true;
			this.TourneyStateLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.TourneyStateLabel.ForeColor = System.Drawing.Color.Red;
			this.TourneyStateLabel.Location = new System.Drawing.Point(82, 198);
			this.TourneyStateLabel.Name = "TourneyStateLabel";
			this.TourneyStateLabel.Size = new System.Drawing.Size(77, 15);
			this.TourneyStateLabel.TabIndex = 12;
			this.TourneyStateLabel.Text = "TourneyState";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Product Sans", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(238, 179);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(84, 41);
			this.label6.TabIndex = 13;
			this.label6.Text = "BPM";
			// 
			// BPM
			// 
			this.BPM.AutoSize = true;
			this.BPM.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BPM.Font = new System.Drawing.Font("Product Sans", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BPM.Location = new System.Drawing.Point(328, 179);
			this.BPM.Name = "BPM";
			this.BPM.Size = new System.Drawing.Size(39, 41);
			this.BPM.TabIndex = 14;
			this.BPM.Text = "0";
			// 
			// BPMcircle
			// 
			this.BPMcircle.AutoSize = true;
			this.BPMcircle.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.BPMcircle.Location = new System.Drawing.Point(390, 180);
			this.BPMcircle.Name = "BPMcircle";
			this.BPMcircle.Size = new System.Drawing.Size(48, 32);
			this.BPMcircle.TabIndex = 15;
			this.BPMcircle.Text = "🔴";
			// 
			// PulseLabel
			// 
			this.PulseLabel.AutoSize = true;
			this.PulseLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.PulseLabel.ForeColor = System.Drawing.Color.Red;
			this.PulseLabel.Location = new System.Drawing.Point(41, 198);
			this.PulseLabel.Name = "PulseLabel";
			this.PulseLabel.Size = new System.Drawing.Size(35, 15);
			this.PulseLabel.TabIndex = 16;
			this.PulseLabel.Text = "Pulse";
			// 
			// ChatLabel
			// 
			this.ChatLabel.AutoSize = true;
			this.ChatLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.ChatLabel.ForeColor = System.Drawing.Color.Red;
			this.ChatLabel.Location = new System.Drawing.Point(165, 198);
			this.ChatLabel.Name = "ChatLabel";
			this.ChatLabel.Size = new System.Drawing.Size(32, 15);
			this.ChatLabel.TabIndex = 17;
			this.ChatLabel.Text = "Chat";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 271);
			this.Controls.Add(this.ChatLabel);
			this.Controls.Add(this.PulseLabel);
			this.Controls.Add(this.BPMcircle);
			this.Controls.Add(this.BPM);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.TourneyStateLabel);
			this.Controls.Add(this.Offset);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.osuRunningLabel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.SongPosition);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ReadingDelay);
			this.Controls.Add(this.ArtistTitleOutput);
			this.Controls.Add(this.SongProgress);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(490, 310);
			this.MinimumSize = new System.Drawing.Size(490, 310);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "OFCT StreamInfoProvider";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.ReadingDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Offset)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar SongProgress;
        private System.Windows.Forms.TextBox ArtistTitleOutput;
        private System.Windows.Forms.NumericUpDown ReadingDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SongPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label osuRunningLabel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown Offset;
		private System.Windows.Forms.Label TourneyStateLabel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label BPM;
		private System.Windows.Forms.Label BPMcircle;
		private System.Windows.Forms.Label PulseLabel;
		private System.Windows.Forms.Label ChatLabel;
	}
}

