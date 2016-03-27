Instructions: 
----------------------------------------------------------------------------------------------------------
  

1.  Implement the `IShoppingCart` and `IPricingService` interfaces.  Feel free to annotate the implementation with commentary
	on the benefits of design choices and/or acknowledgement of potential issues and/or extensions.
  

2.  Encapsulate these implementations with a web service located at "~/Shopping" that accepts JSON input and can be hosted on IIS.  
	The Shopping service needs the ability to: 
   - add item(s) 
   - remove item(s) 
   - list the items in a user's shopping cart 
   - retrieve the total price of the user's shopping cart      


3.  Create a single-page website that calls the web service using AJAX forms 


    A. **Add to Cart**
       - Form Elements
         - Product
           - `[DropdownInput]` 
           - select one from { "Thermometer", "First Aid Kit", "Advil" }
         - Quantity
           - `[QuantityInput]` 
           - non-negative integer
         - `[SubmitButton]`
       - Example Result: 

            { 
              "success" : true, 
              "message" : "2 thermometers were added to the shopping cart." 
            }


    B.  **Remove from Cart**
       - Form Elements
         - Product
           - `[DropdownInput]` 
           - select one from { "Thermometer", "First Aid Kit", "Advil" }
         - Quantity
           - `[QuantityInput]` 
           - non-negative integer
         - `[SubmitButton]`
       - Example Result: 

            { 
              "success" : true, 
              "message" : "1 first aid kit was removed from the shopping cart." 
            }


    C.  **Count**
       - Form Elements
         - Product
           - `[DropdownInput]` 
           - select one from { "Thermometer", "First Aid Kit", "Advil" }
         - `[SubmitButton]`
       - Example Result: 

            { 
              "success" : true, 
              "message" : "The shopping cart contains 3 thermometers.", 
              "quantity": 3
            }


    D.  **List**
       - Form Elements
         - Product
           - `[DropdownInput]` 
           - select one from { "Thermometer", "First Aid Kit", "Advil" }
         - `[SubmitButton]`
       - Example Result: 

            { 
              "success" : true, 
              "message" : "The shopping cart contains 5 items.", 
              "items"   : [ 
                            { 
                              "product"  : "Thermometer", 
                              "quantity" : 1 
                            }, 
                            { 
                              "product"  : "Advil", 
                              "quantity" : 4 
                            } 
                          ]
            }

    E.  **Price**
       - Form Elements
         - `[SubmitButton]`
       - Example Result: 

            { 
              "success" : true, 
              "message" : "The shopping cart total is $4.89", 
              "price"   : 4.89 
            }

       
  Only the minimum amount of time should be spent on formatting the view or the results.  The only requirement for this part of the exercise is that 
  the form is functional and the result is visible. 
  
  
4.  **Business Rules** 
  
   A. Every time a new customer visits the website they are assigned an A/B testing profile.
	Their profile must remain constant while they are using the site so some kind of "user session" must exist. 
  
   B.  The price of every product is marked up 3% for customers with profile B.  
	So, if an Advil product costs $5.00 for a customer with profile A, the same product costs $5.15 for a customer with profile B. 
  
   C.  The price for a product should be a distinct non-negative decimal value. 
  
5. **Additional Notes** 
   - If there isn't enough time to complete everything that you would like to, you may include notes and/or diagrams to explain the rest of the implementation plan.  
   - There are no restrictions on the use of external open source libraries that can be used. 
  
