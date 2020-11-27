select name_product from T_Product pro
	where pro.id_product in
	(
		select id_product from T_Basketitem
		where id_basket = 
		(
			select id_basket from T_User
			where id_user = 9
		)
	)