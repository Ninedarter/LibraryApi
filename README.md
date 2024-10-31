# Book Reservation API

This is a .NET 8 backend API designed to manage book reservations for a library system. It allows users to view available books, make reservations, and calculate the total cost of reservations.

## Table of Contents
- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Technologies Used](#technologies-used)
- [Setup Instructions](#setup-instructions)
- [Configuration](#configuration)
- [Usage](#usage)
- [License](#license)

## Features
- Retrieve a list of all available books.
- Make reservations for physical books or audiobooks.
- Calculate the total amount for reservations based on selected options.
- Quick pickup option for expedited processing.

## Getting Started
To get started with the Book Reservation API, follow the instructions below to set up your development environment.

## API Endpoints
### 1. Get All Books
- **Endpoint:** `GET /api/Book`
- **Description:** Retrieve a list of all books in the system.
- **Response Type:** Array of objects with properties such as:
  - `id` (number)
  - `title` (string)
  - `author` (string)
  - `year` (number)
  - `imageUrl` (string)

### 2. Get All Reservations
- **Endpoint:** `GET /api/Reservation/all`
- **Description:** Retrieve a list of all reservations made.
- **Response Type:** Array of objects with properties such as:
  - `id` (number)
  - `title` (string)
  - `type` (string)
  - `reservationDays` (number)
  - `isQuickPickup` (boolean)

### 3. Calculate Total Amount
- **Endpoint:** `POST /api/Calculation/calculateTotal`
- **Request Body:**
  ```json
  {
    "title": "The Invisible Man",
    "type": "physical",
    "reservationDays": 3,
    "isQuickPickup": true
  }
