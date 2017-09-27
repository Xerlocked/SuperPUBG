using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SuperPUBG.User
{
    /// <summary>
    /// ucInstall.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucInstall : UserControl
    {
        public ucInstall()
        {
            InitializeComponent();
        }

        private void Tile_Click(string url,string filename)
        {
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            Mouse.OverrideCursor = Cursors.Wait;
            webClient.DownloadFileAsync(new Uri(url), $@"{pathDownload}\{filename}.exe");
        }

        private void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Mouse.OverrideCursor = null;
            var messageQueue = Download_Snackbar.MessageQueue;
            var message = "다운로드 완료!\r\nDownloads 폴더를 확인해주세요";

            //the message queue can be called from any thread
            System.Threading.Tasks.Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        private void DownLoad_GoClean_Click(object sender, RoutedEventArgs e)
        {
            Tile_Click("http://goclean.tistory.com/attachment/cfile21.uf@260D3837584DE73E1229E5.exe", "GoClean");
        }

        private void DownLoad_Steam_Click(object sender, RoutedEventArgs e)
        {
            Tile_Click("https://steamcdn-a.akamaihd.net/client/installer/SteamSetup.exe", "Steam");
        }

        private void DownLoad_ReShade_Click(object sender, RoutedEventArgs e)
        {
            Tile_Click("https://cdn.discordapp.com/attachments/316932169245392896/318409223006322688/ReShade_Setup_3.0.7.exe", "ReShade_Setup_3.0.7");
        }

        private void DownLoad_Discord_Click(object sender, RoutedEventArgs e)
        {
            Tile_Click("https://discordapp.com/api/download?platform=win", "DiscordSetup");
        }
    }
}
