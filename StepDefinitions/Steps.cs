using System;
using System.Collections.Generic;
using System.Linq;
using Reqnroll;

namespace Calculator.Test.StepDefinitions
{
    [Binding]
    public sealed class Steps
    {
        // holds the "database" of the products and quantities to populate the test
        private List<ProductQuantities>? _seededProducts;
        // current product under test
        private ProductQuantities? _productUnderTest;

        private class ProductQuantities
        {
            public int ProductID { get; set; }
            public int Stock { get; set; }
            public int Basket { get; set;}
        }

        [Given("I have the following data")]
        public void GivenIHaveTheFollowingData(DataTable dataTable)
        {
            _seededProducts = dataTable.CreateSet<ProductQuantities>().ToList();
        }

        [Then("the quantities are")] 
        public void ThenTheQuantitiesAre(DataTable dataTable)
        {
            //dataTable.CompareToInstance(_productUnderTest);

            dataTable.CompareToSet(_seededProducts);
        }

        [Then("the quantities are stock level of {int} and basket qty of {int}")]
        public void ThenTheQuantitiesAreStockLevelOfAndBasketQtyOf(int stockQty, int basketQty)
        {
            // Assert.AreEqual(stockQty, _productUnderTest!.Stock);
            // Assert.AreEqual(basketQty, _productUnderTest!.Basket);
            // stockQty.Should().Equals(stockQty,  basketQty);
            
            Console.Write(12);
        }


        [Then("a message {string} is displayed to the customer")]
        public void ThenAMessageIsDisplayedToTheCustomer(string p0)
        {
           
        }

        [Given("I am on the product detail page of product {int}")]
        public void GivenIAmOnTheProductDetailPageOfProduct(int productID)
        {
           _productUnderTest = _seededProducts?.FirstOrDefault(p => p.ProductID == productID);
            if (_productUnderTest == null) throw new ArgumentNullException(nameof(_productUnderTest));
        }

        [When("I click the Add to Basket button")]
        public void WhenIClickTheAddToBasketButton()
        {
            if (_productUnderTest!.Stock > 0 && _productUnderTest!.Basket == 0)
            {
                _productUnderTest!.Stock--;
                _productUnderTest!.Basket++;
            }
        }

        [When("I remove Product Id {int} from basket")]
        public void WhenIRemoveProductIdFromBasket(int productID)
        {
            var product = _seededProducts?.FirstOrDefault(p => p.ProductID == productID);
            if (product == null) throw new ArgumentNullException(nameof(product));

            product.Basket--;
            product.Stock++;
        }


        [Given("I am on the basket page")]
        public void GivenIAmOnTheBasketPage()
        {
            
        }

    }
}

