Coffee Managemnet Applicaion

Admin {
	Emplyoee{
		Customer { 
			User Login
			Sign Up

			Product
			Order
		}
		User Managemnet (Customer)
		Product Managemnet
		Order Managemnet	
	}
	User Managemnet (Emplyoee)
}

User[ ID , Username , Email & Password ]

Emplyoee[ID , UserID , FirstName , LastName , Contact NO]

Customer[ID , UserID , FirstName , LastName , Contact NO]

Product [ID , Name ,Description , Ingredietns, Price , ImgSource]

Order[ID , USerID, EmplyoeeID , CustomerID , Total]