using CRM_MED.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace CRM_MED.Views
{
    /// <summary>
    /// Логика взаимодействия для test.xaml
    /// </summary>
    public partial class test : Window
    {
        public List<Storage> storages = new List<Storage>();
        public test()
        {
            InitializeComponent();

            var context = new CRMmedContext();
            storages = context.Storages.Include(s => s.UnitNavigation).Include(s => s.MaterialTypeNavigation).ToList();
            DataContext = this;

        
    }
    }
}
