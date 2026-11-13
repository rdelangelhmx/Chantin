CREATE FUNCTION [dbo].[Ceros](@Valor int, @Lugares int)
RETURNS VARCHAR(50)
AS
BEGIN 
   DECLARE @Return VARCHAR(50)
   SET @Return = RIGHT(REPLICATE('0',@Lugares) + CAST(@Valor AS VARCHAR(50)),@Lugares)
   RETURN @Return
END