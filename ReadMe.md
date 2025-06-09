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


## Preseeded data

There is some preseeded data:

 Id |    Name    |      BoardingDate      |          Url           |   Country   |     AddressMain     | AddressSecondary | PartnerId
----+------------+------------------------+------------------------+-------------+---------------------+------------------+-----------
  1 | Merchant A | 2023-05-01 00:00:00+00 | https://merchant-a.com | Netherlands | Main Street 123     | Suite 4B         |         1
  2 | Merchant B | 2023-04-01 00:00:00+00 | https://merchant-b.com | Bulgaria    | Secondary Street 45 |                  |         1

 Id |     Name
----+--------------
  1 | Test Partner


To insert additional change OperationsReportingContext.OnModelCreating or log in to the PostgreSQL container:
```bash
docker exec -it my-postgres psql -U postgres
```

 and use the following SQL commands:
```sql
-- partners
INSERT INTO partners (id, name)
VALUES
    (2, 'Partner Two'),
    (3, 'Global Partners Inc.'),
    (4, 'NextGen Partner Ltd.');

-- merchants
INSERT INTO merchants (name, boarding_date, url, country, address_main, address_secondary, partner_id) VALUES
('Merchant C', '2024-05-01 00:00:00+00', 'https://merchant-c.com', 'Nigeria', 'Main Street 12345', 'Suite 7B', 1),
('Merchant D', '2025-04-01 00:00:00+00', 'https://merchant-d.com', 'Italy', 'Secondary Street 46', NULL, 2);

-- transactions
INSERT INTO transactions (
    date_created, transaction_type, amount, currency,
    sender_iban, receiver_iban, status, external_id, merchant_id
) VALUES
    ('2023-02-22T07:08:59.679', 1, 111.11, 'EUR', 'NL68INGB5831335380', 'BG83IORT80949736921315', 1, '123213123123', 1),
    ('2023-02-22T07:07:44.123', 2, 1231.13, 'EUR', 'NL68INGB5831335380', 'BG90RZBB91552112199351', 0, '123213234123', 2),
    ('2024-02-22T07:07:44.123', 2, 1231.13, 'EUR', 'NL68INGB5831335380', 'BG90RZBB91552112199351', 0, '123213234124', 3),
    ('2023-02-22T07:07:44.123', 2, 10000000.00, 'EUR', 'NL68INGB5831335380', 'BG90RZBB91552112199351', 0, '123213234125', 4);

```

Additionally transactions can be inserted via swagger "https://localhost:7116/swagger/index.html"