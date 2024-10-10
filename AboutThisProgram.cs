using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using windows2msdos_functions;
using windows2msdos_variables;

namespace windows2msdos
{
    public partial class Window_AboutThisProgram : Form
    {
        public Window_AboutThisProgram()
        {
            // Get the variables
            var variables = new Variables();

            // Initalize the window component
            InitializeComponent();

            // Change the window colors if dark mode is enabled
            ChangeWindowColors();

            // Put together all text instances
            Text = variables.AboutWindow_Strings_WindowTitle;

            Label_AboutThisProgram_ProgramName.Text = variables.AboutWindow_Strings_ProgramName;
            Label_AboutThisProgram_VersionNumber.Text = variables.AboutWindow_Strings_ProgramVersion;
            Label_AboutThisProgram_Author.Text = variables.AboutWindow_Strings_ProgramAuthor;
            Label_AboutThisProgram_OpenSourceInfo.Text = variables.AboutWindow_Strings_ProgramLicenseInfo;
        }

        private void PictureBox_Windows2DOSLogo_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/SolaceEllery/Windows2DOS",
                UseShellExecute = true
            });
        }
    }
}
