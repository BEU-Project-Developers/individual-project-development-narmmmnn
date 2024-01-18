CREATE TABLE [dbo].[Registration_tbl] (
    [Id]       INT NOT NULL         ,
    [f_name]   VARCHAR (50) NOT NULL,
    [l_name]   VARCHAR (50) NOT NULL,
    [b_date]   DATE         NOT NULL,
    [gender]   VARCHAR (50) NOT NULL,
    [address]  VARCHAR (50) NOT NULL,
    [email]    VARCHAR (50) NOT NULL,
    [password] VARCHAR (50) NOT NULL, 
    CONSTRAINT [PK_Registration_tbl] PRIMARY KEY ([Id])
);

