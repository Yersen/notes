using Notes.Models;
using Notes.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Notes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\notesDataList.json";
        private BindingList<NotesModel> notesDataList;
        private fileToStoreData _fileToStoreData;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DgNotesList_Loaded(object sender, RoutedEventArgs e)
        {
            _fileToStoreData = new fileToStoreData(PATH);
            try
            {
                notesDataList = _fileToStoreData.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            

            dgNotesList.ItemsSource = notesDataList;
            notesDataList.ListChanged += NotesDataList_ListChanged;
        }

        private void NotesDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                try
                {
                    _fileToStoreData.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}