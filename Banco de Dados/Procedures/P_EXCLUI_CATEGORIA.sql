if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_EXCLUI_CATEGORIA') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_EXCLUI_CATEGORIA
END
GO

CREATE PROC dbo.P_EXCLUI_CATEGORIA (
	 @id_categoria int
) as
--Código da Procedure
DELETE Categoria 
WHERE id_categoria = @id_categoria
