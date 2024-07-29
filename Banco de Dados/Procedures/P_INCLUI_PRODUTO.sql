if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_INCLUI_PRODUTO') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_INCLUI_PRODUTO
END
GO

CREATE PROC dbo.P_INCLUI_PRODUTO (
     @nm_produto varchar(100),
	 @vl_preco decimal(18, 2),
	 @ds_descricao varchar(500),
	 @id_categoria int,
	 @url_imagem varchar(500)
) as
--Código da Procedure
INSERT INTO Produto (nm_produto, vl_preco, ds_descricao, id_categoria, url_imagem, dt_inclusao)
VALUES (@nm_produto, @vl_preco, @ds_descricao, @id_categoria, @url_imagem, GETDATE())
