using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using windows2msdos_variables;

namespace windows2msdos
{
    public partial class Window_MainWindow : Form
    {
        public Window_MainWindow()
        {
            // Initalize the window component
            InitializeComponent();

            // Change the window colors if dark mode is enabled
            ChangeWindowColors();
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

        // This is called when the program is about to exit.
        private void FormClosedEventHandler(object sender, EventArgs e)
        {
            var variables = new Variables();

            // Make sure the loop ends before we completely exit the program
            if (variables.AllWindows_Booleans_LoopProgram)
            {
                variables.AllWindows_Booleans_LoopProgram = false;
            }

            // Exit the program entirely, don't let any processes run in the background whatsoever
            Application.Exit();
        }
    }
}
