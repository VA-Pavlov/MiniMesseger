use Messeger;
CREATE TABLE users(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	user_login NVARCHAR NOT NULL,
	user_password NVARCHAR NOT NULL,
	user_fio NVARCHAR NOT NULL
);

CREATE TABLE messeges(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	in_user_id INT NOT NULL,
	out_user_id INT NOT NULL,
	messeg NVARCHAR NOT NULL,
	messeg_date DATE NOT NULL,
	FOREIGN KEY (in_user_id)  REFERENCES users (Id),
	FOREIGN KEY (out_user_id)  REFERENCES users (Id)
);