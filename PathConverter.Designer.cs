using windows2msdos_variables;

namespace windows2msdos
{
    partial class Window_PathConverter
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
        // Required method for Designer support - do not modify the contents of this method with the code editor.

        private void InitializeComponent()
        {
            Label_WindowsPathText = new Label();
            Label_DOSPathText = new Label();
            Button_SelectFile = new Button();
            Button_SelectFolder = new Button();
            Button_ResetPaths = new Button();
            Label_PathConversionIndicator = new Label();
            TextBox_WindowsPath = new RichTextBox();
            TextBox_DOSPath = new RichTextBox();
            CheckBox_SwitchConverter = new CheckBox();
            Label_PathConversionOpenText = new Label();
            SuspendLayout();
            // 
            // Label_WindowsPathText
            // 
            Label_WindowsPathText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Label_WindowsPathText.AutoSize = true;
            Label_WindowsPathText.BackColor = Color.Transparent;
            Label_WindowsPathText.Location = new Point(18, 32);
            Label_WindowsPathText.Margin = new Padding(0);
            Label_WindowsPathText.Name = "Label_WindowsPathText";
            Label_WindowsPathText.Size = new Size(20, 15);
            Label_WindowsPathText.TabIndex = 2;
            Label_WindowsPathText.Text = "In:";
            // 
            // Label_DOSPathText
            // 
            Label_DOSPathText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Label_DOSPathText.AutoSize = true;
            Label_DOSPathText.BackColor = Color.Transparent;
            Label_DOSPathText.Location = new Point(13, 92);
            Label_DOSPathText.Margin = new Padding(0);
            Label_DOSPathText.Name = "Label_DOSPathText";
            Label_DOSPathText.Size = new Size(30, 15);
            Label_DOSPathText.TabIndex = 3;
            Label_DOSPathText.Text = "Out:";
            // 
            // Button_SelectFile
            // 
            Button_SelectFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button_SelectFile.AutoSize = true;
            Button_SelectFile.BackColor = Color.SeaShell;
            Button_SelectFile.Location = new Point(687, 56);
            Button_SelectFile.Margin = new Padding(0);
            Button_SelectFile.Name = "Button_SelectFile";
            Button_SelectFile.Size = new Size(53, 34);
            Button_SelectFile.TabIndex = 4;
            Button_SelectFile.Text = "File";
            Button_SelectFile.UseVisualStyleBackColor = false;
            Button_SelectFile.Click += Button_SelectFile_Click;
            // 
            // Button_SelectFolder
            // 
            Button_SelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button_SelectFolder.AutoSize = true;
            Button_SelectFolder.BackColor = Color.SeaShell;
            Button_SelectFolder.Location = new Point(743, 56);
            Button_SelectFolder.Margin = new Padding(0);
            Button_SelectFolder.Name = "Button_SelectFolder";
            Button_SelectFolder.Size = new Size(53, 34);
            Button_SelectFolder.TabIndex = 5;
            Button_SelectFolder.Text = "Folder";
            Button_SelectFolder.UseVisualStyleBackColor = false;
            Button_SelectFolder.Click += Button_SelectFolder_Click;
            // 
            // Button_ResetPaths
            // 
            Button_ResetPaths.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button_ResetPaths.AutoSize = true;
            Button_ResetPaths.BackColor = Color.SeaShell;
            Button_ResetPaths.ForeColor = SystemColors.Desktop;
            Button_ResetPaths.Location = new Point(687, 140);
            Button_ResetPaths.Margin = new Padding(0);
            Button_ResetPaths.Name = "Button_ResetPaths";
            Button_ResetPaths.Size = new Size(109, 34);
            Button_ResetPaths.TabIndex = 6;
            Button_ResetPaths.Text = "Reset";
            Button_ResetPaths.UseVisualStyleBackColor = false;
            Button_ResetPaths.Click += Button_ResetPaths_Click;
            // 
            // Label_PathConversionIndicator
            // 
            Label_PathConversionIndicator.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Label_PathConversionIndicator.AutoSize = true;
            Label_PathConversionIndicator.BackColor = Color.Transparent;
            Label_PathConversionIndicator.Font = new Font("Segoe UI", 7F);
            Label_PathConversionIndicator.ForeColor = Color.Black;
            Label_PathConversionIndicator.Location = new Point(12, 162);
            Label_PathConversionIndicator.Margin = new Padding(0);
            Label_PathConversionIndicator.Name = "Label_PathConversionIndicator";
            Label_PathConversionIndicator.Size = new Size(153, 12);
            Label_PathConversionIndicator.TabIndex = 7;
            Label_PathConversionIndicator.Text = "Converting: Windows -> MS-DOS";
            // 
            // TextBox_WindowsPath
            // 
            TextBox_WindowsPath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_WindowsPath.BackColor = Color.White;
            TextBox_WindowsPath.DetectUrls = false;
            TextBox_WindowsPath.Location = new Point(52, 15);
            TextBox_WindowsPath.Name = "TextBox_WindowsPath";
            TextBox_WindowsPath.ScrollBars = RichTextBoxScrollBars.Vertical;
            TextBox_WindowsPath.Size = new Size(630, 51);
            TextBox_WindowsPath.TabIndex = 8;
            TextBox_WindowsPath.Text = "";
            TextBox_WindowsPath.TextChanged += TextBox_WindowsPath_TextChanged;
            // 
            // TextBox_DOSPath
            // 
            TextBox_DOSPath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_DOSPath.BackColor = Color.White;
            TextBox_DOSPath.DetectUrls = false;
            TextBox_DOSPath.Location = new Point(52, 75);
            TextBox_DOSPath.Name = "TextBox_DOSPath";
            TextBox_DOSPath.ReadOnly = true;
            TextBox_DOSPath.ScrollBars = RichTextBoxScrollBars.Vertical;
            TextBox_DOSPath.Size = new Size(630, 51);
            TextBox_DOSPath.TabIndex = 9;
            TextBox_DOSPath.Text = "";
            // 
            // CheckBox_SwitchConverter
            // 
            CheckBox_SwitchConverter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CheckBox_SwitchConverter.AutoSize = true;
            CheckBox_SwitchConverter.BackColor = Color.Transparent;
            CheckBox_SwitchConverter.ForeColor = Color.Black;
            CheckBox_SwitchConverter.Location = new Point(12, 140);
            CheckBox_SwitchConverter.MinimumSize = new Size(153, 20);
            CheckBox_SwitchConverter.Name = "CheckBox_SwitchConverter";
            CheckBox_SwitchConverter.Size = new Size(153, 20);
            CheckBox_SwitchConverter.TabIndex = 10;
            CheckBox_SwitchConverter.Text = "Switch Conversion Type";
            CheckBox_SwitchConverter.UseVisualStyleBackColor = false;
            CheckBox_SwitchConverter.CheckedChanged += CheckBox_SwitchConverter_CheckedChanged;
            // 
            // Label_PathConversionOpenText
            // 
            Label_PathConversionOpenText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Label_PathConversionOpenText.AutoSize = true;
            Label_PathConversionOpenText.BackColor = Color.Transparent;
            Label_PathConversionOpenText.Enabled = false;
            Label_PathConversionOpenText.Font = new Font("Segoe UI", 7F);
            Label_PathConversionOpenText.ForeColor = Color.Black;
            Label_PathConversionOpenText.Location = new Point(691, 40);
            Label_PathConversionOpenText.Margin = new Padding(0);
            Label_PathConversionOpenText.Name = "Label_PathConversionOpenText";
            Label_PathConversionOpenText.Size = new Size(101, 12);
            Label_PathConversionOpenText.TabIndex = 11;
            Label_PathConversionOpenText.Text = "Open For Conversion:";
            Label_PathConversionOpenText.UseMnemonic = false;
            // 
            // Window_PathConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(804, 182);
            Controls.Add(Label_PathConversionOpenText);
            Controls.Add(CheckBox_SwitchConverter);
            Controls.Add(TextBox_DOSPath);
            Controls.Add(TextBox_WindowsPath);
            Controls.Add(Label_PathConversionIndicator);
            Controls.Add(Button_ResetPaths);
            Controls.Add(Button_SelectFolder);
            Controls.Add(Button_SelectFile);
            Controls.Add(Label_DOSPathText);
            Controls.Add(Label_WindowsPathText);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Window_PathConverter";
            Text = "Windows/MS-DOS Conversion Tools: Path Converter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label Label_WindowsPathText;
        public Label Label_DOSPathText;
        public Button Button_SelectFile;
        public Button Button_SelectFolder;
        public Button Button_ResetPaths;
        public Label Label_PathConversionIndicator;
        public RichTextBox TextBox_WindowsPath;
        public RichTextBox TextBox_DOSPath;
        public CheckBox CheckBox_SwitchConverter;
        public Label Label_PathConversionOpenText;

        private void ChangeWindowColors()
        {
            // Get the variables for the entire program
            var variables = new Variables();

            // If Windows is in dark mode, apply the dark window colors
            if (variables.AllWindows_Booleans_DarkMode)
            {
                // Change the window background color to black
                BackColor = Color.Black;

                // Change all text label colors from black to white
                Label_WindowsPathText.ForeColor = Color.White;
                Label_DOSPathText.ForeColor = Color.White;

                Label_PathConversionOpenText.ForeColor = Color.White;
                Label_PathConversionIndicator.ForeColor = Color.White;

                // Change button colors to fit the dark mode setting
                Button_SelectFile.ForeColor = Color.White;
                Button_SelectFile.BackColor = Color.DarkRed;

                Button_SelectFolder.ForeColor = Color.White;
                Button_SelectFolder.BackColor = Color.DarkRed;

                Button_ResetPaths.ForeColor = Color.White;
                Button_ResetPaths.BackColor = Color.DarkRed;

                // Change all check box text colors from black to white
                CheckBox_SwitchConverter.ForeColor = Color.White;

                // Change all text box from black to white
                TextBox_WindowsPath.BackColor = Color.White;
                TextBox_DOSPath.BackColor = Color.White;
            }
        }
    }
}