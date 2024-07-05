using windows2msdos_variables;

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
            Label_WelcomeInformation = new Label();
            Button_MainMenuAboutThisProgram = new Button();
            SuspendLayout();
            // 
            // Button_MainMenuConvertPaths
            // 
            Button_MainMenuConvertPaths.BackColor = Color.SeaShell;
            Button_MainMenuConvertPaths.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button_MainMenuConvertPaths.ForeColor = Color.Black;
            Button_MainMenuConvertPaths.Location = new Point(572, 12);
            Button_MainMenuConvertPaths.Name = "Button_MainMenuConvertPaths";
            Button_MainMenuConvertPaths.Size = new Size(216, 40);
            Button_MainMenuConvertPaths.TabIndex = 0;
            Button_MainMenuConvertPaths.Text = "Path Converter";
            Button_MainMenuConvertPaths.UseVisualStyleBackColor = false;
            Button_MainMenuConvertPaths.Click += Button_MainMenuConvertPaths_Click;
            // 
            // Label_WelcomeText
            // 
            Label_WelcomeText.AutoSize = true;
            Label_WelcomeText.BackColor = Color.Transparent;
            Label_WelcomeText.Font = new Font("Spencer Everly Font V3", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label_WelcomeText.ForeColor = Color.Black;
            Label_WelcomeText.Location = new Point(12, 9);
            Label_WelcomeText.Name = "Label_WelcomeText";
            Label_WelcomeText.Size = new Size(436, 39);
            Label_WelcomeText.TabIndex = 1;
            Label_WelcomeText.Text = "Welcome to Windows2DOS.";
            // 
            // Label_WelcomeInformation
            // 
            Label_WelcomeInformation.AutoSize = true;
            Label_WelcomeInformation.BackColor = Color.Transparent;
            Label_WelcomeInformation.Font = new Font("Spencer Everly Font V3", 12F);
            Label_WelcomeInformation.ForeColor = Color.Black;
            Label_WelcomeInformation.Location = new Point(12, 61);
            Label_WelcomeInformation.Name = "Label_WelcomeInformation";
            Label_WelcomeInformation.Size = new Size(464, 40);
            Label_WelcomeInformation.TabIndex = 2;
            Label_WelcomeInformation.Text = "This is a conversion tool for many things Windows + DOS related.\r\nPlease select any of our tools on the right in order to use them!";
            // 
            // Button_MainMenuAboutThisProgram
            // 
            Button_MainMenuAboutThisProgram.BackColor = Color.SeaShell;
            Button_MainMenuAboutThisProgram.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Button_MainMenuAboutThisProgram.ForeColor = Color.Black;
            Button_MainMenuAboutThisProgram.Location = new Point(12, 250);
            Button_MainMenuAboutThisProgram.Name = "Button_MainMenuAboutThisProgram";
            Button_MainMenuAboutThisProgram.Size = new Size(188, 57);
            Button_MainMenuAboutThisProgram.TabIndex = 4;
            Button_MainMenuAboutThisProgram.Text = "About This Program";
            Button_MainMenuAboutThisProgram.UseVisualStyleBackColor = false;
            Button_MainMenuAboutThisProgram.Click += Button_MainMenuAboutThisProgram_Click;
            // 
            // Window_MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 319);
            Controls.Add(Button_MainMenuAboutThisProgram);
            Controls.Add(Label_WelcomeInformation);
            Controls.Add(Label_WelcomeText);
            Controls.Add(Button_MainMenuConvertPaths);
            Name = "Window_MainWindow";
            Text = "Windows/MS-DOS Conversion Tools";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button Button_MainMenuConvertPaths;
        public Label Label_WelcomeText;
        public Label Label_WelcomeInformation;
        public Button Button_MainMenuAboutThisProgram;

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
                Label_WelcomeText.ForeColor = Color.White;
                Label_WelcomeInformation.ForeColor = Color.White;

                // Change button colors to fit the dark mode setting
                Button_MainMenuConvertPaths.ForeColor = Color.White;
                Button_MainMenuConvertPaths.BackColor = Color.DarkRed;
                
                Button_MainMenuAboutThisProgram.ForeColor = Color.White;
                Button_MainMenuAboutThisProgram.BackColor = Color.DarkRed;
            }
        }
    }
}