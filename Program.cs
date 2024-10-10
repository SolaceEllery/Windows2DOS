/*
    Windows2DOS: Bidirectional All-In-One Windows & DOS Conversion Utilities
    By Solace D. Ellery
*/

using System;
using System.Windows;
using System.Management;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;

// Prevents warnings about typing up commas if an array will have more values later on
#pragma warning disable IDE0079
#pragma warning disable IDE0059
// Prevents warnings about MarshalAs within not specifying P/Invoke arguments
#pragma warning disable CA2101
// Prevents warnings about public functions and telling the IDE that it can be marked as static
#pragma warning disable CA1822
// Prevents warnings about unused parameters being used
#pragma warning disable CA0060
// Prevents warnings about visible methods being declared from DLLs
#pragma warning disable CA1401
// Prevents warnings about suggesting making certain variables read-only
#pragma warning disable IDE0044
// Prevents warnings about unmatched folder structures
#pragma warning disable IDE0130













namespace windows2msdos_variables
{
    public class Variables
    {
        // ---- VARIABLES ----


        // [--MAIN WINDOW--]

        // Strings:

        // Main window title
        public string MainWindow_Strings_WindowTitle = "Windows/MS-DOS Conversion Tools";
        // Welcome text
        public string MainWindow_Strings_WelcomeText = "Welcome to Windows2DOS.";
        // Welcome info
        public string MainWindow_Strings_WelcomeInformation = "This is a conversion tool for \r\nmany things Windows +\r\nDOS related. Please select\r\nany of our tools on the right\r\nin order to use them!";
        // 'Path Converter' button text
        public string MainWindows_Strings_Buttons_PathConverter = "Path Converter";
        // 'About This Program' button text
        public string MainWindows_Strings_Buttons_AboutThisProgram = "About This Program";

        // [--"PATH CONVERTER" WINDOW--]

        // Strings:

        // Main window title
        public string PathWindow_Strings_WindowText = "Windows/MS-DOS Conversion Tools: Path Converter";
        // Text for the output Windows Path textbox
        public string PathWindow_Strings_WinPath = "Windows Path";
        // Text for the output MS-DOS Path textbox
        public string PathWindow_Strings_DOSPath = "MS-DOS Path";
        // Text for selecting the file/folder for path conversions
        public string PathWindow_Strings_SelectFilePath = "Select File/Folder:";

        // Booleans:

        // Are we converting Windows paths to DOS paths, or the other way around?
        public bool PathWindow_Booleans_ConvertWindowsPaths2DOS = true;

        // [--"ABOUT THIS PROGRAM" WINDOW--]

        // Strings:

        // Main window title
        public string AboutWindow_Strings_WindowTitle = "About Windows2DOS";
        // Program name
        public string AboutWindow_Strings_ProgramName = "Windows2DOS";
        // Program version
        public string AboutWindow_Strings_ProgramVersion = "v0.1.0b";
        // Program author
        public string AboutWindow_Strings_ProgramAuthor = "Programmed by Solace D. Ellery";
        // Program license information
        public string AboutWindow_Strings_ProgramLicenseInfo = "This program is 100% open source with\r\nno license whatsoever. Anyone can do\r\nanything with this program outside the\r\nrepository as they wish.";


        // [--ALL WINDOWS--]

        // Strings:

        // The path to the running application.
        public string AllWindows_Strings_AppPath = AppDomain.CurrentDomain.BaseDirectory;

        // Booleans:

        // Should the program get the dark mode settings from Windows?
        public bool AllWindows_Booleans_GetWindowsDarkModeSettings = true;
        // Is the program in dark mode?
        public bool AllWindows_Booleans_DarkMode = true;
    }
}














namespace windows2msdos_functions
{
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using windows2msdos;
    using windows2msdos_variables;
    using static System.Windows.Forms.LinkLabel;

    public class Functions
    {
        // Import the "kernel32.dll" file for retrieving the raw call for the program
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        // Import "GetShortPathName"
        static extern Int32 GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

        // Import the "kernel32.dll" file
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        // Import "GetLongPathName"
        static extern Int32 GetLongPathName(string path, StringBuilder longPath, int longPathLength);


        // [--MANDATORY METHODS--]

        // Gets a DOS path string value (String returning function)
        public string Windows2DOS_GetDOSPathName(string path1)
        {
            StringBuilder path2 = new(path1.Length + 1);

            if (GetShortPathName(path1, path2, path2.Capacity) == 0)
            {
                return path1;
            }

            return path2.ToString();
        }

        // Gets a Windows path string value (String returning function)
        public string Windows2DOS_GetWindowsPathName(string path1)
        {
            StringBuilder path2 = new(path1.Length + 1);

            if (GetLongPathName(path1, path2, path2.Capacity) == 0)
            {
                return path1;
            }

            return path2.ToString();
        }





        // [--METHODS FOR THE ENTIRE PROGRAM--]

        // Program startup method used for dealing with command line arguments and setting program startup settings
        public void Windows2DOS_Init(object[] args)
        {
            // Get the variables and functions for the entire program
            var variables = new Variables();

            // -- Comand Line Arguments --
            if (args != null && args[0] != (object)"")
            {
                Windows2DOS_InitCmdArgsAndFuncs(args);
            }

            // -- Dark Mode --
            if (variables.AllWindows_Booleans_GetWindowsDarkModeSettings)
            {
                Windows2DOS_CheckDarkModeSettings();
            }
        }

        // Separate program startup method, for if no arguments were specified in the Command Prompt
        public void Windows2DOS_Init()
        {
            // Get the variables and functions for the entire program
            var variables = new Variables();

            // Use an empty string array since there's no arguments
            string[] emptyArgs = [""];

            // Run the function with the "emptyArgs" variable as the args
            Windows2DOS_Init(emptyArgs);
        }

        // Program startup method for running non-GUI command prompt processes for arguments specified
        public void Windows2DOS_InitCmdArgsAndFuncs(object[] args)
        {
            // Get the variables for the entire program
            var variables = new Variables();

            // Path Conversion Variables
            bool ConvertPaths_Enabled = false;
            bool ConvertPaths_Win2DOS = true;
            string ConvertPaths_ConvertedPath = "";
            string ConvertPaths_PathToUse = "NOT SPECIFIED";
            

            // Logging-Related Variables
            bool Logging_WriteToFile = false;
            string Logging_FileToWriteTo = "NOT SPECIFIED";
            string Logging_DefaultFilepath = variables.AllWindows_Strings_AppPath + "logs/Windows2DOS-" + Windows2DOS_GetCurrentDate(true) + "-" + Windows2DOS_GetCurrentTime(true) + ".log";

            for (int i = 0; i <= args.Length; i++)
            {
                // Help info
                if (args[i] == (object)"-h" || args[i] == (object)"--help")
                {
                    Console.Write(
@"Windows2DOS (v0.1.0)
By Solace D. Ellery

Global Options:

-h/--help
    Show this help dialog and exit
-i/--input
    The input of a path/filepath.
    This can be used for converting the input to either Windows/DOS
    path formats.
-o/--output
    The output of a path/filepath. This is an optional argument.
    This can be used for specifying a custom filepath for writing
    to a log file.
-l/--log
    If this is specified after the input and output arguments,
    the program will log details about what the program did to
    a log file.
    
    If the output is not specified, then the default log writing
    path will be used instead:

" + 
variables.AllWindows_Strings_AppPath + "logs/Windows2DOS-" + Windows2DOS_GetCurrentDate(true) + "-" + Windows2DOS_GetCurrentTime(true) + ".log"
+ @"

[pathFormat]                   
    (With no apostrophes)
    For converting to a Windows Path, this should be 'WindowsPath'.
    But if converting to a DOS Path, this should be 'DOSPath'.

General Commands:

- c/--convert [pathFormat]
    Marks a path for converting. See above for the [pathFormat]
    choices.

To start the actual GUI, execute this program without any arguments."
                    );
                }
                // Input directory/filepath
                if ((args[i] == (object)"-i" || args[i] == (object)"--input") && args[i + 1] != null)
                {
                    ConvertPaths_PathToUse = args[i + 1].ToString()!;
                    Console.Write("Input specified, using this filepath for the input:");
                    Console.Write(ConvertPaths_PathToUse);
                }
                // Output directory/filepath
                if ((args[i] == (object)"-o" || args[i] == (object)"--output") && args[i + 1] != null)
                {
                    Logging_FileToWriteTo = args[i + 1].ToString()!;
                    Console.Write("Output specified, using this filepath for the output:");
                    Console.Write(Logging_FileToWriteTo);
                }
                // Log conversion to a file
                if (args[i] == (object)"-l" || args[i] == (object)"--log")
                {
                    Logging_WriteToFile = true;
                    // If the output arg didn't get specified, use the default log writing path instead
                    if (Logging_FileToWriteTo == "NOT SPECIFIED")
                    {
                        // Get the current date
                        string CurrentDate = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("en-us"));

                        // Replace symbols that files can't have to underscores
                        CurrentDate = CurrentDate.Replace("/", "_");

                        // Get the current time
                        string CurrentTime = DateTime.Now.ToString("t", CultureInfo.CreateSpecificCulture("en-us"));

                        // Replace symbols that files can't have to underscores, along with replacing spaces with underscores just in case
                        CurrentTime = CurrentTime.Replace(" ", "_");
                        CurrentTime = CurrentTime.Replace(":", "_");

                        // Specify the default log writing path
                        Logging_FileToWriteTo = variables.AllWindows_Strings_AppPath + "logs/Windows2DOS-" + CurrentDate + "-" + CurrentTime + ".log";
                    }
                    Console.Write("A log file will be written to this filepath:");
                    Console.Write(Logging_FileToWriteTo);
                }
                // Convert paths (No GUI)
                if ((args[i].ToString() == "-c" || args[i].ToString() == "--convert") && args[i + 1] != null)
                {
                    // Make this true
                    ConvertPaths_Enabled = true;

                    // Either "WindowsPath" or "DOSPath" can be specified for conversion
                    if (args[i + 1].ToString() == "DOSPath")
                    {
                        ConvertPaths_Win2DOS = true;
                        Console.Write("Set to convert a Windows Path to a DOS Path.");
                    }
                    else if (args[i + 1].ToString() == "WindowsPath")
                    {
                        ConvertPaths_Win2DOS = false;
                        Console.Write("Set to convert a DOS Path to a Windows Path.");
                    }
                    else
                    {
                        Console.Write("The conversion argument is not valid. Try using either");
                        Console.Write("'WindowsPath' or 'DOSPath' to convert an input");
                    }
                }
            }

            // Run any argument-specified methods below

            // Convert paths (No GUI)
            if(ConvertPaths_Enabled && ConvertPaths_PathToUse != "NOT SPECIFIED")
            {
                if (ConvertPaths_Win2DOS)
                {
                    ConvertPaths_ConvertedPath = Windows2DOS_ConvertPath(true, ConvertPaths_PathToUse);
                    Console.Write("Converted to a DOS Path:");
                }
                else if (!ConvertPaths_Win2DOS)
                {
                    ConvertPaths_ConvertedPath = Windows2DOS_ConvertPath(false, ConvertPaths_PathToUse);
                    Console.Write("Converted to a Windows Path:");
                }
                Console.Write(ConvertPaths_ConvertedPath);
            }

            if (Logging_WriteToFile && Logging_FileToWriteTo != "NOT SPECIFIED")
            {
                // Lines that log files should write
                string[] OutputFileLines = [
                    "---------------------",
                    "Windows2DOS: Log File",
                    "---------------------",
                    "",
                    "Generated on this date & time:",
                    DateTime.Now.ToString(),
                    "",
                    "--------",
                    "",
                    "-- PATH/FILEPATH CONVERSION INFORMATION --",
                    "",
                    "Input Path/Filepath:",
                    ConvertPaths_PathToUse,
                    "",
                    "Path/Filepath Conversion Type:",
                    (ConvertPaths_Win2DOS != false) ? "Windows to MS-DOS" : "MS-DOS to Windows",
                    "",
                    "Path/Filepath Converted Result:",
                    ConvertPaths_ConvertedPath,
                    "",
                    "--------",
                ];

                StreamWriter OutputFile = new(Logging_FileToWriteTo);
                foreach (string line in OutputFileLines)
                {
                    OutputFile.WriteLine(line);
                }
                OutputFile.Close();
            }

            // Exit the environment
            Environment.Exit(0);
        }

        public void Windows2DOS_CheckDarkModeSettings()
        {
            // Get the variables and functions for the entire program
            var variables = new Variables();

            // Get the Windows Registry setting for the dark mode option
            object regValue = Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1) ?? "";

            // Specify the variable for the dark mode setting (Default is 0, which is "light mode" in the Windows Registry settings)
            int isDarkMode = 0;

            // If "regValue" is not -1 (Not found), set what was found to "isDarkMode"
            if ((int)regValue != -1)
            {
                isDarkMode = (int)regValue;
            }

            // If "isDarkMode" is 0, Windows is on dark mode, so set the "AllWindows_Booleans_DarkMode" variable to true
            if (isDarkMode == 0)
            {
                variables.AllWindows_Booleans_DarkMode = true;
            }
            // If "isDarkMode" is 1, Windows is on light mode, so set the "AllWindows_Booleans_DarkMode" variable to false
            else if (isDarkMode == 1)
            {
                variables.AllWindows_Booleans_DarkMode = false;
            }
        }

        // Checks if a method exists. You'll need a namespace, class, and method, all as a string.
        public bool Windows2DOS_MethodFunctionExists(string namespaceName, string className, string methodName)
        {
            // Get the class type
            var classType = Type.GetType(namespaceName + "." + className);

            if (classType != null)
            {
                // Check if a singular method exists
                var methodExists = classType.GetMethod(methodName) != null;

                // Return if it exists or not
                return methodExists;
            }
            else
            {
                return false;
            }
        }

        // Checks if a method exists. This short form only checks the "Functions" class under "windows2msdos_functions", and only "methodName" can be specified
        public bool Windows2DOS_MethodFunctionExists(string methodName)
        {
            return Windows2DOS_MethodFunctionExists("windows2msdos_functions", "Functions", methodName);
        }

        /*
            Converts a path.
            
            toDOS = If true, the path is assumed to be a Windows path to convert to a DOS path. If false, the path is assumed to be a DOS path to convert to a Windows path.
            inPath = The path/filepath as a string
        */
        public string Windows2DOS_ConvertPath(bool toDOS, string inPath)
        {
            string convertedPath = "";

            if (toDOS)
            {
                convertedPath = Windows2DOS_GetDOSPathName(inPath);
            }
            else
            {
                convertedPath = Windows2DOS_GetWindowsPathName(inPath);
            }

            return convertedPath;
        }

        /*
            Opens a dialog for getting the path/filepath.
            
            isPath = If true, the dialog will look for a folder to get the path. If false, the dialog will look for a file to get the filepath.
        */
        public string Windows2DOS_OpenDialogForGettingPath(bool isPath)
        {
            if (!isPath)
            {
                var openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    return openFileDialog.FileName;
                }
                else
                {
                    return "NOT FOUND";
                }
            }
            else
            {
                var openFileDialog = new FolderBrowserDialog();
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    return openFileDialog.SelectedPath;
                }
                else
                {
                    return "NOT FOUND";
                }
            }
        }

        public void Windows2DOS_ClearPathTextValues()
        {
            // Prepare the "Window_PathConverter" class as a variable
            var WindowPathConverterVar = new Window_PathConverter();

            // Clear the path text box text for both text boxes
            WindowPathConverterVar.TextBox_WindowsPath.Text = "";
            WindowPathConverterVar.TextBox_DOSPath.Text = "";
        }

        /*
            Shows a message box on the middle of the screen.
            
            title = The window title to use for the message box
            text = The window message to use for the message box
            icon = 
        */

        public int Windows2DOS_ShowMessageBox_Simple(string title, string text)
        {
            DialogResult msgBox = MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.None);
            return (int)msgBox;
        }

        public int Windows2DOS_ShowMessageBox_Normal(string title, string text, MessageBoxButtons buttons)
        {
            DialogResult msgBox = MessageBox.Show(text, title, buttons, MessageBoxIcon.None);
            return (int)msgBox;
        }

        public int Windows2DOS_ShowMessageBox_Custom(string title, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult msgBox = MessageBox.Show(text, title, buttons, icon);
            return (int)msgBox;
        }

        public int Windows2DOS_ShowMessageBox_Information_Simple(string title, string text)
        {
            DialogResult msgBox = MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return (int)msgBox;
        }

        public int Windows2DOS_ShowMessageBox_Information_Normal(string title, string text, MessageBoxButtons buttons)
        {
            DialogResult msgBox = MessageBox.Show(text, title, buttons, MessageBoxIcon.Information);
            return (int)msgBox;
        }

        public int Windows2DOS_ShowMessageBox_Error_Simple(string title, string text)
        {
            DialogResult msgBox = MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return (int)msgBox;
        }

        public int Windows2DOS_ShowMessageBox_Error_Normal(string title, string text, MessageBoxButtons buttons)
        {
            DialogResult msgBox = MessageBox.Show(text, title, buttons, MessageBoxIcon.Error);
            return (int)msgBox;
        }

        public string Windows2DOS_GetCurrentDate(bool isFileName)
        {
            // Get the current date
            string CurrentDate = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("en-us"));

            // Replace symbols that files can't have to underscores if "isFileName" is true
            if (isFileName)
            {
                CurrentDate = CurrentDate.Replace("/", "_");
            }

            // Return the date
            return CurrentDate;
        }

        public string Windows2DOS_GetCurrentTime(bool isFileName)
        {
            // Get the current time
            string CurrentTime = DateTime.Now.ToString("t", CultureInfo.CreateSpecificCulture("en-us"));

            // Replace symbols that files can't have to underscores if "isFileName" is true
            if (isFileName)
            {
                CurrentTime = CurrentTime.Replace(" ", "_");
                CurrentTime = CurrentTime.Replace(":", "_");
            }

            // Return the date
            return CurrentTime;
        }

        // This is called when the program should exit.
        public void Windows2DOS_CloseProgram()
        {
            // Exit the program itself, but the process will still run
            Application.Exit();

            // -- Since the program has not 100% quit entirely (It's still running in the background at this point), attempt to kill the entire process --

            // Get the process itself, and the PID needed for killing the program
            System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();

            // Finally, we can kill the process entirely!
            process.Kill(true);
        }
    }
}
















namespace windows2msdos
{
    using System.Runtime.InteropServices;
    using windows2msdos_functions;
    using windows2msdos_variables;

    internal class Program
    {
        // The main program process
        [System.ComponentModel.Bindable(true)]

        [STAThread]
        static void Main(string[] args)
        {
            // Get the variables and functions for the entire program
            var variables = new Variables();
            var functions = new Functions();

            // Set some mandatory settings
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            // Prepare the "Window_MainWindow" class as a variable
            var mainWindowVar = new Window_MainWindow();

            // Run the startup settings configurator function. If there are no command prompt arguments, the command line won't be used for running the program
            if (args.Length != 0)
            {
                // Make a new blank object array variable
                object[] argsForInit = [];

                // Convert the string array to an object array
                for (int i = 0; i <= (int)args.Length; i++)
                {
                    argsForInit[i] = args[i];
                }

                // Now run the command prompt side of the program
                functions.Windows2DOS_InitCmdArgsAndFuncs(argsForInit);
            }
            else
            {
                functions.Windows2DOS_Init();
            }

            // Run the true application process
            Application.Run(new Window_MainWindow());

            // If Windows is in dark mode, apply the dark window colors
            if(variables.AllWindows_Booleans_DarkMode)
            {
                // Change the window background color to black
                mainWindowVar.BackColor = Color.Black;

                // Change all text colors that are black to white
                mainWindowVar.Label_WelcomeText.ForeColor = Color.White;
                mainWindowVar.Label_WelcomeInformation.ForeColor = Color.White;

                // Change all button colors to fit the dark mode setting
                mainWindowVar.Button_MainMenuAboutThisProgram.BackColor = Color.DarkRed;
                mainWindowVar.Button_MainMenuAboutThisProgram.ForeColor = Color.White;

                mainWindowVar.Button_MainMenuConvertPaths.BackColor = Color.DarkRed;
                mainWindowVar.Button_MainMenuConvertPaths.ForeColor = Color.White;
            }
        }
    }
}
