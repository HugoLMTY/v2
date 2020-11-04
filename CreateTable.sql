use DB_Ynov

CREATE TABLE T_User
(
	id_user int not null primary key,
	name_user char not null,
	firstname_user char not null,
	type_user int not null,
	mail_user char not null,
	age_user int,
	adress_user char not null,
	tel_user int not null,
	pword_user char not null,
)

CREATE TABLE T_Imgproduct
(
	id_imgproduct int not null primary key,
	path_imgproduct char not null,
	name_product char not null
)

CREATE TABLE T_Product
(
	id_product int not null primary key,
	name_product char not null,
	qty_product int not null,
	color_product char not null,
	price_product int not null,
	desc_product char not null,
	id_imgproduct int FOREIGN KEY REFERENCES T_Imgproduct(id_imgproduct),
	type_product char not null,
	height_product float,
	lenght_product float,
	width_product float
)

CREATE TABLE T_Basket
(
	id_basket int not null primary key,
	qty_basket int not null,
	price_basket int not null,
	id_user int FOREIGN KEY REFERENCES T_User(id_user),
	status_basket char not null
)

CREATE TABLE T_Basketitem
(
	id_basketitem int not null primary key,
	id_basket int FOREIGN KEY REFERENCES T_Basket(id_basket),
	id_product int FOREIGN KEY REFERENCES T_Product(id_product),
	qty_basketitem int not null,
	price_basketitem int not null
)

CREATE TABLE T_Order
(
	id_order int not null primary key,
	id_basket int FOREIGN KEY REFERENCES T_Basket(id_basket),
	request_order char not null,
	comment_order char,
	filepath_order char not null,
	status_order char not null
)
