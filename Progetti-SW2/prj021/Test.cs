using System;
using NUnit.Framework;
namespace Test
{
        class Program
        {
                static void Main(string[] args)
                {
                        Console.WriteLine("Hello World!");
                }
                [Test]
                public void Test1()
                {
                        Assert.That("2", Is.EqualTo("2"));
                }
        }
}
