📅 [CompanyDDD] - API de Gerenciamento de Funcionários e Departamentos












🎯 Sobre o Projeto

Esta é uma API RESTful desenvolvida em ASP.NET Core 8 seguindo o padrão Domain-Driven Design (DDD) para gerenciar funcionários e departamentos.

O projeto utiliza DTOs para transferência de dados, Entity Framework Core para persistência e FluentValidation para validação de entrada de dados.

O foco principal é organização limpa do código, separação de responsabilidades e regras de negócio, como validar se um departamento existe antes de adicionar um funcionário.

🛠️ Tecnologias Utilizadas

Framework: ASP.NET Core 8 (C#)

Banco de Dados: SQL Server

ORM: Entity Framework Core

Validação: FluentValidation

Documentação: Swagger / OpenAPI

Padrão: Domain-Driven Design (DDD)

Mapeamento (opcional): AutoMapper

📦 Estrutura da API (Endpoints)

A API possui endpoints para gerenciar funcionários e departamentos, cobrindo todas as operações CRUD.

Funcionario
Método	Endpoint	Descrição
GET	/api/Funcionario/Lista todos os funcionarios	Retorna todos os funcionários.
GET	/api/Funcionario/Buscar funcionario por um Id especifico?id={id}	Retorna um funcionário específico pelo ID.
POST	/api/Funcionario/Adiciona um novo funcionario	Adiciona um novo funcionário. O DepartamentoId informado deve existir.
PUT	/api/Funcionario/Atualiza dados de um funcionario ja existente?id={id}	Atualiza os dados de um funcionário existente.
DELETE	/api/Funcionario/Remove um funcionario por Id especifico?id={id}	Remove um funcionário pelo ID.
Departamento
Método	Endpoint	Descrição
GET	/api/Departamento/Lista todos os departamentos	Retorna todos os departamentos.
GET	/api/Departamento/Buscar departamento por um Id especifico?id={id}	Retorna um departamento específico pelo ID.
POST	/api/Departamento/Adiciona um novo departamento	Adiciona um novo departamento.
PUT	/api/Departamento/Atualiza dados de um departamento ja existente?id={id}	Atualiza os dados de um departamento existente.
DELETE	/api/Departamento/Remove um departamento por Id especifico?id={id}	Remove um departamento pelo ID.
⚡ Funcionalidades Principais

CRUD completo para Funcionários e Departamentos.

Validação de entrada via FluentValidation.

Regra de negócio: só é possível cadastrar um funcionário se o departamento existir.

DTOs para evitar referência cíclica e expor apenas dados necessários.

Documentação Swagger disponível para testar endpoints.
