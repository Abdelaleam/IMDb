# IMDb: Ratings and Reviews for Movies & TV Shows

## Description

This project is a C# Windows Forms desktop application designed to function similarly to IMDb, allowing users to browse movies and TV shows, read and submit ratings and reviews, and manage a personal watchlist. The system features a structured Oracle database backend and provides distinct functionalities for regular users and administrators.

## Features

### User Features:
*   **Authentication:** Secure Sign-in and Sign-up functionality (`sign_in` procedure).
*   **Movie Browsing:**
    *   Search for movies by title with auto-suggestions (`search_movies_by_title` procedure).
    *   Browse movies categorized by genre.
*   **Movie Details:** View detailed information about a selected movie, including description, genre, release date, and actors (`ACT_NAMES` procedure).
*   **Ratings:** Submit and update movie ratings on a scale of 0.0 to 10.0 (`submit_rating` procedure, `Ratings` table).
*   **Reviews:** Write, submit, and update movie reviews (`submit_review` procedure, `Reviews` table).
*   **Watchlist:** Add movies to a personal watchlist (`add_to_watchlist` procedure, `Watchlist` table).
*   **Report Reviews:** Report inappropriate reviews for administrator moderation (`submit_Report` procedure).

### Admin Features:
*   **Dashboard:** Central interface for administrative tasks (`AdminForm.cs`).
*   **Movie Management:** Add, update, or remove movie entries and manage associated actors (`ManageMovies.cs`, `Movies`, `Actors`, `Movie_Actors` tables).
*   **User Management:** Manage user accounts, including banning/unbanning users based on policy violations (`ManageUsers.cs`, `Users` table - `ban` column).
*   **Review Management:** Moderate and remove inappropriate or reported reviews (`ManageReviews.cs`, `Reviews` table - `is_bad` column, `v_count` column).
*   **Reporting:**
    *   Generate reports based on movie ratings (`RateReportDetails.cs`, `CrystalReport1.rpt`).
    *   Generate Crystal Reports for Movies analysis (`Report_Review.cs`, `CrystalReport2.rpt`).

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
    *   **Database Connection:** (`ordbCon.cs`) Handles the connection to the Oracle database. Contains logic for database operations, often utilizing stored procedures.
    *   **Properties:** Contains assembly information and project settings.
    *   **Resources:** Stores images and other resources used by the application.
    *   **Reports:** (.rpt files) Crystal Reports definitions (`CrystalReport1.rpt`, `CrystalReport2.rpt`).
*   `/Sw project/Sw project/bin/Debug/`: Contains necessary DLLs, including Oracle Data Access and Crystal Reports libraries.

## Database Schema

The application utilizes an Oracle database with the following key tables:

*   **Users:** Stores user information including ID, username, password (hashed/plain - check implementation), email, role (USER/ADMIN), creation date, ban status, and reported count.
*   **Movies:** Contains movie details like ID, title, genre, release date, and description.
*   **Actors:** Stores actor information (ID, name).
*   **Movie_Actors:** Maps actors to movies (many-to-many relationship).
*   **Reviews:** Holds user reviews, linking users and movies. Includes review text, date, a flag for inappropriate content (`is_bad`), and a report count (`v_count`).
*   **Ratings:** Stores user ratings for movies, linking users and movies. Includes the rating value (0.0-10.0) and date.
*   **Watchlist:** Manages users' personal watchlists, linking users and movies.

**Sequences & Triggers:** The database uses sequences (`User_seq`, `movie_seq`, `act_seq`) and corresponding triggers (`User_trigger`, `movie_trigger`, `act_trigger`) to automatically generate primary keys for the `Users`, `Movies`, and `Actors` tables respectively.

## Database Interaction

The application interacts heavily with the Oracle database via `Oracle.DataAccess.Client` and stored procedures. Key procedures include:

*   `sign_in`: Authenticates users.
*   `get_user`: Retrieves user details.
*   `search_movies_by_title`: Finds movies based on title search.
*   `ACT_NAMES`: Gets actors associated with a movie.
*   `add_to_watchlist`: Adds a movie to a user's watchlist.
*   `submit_rating`: Submits or updates a user's movie rating.
*   `submit_review`: Submits or updates a user's movie review.
*   `submit_Report`: Flags a review as inappropriate and increments user's reported count.

## Setup and Running

1.  **Prerequisites:**
    *   Microsoft Visual Studio (with .NET Framework development tools).
    *   Oracle Database instance accessible.
    *   Oracle Client tools (including `Oracle.DataAccess.dll`) installed and configured.
    *   SAP Crystal Reports runtime/SDK for Visual Studio.
2.  **Database Setup:** Execute the SQL scripts found in the provided [SQL.pdf](https://github.com/Abdelaleam/IMDb/blob/main/Docs/SQL.pdf)
 (or equivalent .sql file) to create the necessary tables (`Users`, `Movies`, `Actors`, `Movie_Actors`, `Reviews`, `Ratings`, `Watchlist`), sequences, triggers, and stored procedures. Configure the database connection string within the application (likely in `ordbCon.cs` or an `App.config` file).
3.  **Running:** Open the `Sw project.sln` file in Visual Studio and build the solution. Run the project (usually by pressing F5). The main application window (`MAIN.cs`) should appear.

## Team Members

*   Rana Ahmed Mohamed Atef
*   Shahd Mohamed Ali Zainhom
*   Abdelaleam Ehab AbdelFattah
*   Ashraf Khaled gabr
*   Basel Mohamed AbdelFattah
*   Ismail Mohamed Ismail
*   Islam Ahmed Adel Mohamed

