# (un)Done

A gamified task manager where every completed task earns you XP, coins, and badges. Built with ASP.NET Core Web API + PostgreSQL on the backend and Angular on the frontend. Level up your productivity, one task at a time.

---

## Status

This project is currently under active development.

---

## Features

- Task management with difficulty levels (Easy, Medium, Hard) and Daily tasks
- XP and coins rewards per completed task
- Level progression system
- Streak tracking
- Automatic badge granting based on user activity
- Store with consumable and cosmetic items
- Dashboard with activity stats and progress charts

---

## Tech Stack

**Backend**
- ASP.NET Core Web API (.NET 8)
- PostgreSQL + Entity Framework Core
- Clean Architecture (Domain, Application, Infrastructure, API)
- CQRS with MediatR
- JWT Authentication
- FluentValidation
- Serilog

**Frontend**
- Angular 17+ (Standalone Components + Signals)
- Angular Material
- SCSS

---

## Project Structure

```
undone/
├── server/
│   ├── UnDone.API/
│   ├── UnDone.Application/
│   ├── UnDone.Domain/
│   └── UnDone.Infrastructure/
├── client/
├── .gitignore
└── README.md
```

---

## Getting Started

> Setup instructions will be added as the project progresses.

---

## License

This project is open source and available under the [MIT License](LICENSE).