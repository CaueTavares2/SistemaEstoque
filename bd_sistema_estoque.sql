--
-- SCRIPT DE CRIAÇÃO DO BANCO DE DADOS E TABELAS (Versão Otimizada)
--

-- 1. Cria o Banco de Dados (se não existir)
CREATE DATABASE IF NOT EXISTS bd_sistema_estoque;

-- Seleciona o banco de dados para uso
USE bd_sistema_estoque;

-- ----------------------------
-- 2. Tabela: categoria
-- ----------------------------
CREATE TABLE IF NOT EXISTS categoria (
    idcategoria INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY (idcategoria)
);

-- ----------------------------
-- 2.1. Tabela: fornecedor (NOVA)
-- ----------------------------
CREATE TABLE IF NOT EXISTS fornecedor (
    idfornecedor INT NOT NULL AUTO_INCREMENT,
    razao_social VARCHAR(150) NOT NULL,
    cnpj VARCHAR(18) NOT NULL UNIQUE,
    nome_fantasia VARCHAR(100),
    email VARCHAR(100),
    PRIMARY KEY (idfornecedor)
);

-- ----------------------------
-- 3. Tabela: usuario (CORRIGIDA E MELHORADA)
-- Suporta hash forte (VARCHAR(255)) e controle de acesso (nivel_acesso).
-- ----------------------------
CREATE TABLE IF NOT EXISTS usuario (
    idusuario INT NOT NULL AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL, -- Aumentado para máxima compatibilidade com hashing seguro (PBKDF2/Argon2)
    nivel_acesso VARCHAR(20) NOT NULL DEFAULT 'Operador', -- NOVO: Permissões (Ex: Admin, Operador)
    PRIMARY KEY (idusuario)
);

-- ----------------------------
-- 4. Tabela: produto
-- ----------------------------
CREATE TABLE IF NOT EXISTS produto (
    idproduto INT NOT NULL AUTO_INCREMENT,
    nome_produto VARCHAR(255) NOT NULL,
    quantidade INT NOT NULL DEFAULT 0,
    preco_venda DECIMAL(10, 2) NOT NULL,
    estoque_minimo INT NOT NULL DEFAULT 1,
    fk_categoria_idcategoria INT NOT NULL,
    PRIMARY KEY (idproduto),
    FOREIGN KEY (fk_categoria_idcategoria) REFERENCES categoria(idcategoria)
        ON DELETE RESTRICT 
        ON UPDATE CASCADE
);

-- ----------------------------
-- 5. Tabela: movimentacao (MELHORADA COM AUDITORIA)
-- Rastreia quem fez o movimento.
-- ----------------------------
CREATE TABLE IF NOT EXISTS movimentacao (
    idmovimentacao INT NOT NULL AUTO_INCREMENT,
    tipo VARCHAR(10) NOT NULL,
    quantidade INT NOT NULL,
    preco DECIMAL(10, 2) NOT NULL,
    `date` DATETIME NOT NULL,
    fk_produto_idproduto INT NOT NULL,
    fk_usuario_idusuario INT NOT NULL, -- NOVO: Chave Estrangeira para o usuário que registrou
    PRIMARY KEY (idmovimentacao),
    FOREIGN KEY (fk_produto_idproduto) REFERENCES produto(idproduto)
        ON DELETE CASCADE 
        ON UPDATE CASCADE,
    FOREIGN KEY (fk_usuario_idusuario) REFERENCES usuario(idusuario) -- Nova Foreign Key
        ON DELETE RESTRICT -- Impede a exclusão de um usuário com movimentações
        ON UPDATE CASCADE
);

--
-- DADOS INICIAIS
--
INSERT INTO categoria (nome) VALUES 
('Eletrônicos'), 
('Alimentos'), 
('Ferramentas'),
('Escritório');

INSERT INTO produto 
    (nome_produto, quantidade, preco_venda, estoque_minimo, fk_categoria_idcategoria) 
VALUES 
    ('Mouse Gamer RGB', 15, 89.90, 5, 1);
