<div align="center">

# ✺ BookNest

### A little space for big stories.

A cosy, local-first reading tracker built with **C# · ASP.NET Core MVC · Entity Framework Core · SQLite**.

![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![C%23](https://img.shields.io/badge/C%23-ASP.NET_Core_MVC-563D7C)
![EF Core](https://img.shields.io/badge/Entity_Framework_Core-10-559E83)
![SQLite](https://img.shields.io/badge/SQLite-Local_Database-003B57?logo=sqlite)
![Status](https://img.shields.io/badge/Status-Local_MVP-C87960)

[**Developer Portfolio**](https://st10458151.github.io/developer-portfolio/) · [**GitHub Profile**](https://github.com/ST10458151)

</div>

---

## About BookNest

**BookNest** is an ASP.NET Core MVC reading journal for organising personal books, tracking reading progress and recording personal ratings.

It demonstrates **full-stack MVC architecture, server-side CRUD, model validation, Razor views, LINQ queries, EF Core persistence, dependency injection, anti-forgery protection and a relational SQLite database**.

Unlike my other static HTML/CSS/JavaScript projects, BookNest is a **server-side .NET application** and has its own warm editorial design with cream backgrounds, sage green, terracotta, serif typography and a hand-crafted bookshelf illustration.

## Features

| Feature | Description |
|---|---|
| Book catalogue | Add a book with title, author, genre and optional cover URL |
| Reading status | Want to Read, Currently Reading or Finished |
| Progress tracking | Save total pages and pages read, with automatic progress percentage |
| Personal ratings | Rate books from one to five stars |
| Notes | Keep reading reflections and personal notes |
| Search | Find books by title, author or genre |
| Filters | Browse by reading status |
| Statistics | Dashboard counts for total, currently reading, finished and unread books |
| CRUD | Create, view, update and delete books |
| Persistence | Book records stored locally in a SQLite database |

## Technology

- **.NET 10** and **C#**
- **ASP.NET Core MVC** with Razor views and Tag Helpers
- **Entity Framework Core 10** using the SQLite provider
- **LINQ** for searching, filtering and statistics
- **HTML/CSS** for a distinctive responsive editorial interface

## Run locally

You need the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) installed.

Clone the repository:

```bash
git clone https://github.com/ST10458151/booknest.git
cd booknest
```

Restore dependencies and start the application:

```bash
dotnet restore BookNest.Web/BookNest.Web.csproj
dotnet run --project BookNest.Web
```

Open the local URL printed by the terminal.

On the first run, Entity Framework Core will create **booknest.db** automatically. You can then add books and save changes between app restarts.

## Project structure

```text
booknest/
├── BookNest.Web/
│   ├── Controllers/
│   │   ├── BooksController.cs
│   │   └── HomeController.cs
│   ├── Data/
│   │   └── BookNestContext.cs
│   ├── Models/
│   │   ├── Book.cs
│   │   └── LibraryViewModel.cs
│   ├── Views/
│   │   ├── Books/
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   ├── Delete.cshtml
│   │   │   └── _Form.cshtml
│   │   └── Shared/_Layout.cshtml
│   ├── wwwroot/css/site.css
│   ├── Program.cs
│   └── BookNest.Web.csproj
└── README.md
```

## Learning outcomes

- Applying ASP.NET Core MVC and separation of concerns
- Mapping models and persisting entities with EF Core and SQLite
- Building validation and server-rendered HTML forms
- Implementing CRUD endpoints with anti-forgery protection
- Writing database queries with LINQ
- Creating an original, responsive UI

## Important limitations

This is a **local single-user portfolio MVP**, not a production-ready hosted application. It does not provide accounts or separate each person's library from other users. Do not deploy it as a shared public application without authentication, authorisation, per-user records, schema migrations and proper operations/security configuration.

For simplicity, the demo initialises its database using `EnsureCreated()`; a production system should instead use **EF Core migrations**. External HTTPS book-cover URLs are loaded from their respective websites.

**GitHub Pages cannot host a server-side ASP.NET Core/SQLite application.** Run this project locally or deploy to a hosting platform that supports .NET and persistent data storage.

---

Created by **Shakeelah Khan** · [Portfolio](https://st10458151.github.io/developer-portfolio/) · [LinkedIn](https://www.linkedin.com/in/shakeelah-k-867b13320/)
