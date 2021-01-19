
CREATE TABLE ServiceDesk(
IdTicket numeric(9),
FechaInicio datetime,
FechaFin datetime,
/*Ventana nvarchar(300),*/
HorasSeguimiento decimal(10,2),
EnTiempo nvarchar(100),
Tipo nvarchar(300),
Categoria nvarchar(300),
Subcategoria nvarchar(300),
/*EmailEmpleado nvarchar(300),*/
Prioridad int,
Tiempo decimal(10,2),
/*Area nvarchar(300), /*extends empleados*/
Departamento nvarchar(300),
Telefono nvarchar(300),*/
ReportadoPor int,
ReportadoMediante varchar(max),
/*IdInventario nvarchar(max),*/
/*Serie nvarchar(300),
Nparte nvarchar(300),
Marca nvarchar(300),
Modelo nvarchar(300),*/
Nota varchar(max), /*extends detalle*/
IdEstado char(1),
Estado varchar(max), /*extends detalle*/
Auditoria datetime,
Quien int /*extends empleados*/
);

CREATE TABLE ServiceDesk_Detalle(
IdTicket int,
Nota varchar(max),
FechaNota datetime,
IdEstadoNota char(1),
EstadoNota varchar(max),
IdEmpleado int,
Auditoria datetime
);

select *
from dbo.ServiceDesk