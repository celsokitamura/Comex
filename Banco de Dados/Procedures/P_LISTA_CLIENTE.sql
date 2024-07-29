if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_LISTA_CLIENTE') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_LISTA_CLIENTE
END
GO

CREATE PROC dbo.P_LISTA_CLIENTE 
 as
--Código da Procedure
SELECT id_cliente, nm_cliente, cpf_cliente, dt_inclusao, dt_alteracao FROM Cliente 

