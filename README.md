# ScreenSound

ScreenSound é uma plataforma web para gerenciar artistas e músicas. Este projeto está estruturado em diferentes camadas e utiliza o Entity Framework Core para interação com o banco de dados. A aplicação está organizada com base nos princípios de arquitetura limpa e utiliza Migrations para versionamento de banco de dados.

## Estrutura do Projeto

- **ScreenSound.API**: Camada responsável pela API do projeto, onde as funcionalidades de backend são expostas via endpoints.
- **ScreenSound.Web**: Frontend do projeto, que consome a API para exibir informações para os usuários.
- **ScreenSound.Shared.Modelos**: Contém os modelos de dados compartilhados entre as camadas.
- **ScreenSound.Shared.Dados**: Implementa a lógica de acesso ao banco de dados, utilizando o Entity Framework Core.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação usada no desenvolvimento.
- **Entity Framework Core**: Framework ORM (Object-Relational Mapper) para interagir com o banco de dados.
- **Migrations**: Gerenciamento e versionamento do banco de dados.
- **ASP.NET Core**: Usado para construir a API RESTful.
- **SQL Server**: Banco de dados utilizado no projeto.

## Setup do Projeto

### Pré-requisitos

- .NET SDK instalado
- SQL Server ou outro banco de dados compatível com Entity Framework
- Ferramenta de controle de versão Git

### Passos para rodar o projeto localmente

1. Clone o repositório:
    ```bash
    git clone https://github.com/usuario/ScreenSound.git
    ```

2. Navegue até a pasta do projeto e restaure os pacotes:
    ```bash
    cd ScreenSound
    dotnet restore
    ```

3. Atualize o banco de dados utilizando Migrations:
    ```bash
    dotnet ef database update
    ```

4. Execute a aplicação:
    ```bash
    dotnet run --project ScreenSound.API
    ```

5. Acesse a aplicação em `http://localhost:****`.

## Migrations

O projeto utiliza Migrations para manter o banco de dados atualizado com as últimas mudanças nos modelos de dados.

### Adicionar uma nova migration

Para adicionar uma nova migration após modificar os modelos, utilize o comando:

```bash
dotnet ef migrations add NomeDaMigration
