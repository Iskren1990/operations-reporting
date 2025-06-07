# Running the Project with PostgreSQL Docker Container

## Prerequisites
- [Docker](https://docs.docker.com/get-docker/)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

## Start PostgreSQL Container

Run the following command to start a PostgreSQL container with the correct password and port mapping:

```bash
docker run --name my-postgres -e POSTGRES_PASSWORD=mysecretpassword -p 5433:5432 -v pgdata:/var/lib/postgresql/data -d postgres
```

## Set OperationsReporting.WebApi as startup project

## Create and apply migrations

From within solution folder execute the following:

```bash
dotnet ef migrations add InitialCreate --project ./OperationsReporting.DAL --startup-project ./OperationsReporting.WebApi
dotnet ef database update --project ./OperationsReporting.DAL --startup-project ./OperationsReporting.WebApi
```