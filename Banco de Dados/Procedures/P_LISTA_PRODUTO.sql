if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_LISTA_PRODUTO') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_LISTA_PRODUTO
END
GO

CREATE PROC dbo.P_LISTA_PRODUTO 
 as
--Código da Procedure
SELECT id_produto, nm_produto, vl_preco, ds_descricao, id_categoria, url_imagem, dt_inclusao, dt_alteracao FROM Produto 

