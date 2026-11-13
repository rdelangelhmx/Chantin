CREATE FUNCTION [dbo].[Base64Encode] ( @Input NVARCHAR(MAX) )
RETURNS VARCHAR(MAX)
BEGIN

DECLARE @InputVB VARBINARY(MAX)
DECLARE @EncodedOutput VARCHAR(MAX)

set @InputVB = CONVERT(varbinary(MAX), @Input)
set @EncodedOutput = CAST(N'' as xml).value('xs:base64Binary(sql:variable("@InputVB"))', 'VARCHAR(max)')

RETURN @EncodedOutput

END