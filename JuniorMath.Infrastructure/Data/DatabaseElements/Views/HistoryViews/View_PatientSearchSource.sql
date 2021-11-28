
ALTER VIEW [dbo].[View_PatientSearchSource]
AS
SELECT p.Id,p.[FirstName], p.LastName, p.Phone, p.Email, p.UpdatedDateUTC,p.ClinicId, a.Address1, a.PostalCode,
d.Id as DoctorId,d.FirstName as DoctorFirstName, d.LastName as DoctorLastName
FROM dbo.Patient p  with(nolock)
inner join dbo.Address a  with(nolock) on a.Id = p.[AddressId] 
inner join [dbo].[Doctor] d with(nolock) on p.DoctorId = d.Id

GO


