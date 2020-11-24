# ShoppingCart

## Problem background

We have an existing shopping cart application, with a small set of eCommerce/shopping cart rules.
Rules include calculation of total price, discount and loyalty points calculation.
Most of the business logic is implemented in single method `ShoppingCart.Checkout`.
There is a `/products` endpoint to list the products.

## Prerequisites

.NET Core 2.0

## IDE

The project is tested in the following IDE's but you should be able to use any IDE's that support .NET Core. No additional tools, frameworks or setup is needed.

* Visual Studio 2017 Community
* Visual Studio for Mac Community
* Visual Studio Code

## Command line

The commands are tested on Mac and Windows but you should be able to run them on any platforms with .NET Core 2.0.

### Run the tests

In your terminal run `dotnet test ./src/Supercon.Test`. 
The command will build the projects and run the tests. The output will show the number of passed, failed, and skipped tests.

### Run the application

In your terminal run `dotnet run -p ./src/Supercon`. Then navigate to http://localhost:5000/v1/products in your browser to test the app is running.
The command builds the projects and runs the demo application.