namespace AngleSharp.Core.Tests.Html
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class InnerText
    {

        // text & spaces
        [TestCase("test", "test")]
        [TestCase("  test  ", "test")]
        [TestCase("  ", "")]
        [TestCase("&nbsp;&nbsp;", "  ")] // these are non breaking spaces
        [TestCase(" &nbsp; test &nbsp; ", "  test  ")]
        [TestCase(" 1&nbsp;2 <span> 3&nbsp;4  5&nbsp;6 </span>7&nbsp;8 ", "1 2 3 4 5 6 7 8")]
        [TestCase("<span> test 1 </span><span> test 2 </span><span> test 3 </span>", "test 1 test 2 test 3")]
        [TestCase("<span> test 1 <span></span></span>", "test 1")]
        [TestCase("test1 <br> test2 <br> test3", "test1\ntest2\ntest3")]
        // paragraph
        [TestCase("<p>test</p>", "test")]
        [TestCase("<p>test1</p><p>test2</p>", "test1\n\ntest2")]
        // block-level
        [TestCase("<div>test1</div><div>test2</div><div>test3</div>", "test1\ntest2\ntest3")]
        [TestCase(@"test1<span style=""display:block"">test2</span>test3", "test1\ntest2\ntest3")]
        // line break
        [TestCase("test1<br>test2<br>test3", "test1\ntest2\ntest3")]
        // table
        [TestCase("<table><tr><td>1</td><td>2</td></tr><tr><td>3</td><td>4</td></tr></table>", "1\t2\n3\t4")]
        [TestCase("<table><tr><td>1</td><td>2</td></tr><tr><td><table><tr><td>3</td><td>4</td></tr></table></td><td>5</td></tr></table>", "1\t2\n\n3\t4\n\t5")]
        // select
        [TestCase("<select><option>test1</option><option>test2</option></select>", "test1\ntest2")]
        // style visibility
        [TestCase(@"<div hidden style=""display:block;"">test1<br>test2<div>test3</div></div>", "test1\ntest2\ntest3")]
        [TestCase(@"<div hidden style=""visibility:visible;"">test1<br>test2<div>test3</div></div>", "")]
        [TestCase("<div hidden>test1<br>test2<div>test3</div></div>", "")]
        [TestCase(@"<div style=""display:none"">test1<br>test2<div>test3</div></div>", "")]
        [TestCase(@"<div hidden style=""display:block;visibility:hidden;"">test1<br>test2<div>test3</div></div>", "")]
        [TestCase(@"<div hidden style=""display:none;visibility:visible;"">test1<br>test2<div>test3</div></div>", "")]
        // style text-transform
        [TestCase(@"<span style=""text-transform:uppercase"">test</span>", "TEST")]
        [TestCase(@"<span style=""text-transform:lowercase"">TEST</span>", "test")]
        [TestCase("<span style=\"text-transform:capitalize\">test1 test2\ntest3&nbsp;test4</span>", "Test1 Test2 Test3 Test4")]
        [TestCase(@"<div style=""text-transform:lowercase"">TEST1<span>TEST2</span></div>", "test1test2")]
        [TestCase(@"<div style=""text-transform:lowercase"">TEST1<span style=""text-transform:uppercase"">test2</span></div>", "test1TEST2")]
        // style white-space
        [TestCase("t e  s\tt1\ntest2", "t e s t1 test2")]
        [TestCase("<span style=\"white-space:normal\">t e  s\tt1\ntest2</span>", "t e s t1 test2")]
        [TestCase("<span style=\"white-space:nowrap\">t e  s\tt1\ntest2</span>", "t e s t1 test2")]
        [TestCase("<span style=\"white-space:pre-line\">t e  s\tt1\ntest2</span>", "t e s t1\ntest2")]
        [TestCase("<span style=\"white-space:pre\">t e  s\tt1\ntest2</span>", "t e  s\tt1\ntest2")]
        [TestCase("<span style=\"white-space:pre-wrap\">t e  s\tt1\ntest2</span>", "t e  s\tt1\ntest2")]
        // no css box
        [TestCase("<textarea>test</textarea>", "")]
        [TestCase("<script>test</noscript>", "")]
        [TestCase("<style>test</style>", "")]
        public void GetInnerText(String fixture, String expected)
        {
            var config = Configuration.Default.WithCss();
            var doc = (fixture).ToHtmlDocument(config);

            Assert.AreEqual(expected, doc.Body.InnerText);
        }

        [TestCase(null, "", "")]
        [TestCase("", "", "")]
        [TestCase("test", "test", "test")]
        [TestCase("test1\ntest2\ntest3", "test1\ntest2\ntest3", "test1<br>test2<br>test3")]
        [TestCase("te\rst1\r\ntest2\ntest3\r", "te\nst1\ntest2\ntest3\n", "te<br>st1<br>test2<br>test3<br>")]
        [TestCase("te st1\nte  st2\nte   st3", "te st1\nte st2\nte st3", "te st1<br>te  st2<br>te   st3")]
        public void SetInnerText(String fixture, String expectedInnerText, String expectedHtml)
        {
            var doc = ("<div>sample content</div>").ToHtmlDocument();

            doc.Body.InnerText = fixture;

            Assert.AreEqual(expectedInnerText, doc.Body.InnerText);
            Assert.AreEqual(expectedHtml, doc.Body.InnerHtml);
        }


        [Test]
        public void GetInnerText_Custom1()
        {
            var doc = @"
<div>
    <div>
        <div>
            <div><b><span>Product</span></b><b><span> and Project NCC Reporting&nbsp; <span>006.2022</span></span></b><span></span><br><span>SE GP T </span><span>Overview</span><span> all BUs (1/2)</span><br></div>
        </div>
    </div>
</div>".ToHtmlDocument();


            Assert.AreEqual("Product and Project NCC Reporting  006.2022\nSE GP T Overview all BUs (1/2)\n", doc.Body.InnerText);

        }

        [Test]
        public void GetInnerText_Custom2()
        {
            var doc = @"
<div id=""sapbi_snippet_STECKBRIEF_COMMENT_DETAIL1_A""><!-- AGIMENDO.process Comment WebItem Start -->

<div id=""AGIMENDO_ANNOTATE_comment_0000123057"">







  

  <div class=""myComment"" style=""width: 710;"">

    <div class=""myComment"">

<div class=""myComment"">

<div class=""myComment"">

<div class=""myComment"">

<div class=""myComment"">

<div class=""myComment"">

<div class=""myComment"">

<div class=""myComment"">

<div class=""myComment""><br>

<p align=""left"">Die Änderung des Rechnungszinssatzes (RZ) wirkt sich wegen deren Langfristigkeit nicht unwesentlich auf die Höhe der Jubiläums- und Beihilferückstellungen aus. Dabei erhöhen sich die Rückstellungen bei einem sinkenden RZ, vice versa.</p>

<p align=""left"">In Q2.2020 wurde die Berechnung auf die Methodik des Szenario- und Simulationsmodells umgestellt, so dass daraus ein Bruch in der Berechnung resultiert. Die Darstellung des Nettorisikos&nbsp;erfolgt auf Grundlage einer&nbsp;VaR-Berechnung für einen Zeithorizont von 12 Monaten.</p>

<p align=""left"">Das Risiko ist EBT-wirksam.&nbsp;Aufgrund der Ableitung des Nettorisikos auf Basis einer VaR-Berechnung ist ein Erwartungswert des Risikos derzeit nicht aussagekräftig.</p>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

  </div>

  





<form id=""AGIMENDO_ANNOTATE_comment_form_0000123057"" style=""display: none;""><textarea id=""AGIMENDO_ANNOTATE_textarea_0000123057""></textarea></form>

</div>



<!-- AGIMENDO.process Comment WebItem End -->

</div>
".ToHtmlDocument();


            Assert.AreEqual("\n\n\nDie Änderung des Rechnungszinssatzes (RZ) wirkt sich wegen deren Langfristigkeit nicht unwesentlich auf die Höhe der Jubiläums- und Beihilferückstellungen aus. Dabei erhöhen sich die Rückstellungen bei einem sinkenden RZ, vice versa.\n\nIn Q2.2020 wurde die Berechnung auf die Methodik des Szenario- und Simulationsmodells umgestellt, so dass daraus ein Bruch in der Berechnung resultiert. Die Darstellung des Nettorisikos erfolgt auf Grundlage einer VaR-Berechnung für einen Zeithorizont von 12 Monaten.\n\nDas Risiko ist EBT-wirksam. Aufgrund der Ableitung des Nettorisikos auf Basis einer VaR-Berechnung ist ein Erwartungswert des Risikos derzeit nicht aussagekräftig.", doc.Body.InnerText);
        }

        [Test]
        public void GetInnerText_Custom3()
        {
            var doc = @"
<div style=""vertical-align:middle;line-height:16px;width:285px;height:51px;max-width:285px;padding-left:5px;padding-right:5px;padding-top:0px;"" class=""cellBorders""><div style=""max-height:51px;""><div style=""line-height:;font-size:;"" tabindex=""0"" class=""sapReportEngineTitle"">Planned_Events_Sample</div><div class=""sapReportEngineTokenContainer""><div style=""line-height:;text-align:left;vertical-align:middle;"" class=""sapReportEngineCurrencyFilterToken sapReportEngineToken""><span id=""dataRegion_15801313570929-__table0-currencyToken"" title=""in USD"" tabindex=""0"" class=""currencyToken sapReportEngineSubtitle"">in USD</span></div><div class=""sapReportEngineDatasetToken sapReportEngineToken""><div class=""sapReportEngineTokenSeparator""></div><span id=""dataRegion_15801313570929-__table0-datasetIcon"" data-regionkey=""dataRegion_15801313570929"" class=""sapReportEngineDatasetIcon""></span></div></div></div></div>
".ToHtmlDocument();

            Assert.AreEqual("Planned_Events_Sample\nin USD", doc.Body.InnerText);
        }

    }
}
