Feature: Checkout functionality

  Scenario: Successful checkout with valid user
    Given I login with valid credentials
    When I add a product to the cart
    And I proceed to checkout
    And I enter checkout details
    And I confirm the order
    Then I should see order confirmation message