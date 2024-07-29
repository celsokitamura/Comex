if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_EXCLUI_CLIENTE') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_EXCLUI_CLIENTE
END
GO

CREATE PROC dbo.P_EXCLUI_CLIENTE (
	 @id_cliente int
) as
--Código da Procedure
DELETE Cliente 
WHERE id_cliente = @id_cliente
