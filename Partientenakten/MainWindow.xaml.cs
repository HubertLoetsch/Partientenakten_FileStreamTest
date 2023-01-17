using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text;

namespace Partientenakten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string DIR_PATH = @"C:\Users\blade\Documents\Test\";
        public const string FILE_EXT = ".txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = textBoxFileName.Text;
            

            using (FileStream fs = File.Create(DIR_PATH + filename + FILE_EXT))
            {
                byte[] contentConvertedToByte = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvertedToByte, 0, contentConvertedToByte.Length);
            }

            MessageBox.Show("Datei Wurde angelegt.");

        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
           
            string filename = textBoxFileName.Text;

            using (FileStream fs = File.OpenRead(DIR_PATH + filename + FILE_EXT))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content;
                }
            }

        }
    }
}
