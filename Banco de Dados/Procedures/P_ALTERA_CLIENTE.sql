if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_ALTERA_CLIENTE') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_ALTERA_CLIENTE
END
GO

CREATE PROC dbo.P_ALTERA_CLIENTE (
	 @id_cliente int,
     @nm_cliente varchar(100),
	 @cpf_cliente char(11)
) as
--Código da Procedure
UPDATE Cliente 
SET nm_cliente = @nm_cliente, 
cpf_cliente = @cpf_cliente,
dt_alteracao = GETDATE()
WHERE id_cliente = @id_cliente
