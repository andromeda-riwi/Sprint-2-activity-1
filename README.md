# Sistema de Gestión de Usuarios - Sprint 2

## Descripción
Sistema completo de gestión de usuarios desarrollado en C# con .NET 8, Entity Framework Core y MySQL. Implementa un patrón de arquitectura en capas con Repository Pattern, DTOs y una interfaz de consola interactiva.

## Características Principales

### Campos Obligatorios
- **First Name** (nombre)
- **Last Name** (apellido) 
- **Username** (único, no repetido)
- **Email** (único, no repetido)

### Campos Opcionales
- Teléfono
- Dirección
- Ciudad
- Estado
- Código postal
- País
- Género
- Edad
- Contraseña

## Funcionalidades Implementadas

### 📋 Consultas Funcionales
- ✅ Listar todos los usuarios registrados
- ✅ Ver detalle de usuario por ID
- ✅ Ver detalle de usuario por correo electrónico
- ✅ Listar usuarios por ciudad específica
- ✅ Listar usuarios por país específico
- ✅ Listar usuarios mayores de edad específica
- ✅ Listar usuarios por género específico
- ✅ Mostrar nombres completos y correos (para campañas)
- ✅ Contar total de usuarios registrados
- ✅ Contar usuarios por ciudad
- ✅ Contar usuarios por país
- ✅ Ver usuarios sin teléfono registrado
- ✅ Ver usuarios sin dirección registrada
- ✅ Listar últimos usuarios registrados
- ✅ Listar usuarios ordenados alfabéticamente por apellido

### 🗑️ Módulo de Eliminación
- ✅ Eliminar usuario por ID
- ✅ Eliminar usuario por correo electrónico
- ✅ Mensaje de confirmación antes de eliminar
- ✅ Mensaje de confirmación de eliminación exitosa

### ✏️ Módulo de Actualización
- ✅ Actualizar datos del usuario
- ✅ Actualizar contraseña con confirmación
- ✅ Mensaje de confirmación de actualización

### ➕ Módulo de Inserción
- ✅ Registrar nuevo usuario
- ✅ Validación de campos obligatorios
- ✅ Rechazar registros con username/email duplicados
- ✅ Mensaje de confirmación de creación exitosa

## Arquitectura del Proyecto

```
Sprint-2/
├── Controllers/          # Controladores de la aplicación
│   └── UsersController.cs
├── Data/                 # Contexto de base de datos
│   └── UserDbContext.cs
├── DTOs/                 # Objetos de transferencia de datos
│   └── UserDTO.cs
├── Entities/             # Entidades del dominio
│   └── Users.cs
├── Menus/                # Sistema de menús de consola
│   └── MainMenu.cs
├── Repositories/         # Patrón Repository
│   ├── IUserRepository.cs
│   └── UserRepository.cs
├── Program.cs            # Punto de entrada de la aplicación
└── Sprint-2.csproj      # Archivo de proyecto
```

## Tecnologías Utilizadas

- **.NET 8.0** - Framework de desarrollo
- **Entity Framework Core 9.0.9** - ORM para acceso a datos
- **Pomelo.EntityFrameworkCore.MySql** - Proveedor MySQL para EF Core
- **Microsoft.Extensions.DependencyInjection** - Inyección de dependencias
- **MySQL** - Base de datos

## Configuración de Base de Datos

El proyecto está configurado para conectarse a una base de datos MySQL con las siguientes credenciales:
- **Servidor**: 168.119.183.3
- **Puerto**: 3307
- **Base de datos**: tren_andromeda
- **Usuario**: root

## Cómo Ejecutar

1. **Restaurar dependencias**:
   ```bash
   dotnet restore
   ```

2. **Compilar el proyecto**:
   ```bash
   dotnet build
   ```

3. **Ejecutar la aplicación**:
   ```bash
   dotnet run
   ```

## Estructura de la Base de Datos

La tabla `Users` se crea automáticamente con los siguientes campos:
- `Id` (BIGINT, PRIMARY KEY, AUTO_INCREMENT)
- `FirstName` (VARCHAR(100), NOT NULL)
- `LastName` (VARCHAR(100), NOT NULL)
- `Username` (VARCHAR(50), NOT NULL, UNIQUE)
- `Email` (VARCHAR(255), NOT NULL, UNIQUE)
- `Password` (VARCHAR(255))
- `Cellphone` (VARCHAR(20))
- `Address` (VARCHAR(500))
- `City` (VARCHAR(100))
- `State` (VARCHAR(100))
- `Zipcode` (VARCHAR(20))
- `Country` (VARCHAR(100))
- `Gender` (VARCHAR(20))
- `Age` (INT)
- `CreatedAt` (DATETIME, DEFAULT CURRENT_TIMESTAMP)
- `UpdatedAt` (DATETIME, DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)

## Patrones de Diseño Implementados

- **Repository Pattern**: Abstracción del acceso a datos
- **DTO Pattern**: Transferencia de datos entre capas
- **Dependency Injection**: Inversión de control
- **Service Layer**: Lógica de negocio en controladores

## Características de Seguridad

- Validación de campos obligatorios
- Verificación de unicidad de username y email
- Confirmación antes de operaciones destructivas
- Manejo de errores con mensajes informativos

## Interfaz de Usuario

La aplicación cuenta con un sistema de menús interactivo que incluye:
- Menú principal con opciones organizadas por categorías
- Submenús específicos para consultas, gestión y reportes
- Interfaz intuitiva con mensajes claros
- Validación de entrada de datos
- Confirmaciones para operaciones críticas