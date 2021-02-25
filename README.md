# Briefsys
### Descripción de repositorio

Hola visitante, este repositorio corresponde a una aplicación tipo ERP, la cual he estado mejorando día a día para aplicar los conocimientos que he logrado
obtener a lo largo del tiempo, tomándola como portafolio personal.

Dentro de la arquitectura y lenguajes que componen esta aplicación se encuentran:

+ ASP.NET MVC 5, lo cuál corresponde al mappeo de las tablas que se tienen en la base de datos, los controladores y las vistas.
+ Las vistas con diseño Razor tipo .cshtml, incluyen hojas de estilos personalizados y librerías.
+ JavaScript y JQuery, usando funciones y peticiones asíncronas para resolver la comunicación con el servidor.

El código de esta aplicación compone a funcionamiento FrontEnd y BackEnd, utilizando como conexión:

+ EntityFramework (ORM) para SQL Server y MySQL para resolver la conexión y administración de base de datos por Code First.
+ Clase de conexión como adicional si se quisiera utilizar DB First.

## Base de datos

Actualmente, la base de datos es de tipo No Relacional, por lo que:

+ No se tienen dependencias entre tablas.
+ Las llaves primarias solo se utilizan como identificadores principales entre tablas, pero no se han implementado llaves foráneas, esto debido a los cambios que se han presentado durante el desarrollo.

### Alojamiento

He logrado montar esta aplicación en un servicio de hosting gratuito, lo cuál me ha brindado de 1GB de espacio de almacenamiento para la aplicación y 1GB de SQL (SQL Server y MySQL) para poder realizar el store de la información.
