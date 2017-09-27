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
using TweetSharp;

namespace SuperPUBG.User
{
    /// <summary>
    /// ucHome.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucHome : UserControl
    {
        public ucHome()
        {
            InitializeComponent();

            var service = new TwitterService("GUILlchS8MQBz4n8Q7j3lTwaV", "i8SvtzxyDWOjXQW6uMMGhDzdAZpp85QAWGsJaDnezzxOiuXcdu");
            service.AuthenticateWith("911950168785690625-KCpv9VZencc9orhNBS5kZ8mvFzmIodw", "WoKtgsr2N8RyZhMz3zImOLSgziCJL5aAaFHZPIHQhRtle");
            var currentTweets = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { ScreenName = "PUBATTLEGROUNDS", Count = 1, });

            foreach (var tweet in currentTweets)
            {
                tbTweet.Text = tweet.Text;
            }
        }
    }
}
