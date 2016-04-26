using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Havid
{
    public class UrlParse
    {
        /// <summary>
        /// URL 拼接
        /// </summary>
        /// <param name="rootUrl">http://finance.ce.cn/gold/gd/</param>
        /// <param name="relativeUrl">/rolling/201602/03/t20160203_8725314.shtml</param>
        /// <returns></returns>
        public static string urlJoin(string rootUrl, string relativeUrl)
        {

            if (relativeUrl.IndexOf("http") != -1)
                return relativeUrl;

            rootUrl = rootUrl.Replace("http://", "");
            string url = string.Empty;
            //分解完整的url
            var urllist = rootUrl.Split(new string[] { @"/" }, StringSplitOptions.RemoveEmptyEntries);
            //如果是绝对路径
            if (relativeUrl.StartsWith("/"))
                url = urllist[0] + relativeUrl;
            else if (relativeUrl.StartsWith("../"))
            {
                //查看 ../ 的数目
                int n = Regex.Matches(relativeUrl, "\\.\\./").Count;
                for (int i = 0; i <= urllist.Length - n - 2; i++)
                {
                    url += urllist[i] + "/";
                }
                url += relativeUrl.Replace("../", "");
            }
            else
            {
                //平级
                for (int i = 0; i <= urllist.Length - 1 - 1; i++)
                {
                    url += urllist[i] + "/";
                }
                url += relativeUrl.Replace("../", "");
            }

            return "http://"+url;
        }
    }
}
