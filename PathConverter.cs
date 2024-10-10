/*

    -- Windows2DOS --
    By SpencerlyEverly

    Convert paths, and other things to formats MS-DOS can understand, and back to Windows

*/

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Forms;

using Windows;

using Microsoft.Win32;
using windows2msdos;

// Prevents warnings about typing up commas if an array will have more values later on
#pragma warning disable IDE0079
#pragma warning disable IDE0059
// Prevents warnings about MarshalAs within not specifying P/Invoke arguments
#pragma warning disable CA2101

namespace windows2msdos
{
    using windows2msdos_functions;
    using windows2msdos_variables;

    public partial class Window_PathConverter : Form
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
        static extern bool SetDllDirectory(string lpPathName);

        public Window_PathConverter()
        {
            // Get the variables
            var variables = new Variables();

            // Initalize the window component
            InitializeComponent();

            // Change the window colors if dark mode is enabled
            ChangeWindowColors();

            // Put together all text instances
            Text = variables.PathWindow_Strings_WindowText;
        }

        private void Button_SelectFile_Click(object sender, EventArgs e)
        {
            // Get the functions & variables
            var functions = new Functions();
            var variables = new Variables();

            // Open the dialog and retrieve a string of the filepath
            string getFilePath = functions.Windows2DOS_OpenDialogForGettingPath(false);

            // If the filepath is valid and the file was found, apply the file path text to the text box
            if (getFilePath != "NOT FOUND")
            {
                getFilePath = functions.Windows2DOS_ConvertPath(variables.PathWindow_Booleans_ConvertWindowsPaths2DOS, getFilePath);
                TextBox_WindowsPath.Text = getFilePath;
            }
        }
        private void Button_SelectFolder_Click(object sender, EventArgs e)
        {
            // Get the functions & variables
            var functions = new Functions();
            var variables = new Variables();

            // Open the dialog and retrieve a string of the folder
            string getFolderPath = functions.Windows2DOS_OpenDialogForGettingPath(true);

            // If the folder is valid and the folder was found, apply the folder path text to the text box
            if (getFolderPath != "NOT FOUND")
            {
                getFolderPath = functions.Windows2DOS_ConvertPath(variables.PathWindow_Booleans_ConvertWindowsPaths2DOS, getFolderPath);
                TextBox_WindowsPath.Text = getFolderPath;
            }
        }

        private void CheckBox_SwitchConverter_CheckedChanged(object sender, EventArgs e)
        {
            // Get the functions & variables
            var functions = new Functions();
            var variables = new Variables();

            // Get checkbox checked state information
            CheckBox checkBox = (CheckBox)sender;
            string checkBoxState = checkBox.CheckState.ToString();

            // Make sure "isCheckBoxChecked" is set to true if "checkBoxState" says "Checked", but if not, then it's set to false
            if (checkBoxState == "Unchecked")
            {
                Label_PathConversionIndicator.Text = "Converting: Windows -> MS-DOS";
                variables.PathWindow_Booleans_ConvertWindowsPaths2DOS = true;
            }
            else if (checkBoxState == "Checked")
            {
                Label_PathConversionIndicator.Text = "Converting: MS-DOS -> Windows";
                variables.PathWindow_Booleans_ConvertWindowsPaths2DOS = false;
            }

            // Clear off the text boxes
            TextBox_WindowsPath.Text = "";
            TextBox_DOSPath.Text = "";
        }

        private void TextBox_WindowsPath_TextChanged(object sender, EventArgs e)
        {
            // Get the functions & variables
            var functions = new Functions();
            var variables = new Variables();

            // Create a variable that includes the window class itself
            var WindowPathConverter = new Window_PathConverter();

            // Go ahead and convert the path for the other box if it's set to do so
            TextBox_DOSPath.Text = functions.Windows2DOS_ConvertPath(variables.PathWindow_Booleans_ConvertWindowsPaths2DOS, TextBox_WindowsPath.Text);
        }

        private void Button_ResetPaths_Click(object sender, EventArgs e)
        {
            // Get the functions for the entire program
            var functions = new Functions();

            if ((TextBox_WindowsPath.Text != "" || TextBox_DOSPath.Text != "") || (TextBox_WindowsPath.Text != "" && TextBox_DOSPath.Text != ""))
            {
                // Show a message box before comfirming to clear the paths if they're not empty
                int response = functions.Windows2DOS_ShowMessageBox_Information_Normal("Warning", "Are you sure you want to reset? We detected you already got a path specified, so by clicking \"Yes\", be aware that what you filled already will be lost.", MessageBoxButtons.YesNo);

                // If the user presses "Yes", clear the paths in the text boxes
                if (response == (int)DialogResult.Yes)
                {
                    TextBox_WindowsPath.Text = "";
                    TextBox_DOSPath.Text = "";
                }
            }
        }
    }
}