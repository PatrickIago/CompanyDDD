📁 CompanyDDD - API de Gerenciamento de Funcionários e Departamentos












📖 Sobre o Projeto

CompanyDDD é uma API RESTful construída em ASP.NET Core 8 com foco em Domain-Driven Design (DDD), para gerenciar funcionários e departamentos.

Principais características:

Separação clara de camadas: Domain, Application, Infra, API.

Uso de DTOs para transferência de dados e evitar ciclos de referência JSON.

Entity Framework Core para persistência de dados.

FluentValidation para validação de entrada de dados.

CRUD completo para funcionários e departamentos.

Regra de negócio: não é permitido adicionar um funcionário em um departamento que não existe.

🛠️ Tecnologias

Framework: ASP.NET Core 8

ORM: Entity Framework Core

Banco de Dados: SQL Server

Validação: FluentValidation

Documentação: Swagger / OpenAPI

Padrão de projeto: Domain-Driven Design (DDD)

📦 Estrutura de Endpoints
Funcionario
Método	Rota	Descrição	Exemplo de Payload
GET	/api/Funcionario/Lista todos os funcionarios	Lista todos os funcionários	-
GET	/api/Funcionario/Buscar funcionario por um Id especifico?id={id}	Retorna um funcionário específico	-
POST	/api/Funcionario/Adiciona um novo funcionario	Adiciona um novo funcionário	json { "nome": "André Soares", "dataNascimento": "2000-10-22", "salario": 2000, "email": "andre@gmail.com", "contato": "51980578891", "departamentoId": 1 }
PUT	/api/Funcionario/Atualiza dados de um funcionario ja existente?id={id}	Atualiza dados de um funcionário	json { "id": 1, "nome": "André Soares", "dataNascimento": "2000-10-22", "salario": 2500, "email": "andre@gmail.com", "contato": "51980578891", "departamentoId": 1 }
DELETE	/api/Funcionario/Remove um funcionario por Id especifico?id={id}	Remove um funcionário pelo ID	-
Departamento
Método	Rota	Descrição	Exemplo de Payload
GET	/api/Departamento/Lista todos os departamentos	Lista todos os departamentos	-
GET	/api/Departamento/Buscar departamento por um Id especifico?id={id}	Retorna um departamento específico	-
POST	/api/Departamento/Adiciona um novo departamento	Adiciona um novo departamento	json { "nome": "Recursos Humanos", "descricao": "Departamento de RH" }
PUT	/api/Departamento/Atualiza dados de um departamento ja existente?id={id}	Atualiza dados de um departamento	json { "id": 1, "nome": "RH Atualizado", "descricao": "Departamento de Recursos Humanos" }
DELETE	/api/Departamento/Remove um departamento por Id especifico?id={id}	Remove um departamento pelo ID	-
⚡ Funcionalidades Principais

CRUD completo para Funcionários e Departamentos.

Validação de dados de entrada via FluentValidation.

DTOs para evitar problemas de referência cíclica.

Regras de negócio implementadas: departamento deve existir antes de cadastrar funcionário.

Documentação interativa via Swagger.
