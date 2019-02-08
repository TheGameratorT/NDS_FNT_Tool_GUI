using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace NDS_FNT_Tool_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            JSONEditor_Window.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"include\json_editor\index.html");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("py"))
            {
                MessageBox.Show("Python wasn't found! Conversion may not continue; please install it to use this feature.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "Binary files|*.bin";
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                ProcessStartInfo fnt_bin_to_json = new ProcessStartInfo("py");
                fnt_bin_to_json.Arguments = @"include\fnttool.py " + openFileDlg.FileName;
                fnt_bin_to_json.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(fnt_bin_to_json);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (File.Exists("py"))
            {
                MessageBox.Show("Python wasn't found! Conversion may not continue; please install it to use this feature.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "JSON files|*.json";
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                ProcessStartInfo fnt_bin_to_json = new ProcessStartInfo("py");
                fnt_bin_to_json.Arguments = @"include\fnttool.py " + openFileDlg.FileName;
                fnt_bin_to_json.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(fnt_bin_to_json);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tool GUI by TheGameratorT\n\n" +
                "FNTTool.py by RoadrunnerWMC\n\n" +
                "JSON Editor by josdejong, edited by TheGameratorT",
                "About:");
        }
    }
}
