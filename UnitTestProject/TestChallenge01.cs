using System.Collections.Generic;
using NUnit.Framework;
using System;
[TestFixture]
public class MarkdownParserTest
{
  [Test]
  public void BasicValidCases()
  {
    Assert.AreEqual("<h1>header</h1>", Challenge.MarkdownParser("# header"));
    Assert.AreEqual("<h2>smaller header</h2>", Challenge.MarkdownParser("## smaller header"));
  }
  [Test]
  public void BasicInvalidCases()
  {
    Assert.AreEqual("#Invalid", Challenge.MarkdownParser("#Invalid"));
  }
}