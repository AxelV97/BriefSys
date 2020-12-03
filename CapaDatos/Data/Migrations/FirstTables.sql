--USE MASTER;

--DROP DATABASE BriefSys;

CREATE DATABASE BriefSys;

USE BriefSys;

CREATE TABLE Departamento(
IdDepartamento int,
Clasificacion VARCHAR(2),
Descripcion VARCHAR(100),
Estado CHAR(1)
);

CREATE TABLE Puesto(
IdPuesto int,
IdDepartamento int,
Clasificacion VARCHAR(2),
Descripcion VARCHAR(100),
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

insert into Departamento(IdDepartamento,Clasificacion,Descripcion,Estado) values(1,'TI','Tecnología de la Información','A')
insert into Puesto(IdPuesto,IdDepartamento,Clasificacion,Descripcion,Estado) values(1,1,'JR','Programador Jr','A')
insert into Empleado(IdEmp,IdDepartamento,IdPuesto,Ingreso) values(1,1,1,GETDATE())
insert into Empleado_Detalle(IdEmp,Nombre,ApellidoP,ApellidoM,FechaNac,Telefono,Extension,Estado) values(1,'Edwin Axel','Vizuet','Gil','1997-08-10','5599999999','000','A')

SELECT *
FROM dbo.Departamento

SELECT *
FROM dbo.Empleado_Detalle

SELECT *
FROM dbo.Acceso_Usuario

select *
from dbo.Puesto

CREATE TABLE ServiceDesk(
IdTicket numeric(9),
FechaInicio datetime,
FechaFin datetime,
/*Ventana nvarchar(300),*/
HorasSeguimiento numeric(9),
EnTiempo nvarchar(100),
Tipo nvarchar(300),
Categoria nvarchar(300),
Subcategoria nvarchar(300),
/*EmailEmpleado nvarchar(300),*/
Prioridad numeric(9),
Tiempo numeric(9),
/*Area nvarchar(300), /*extends empleados*/
Departamento nvarchar(300),
Telefono nvarchar(300),*/
ReportadoPor int,
ReportadoMediante nvarchar(300),
IdInventario nvarchar(300),
/*Serie nvarchar(300),
Nparte nvarchar(300),
Marca nvarchar(300),
Modelo nvarchar(300),*/
Nota text, /*extends detalle*/
IdEstado int,
Estado nvarchar(300), /*extends detalle*/
Auditoria datetime,
Quien int /*extends empleados*/
);

CREATE TABLE ServiceDesk_Detalle(
IdTicket int,
Nota text,
FechaNota datetime,
IdEstadoNota int,
EstadoNota nvarchar(300),
IdEmpleado int,
Auditoria datetime
);