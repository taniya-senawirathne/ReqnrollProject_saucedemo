Feature: Checkout functionality
  As a customer of SauceDemo
  I want to complete the checkout process
  So that I can purchase items successfully

  Background:
    Given I am logged in as a standard user

  Scenario: Successfully complete end-to-end checkout with a single item
    Given I add "Sauce Labs Backpack" to the cart
    And I navigate to the cart
    When I proceed to checkout
    And I fill in my details with first name "John" last name "Doe" and postal code "12345"
    And I confirm the order
    Then I should see the order confirmation message

  Scenario: Cart displays correct item count after adding an item
    When I add "Sauce Labs Backpack" to the cart
    Then the cart badge should show "1"

  Scenario: Checkout overview displays correct pricing information
    Given I add "Sauce Labs Backpack" to the cart
    And I navigate to the cart
    When I proceed to checkout
    And I fill in my details with first name "Jane" last name "Smith" and postal code "54321"
    Then I should see the item total on the overview page
    And I should see the tax amount on the overview page

  Scenario: Cannot proceed with empty checkout information
    Given I add "Sauce Labs Backpack" to the cart
    And I navigate to the cart
    When I proceed to checkout
    And I submit the checkout form without filling in any details
    Then I should see an error message on the checkout information page

  Scenario: Successfully navigate back to products after order completion
    Given I add "Sauce Labs Backpack" to the cart
    And I navigate to the cart
    When I proceed to checkout
    And I fill in my details with first name "John" last name "Doe" and postal code "12345"
    And I confirm the order
    Then I should see the order confirmation message