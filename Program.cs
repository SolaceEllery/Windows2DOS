using System;
using System.Diagnostics;
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
// Prevents warnings about visible methods being declared from DLLs
#pragma warning disable CA1401
// Prevents warnings about suggesting making certain variables read-only
#pragma warning disable IDE0044














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
        // This is true so that we can run functions on every frame if we need to.
        public bool AllWindows_Booleans_LoopProgram = true;
    }
}














namespace windows2msdos_functions
{
    using System.Runtime.InteropServices;
    using windows2msdos;
    using windows2msdos_variables;

    public class Functions
    {


        // [--MANDATORY METHODS FOR LINKING KERNEL32.DLL--]

        // Gets a DOS path string value
        public string GetShortPathName(string longPath)
        {
            StringBuilder shortPath = new(longPath.Length + 1);

            if (GetShortPathName(longPath, shortPath, shortPath.Capacity) == 0)
            {
                return longPath;
            }

            return shortPath.ToString();
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern Int32 GetShortPathName(string path, StringBuilder shortPath, Int32 shortPathLength);

        // Gets a Windows path string value
        public string GetLongPathName(string shortPath)
        {
            StringBuilder longPath = new(1024);

            if (GetLongPathName(shortPath, longPath, longPath.Capacity) == 0)
            {
                return shortPath;
            }

            return longPath.ToString();
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern Int32 GetLongPathName(string shortPath, StringBuilder longPath, Int32 longPathLength);





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
            bool ConvertPaths_Enabled = false;
            string ConvertPaths_Path = "NOT SPECIFIED";
            bool ConvertPaths_Win2DOS = true;
            string ConvertPaths_Output = "";

            for (int i = 0; i <= args.Length; i++)
            {
                // Help info
                if ((args[i].ToString() == "-h" || args[i].ToString() == "--help") && args[i + 1] != null)
                {
                    Debug.WriteLine(
@"Windows2DOS
By Spencerly D. Everly

Global Options:

-o/--output
    The output of a path/filepath for converting to Windows/DOS.

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
                // Output directory/filepath
                if ((args[i].ToString() == "-o" || args[i].ToString() == "--output") && args[i + 1] != null)
                {
                    ConvertPaths_Path = args[i + 1].ToString()!;
                    Debug.WriteLine("Output specified as: \"" + ConvertPaths_Path + "\"");
                }
                // Convert paths (No GUI)
                if ((args[i].ToString() == "-c" || args[i].ToString() == "--convert") && args[i + 1] != null)
                {
                    // Make this true so that the Command Prompt will convert paths
                    ConvertPaths_Enabled = true;

                    // Either "WindowsPath" or "DOSPath" can be specified for conversion
                    if (args[i + 1].ToString() == "DOSPath")
                    {
                        ConvertPaths_Win2DOS = true;
                        Debug.WriteLine("Set to convert a Windows Path to a DOS Path.");
                    }
                    else if (args[i + 1].ToString() == "WindowsPath")
                    {
                        ConvertPaths_Win2DOS = false;
                        Debug.WriteLine("Set to convert a DOS Path to a Windows Path.");
                    }
                }
            }

            // Run any argument-specified methods below

            // Convert paths (No GUI)
            if(ConvertPaths_Path != "NOT SPECIFIED")
            {
                if (ConvertPaths_Enabled && ConvertPaths_Win2DOS)
                {
                    ConvertPaths_Output = Windows2DOS_ConvertPath(true, ConvertPaths_Path);
                    Debug.WriteLine("Converted to a DOS Path:");
                }
                else if (ConvertPaths_Enabled && !ConvertPaths_Win2DOS)
                {
                    ConvertPaths_Output = Windows2DOS_ConvertPath(false, ConvertPaths_Path);
                    Debug.WriteLine("Converted to a Windows Path:");
                }
                Debug.WriteLine(ConvertPaths_Output);
            }

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

        // Sets the conversion type for converting Windows/DOS paths
        public void Windows2DOS_SetConversionType(bool isSet)
        {
            // Get the variables and functions for the entire program
            var variables = new Variables();

            // Check "isSet". If true, the converter will convert from MS-DOS to Windows, else if false, the converter will convert from Windows to MS-DOS
            if (isSet)
            {
                variables.PathWindow_Booleans_ConvertWindowsPaths2DOS = true;
            }
            else
            {
                variables.PathWindow_Booleans_ConvertWindowsPaths2DOS = false;
            }
        }

        /*
            Converts a path.
            
            toDOS = If true, the path is assumed to be a Windows path to convert to a DOS path. If false, the path is assumed to be a DOS path to convert to a Windows path.
            inPath = The path/filepath as a string
        */
        public string Windows2DOS_ConvertPath(bool toDOS, string inPath)
        {
            // Prepare the "Window_PathConverter" class as a variable
            var WindowPathConverterVar = new Window_PathConverter();

            if (toDOS)
            {
                StringBuilder shortPath = new(65000);
                int shortPathConv = GetShortPathName(inPath, shortPath, shortPath.Capacity);
                return shortPath.ToString();
            }
            else
            {
                StringBuilder longPath = new(1024);
                int longPathConv = GetLongPathName(inPath, longPath, longPath.Capacity);
                return longPath.ToString();
            }
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
            // Set some mandatory settings
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            // Get the variables and functions for the entire program
            var variables = new Variables();
            var functions = new Functions();

            // Prepare the "Window_MainWindow" class as a variable
            var mainWindowVar = new Window_MainWindow();

            // Run the startup settings configurator function. If there are no command prompt arguments, the command line won't be used for running the program
            if (args.Length != 0)
            {
                // Make a new object array variable
                object[] argsForInit = [""];

                // Convert the string array to an object array
                for (int i = 0; i <= args.Length; i++)
                {
                    argsForInit[i] = (string)args[i];
                }

                // Now run the initiation method
                functions.Windows2DOS_Init(argsForInit);
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
            do
            {
                functions.Windows2DOS_CheckDarkModeSettings();
            }
            while (variables.AllWindows_Booleans_LoopProgram);
        }
    }
}
