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
            Button_ConvertPaths = new Button();
            Label_PathConvertIndicator = new Label();
            TextBox_WindowsPath = new RichTextBox();
            TextBox_DOSPath = new RichTextBox();
            CheckBox_SwitchConverter = new CheckBox();
            Label_PathConversionOpenText = new Label();
            SuspendLayout();
            // 
            // Label_WindowsPathText
            // 
            Label_WindowsPathText.AutoSize = true;
            Label_WindowsPathText.Location = new Point(11, 18);
            Label_WindowsPathText.Margin = new Padding(0);
            Label_WindowsPathText.Name = "Label_WindowsPathText";
            Label_WindowsPathText.Size = new Size(86, 15);
            Label_WindowsPathText.TabIndex = 2;
            Label_WindowsPathText.Text = "Windows Path:";
            // 
            // Label_DOSPathText
            // 
            Label_DOSPathText.AutoSize = true;
            Label_DOSPathText.Location = new Point(13, 75);
            Label_DOSPathText.Margin = new Padding(0);
            Label_DOSPathText.Name = "Label_DOSPathText";
            Label_DOSPathText.Size = new Size(82, 15);
            Label_DOSPathText.TabIndex = 3;
            Label_DOSPathText.Text = "MS-DOS Path:";
            // 
            // Button_SelectFile
            // 
            Button_SelectFile.AutoSize = true;
            Button_SelectFile.Location = new Point(686, 32);
            Button_SelectFile.Margin = new Padding(0);
            Button_SelectFile.Name = "Button_SelectFile";
            Button_SelectFile.Size = new Size(54, 34);
            Button_SelectFile.TabIndex = 4;
            Button_SelectFile.Text = "File";
            Button_SelectFile.UseVisualStyleBackColor = true;
            Button_SelectFile.Click += Button_SelectFile_Click;
            // 
            // Button_SelectFolder
            // 
            Button_SelectFolder.AutoSize = true;
            Button_SelectFolder.Location = new Point(744, 32);
            Button_SelectFolder.Margin = new Padding(0);
            Button_SelectFolder.Name = "Button_SelectFolder";
            Button_SelectFolder.Size = new Size(54, 34);
            Button_SelectFolder.TabIndex = 5;
            Button_SelectFolder.Text = "Folder";
            Button_SelectFolder.UseVisualStyleBackColor = true;
            Button_SelectFolder.Click += Button_SelectFolder_Click;
            // 
            // Button_ConvertPaths
            // 
            Button_ConvertPaths.AutoSize = true;
            Button_ConvertPaths.ForeColor = SystemColors.Desktop;
            Button_ConvertPaths.Location = new Point(656, 137);
            Button_ConvertPaths.Margin = new Padding(0);
            Button_ConvertPaths.Name = "Button_ConvertPaths";
            Button_ConvertPaths.Size = new Size(138, 34);
            Button_ConvertPaths.TabIndex = 7;
            Button_ConvertPaths.Text = "Convert";
            Button_ConvertPaths.UseVisualStyleBackColor = true;
            // 
            // Label_PathConvertIndicator
            // 
            Label_PathConvertIndicator.AutoSize = true;
            Label_PathConvertIndicator.Font = new Font("Segoe MDL2 Assets", 9F);
            Label_PathConvertIndicator.ForeColor = Color.Black;
            Label_PathConvertIndicator.Location = new Point(11, 159);
            Label_PathConvertIndicator.Margin = new Padding(0);
            Label_PathConvertIndicator.Name = "Label_PathConvertIndicator";
            Label_PathConvertIndicator.Size = new Size(192, 12);
            Label_PathConvertIndicator.TabIndex = 10;
            Label_PathConvertIndicator.Text = "Converting: Windows Path -> MS-DOS Path";
            // 
            // TextBox_WindowsPath
            // 
            TextBox_WindowsPath.Location = new Point(100, 15);
            TextBox_WindowsPath.Name = "TextBox_WindowsPath";
            TextBox_WindowsPath.Size = new Size(582, 51);
            TextBox_WindowsPath.TabIndex = 11;
            TextBox_WindowsPath.Text = "";
            TextBox_WindowsPath.TextChanged += TextBox_WindowsPath_TextChanged;
            // 
            // TextBox_DOSPath
            // 
            TextBox_DOSPath.Location = new Point(100, 75);
            TextBox_DOSPath.Name = "TextBox_DOSPath";
            TextBox_DOSPath.Size = new Size(582, 51);
            TextBox_DOSPath.TabIndex = 12;
            TextBox_DOSPath.Text = "";
            TextBox_DOSPath.TextChanged += TextBox_DOSPath_TextChanged;
            // 
            // CheckBox_SwitchConverter
            // 
            CheckBox_SwitchConverter.AutoSize = true;
            CheckBox_SwitchConverter.Location = new Point(12, 140);
            CheckBox_SwitchConverter.Name = "CheckBox_SwitchConverter";
            CheckBox_SwitchConverter.Size = new Size(124, 19);
            CheckBox_SwitchConverter.TabIndex = 13;
            CheckBox_SwitchConverter.Text = "Switch Conversion";
            CheckBox_SwitchConverter.UseVisualStyleBackColor = true;
            CheckBox_SwitchConverter.CheckedChanged += CheckBox_SwitchConverter_CheckedChanged;
            // 
            // Label_PathConversionOpenText
            // 
            Label_PathConversionOpenText.AutoSize = true;
            Label_PathConversionOpenText.Enabled = false;
            Label_PathConversionOpenText.Font = new Font("Segoe MDL2 Assets", 9F);
            Label_PathConversionOpenText.ForeColor = Color.Black;
            Label_PathConversionOpenText.Location = new Point(693, 16);
            Label_PathConversionOpenText.Margin = new Padding(0);
            Label_PathConversionOpenText.Name = "Label_PathConversionOpenText";
            Label_PathConversionOpenText.Size = new Size(98, 12);
            Label_PathConversionOpenText.TabIndex = 14;
            Label_PathConversionOpenText.Text = "Open For Conversion:";
            Label_PathConversionOpenText.UseMnemonic = false;
            // 
            // Window_PathConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 182);
            Controls.Add(Label_PathConversionOpenText);
            Controls.Add(CheckBox_SwitchConverter);
            Controls.Add(TextBox_DOSPath);
            Controls.Add(TextBox_WindowsPath);
            Controls.Add(Label_PathConvertIndicator);
            Controls.Add(Button_ConvertPaths);
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
        private Label Label_WindowsPathText;
        private Label Label_DOSPathText;
        private Button Button_SelectFile;
        private Button Button_SelectFolder;
        private Button Button_ConvertPaths;
        private Label Label_PathConvertIndicator;
        private RichTextBox TextBox_WindowsPath;
        private RichTextBox TextBox_DOSPath;
        private CheckBox CheckBox_SwitchConverter;
        private Label Label_PathConversionOpenText;
    }
}