# Book Reservation API

This is a .NET 8 backend API designed to manage book reservations for a library system. It allows users to view available books, make reservations, and calculate the total cost of reservations.

## Features
- Retrieve a list of all available books.
- Make reservations for physical books or audiobooks.
- Calculate the total amount for reservations based on selected options.
- Quick pickup option for expedited processing.

## API Endpoints
1. **Get All Books**: `GET /api/Book` - Retrieve a list of all books in the system. Response Type: Array of objects with properties such as: `id` (number), `title` (string), `author` (string), `year` (number), `imageUrl` (string).
2. **Get All Reservations**: `GET /api/Reservation/all` - Retrieve a list of all reservations made. Response Type: Array of objects with properties such as: `id` (number), `title` (string), `type` (string), `reservationDays` (number), `isQuickPickup` (boolean).
3. **Calculate Total Amount**: `POST /api/Calculation/calculateTotal` - Request Body: `{ "title": "The Invisible Man", "type": "physical", "reservationDays": 3, "isQuickPickup": true }` Description: Calculate the total amount for a reservation. Response Type: Object with property `totalAmount` (number).
4. **Make Reservation**: `POST /api/Reservation/makeReservation` - Request Body: `{ "title": "The Invisible Man", "type": "physical", "reservationDays": 3, "isQuickPickup": true }` Description: Create a new reservation if the book is not already reserved. Response Type: Object with property `success` (boolean) and `message` (string).

## Technologies Used
- .NET 8
- C#
- Entity Framework Core
- ASP.NET Core Web API

## Setup Instructions
1. Clone the repository to your local machine: `git clone <repository-url>` `cd <project-directory>`
2. Run `dotnet restore` to install the required dependencies.


## Usage
To run the API locally, use the following command: `dotnet run`. The API will be available at `https://localhost:7040`. You can use tools like Postman or cURL to interact with the API endpoints.

