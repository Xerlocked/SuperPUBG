using OpenQA.Selenium;
using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace SuperPUBG.CS
{
    public class MailList
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        mailBot mailbot = new mailBot();

        public IntPtr _Dock = IntPtr.Zero;

        public MailList(TextBlock tb, string site, string id, string pw)
        {
            mailbot.EnterWithPhantom();

            //HwndSource source = PresentationSource.FromVisual(doc) as HwndSource;
            //_Dock = source.Handle;

            //string title = "data:, - Chrome";
            //var process = Process.GetProcesses().FirstOrDefault(x => x.MainWindowTitle == title);

            //SetParent(process.MainWindowHandle, _Dock);

            tb.Text = SetLogin(site, id, pw);
        }

        public MailList()
        {
            mailbot.EnterWithPhantom();
        }

        public string SetLogin(string site, string id, string pw)
        {
            switch (site)
            {
                case "네이버":
                     return NLogin(id, pw);

                case "다음":
                    return DaumLogin(id, pw);

                case "지메일":
                    return GmailLogin(id, pw);

                default:
                    return "Error";
            }
        }

        public string NLogin(string id, string pw)
        {

            mailbot.Driver.Navigate().GoToUrl("https://nid.naver.com/nidlogin.login?url=http%3A%2F%2Fmail.naver.com%2F");

            var ElementID = mailbot.Driver.FindElement(By.Name("id"));
            var ElementPW = mailbot.Driver.FindElement(By.Name("pw"));
            var ElementBtn = mailbot.Driver.FindElement(By.ClassName("btn_global"));

            ElementID.SendKeys(id);
            mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ElementPW.SendKeys(pw);
            mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ElementBtn.Click();

            mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
            var mailList = mailbot.Driver.FindElements(By.XPath("//*[@class='listWrap']/ol/li"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)mailbot.Driver;
            js.ExecuteScript("arguments[0].click()", mailList[0]);

            var viewMail = mailbot.Driver.FindElements(By.Id("readFrame"));
            string codes;

            codes = viewMail[0].GetAttribute("textContent");

            codes = codes.Replace("\r", string.Empty).Replace("\t", string.Empty).Replace("\n", string.Empty);
            codes = codes.Trim();

            try
            {
                Regex reg = new Regex(@"[A-Z0-9]{4,6}");

                Match m = reg.Match(codes);

                codes = m.Value;

                mailbot.Driver.Quit();

                return codes;
            }
            catch (Exception)
            {
                mailbot.Driver.Quit();
                return "메일을 찾을  수 없습니다.";
            }
            //var scroll = "arguments[0].scrollIntoView(true);";


            //js.ExecuteScript(scroll, viewMail);
            // mailList[0].Click();
        }

        public string DaumLogin(string id, string pw)
        {
            mailbot.Driver.Navigate().GoToUrl("https://logins.daum.net/accounts/loginform.do?url=https%3A%2F%2Fmail.daum.net%2F");

            var ElementID = mailbot.Driver.FindElement(By.Name("id"));
            var ElementPW = mailbot.Driver.FindElement(By.Name("pw"));
            var ElementBtn = mailbot.Driver.FindElement(By.ClassName("btn_comm"));

            ElementID.SendKeys(id);
            mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ElementPW.SendKeys(pw);
            mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ElementBtn.Click();
            mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);

            var mailList = mailbot.Driver.FindElements(By.XPath("//*[@class='list_mail']/li"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)mailbot.Driver;
            js.ExecuteScript("arguments[0].click()", mailList[0]);

            var viewMail = mailbot.Driver.FindElements(By.ClassName("txt_mailview"));
            string codes;

            codes = viewMail[0].GetAttribute("textContent");

            codes = codes.Replace("\r", string.Empty).Replace("\t", string.Empty).Replace("\n", string.Empty);
            codes = codes.Trim();

            try
            {
                Regex reg = new Regex(@"[A-Z0-9]{4,6}");

                Match m = reg.Match(codes);

                codes = m.Value;

                mailbot.Driver.Quit();

                return codes;
            }
            catch (Exception)
            {
                mailbot.Driver.Quit();
                return "메일을 찾을  수 없습니다.";
            }
        }

        #region GMAIL (No Dev)
        public string GmailLogin(string id, string pw)
        {
            mailbot.Driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&osid=1&service=mail&ss=1&ltmpl=default&rm=false&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

            var ElementID = mailbot.Driver.FindElement(By.Id("identifierId"));
            var ElementID_Next = mailbot.Driver.FindElement(By.Id("identifierNext"));

            ElementID.SendKeys(id);
            ElementID_Next.Click();

            var ElementPW = mailbot.Driver.FindElements(By.XPath("//*[@class='whsOnd zHQkBf']"));
            //var ElementPW_Next = mailbot.Driver.FindElement(By.XPath("//*[@class='O0WRkf zZhnYe e3Duub C0oVfc Zp5qWd Hj2jlf dKVcQ']"));

            ElementPW[0].SendKeys(pw);
            ElementPW[0].SendKeys(Keys.Enter);
            mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //ElementPW_Next.Click();
            //mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);

            //mailbot.Driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#all");
            //mailbot.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var mailList = mailbot.Driver.FindElements(By.XPath("//*[@class='F cf zt']/tbody/tr"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)mailbot.Driver;
            js.ExecuteScript("arguments[0].click()", mailList[0]);

            var viewMail = mailbot.Driver.FindElements(By.ClassName("a3s aXjCH m15df04dc5bcb78bd"));
            string codes;

            codes = viewMail[0].GetAttribute("textContent");

            codes = codes.Replace("\r", string.Empty).Replace("\t", string.Empty).Replace("\n", string.Empty);
            codes = codes.Trim();

            try
            {
                Regex reg = new Regex(@"[A-Z0-9]{4,6}");

                Match m = reg.Match(codes);

                codes = m.Value;

                mailbot.Driver.Quit();

                return codes;
            }
            catch (Exception)
            {
                mailbot.Driver.Quit();
                return "메일을 찾을  수 없습니다.";
            }
        }

        #endregion

    }
}
