--
-- SCRIPT DE CRIAÇÃO DO BANCO DE DADOS E TABELAS
--
-- Banco de dados esperado: bd_sistema_estoque
--

-- 1. Cria o Banco de Dados (se não existir)
CREATE DATABASE IF NOT EXISTS bd_sistema_estoque;

-- Seleciona o banco de dados para uso
USE bd_sistema_estoque;

-- 2. Tabela: categoria
-- Armazena os tipos/grupos de produtos.
CREATE TABLE IF NOT EXISTS categoria (
    idcategoria INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY (idcategoria)
);

-- 3. Tabela: usuario
-- Armazena as credenciais de login para acesso ao sistema.
CREATE TABLE IF NOT EXISTS usuario (
    idusuario INT NOT NULL AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL UNIQUE,
    senha VARCHAR(50) NOT NULL, -- Recomenda-se usar HASH (ex: SHA256) em produção, mas o código atual usa string simples.
    PRIMARY KEY (idusuario)
);

-- 4. Tabela: produto
-- Tabela principal que armazena os dados do inventário, ligada à Categoria.
CREATE TABLE IF NOT EXISTS produto (
    idproduto INT NOT NULL AUTO_INCREMENT,
    nome_produto VARCHAR(255) NOT NULL,
    quantidade INT NOT NULL DEFAULT 0,
    preco_venda DECIMAL(10, 2) NOT NULL,
    estoque_minimo INT NOT NULL DEFAULT 1,
    -- Chave Estrangeira para a Categoria
    fk_categoria_idcategoria INT NOT NULL,
    PRIMARY KEY (idproduto),
    FOREIGN KEY (fk_categoria_idcategoria) REFERENCES categoria(idcategoria)
        ON DELETE RESTRICT -- Impede exclusão de categoria com produtos relacionados
        ON UPDATE CASCADE
);

-- 5. Tabela: movimentacao
-- Tabela de histórico de saídas (baixas) de estoque.
CREATE TABLE IF NOT EXISTS movimentacao (
    idmovimentacao INT NOT NULL AUTO_INCREMENT,
    tipo VARCHAR(10) NOT NULL, -- O código C# usa o valor 'Saida'
    quantidade INT NOT NULL,
    preco DECIMAL(10, 2) NOT NULL,
    `date` DATETIME NOT NULL, -- Usado NOW() no código C#
    -- Chave Estrangeira para o Produto que sofreu a movimentação
    fk_produto_idproduto INT NOT NULL,
    PRIMARY KEY (idmovimentacao),
    FOREIGN KEY (fk_produto_idproduto) REFERENCES produto(idproduto)
        ON DELETE CASCADE -- Se o produto for excluído, seu histórico de movimentação também é
        ON UPDATE CASCADE
);

--
-- DADOS INICIAIS (Para Teste)
--

-- Insere algumas categorias padrão (o código C# assume que o ID de Categoria é o índice + 1)
INSERT INTO categoria (nome) VALUES 
('Eletrônicos'), 
('Alimentos'), 
('Ferramentas'),
('Escritório');

-- Insere um usuário padrão para login (Usuário: admin / Senha: 123)
INSERT INTO usuario (login, senha) VALUES ('admin', '123');

-- Exemplo de inserção de produto para teste
INSERT INTO produto 
    (nome_produto, quantidade, preco_venda, estoque_minimo, fk_categoria_idcategoria) 
VALUES 
    ('Mouse Gamer RGB', 15, 89.90, 5, 1); -- Categoria 1: Eletrônicos
