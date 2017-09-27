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
using SuperPUBG.CS;

namespace SuperPUBG.User
{
    /// <summary>
    /// ucDiscord.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucDiscord : UserControl
    {
        public ucDiscord()
        {
            InitializeComponent();
            DiscordLoadViewModel discordLoadViewModel = new DiscordLoadViewModel(Discord_List);
            this.DataContext = discordLoadViewModel;
        }

        private void Discord_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DiscordList link = (DiscordList)Discord_List.SelectedItem;

                System.Diagnostics.Process.Start(link.DiscordLink);
            }
            catch (InvalidCastException)
            { }
            catch(NullReferenceException)
            { }
        }
    }
}
