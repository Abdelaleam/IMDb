# IMDb Ratings and Reviews for Movies & TV Shows

## Description

This project is a desktop application developed using C# and Windows Forms. It serves as a platform for users to browse movies, view details, manage a personal watchlist, and potentially review/rate movies (review/rate functionality inferred from form names like `Review.cs`, `Rate.cs`, `ManageReviews.cs`). The application also includes an administrative interface for managing movies, users, and reviews, along with reporting capabilities. It connects to an Oracle database to store and retrieve information.

## Features

### User Features:
*   **Authentication:** Secure Sign-in and Sign-up functionality.
*   **Movie Browsing:**
    *   Search for movies by title with auto-suggestions.
    *   Browse movies categorized by genre.
*   **Movie Details:** View detailed information about a selected movie, including description, genre, release date, and actors.
*   **Watchlist:** Add movies to a personal watchlist.
*   **Reviews & Ratings:** (Inferred) Users can likely view and submit movie reviews and ratings.

### Admin Features:
*   **Dashboard:** Central interface for administrative tasks.
*   **Movie Management:** Add, update, or remove movie entries in the database. Manage movie actors.
*   **User Management:** Manage user accounts.
*   **Review Management:** Manage user-submitted reviews.
*   **Reporting:**
    *   Generate reports based on movie ratings (using `RateReportDetails.cs`).
    *   Generate Crystal Reports for potentially other insights (using `CR_Report.cs`, `CrystalReport1.rpt`, `CrystalReport2.rpt`).

## Technology Stack

*   **Language:** C#
*   **Framework:** .NET Framework (Windows Forms)
*   **Database:** Oracle Database (using `Oracle.DataAccess.dll`)
*   **Reporting:** SAP Crystal Reports

## Project Structure

The project follows a typical Windows Forms application structure:

*   `/Sw project/Sw project/`: Main project directory containing:
    *   **Forms:** (.cs and .Designer.cs files) Defines the user interface windows (e.g., `MAIN.cs`, `signin.cs`, `AdminForm.cs`, `MovieDetailes.cs`).
    *   **Models:** (.cs files within subdirectories like `/Movies`, `/Users`) Defines data structures (e.g., `Movie.cs`, `User.cs`).
    *   **Database Connection:** (`ordbCon.cs`) Handles the connection to the Oracle database. Contains logic for database operations, often utilizing stored procedures (e.g., `search_movies_by_title`, `add_to_watchlist`, `ACT_NAMES`).
    *   **Properties:** Contains assembly information and project settings.
    *   **Resources:** Stores images and other resources used by the application.
    *   **Reports:** (.rpt files) Crystal Reports definitions (`CrystalReport1.rpt`, `CrystalReport2.rpt`).
*   `/Sw project/Sw project/bin/Debug/`: Contains necessary DLLs, including Oracle Data Access and Crystal Reports libraries.

## Setup and Running

1.  **Prerequisites:**
    *   Microsoft Visual Studio (with .NET Framework development tools).
    *   Oracle Database instance accessible.
    *   Oracle Client tools (including `Oracle.DataAccess.dll`) installed and configured.
    *   SAP Crystal Reports runtime/SDK for Visual Studio.
2.  **Database Setup:** The application relies on an Oracle database with a specific schema, tables (e.g., `Movies`, `Users`, `Actors`, `Movie_Actors`, `Watchlist`, potentially `Reviews`, `Ratings`), and stored procedures (e.g., `search_movies_by_title`, `add_to_watchlist`, `ACT_NAMES`). The connection string needs to be configured correctly in `ordbCon.cs` or application configuration files.
3.  **Running:** Open the `Sw project.sln` file in Visual Studio and build the solution. Run the project (usually by pressing F5). The main application window (`MAIN.cs`) should appear.

## Database Interaction

The application interacts heavily with an Oracle database via the `Oracle.DataAccess.Client` library. Key operations include:
*   Fetching movie data based on title or genre.
*   Retrieving movie details and associated actors.
*   User authentication.
*   Managing watchlist entries.
*   CRUD operations for movies, users, and reviews (Admin).
*   Execution of stored procedures for various functionalities.

## Reporting

The application utilizes SAP Crystal Reports for generating reports, specifically:
*   A report related to movie ratings (`RateReportDetails.cs`).
*   At least two other custom Crystal Reports (`CrystalReport1.rpt`, `CrystalReport2.rpt`) accessible via the admin panel (`CR_Report.cs`).



## Team Members

*   Rana Ahmed Mohamed Atef
*   Shahd Mohamed Ali Zainhom
*   Abdelaleam Ehab AbdelFattah
*   Ashraf Khaled gabr
*   Basel Mohamed AbdelFattah
*   Ismail Mohamed Ismail
*   Islam Ahmed Adel Mohamed

