using NUnit.Framework;


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Codice da eseguire prima di ogni test
        }

        [Test]
        public void Test1()
        {
            
            Assert.That("1", Is.EqualTo("1"));
        }

    }

