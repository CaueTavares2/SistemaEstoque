# Sistema de Gerenciamento de Estoque

Este é um projeto desenvolvido em C# utilizando **Windows Forms** para criar um sistema de gerenciamento de estoque completo. O sistema permite o cadastro, listagem, controle de saídas e geração de relatórios básicos sobre os produtos em estoque.

## 🚀 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET (Provavelmente .NET 5 ou superior, baseado no `.csproj`)
* **Interface Gráfica:** Windows Forms
* **Banco de Dados:** MySQL
* **Conexão com BD:** MySqlConnector

## ⚙️ Estrutura do Projeto

O projeto segue uma arquitetura básica com separação de responsabilidades:

1.  **Classes de Modelo:** (e.g., `Produto.cs`) definem as estruturas de dados.
2.  **DAO (Data Access Object):** (e.g., `ProdutoDAO.cs`, `UsuarioDAO.cs`, `CategoriaDAO.cs`, etc.) são responsáveis por toda a comunicação e manipulação de dados no MySQL.
3.  **Camada de Persistência:** (`Database.cs`) gerencia a string de conexão com o banco.
4.  **Forms (UI):** Gerenciam a interface do usuário (`FormLogin`, `FormMenu`, `FormCadastro`, etc.).

## 🛠️ Configuração e Execução

Para rodar este projeto localmente, siga os passos abaixo:

### 1. Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) instalado.
* MySQL Server instalado e rodando.
* **Importante:** Você deve ter criado o banco de dados (`bd_sistema_estoque`) e as tabelas necessárias (`produto`, `categoria`, `usuario`, `movimentacao`) com a estrutura correta.

### 2. Configuração do Banco de Dados

A string de conexão está definida em `DAO/Database.cs`. **Você precisa ajustar o campo `Pwd` (senha) ou as credenciais de `Uid` se elas forem diferentes das definidas:**

```csharp
// DAO/Database.cs
public static string ConnectionString = "Server=localhost;Database=bd_sistema_estoque;Uid=root;Pwd=;"; // AJUSTE AQUI!
