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

namespace LoN.View
{
    /// <summary>
    /// Interaction logic for CRUD.xaml
    /// </summary>
    public partial class CrudWindow : Window
    {
        public CrudWindow()
        {
            InitializeComponent();
        }

        private void SwitchWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((App)Application.Current).ToShopView();
        }
    }
}
