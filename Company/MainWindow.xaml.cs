using Company.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        /// <summary>
        /// Загружает данные из бд в DataGrid, отображая таблицу Employee с объединением таблицы Post
        /// </summary>
        /// <returns>
        /// Возвращает список сотрудников из таблицы Employee и зарплату из Post
        /// </returns>
        private async Task LoadData()
        {
            try
            {
                ItemsDataGrid.ItemsSource = await dbContext.Employees.Select(e => new
                {
                    e.Id,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    Wages = e.Statuses.Where(s => s.EmployeeId == e.Id).Select(s => s.Post.Wages).FirstOrDefault()
                }).ToListAsync();
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

        /// <summary>
        /// Фильтрация по ФИО, после нажатия на кнопку фильтруется таблица и возвращает отфильтрованные данные 
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //предполагает, что SearchBox содержит данные для фильтрации
            var filter = SearchBox.Text.ToLower();
            var filtered = dbContext.Employees.Where(e =>
            e.FirstName.ToLower().Contains(filter) ||
            e.LastName.ToLower().Contains(filter) ||
            e.MiddleName.ToLower().Contains(filter));

            ItemsDataGrid.ItemsSource = filtered.Select(e => new
            {
                e.Id,
                e.FirstName,
                e.LastName,
                e.MiddleName,
                Wages = e.Statuses.Where(s => s.EmployeeId == e.Id).Select(s => s.Post.Wages).FirstOrDefault()
            }).ToList();
        }

        /// <summary>
        /// сброс фильтрации
        /// </summary>
        private async void ResetButtun_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            await LoadData();
        }
    }
}