# GamingApi: Summary

This project demonstrates an **on-premise deployment** of a C# ASP.NET Core API designed to manage a list of video games. It integrates with a SQL database (SQL Server) and uses GitHub Actions for automated deployment.

## Key Features

- **CRUD Operations**: Add, view, update, and delete video game entries.
- **Database Integration**: Uses SQL Server for data persistence.
- **On-Premise Hosting**: Designed to run on a Linux server.
- **Automated Deployment**: GitHub Actions pipeline for seamless updates.

## Tech Stack

- **Backend**: C# with ASP.NET Core.
- **Database**: SQL Server or PostgreSQL.
- **CI/CD**: GitHub Actions with self-hosted runner support.
- **Web Server**: Nginx reverse proxy.

## Getting Started

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/VideoGameApi.git
   ```
2. **Set Up the API**:
   - Install .NET SDK, SQL Server/PostgreSQL, and Nginx on your Linux server.
   - Add database connection details in `appsettings.json`.
3. **Push Changes to GitHub**:
   ```bash
   git add .
   git commit -m "Initial setup"
   git push origin main
   ```
4. **Deploy Automatically**:
   - GitHub Actions workflow automates deployment to your server.
   - Configure secrets for server IP, username, and password.

## API Endpoints

- **GET /api/games**: Retrieve all games.
- **POST /api/games**: Add a new game.
- **PUT /api/games/{id}**: Update a game.
- **DELETE /api/games/{id}**: Delete a game.

/src
  /Domain
    - Entities/
      - Game.cs
    - Interfaces/
      - IGameRepository.cs
  /Application
    - Services/
      - GameService.cs
    - DTOs/
      - GameDto.cs
    - Interfaces/
      - IGameService.cs
  /Infrastructure
    - Persistence/
      - GameContext.cs
      - GameRepository.cs
    - Migrations/
  /API
    - Controllers/
      - GamesController.cs
    - Program.cs
    - appsettings.json

## Deployment Notes
- Ensure the server has the necessary prerequisites installed:
  - **.NET SDK**
  - **Nginx**
  - **SQL Server/PostgreSQL**
- Use `systemd` for managing the API as a service.
## Contributing

Feel free to fork this repository and submit pull requests for any improvements or new features.

## License

This project is open-source and available under the [MIT License](LICENSE).


