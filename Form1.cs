using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#pragma warning disable CA2101

namespace windows2msdos
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
        static extern void GetShortPathName(
                 [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                 [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder shortPath,
                 int shortPathLength
                 );
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new FolderBrowserDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.SelectedPath;
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

            private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            StringBuilder shortPath = new(65000);
            GetShortPathName(textBox1.Text, shortPath, shortPath.Capacity);
            textBox2.Text = shortPath.ToString();
        }
    }
}