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