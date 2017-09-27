using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperPUBG.CS
{
    public class GetDiscord
    {
        public List<DiscordList> GetDiscordList()
        {
            List<DiscordList> discordlist = new List<DiscordList>();

            List<string> titlelist = new List<string>();
            List<string> linklist = new List<string>();

            //string articleReg = @"(?<=article-board m-tcol-c\"">)(.*?)(?=<\/form)";
            string articleTitleReg = @"(?<=onmouseover=\""\"" class=\""m-tcol-c\"">).*?(?=<)";
            string articleIdReg = "(?<=\"m-tcol-c list-count\">).*?(?=<)";
            string resResult;

            resResult = HttpWebReturn("http://cafe.naver.com/ArticleList.nhn?search.clubid=28866679&search.menuid=24&search.boardtype=L&search.clubid=28866679", "http://cafe.naver.com/playbattlegrounds?iframe_url=/ArticleList.nhn%3Fsearch.clubid=28866679%26search.menuid=24%26search.boardtype=L");

            Regex regTitle = new Regex(articleTitleReg); // Discord 게시글 제목

            MatchCollection matchTitle = regTitle.Matches(resResult);

            Regex regLink = new Regex(articleIdReg); // Discord 게시글 링크

            MatchCollection matchLink = regLink.Matches(resResult);

            titlelist = matchTitle.OfType<Match>().Select(m => m.Value).ToList();
            linklist = matchLink.OfType<Match>().Select(m => Cafe_DiscordLink(m.Value)).ToList();

            for (int i = 0; i < titlelist.Count; i++)
            {
                discordlist.Add(new DiscordList { DiscordTitle = titlelist[i], DiscordLink = linklist[i] });
            }

            return discordlist;
        }



        private string Cafe_DiscordLink(string url)
        {
            string RegDiscord_url = "(?<=https://discord.gg/).{0,8}(?=\")";
            string resResult;

            resResult = HttpWebReturn($"http://cafe.naver.com/ArticleRead.nhn?articleid={url}&clubid=28866679&clubid=28866679", $"http://cafe.naver.com/playbattlegrounds?iframe_url=/ArticleRead.nhn%3Farticleid={url}%26clubid=28866679");

            try
            {
                Regex regex = new Regex(RegDiscord_url);

                MatchCollection match = regex.Matches(resResult);

                resResult = $"https://discord.gg/{match[0].Value}";

                return resResult;
            }
            catch (ArgumentOutOfRangeException)
            {
                return $"http://cafe.naver.com/playbattlegrounds/{url}";
            }
        }

        private string HttpWebReturn(string url, string refer)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.Referer = refer;
            req.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            req.ContentType = "text/html;charset=ms949";
            req.Host = "cafe.naver.com";
            req.KeepAlive = true;
            req.AllowAutoRedirect = false;

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader readerPost = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("EUC-KR"), true);   // Encoding.GetEncoding("EUC-KR")
            string resResult = readerPost.ReadToEnd();
            //Getcookie = response.GetResponseHeader("Set-Cookie"); // 쿠키정보 값을 확인하기 위해서
            readerPost.Close();
            res.Close();

            return resResult;
        }

    }
}
