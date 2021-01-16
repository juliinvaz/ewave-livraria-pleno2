IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Livraria')
BEGIN
    CREATE DATABASE [Livraria];
END
GO

USE [Livraria];
GO
CREATE TABLE [dbo].[Estado] 
(
    [Id] INT NOT NULL,
    [Nome] VARCHAR(75) NOT NULL,
    [Uf] VARCHAR(2) NOT NULL,
    CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
)
GO

CREATE TABLE [dbo].[Cidade] 
(
    [Id] INT NOT NULL,
    [Nome] VARCHAR(255) NOT NULL,
    [EstadoId] INT NOT NULL,
    CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
    CONSTRAINT [FK_Cidade_Estado] FOREIGN KEY ([EstadoId]) REFERENCES [dbo].[Estado](Id)
)
GO

CREATE TABLE [dbo].[Endereco] 
(
    [Id] INT IDENTITY (1,1) NOT NULL,
    [Logradouro] VARCHAR(255) NOT NULL,
    [Numero] VARCHAR(255) NOT NULL,
    [CEP] VARCHAR(8) NOT NULL,
    [CidadeId] INT NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
    CONSTRAINT [FK_Endereco_Cidade] FOREIGN KEY ([CidadeId]) REFERENCES [dbo].[Cidade](Id)
)
GO

CREATE TABLE [dbo].[InstituicaoEnsinoSituacao] 
(
    [Id] INT NOT NULL,
    [Nome] VARCHAR(180) NOT NULL,
    CONSTRAINT [PK_InstituicaoEnsinoSituacao] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[InstituicaoEnsino] 
(
    [Id] INT IDENTITY (1,1) NOT NULL,
    [Nome] VARCHAR(255) NOT NULL,
    [CNPJ] VARCHAR(14) NOT NULL UNIQUE,
    [Telefone] VARCHAR(11) NOT NULL,
    [SituacaoId] INT NOT NULL,
    [EnderecoId] INT NOT NULL,
    CONSTRAINT [PK_InstituicaoEnsino] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
    CONSTRAINT [FK_InstituicaoEnsino_Endereco] FOREIGN KEY ([EnderecoId]) REFERENCES [dbo].[Endereco](Id),
    CONSTRAINT [FK_InstituicaoEnsino_InstituicaoEnsinoSituacao] FOREIGN KEY ([SituacaoId]) REFERENCES [dbo].[InstituicaoEnsinoSituacao](Id)
)
GO

CREATE TABLE [dbo].[UsuarioSituacao] 
(
    [Id] INT NOT NULL,
    [Nome] VARCHAR(180) NOT NULL,
    CONSTRAINT [PK_UsuarioSituacao] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[Usuario] 
(
    [Id] INT IDENTITY (1,1) NOT NULL,
    [Nome] VARCHAR(255) NOT NULL,
    [CPF] VARCHAR(11) NOT NULL UNIQUE,
    [Telefone] VARCHAR(11) NULL,
    [Email] VARCHAR(255) NULL,
    [SituacaoId] INT NOT NULL,
    [EnderecoId] INT NULL,
    [InstituicaoId] INT NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
    CONSTRAINT [FK_Usuario_Endereco] FOREIGN KEY ([EnderecoId]) REFERENCES [dbo].[Endereco](Id),
    CONSTRAINT [FK_Usuario_IntituicaoEnsino] FOREIGN KEY ([InstituicaoId]) REFERENCES [dbo].[InstituicaoEnsino](Id),
    CONSTRAINT [FK_InstituicaoEnsino_UsuarioSituacao] FOREIGN KEY ([SituacaoId]) REFERENCES [dbo].[UsuarioSituacao](Id)
)
GO

CREATE TABLE [dbo].[LivroSituacao] 
(
    [Id] INT NOT NULL,
    [Nome] VARCHAR(180) NOT NULL,
    CONSTRAINT [PK_LivroSituacao] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[Livro] 
(
    [Id] INT IDENTITY (1,1) NOT NULL,
    [Titulo] VARCHAR(255) NOT NULL,
    [Genero] VARCHAR(255) NOT NULL,
    [Autor] VARCHAR(255) NOT NULL,
    [Sinopse] VARCHAR(4000) NOT NULL,
    [Capa] VARCHAR(500) NOT NULL,
    [SituacaoId] INT NOT NULL,
    CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
    CONSTRAINT [FK_InstituicaoEnsino_LivroSituacao] FOREIGN KEY ([SituacaoId]) REFERENCES [dbo].[LivroSituacao](Id)
)
GO

CREATE TABLE [dbo].[Emprestimo] 
(
    [Id] INT IDENTITY (1,1) NOT NULL,
    [Data] DATETIME NOT NULL,
    [DataDevolucao] DATETIME NULL,
    [UsuarioId] INT NOT NULL,
    [LivroId] INT NOT NULL,
    CONSTRAINT [PK_Emprestimo] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
    CONSTRAINT [FK_Emprestimo_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario](Id),
    CONSTRAINT [FK_Emprestimo_Livro] FOREIGN KEY ([LivroId]) REFERENCES [dbo].[Livro](Id)
)
GO

CREATE TABLE [dbo].[ReservaSituacao] 
(
    [Id] INT NOT NULL,
    [Nome] VARCHAR(180) NOT NULL,
    CONSTRAINT [PK_ReservaSituacao] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[Reserva] 
(
    [Id] INT IDENTITY (1,1) NOT NULL,
    [Data] DATETIME NOT NULL,
    [SituacaoId] INT NOT NULL,
    [UsuarioId] INT NOT NULL,
    [LivroId] INT NOT NULL,
    CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
    CONSTRAINT [FK_Reserva_ReservaSituacao] FOREIGN KEY ([SituacaoId]) REFERENCES [dbo].[ReservaSituacao](Id),
    CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario](Id),
    CONSTRAINT [FK_Reserva_Livro] FOREIGN KEY ([LivroId]) REFERENCES [dbo].[Livro](Id)
)
GO
