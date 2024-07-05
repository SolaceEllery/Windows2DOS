namespace windows2msdos
{
    partial class Window_MainWindow
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
            Button_MainMenuConvertPaths = new Button();
            Label_WelcomeText = new Label();
            Label_WelcomeInformation1 = new Label();
            Label_WelcomeInformation2 = new Label();
            Button_MainMenuAboutThisProgram = new Button();
            SuspendLayout();
            // 
            // Button_MainMenuConvertPaths
            // 
            Button_MainMenuConvertPaths.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button_MainMenuConvertPaths.Location = new Point(572, 12);
            Button_MainMenuConvertPaths.Name = "Button_MainMenuConvertPaths";
            Button_MainMenuConvertPaths.Size = new Size(216, 40);
            Button_MainMenuConvertPaths.TabIndex = 0;
            Button_MainMenuConvertPaths.Text = "Path Converter";
            Button_MainMenuConvertPaths.UseVisualStyleBackColor = true;
            Button_MainMenuConvertPaths.Click += Button_MainMenuConvertPaths_Click;
            // 
            // Label_WelcomeText
            // 
            Label_WelcomeText.AutoSize = true;
            Label_WelcomeText.Font = new Font("Spencer Everly Font V3", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label_WelcomeText.Location = new Point(12, 9);
            Label_WelcomeText.Name = "Label_WelcomeText";
            Label_WelcomeText.Size = new Size(436, 39);
            Label_WelcomeText.TabIndex = 1;
            Label_WelcomeText.Text = "Welcome to Windows2DOS.";
            // 
            // Label_WelcomeInformation1
            // 
            Label_WelcomeInformation1.AutoSize = true;
            Label_WelcomeInformation1.Font = new Font("Spencer Everly Font V3", 12F);
            Label_WelcomeInformation1.Location = new Point(12, 61);
            Label_WelcomeInformation1.Name = "Label_WelcomeInformation1";
            Label_WelcomeInformation1.Size = new Size(464, 20);
            Label_WelcomeInformation1.TabIndex = 2;
            Label_WelcomeInformation1.Text = "This is a conversion tool for many things Windows + DOS related.";
            // 
            // Label_WelcomeInformation2
            // 
            Label_WelcomeInformation2.AutoSize = true;
            Label_WelcomeInformation2.Font = new Font("Spencer Everly Font V3", 12F);
            Label_WelcomeInformation2.Location = new Point(12, 89);
            Label_WelcomeInformation2.Name = "Label_WelcomeInformation2";
            Label_WelcomeInformation2.Size = new Size(449, 20);
            Label_WelcomeInformation2.TabIndex = 3;
            Label_WelcomeInformation2.Text = "Please select any of our tools on the right in order to use them!";
            // 
            // Button_MainMenuAboutThisProgram
            // 
            Button_MainMenuAboutThisProgram.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Button_MainMenuAboutThisProgram.Location = new Point(12, 250);
            Button_MainMenuAboutThisProgram.Name = "Button_MainMenuAboutThisProgram";
            Button_MainMenuAboutThisProgram.Size = new Size(188, 57);
            Button_MainMenuAboutThisProgram.TabIndex = 4;
            Button_MainMenuAboutThisProgram.Text = "About This Program";
            Button_MainMenuAboutThisProgram.UseVisualStyleBackColor = true;
            Button_MainMenuAboutThisProgram.Click += Button_MainMenuAboutThisProgram_Click;
            // 
            // Window_MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 319);
            Controls.Add(Button_MainMenuAboutThisProgram);
            Controls.Add(Label_WelcomeInformation2);
            Controls.Add(Label_WelcomeInformation1);
            Controls.Add(Label_WelcomeText);
            Controls.Add(Button_MainMenuConvertPaths);
            Name = "Window_MainWindow";
            Text = "Windows/MS-DOS Conversion Tools";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button_MainMenuConvertPaths;
        private Label Label_WelcomeText;
        private Label Label_WelcomeInformation1;
        private Label Label_WelcomeInformation2;
        private Button Button_MainMenuAboutThisProgram;
    }
}