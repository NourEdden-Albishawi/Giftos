# eCommerce Shop

## Overview

Welcome to the eCommerce Shop, an ASP.NET-based web application designed to provide a seamless online shopping experience. This project leverages the power of the ASP.NET framework along with the Identity Framework to ensure robust and secure authentication for users.

## Features

- **User Authentication:** Secure user registration and login using ASP.NET Identity Framework.
- **Product Management:** Comprehensive CRUD (Create, Read, Update, Delete) functionality for managing products.
- **Image Upload:** Easy upload and preview of product images.
- **Shopping Cart:** Add products to the cart and proceed to checkout.
- **Responsive Design:** Fully responsive design using Bootstrap to ensure compatibility across all devices.
- **Account Management:** Manage user profiles, including updating personal information and profile pictures.

## Technologies Used

- **ASP.NET MVC:** The core framework for building the web application.
- **ASP.NET Identity Framework:** For handling user authentication and authorization.
- **Bootstrap:** For creating a responsive and visually appealing UI.
- **Entity Framework:** For database management and operations.
- **SQL Server:** Database to store application data.

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/NourEdden-Albishawi/Giftos/
   ```
2. Navigate to the project directory:
    ```sh
    cd ecommerce-shop
    ```
3. Restore the NuGet packages:
    ```sh
    dotnet restore
    ```
4. Update the database connection string in appsettings.json to match your SQL Server configuration.

5. Apply the database migrations:
   ```sh
   dotnet ef database update
   ```
6. Run the application:
   ```sh
   dotnet run
   ```

## Usage

1. **Register a new account:** Navigate to the register page and create a new account.
2. **Login:** Use your credentials to log in.
3. **Manage Products:** As an authenticated user, you can create, edit, and delete products.
4. **Add to Cart:** Browse products and add them to your shopping cart.
5. **Checkout:** Proceed to checkout to complete your purchase.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any feature additions or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
