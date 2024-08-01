if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_ALTERA_CATEGORIA') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_ALTERA_CATEGORIA
END
GO

CREATE PROC dbo.P_ALTERA_CATEGORIA (
	 @id_categoria int,
     @ds_categoria varchar(100)
) as
--Código da Procedure
UPDATE Categoria
SET ds_categoria = @ds_categoria,
dt_alteracao = GETDATE()
WHERE id_categoria = @id_categoria
