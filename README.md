# Property Management Web API

A RESTful backend service built for managing real estate properties and their specific features. This API supports full CRUD (Create, Read, Update, Delete) operations for properties, handles nested relational data (features), and includes file upload capabilities for property images.

## Technologies Used
* **Framework:** .NET Framework 4.8 
* **Web API:** ASP.NET Web API 2 (v5.2.9)
* **ORM:** Entity Framework 6 (v6.5.1)
* **Language:** C#

## Features
* **Entity Management:** Manage `Property` records (Title, Asking Price, Listed Date, Rental Status, Picture).
* **Relational Data:** Manage a one-to-many relationship with `Feature` records (e.g., bedrooms, pool, parking) nested within properties.
* **File Uploads:** Dedicated endpoint for uploading and saving property images locally.
* **Data Serialization:** Seamlessly accepts and returns JSON data, handling child models via view models (`PropertyInputModel`).

## Database Models

**Property**
* `PropertyId` (Primary Key)
* `Title` (String, Max 70)
* `ListedDate` (Date)
* `AskingPrice` (Money)
* `IsRental` (Boolean)
* `Picture` (String, Max 100)
* `Features` (Navigation Property)

**Feature**
* `FeatureId` (Primary Key)
* `Name` (String, Max 50)
* `Description` (String, Max 50)
* `PropertyId` (Foreign Key)

## API Endpoints

### Properties
* `GET /api/Properties`
    * Retrieves a list of all properties, including their associated features.
* `GET /api/Properties/{id}`
    * Retrieves a specific property and its features by its ID.
* `POST /api/Properties`
    * Creates a new property along with its associated features. Expects a `PropertyInputModel` payload.
* `PUT /api/Properties/{id}`
    * Updates an existing property. Replaces the old features with the new ones provided in the payload.
* `DELETE /api/Properties/{id}`
    * Deletes a property from the database.

### File Upload
* `POST /api/Properties/Image/Upload`
    * Accepts a `multipart/form-data` file upload. Generates a random filename, saves the image to the `~/Images` directory, and returns the generated filename.

## Setup Instructions
1. Clone the repository.
2. Open the `.sln` file in Visual Studio.
3. Update the `PropertyDbContext` connection string in the `Web.config` file to point to your local SQL Server instance.
4. Run `Update-Database` in the Package Manager Console to apply Entity Framework migrations and generate the database schema.
5. Build and run the project.
