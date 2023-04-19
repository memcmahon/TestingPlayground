using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MuffinCrud;
using MuffinCrud.DataAccess;
using MuffinCrud.Models;
using Newtonsoft.Json;
using Xunit;
using MuffinCrud.Tests;


namespace MuffinCrud.Tests.IntegrationTests
{
    public class MuffinIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public MuffinIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        private MuffinDbContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MuffinDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDatabase");

            var context = new MuffinDbContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public async Task Index_ReturnsViewWithMuffins()
        {
            var context = GetDbContext();
            context.Muffins.Add(new Muffin { Flavor = "Craisin", IsGlutenFree = false });
            context.Muffins.Add(new Muffin { Flavor = "Banana", IsGlutenFree = true });
            context.SaveChanges();

            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Muffin");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Craisin", responseString);
            Assert.Contains("Banana", responseString);
        }
    }
}
