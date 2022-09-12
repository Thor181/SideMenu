using System.Diagnostics;

namespace SideMenu.Service
{
    public class RunAppCommand : Command
    {
        public RunAppCommand(object parameter) : base(parameter)
        {
            _action = RunApp;
        }
        public void RunApp(object parameter)
        {
            if (parameter == null || parameter.GetType() != typeof(string))
                return;

            new Process
            {
                StartInfo = new ProcessStartInfo((string)parameter)
                {
                    UseShellExecute = true
                }
            }.Start();
        }
    }
}
