using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windows2msdos
{
    public partial class Window_MainWindow : Form
    {
        public Window_MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MainMenuConvertPaths_Click(object sender, EventArgs e)
        {
            Application.Run(new Window_PathConverter());
        }

        private void Button_MainMenuAboutThisProgram_Click(object sender, EventArgs e)
        {
            
        }
    }
}
