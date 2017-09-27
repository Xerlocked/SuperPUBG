using SuperPUBG.CS;
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

namespace SuperPUBG.User
{
    /// <summary>
    /// ucMail.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucMail : UserControl
    {
        public ucMail()
        {
            InitializeComponent();
        }

        private async void mailLogin_Click(object sender, RoutedEventArgs e)
        {
            

            if (!String.IsNullOrEmpty(mail_id.Text) || !String.IsNullOrEmpty(mail_pw.Password))
            {
                MailList ml = new MailList();
                btn_Code.Content = ml.SetLogin(combo_mail.Text, mail_id.Text, mail_pw.Password);
            }
            else
            {
                var sampleMessageDialog = new SimpleMessageDialog
                {
                    Message = { Text = "아이디 혹은 비밀번호를 확인해주세요 !" }
                };
                await MaterialDesignThemes.Wpf.DialogHost.Show(sampleMessageDialog, "RootDialog");
            }

        }



        private async void btn_Code_Click(object sender, RoutedEventArgs e)
        {
       
            if (btn_Code.Content == null || btn_Code.Content.ToString() == "Error")
            {
                var sampleMessageDialog = new SimpleMessageDialog
                {
                    Message = { Text = "복사 할 수 없습니다." }
                };
                await MaterialDesignThemes.Wpf.DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
            
            else
            {

                Clipboard.SetText(btn_Code.Content.ToString());
                var sampleMessageDialog = new SimpleMessageDialog
                {
                    Message = { Text = "입력창에 붙여넣어주세요." }
                };

                await MaterialDesignThemes.Wpf.DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
        }
    }
}
