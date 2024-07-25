--Categoria
CREATE TABLE Categoria(
id_categoria int PRIMARY KEY IDENTITY(1, 1),
ds_categoria varchar(100) NOT NULL,
dt_inclusao datetime,
dt_alteracao datetime
);

--Produto
CREATE TABLE Produto(
id_produto int PRIMARY KEY IDENTITY(1, 1),
nm_produto varchar(100) NOT NULL,
vl_preco decimal(10, 2) NOT NULL,
ds_descricao varchar(500),
id_categoria int,
url_imagem varchar(500),
dt_inclusao datetime,
dt_alteracao datetime,
FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria)
);


--Cliente
CREATE TABLE Cliente(
id_cliente int PRIMARY KEY IDENTITY(1, 1),
nm_cliente varchar(100),
cpf_cliente char(11),
dt_inclusao datetime,
dt_alteracao datetime
);