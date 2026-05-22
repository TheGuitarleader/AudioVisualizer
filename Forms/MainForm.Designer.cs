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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            frequencyPlot = new ScottPlot.WinForms.FormsPlot();
            levelsPlot = new ScottPlot.WinForms.FormsPlot();
            loopTimer = new System.Windows.Forms.Timer(components);
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            audioDeviceTsCB = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            addTsBtn = new ToolStripButton();
            removeTsBtn = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toneGenTsBtn = new ToolStripButton();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(frequencyPlot, 0, 1);
            tableLayoutPanel1.Controls.Add(levelsPlot, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 36);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1102, 576);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // frequencyPlot
            // 
            frequencyPlot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            frequencyPlot.DisplayScale = 1F;
            frequencyPlot.Location = new Point(3, 291);
            frequencyPlot.Name = "frequencyPlot";
            frequencyPlot.Size = new Size(1096, 282);
            frequencyPlot.TabIndex = 1;
            // 
            // levelsPlot
            // 
            levelsPlot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            levelsPlot.DisplayScale = 1F;
            levelsPlot.Location = new Point(3, 3);
            levelsPlot.Name = "levelsPlot";
            levelsPlot.Size = new Size(1096, 282);
            levelsPlot.TabIndex = 0;
            // 
            // loopTimer
            // 
            loopTimer.Interval = 1;
            loopTimer.Tick += loopTimer_Tick;
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, audioDeviceTsCB, toolStripSeparator1, addTsBtn, removeTsBtn, toolStripSeparator2, toneGenTsBtn });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1126, 33);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(77, 30);
            toolStripLabel1.Text = "Audio Device";
            // 
            // audioDeviceTsCB
            // 
            audioDeviceTsCB.AutoSize = false;
            audioDeviceTsCB.DropDownStyle = ComboBoxStyle.DropDownList;
            audioDeviceTsCB.Name = "audioDeviceTsCB";
            audioDeviceTsCB.Size = new Size(300, 23);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 33);
            // 
            // addTsBtn
            // 
            addTsBtn.Image = (Image)resources.GetObject("addTsBtn.Image");
            addTsBtn.ImageTransparentColor = Color.Magenta;
            addTsBtn.Name = "addTsBtn";
            addTsBtn.Size = new Size(49, 30);
            addTsBtn.Text = "Add";
            addTsBtn.TextDirection = ToolStripTextDirection.Horizontal;
            addTsBtn.Click += addTsBtn_Click;
            // 
            // removeTsBtn
            // 
            removeTsBtn.Image = (Image)resources.GetObject("removeTsBtn.Image");
            removeTsBtn.ImageTransparentColor = Color.Magenta;
            removeTsBtn.Name = "removeTsBtn";
            removeTsBtn.Size = new Size(60, 30);
            removeTsBtn.Text = "Delete";
            removeTsBtn.Click += removeTsBtn_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 33);
            // 
            // toneGenTsBtn
            // 
            toneGenTsBtn.Image = (Image)resources.GetObject("toneGenTsBtn.Image");
            toneGenTsBtn.ImageTransparentColor = Color.Magenta;
            toneGenTsBtn.Name = "toneGenTsBtn";
            toneGenTsBtn.Size = new Size(108, 30);
            toneGenTsBtn.Text = "Tone Generator";
            toneGenTsBtn.Click += toneGenTsBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 624);
            Controls.Add(toolStrip1);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Audio Visualizer";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.WinForms.FormsPlot frequencyPlot;
        private ScottPlot.WinForms.FormsPlot levelsPlot;
        private System.Windows.Forms.Timer loopTimer;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox audioDeviceTsCB;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton addTsBtn;
        private ToolStripButton removeTsBtn;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toneGenTsBtn;
    }
}
