using System;
using System.Threading.Tasks;
using NUnit.Framework;
using LaSpruca.KNIDotNet;

namespace LaSpruca.KNIDotNetTests {
    public class TestKni {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public async Task TestGetNotices() {
            var portal = new Portal("https://demo.school.kiwi/");
            var data = await portal.GetNotices(DateTime.Now);
            Console.WriteLine(data);
            Assert.Pass();
        }
        
        [Test]
        public async Task TestGetNoticesInvalidKey() {
            var portal = new Portal("https://demo.school.kiwi/", "hentai");
            var data = await portal.GetNotices(DateTime.Now);
            Console.WriteLine(data);
            Assert.Pass();
        }
    }
}