﻿using Utm.Builder.Core.ValueObjects.Exceptions;
using Utm.Builder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    private const string InvalidUrl = "torrest";
    private const string ValidUrl = "https://balta.io";

    [TestMethod]
    [ExpectedException(typeof(InvalidUrlException))]
    public void ShouldReturnExceptionWhenUrlIsInvalid()
    {
        new Url(InvalidUrl);
    }

    [TestMethod]
    public void ShouldNotReturnExceptionWhenUrlIsValid()
    {
        new Url(ValidUrl);
        Assert.IsTrue(true);
    }

    [TestMethod]
    [DataRow(" ", true)]
    [DataRow("http", true)]
    [DataRow("torrest", true)]
    [DataRow("https://balta.io", false)]
    public void TestUrl(
        string link,
        bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Url(link);
                Assert.Fail();
            }
            catch (InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Url(link);
            Assert.IsTrue(true);
        }
    }
}