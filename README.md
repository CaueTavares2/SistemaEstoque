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
```

## 🧩 Sistema de Código de Erros (Error Codes)

Para facilitar a rastreabilidade de problemas, o sistema utiliza um código de erro de três dígitos ao registrar falhas no arquivo `C:\Logs\SistemaEstoque\sistema_estoque.log`.

A estrutura do código é a seguinte:

| Código | Área do Sistema | Descrição Geral |
| :----: | :-------------: | :-------------- |
| **1xx** | Inicialização/Geral | Erros que ocorrem ao iniciar a aplicação ou falhas inesperadas. |
| **2xx** | **DAO - Usuário** | Erros relacionados ao `UsuarioDAO` (Login, Banco de Dados). |
| **3xx** | **DAO - Produto** | Erros relacionados ao `ProdutoDAO` (CRUD de Produtos). |
| **4xx** | **DAO - Movimentação** | Erros relacionados ao `MovimentacaoDAO` (Baixa de Estoque). |
| **5xx** | **Interfaces (Forms)** | Erros de validação ou interação em formulários. |

### Exemplos Comuns:

* **201:** Falha na conexão ou execução de consulta SQL no `UsuarioDAO`.
* **302:** Erro ao tentar atualizar um registro no `ProdutoDAO`.
* **401:** Falha na transação (rollback) ao registrar saída de estoque no `MovimentacaoDAO`.

O **Logger** registra o código de erro, a mensagem, o tipo da exceção e o *Stack Trace* completo para auxiliar no diagnóstico.
