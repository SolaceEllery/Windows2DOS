using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using windows2msdos_functions;
using windows2msdos_variables;

// Prevent warnings about unused parameters being used, as well as prevent unnecessary suppression warnings
#pragma warning disable IDE0079
#pragma warning disable IDE0060

namespace windows2msdos
{
    public partial class Window_MainWindow : Form
    {
        public Window_MainWindow()
        {
            // Get the variables
            var variables = new Variables();

            // Initalize the window component
            InitializeComponent();

            // Change the window colors if dark mode is enabled
            ChangeWindowColors();

            // Put together all text instances
            Text = variables.MainWindow_Strings_WindowTitle;

            Label_WelcomeText.Text = variables.MainWindow_Strings_WelcomeText;
            Label_WelcomeInformation.Text = variables.MainWindow_Strings_WelcomeInformation;

            Button_MainMenuConvertPaths.Text = variables.MainWindows_Strings_Buttons_PathConverter;
            Button_MainMenuAboutThisProgram.Text = variables.MainWindows_Strings_Buttons_AboutThisProgram;
        }

        private void Button_MainMenuConvertPaths_Click(object sender, EventArgs e)
        {
            var NewWindowVar = new Window_PathConverter();
            NewWindowVar.ShowDialog();
        }

        private void Button_MainMenuAboutThisProgram_Click(object sender, EventArgs e)
        {
            var NewWindowVar = new Window_AboutThisProgram();
            NewWindowVar.ShowDialog();
        }

        private void Window_MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void Button_ExitProgram_Click(object sender, EventArgs e)
        {
            // Get the functions for the entire program
            var functions = new Functions();

            // Run the function to end the program
            functions.Windows2DOS_CloseProgram();
        }

        private void Button_MainMenuMinimize_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
