# ClinicVp API .NET

**API REST desenvolvida com .NET para o gerenciamento de operações de uma clínica médica.**

O ClinicVp API é um projeto desenvolvido com foco no aprendizado e na aplicação de boas práticas de desenvolvimento backend utilizando C#, ASP.NET Core e PostgreSQL.

O projeto representa a evolução de uma API de gerenciamento de clínicas, explorando os recursos do ecossistema .NET para construir uma aplicação organizada, escalável e de fácil manutenção.

## Tecnologias utilizadas

| Tecnologia | Finalidade |
|---|---|
| **C#** | Linguagem utilizada no desenvolvimento da aplicação. |
| **.NET 10** | Plataforma de desenvolvimento e execução da API. |
| **ASP.NET Core Web API** | Construção dos endpoints HTTP e dos controllers. |
| **PostgreSQL** | Banco de dados relacional para persistência das informações. |
| **Entity Framework Core** | ORM utilizado para mapear entidades e interagir com o banco de dados. |
| **Npgsql** | Provedor de acesso ao PostgreSQL para o Entity Framework Core. |
| **DotNetEnv** | Carregamento de variáveis de ambiente a partir de arquivos `.env`. |
| **Git e GitHub** | Controle de versão e hospedagem do código-fonte. |

## Funcionalidades e domínio

A API é voltada para operações de uma clínica médica, contemplando entidades e estruturas relacionadas a:

- **Médicos:** informações profissionais, CRM, especialidades e dados de contato.
- **Pacientes:** informações pessoais e endereços.
- **Consultas:** gerenciamento dos agendamentos e informações associadas.
- **Prontuários de consulta:** sintomas, diagnóstico, tratamento e observações clínicas.
- **Especialidades e endereços:** organização dos dados relacionados aos profissionais e pacientes.

A implementação de cada funcionalidade pode evoluir de forma independente conforme as necessidades do projeto.

## Arquitetura e organização

O projeto foi desenvolvido com separação de responsabilidades, organizando o acesso aos dados, as regras de negócio e a exposição dos endpoints.

### Repository Pattern

A camada de repositórios centraliza as operações de acesso ao banco de dados. Interfaces, como `ISpeciality` e `IRecepcionist`, definem contratos que podem ser implementados por repositórios concretos.

Essa abordagem reduz o acoplamento entre as regras de negócio e a implementação da persistência.

### Services

A camada de serviços concentra a lógica de negócio e coordena as operações necessárias para atender às solicitações da aplicação.

Os controllers delegam as operações aos serviços, evitando concentrar toda a lógica em um único componente.

### Controllers

Os controllers recebem as requisições HTTP, encaminham os dados para a camada responsável e retornam as respostas da API.

### DTOs — Data Transfer Objects

Os DTOs definem os dados utilizados na comunicação entre o cliente e a API.

Foram utilizados objetos específicos para operações de escrita e leitura, permitindo controlar quais informações são recebidas ou retornadas pelos endpoints sem depender diretamente das entidades do banco de dados.

### Injeção de dependência

O ASP.NET Core é utilizado para registrar e fornecer as dependências necessárias aos controllers, serviços e repositórios.

Com isso, os componentes dependem de contratos e podem ser substituídos ou testados com maior facilidade.

## Banco de dados

A aplicação utiliza PostgreSQL, acessado por meio do Entity Framework Core e do provedor Npgsql.

O mapeamento entre os objetos C# e os dados relacionais é realizado com entidades e um contexto de banco de dados (`DbContext`).

O projeto também utiliza enums para representar estados e categorias do domínio, como gênero e situação de funcionários. A integração com os tipos enum do PostgreSQL exige que os valores e os mapeamentos entre C# e banco estejam corretamente configurados.

As credenciais e os dados de conexão devem ser fornecidos por variáveis de ambiente, evitando manter informações sensíveis diretamente no código-fonte.

**Boas práticas adotadas no desenvolvimento:**

- Separação das configurações sensíveis do código-fonte.
- Utilização de variáveis de ambiente.
- Uso de DTOs para controlar os dados de entrada e saída.
- Separação de responsabilidades entre controllers, serviços e repositórios.
- Controle de versão com Git.

## Como executar o projeto

### Pré-requisitos

Antes de executar a aplicação, instale:

- [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL](https://www.postgresql.org/) ou acesso a uma instância PostgreSQL hospedada.
- [Git](https://git-scm.com/)

### 1. Clone o repositório

```bash
git clone https://github.com/JoaoMoraes28/NewbiesClinicVpAPI.git
```

Entre na pasta do projeto:

```bash
cd NewbiesClinicVpAPI
```

### 2. Configure as variáveis de ambiente

Configure as variáveis necessárias para a aplicação, incluindo a URL de conexão com o PostgreSQL.

Caso o projeto esteja configurado para utilizar um arquivo `.env`, crie-o no local esperado pela aplicação e preencha-o com os nomes de variáveis definidos no código.

Exemplo ilustrativo:

```env
DATABASE_URL=sua_url_de_conexao_postgresql
```

> O nome acima é um exemplo. Confira o nome efetivamente utilizado pelas configurações da aplicação antes de executar o projeto. Não compartilhe credenciais reais nem envie arquivos `.env` ao GitHub.

### 3. Restaure as dependências

```bash
dotnet restore
```

### 4. Compile a aplicação

```bash
dotnet build
```

### 5. Execute a API

```bash
dotnet run --project ClinicVp
```

O endereço local e a porta da API dependem da configuração de execução do projeto. Consulte a saída do terminal para identificar a URL utilizada.

## Objetivos de aprendizado

O desenvolvimento deste projeto tem como objetivos:

- Aprender C# aplicado ao desenvolvimento backend.
- Compreender a estrutura de uma aplicação ASP.NET Core Web API.
- Aplicar os princípios de injeção de dependência.
- Trabalhar com interfaces, repositórios e serviços.
- Utilizar DTOs para estruturar a comunicação HTTP.
- Integrar o Entity Framework Core a um banco PostgreSQL.
- Configurar enums e seus mapeamentos entre C# e PostgreSQL.
- Gerenciar configurações por variáveis de ambiente.
- Aplicar boas práticas de organização e manutenção do código.

## Autores

**João Moraes**

- GitHub: [@JoaoMoraes28](https://github.com/JoaoMoraes28)
- Linkedin: [@Linkedin]()
---

**Sidney Aragão**

- GitHub: [@Sidney010](https://github.com/Sidney010)
- Linkedin: [@Linkedin](https://www.linkedin.com/in/sidney-campos-aragão/)
---

Primeiro contato com .NET, com o objetivo de aprofundar conhecimentos em desenvolvimento backend com C# e .NET.