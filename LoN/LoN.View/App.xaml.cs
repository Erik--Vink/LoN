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
            var x = new MainWindow() { Top = 100, Left = 100 };
            x.Show();          
            var y = new NinjaWindow() { Top = x.Top, Left = (x.Left + x.Width) };
            y.Show();
            new NinjaLoadWindow() { Top = y.Top, Left = (y.Left + y.Width) }.Show();           
            var crud = Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Crud");
            if (crud != null) { crud.Close(); }
        }

        public void ToCrudView()
        {
            new CrudWindow() { Top = 100, Left = 100 }.Show();
            var main = Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Main");
            if (main != null) { main.Close(); }
            var ninja = Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Ninja");
            if (ninja != null) { ninja.Close(); }
            var load = Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Load");
            if (load != null) { load.Close(); }
        }


    }
}
