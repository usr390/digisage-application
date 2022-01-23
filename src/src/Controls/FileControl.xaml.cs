using src.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace src.Controls
{
    /// <summary>
    /// Interaction logic for FileControl.xaml
    /// </summary>
    public partial class FileControl : UserControl
    {
        public DigisageFile DigisageFile
        {
            get { return (DigisageFile)GetValue(DigisageFileProperty); }
            set { SetValue(DigisageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DigisageFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DigisageFileProperty =
            DependencyProperty.Register("DigisageFile", typeof(DigisageFile), typeof(FileControl), new PropertyMetadata(new DigisageFile() { Name = "file.txt", Filestream = null}, SetFile));

        private static void SetFile(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FileControl control = d as FileControl;

            if (control != null)
            {
                control.filenameTextBlock.Text = (e.NewValue as DigisageFile).Name;
            }
        }

        public FileControl()
        {
            InitializeComponent();
        }
    }
}
