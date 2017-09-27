using MaterialDesignThemes.Wpf;
using System;
using SuperPUBG.User;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPUBG.CS
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null) throw new ArgumentNullException(nameof(snackbarMessageQueue));

            MenuItems = new[]
            {
                new MenuItem("Home",new ucHome()),
                new MenuItem("Install",new ucInstall()),
                new MenuItem("Mail", new ucMail()),
                new MenuItem("Discord", new ucDiscord()),
                new MenuItem("Board",new ucSetting())
            };

        }

        public MenuItem[] MenuItems { get; }
    }
}
