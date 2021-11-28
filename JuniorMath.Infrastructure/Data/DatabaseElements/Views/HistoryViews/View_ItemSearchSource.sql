
ALTER VIEW [dbo].[View_ItemSearchSource]
AS
SELECT Id, Name, Description, Cost, UpdatedDateUTC
FROM [dbo].[Item]  with(nolock)

GO


