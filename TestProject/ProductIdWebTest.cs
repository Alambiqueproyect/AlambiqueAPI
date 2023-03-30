using Entities.Entities;
using Logic.Logic;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject
{
    [TestClass]
    public class ProductIdWebTest
    {

        public readonly ProductLogic _productLogic;
        [TestMethod]

        public void InsertProductItemTest()
        {

            var productToAdd = new ProductItem();
           


            productToAdd.IdWeb = Guid.NewGuid();
           


            Assert.AreNotEqual(productToAdd.IdWeb, Guid.Empty);
        }



    }

}
