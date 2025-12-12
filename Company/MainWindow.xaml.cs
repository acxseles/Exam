using Company.Data;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppDbContext dbContext = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task LoadData()
        {
            try
            {
                ItemsDataGrid.ItemsSource = await dbContext.Employees
                    .Include(e => e.Statuses)
                    .ThenInclude(s => s.Post)
                    .ToListAsync();
            }
            catch
            {
                MessageBox.Show("Нет подключения к базе данных");
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}