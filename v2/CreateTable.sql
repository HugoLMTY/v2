
create database DB_Ynov



use DB_Ynov

CREATE TABLE T_User
(
	id_user int not null primary key identity(1,1),
	name_user varchar(50) not null,
	firstname_user varchar(50) not null,
	type_user int not null,
	mail_user varchar(50) not null,
	age_user int,
	adress_user varchar(50) not null,
	tel_user int not null,
	pword_user varchar(50) not null,
)

CREATE TABLE T_Imgproduct
(
	id_imgproduct int not null primary key identity(1,1),
	path_imgproduct varchar(50) not null,
	name_product varchar(50) not null
)

CREATE TABLE T_Product
(
	id_product int not null primary key identity(1,1),
	name_product varchar(50) not null,
	qty_product int not null,
	color_product varchar(50) not null,
	price_product int not null,
	desc_product varchar(50) not null,
	id_imgproduct int FOREIGN KEY REFERENCES T_Imgproduct(id_imgproduct),
	type_product varchar(50) not null,
	height_product float,
	lenght_product float,
	width_product float
)

CREATE TABLE T_Basket
(
	id_basket int not null primary key identity(1,1),
	qty_basket int not null,
	price_basket int not null,
	id_user int FOREIGN KEY REFERENCES T_User(id_user),
	status_basket varchar(50) not null
)

CREATE TABLE T_Basketitem
(
	id_basketitem int not null primary key identity(1,1),
	id_basket int FOREIGN KEY REFERENCES T_Basket(id_basket),
	id_product int FOREIGN KEY REFERENCES T_Product(id_product),
	qty_basketitem int not null,
	price_basketitem int not null
)

CREATE TABLE T_Order
(
	id_order int not null primary key identity(1,1),
	id_basket int FOREIGN KEY REFERENCES T_Basket(id_basket),
	request_order varchar(50) not null,
	comment_order varchar(50),
	filepath_order varchar(50) not null,
	status_order varchar(50) not null
)
