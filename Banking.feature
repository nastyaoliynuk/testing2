Feature: Add Customer in Banking Project

  Scenario: Add a new customer
    Given the banking manager page is open
    And the manager logs in
    When the manager adds a new customer with first name "John", last name "Doe", and postal code "12345"
    Then a success alert is displayed with message "Customer added successfully with customer id :"
