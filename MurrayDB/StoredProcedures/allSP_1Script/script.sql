USE [Murray]
GO
/****** Object:  StoredProcedure [dbo].[CATEGORIA_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Creación de nueva categoría>
-- =============================================
CREATE PROCEDURE [dbo].[CATEGORIA_CREATE]
	@Nombre VARCHAR(MAX)
AS
BEGIN
	-- VALIDATIONS
	IF (@Nombre = '' OR @Nombre IS NULL)
		RAISERROR('NOMBRE_IS_EMPTY',16,1)

	IF EXISTS (SELECT * FROM Categoria WHERE Nombre = @Nombre AND Estado = 1)
		RAISERROR('NOMBRE_ALREADY_EXISTS',16,1)

	-- ACTION
	INSERT INTO Categoria(Nombre, Estado) VALUES (@Nombre, 1)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Categoria')

	-- RESULT
	SELECT * FROM Categoria WHERE Id = @INSERTED_ID
END
GO
/****** Object:  StoredProcedure [dbo].[CATEGORIA_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Eliminiación de categoría>
-- =============================================
CREATE PROCEDURE [dbo].[CATEGORIA_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM Categoria WHERE Id = @Id AND Estado = 0) 
		RAISERROR('CATEGORY_CURRENTLY_REMOVED',16,1)

	-- ACTION
	UPDATE Categoria SET Estado = 0 WHERE Id = @Id

	-- RESULT
	SELECT * FROM Categoria WHERE Id = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[CATEGORIA_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Obtención de categorías>
-- =============================================
CREATE PROCEDURE [dbo].[CATEGORIA_GET]
	@Id INT,
	@Nombre VARCHAR(MAX),
	@Estado BIT
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Categoria
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
		AND (@Estado IS NULL OR Estado = @Estado)
END
GO
/****** Object:  StoredProcedure [dbo].[CATEGORIA_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Actualización de categoría>
-- =============================================
CREATE PROCEDURE [dbo].[CATEGORIA_UPDATE]
	@Id INT,
	@Nombre VARCHAR(MAX)
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@Nombre = '' OR @Nombre IS NULL)
		RAISERROR('NOMBRE_IS_EMPTY',16,1)

	IF EXISTS (SELECT * FROM Categoria WHERE Nombre = @Nombre AND Estado = 1)
		RAISERROR('NOMBRE_ALREADY_EXISTS',16,1)

	-- ACTION
	UPDATE Categoria SET Nombre = @Nombre WHERE Id = @Id AND Estado = 1

	-- RESULT
	SELECT * FROM Categoria WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[CLIENTE_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Creación de nuevo cliente>
-- =============================================
CREATE PROCEDURE [dbo].[CLIENTE_CREATE]
	@IdContacto INT
AS
BEGIN
	-- VALIDATIONS
	IF (@IdContacto = 0 OR @IdContacto IS NULL)
		RAISERROR('ID_CLIENTE_NOT_EXISTS',16,1)

	-- ACTION
	INSERT INTO Cliente(Estado, IdContacto) VALUES (1, @IdContacto)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Cliente')

	-- RESULT
	SELECT * FROM Cliente WHERE Id = @INSERTED_ID
END

execute dbo.CLIENTE_CREATE @IdContacto = 1
GO
/****** Object:  StoredProcedure [dbo].[CLIENTE_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Eliminiación de cliente>
-- =============================================
CREATE PROCEDURE [dbo].[CLIENTE_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM Cliente WHERE Id = @Id AND Estado = 0) 
		RAISERROR('PROVIDER_CURRENTLY_REMOVED',16,1)

	-- ACTION
	UPDATE Cliente SET Estado = 0 WHERE Id = @Id

	-- RESULT
	SELECT * FROM Cliente WHERE Id = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[CLIENTE_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Obtención de clientes>
-- =============================================
CREATE PROCEDURE [dbo].[CLIENTE_GET]
	@Id INT,
	@Estado BIT,
	@IdContacto INT
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Cliente
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Estado IS NULL OR Estado = @Estado)
		AND (@IdContacto IS NULL OR IdContacto = @IdContacto)
END
GO
/****** Object:  StoredProcedure [dbo].[CLIENTE_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Actualización de cliente>
-- =============================================
CREATE PROCEDURE [dbo].[CLIENTE_UPDATE]
	@Id INT,
	@IdContacto INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@IdContacto = 0 OR @IdContacto IS NULL)
		RAISERROR('ID_CONTACTO_NOT_EXISTS',16,1)

	-- ACTION
	UPDATE Cliente SET IdContacto = @IdContacto WHERE Id = @Id AND Estado = 1

	-- RESULT
	SELECT * FROM Cliente WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[COMPRA_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Creación de nueva compra>
-- =============================================
CREATE PROCEDURE [dbo].[COMPRA_CREATE]
	@Fecha DATETIME,
	@IdProveedor INT,
	@IdEmpleado INT
AS
BEGIN
	-- VALIDATIONS
	IF (@Fecha = '' OR @Fecha IS NULL)
		RAISERROR('FECHA_IS_EMPTY', 16, 1)

	IF (@IdProveedor = 0 OR @IdProveedor IS NULL)
		RAISERROR('ID_PROVEEDOR_NOT_EXISTS',16,1)

	IF (@IdEmpleado = 0 OR @IdEmpleado IS NULL)
		RAISERROR('ID_EMPLEADO_NOT_EXISTS', 16, 1)

	-- ACTION
	INSERT INTO Compra(Fecha, IdProveedor, IdEmpleado)
	VALUES (@Fecha, @IdProveedor, @IdEmpleado)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Compra')

	-- RESULT
	SELECT * FROM Compra WHERE Id = @INSERTED_ID
END

GO
/****** Object:  StoredProcedure [dbo].[COMPRA_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Obtención de compras>
-- =============================================
CREATE PROCEDURE [dbo].[COMPRA_DELETE]
	@Id INT
	
AS
BEGIN
	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_NOT_EXISTS',16,1)
	ELSE
	--ACTION
	SELECT * FROM Compra WHERE Id = @Id AND Estado IS NULL
	UPDATE Compra SET Estado = 'CANCELADO'
	WHERE Id = @Id

	-- RESULT
	SELECT * FROM Compra WHERE Id=@Id AND Estado = 'CANCELADO'
	
END
GO
/****** Object:  StoredProcedure [dbo].[COMPRA_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Obtención de compras>
-- =============================================
CREATE PROCEDURE [dbo].[COMPRA_GET]
	@Id INT,
	@Fecha DATETIME,
	@IdProveedor INT,
	@IdEmpleado INT
AS
BEGIN
	--RESULT
	SELECT
		*
	FROM
		Compra
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Fecha IS NULL OR Fecha = @Fecha)
		AND (@IdProveedor IS NULL OR IdProveedor = @IdProveedor)
		AND (@IdEmpleado IS NULL OR IdEmpleado = @IdEmpleado)
END
GO
/****** Object:  StoredProcedure [dbo].[COMPRA_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Actualización de compras>
-- =============================================
CREATE PROCEDURE [dbo].[COMPRA_UPDATE]
	@Id INT,
	@Fecha DATETIME,
	@IdProveedor INT,
	@IdEmpleado INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@Fecha = '' OR @Fecha IS NULL)
		RAISERROR('FECHA_IS_EMPTY',16,1)

	IF (@IdProveedor = 0 OR @IdProveedor IS NULL)
		RAISERROR('ID_PROVEEDOR_NOT_EXISTS',16,1)

	IF (@IdEmpleado = 0 OR @IdEmpleado IS NULL)
		RAISERROR('ID_EMPLEADO_NOT_EXISTS',16,1)

	-- ACTION
	UPDATE Compra SET 
	Fecha = @Fecha, IdProveedor = @IdProveedor, IdEmpleado = @IdEmpleado
	WHERE Id = @Id

	-- RESULT
	SELECT * FROM Compra WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[CONTACTO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <24/11/2021>
-- Description:	<Creación de nuevo contacto>
-- =============================================

--EXEC CONTACTO_CREATE 'EJEMPLO', 'EJEMPLO','Perez','Perez', '', 'Managua',1

CREATE PROCEDURE [dbo].[CONTACTO_CREATE]
	--@INSERTED_ID int,
	@PrimerNombre NVARCHAR(MAX),
	@SegundoNombre VARCHAR(MAX),
	@PrimerApellido VARCHAR(MAX),
	@SegundoApellido VARCHAR(MAX),
	@FechaNacimiento DATE,
	@Direccion NVARCHAR(MAX),
	@IdMunicipio INT
AS
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Contacto')
	SET @INSERTED_ID =(SELECT ISNULL(max(Id),0)+1 FROM Contacto)
BEGIN
	-- VALIDATIONS
	IF (@PrimerNombre = '' OR @PrimerNombre IS NULL)
		RAISERROR('Primer_Nombre_IS_EMPTY', 16, 1)

	IF (LEN(@PrimerNombre) > 50)
		RAISERROR('Primer_Nombre_LENGTH_EXCEED', 16, 1)

	IF (LEN(@SegundoNombre) > 50)
		RAISERROR('Segundo_Nombre_LENGTH_EXCEED', 16, 1)

	IF (@PrimerApellido = '' OR @PrimerApellido IS NULL)
		RAISERROR('Primer_Apellido_IS_EMPTY',16,1)

	IF (LEN(@PrimerApellido) > 50)
		RAISERROR('Primer_Apellido_LENGTH_EXCEED', 16, 1)

	IF (LEN(@SegundoApellido) > 50)
		RAISERROR('Segundo_Apellido_LENGTH_EXCEED', 16, 1)

	IF (LEN(@Direccion) > 50)
		RAISERROR('Direccion_LENGTH_EXCEED', 16, 1)

	IF EXISTS (SELECT TOP 1 1 FROM Contacto WHERE UPPER(PrimerNombre) = UPPER(@PrimerNombre) AND UPPER(PrimerApellido) = UPPER(@PrimerApellido))
		RAISERROR('NOMBRE_AND_APELLIDO_ALREADY_EXISTS', 16, 1)

	-- ACTION
	INSERT INTO Contacto (iD, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, FechaNacimiento, Direccion,IdMunicipio) 
	VALUES (@INSERTED_ID, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Direccion, @IdMunicipio)

	-- RESULT
	SELECT * FROM Contacto WHERE Id = @INSERTED_ID
END
GO
/****** Object:  StoredProcedure [dbo].[CONTACTO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Eliminiación de contacto>
-- =============================================
CREATE PROCEDURE [dbo].[CONTACTO_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS

	-- ACTION
	SELECT *  INTO #DELETED FROM Contacto WHERE Id = @Id
	DELETE Contacto WHERE Id = @Id

	-- RESULT
	SELECT * FROM #DELETED WHERE Id = @Id
	DROP TABLE #DELETED
END
GO
/****** Object:  StoredProcedure [dbo].[CONTACTO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <22/02/2022>
-- Description:	<Obtención de contactos>
-- =============================================
CREATE PROCEDURE [dbo].[CONTACTO_GET]
	@Id INT,
	@PrimerNombre NVARCHAR(MAX),
	@SegundoNombre VARCHAR(MAX),
	@PrimerApellido VARCHAR(MAX),
	@SegundoApellido VARCHAR(MAX),
	@FechaNacimiento DATE,
	@Direccion NVARCHAR(MAX),
	@IdMunicipio INT
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Contacto
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@PrimerNombre IS NULL OR PrimerNombre LIKE '%' + @PrimerNombre + '%')
		AND (@SegundoNombre IS NULL OR SegundoNombre LIKE '%' + @SegundoNombre + '%')
		AND (@PrimerApellido IS NULL OR PrimerApellido LIKE '%' + @PrimerApellido + '%')
		AND (@SegundoApellido IS NULL OR SegundoApellido LIKE '%' + @SegundoApellido + '%')
		AND (@FechaNacimiento IS NULL OR FechaNacimiento = @FechaNacimiento)
		AND (@Direccion IS NULL OR Direccion LIKE '%' + @Direccion + '%')
		AND (@IdMunicipio IS NULL OR IdMunicipio = @IdMunicipio)
END
GO
/****** Object:  StoredProcedure [dbo].[CONTACTO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <24/11/2021>
-- Description:	<Actualización de contacto>
-- =============================================
CREATE PROCEDURE [dbo].[CONTACTO_UPDATE]
	@Id INT,
	@PrimerNombre NVARCHAR(MAX),
	@SegundoNombre VARCHAR(MAX),
	@PrimerApellido VARCHAR(MAX),
	@SegundoApellido VARCHAR(MAX),
	@FechaNacimiento DATE,
	@Direccion NVARCHAR(MAX),
	@IdMunicipio INT
AS
BEGIN

	-- VALIDATIONS
	IF (@PrimerNombre = '' OR @PrimerNombre IS NULL)
		RAISERROR('Primer_Nombre_IS_EMPTY', 16, 1)

	IF (LEN(@PrimerNombre) > 50)
		RAISERROR('Primer_Nombre_LENGTH_EXCEED', 16, 1)

	IF (LEN(@SegundoNombre) > 50)
		RAISERROR('Segundo_Nombre_LENGTH_EXCEED', 16, 1)

	IF (@PrimerApellido = '' OR @PrimerApellido IS NULL)
		RAISERROR('Primer_Apellido_IS_EMPTY',16,1)

	IF (LEN(@PrimerApellido) > 50)
		RAISERROR('Primer_Apellido_LENGTH_EXCEED', 16, 1)

	IF (LEN(@SegundoApellido) > 50)
		RAISERROR('Segundo_Apellido_LENGTH_EXCEED', 16, 1)

	IF (LEN(@Direccion) > 50)
		RAISERROR('Direccion_LENGTH_EXCEED', 16, 1)

	IF EXISTS (SELECT TOP 1 1 FROM Contacto WHERE UPPER(PrimerNombre) = UPPER(@PrimerNombre) AND UPPER(PrimerApellido) = UPPER(@PrimerApellido))
		RAISERROR('NOMBRE_AND_APELLIDO_ALREADY_EXISTS', 16, 1)

	-- ACTION
	UPDATE Contacto SET 
	PrimerNombre = @PrimerNombre, 
	SegundoNombre = @SegundoNombre,
	PrimerApellido = @PrimerApellido,
	SegundoApellido = @SegundoApellido,
	FechaNacimiento = @FechaNacimiento,
	Direccion = @Direccion,
	IdMunicipio = @IdMunicipio
	WHERE Id = @Id

	-- RESULT
	SELECT * FROM Contacto WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[CONTACTOJURIDICO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONTACTOJURIDICO_CREATE]
@N_Empresa NVARCHAR(50),
@R_social NVARCHAR(50),
@IdMunicipio INT
AS
DECLARE @INSERTED_ID INT = IDENT_CURRENT('ContactoJuridico')
	SET @INSERTED_ID =(SELECT ISNULL(max(Id),0)+1 FROM ContactoJuridico)
BEGIN
	-- VALIDATIONS
	IF (@N_Empresa = '' OR @N_Empresa IS NULL)
	RAISERROR ('N_Empresa_IS_EMPTY', 16, 1)

	IF (LEN(@N_Empresa) > 50)
		RAISERROR('N_Empresa_LENGTH_EXCEED', 16, 1)

	IF (@R_social = '' OR @R_social IS NULL)
	RAISERROR ('N_Empresa_IS_EMPTY', 16, 1)

	IF (LEN(@R_social) > 50)
		RAISERROR('R_social_LENGTH_EXCEED', 16, 1)

	IF (@IdMunicipio = '' OR @IdMunicipio IS NULL)
	RAISERROR ('ID_muni_IS_EMPTY', 16, 1)

	IF EXISTS (SELECT TOP 1 1 FROM ContactoJuridico WHERE UPPER(NombreEmpresa) = UPPER(@N_Empresa) AND UPPER(RazonSocial) = UPPER(@R_social))
		RAISERROR('NOMBRE_EMPRESA_AND_RAZON_SOCIAL_ALREADY_EXISTS', 16, 1)
	
	-- ACTION
	INSERT INTO ContactoJuridico(Id, NombreEmpresa, RazonSocial, IdMunicipio) 
	VALUES (@INSERTED_ID, @N_Empresa, @R_social, @IdMunicipio)

END
GO
/****** Object:  StoredProcedure [dbo].[CONTACTOJURIDICO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<James Gutierrez>
-- Create date: <22/02/2022>
-- Description:	<DELETE para la tabla cliente juridico>
-- =============================================
CREATE PROCEDURE [dbo].[CONTACTOJURIDICO_DELETE]
@ID INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM [dbo].[ContactoJuridico] WHERE Id = @ID AND Estado = 0)
		RAISERROR('CONTACTOJURIDICO_CURRENTLY_REMOVED',16,1)

		-- ACTION
		UPDATE [dbo].[ContactoJuridico] SET Estado = 0 WHERE Id = @ID

		-- RESULT
		SELECT * FROM [dbo].[ContactoJuridico] WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[CONTACTOJURIDICO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <22/02/2022>
-- Description:	<GET para la tabla cliente juridico>
-- =============================================
CREATE PROCEDURE [dbo].[CONTACTOJURIDICO_GET]
	@Id INT,
	@NombreEmpresa NVARCHAR(50),
	@RazonSocial NVARCHAR(50),
	@IdMunicipio INT
AS
BEGIN
	--RESULT
	SELECT 
		* 
	FROM 
		[dbo].[ContactoJuridico]
	WHERE
	(@Id IS NULL OR Id = @Id)
	AND (@NombreEmpresa IS NULL OR [NombreEmpresa] LIKE '%' + @NombreEmpresa + '%')
	AND (@RazonSocial IS NULL OR [RazonSocial] LIKE '%' + @RazonSocial + '%')
	AND(@IdMunicipio IS NULL OR [IdMunicipio] = @IdMunicipio)

END
GO
/****** Object:  StoredProcedure [dbo].[CONTACTOJURIDICO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<James Gutierrez>
-- Create date: <22/02/2022>
-- Description:	<UPDATE para la tabla cliente juridico>
-- =============================================
CREATE PROCEDURE [dbo].[CONTACTOJURIDICO_UPDATE]
@ID INT,
@N_Empresa NVARCHAR(50),
@R_social NVARCHAR(50),
@ID_muni INT
AS
IF(@ID=(SELECT Id FROM ContactoJuridico WHERE Id=@ID))
BEGIN
	IF(@ID_muni=(SELECT Id FROM Municipio WHERE Id=@ID_muni ))
	BEGIN
		IF(@ID <= 0 OR @N_Empresa = '' OR @R_social= '' OR @ID_muni <= 0)
		BEGIN
			PRINT 'EL VALOR DE LOS PARAMETROS NO PUEDE SER NULO O NEGATIVO'
		END
		ELSE
		BEGIN
			  UPDATE ContactoJuridico SET NombreEmpresa =@N_Empresa,RazonSocial=@R_social,IdMunicipio=@ID_muni
			  WHERE Id=@ID
		END
	END
	ELSE
	BEGIN
		PRINT 'NO SE ENCONTRO EL MUNICIPIO'
	END
END
ELSE
BEGIN
	PRINT 'EL CONTACTO NO EXISTE'
END
GO
/****** Object:  StoredProcedure [dbo].[DEPARTAMENTO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <21/11/2021>
-- Description:	<Creación de nuevo departamento>
-- =============================================
CREATE PROCEDURE [dbo].[DEPARTAMENTO_CREATE]
	@Nombre NVARCHAR(MAX)
AS
BEGIN
	-- VALIDATIONS
	IF (@Nombre = '' OR @Nombre IS NULL)
		RAISERROR('NOMBRE_IS_EMPTY', 16, 1)

	IF (LEN(@Nombre) > 50)
		RAISERROR('NOMBRE_LENGTH_EXCEED', 16, 1)

	IF EXISTS (SELECT TOP 1 1 FROM Departamento WHERE UPPER(@Nombre) = UPPER(@Nombre))
		RAISERROR('NOMBRE_ALREADY_EXISTS', 16, 1)

	-- ACTION
	INSERT INTO Departamento (Nombre) VALUES (@Nombre)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Departamento')

	-- RESULT
	SELECT * FROM Departamento WHERE Id = @INSERTED_ID
END
GO
/****** Object:  StoredProcedure [dbo].[DEPARTAMENTO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <21/11/2021>
-- Description:	<Eliminiación de departamento>
-- =============================================
CREATE PROCEDURE [dbo].[DEPARTAMENTO_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS

	-- ACTION
	SELECT *  INTO #DELETED FROM Departamento WHERE Id = @Id
	DELETE Departamento WHERE Id = @Id

	-- RESULT
	SELECT * FROM #DELETED WHERE Id = @Id
	DROP TABLE #DELETED
END
GO
/****** Object:  StoredProcedure [dbo].[DEPARTAMENTO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <21/11/2021>
-- Description:	<Obtención de departamentos>
-- =============================================
CREATE PROCEDURE [dbo].[DEPARTAMENTO_GET]
	@Id INT,
	@Nombre NVARCHAR(MAX)
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Departamento
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[DEPARTAMENTO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <21/11/2021>
-- Description:	<Actualización de departamento>
-- =============================================
CREATE PROCEDURE [dbo].[DEPARTAMENTO_UPDATE]
	@Id INT,
	@Nombre NVARCHAR(MAX)
AS
BEGIN

	-- VALIDATIONS
	IF (@Nombre = '' OR @Nombre IS NULL)
		RAISERROR('NOMBRE_IS_EMPTY', 16, 1)

	IF (LEN(@Nombre) > 50)
		RAISERROR('NOMBRE_LENGTH_EXCEED', 16, 1)

	IF EXISTS (SELECT TOP 1 1 FROM Departamento WHERE UPPER(@Nombre) = UPPER(@Nombre))
		RAISERROR('NOMBRE_ALREADY_EXISTS', 16, 1)

	-- ACTION
	UPDATE Departamento SET Nombre = @Nombre WHERE Id = @Id

	-- RESULT
	SELECT * FROM Departamento WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DETALLE_COMPRA_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Creación de nuevo detalle de compra>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_COMPRA_CREATE]
	@IdCompra INT,
	@IdProducto INT,
	@Cantidad INT,
	@Precio MONEY,
	@Descuento FLOAT
AS
BEGIN
	-- VALIDATIONS
	IF (@IdCompra = 0 OR @IdCompra IS NULL)
		RAISERROR('ID_COMPRA_NOT_EXISTS', 16, 1)

	IF (@IdProducto = 0 OR @IdProducto IS NULL)
		RAISERROR('ID_PRODUCTO_NOT_EXISTS',16,1)

	IF (@Cantidad = 0 OR  @Cantidad IS NULL)
		RAISERROR('CANTIDAD_IS_EMPTY', 16, 1)

	IF (@Precio = 0 OR  @Precio IS NULL)
		RAISERROR('CANTIDAD_IS_EMPTY', 16, 1)

	IF (@Descuento IS NULL)
		RAISERROR('DESCUENTO_IS_EMPTY', 16, 1)

	-- ACTION
	INSERT INTO DetalleCompra(IdCompra, IdProducto, Cantidad, Precio, Descuento)
	VALUES (@IdCompra, @IdProducto, @Cantidad, @Precio, @Descuento)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('DetalleCompra')

	-- RESULT
	SELECT * FROM DetalleCompra WHERE IdCompra = @IdCompra AND IdProducto = @IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[DETALLE_COMPRA_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Eliminiación de detalle de compra>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_COMPRA_DELETE]
	@IdCompra INT,
	@IdProducto INT
AS
BEGIN
	-- VALIDATIONS
	IF (@IdCompra = 0 OR @IdCompra IS NULL)
		RAISERROR('ID_NOT_EXISTS',16,1)

	IF (@IdProducto = 0 OR @IdProducto IS NULL)
		RAISERROR('ID_PRODUCTO_NOT_EXISTS',16,1)

	-- ACTION
	SELECT *  INTO #DELETED FROM DetalleCompra WHERE IdCompra = @IdCompra AND IdProducto = @IdProducto
	DELETE DetalleCompra WHERE IdCompra = @IdCompra AND IdProducto = @IdProducto

	-- RESULT
	SELECT * FROM #DELETED WHERE IdCompra = @IdCompra AND IdProducto = @IdProducto
	DROP TABLE #DELETED
END
GO
/****** Object:  StoredProcedure [dbo].[DETALLE_COMPRA_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <25/11/2021>
-- Description:	<Obtención de detalle de compras>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_COMPRA_GET]
	@IdCompra INT,
	@IdProducto INT,
	@Cantidad INT,
	@Precio MONEY,
	@Descuento FLOAT
AS
BEGIN
	--RESULT
	SELECT
		*
	FROM
		DetalleCompra
	WHERE
		(@IdCompra IS NULL OR IdCompra = @IdCompra)
		AND (@IdProducto IS NULL OR IdProducto = @IdProducto)
		AND (@Cantidad IS NULL OR Cantidad = @Cantidad)
		AND (@Precio IS NULL OR Precio = @Precio)
		AND (@Descuento IS NULL OR Descuento = @Descuento)
END
GO
/****** Object:  StoredProcedure [dbo].[DETALLE_COMPRA_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Actualización de detalle de compra>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_COMPRA_UPDATE]
	@IdCompra INT,
	@IdProducto INT,
	@Cantidad INT,
	@Precio MONEY,
	@Descuento FLOAT
AS
BEGIN

	-- VALIDATIONS
	IF (@IdCompra = 0 OR @IdCompra IS NULL)
		RAISERROR('ID_COMPRA_IS_EMPTY', 16, 1)

	IF (@IdProducto = 0 OR @IdProducto IS NULL)
		RAISERROR('ID_PRODUCTO_IS_EMPTY', 16, 1)

	IF (@Cantidad = 0 OR @Cantidad IS NULL)
		RAISERROR('CANTIDAD_IS_EMPTY', 16, 1)

	IF (@Precio = 0 OR @Precio IS NULL)
		RAISERROR('PRECIO_IS_EMPTY', 16, 1)

	IF (@Descuento IS NULL)
		RAISERROR('DESCUENTO_NOT_EXISTS', 16, 1)

	-- ACTION
	UPDATE DetalleCompra SET 
	Cantidad = @Cantidad, Precio = @Precio, Descuento = @Descuento
	WHERE IdCompra = @IdCompra AND IdProducto = @IdProducto

	-- RESULT
	SELECT * FROM DetalleCompra WHERE IdCompra = @IdCompra AND IdProducto = @IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[DETALLE_VENTA_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<James Darren>
-- Create date: <25/11/2021>
-- Description:	<Creación de nuevo detalle de venta>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_VENTA_CREATE]
	@IdVenta INT,
	@IdProducto INT,
	@Cantidad INT,
	@Descuento FLOAT
AS
BEGIN
	-- VALIDATIONS
	IF (@IdVenta = 0 OR @IdVenta IS NULL)
		RAISERROR('ID_VENTA_NOT_EXISTS', 16, 1)

	IF (@IdProducto = 0 OR @IdProducto IS NULL)
		RAISERROR('ID_PRODUCTO_NOT_EXISTS',16,1)

	IF (@Cantidad = 0 OR  @Cantidad IS NULL)
		RAISERROR('CANTIDAD_IS_EMPTY', 16, 1)

	IF (@Descuento IS NULL)
		RAISERROR('DESCUENTO_IS_EMPTY', 16, 1)

	-- ACTION
	INSERT INTO DetalleVenta(IdVenta, IdProducto, Cantidad, Descuento)
	VALUES (@IdVenta, @IdProducto, @Cantidad, @Descuento)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('DetalleVenta')

	-- RESULT
	SELECT * FROM DetalleVenta WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto
END

GO
/****** Object:  StoredProcedure [dbo].[DETALLE_VENTA_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Eliminiación de detalle de venta>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_VENTA_DELETE]
	@IdVenta INT,
	@IdProducto INT
AS
BEGIN
	-- VALIDATIONS
	IF (@IdVenta = 0 OR @IdVenta IS NULL)
		RAISERROR('ID_NOT_EXISTS',16,1)

	IF (@IdProducto = 0 OR @IdProducto IS NULL)
		RAISERROR('ID_PRODUCTO_NOT_EXISTS',16,1)

	-- ACTION
	SELECT *  INTO #DELETED FROM DetalleVenta WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto
	DELETE DetalleVenta WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto

	-- RESULT
	SELECT * FROM #DELETED WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto
	DROP TABLE #DELETED
END
GO
/****** Object:  StoredProcedure [dbo].[DETALLE_VENTA_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <25/11/2021>
-- Description:	<Obtención de detalle de ventas>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_VENTA_GET]
	@IdVenta INT,
	@IdProducto INT,
	@Cantidad INT,
	@Descuento FLOAT
AS
BEGIN
	--RESULT
	SELECT
		*
	FROM
		DetalleVenta
	WHERE
		(@IdVenta IS NULL OR IdVenta = @IdVenta)
		AND (@IdProducto IS NULL OR IdProducto = @IdProducto)
		AND (@Cantidad IS NULL OR Cantidad = @Cantidad)
		AND (@Descuento IS NULL OR Descuento = @Descuento)
END
GO
/****** Object:  StoredProcedure [dbo].[DETALLE_VENTA_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <25/11/2021>
-- Description:	<Actualización de detalle de venta>
-- =============================================
CREATE PROCEDURE [dbo].[DETALLE_VENTA_UPDATE]
	@IdVenta INT,
	@IdProducto INT,
	@Cantidad INT,
	@Precio FLOAT,
	@Descuento FLOAT
AS
BEGIN

	-- VALIDATIONS
	IF (@IdVenta = 0 OR @IdVenta IS NULL)
		RAISERROR('ID_VENTA_IS_EMPTY', 16, 1)

	IF (@IdProducto = 0 OR @IdProducto IS NULL)
		RAISERROR('ID_PRODUCTO_IS_EMPTY', 16, 1)

	IF (@Cantidad = 0 OR @Cantidad IS NULL)
		RAISERROR('CANTIDAD_IS_EMPTY', 16, 1)

	IF (@Descuento IS NULL)
		RAISERROR('DESCUENTO_NOT_EXISTS', 16, 1)

	-- ACTION
	IF (EXISTS(SELECT * FROM DetalleVenta WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto))
	BEGIN
		UPDATE DetalleVenta SET 
		Cantidad = @Cantidad, Descuento = @Descuento, Precio = @Precio
		WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto
	END
	ELSE
	BEGIN
		INSERT INTO DetalleVenta(IdVenta, IdProducto, Cantidad, Descuento, Precio)
		VALUES (@IdVenta, @IdProducto, @Cantidad, @Descuento, @Precio)
	END
	
	-- RESULT
	SELECT * FROM DetalleVenta WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[EMPLEADO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Creación de nuevo empleado>
-- =============================================
CREATE PROCEDURE [dbo].[EMPLEADO_CREATE]
	@IdContacto INT
AS
BEGIN
	-- VALIDATIONS
	IF (@IdContacto = 0 OR @IdContacto IS NULL)
		RAISERROR('ID_CONTACTO_NOT_EXISTS',16,1)

	-- ACTION
	INSERT INTO Empleado(Estado, IdContacto) VALUES (1, @IdContacto)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Empleado')

	-- RESULT
	SELECT * FROM Empleado WHERE Id = @INSERTED_ID
END
GO
/****** Object:  StoredProcedure [dbo].[EMPLEADO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Eliminiación de empleado>
-- =============================================
CREATE PROCEDURE [dbo].[EMPLEADO_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM Empleado WHERE Id = @Id AND Estado = 0) 
		RAISERROR('PROVIDER_CURRENTLY_REMOVED',16,1)

	-- ACTION
	UPDATE Empleado SET Estado = 0 WHERE Id = @Id

	-- RESULT
	SELECT * FROM Empleado WHERE Id = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[EMPLEADO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Obtención de empleados>
-- =============================================
CREATE PROCEDURE [dbo].[EMPLEADO_GET]
	@Id INT,
	@Estado BIT,
	@IdContacto INT
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Empleado
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Estado IS NULL OR Estado = @Estado)
		AND (@IdContacto IS NULL OR IdContacto = @IdContacto)
END
GO
/****** Object:  StoredProcedure [dbo].[EMPLEADO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Actualización de empleado>
-- =============================================
CREATE PROCEDURE [dbo].[EMPLEADO_UPDATE]
	@Id INT,
	@IdContacto INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@IdContacto = 0 OR @IdContacto IS NULL)
		RAISERROR('ID_CONTACTO_NOT_EXISTS',16,1)

	-- ACTION
	UPDATE Empleado SET IdContacto = @IdContacto WHERE Id = @Id AND Estado = 1

	-- RESULT
	SELECT * FROM Empleado WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GARANTIA_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<James Gutierrez>
-- Create date: <22/02/2022>
-- Description:	<Procedimiento crear garantia>
-- =============================================
CREATE PROCEDURE [dbo].[GARANTIA_CREATE]
@ID INT,
@FechaF DATE,
@desc NVARCHAR(100),
@FechaI DATE
AS
IF(@ID=(SELECT Id FROM Garantias WHERE Id=@ID))
BEGIN
	PRINT 'GARANTIA REGISTRADA'
END
ELSE
BEGIN
	IF(@ID <=0 OR @desc='' OR @FechaI='' OR @FechaF='')
	BEGIN
		PRINT 'LOS PARAMETROS NO PUEDEN SER NULO O NEGATIVOS'
	END
	ELSE
	BEGIN
		INSERT INTO Garantias VALUES(@ID,@desc,@FechaI,@FechaF)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GARANTIA_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <25/11/2021>
-- Description:	<Eliminiación de producto>
-- =============================================
CREATE PROCEDURE [dbo].[GARANTIA_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM Garantias WHERE Id = @Id AND Estado = 0) 
		RAISERROR('GARANTIA_CURRENTLY_REMOVED',16,1)

	-- ACTION
	UPDATE Garantias SET Estado = 0 WHERE Id = @Id

	-- RESULT
	SELECT * FROM Garantias WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GARANTIA_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<James Gutierrez>
-- Create date: <22/02/2022>
-- Description:	<Procedimiento get garantia>
-- =============================================
CREATE PROCEDURE [dbo].[GARANTIA_GET]
	@Id INT,
	@FechaFinal DATE,
	@Descripcion NVARCHAR(100),
	@FechaInicio DATE
AS 
BEGIN
	SELECT 
		*
	FROM 
		Garantias
	WHERE
		(@Id IS NULL OR Id = @Id)
			AND (@FechaFinal IS NULL OR FechaFinal = @FechaFinal)
			AND (@Descripcion IS NULL OR Descripcion = @Descripcion)
			AND (@FechaInicio IS NULL OR FechaInicio = @FechaInicio)
END
GO
/****** Object:  StoredProcedure [dbo].[GARANTIA_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GARANTIA_UPDATE]
@ID INT,
@desc NVARCHAR(100),
@FechaI DATE,
@FechaF DATE
AS
IF(@ID=(SELECT Id FROM Garantias WHERE Id=@ID))
BEGIN
	IF(@ID <=0 OR @desc='' OR @FechaI='' OR @FechaF='')
	BEGIN
		PRINT 'LOS PARAMETROS NO PUEDEN SER NULOS O NEGATIVOS'
	END
	ELSE
	BEGIN
		UPDATE Garantias SET Descripcion=@desc,FechaInicio=@FechaI,FechaFinal=@FechaF WHERE
		Id=@ID
	END
END
ELSE
BEGIN
	PRINT 'REGISTRO NO ENCONTRADO'
END
GO
/****** Object:  StoredProcedure [dbo].[HISTORICOPRODUCTO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <21/11/2021>
-- Description:	<Creación de nuevo Historico de producto>
-- =============================================
CREATE PROCEDURE [dbo].[HISTORICOPRODUCTO_CREATE]
	@TituloHistorico NVARCHAR(50),
	@Descripcion NVARCHAR(MAX),
	@FechaHistorico DATE,
	@IdUsuario INT
AS
BEGIN
	-- VALIDATIONS
	IF (@TituloHistorico = '' OR @TituloHistorico IS NULL)
		RAISERROR('Primer_Nombre_IS_EMPTY', 16, 1)

	IF (LEN(@TituloHistorico) > 50)
		RAISERROR('Primer_Nombre_LENGTH_EXCEED', 16, 1)
	
	IF(@Descripcion = '' OR @Descripcion IS NULL)
		RAISERROR('Descripcion_IS_EMPTY',16,1)

	IF(@FechaHistorico = '' OR @FechaHistorico IS NULL)
		RAISERROR('FechaHistorico_IS_EMPTY',16,1)

	-- ACTION
	INSERT INTO 
	[dbo].[HistoricoProducto] (TituloHistorico, Descripcion, FechaHistorico, IdUsuario) 
	VALUES 
	(@TituloHistorico, @Descripcion, @FechaHistorico, @IdUsuario)
	DECLARE 
	@INSERTED_ID INT = IDENT_CURRENT('HistoricoProducto')

	-- RESULT
	SELECT * FROM [dbo].[HistoricoProducto] WHERE Id = @INSERTED_ID
END
GO
/****** Object:  StoredProcedure [dbo].[HISTORICOPRODUCTO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <18/08/2022>
-- Description:	<Eliminiación de Historicos>
-- =============================================
CREATE PROCEDURE [dbo].[HISTORICOPRODUCTO_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM HistoricoProducto WHERE Id = @Id AND Estado = 0) 
		RAISERROR('HISTORICOPRODUCTO_CURRENTLY_REMOVED',16,1)

	-- ACTION
	UPDATE HistoricoProducto SET Estado = 0 WHERE Id = @Id

	-- RESULT
	SELECT * FROM HistoricoProducto WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[HISTORICOPRODUCTO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <22/02/2022>
-- Description:	<Procedimiento get Historico>
-- =============================================
CREATE PROCEDURE [dbo].[HISTORICOPRODUCTO_GET]
	@Id INT,
	@TituloHistorico NVARCHAR(50),
	@Descripcion NVARCHAR(MAX),
	@FechaHistorico DATE,
	@IdUsuario INT
AS 
BEGIN
	SELECT 
		*
	FROM 
		HistoricoProducto
	WHERE
		(@Id IS NULL OR Id = @Id)
			AND (@TituloHistorico IS NULL OR TituloHistorico LIKE '%' + @TituloHistorico + '%')			
			AND (@Descripcion IS NULL OR Descripcion LIKE '%' + @Descripcion + '%')
			AND (@FechaHistorico IS NULL OR FechaHistorico = @FechaHistorico)
			AND (@IdUsuario IS NULL OR IdUsuario = @IdUsuario)
END
GO
/****** Object:  StoredProcedure [dbo].[HISTORICOPRODUCTO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <23/02/2022>
-- Description:	<Actualización de contacto>
-- =============================================
CREATE PROCEDURE [dbo].[HISTORICOPRODUCTO_UPDATE]
	@id INT,
	@TituloHistorico NVARCHAR(50),
	@Descripcion NVARCHAR(MAX),
	@FechaHistorico DATE,
	@IdUsuario INT
AS
BEGIN

	-- VALIDATIONS
	IF (@TituloHistorico = '' OR @TituloHistorico IS NULL)
		RAISERROR('Titulo_Historico_IS_EMPTY', 16, 1)

	IF (LEN(@TituloHistorico) > 50)
		RAISERROR('Titulo_Historico_LENGTH_EXCEED', 16, 1)
	
	IF(@Descripcion = '' OR @Descripcion IS NULL)
		RAISERROR('Descripcion_IS_EMPTY',16,1)

	IF(@FechaHistorico = '' OR @FechaHistorico IS NULL)
		RAISERROR('FechaHistorico_IS_EMPTY',16,1)

	-- ACTION
	UPDATE HistoricoProducto SET 
	TituloHistorico = @TituloHistorico, 
	Descripcion = @Descripcion,
	FechaHistorico = @FechaHistorico,
	IdUsuario = @IdUsuario
	WHERE Id = @Id

	-- RESULT
	SELECT * FROM Contacto WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[MUNICIPIO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Creación de nuevo municipio>
-- =============================================
CREATE PROCEDURE [dbo].[MUNICIPIO_CREATE]
	@Nombre NVARCHAR(MAX),
	@IdDepartamento INT
AS
BEGIN
	-- VALIDATIONS
	IF (@Nombre = '' OR @Nombre IS NULL)
		RAISERROR('NOMBRE_IS_EMPTY', 16, 1)

	IF (LEN(@Nombre) > 50)
		RAISERROR('NOMBRE_LENGTH_EXCEED', 16, 1)

	IF (@IdDepartamento = 0 OR @IdDepartamento IS NULL)
		RAISERROR('IdDepartamento_NOT_EXISTS',16,1)

	IF EXISTS (SELECT TOP 1 1 FROM Municipio WHERE UPPER(@Nombre) = UPPER(@Nombre) AND IdDepartamento = @IdDepartamento)
		RAISERROR('NOMBRE_ALREADY_EXISTS_IN_THAT_DEPARTMENT', 16, 1)

	-- ACTION
	INSERT INTO Municipio (Nombre, IdDepartamento) VALUES (@Nombre, @IdDepartamento)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Municipio')

	-- RESULT
	SELECT * FROM Municipio WHERE Id = @INSERTED_ID
END
GO
/****** Object:  StoredProcedure [dbo].[MUNICIPIO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Eliminiación de municipio>
-- =============================================
CREATE PROCEDURE [dbo].[MUNICIPIO_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS

	-- ACTION
	SELECT *  INTO #DELETED FROM Municipio WHERE Id = @Id
	DELETE Municipio WHERE Id = @Id

	-- RESULT
	SELECT * FROM #DELETED WHERE Id = @Id
	DROP TABLE #DELETED
END

GO
/****** Object:  StoredProcedure [dbo].[MUNICIPIO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Obtención de municipios>
-- =============================================
CREATE PROCEDURE [dbo].[MUNICIPIO_GET]
	@Id INT,
	@Nombre NVARCHAR(MAX),
	@IdDepartamento INT
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Municipio
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
		AND (@IdDepartamento IS NULL OR IdDepartamento = @IdDepartamento)
END
GO
/****** Object:  StoredProcedure [dbo].[MUNICIPIO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Actualización de municipio>
-- =============================================
CREATE PROCEDURE [dbo].[MUNICIPIO_UPDATE]
	@Id INT,
	@Nombre NVARCHAR(MAX),
	@IdDepartamento INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Nombre = '' OR @Nombre IS NULL)
		RAISERROR('NOMBRE_IS_EMPTY', 16, 1)

	IF (LEN(@Nombre) > 50)
		RAISERROR('NOMBRE_LENGTH_EXCEED', 16, 1)

	IF (@IdDepartamento = 0 OR @IdDepartamento IS NULL)
		RAISERROR('IdDepartamento_NOT_EXISTS',16,1)

	IF EXISTS (SELECT TOP 1 1 FROM Municipio WHERE UPPER(@Nombre) = UPPER(@Nombre) AND IdDepartamento = @IdDepartamento)
		RAISERROR('NOMBRE_ALREADY_EXISTS_IN_THAT_DEPARTMENT', 16, 1)

	-- ACTION
	UPDATE Municipio SET Nombre = @Nombre, IdDepartamento = @IdDepartamento WHERE Id = @Id

	-- RESULT
	SELECT * FROM Municipio WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[PRODUCTO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <25/11/2021>
-- Description:	<Creación de nuevo producto>
-- =============================================
CREATE PROCEDURE [dbo].[PRODUCTO_CREATE]
	@Descripcion VARCHAR(MAX),
	@Precio MONEY,
	@IdCategoria INT,
	@stock INT
AS
BEGIN
	-- VALIDATIONS
	IF (@Descripcion = '' OR @Descripcion IS NULL)
		RAISERROR('DESCRIPCION_IS_EMPTY',16,1)

	IF (LEN(@Descripcion) > 100)
		RAISERROR('DESCRIPCION_LENGTH_EXCEED',16,1)

	IF (@Precio = 0 OR @Precio IS NULL)
		RAISERROR('PRECIO_IS_EMPTY',16,1)

	IF (@IdCategoria = 0 OR @IdCategoria IS NULL)
		RAISERROR('ID_CATEGORIA_NOT_EXISTS',16,1)

	-- ACTION
	INSERT INTO Producto(Descripcion, Precio, Estado, IdCategoria, Stock) VALUES (@Descripcion, @Precio, 1, @IdCategoria,@stock)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Producto')

	-- RESULT
	SELECT * FROM Producto WHERE Id = @INSERTED_ID
END


GO
/****** Object:  StoredProcedure [dbo].[PRODUCTO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <25/11/2021>
-- Description:	<Eliminiación de producto>
-- =============================================
CREATE PROCEDURE [dbo].[PRODUCTO_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM Producto WHERE Id = @Id AND Estado = 0) 
		RAISERROR('PRODUCT_CURRENTLY_REMOVED',16,1)

	-- ACTION
	SELECt * into #DELETED FROM Producto WHERE Id = @Id
	DELETE Producto WHERE Id = @Id

	-- RESULT
	SELECT * FROM Producto WHERE Id = @Id
	DROP TABLE #DELETED
END

GO
/****** Object:  StoredProcedure [dbo].[PRODUCTO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Obtención de productos>
-- =============================================
CREATE PROCEDURE [dbo].[PRODUCTO_GET]
	@Id INT,
	@Descripcion VARCHAR(MAX),
	@Estado BIT,
	@IdCategoria INT,
	@stock INT
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Producto
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Descripcion IS NULL OR Descripcion = @Descripcion)
		AND (@Estado IS NULL OR Estado = @Estado)
		AND (@IdCategoria IS NULL OR IdCategoria = @IdCategoria)
		AND (@stock IS NULL OR Stock = @stock)
END

select * from Producto
GO
/****** Object:  StoredProcedure [dbo].[PRODUCTO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Actualización de producto>
-- =============================================
CREATE PROCEDURE [dbo].[PRODUCTO_UPDATE]
	@Id INT,
	@Descripcion VARCHAR(MAX),
	@Precio MONEY,
	@Imagen IMAGE,
	@IdCategoria INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@Descripcion = '' OR @Descripcion IS NULL)
		RAISERROR('DESCRIPCION_IS_EMPTY',16,1)

	IF (LEN(@Descripcion) > 100)
		RAISERROR('DESCRIPCION_LENGTH_EXCEED',16,1)

	IF (@Precio = 0 OR @Precio IS NULL)
		RAISERROR('PRECIO_IS_EMPTY',16,1)

	IF (@Imagen IS NULL)
		RAISERROR('IMAGEN_NOT_EXISTS',16,1)

	IF (@IdCategoria = 0 OR @IdCategoria IS NULL)
		RAISERROR('ID_CATEGORIA_NOT_EXISTS',16,1)

	-- ACTION
	UPDATE Producto SET Descripcion = @Descripcion, Precio = @Precio, Imagen = @Imagen, IdCategoria = @IdCategoria WHERE Id = @Id AND Estado = 1

	-- RESULT
	SELECT * FROM Producto WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[PROVEEDOR_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Creación de nuevo proveedor>
-- =============================================
CREATE PROCEDURE [dbo].[PROVEEDOR_CREATE]
	@IdContacto INT
AS
BEGIN
	-- VALIDATIONS
	IF (@IdContacto = 0 OR @IdContacto IS NULL)
		RAISERROR('ID_CONTACTO_NOT_EXISTS',16,1)

	-- ACTION
	INSERT INTO Proveedor(Estado, IdContacto) VALUES (1, @IdContacto)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Proveedor')

	-- RESULT
	SELECT * FROM Proveedor WHERE Id = @INSERTED_ID
END
GO
/****** Object:  StoredProcedure [dbo].[PROVEEDOR_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Eliminiación de proveedor>
-- =============================================
CREATE PROCEDURE [dbo].[PROVEEDOR_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF EXISTS (SELECT * FROM Proveedor WHERE Id = @Id AND Estado = 0) 
		RAISERROR('PROVIDER_CURRENTLY_REMOVED',16,1)

	-- ACTION
	UPDATE Proveedor SET Estado = 0 WHERE Id = @Id

	-- RESULT
	SELECT * FROM Proveedor WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[PROVEEDOR_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Obtención de proveedores>
-- =============================================
CREATE PROCEDURE [dbo].[PROVEEDOR_GET]
	@Id INT,
	@Estado BIT,
	@IdContacto INT
AS
BEGIN
	-- RESULT
	SELECT 
		*
	FROM
		Proveedor
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@Estado IS NULL OR Estado = @Estado)
		AND (@IdContacto IS NULL OR IdContactoJur = @IdContacto)
END
GO
/****** Object:  StoredProcedure [dbo].[PROVEEDOR_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Actualización de proveedor>
-- =============================================
CREATE PROCEDURE [dbo].[PROVEEDOR_UPDATE]
	@Id INT,
	@IdContacto INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@IdContacto = 0 OR @IdContacto IS NULL)
		RAISERROR('ID_CONTACTO_NOT_EXISTS',16,1)

	-- ACTION
	UPDATE Proveedor SET IdContacto = @IdContacto WHERE Id = @Id AND Estado = 1

	-- RESULT
	SELECT * FROM Proveedor WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[USUARIO_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Creación de nuevo usuario>
-- =============================================
CREATE PROCEDURE [dbo].[USUARIO_CREATE]
	@UserName VARCHAR(MAX),
	@Password VARCHAR(MAX),
	@Role VARCHAR(MAX),
	@IdEmpleado INT
AS
BEGIN
	-- VALIDATIONS
	IF (@UserName = '' OR @UserName IS NULL)
		RAISERROR('USER_NAME_IS_EMPTY', 16, 1)

	IF (LEN(@UserName) > 50)
		RAISERROR('USER_NAME_LENGTH_EXCEED', 16, 1)

	IF EXISTS (SELECT * FROM Usuario WHERE Username = @UserName AND Estado = 1)
		RAISERROR('USER_NAME_ALREADY_EXISTS',16,1)

	IF (@Password = '' OR @Password IS NULL)
		RAISERROR('PASSWORD_IS_EMPTY',16,1)

	IF (LEN(@Role) > 50)
		RAISERROR('ROLE_LENGTH_EXCEED', 16, 1)

	IF (@IdEmpleado = 0 OR @IdEmpleado IS NULL)
		RAISERROR('ID_EMPLEADO_IS_EMPTY', 16, 1)

	-- ACTION
	INSERT INTO Usuario(Username, Password, Role, Estado, IdEmpleado)
	VALUES (@UserName, ENCRYPTBYPASSPHRASE(@Password, @Password), @Role, 1, @IdEmpleado)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Usuario')

	-- RESULT
	SELECT * FROM Usuario WHERE Id = @INSERTED_ID
END

GO
/****** Object:  StoredProcedure [dbo].[USUARIO_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <24/11/2021>
-- Description:	<Eliminiación de usuario>
-- =============================================
CREATE PROCEDURE [dbo].[USUARIO_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_NOT_EXISTS',16,1)

	IF EXISTS (SELECT * FROM Usuario WHERE Id = @Id AND Estado = 0)
		RAISERROR('USER_CURRENTLY_REMOVED',16,1)

	-- ACTION
	UPDATE Usuario SET Estado = 0 WHERE Id = @Id

	-- RESULT
	SELECT * FROM Usuario WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[USUARIO_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Obtención de usuarios>
-- =============================================
CREATE PROCEDURE [dbo].[USUARIO_GET]
	@Id INT,
	@UserName VARCHAR(MAX),
	@Password VARCHAR(MAX),
	@Role VARCHAR(MAX),
	@Estado BIT,
	@IdEmpleado INT
AS
BEGIN
	--RESULT
	SELECT
		*
	FROM
		Usuario
	WHERE
		(@Id IS NULL OR Id = @Id)
		AND (@UserName IS NULL OR Username = @UserName)
		AND (@Password IS NULL OR CONVERT(varchar(MAX), DECRYPTBYPASSPHRASE(@Password, Password)) = @Password)
		AND (@Role IS NULL OR Role = @Role)
		AND (@Estado IS NULL OR Estado = @Estado)
		AND (@IdEmpleado IS NULL OR IdEmpleado = @IdEmpleado)
END
GO
/****** Object:  StoredProcedure [dbo].[USUARIO_LOGIN]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
-- =============================================
-- Author:		<Marat Lanza>
-- Create date: <24/02/2022>
-- Description:	<Procedimiento de almacenado User Login>
-- =============================================
CREATE PROCEDURE [dbo].[USUARIO_LOGIN]
	@username VARCHAR(50),
	@password VARCHAR(50)
AS 

DECLARE @PASSWORD_KEY VARCHAR(50) = 'SECRET';

IF NOT (EXISTS(SELECT TOP 1 * FROM Usuario 
WHERE 
	Username = @username AND DECRYPTBYPASSPHRASE(@PASSWORD_KEY, [Password]) = @password
))
	RAISERROR('USER_NOT_FOUND',16,1)

SELECT TOP 1 * FROM Usuario 
WHERE 
	Username = @username AND DECRYPTBYPASSPHRASE(@PASSWORD_KEY, [Password]) = @password
GO
/****** Object:  StoredProcedure [dbo].[USUARIO_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Actualización de usuario>
-- =============================================
CREATE PROCEDURE [dbo].[USUARIO_UPDATE]
	@Id INT,
	@UserName VARCHAR(MAX),
	@Password VARCHAR(MAX),
	@Role VARCHAR(MAX),
	@IdEmpleado INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@UserName = '' OR @UserName IS NULL)
		RAISERROR('USER_NAME_IS_EMPTY',16,1)

	IF (LEN(@UserName) > 50)
		RAISERROR('USER_NAME_LENGTH_EXCEED',16,1)

	IF EXISTS (SELECT * FROM Usuario WHERE Username = @UserName AND Estado = 1)
		RAISERROR('USER_NAME_ALREADY_EXISTS',16,1)

	IF (@Password = '' OR @Password IS NULL)
		RAISERROR('PASSWORD_IS_EMPTY',16,1)

	IF (@Role = '' OR @Role IS NULL)
		RAISERROR('ROLE_IS_EMPTY',16,1)

	IF (LEN(@Role) > 50)
		RAISERROR('ROLE_LENGTH_EXCEED',16,1)

	IF (@IdEmpleado = 0 OR @IdEmpleado IS NULL)
		RAISERROR('ID_EMPLEADO_NOT_EXISTS',16,1)

	-- ACTION
	UPDATE Usuario SET 
	Username = @UserName, Password = ENCRYPTBYPASSPHRASE(@Password, @Password), Role = @Role, IdEmpleado = @IdEmpleado
	WHERE Id = @Id AND Estado = 1

	-- RESULT
	SELECT * FROM Usuario WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[VENTA_CREATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Creación de nueva venta>
-- =============================================
CREATE PROCEDURE [dbo].[VENTA_CREATE]
	@Fecha DATETIME,
	@IdCliente INT,
	@IdEmpleado INT
AS
BEGIN
	-- VALIDATIONS
	IF (@Fecha = '' OR @Fecha IS NULL)
		RAISERROR('FECHA_IS_EMPTY', 16, 1)

	IF (@IdCliente = 0 OR @IdCliente IS NULL)
		RAISERROR('ID_CLIENTE_NOT_EXISTS',16,1)

	IF (@IdEmpleado = 0 OR @IdEmpleado IS NULL)
		RAISERROR('ID_EMPLEADO_NOT_EXISTS', 16, 1)

	-- ACTION
	INSERT INTO Venta(Fecha, IdCliente, IdEmpleado)
	VALUES (@Fecha, @IdCliente, @IdEmpleado)
	DECLARE @INSERTED_ID INT = IDENT_CURRENT('Venta')

	-- RESULT
	SELECT * FROM Venta WHERE Id = @INSERTED_ID
END

GO
/****** Object:  StoredProcedure [dbo].[VENTA_DELETE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Eliminiación de venta>
-- =============================================
CREATE PROCEDURE [dbo].[VENTA_DELETE]
	@Id INT
AS
BEGIN
	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_NOT_EXISTS',16,1)

	-- ACTION
	SELECT *  INTO #DELETED FROM Venta WHERE Id = @Id
	DELETE Venta WHERE Id = @Id

	-- RESULT
	SELECT * FROM #DELETED WHERE Id = @Id
	DROP TABLE #DELETED
END
GO
/****** Object:  StoredProcedure [dbo].[VENTA_GET]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VENTA_GET] 
	@Id INT,
	@Query NVARCHAR(100)
AS

Select Venta.* From Venta
INNER JOIN Cliente ON Venta.IdCliente = Cliente.Id
INNER JOIN Contacto ON Cliente.IdContacto = Contacto.Id
WHERE
	(@Id IS NULL OR Venta.Id = @Id)
	AND (@Query IS NULL OR @Query = '' OR Contacto.PrimerNombre LIKE '%' + @Query + '%')

ORDER BY Venta.Id 
GO
/****** Object:  StoredProcedure [dbo].[VENTA_UPDATE]    Script Date: 22/02/2023 10:22:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gabriel Avilés>
-- Create date: <25/11/2021>
-- Description:	<Actualización de venta>
-- =============================================
CREATE PROCEDURE [dbo].[VENTA_UPDATE]
	@Id INT,
	@Fecha DATETIME,
	@IdCliente INT,
	@IdEmpleado INT
AS
BEGIN

	-- VALIDATIONS
	IF (@Id = 0 OR @Id IS NULL)
		RAISERROR('ID_IS_EMPTY', 16, 1)

	IF (@Fecha = '' OR @Fecha IS NULL)
		RAISERROR('FECHA_IS_EMPTY',16,1)

	IF (@IdCliente = 0 OR @IdCliente IS NULL)
		RAISERROR('ID_CLIENTE_NOT_EXISTS',16,1)

	IF (@IdEmpleado = 0 OR @IdEmpleado IS NULL)
		RAISERROR('ID_EMPLEADO_NOT_EXISTS',16,1)

	-- ACTION
	UPDATE Venta SET 
	Fecha = @Fecha, IdCliente = @IdCliente, IdEmpleado = @IdEmpleado
	WHERE Id = @Id

	-- RESULT
	SELECT * FROM Venta WHERE Id = @Id
END

GO
