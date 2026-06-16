using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Software_Project_team2.Services
{
    public record NoticeItem(
        string Number,
        string Category,
        string Title,
        string Date,
        string Author,
        string Url,
        bool IsPinned);

    public class NoticeService
    {
        private static readonly HttpClient _http = new();

        public async Task<List<NoticeItem>> FetchAsync(string categoryId = "", string searchVal = "")
        {
            var encoded = Uri.EscapeDataString(searchVal ?? "");
            var url = $"https://www.kw.ac.kr/ko/life/notice.jsp?BoardMode=list&tpage=1" +
                      $"&searchKey=1&searchVal={encoded}&srCategoryId={categoryId}";
            try
            {
                if (!_http.DefaultRequestHeaders.Contains("User-Agent"))
                    _http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                var html = await _http.GetStringAsync(url);
                return ParseNotices(html);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[NoticeService] {ex.Message}");
                return new List<NoticeItem>();
            }
        }

        private static List<NoticeItem> ParseNotices(string html)
        {
            var result = new List<NoticeItem>();
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var items = doc.DocumentNode.SelectNodes(
                "//div[contains(@class,'board-list-box')]" +
                "//li[contains(@class,'top-notice') or .//span[normalize-space(@class)='no']]");

            if (items == null) return result;

            foreach (var item in items)
            {
                bool isPinned = item.GetAttributeValue("class", "").Contains("top-notice");

                var numNode = item.SelectSingleNode(".//span[normalize-space(@class)='no']");
                string number = isPinned ? "Notice" : (numNode?.InnerText.Trim() ?? "");

                var catNode = item.SelectSingleNode(".//strong[contains(@class,'category')]");
                string category = catNode != null
                    ? System.Net.WebUtility.HtmlDecode(catNode.InnerText).Trim()
                    : "";

                var linkNode = item.SelectSingleNode(".//div[contains(@class,'board-text')]//a");
                if (linkNode == null) continue;

                string title = string.Join(" ", linkNode.ChildNodes
                    .Where(n => n.NodeType == HtmlNodeType.Text)
                    .Select(n => System.Net.WebUtility.HtmlDecode(n.InnerText).Trim())
                    .Where(t => !string.IsNullOrWhiteSpace(t)));

                string href = linkNode.GetAttributeValue("href", "");
                string noticeUrl = href.StartsWith("http") ? href : "https://www.kw.ac.kr" + href;

                var infoNode = item.SelectSingleNode(".//p[contains(@class,'info')]");
                string date = "";
                string author = "";

                if (infoNode != null)
                {
                    string infoText = System.Net.WebUtility.HtmlDecode(infoNode.InnerText)
                        .Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Trim();

                    var parts = infoText.Split('|').Select(p => p.Trim()).ToArray();

                    foreach (var part in parts)
                    {
                        if (part.Contains("작성일"))
                        {
                            var m = Regex.Match(part, @"\d{4}-\d{2}-\d{2}");
                            if (m.Success) { date = m.Value; break; }
                        }
                    }

                    author = parts.LastOrDefault(p => !string.IsNullOrWhiteSpace(p)) ?? "";
                }

                if (!string.IsNullOrEmpty(title))
                    result.Add(new NoticeItem(number, category, title, date, author, noticeUrl, isPinned));
            }

            return result;
        }
    }
}
