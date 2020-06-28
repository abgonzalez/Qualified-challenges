using System;
using Canon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Canon.Challenge;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            User miguel = new User("Miguel");
            User vero = new User("Vero");
            User daniel = new User("Daniel");
         //   Moderator luis = new Moderator("Luis");
        //    Moderator luis = (Moderator) new User("Luis");
            Admin ana = new Admin("Ana");
            Comment miguelcomment=new Comment(miguel,"hola", null);
            miguelcomment.ToString();
            miguel.CanEdit(miguelcomment);
            miguel.CanDelete(miguelcomment);

        }

        [TestMethod]
        public void TestMarkdownParser()
        {
            Assert.AreEqual("<h2>Lost In Space</h2>", Challenge02.MarkdownParser("##         Lost In Space      "));
            Assert.AreEqual("<h2>smaller header</h2>", Challenge02.MarkdownParser("## smaller header"));
            Assert.AreEqual("<h6>smaller header</h6>", Challenge02.MarkdownParser("###### smaller header"));
            Assert.AreEqual("#Invalid", Challenge02.MarkdownParser("#Invalid"));
            Assert.AreEqual(" #Invalid", Challenge02.MarkdownParser(" #Invalid"));
            Assert.AreEqual("<h1>Invalid</h1>", Challenge02.MarkdownParser("# Invalid"));
            Assert.AreEqual("<h3>### smaller header</h3>", Challenge02.MarkdownParser("### ### smaller header"));
            Assert.AreEqual("####### more than h6", Challenge02.MarkdownParser("####### more than h6"));
            Assert.AreEqual("<h3>### smaller header " +
                            "### one copy" +
                            "### two copy" +
                            "### three copy" +
                            "### four copy" +
                            "### five copy" +
                            "### sixth copy" +
                            "### seventh copy" +
                            "### eighth copy" + "</h3>", Challenge02.MarkdownParser("### ### smaller header " +
                                                                                 "### one copy" +
                                                                                 "### two copy" +
                                                                                 "### three copy" +
                                                                                 "### four copy" +
                                                                                 "### five copy" +
                                                                                 "### sixth copy" +
                                                                                 "### seventh copy" +
                                                                                 "### eighth copy"));
         }
        [TestMethod]
        public void TestExamplePage()
        {
            List<int> collection = new List<int>()
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            14,15,16,17,18,19,20,21,22,23,24
        };
            var helper = new PaginationHelper<int>(collection, 10);
            Assert.AreEqual(3, helper.PageCount());
            Assert.AreEqual(2, helper.PageIndex(23));
            Assert.AreEqual(24, helper.ItemCount());
        }
        [TestMethod]
        public void TestExamplePage2()
        {
            List<char> collection = new List<char>()
        {
            'a','b','c','d','e','f'
        };
            var helper = new PaginationHelper<char>(collection, 4);
            Assert.AreEqual(2, helper.PageCount());
            Assert.AreEqual(6, helper.ItemCount());
            Assert.AreEqual(4, helper.PageItemCount(0));
            Assert.AreEqual(2, helper.PageItemCount(1));
            Assert.AreEqual(-1, helper.PageItemCount(2));
            Assert.AreEqual(1, helper.PageIndex('c'));
            Assert.AreEqual(1, helper.PageIndex(5));
            Assert.AreEqual(0, helper.PageIndex(2));
            Assert.AreEqual(-1, helper.PageIndex(20));
            Assert.AreEqual(-1, helper.PageIndex(-10));
        }
    }
}
