# SaleMasterApi

API em ASP.NET Core (.NET 8) com MySQL (Docker) usando Entity Framework Core (ORM) e padrão DDD (Controller/Service/Repository).

## Requisitos
- .NET SDK 8
- Docker Desktop
- Postman
- Swagger (integrado na API)

## Como rodar o banco (MySQL)
\dbdata\docker-compose.yml

bash
docker compose up -d

MySQL:

Host: localhost

Porta: 3306

Usuário: root

Senha: root

Database: salemaster

## Como rodar a API

Entre na pasta do projeto (onde está o SaleMasterApi.csproj) e execute:

dotnet restore
dotnet run


# A API ficará disponível em:

https://localhost:7128

Swagger:

https://localhost:7128/swagger

# Migrations / Criar tabelas

Na pasta do projeto:

dotnet ef database update

# Endpoints principais (Produtos)

GET /api/produtos

POST /api/produtos

GET /api/produtos/{id}

PUT /api/produtos/{id}

DELETE /api/produtos/{id}

# Testes

Uma collection do Postman está incluída no arquivo:

SaleMasterApi.postman_collection.json




