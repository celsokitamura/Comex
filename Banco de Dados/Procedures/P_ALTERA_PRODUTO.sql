if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_ALTERA_PRODUTO') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_ALTERA_PRODUTO
END
GO

CREATE PROC dbo.P_ALTERA_PRODUTO (
	 @id_produto int,
     @nm_produto varchar(100),
	 @vl_preco decimal(18, 2),
	 @ds_descricao varchar(500),
	 @id_categoria int,
	 @url_imagem varchar(500)
) as
--Código da Procedure
UPDATE Produto 
SET nm_produto = @nm_produto, 
vl_preco = @vl_preco, 
ds_descricao = @ds_descricao, 
id_categoria = @id_categoria, 
url_imagem = @url_imagem, 
dt_alteracao = GETDATE()
WHERE id_produto = @id_produto
