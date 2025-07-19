--CREATE TABLES
CREATE TABLE VeiculoMarca (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
)


CREATE TABLE VeiculoCor (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
)
CREATE TABLE Veiculo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MarcaId INT NOT NULL,
    Modelo VARCHAR(100) NOT NULL,
    Ano INT NOT NULL,
    Placa VARCHAR(10) NOT NULL UNIQUE,
    Km INT NULL,
    Cor VARCHAR(50) NOT NULL,
    Preco DECIMAL(18,2) NOT NULL
	CONSTRAINT FK_Marca FOREIGN KEY (MarcaId) REFERENCES VeiculoMarca(Id)

);


CREATE TABLE Portal (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL UNIQUE
);


CREATE TABLE Pacote (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL UNIQUE
);


CREATE TABLE VeiculoPortalPacote (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VeiculoId INT NOT NULL,
    PortalId INT NOT NULL,
    PacoteId INT NOT NULL,
    CONSTRAINT FK_Veiculo FOREIGN KEY (VeiculoId) REFERENCES Veiculo(Id),
    CONSTRAINT FK_Portal FOREIGN KEY (PortalId) REFERENCES Portal(Id),
    CONSTRAINT FK_Pacote FOREIGN KEY (PacoteId) REFERENCES Pacote(Id),
    CONSTRAINT UQ_VeiculoPortal UNIQUE (VeiculoId, PortalId)
);

CREATE TABLE Opcional (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
)

CREATE TABLE OpcionalVeiculo (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	VeiculoId INT NOT NULL,
	OpcionalId INT NOT NULL,
	CONSTRAINT FK_VeiculoOpcional FOREIGN KEY (VeiculoId) REFERENCES Veiculo(Id),
    CONSTRAINT FK_Opcional FOREIGN KEY (OpcionalId) REFERENCES Opcional(Id),
)

CREATE TABLE VeiculoImagem (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Url VARCHAR(MAX) NOT NULL,
    Ordem INT DEFAULT 0,
    VeiculoId INT NOT NULL,
    CONSTRAINT FK_ImagemVeiculo FOREIGN KEY (VeiculoId) REFERENCES Veiculo(Id)
)

--INSERT DADOS
INSERT INTO VeiculoMarca (Nome) Values
('Chevrolet'),('Ford'),('Fiat'),('Volkswagen'),('Peugeot'),('Kia'),('Hyundai'),('Toyota'),('Honda'),('Jeep'),('BYD'),('BMW'),('Mercedes'),('Renault')

INSERT INTO VeiculoCor (Nome) VALUES
('Branco'),('Preto'),('Prata'),('Chumbo'),('Branco Pérola'),('Vermelho'),('Azul Metálico')

INSERT INTO Opcional (Nome) VALUES 
('Ar Condicionado'), ('Direção Hidráulica'), ('Direção Elétrica'), ('Alarme'), ('Trava Elétrica'), ('Vidros Elétricos'), 
('Airbag Duplo'), ('Airbag Lateral'), ('Freios ABS'), ('Controle de Estabilidade'), ('Controle de Tração'), 
('Assistente de Partida em Rampa'), ('Farol de Neblina'), ('Farol de LED'), ('Rodas de Liga Leve'), ('Teto Solar'), 
('Sensor de Estacionamento'), ('Câmera de Ré'), ('Piloto Automático'), ('Computador de Bordo'), ('Bancos em Couro'), 
('Bancos com Ajuste Elétrico'), ('Chave Presencial'), ('Partida por Botão'), ('Central Multimídia'), ('Navegador GPS'), 
('Bluetooth'), ('Apple CarPlay / Android Auto'), ('Volante Multifuncional'), ('Isofix para Cadeirinha'), 
('Retrovisores com Rebatimento Elétrico')