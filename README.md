# Reviews Application

## Description
A web application for managing user reviews.  
- **Backend:** .NET 9, EF Core, PostgreSQL, Docker  
- **Frontend:** React + TypeScript + Vite  
- **Features:** Adding, Viewing, Filtering reviews.

---

## Features
- View list of reviews
- Add new reviews
- Upload files and images
- Filter and search reviews
- Swagger/OpenAPI for API testing

---

## Installation & Run

### 1. Clone the repository
```bash
git clone git@github.com:vanyachernov/user-reviews.git
cd <PROJECT_FOLDER>
```

### 2. Set up the database

1. Install PostgreSQL (if not installed)
2. Update the connection data in **backend/.env**

### 3. Start

Enter next command to the terminal:

1) Go to **./backend/src/Reviews.API** and create .env file based on .env.example

2)

```bash
docker-compose up -d --build
```

### What next?

Links will be available by the link:

- **Backend**: http://localhost:8080
- **Fronend**: http://localhost:3000
