ALTER VIEW [dbo].[View_PatientSearchSource]
AS
SELECT p.Id,p.[FirstName], p.LastName, p.Phone, p.Email, p.UpdatedDateUTC,p.ClinicId, a.Address1, a.City,
case when a.RegionId is not null then r.name else a.Region end as StateName,c.Iso2 as CountrIso2, a.PostalCode,
d.Id as DoctorId,d.FirstName as DoctorFirstName, d.LastName as DoctorLastName, p.SubscriptionExpireDate
FROM dbo.Patient p  with(nolock)
inner join dbo.Address a  with(nolock) on a.Id = p.[AddressId] 
inner join [dbo].[Country] c with(nolock) on a.CountryId = c.Id
left join [dbo].[Region] r with(nolock) on a.RegionId = r.Id
inner join [dbo].[Doctor] d with(nolock) on p.DoctorId = d.Id
GO
