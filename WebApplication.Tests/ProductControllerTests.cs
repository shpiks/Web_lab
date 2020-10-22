using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using WebApplication.Controllers;
using WebApplication.DAL.Data;
using WebApplication.DAL.Entities;
using Xunit;

namespace WebApplication.Tests
{
    public class ProductControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "testDb")
                            .Options;
        }

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;

            // заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context)
                {
                    ControllerContext = controllerContext
                };


                // Act
                var result = controller.Index(pageNo: page, group: null) as ViewResult;
                var model = result?.Model as List<Phone>;

                // Assert 
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].PhoneId);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }

        }



        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;

            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context)
                {
                    ControllerContext = controllerContext
                };

                var comparer = Comparer<Phone>.GetComparer((d1, d2) => d1.PhoneId.Equals(d2.PhoneId));

                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Phone>;

                // assert
                Assert.Equal(2, model.Count);
                //Assert.Equal(data[0], model[0], comparer);
                Assert.Equal(context.Phones.ToArrayAsync().GetAwaiter().GetResult()[0], model[0], comparer);
            }
        }
    }
}
