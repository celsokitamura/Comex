if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_EXCLUI_PRODUTO') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_EXCLUI_PRODUTO
END
GO

CREATE PROC dbo.P_EXCLUI_PRODUTO (
	 @id_produto int
) as
--Código da Procedure
DELETE Produto 
WHERE id_produto = @id_produto
