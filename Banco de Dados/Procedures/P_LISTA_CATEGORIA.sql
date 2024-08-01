if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_LISTA_CATEGORIA') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_LISTA_CATEGORIA
END
GO

CREATE PROC dbo.P_LISTA_CATEGORIA 
 as
--Código da Procedure
SELECT id_categoria, ds_categoria, dt_inclusao, dt_alteracao FROM Categoria 

