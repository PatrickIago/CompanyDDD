# 🏢 [CompanyDDD] - API de Gerenciamento de Funcionários e Departamentos

[![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET Core](https://img.shields.io/badge/.NET-8-blueviolet?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![Design Pattern](https://img.shields.io/badge/Design_Pattern-DDD-0077b6?style=for-the-badge&logo=data%3Aimage%2Fsvg%2Bxml%3Bbase64%2CPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA1MTIgNTEyIj48cGF0aCBmaWxsPSIjRkZGRkZGIiBkPSJNNjQgNDQ4TDI1NiA2NEw0NDggNDQ4SDY0ek0yNTYgMTI4TDEyOCAzODRoMjU2TDI1NiAxMjh6Ii8%2BPC9zdmc%2B)](https://en.wikipedia.org/wiki/Domain-driven_design)
[![ORM](https://img.shields.io/badge/ORM-EF_Core-38B2AC?style=for-the-badge&logo=dot-net)](https://docs.microsoft.com/en-us/ef/core/)
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)

---

## 🎯 Sobre o Projeto

Esta é uma **API RESTful** desenvolvida com **ASP.NET Core 8** para gerenciar as entidades de **Funcionário** e **Departamento** em um contexto de negócio.

O foco desta aplicação está na arquitetura, seguindo rigorosamente o **Domain-Driven Design (DDD)** para garantir uma separação de responsabilidades, escalabilidade e clareza das regras de negócio.

### ✨ Funcionalidades e Destaques Chave

* ✅ **Arquitetura Limpa (DDD):** Implementação das camadas `Domain`, `Application`, `Infrastructure` e `API`.
* 🛡️ **Validação de Domínio:** Uso do **FluentValidation** para garantir a integridade dos dados na entrada.
* 💾 **Persistência SQL:** Configurado com **Entity Framework Core** para comunicação com **SQL Server**.
* 🔄 **Transferência Segura:** Uso de **DTOs** (Data Transfer Objects) para desacoplamento e segurança na comunicação.
* 🚫 **Regra de Negócio Crítica:** Um funcionário só pode ser adicionado se o departamento associado existir.

### 💻 Tecnologias Utilizadas

* **Framework:** ASP.NET Core 8 (C#)
* **Arquitetura:** Domain-Driven Design (DDD)
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQL Server
* **Validação:** FluentValidation
* **Documentação:** Swagger/OpenAPI

## 📦 Estrutura da API (Endpoints)

A API é dividida em dois recursos principais, cobrindo operações CRUD (Create, Read, Update, Delete) para cada um.

| Recurso | Método | Rota | Descrição |
| :--- | :--- | :--- | :--- |
| **Funcionário** | `POST` | `/api/Funcionario/` | **[CREATE]** Adiciona um novo funcionário (Requer Departamento Existente). |
| | `GET` | `/api/Funcionario/` | **[READ ALL]** Retorna a lista de todos os funcionários. |
| | `GET` | `/api/Funcionario/Buscar?id={id}` | **[READ ONE]** Retorna um funcionário específico. |
| | `PUT` | `/api/Funcionario/Atualiza?id={id}` | **[UPDATE]** Atualiza os dados de um funcionário. |
| | `DELETE` | `/api/Funcionario/Remove?id={id}` | **[DELETE]** Remove um funcionário pelo ID. |
| **Departamento** | `POST` | `/api/Departamento/` | **[CREATE]** Adiciona um novo departamento. |
| | `GET` | `/api/Departamento/` | **[READ ALL]** Retorna a lista de todos os departamentos. |
| | `GET` | `/api/Departamento/Buscar?id={id}` | **[READ ONE]** Retorna um departamento específico. |
| | `PUT` | `/api/Departamento/Atualiza?id={id}` | **[UPDATE]** Atualiza os dados de um departamento. |
| | `DELETE` | `/api/Departamento/Remove?id={id}` | **[DELETE]** Remove um departamento pelo ID. |

## ⚙️ Instalação e Execução Local

Siga estes passos para configurar e rodar o projeto na sua máquina:

### 1. Pré-requisitos

* [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
* SQL Server instalado e acessível (LocalDB, Express ou similar).

### 2. Clonar e Configurar

1.  Clone o repositório:
    ```bash
    git clone [https://github.com/SeuUsuario/SeuRepositorio.git](https://github.com/SeuUsuario/SeuRepositorio.git)
    cd CompanyDDD
    ```
2.  **Ajuste a Connection String** no arquivo `appsettings.json` na pasta `CompanyDDD.API` para apontar para o seu SQL Server local.
3.  Aplique as migrations do Entity Framework:
    ```bash
    dotnet ef database update --project CompanyDDD.Infrastructure
    ```

### 3. Iniciar a API

Navegue para a pasta da API e execute:

```bash
cd CompanyDDD.API
dotnet run
