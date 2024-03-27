create database prueba
use prueba



create table categoria (
    id_categoria int not null identity primary key,
    nombre_categoria varchar(256) not null,
    descripcion varchar(256) not null
);

create table subcategoria (
    id_subcategoria int not null identity primary key,
		id_categoria int not null references categoria (id_categoria),
    nombre_subcategoria varchar(256) not null,
    descripcion varchar(256) not null
);





create table unidad_medida (
    id_unidad_medida int not null identity primary key,
    nombre_medida varchar(256) not null,
	abreviatura varchar(256) not null
);


create table producto (
    id_producto int not null identity primary key,
    id_unidad_medida int not null references unidad_medida (id_unidad_medida),
    id_subcategoria int not null references subcategoria (id_subcategoria),
    nombre_producto varchar(256) not null,
    precio_producto varchar(256) not null,
    descripcion_producto varchar(256) not null,
    stock int not null
);

drop view VistaProductos

select *from VistaProductos

CREATE VIEW VistaProductos AS
SELECT 
    p.id_producto AS ID,
    p.nombre_producto AS NOMBRE,
    s.nombre_subcategoria AS SUBCATEGORIA,
    u.abreviatura AS ABREVIATURA,
    p.precio_producto AS PRECIO,
    p.stock AS CANTIDAD,
    p.descripcion_producto AS DESCRIPCION
FROM 
    producto p
INNER JOIN 
    subcategoria s ON p.id_subcategoria = s.id_subcategoria
INNER JOIN 
    unidad_medida u ON p.id_unidad_medida = u.id_unidad_medida;




drop view VistaSubcategoria

CREATE VIEW VistaSubcategoria AS
SELECT 
    s.id_subcategoria AS id_subcategoria,
    s.nombre_subcategoria AS nombre_subcategoria,
    s.descripcion AS descripcion,
    c.nombre_categoria AS nombre_categoria
FROM 
    subcategoria s
INNER JOIN 
    categoria c ON s.id_categoria = c.id_categoria;






	CREATE VIEW VistaUnidadMedida AS
SELECT 
*
FROM 
    unidad_medida


	drop view VistaSubcategoria


	CREATE VIEW VistaCategoria AS
SELECT 
	c.id_categoria as ID,
	c.nombre_categoria as NOMBRE,
	c.descripcion as DESCRIPCION
	
FROM 
    categoria c
