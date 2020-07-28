CREATE DATABASE Establishments

CREATE TABLE Categorias (
	Id INT Identity(1,1) Primary Key NOT NULL,
	Nome VARCHAR(60) NOT NULL,
	TelefoneObrigatorio BIT NOT NULL,
	DataCadastro datetime NOT NULL,
	Ativo bit NOT NULL
)

CREATE TABLE Estabelecimentos (
	Id INT Identity(1,1) Primary Key NOT NULL,
	RazaoSocial VARCHAR(100) NOT NULL,
	NomeFantasia VARCHAR(60),
	CNPJ VARCHAR(14) NOT NULL,
	Email VARCHAR(50),
	Endereco VARCHAR(100),
	Cidade VARCHAR(40),
	Estado VARCHAR(2),
	Telefone VARCHAR(14),
	DataCadastro datetime NOT NULL,
	CategoriaId int NOT NULL,
	Ativo bit NOT NULL,
	BancoAgencia VARCHAR(4),
	BancoConta VARCHAR(6)
)