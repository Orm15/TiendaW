CREATE TABLE [dbo].[Usuario] (
    [idUsuario] INT          NOT NULL,
    [nombre]    VARCHAR (50) NULL,
    [correo]    VARCHAR (50) NULL,
    [password]  VARCHAR (50) NULL,
    [tipo]      VARCHAR (50) NULL,
    [estado]    BIT          NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC)
);

