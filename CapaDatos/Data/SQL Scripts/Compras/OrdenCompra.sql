CREATE TABLE Catalogo_General(
IdProducto varchar(20),
Producto varchar(max),
PresentacionInterna varchar(100),
Estado char(1)
);

CREATE TABLE Requisicion(
IdReq int,
FechaReq datetime,
FechaAprobación datetime,
IdElaboro int /*Empleado necesita*/,
Estado char(1)
);

CREATE TABLE Requisicion_Aprobacion(
IdReq int,
IdAprobo int,
CantidadRequisicion decimal(10,2),
CantidadAprobada decimal(10,2),
FechaAprobacion datetime,
Estado char(1)
);

CREATE TABLE Requisicion_Detalle(
IdReq int,
IdProducto varchar(20),
Producto varchar(max),
CantidadSolicitada decimal(10,2)
);

CREATE TABLE Orden(
IdOrden int identity,
IdRequisicion int,
IdProveedor varchar(50),
Proveedor varchar(MAX),
FechaElaboracion date,
FechaEntrega date,
Moneda varchar(5),
IdElaboro int /*Empleado Elaboró*/, 
Estado char(1)
);

CREATE TABLE Orden_Detalle(
IdOrden int,
CodigoPartida int identity,
Partida int,
PartidaRequisicion int,
IdProducto varchar(20),
Producto varchar(MAX),
Cantidad decimal(10,2),
UnidadInterna varchar(100),
UnidadExterna varchar(100),
Atendido bit,
Estado char(1)
);

CREATE TABLE Orden_Recibida(
IdOrden int,
FechaRecepcion datetime,
CantidadRecibida decimal(10,2),
IdRecibio int /*Empleado Recibió*/,
Estado char(1)
);

insert into Orden(IdProveedor,Proveedor,FechaElaboracion,FechaEntrega,Moneda,IdElaboro,IdRequisicion,Estado) 
			values('PROV001','Proveedor Mesas S.A. de C.V.',GETDATE(),'2020-12-28','MXN',1,0,'N');
insert into Orden(IdProveedor,Proveedor,FechaElaboracion,FechaEntrega,Moneda,IdElaboro,IdRequisicion,Estado) 
			values('PROV002','Proveedor Bolsas S.A. de C.V.',GETDATE(),'2020-12-28','MXN',1,0,'N');
insert into Orden(IdProveedor,Proveedor,FechaElaboracion,FechaEntrega,Moneda,IdElaboro,IdRequisicion,Estado) 
			values('PROV003','Proveedor Electrónicos S.A. de C.V.',GETDATE(),'2021-01-18','MXN',1,0,'N');
insert into Orden(IdProveedor,Proveedor,FechaElaboracion,FechaEntrega,Moneda,IdElaboro,IdRequisicion,Estado) 
			values('PROV004','Proveedor Papeleria S.A. de C.V.',GETDATE(),'2021-02-03','USD',1,0,'N');
insert into Orden(IdProveedor,Proveedor,FechaElaboracion,FechaEntrega,Moneda,IdElaboro,IdRequisicion,Estado) 
			values('PROV005','Proveedor Muebles S.A. de C.V.',GETDATE(),'2021-02-03','USD',1,0,'N');

insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(1,1,'AC001','Acido sulfúrico H2SO4',0,20.50,'ml','ml','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(1,2,'EN015','Envase de 500ml',0,50,'pieza','paquete','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(1,3,'TB001','Producto linea num 001',0,40,'botella','caja','N',0);

						
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(2,1,'AC090','Acido acético C2H4O2',0,2.50,'L','ml','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(2,2,'EN015','Envase de 2L',0,20,'pieza','paquete','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(2,3,'TB004','Producto linea num 004',0,20,'botella','caja','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(2,3,'TB006','Producto linea num 006',0,10,'botella','caja','N',0);

						
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(3,1,'VARIOS','Laptop HP Pavilion x360',0,2,'pieza','pieza','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(3,2,'EN015','Envase de 3L',0,15,'pieza','paquete','N',0);

						
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(4,1,'AC100','Acido perclórico HClO4',0,2.50,'ml','ml','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(4,2,'EN015','Envase de 4L',0,20,'pieza','paquete','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(4,3,'VARIOS','Mesas circulares',0,10,'botella','caja','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(4,3,'DP001','Drog num 001',0,10,'botella','caja','N',0);
						

insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(5,1,'AC090','Acido acético C2H4O2',0,2.50,'L','ml','N',0);
insert into Orden_Detalle(IdOrden,Partida,IdProducto,Producto,PartidaRequisicion,Cantidad,UnidadInterna,UnidadExterna,Estado,Atendido) 
						values(5,2,'EN015','Envase de 2L',0,20,'pieza','paquete','N',0);

select *
from dbo.Orden oc
inner join dbo.Orden_Detalle od on oc.IdOrden = od.IdOrden
where oc.IdOrden = 4

--DROP TABLE Orden_Calendario
CREATE TABLE Orden_Calendario(
IdOrden int,
Partida int,
Color varchar(150),
FechaEntrega date,
FechaSugerida datetime,
Estado char(1)
);

CREATE TABLE Orden_Archivo(
IdOrden int,
NombreArchivo varchar(150),
Archivo varbinary(max),
FechaSubida datetime,
IdQuien int,
Estado char(1)
);

select *
from dbo.ca