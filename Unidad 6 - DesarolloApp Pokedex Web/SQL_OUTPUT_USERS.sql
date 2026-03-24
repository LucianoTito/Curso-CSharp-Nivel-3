-- 1. Creamos la tabla USERS con todos los campos que necesitaremos a futuro 
CREATE TABLE USERS (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(100) NOT NULL,
    Pass VARCHAR(50) NOT NULL,
    Nombre VARCHAR(50) NULL,
    Apellido VARCHAR(50) NULL,
    FechaNacimiento DATE NULL,
    ImagenPerfil VARCHAR(250) NULL,
    Admin BIT DEFAULT 0 -- Usamos BIT (0 o 1) para verdadero/falso. Por defecto es 0 (Falso) 
)
GO

-- 2. Creamos el Procedimiento Almacenado con el truco del OUTPUT 
CREATE PROCEDURE insertarNuevo
    @email VARCHAR(100),
    @pass VARCHAR(50)
AS
BEGIN
    -- Insertamos solo los campos obligatorios 
    INSERT INTO USERS (Email, Pass, Admin)
    
    -- LA MAGIA: Interceptamos el registro recién creado y escupimos su Id autoincremental 
    OUTPUT inserted.Id
    --Al agregar la línea OUTPUT inserted.Id, le estamos diciendo a SQL Server: "Justo antes de terminar, agarrá el registro que acabás de insertar, leé qué número de Id le pusiste, y devolveme ese número como si fuera el resultado de un SELECT"
    
    VALUES (@email, @pass, 0)
END
GO