# Introduction

The **User Management System – Sprint 2** is a console application developed in **C# / .NET 8**, designed to handle users with CRUD operations (create, read, update, delete) and specialized queries (by city, country, gender, etc.).  

## Objectives

- Implement a modular, maintainable system with layered architecture.  
- Interact with a **MySQL** database using **Entity Framework Core**.  
- Apply good development practices: DTOs, repositories, separation of concerns.  

## High-Level Architecture

```mermaid
flowchart TD
UI[Console (Menus)] --> Controllers
Controllers --> Services
Services --> Repositories
Repositories --> DB[(MySQL)]
