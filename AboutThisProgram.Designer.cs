using windows2msdos_functions;
using windows2msdos_variables;

namespace windows2msdos
{
    partial class Window_AboutThisProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window_AboutThisProgram));
            PictureBox_Windows2DOSLogo = new PictureBox();
            Label_AboutThisProgram_ProgramName = new Label();
            Label_AboutThisProgram_VersionNumber = new Label();
            Label_AboutThisProgram_OpenSourceInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBox_Windows2DOSLogo).BeginInit();
            SuspendLayout();
            // 
            // PictureBox_Windows2DOSLogo
            // 
            PictureBox_Windows2DOSLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PictureBox_Windows2DOSLogo.BackColor = Color.Transparent;
            PictureBox_Windows2DOSLogo.Cursor = Cursors.Help;
            PictureBox_Windows2DOSLogo.Image = (Image)resources.GetObject("PictureBox_Windows2DOSLogo.Image");
            PictureBox_Windows2DOSLogo.ImageLocation = "";
            PictureBox_Windows2DOSLogo.Location = new Point(120, 12);
            PictureBox_Windows2DOSLogo.Margin = new Padding(0);
            PictureBox_Windows2DOSLogo.MinimumSize = new Size(90, 96);
            PictureBox_Windows2DOSLogo.Name = "PictureBox_Windows2DOSLogo";
            PictureBox_Windows2DOSLogo.Size = new Size(90, 96);
            PictureBox_Windows2DOSLogo.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox_Windows2DOSLogo.TabIndex = 1;
            PictureBox_Windows2DOSLogo.TabStop = false;
            PictureBox_Windows2DOSLogo.Click += PictureBox_Windows2DOSLogo_Click;
            // 
            // Label_AboutThisProgram_ProgramName
            // 
            Label_AboutThisProgram_ProgramName.AutoSize = true;
            Label_AboutThisProgram_ProgramName.BackColor = Color.Transparent;
            Label_AboutThisProgram_ProgramName.Font = new Font("Spencer Everly Font V3", 14F);
            Label_AboutThisProgram_ProgramName.Location = new Point(4, 111);
            Label_AboutThisProgram_ProgramName.Name = "Label_AboutThisProgram_ProgramName";
            Label_AboutThisProgram_ProgramName.Size = new Size(322, 23);
            Label_AboutThisProgram_ProgramName.TabIndex = 2;
            Label_AboutThisProgram_ProgramName.Text = "Windows2DOS by Spencerly D. Everly";
            // 
            // Label_AboutThisProgram_VersionNumber
            // 
            Label_AboutThisProgram_VersionNumber.AutoSize = true;
            Label_AboutThisProgram_VersionNumber.BackColor = Color.Transparent;
            Label_AboutThisProgram_VersionNumber.Font = new Font("Spencer Everly Font V3", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label_AboutThisProgram_VersionNumber.Location = new Point(113, 135);
            Label_AboutThisProgram_VersionNumber.Name = "Label_AboutThisProgram_VersionNumber";
            Label_AboutThisProgram_VersionNumber.Size = new Size(114, 16);
            Label_AboutThisProgram_VersionNumber.TabIndex = 3;
            Label_AboutThisProgram_VersionNumber.Text = "v0.1.0 (Beta 1)";
            // 
            // Label_AboutThisProgram_OpenSourceInfo
            // 
            Label_AboutThisProgram_OpenSourceInfo.AutoSize = true;
            Label_AboutThisProgram_OpenSourceInfo.BackColor = Color.Transparent;
            Label_AboutThisProgram_OpenSourceInfo.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label_AboutThisProgram_OpenSourceInfo.Location = new Point(42, 156);
            Label_AboutThisProgram_OpenSourceInfo.Name = "Label_AboutThisProgram_OpenSourceInfo";
            Label_AboutThisProgram_OpenSourceInfo.Size = new Size(257, 56);
            Label_AboutThisProgram_OpenSourceInfo.TabIndex = 4;
            Label_AboutThisProgram_OpenSourceInfo.Text = "This program is 100% open source with\r\nno license whatsoever. Anyone can do\r\nanything with this program outside the\r\nrepository as they wish.";
            Label_AboutThisProgram_OpenSourceInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // Window_AboutThisProgram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 221);
            Controls.Add(Label_AboutThisProgram_OpenSourceInfo);
            Controls.Add(Label_AboutThisProgram_VersionNumber);
            Controls.Add(Label_AboutThisProgram_ProgramName);
            Controls.Add(PictureBox_Windows2DOSLogo);
            Name = "Window_AboutThisProgram";
            Text = "About Windows2DOS";
            ((System.ComponentModel.ISupportInitialize)PictureBox_Windows2DOSLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public PictureBox PictureBox_Windows2DOSLogo;
        public Label Label_AboutThisProgram_ProgramName;
        public Label Label_AboutThisProgram_VersionNumber;
        public Label Label_AboutThisProgram_OpenSourceInfo;

        private void ChangeWindowColors()
        {
            // Get the variables for the entire program
            var variables = new Variables();

            // If Windows is in dark mode, apply the dark window colors
            if (variables.AllWindows_Booleans_DarkMode)
            {
                // Change the window background color to black
                BackColor = Color.Black;

                // Change all text colors that are black to white
                Label_AboutThisProgram_ProgramName.ForeColor = Color.White;
                Label_AboutThisProgram_VersionNumber.ForeColor = Color.White;
                Label_AboutThisProgram_OpenSourceInfo.ForeColor = Color.White;
            }
        }
    }
}