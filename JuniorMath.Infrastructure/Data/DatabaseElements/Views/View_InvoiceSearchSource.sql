
ALTER VIEW [dbo].[View_InvoiceSearchSource]
AS
SELECT i.Id, i.InvoiceDate, i.[UpdatedDateUTC], s.FirstName as UserFirstName, s.LastName as UserLastName
, p.FirstName, p.LastName, p.Phone, p.Email, a.Address1, a.Address2, a.AddressTypeId
, a.AttentionTo, a.City, a.CountryId, a.PostalCode, a.Region, a.RegionId,
d.FirstName as DoctorFirstName, d.LastName as DoctorLastName
FROM [dbo].[Invoice] i with(nolock)
inner join dbo.Patient p  with(nolock) on i.[PatientId] = p.Id
inner join dbo.Address a with(nolock) on a.Id = p.[AddressId] 
inner join [dbo].[Doctor] d with(nolock) on i.DoctorId = d.Id
inner join [dbo].[SiteUser] s with(nolock)  on i.[CreatedBy] = s.Id
GO


