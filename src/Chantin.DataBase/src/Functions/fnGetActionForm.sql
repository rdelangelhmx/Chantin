-- =============================================
-- Author:		Rodrigo Del Angel <rdelangelhmx@gmail.com>
-- Create date: 04-Jun-2026
-- Description:	Get the Name of Action Form from Enum
/*
ActionForm
{
	Create = 1,
	Read = 2,
	Update = 3,
	Delete = 4,
	Access = 5,
	Process = 6,
	Session = 7,
	Transaction = 8,
	Other = 0
}
*/
-- =============================================
CREATE FUNCTION fnGetActionForm
(
	-- Add the parameters for the function here
	@idAction as int
)
RETURNS varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ActionName varchar(50);

	-- Add the T-SQL statements to compute the return value here
	SELECT @ActionName = 
	CASE
		WHEN @idAction = 1 THEN 'Create' 
		WHEN @idAction = 2 THEN 'Read' 
		WHEN @idAction = 3 THEN 'Update' 
		WHEN @idAction = 4 THEN 'Delete' 
		WHEN @idAction = 5 THEN 'Access' 
		WHEN @idAction = 6 THEN 'Process' 
		WHEN @idAction = 7 THEN 'Session' 
		WHEN @idAction = 8 THEN 'Transaction' ELSE 'Other' 
	END
	-- Return the result of the function
	RETURN @ActionName;

END