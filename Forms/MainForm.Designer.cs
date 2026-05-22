namespace AudioVisualizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            audioDeviceCB = new ComboBox();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            frequencyPlot = new ScottPlot.WinForms.FormsPlot();
            levelsPlot = new ScottPlot.WinForms.FormsPlot();
            frequencyLabel = new Label();
            loopTimer = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // audioDeviceCB
            // 
            audioDeviceCB.DropDownStyle = ComboBoxStyle.DropDownList;
            audioDeviceCB.FormattingEnabled = true;
            audioDeviceCB.Location = new Point(98, 12);
            audioDeviceCB.Name = "audioDeviceCB";
            audioDeviceCB.Size = new Size(246, 23);
            audioDeviceCB.TabIndex = 1;
            audioDeviceCB.SelectedIndexChanged += audioDeviceCB_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 2;
            label1.Text = "Audio Device:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(frequencyPlot, 0, 1);
            tableLayoutPanel1.Controls.Add(levelsPlot, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 41);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1102, 571);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // frequencyPlot
            // 
            frequencyPlot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            frequencyPlot.DisplayScale = 1F;
            frequencyPlot.Location = new Point(3, 288);
            frequencyPlot.Name = "frequencyPlot";
            frequencyPlot.Size = new Size(1096, 280);
            frequencyPlot.TabIndex = 1;
            // 
            // levelsPlot
            // 
            levelsPlot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            levelsPlot.DisplayScale = 1F;
            levelsPlot.Location = new Point(3, 3);
            levelsPlot.Name = "levelsPlot";
            levelsPlot.Size = new Size(1096, 279);
            levelsPlot.TabIndex = 0;
            // 
            // frequencyLabel
            // 
            frequencyLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            frequencyLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            frequencyLabel.Location = new Point(1014, 12);
            frequencyLabel.Name = "frequencyLabel";
            frequencyLabel.Size = new Size(100, 23);
            frequencyLabel.TabIndex = 4;
            frequencyLabel.Text = "00.00 Hz";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 624);
            Controls.Add(frequencyLabel);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(audioDeviceCB);
            Name = "MainForm";
            Text = "Audio Visualizer";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox audioDeviceCB;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.WinForms.FormsPlot frequencyPlot;
        private ScottPlot.WinForms.FormsPlot levelsPlot;
        private Label frequencyLabel;
        private System.Windows.Forms.Timer loopTimer;
    }
}
