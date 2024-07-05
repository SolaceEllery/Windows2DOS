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
        public static string GetShortPathName(string longPath)
        {
            StringBuilder shortPath = new(longPath.Length + 1);

            if (Window_PathConverter.GetShortPathName(longPath, shortPath, shortPath.Capacity) == 0)
            {
                return longPath;
            }

            return shortPath.ToString();
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern Int32 GetShortPathName(string path, StringBuilder shortPath, Int32 shortPathLength);

        public static string GetLongPathName(string shortPath)
        {
            StringBuilder longPath = new(1024);

            if (Window_PathConverter.GetLongPathName(shortPath, longPath, longPath.Capacity) == 0)
            {
                return shortPath;
            }

            return longPath.ToString();
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern Int32 GetLongPathName(string shortPath, StringBuilder longPath, Int32 longPathLength);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
        static extern bool SetDllDirectory(string lpPathName);

        public Window_PathConverter()
        {
            InitializeComponent();
        }

        private void Button_SelectFile_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                TextBox_WindowsPath.Text = openFileDialog1.FileName;
            }
        }
        private void Button_SelectFolder_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new FolderBrowserDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                TextBox_WindowsPath.Text = openFileDialog1.SelectedPath;
            }
        }

        private void CheckBox_SwitchConverter_CheckedChanged(object sender, EventArgs e)
        {
            // Get checkbox information
            CheckBox checkBox = (CheckBox)sender;

            // Get the functions & variables
            Functions functions = new();
            Variables variables = new();

            // Now set the conversion type setting, along with setting everything else
            functions.Windows2DOS_SetConversionType(checkBox.Checked, variables);
            if (checkBox.Checked)
            {
                Label_PathConvertIndicator.Text = "Converting: MS-DOS Path -> Windows Path";
            }
            else
            {
                Label_PathConvertIndicator.Text = "Converting: Windows Path -> MS-DOS Path";
            }
        }

        private void TextBox_DOSPath_TextChanged(object sender, EventArgs e)
        {
            // Get the functions & variables
            Functions functions = new();
            Variables variables = new();

            // Now lets check to see if the conversion type is valid
            if(!variables.PathWindow_Booleans_ConvertWindowsPaths2DOS)
            {
                StringBuilder shortPath = new(65000);
                int shortPathConv = GetShortPathName(TextBox_WindowsPath.Text, shortPath, shortPath.Capacity);
                TextBox_DOSPath.Text = shortPath.ToString();
            }
        }

        private void TextBox_WindowsPath_TextChanged(object sender, EventArgs e)
        {
            // Get the functions & variables
            Functions functions = new();
            Variables variables = new();

            // Now lets check to see if the conversion type is valid
            if (variables.PathWindow_Booleans_ConvertWindowsPaths2DOS)
            {
                StringBuilder longPath = new(1024);
                int longPathConv = GetLongPathName(TextBox_WindowsPath.Text, longPath, longPath.Capacity);
                TextBox_WindowsPath.Text = longPath.ToString();
            }
        }
    }
}