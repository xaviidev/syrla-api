# DEPLOYMENT GUIDE

## Overview

This document describes the deployment process of the Syrla API, including GitHub integration, Docker configuration, Render deployment, troubleshooting procedures, and rollback strategies.

---

# Project Information

Application: Syrla API

Technology Stack:

* ASP.NET Core 8
* Entity Framework Core
* MySQL
* JWT Authentication
* Docker
* Render
* GitHub

Repository:

https://github.com/xaviidev/syrla-api

---

# Architecture

Developer
↓
Git Push
↓
GitHub Repository
↓
Render Auto Deploy
↓
Docker Build
↓
Production Environment

---

# Deployment Pipeline

## Local Development

Build application:

```bash
dotnet build
```

Run application:

```bash
dotnet run
```

Run tests:

```bash
dotnet test
```

---

## Source Control

Check status:

```bash
git status
```

Add changes:

```bash
git add .
```

Create commit:

```bash
git commit -m "description"
```

Push changes:

```bash
git push
```

---

## Automatic Deployment

Render automatically deploys every push to:

Branch:

main

Deployment flow:

Git Push
↓
GitHub
↓
Render Build
↓
Docker Build
↓
Production Release

---

# Docker Configuration

Current Dockerfile:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Syrla.Api.dll"]
```

---

# Production Endpoints

## Root Endpoint

GET /

Returns application status.

---

## Health Check

GET /health

Purpose:

* Service validation
* Monitoring
* Availability checks

---

## Weather Forecast

GET /weatherforecast

Testing endpoint.

---

## Swagger

GET /swagger

API documentation.

---

# Environment Variables

Current status:

Partially implemented.

Future migration:

JWT Secret

Connection String

External services configuration

Example:

```env
ASPNETCORE_URLS=http://+:8080

JwtSettings__SecretKey=secret

ConnectionStrings__DefaultConnection=connection-string
```

---

# Render Configuration

Service Type:

Web Service

Deployment Method:

Docker

Environment:

Production

Port:

8080

Auto Deploy:

Enabled

---

# Monitoring Checklist

Verify:

* Application status
* Health endpoint
* Swagger availability
* Deployment logs
* Database connectivity

---

# Rollback Procedure

If deployment fails:

1. Open GitHub repository
2. Identify last stable commit
3. Revert commit

Example:

```bash
git revert COMMIT_ID
git push
```

Render will automatically redeploy.

---

# Troubleshooting

## Swagger Returns 404

Verify:

```csharp
app.UseSwagger();
app.UseSwaggerUI();
```

are enabled in Production.

---

## Render Deployment Failure

Check:

* Build logs
* Dockerfile
* Environment variables

---

## Database Connection Error

Verify:

* Connection string
* Database availability
* Firewall rules
* Credentials

---

## Health Endpoint Failure

Verify:

* Application startup logs
* Dependency injection
* Middleware configuration

---

# Security Recommendations

Future improvements:

* Environment variables
* Secret rotation
* HTTPS validation
* JWT secret management
* Database encryption

---

# Future Infrastructure

Planned:

* Managed Database
* Custom Domain
* SSL Validation
* Monitoring Dashboard
* Centralized Logging
* CI/CD Pipeline Enhancements

---

# Deployment Status

Current Version:

v0.1.0

Environment:

Production

Deployment Platform:

Render

Status:

Operational
