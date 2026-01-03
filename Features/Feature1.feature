Feature: Shopping Basket
In order to amend my purchase before checking out, as a customer, I want to be able to edit my shopping basket

    Background:
        Given I have the following data
          | Product ID | Stock | Basket |
          | 1          | 2     | 0      |
          | 2          | 0     | 0      |
          | 3          | 2     | 1      |
          | 4          | 5     | 1      |

    Scenario Outline: Testing functionality of basket
        Given I am on the product detail page of product <Product ID>
        When I click the Add to Basket button
        Then the quantities are stock level of <Stock> and basket qty of <Basket>
        And a message <Message> is displayed to the customer

        Examples:
          | Test Description  | Product ID | Stock | Basket | Message               |
          | In stock          | 1          | 1     | 1      | 'Added to basket'     |
          | Not in stock      | 2          | 0     | 0      | 'Not in stock'        |
          | Already in basket | 3          | 2     | 1      | 'Limited to one only' |
       

    Scenario: Testing Remove Item from Basket
        Given I am on the basket page
        When I remove Product Id 3 from basket
        And I remove Product Id 4 from basket
        Then the quantities are
          | Product ID | Stock | Basket |
          | 1          | 2     | 0      |
          | 2          | 0     | 0      |
          | 3          | 3     | 0      |
          | 4          | 6     | 0      |