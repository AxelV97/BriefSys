--DROP DATABASE BriefSys;

CREATE DATABASE BriefSys;

USE BriefSys;

CREATE TABLE Departamento(
IdDepartamento int,
Clasificacion VARCHAR(2),
Descripción VARCHAR(100),
Estado CHAR(1)
);

CREATE TABLE Puesto(
IdPuesto int,
IdDepartamento int,
Clasificacion VARCHAR(2),
Descripción VARCHAR(100),
Estado CHAR(1)
);

CREATE TABLE Empleado(
IdDepartamento int,
IdPuesto int,
IdEmp int,
Ingreso date
);

CREATE TABLE Empleado_Detalle(
IdEmp int,
Nombre varchar(100),
ApellidoP varchar(100),
ApellidoM varchar(100),
FechaNac date,
Telefono varchar(100),
Extension varchar(100),
FotografiaDigital varbinary(max),
Estado char(1)
);

--DROP TABLE Acceso_Usuario
CREATE TABLE Acceso_Usuario(
IdEmp int,
UsuarioID varchar(100),
Password varchar(150),
Salt varchar(100),
FechaModificacion datetime
);

insert into Departamento(IdDepartamento,Clasificacion,Descripción,Estado) values(1,'TI','Tecnología de la Información','A')
insert into Puesto(IdPuesto,IdDepartamento,Clasificacion,Descripción,Estado) values(1,1,'JR','Programador Jr','A')
insert into Empleado(IdEmp,IdDepartamento,IdPuesto,Ingreso) values(1,1,1,GETDATE())
insert into Empleado_Detalle(IdEmp,Nombre,ApellidoP,ApellidoM,FechaNac,Telefono,Extension,Estado) values(1,'Edwin Axel','Vizuet','Gil','1997-08-10','5599999999','000','A')

SELECT *
FROM dbo.Empleado_Detalle

SELECT *
FROM dbo.Acceso_Usuario