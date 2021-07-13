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
using TestProject.BL;
using TestProject.DB;


namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataBaseCreator.CreateDataBase();

            using (ApplicationContext db = new ApplicationContext())
            {
                var x = DataGridDataLoader.GetTableInRussian(db);
                
                DataGridSales.ItemsSource = x.ToList();
            }
        }

        private void BtnRefreshData_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var x = DataGridDataLoader.GetTableInRussian(db);

                DataGridSales.ItemsSource = x.ToList();
            }
        }
        
        private void BtnModifyData_Click(object sender, RoutedEventArgs e)
        {
            ModifyDataWindow modifyDataWindow = new ModifyDataWindow();
            modifyDataWindow.Show();
        }
    }
}
