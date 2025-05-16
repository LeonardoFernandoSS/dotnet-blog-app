Collecting workspace information# BlogApp

Este projeto é um exemplo de aplicação modularizada para estudo, utilizando arquitetura em camadas e diversas bibliotecas populares do ecossistema .NET.

## Arquitetura

O projeto está organizado em quatro camadas principais:

- **BlogApp.Domain**: Contém as entidades de domínio, enums, eventos, exceções e value objects. É o núcleo da lógica de negócio.
- **BlogApp.Core**: Camada central para abstrações e contratos compartilhados.
- **BlogApp.Application**: Implementa os casos de uso, interfaces de aplicação e injeção de dependências.
- **BlogApp.Infrastructure**: Responsável pela implementação de repositórios, acesso a dados e integrações externas.

A arquitetura segue princípios de separação de responsabilidades, facilitando testes, manutenção e evolução do sistema.

## Bibliotecas Utilizadas

Principais pacotes NuGet presentes no projeto:

- **Microsoft.Extensions.DependencyInjection**  
  Utilizada para injeção de dependências, promovendo baixo acoplamento entre as camadas.

- **Microsoft.EntityFrameworkCore**  
  ORM para persistência de dados, facilitando o mapeamento objeto-relacional.

- **Microsoft.EntityFrameworkCore.Sqlite**  
  Provedor do Entity Framework Core para SQLite, utilizado como banco de dados.

- **Balta.Mediator**  
  Implementação de Mediator para desacoplar a comunicação entre componentes e casos de uso.

- **Humanizer.Core**  
  Biblioteca para manipulação e apresentação de strings e datas de forma mais amigável.

## Padrões e Princípios

- **Domain-Driven Design (DDD)**:  
  O domínio é o centro da aplicação, com entidades ricas e regras de negócio explícitas.

- **Injeção de Dependências**:  
  Todas as dependências são resolvidas via DI, facilitando testes e substituição de implementações.

- **Factories**:  
  Uso de métodos de fábrica para criação controlada de entidades, como em `PublishedPost.Factories.Create`.

- **Enum para Status e Tipos**:  
  Uso de enums para representar status e tipos de posts, tornando o código mais legível e seguro.

## Estrutura de Pastas

```
BlogApp.Domain/
  Entities/
  Enums/
  Events/
  Exceptions/
  ValueObjects/
BlogApp.Core/
BlogApp.Application/
  Interfaces/
  Repositories/
  UseCases/
BlogApp.Infrastructure/
```

## Objetivo

Este projeto serve como base para estudos de arquitetura limpa, boas práticas de organização de código e uso de bibliotecas modernas no .NET.

---

Sinta-se à vontade para explorar cada camada e entender como as responsabilidades estão distribuídas!
