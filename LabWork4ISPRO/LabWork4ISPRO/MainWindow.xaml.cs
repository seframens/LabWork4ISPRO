using LabWork4ISPRO.DbLayer.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork4ISPRO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserService _userService = new();
        public MainWindow()
        {
            InitializeComponent();

            LoadUser();
        }

        private async Task LoadUser()
        {
            try
            {
                userDataGrid.ItemsSource = await _userService.GetAllAsync(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}