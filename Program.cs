using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

// Prevents warnings about typing up commas if an array will have more values later on
#pragma warning disable IDE0079
#pragma warning disable IDE0059
// Prevents warnings about MarshalAs within not specifying P/Invoke arguments
#pragma warning disable CA2101
// Prevents warnings about public functions and telling the IDE that it can be marked as static
#pragma warning disable CA1822
// Prevents warnings about unused parameters being used
#pragma warning disable CA0060

namespace windows2msdos_variables
{
    public class Variables
    {
        // ---- VARIABLES ----


        // [--MAIN WINDOW--]

        // Strings:

        // The window title for the main window
        public string MainWindowTitle = "Windows/MS-DOS Conversion Tools";


        // [--PATH CONVERTER WINDOW--]

        // Strings:

        // Text for the output Windows Path textbox
        public string PathWindow_Strings_WinPath = "Windows Path";
        // Text for the output MS-DOS Path textbox
        public string PathWindow_Strings_DOSPath = "MS-DOS Path";
        // Text for selecting the file/folder for path conversions
        public string PathWindow_Strings_SelectFilePath = "Select File/Folder:";

        // Booleans:

        // Are we converting Windows paths to DOS paths, or the other way around?
        public bool PathWindow_Booleans_ConvertWindowsPaths2DOS = true;


        // [--ALL WINDOWS--]

        // Strings:

        // 'File' string
        public string AllWindows_Strings_File = "File";
        // 'Folder' string
        public string AllWindows_Strings_Folder = "Folder";
        // Button string for converting a Windows thing to an MS-DOS format
        public string AllWindows_Strings_Windows2DOS = "Windows -> MS-DOS";
        // Button string for converting an MS-DOS thing to a Windows format
        public string AllWindows_Strings_DOS2Windows = "MS-DOS -> Windows";

        // Booleans:

        // Should the program get the dark mode settings from Windows?
        public bool AllWindows_Booleans_GetWindowsDarkModeSettings = true;
        // Is the program in dark mode?
        public bool AllWindows_Booleans_DarkMode = true;
    }
}

namespace windows2msdos_functions
{
    using windows2msdos_variables;

    public class Functions
    {
        public void Windows2DOS_GetDarkMode(Variables variables)
        {
            if (variables.AllWindows_Booleans_GetWindowsDarkModeSettings)
            {
                // Get the Windows Registry setting for the dark mode option
                object regValue = Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1) ?? "";
                string regValueS = (string)regValue;

                // Default variable for dark mode setting
                int res = 0;

                // If not -1 (Not found), set the found value
                if ((int)regValue != -1)
                {
                    res = (int)regValue;
                }

                // If dark mode is on, it's true
                if (res == 0)
                {
                    variables.AllWindows_Booleans_DarkMode = true;
                }
                // If dark mode is off, it's false
                else if (res == 1)
                {
                    variables.AllWindows_Booleans_DarkMode = false;
                }
            }
        }
        public void Windows2DOS_SetConversionType(bool isSet, Variables variables)
        {
            if(isSet)
            {
                variables.PathWindow_Booleans_ConvertWindowsPaths2DOS = true;
            }
            else
            {
                variables.PathWindow_Booleans_ConvertWindowsPaths2DOS = false;
            }
        }
    }
}

namespace windows2msdos
{
    using windows2msdos_functions;
    using windows2msdos_variables;

    public class Program
    {
        // The main program process
        [STAThread]
        static void Main(Functions functions, Variables variables)
        {
            functions.Windows2DOS_GetDarkMode(variables);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window_MainWindow());
        }
    }
}
