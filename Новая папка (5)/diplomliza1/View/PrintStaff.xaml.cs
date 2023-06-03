using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.ViewModels;
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

namespace diplomliza1.View
{
    /// <summary>
    /// Логика взаимодействия для PrintStaff.xaml
    /// </summary>
    public partial class PrintStaff : Window
    {
        public PrintStaff(ApplicationDbContext ctx, Staff staff)
        {
            InitializeComponent();
            DataContext = new PrintStaffViewModel(ctx,staff);
        }
        
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Stac_print, "Распечатываем элемент Canvas");
            }
        }
    }
}
