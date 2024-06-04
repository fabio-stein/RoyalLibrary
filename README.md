
# RoyalLibrary Search Application

This is a simple web application that allows users to search for books in the RoyalLibrary using a web interface. The backend API is built with .NET, and the frontend is a basic HTML page with JavaScript for interacting with the API.

## Setup and Run Instructions

To run the .NET project and access the search interface, follow these simple steps:

1. **Update the appsettings with your connection strings:**
   It is expected you already have the db setup and running locally
   
3. **Run the .NET Project:**
   ```
   dotnet run
   ```
   This will start the backend API and make it accessible at `http://localhost:5125/api/Book`.

4. **Access the Web Interface:**
   Open a web browser and go to [http://localhost:5125/index.html](http://localhost:5125/index.html) to access the RoyalLibrary search interface.

## Usage
1. Enter the search criteria for the book (Author, ISBN, Page Number, and Page Size) in the input fields provided.
2. Click the "Search" button to retrieve the search results.

Enjoy searching for books in the RoyalLibrary!
