using CRM_MED.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CRM_MED.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminLogPage.xaml
    /// </summary>
    public partial class AdminLogPage : Page
    {
        public ObservableCollection<StorageLog> storageLogs;
        public AdminLogPage()
        {


            InitializeComponent();
            using (var context = new CRMmedContext())
            {
                storageLogs = new ObservableCollection<StorageLog>(context.StorageLogs.Include(w=>w.Doctor).Include(w=>w.Patient).Include(w=>w.DayOfWeek).Include(w=>w.Storage).ToList());
                DG.ItemsSource = storageLogs;
                DataContext = this;

            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            var context = new CRMmedContext();
        }
    }
}
