-- Problem 1
CREATE DATABASE minions;

-- Problem 2
CREATE TABLE minions(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
age INT,
PRIMARY KEY(id)
);

CREATE TABLE towns(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
PRIMARY KEY(id)
);

ALTER TABLE minions
 ADD FOREIGN KEY (town_id)
 REFERENCES towns(id);
 
-- Problem 3
ALTER TABLE minions
 ADD town_id INT NOT NULL;
 
-- Problem 4
INSERT INTO towns(id, name)
 VALUES(1, 'Sofia'),
 (2, 'Plovdiv'),
 (3, 'Varna');

INSERT INTO minions(id, name, age, town_id)
 VALUES(1, 'Kevin', 22, 1),
 (2, 'Bob', 15, 3),
 (3, 'Steward', NULL, 2);
 
-- Problem 5
TRUNCATE TABLE minions;

-- Problem 6
DROP TABLE minions;
DROP TABLE towns;

-- Problem 7
CREATE TABLE people(
id INT AUTO_INCREMENT,
name VARCHAR(200) NOT NULL,
picture BLOB,
height DOUBLE,
weight DOUBLE,
gender CHAR(1),
birthdate DATE NOT NULL,
biography VARCHAR(5000),
PRIMARY KEY(id)
);

INSERT INTO people 
 VALUES(1, 'Asen1', NULL, 1.80, 80.0, 'm', '1990/12/20', 'Asen'),
 (2, 'Asen2', NULL, 1.81, 81.0, 'm', '1990/12/21', 'Asen'),
 (3, 'Asen3', NULL, 1.82, 82.0, 'm', '1990/12/22', 'Asen'),
 (4, 'Asen4', NULL, 1.83, 83.0, 'm', '1990/12/22', 'Asen'),
 (5, 'Asiya', NULL, 1.73, 56.0, 'f', '1995/12/24', 'Asiya');
 
 -- Problem 8
CREATE TABLE users(
id BIGINT AUTO_INCREMENT,
username VARCHAR(30) NOT NULL,
password VARCHAR(26) NOT NULL,
profile_picture BLOB,
last_login_time DATE,
is_deleted TINYINT(1),
PRIMARY KEY(id)
);

INSERT INTO users 
 VALUES(1, 'Pesho1', '1234', NULL, '2016/09/21', FALSE),
 (2, 'Pesho2', '1234', NULL, '2016/09/21', FALSE),
 (3, 'Pesho3', '1234', NULL, '2016/09/21', FALSE),
 (4, 'Pesho4', '1234', NULL, '2016/09/21', FALSE),
 (5, 'Petya', '1234', NULL, '2016/09/21', FALSE);
 
-- Problem 9
ALTER TABLE users
MODIFY id BIGINT NOT NULL;

ALTER TABLE users
DROP PRIMARY KEY;

ALTER TABLE users 
ADD PRIMARY KEY (id, username);

-- Problem 10
ALTER TABLE users
ADD CHECK (LENGTH(password) > 4)

 -- Problem 11
ALTER TABLE users 
MODIFY COLUMN last_login_time TIMESTAMP
NOT NULL DEFAULT CURRENT_TIMESTAMP;

-- Problem 12
-- TODO
ALTER TABLE users
DROP PRIMARY KEY,
ADD PRIMARY KEY(id);

-- Problem 13
CREATE DATABASE movies;

USE movies;

CREATE TABLE directors(
id INT NOT NULL AUTO_INCREMENT,
director_name VARCHAR(30) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id)
);

CREATE TABLE genres(
id INT NOT NULL AUTO_INCREMENT,
genre_name VARCHAR(30) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id)
);

CREATE TABLE categories(
id INT NOT NULL AUTO_INCREMENT,
category_name VARCHAR(30) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id)
);

CREATE TABLE movies(
id INT NOT NULL AUTO_INCREMENT,
title VARCHAR(30) NOT NULL,
director_id INT NOT NULL,
copyright_year YEAR NOT NULL,
length TIME NOT NULL,
genre_id INT NOT NULL,
category_id INT NOT NULL,
rating DOUBLE NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id),
FOREIGN KEY (director_id) REFERENCES directors(id),
FOREIGN KEY (genre_id) REFERENCES genres(id),
FOREIGN KEY (category_id) REFERENCES categories(id)
);

INSERT INTO directors
 VALUES(1, 'Pesho1', NULL),
 (2, 'Pesho2', 'Note2'),
 (3, 'Pesho3', 'Note3'),
 (4, 'Pesho4', 'Note4'),
 (5, 'Pesho5', NULL);
 
INSERT INTO genres
 VALUES(1, 'Comedy', 'Comedy'),
 (2, 'Thriller', 'Thriller'),
 (3, 'Action', 'Action'),
 (4, 'Adventure', 'Adventure'),
 (5, 'Documentary', NULL);
 
INSERT INTO categories
 VALUES(1, 'History', 'NULL'),
 (2, 'Romance', NULL),
 (3, 'Biography', NULL),
 (4, 'Mystery ', NULL),
 (5, 'Drama', NULL);

INSERT INTO movies
 VALUES(1, 'Movie1', 2, 1999, '00:50', 1, 5, 5.00, 'Good'),
 (2, 'Movie2', 1, 1998, '00:40', 5, 4, 3.00, 'Poor'),
 (3, 'Movie3', 5, 1997, '00:30', 3, 3, 6.00, 'Excellent'),
 (4, 'Movie4', 4, 1996, '00:49', 2, 5, 4.00, 'Average'),
 (5, 'Movie5', 3, 1995, '00:59', 4, 1, 5.00, 'Good');

-- Problem	14
CREATE DATABASE car_rental;

USE car_rental;

CREATE TABLE categories(
id INT NOT NULL AUTO_INCREMENT,
category VARCHAR(50) NOT NULL,
daily_rate DOUBLE NOT NULL,
weekly_rate DOUBLE NOT NULL,
monthly_rate DOUBLE NOT NULL,
weekend_rate DOUBLE NOT NULL,
PRIMARY KEY(id)
);

CREATE TABLE cars(
id INT NOT NULL AUTO_INCREMENT,
plate_number VARCHAR(50) NOT NULL,
make VARCHAR(50) NOT NULL,
model VARCHAR(50) NOT NULL,
car_year YEAR NOT NULL,
category_id INT NOT NULL,
doors INT NOT NULL,
picture BLOB,
car_condition VARCHAR(50),
avaiable TINYINT,
PRIMARY KEY(id),
FOREIGN KEY(category_id) REFERENCES categories(id)
);

CREATE TABLE employees(
id INT NOT NULL AUTO_INCREMENT,
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
title VARCHAR(50) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id)
);

CREATE TABLE customers(
id INT NOT NULL AUTO_INCREMENT,
driver_licence_number VARCHAR(50) NOT NULL,
full_name VARCHAR(50) NOT NULL,
address VARCHAR(50) NOT NULL,
city VARCHAR(50) NOT NULL,
zip_code VARCHAR(10),
notes VARCHAR(5000),
PRIMARY KEY(id)
);

CREATE TABLE rental_orders (
id INT NOT NULL AUTO_INCREMENT,
employee_id INT NOT NULL,
customer_id INT NOT NULL,
car_id INT NOT NULL,
car_condition VARCHAR(50) NOT NULL,
tank_level INT NOT NULL,
kilometrage_start INT NOT NULL,
kilometrage_end INT NOT NULL,
total_kilometrage INT NOT NULL, 
start_date DATE NOT NULL,
end_date DATE NOT NULL,
total_days INT NOT NULL,
rate_applied DOUBLE NOT NULL,
tax_rate DOUBLE NOT NULL,
order_status VARCHAR(50) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id),
FOREIGN KEY(employee_id) REFERENCES employees(id),
FOREIGN KEY(customer_id) REFERENCES customers(id),
FOREIGN KEY(car_id) REFERENCES cars(id)
);

INSERT INTO categories 
 VALUES(1, 'category1', 4.00, 5.00, 6.00, 2.00),
 (2, 'category2', 5.00, 2.00, 6.00, 3.00),
 (3, 'category3', 3.00, 2.00, 3.00, 4.00);
 
INSERT INTO cars
 VALUES(1, '123', 'make', '316i', 1995, 1, 4, NULL, 'Good', TRUE),
 (2, '124', 'make', '318i', 2000, 2, 4, NULL, 'Good', TRUE),
 (3, '125', 'make', '320i', 2007, 3, 4, NULL, 'Good', FALSE);
 	
INSERT INTO employees 
 VALUES(1, 'Pesho', 'Peshev', 'title1', NULL),
 (2, 'Pesho1', 'Peshev1', 'title2', 'note'),
 (3, 'Pesho2', 'Peshev2', 'title3', NULL);
 
INSERT INTO customers 
 VALUES(1, 'CA5555HT', 'FullName1', 'adress1', 'sofia', '1220', NULL),
 (2, 'CA5545HT', 'FullName2', 'adress2', 'burgas', NULL, NULL),
 (3, 'CA5255HB', 'FullName3', 'adress3', 'plovdiv', NULL, NULL);
 
INSERT INTO rental_orders 
 VALUES(1, 1, 1, 1, 'Good', 5, 280000, 700000, 1000000, '2016/09/21', '2016/09/22', 30, 2.00, 3.00, 'Done', NULL),
 (2, 2, 2, 2, 'Good', 5, 180000, 500000, 700000, '2016/09/21', '2016/09/22', 30, 2.00, 3.00, 'Done', NULL),
 (3, 3, 3, 3, 'Bad', 5, 380000, 400000, 1000000, '2016/09/21', '2016/09/22', 30, 2.00, 3.00, 'Done', NULL);
 
-- Problem 15
CREATE DATABASE hotel;

USE hotel;

CREATE TABLE employees(
id INT NOT NULL AUTO_INCREMENT,
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
title VARCHAR(50) NOT NULL,
notes VARCHAR(5000),	
PRIMARY KEY(id)
);

CREATE TABLE customers(
account_number INT NOT NULL AUTO_INCREMENT,
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
phone_number VARCHAR(50) NOT NULL,
emergency_name VARCHAR(50) NOT NULL,
emergency_number VARCHAR(50) NOT NULL,	
notes VARCHAR(5000),
PRIMARY KEY(account_number)
);

CREATE TABLE room_status(
room_status VARCHAR(50) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(room_status)
);

CREATE TABLE room_types(
room_type VARCHAR(50) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(room_type)
);

CREATE TABLE bed_types(
bed_type VARCHAR(50) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(bed_type)
);

CREATE TABLE rooms(
room_number INT NOT NULL AUTO_INCREMENT,
room_type VARCHAR(50) NOT NULL,
bed_type VARCHAR(50) NOT NULL,
rate DOUBLE NOT NULL,
room_status VARCHAR(50) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(room_number),
FOREIGN KEY(room_type) REFERENCES room_types(room_type),
FOREIGN KEY(bed_type) REFERENCES bed_types(bed_type),
FOREIGN KEY(room_status) REFERENCES room_status(room_status)
);

CREATE TABLE payments(
id INT NOT NULL AUTO_INCREMENT,
employee_id INT NOT NULL,
payment_date DATE NOT NULL,
account_number INT NOT NULL,
first_date_occupied DATE NOT NULL,
last_date_occupied DATE NOT NULL,
total_days INT NOT NULL,
amount_charged DOUBLE NOT NULL,
tax_rate DOUBLE NOT NULL,
tax_amount DOUBLE NOT NULL,
payment_total DOUBLE NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id),
FOREIGN KEY(employee_id) REFERENCES employees(id),
FOREIGN KEY(account_number) REFERENCES customers(account_number)
);

CREATE TABLE occupancies(
id INT NOT NULL AUTO_INCREMENT,
employee_id INT NOT NULL,
date_occupied DATE NOT NULL,
account_number INT NOT NULL,
room_number INT NOT NULL,
rate_applied DOUBLE NOT NULL,
phone_charge VARCHAR(50) NOT NULL,
notes VARCHAR(5000),
PRIMARY KEY(id),
FOREIGN KEY(employee_id) REFERENCES employees(id),
FOREIGN KEY(account_number) REFERENCES customers(account_number),
FOREIGN KEY(room_number) REFERENCES rooms (room_number)
);

INSERT INTO employees
 VALUES(1, 'Pesho1', 'Peshev1',	'title1', NULL),
 (2, 'Pesho2', 'Peshev2', 'title2', NULL),
 (3, 'Pesho3', 'Peshev3', 'title3', NULL);
 
INSERT INTO customers
 VALUES(1, 'Pesho1', 'Peshev1',	'088 444 555 97', 'Emergency1', '112', NULL),
 (2, 'Pesho2', 'Peshev2',	'088 444 555 98', 'Emergency2', '112', NULL),
 (3, 'Pesho3', 'Peshev3',	'088 444 555 99', 'Emergency3', '112', NULL);
 
INSERT INTO room_status
 VALUES('room1', NULL),
 ('room2', NULL),
 ('room3', NULL);
 
INSERT INTO room_types 
 VALUES('room_type1', NULL),
 ('room_type2', NULL),
 ('room_type3', NULL);
 
INSERT INTO bed_types  
 VALUES('bed_type1', NULL),
 ('bed_type2', NULL),
 ('bed_type3', NULL);

INSERT INTO rooms  
 VALUES(1, 'room_type1', 'bed_type1', 8.00, 'room1', NULL),
 (2, 'room_type2', 'bed_type2', 5.00, 'room2', NULL),
 (3, 'room_type3', 'bed_type3', 6.00, 'room3', NULL);
 
INSERT INTO payments   
 VALUES(1, 1, '2016/09/22', 1, '2016/09/21', '2016/09/22', 30, 50.00, 3.00, 5.00, 80.00, NULL),
 (2, 2, '2016/09/22', 2, '2016/09/20', '2016/09/22', 40, 40.00, 2.00, 4.00, 60.00, NULL),
 (3, 3, '2016/09/22', 3, '2016/09/20', '2016/09/22', 10, 10.00, 1.00, 2.00, 30.00, NULL);
 
INSERT INTO occupancies   
 VALUES(1, 1, '2016/09/22', 1, 1, 3.00, 'phone_charge1', NULL),
 (2, 2, '2016/09/22', 2, 2, 4.00, 'phone_charge2', NULL),
 (3, 3, '2016/09/22', 3, 3, 5.00, 'phone_charge3', NULL);
 
-- Problem 16
CREATE DATABASE softuni;

USE softuni;

CREATE TABLE towns(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE addresses(
id INT NOT NULL AUTO_INCREMENT,
address_text VARCHAR(50) NOT NULL,
town_id INT,
PRIMARY KEY (id),
FOREIGN KEY(town_id) REFERENCES towns(id)
);

CREATE TABLE departments(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE employees(
id INT NOT NULL AUTO_INCREMENT,
first_name VARCHAR(50) NOT NULL,
middle_name VARCHAR(50),
last_name VARCHAR(50) NOT NULL,
job_title VARCHAR(50) NOT NULL,
department_id INT NOT NULL,
hire_date DATE NOT NULL,
salary DOUBLE NOT NULL,
address_id INT,
PRIMARY KEY (id),
FOREIGN KEY(department_id) REFERENCES departments(id),
FOREIGN KEY(address_id) REFERENCES addresses(id)
);

-- Problem 18
USE softuni;

INSERT INTO towns
 VALUES(1, 'Sofia'),
 (2, 'Plovdiv'),
 (3, 'Varna'),
 (4, 'Burgas');
 
INSERT INTO departments
 VALUES(1, 'Engineering'),
 (2, 'Sales'),
 (3, 'Marketing'),
 (4, 'Software Development'),
 (5, 'Quality Assurance');
 
INSERT INTO employees
 VALUES(1, 'Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00, NULL),
 (2, 'Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00, NULL),
 (3, 'Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28', 525.25, NULL),
 (4, 'Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007/12/09', 3000.00, NULL),
 (5, 'Peter', 'Pan', 'Pan', 'Intern', 3, '2016/08/28', 599.88, NULL);
 
-- Problem 19
SELECT * FROM towns;
SELECT * FROM departments;
SELECT * FROM employees ;

-- Problem 20
SELECT * FROM towns 
ORDER BY name;

SELECT * FROM departments
ORDER BY name;

SELECT * FROM employees 
ORDER BY salary DESC;

-- Problem 21
SELECT name FROM towns
ORDER BY name;

SELECT name FROM departments
ORDER BY name;

SELECT first_name, last_name, job_title, salary FROM employees
ORDER BY salary DESC;

-- Problem 22
UPDATE employees 
SET salary = salary + (0.1 * salary);

SELECT salary FROM employees;

-- Problem 23
USE hotel;

UPDATE payments 	 
SET tax_rate  = tax_rate - (0.03 * tax_rate);

SELECT tax_rate FROM payments;

-- Problem 24
USE hotel;
DELETE FROM occupancies;