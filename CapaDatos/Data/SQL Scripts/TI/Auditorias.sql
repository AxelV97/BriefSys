CREATE TABLE Auditoria_Global(
IdHistorico int,
TipoDocumento varchar(150),
IdDocumento varchar(150),
DescripcionMovimiento varchar(max),
DescripcionUsuario varchar(max),
Cuando datetime,
IdQuien int
);