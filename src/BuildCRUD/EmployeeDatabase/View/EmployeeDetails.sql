CREATE VIEW [dbo].[EmployeeDetails]
	AS  SELECT dbo.Employee.id, dbo.Employee.fullName, dbo.Employee.email, dbo.Employee.cellphone, dbo.Employee.service_equipmentneeded, 
               dbo.Employee.aditional_service, dbo.Employee.hiringManagerEmail, dbo.Employee.restricted_access, dbo.Employee.another_building, 
               dbo.Company.labelDescription AS companyName, dbo.Buildings.labelDescription AS buildingName, dbo.BeingHiredFor.labelDescription AS beinghiredFor
FROM  dbo.Company INNER JOIN
               dbo.Employee ON dbo.Company.id = dbo.Employee.fk_companylist LEFT OUTER JOIN
               dbo.Buildings ON dbo.Employee.fk_buildingaccess = dbo.Buildings.id INNER JOIN
               dbo.BeingHiredFor ON dbo.Employee.fk_hiredfor = dbo.BeingHiredFor.id