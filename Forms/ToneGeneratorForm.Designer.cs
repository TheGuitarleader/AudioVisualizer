namespace AudioVisualizer.Forms
{
    partial class ToneGeneratorForm
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
            toneBar = new TrackBar();
            hzLabel = new Label();
            playBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)toneBar).BeginInit();
            SuspendLayout();
            // 
            // toneBar
            // 
            toneBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            toneBar.LargeChange = 100;
            toneBar.Location = new Point(12, 12);
            toneBar.Maximum = 22000;
            toneBar.Minimum = 20;
            toneBar.Name = "toneBar";
            toneBar.Size = new Size(440, 45);
            toneBar.SmallChange = 10;
            toneBar.TabIndex = 0;
            toneBar.TickFrequency = 1000;
            toneBar.TickStyle = TickStyle.Both;
            toneBar.Value = 500;
            toneBar.Scroll += toneBar_Scroll;
            toneBar.ValueChanged += toneBar_ValueChanged;
            // 
            // hzLabel
            // 
            hzLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hzLabel.Font = new Font("Segoe UI Semilight", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hzLabel.Location = new Point(12, 60);
            hzLabel.Name = "hzLabel";
            hzLabel.Size = new Size(440, 37);
            hzLabel.TabIndex = 2;
            hzLabel.Text = "0 Hz";
            hzLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // playBtn
            // 
            playBtn.Location = new Point(187, 123);
            playBtn.Name = "playBtn";
            playBtn.Size = new Size(90, 30);
            playBtn.TabIndex = 4;
            playBtn.Text = "Play";
            playBtn.UseVisualStyleBackColor = true;
            playBtn.Click += playBtn_Click;
            // 
            // ToneGeneratorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 165);
            Controls.Add(playBtn);
            Controls.Add(hzLabel);
            Controls.Add(toneBar);
            Name = "ToneGeneratorForm";
            Text = "ToneGenerator";
            ((System.ComponentModel.ISupportInitialize)toneBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar toneBar;
        private Label hzLabel;
        private Button playBtn;
    }
}