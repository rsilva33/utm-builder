using Utm.Builder.Core.ValueObjects.Exceptions;
using Utm.Builder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class CampaignTests
{
    [TestMethod]
    [DataRow("", "", "", true)]
    [DataRow("src", "", "", true)]
    [DataRow("src", "med", "", true)]
    [DataRow("src", "med", "nme", false)]
    public void TestCampaign(
        string source,
        string medium,
        string name,
        bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Campaign(source, medium, name);
                Assert.Fail();
            }
            catch (InvalidCampaignException)
            // Determina que inspecione e hava e algum tipo de situacao
            //when(e.Message == "Source ir invalid")
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Campaign(source, medium, name);
            Assert.IsTrue(true);
        }
    }
}
