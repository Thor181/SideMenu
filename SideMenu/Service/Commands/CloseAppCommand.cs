using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideMenu.Service
{
    public class CloseAppCommand : Command
    {
        public CloseAppCommand()
        {
            _action = CloseApp;
        }

        public void CloseApp(object parameter)
        {
            App.Current.Shutdown(0);
        }
    }
}
