using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoN.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ToShopView();
        }

        public void ToShopView()
        {
            var x = new NinjaWindow() { Top = 100, Left = 100 };
            x.Show();
            new MainWindow() { Top = x.Top, Left = (x.Left + x.Width) }.Show();
            var crud = Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Crud");
            if (crud != null) { crud.Close(); }
        }

        public void ToCrudView()
        {
            new CrudWindow() { Top = 100, Left = 100 }.Show();
            var main = Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Main");
            if (main != null) { main.Close(); }
            var list = Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "List");
            if (list != null) { list.Close(); }
        }


    }
}
