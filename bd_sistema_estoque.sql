-- BANCO DE DADOS SIMPLIFICADO - SISTEMA ESTOQUE
CREATE DATABASE IF NOT EXISTS bd_sistema_estoque;
USE bd_sistema_estoque;

-- TABELAS BÁSICAS
CREATE TABLE IF NOT EXISTS categoria (
    idcategoria INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE IF NOT EXISTS usuario (
    idusuario INT AUTO_INCREMENT PRIMARY KEY,
    login VARCHAR(50) UNIQUE NOT NULL,
    senha VARCHAR(255) NOT NULL,
    nivel_acesso VARCHAR(20) DEFAULT 'Operador'
);

CREATE TABLE IF NOT EXISTS produto (
    idproduto INT AUTO_INCREMENT PRIMARY KEY,
    nome_produto VARCHAR(255) NOT NULL,
    quantidade INT DEFAULT 0,
    preco_venda DECIMAL(10,2) NOT NULL,
    estoque_minimo INT DEFAULT 1,
    fk_categoria_idcategoria INT NOT NULL,
    FOREIGN KEY (fk_categoria_idcategoria) REFERENCES categoria(idcategoria)
);

CREATE TABLE IF NOT EXISTS fornecedor (
    idfornecedor INT AUTO_INCREMENT PRIMARY KEY,
    razao_social VARCHAR(255) NOT NULL,
    cnpj VARCHAR(18) UNIQUE NOT NULL,
    nome_fantasia VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS movimentacao (
    idmovimentacao INT AUTO_INCREMENT PRIMARY KEY,
    tipo VARCHAR(10) NOT NULL,
    quantidade INT NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    date DATETIME NOT NULL,
    fk_produto_idproduto INT NOT NULL,
    fk_usuario_idusuario INT NOT NULL,
    FOREIGN KEY (fk_produto_idproduto) REFERENCES produto(idproduto),
    FOREIGN KEY (fk_usuario_idusuario) REFERENCES usuario(idusuario)
);

-- NOVA TABELA DE ACESSIBILIDADE
CREATE TABLE IF NOT EXISTS config_acessibilidade (
    idconfig INT AUTO_INCREMENT PRIMARY KEY,
    fk_usuario_idusuario INT UNIQUE NOT NULL,
    tema_escuro BOOLEAN DEFAULT FALSE,
    fonte_tamanho INT DEFAULT 9,
    alto_contraste BOOLEAN DEFAULT FALSE,
    leitor_tela BOOLEAN DEFAULT FALSE,
    navegacao_teclado BOOLEAN DEFAULT TRUE,
    descricao_imagens BOOLEAN DEFAULT FALSE,
    contraste_cores VARCHAR(20) DEFAULT 'normal',
    FOREIGN KEY (fk_usuario_idusuario) REFERENCES usuario(idusuario) ON DELETE CASCADE
);

-- DADOS INICIAIS
INSERT INTO categoria (nome) VALUES 
('Eletrônicos'), ('Alimentos'), ('Ferramentas'), ('Escritório');

INSERT INTO usuario (login, senha, nivel_acesso) VALUES 
('admin', SHA2('admin', 256), 'Admin'),
('operador', SHA2('operador', 256), 'Operador');

INSERT INTO fornecedor (razao_social, cnpj, nome_fantasia, email) VALUES 
('Tech Solutions LTDA', '12.345.678/0001-95', 'Tech Solutions', 'vendas@tech.com');

INSERT INTO produto (nome_produto, quantidade, preco_venda, estoque_minimo, fk_categoria_idcategoria) VALUES 
('Mouse Gamer', 15, 89.90, 5, 1);

INSERT INTO config_acessibilidade (fk_usuario_idusuario) 
SELECT idusuario FROM usuario;

SELECT 'Banco criado com sucesso!' as Status;
