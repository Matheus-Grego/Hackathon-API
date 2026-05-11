# reWind — Backend API

> Plataforma de mapeamento de usinas eólicas com estimativa de materiais, roteamento e destinação para economia circular.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-17-336791?style=flat&logo=postgresql)
![Docker](https://img.shields.io/badge/Docker-Compose-2496ED?style=flat&logo=docker)
![Swagger](https://img.shields.io/badge/Docs-Swagger-85EA2D?style=flat&logo=swagger)
![Status](https://img.shields.io/badge/Status-MVP%20Finalizado-brightgreen)

---

## Sumário

- [Sobre o projeto](#sobre-o-projeto)
- [Arquitetura](#arquitetura)
- [Stack tecnológica](#stack-tecnológica)
- [Pré-requisitos](#pré-requisitos)
- [Como rodar localmente](#como-rodar-localmente)
- [Docker Compose](#docker-compose)
- [Endpoints da API](#endpoints-da-api)
- [Variáveis de ambiente](#variáveis-de-ambiente)
- [Time](#time)

---

## Sobre o projeto

O **reWind** é uma solução desenvolvida no **1º Hackathon E+: Transição Energética** pela Equipe 06. O backend fornece uma API REST para:

- Consulta e gerenciamento de **parques eólicos** (Parks)
- Consulta e gerenciamento de **empresas** (Companies)
- Estimativa de materiais e carbono evitado ao fim da vida útil das usinas
- Integração com **Google Maps** para geocodificação de endereços

---

## Arquitetura

O projeto segue a arquitetura em camadas **Clean Architecture**:

```
ReWind.API               → Controllers, Program.cs, Swagger
   ↓
ReWind.Application       → Services, ViewModels, InputModels
   ↓
ReWind.Infrastructure    → Repositories, DbContext, GoogleMaps
   ↓
Rewind.Core              → Entities, Enums, Interfaces
```

### Estrutura de pastas

```
📦 HackathonEquipe6.sln
├── 📁 ReWind.API
│   ├── Controllers/
│   │   ├── CompaniesController.cs
│   │   └── ParksController.cs
│   └── Program.cs
├── 📁 ReWind.Application
│   ├── Models/
│   │   ├── CompanyViewModel.cs
│   │   ├── CompanyInputModel.cs
│   │   └── ...
│   └── Services/
│       ├── ICompanyService.cs
│       ├── CompanyService.cs
│       └── ...
├── 📁 ReWind.Infrastructure
│   ├── Persistance/
│   │   └── ReWindDbContext.cs
│   ├── Repositories/
│   │   ├── CompanyRepository.cs
│   │   └── ParkRepository.cs
│   └── GoogleMapsPersistent/
│       ├── IGoogleMapsService.cs
│       └── GoogleMapsService.cs
└── 📁 Rewind.Core
    ├── Entities/
    │   ├── BaseEntity.cs
    │   ├── Company.cs
    │   ├── Park.cs
    │   ├── Waste.cs
    │   └── ...
    └── Enums/
        └── OriginTypeEnum.cs
```

---

## Stack tecnológica

| Camada | Tecnologia |
|---|---|
| Runtime | .NET 10 |
| Framework | ASP.NET Core |
| ORM | Entity Framework Core |
| Banco de dados | PostgreSQL 17 |
| Documentação | Swagger / OpenAPI |
| Infraestrutura | Docker + Docker Compose |
| Geocodificação | Google Maps API |
| Segurança | BCrypt.Net |

---

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 17](https://www.postgresql.org/download/) ou [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [dotnet-ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) — ferramenta de migrations

```bash
dotnet tool install --global dotnet-ef
```

---

## Como rodar localmente

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/HackathonEquipe6.git
cd HackathonEquipe6
```

### 2. Configure as credenciais com User Secrets

```bash
dotnet user-secrets init --project ReWind.API
dotnet user-secrets set "ConnectionStrings:DefaultConnection" \
  "Host=localhost;Port=5432;Database=ReWind;Username=postgres;Password=SUA_SENHA" \
  --project ReWind.API
```

> ⚠️ Nunca suba credenciais reais no `appsettings.json`. Use sempre User Secrets em desenvolvimento.

### 3. Rode as migrations

```bash
cd ReWind.Infrastructure
dotnet ef database update --startup-project ../ReWind.API
```

### 4. Inicie a API

```bash
cd ReWind.API
dotnet run
```

A API estará disponível em:
- **HTTP:** `http://localhost:8080`
- **Swagger:** `http://localhost:8080/swagger`

---

## Docker Compose

A forma mais simples de subir o ambiente completo:

### 1. Crie o arquivo `.env` na raiz do projeto

```env
POSTGRES_USER=postgres
POSTGRES_PASSWORD=sua_senha
CNPJ_BIZ_KEY=sua_chave_cnpj
```

> Use o `.env.example` como referência.

### 2. Suba os containers

```bash
docker-compose up -d --build
```

### 3. Rode as migrations

```bash
dotnet ef database update --startup-project ReWind.API
```

### Comandos úteis

```bash
# Ver status dos containers
docker-compose ps

# Parar sem apagar dados
docker-compose stop

# Derrubar containers
docker-compose down

# Derrubar e apagar todos os dados ⚠️
docker-compose down -v
```

| Serviço | URL |
|---|---|
| API | `http://localhost:8080` |
| Swagger | `http://localhost:8080/swagger` |
| PostgreSQL | `localhost:5432` |

---

## Endpoints da API

### Parks `/api/parks`

| Método | Endpoint | Descrição |
|---|---|---|
| `GET` | `/api/parks` | Lista todos os parques eólicos |
| `GET` | `/api/parks/{id}` | Busca parque por ID |
| `GET` | `/api/parks/{id}/details` | Detalhes completos do parque |
| `POST` | `/api/parks` | Cadastra novo parque |
| `PUT` | `/api/parks/{id}` | Atualiza parque |
| `DELETE` | `/api/parks/{id}` | Remove parque (soft delete) |

### Companies `/api/companies`

| Método | Endpoint | Descrição |
|---|---|---|
| `GET` | `/api/companies` | Lista todas as empresas |
| `GET` | `/api/companies/{id}` | Busca empresa por ID |
| `GET` | `/api/companies/{id}/details` | Detalhes completos da empresa |
| `POST` | `/api/companies` | Cadastra nova empresa |
| `PUT` | `/api/companies/{id}` | Atualiza empresa |
| `DELETE` | `/api/companies/{id}` | Remove empresa (soft delete) |

> 📄 Documentação interativa completa disponível no Swagger: `http://localhost:8080/swagger`

---

## Variáveis de ambiente

| Variável | Descrição | Obrigatória |
|---|---|---|
| `ConnectionStrings__DefaultConnection` | String de conexão PostgreSQL | ✅ Sim |
| `GoogleMaps__ApiKey` | Chave da API Google Maps | ⚠️ Opcional (MVP) |
| `CNPJ_BIZ_KEY` | Chave da API CNPJ Biz | ⚠️ Opcional |
| `ASPNETCORE_ENVIRONMENT` | Ambiente (`Development` / `Production`) | ✅ Sim |

---

## Time

| Nome | Papel |
|---|---|
| Adriano Erique de Oliveira Lima | Industrial Decarbonization Specialist |
| Kenji Mattos Kinoshita | Frontend Developer |
| Keven Souza Grillo | Full Stack Developer |
| Lethycia Zenaide Queiroz Melo | UX/UI Developer |
| Matheus Grego do Amaral | Full Stack Developer |

---

<p align="center">Desenvolvido com 💚 no <strong>1º Hackathon E+: Transição Energética</strong> — 2026</p>
