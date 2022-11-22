use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'PRUEBANET')
CREATE DATABASE PRUEBANET

GO 

USE PRUEBANET

GO

----- CREAMOS LA TABLA PRODUCTOS ---

create table PRODUCTOS(
id int primary key identity(1,1),
nombre varchar(60),
marca varchar(60),
precio int,
descripcion varchar(60),
fecha datetime default getdate(),
tipo varchar(60)
)


select * from dbo.PRODUCTOS
 
---INSERTAMOS DATOS A LA BD PRODUCTOS
USE PRUEBANET
GO
SET IDENTITY_INSERT dbo.PRODUCTOS ON 

INSERT PRODUCTOS (id, nombre, marca, precio, descripcion, tipo) VALUES (1, N'Mous', N'PP', 100, N'Mous Gaming', N'Info')
INSERT PRODUCTOS (id, nombre, marca, precio, descripcion, tipo) VALUES (2, N'PC', N'HP', 3000, N'Computadora marca HP', N'Info')

SET IDENTITY_INSERT PRODUCTOS OFF

--- CREAMOA LOS PROCEDIMIENTOS ALMACENADOS DE LA TABLA PRODUCTOS----

go
use PRUEBANET
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pro_registrar')
DROP PROCEDURE pro_registrar

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pro_modificar')
DROP PROCEDURE pro_modificar
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pro_obtener')
DROP PROCEDURE pro_obtener
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pro_listar')
DROP PROCEDURE pro_obtener
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pro_eliminar')
DROP PROCEDURE pro_eliminar
go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure pro_registrar(
@nombre varchar(60),
@marca varchar(60),
@precio int,
@descripcion varchar(60),
@tipo varchar(60)
)
as
begin
insert into PRODUCTOS(nombre,marca,precio,descripcion,tipo)
values
(
@nombre,
@marca,
@precio,
@descripcion,
@tipo
)
end
go

create procedure pro_modificar(
@id int,
@nombre varchar(60),
@marca varchar(60),
@precio int,
@descripcion varchar(60),
@tipo varchar(60)
)
as
begin
update PRODUCTOS set 
nombre = @nombre,
marca = @marca,
precio = @precio,
descripcion = @descripcion,
tipo = @tipo
where id = @id
end
go

create procedure pro_obtener(@id int)
as
begin
select * from PRODUCTOS where id = @id
end
go


create procedure pro_listar
as
begin
select * from PRODUCTOS
end
go

go
create procedure pro_eliminar(
@id int
)
as
begin

delete from PRODUCTOS where id = @id
end
go


----- CREAMOS LA TABLA PROVEEDORES ---

USE PRUEBANET
GO

create table PROVEEDORES(
id int primary key identity(1,1),
nombre varchar(60),
direccion varchar(60),
telefono varchar(60)
)


select * from dbo.PROVEEDORES
 
---INSERTAMOS DATOS A LA BD PRODUCTOS
USE PRUEBANET
GO
SET IDENTITY_INSERT dbo.PROVEEDORES ON 

INSERT PROVEEDORES (id, nombre, direccion, telefono) VALUES (1, N'Juan', N'Quetzaltenango', N'12904653')
INSERT PROVEEDORES (id, nombre, direccion, telefono) VALUES (2, N'Mario', N'Solola', N'43902845')

SET IDENTITY_INSERT PROVEEDORES OFF

--- CREAMOA LOS PROCEDIMIENTOS ALMACENADOS DE LA TABLA PRODUCTOS----

go
use PRUEBANET
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prov_registrar')
DROP PROCEDURE prov_registrar

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prov_modificar')
DROP PROCEDURE prov_modificar
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prov_obtener')
DROP PROCEDURE prov_obtener
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prov_listar')
DROP PROCEDURE prov_obtener
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prov_eliminar')
DROP PROCEDURE prov_eliminar
go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure prov_registrar(
@nombre varchar(60),
@direccion varchar(60),
@telefono varchar(60)
)
as
begin
insert into PROVEEDORES(nombre,direccion,telefono)
values
(
@nombre,
@direccion,
@telefono
)
end
go

create procedure prov_modificar(
@id int,
@nombre varchar(60),
@direccion varchar(60),
@telefono varchar(60)
)
as
begin
update PROVEEDORES set 
nombre = @nombre,
direccion = @direccion,
telefono = @telefono
where id = @id
end
go

create procedure prov_obtener(@id int)
as
begin
select * from PROVEEDORES where id = @id
end
go


create procedure prov_listar
as
begin
select * from PROVEEDORES
end
go

go
create procedure prov_eliminar(
@id int
)
as
begin

delete from PROVEEDORES where id = @id
end
go