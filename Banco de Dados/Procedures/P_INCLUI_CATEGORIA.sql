if exists (select 'x' from dbo.sysobjects where id = object_id(N'dbo.P_INCLUI_CATEGORIA') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
   drop procedure dbo.P_INCLUI_CATEGORIA
END
GO

CREATE PROC dbo.P_INCLUI_CATEGORIA (
      @ds_categoria varchar(100)
) as
--Código da Procedure
INSERT INTO Categoria (ds_categoria, dt_inclusao)
VALUES (@ds_categoria, GETDATE())
