using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace UrlParse
{
    [TestFixture]
    public class urljointest
    {

        [Test]
        public void urljointestt()
        {
            string url1 = "http://finance.ce.cn/gold/gd/a.html";
            string url2 = "rolling/201602/03/t20160203_8725314.shtml";

            string s=Havid.UrlParse.urlJoin(url1, url2);


            Assert.AreEqual("333", s); 

        }

    }
}
