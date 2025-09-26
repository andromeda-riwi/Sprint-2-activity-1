# Architecture

The project follows a **layered architecture**:

- **Entities** → Represent the database models.  
- **DTOs** → Data Transfer Objects, to control the flow of data.  
- **Repositories** → Handle database operations.  
- **Controllers** → Contain business logic and orchestrate actions.  
- **Menus** → Define the console user interface.  
- **Data** → Configure the database context.  

## Repository Pattern

The repository layer decouples business logic from database access, improving maintainability and testability.
