# Database Model

The main entity is `Users`.

| Field       | SQL Type     | Notes                           |
|-------------|--------------|---------------------------------|
| Id          | BIGINT       | PK, AUTO_INCREMENT              |
| FirstName   | VARCHAR(100) | NOT NULL                        |
| LastName    | VARCHAR(100) | NOT NULL                        |
| Username    | VARCHAR(50)  | NOT NULL, UNIQUE                |
| Email       | VARCHAR(255) | NOT NULL, UNIQUE                |
| Password    | VARCHAR(255) |                                 |
| City        | VARCHAR(100) | Optional                        |
| Country     | VARCHAR(100) | Optional                        |
| Gender      | VARCHAR(20)  | Optional                        |
| Age         | INT          | Optional                        |
| CreatedAt   | DATETIME     | DEFAULT CURRENT_TIMESTAMP       |
| UpdatedAt   | DATETIME     | ON UPDATE CURRENT_TIMESTAMP     |

> This table is generated via **Entity Framework Core** migrations.
