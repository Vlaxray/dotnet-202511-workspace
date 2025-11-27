using NUnit.Framework;
[TestFixture]
    public class YahooFinance
    {
       
        [Test]
        public void Currency()
        {
            string Currency = "USD";
            Assert.That(Currency, Is.EqualTo("USD"));
        }
    }
