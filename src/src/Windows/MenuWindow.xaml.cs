using Microsoft.Win32;
using src.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;

namespace src.Windows
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        List<DigisageFile> files;
        DigisageFile selectedFile;
        FileDatabaseManager db;
        public MenuWindow()
        {
            InitializeComponent();
            files = new List<DigisageFile>();
            db = new FileDatabaseManager("UserFiles");
            ReadFileDatabase();

        }

        void ReadFileDatabase()
        {
            files = db.LoadRecords<DigisageFile>("Files");

            if (files != null)
                fileDisplayListView.ItemsSource = files;
        }

        private void uploadFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|PNG (*.png)|*.png|Wave files (*.wav)|*.wav";

            if(openFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fs.Length];
                    int bytesread = fs.Read(buffer, 0, buffer.Length);
                    db.InsertRecord("Files", new DigisageFile { Name = openFileDialog.SafeFileName, Filestream = buffer });
                    ReadFileDatabase();
                }
            }
        }
        private void retrieveFileButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void deleteFileButton_Click(object sender, RoutedEventArgs e)
        {
            db.DeleteRecord<DigisageFile>("Files", selectedFile.Id);
            ReadFileDatabase();
        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            string tempFolderPath = $@"{Directory.GetCurrentDirectory()} + \..\..\..\Temp";
            System.IO.DirectoryInfo di = new DirectoryInfo(tempFolderPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            Close();
        }

        private void fileDisplayListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DigisageFile highlightedFile = (DigisageFile)fileDisplayListView.SelectedItem;

            if (highlightedFile != null)
            {
                selectedFile = highlightedFile;
            }
        }

        private void fileDisplayListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DigisageFilePresenter.presentFile(selectedFile);
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filteredList = files.Where(f => f.Name.ToLower().Contains(searchBox.Text.ToLower())).ToList();
            fileDisplayListView.ItemsSource = filteredList;
        }
    }
}
