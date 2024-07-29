if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_INCLUI_CLIENTE') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_INCLUI_CLIENTE
END
GO

CREATE PROC dbo.P_INCLUI_CLIENTE (
      @nm_cliente varchar(100),
      @cpf_cliente char(11)
) as
--Código da Procedure
INSERT INTO Cliente (nm_cliente, cpf_cliente, dt_inclusao)
VALUES (@nm_cliente, @cpf_cliente, GETDATE())
