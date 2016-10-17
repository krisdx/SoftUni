-- Section 1. DDL
-- Problem 1
CREATE TABLE deposit_types(
deposit_type_id INT NOT NULL,
name VARCHAR(20) NOT NULL,	
PRIMARY KEY(deposit_type_id)
);

CREATE TABLE deposits(
deposit_id INT NOT NULL AUTO_INCREMENT, 
amount DECIMAL(10, 2) NOT NULL,
start_date DATE NOT NULL,
end_date DATE,
deposit_type_id INT ,
customer_id INT,
PRIMARY KEY(deposit_id),
FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
FOREIGN KEY (deposit_type_id) REFERENCES deposit_types(deposit_type_id)
);

CREATE TABLE employees_deposits(
employee_id INT NOT NULL, 
deposit_id INT NOT NULL,
PRIMARY KEY(employee_id, deposit_id),
FOREIGN KEY (employee_id) REFERENCES employees(employee_id),
FOREIGN KEY (deposit_id) REFERENCES deposits(deposit_id)
);

CREATE TABLE credit_history(
credit_history_id INT NOT NULL, 
mark CHAR(1) NOT NULL,
start_date DATE NOT NULL,
end_date DATE NOT NULL,
customer_id INT,
PRIMARY KEY(credit_history_id),
FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE payments(
payement_id INT NOT NULL,
`date` DATE NOT NULL,
amount DECIMAL(10, 2) NOT NULL,
loan_id INT,
PRIMARY KEY(payement_id),
FOREIGN KEY (loan_id) REFERENCES loans(loan_id)
);

CREATE TABLE users(
user_id INT NOT NULL,
user_name VARCHAR(20) NOT NULL,
`password` VARCHAR(20) NOT NULL,
customer_id INT UNIQUE,
PRIMARY KEY(user_id),
FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

ALTER TABLE employees
ADD COLUMN manager_id INT;

ALTER TABLE employees
ADD FOREIGN KEY (manager_id)
REFERENCES employees(employee_id);

-- Section 2. DML
-- Problem 1
INSERT INTO deposit_types
VALUES(1, 'Time Deposit'),
(2, 'Call Deposit'),
(3, 'Free Deposit');

INSERT INTO deposits(amount, start_date, end_date, deposit_type_id, customer_id)
(SELECT IF(date_of_birth > '1980/01/01', 1000, 1500) + IF(gender = 'M', 100, 200) AS amount
		 ,CURDATE() AS start_date
		 ,NULL AS end_date
		 ,IF(customer_id > 15, 3, IF(customer_id % 2 = 0, 2, 1)) AS deposit_type_id,
		 customer_id	
FROM customers
WHERE customer_id < 20);

INSERT INTO employees_deposits
VALUES (15, 4),
(20, 15),
(8, 7),
(4, 8),
(3, 13),
(3, 8),
(4, 10),
(10, 1),
(13, 4),
(14, 9);

-- Section 2. DML
-- Problem 2
UPDATE employees
SET manager_id = (CASE 
						 WHEN employee_id >= 2 AND employee_id <= 10 THEN 1
						 WHEN employee_id >= 12 AND employee_id <= 20 THEN 11
						 WHEN employee_id >= 22 AND employee_id <= 30 THEN 21
						 WHEN employee_id IN (11, 21) THEN 1
					   END);
					   
-- Section 2. DML
-- Problem 3
DELETE FROM employees_deposits
WHERE deposit_id = 9 OR employee_id = 3

-- Section 3. Querying
-- Problem 1
SELECT employee_id
		,hire_date
		,salary
		,branch_id
FROM employees
WHERE salary > 2000 AND hire_date > '2009/06/15'

-- Section 3. Querying
-- Problem 2
-- TODO

-- Section 3. Querying
-- Problem 3
SELECT cu.customer_id
		,cu.first_name
		,cu.last_name
		,cu.gender
		,ci.city_name
FROM customers AS cu
	JOIN cities as ci ON cu.city_id = ci.city_id
WHERE (LEFT(cu.last_name, 2) = 'bu' OR RIGHT(cu.first_name, 1) = 'a')
			AND CHAR_LENGTH(ci.city_name) >= 8;
		
-- Section 3. Querying
-- Problem 4	
SELECT e.employee_id
		,e.first_name
		,a.account_number
FROM employees AS e
	JOIN employees_accounts AS ea ON e.employee_id = ea.employee_id
	JOIN accounts AS a ON ea.account_id = a.account_id
WHERE YEAR(a.start_date) > 2012 
ORDER BY e.first_name DESC
LIMIT 5;

-- Section 3. Querying
-- Problem 5
SELECT c.city_name
		,b.name
		,COUNT(e.employee_id)
FROM cities AS c
	JOIN branches AS b ON c.city_id = b.city_id
	JOIN employees AS e ON b.branch_id = e.branch_id
WHERE c.city_id NOT IN (4, 5)
GROUP BY c.city_name, b.name
HAVING COUNT(e.employee_id) >= 3;	

-- Section 3. Querying
-- Problem 6
SELECT SUM(l.amount)
		,MAX(l.interest)
		,MIN(e.salary)
FROM employees AS e
	JOIN employees_loans AS el ON e.employee_id = el.employee_id
	JOIN loans AS l ON el.loan_id = l.loan_id;
	
-- Section 3. Querying
-- Problem 7
(SELECT e.first_name
		 ,c.city_name
FROM employees AS e
	JOIN branches AS b ON e.branch_id = b.branch_id
	JOIN cities AS c ON b.city_id = c.city_id
LIMIT 3)
UNION ALL
(SELECT cu.first_name
		 ,ci.city_name
FROM customers AS cu
	JOIN cities AS ci ON cu.city_id = ci.city_id
LIMIT 3);

-- Section 3. Querying
-- Problem 8
SELECT c.customer_id
		,c.height
FROM customers AS c
WHERE c.customer_id NOT IN (SELECT customer_id FROM accounts)
		 AND (c.height >= 1.74 AND c.height <= 2.04);
		 
-- Section 3. Querying
-- Problem 9
SELECT c.customer_id, l.amount
FROM customers AS c
	JOIN loans AS l ON c.customer_id = l.customer_id
WHERE	l.amount > (SELECT AVG(l1.amount)
						FROM customers AS c1
							JOIN loans AS l1 ON c1.customer_id = l1.customer_id
						WHERE c1.gender = 'M')
ORDER BY c.last_name 
LIMIT 5;

-- Section 3. Querying
-- Problem 10
SELECT c.customer_id
		,c.first_name	
		,a.start_date
FROM customers AS c
	JOIN accounts AS a ON c.customer_id = a.customer_id
WHERE	a.start_date = (SELECT MIN(a.start_date)
							 FROM customers AS c
								 JOIN accounts AS a ON c.customer_id = a.customer_id);

-- Section 4. Programmability
-- Problem 1
DELIMITER //
DROP FUNCTION IF EXISTS udf_concat_string //

CREATE FUNCTION udf_concat_string(first_str VARCHAR(225), second_str VARCHAR(225))
RETURNS VARCHAR(225)

BEGIN
	RETURN CONCAT(REVERSE(first_str), REVERSE(second_str));
END //

-- Section 4. Programmability
-- Problem 2
DELIMITER //
DROP PROCEDURE IF EXISTS usp_customers_with_unexpired_loans //

CREATE PROCEDURE usp_customers_with_unexpired_loans(target_customer_id INT)
BEGIN
	SELECT c.customer_id
		,c.first_name
		,l.loan_id
	FROM customers AS c
		JOIN loans AS l ON c.customer_id = l.customer_id
	WHERE c.customer_id = target_customer_id
		 AND l.expiration_date IS NULL;
END //

-- Section 4. Programmability
-- Problem 3
DELIMITER //
DROP PROCEDURE IF EXISTS usp_take_loan //

CREATE PROCEDURE usp_take_loan(
target_customer_id INT, loan_amount DOUBLE, interest_rate DOUBLE, `start` DATE)
BEGIN
	START TRANSACTION;
	
	IF (loan_amount < 0.01 OR loan_amount > 100000)
		THEN 
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid Loan Amount.';
			ROLLBACK;
	END IF;
	
	INSERT INTO loans(start_date, amount, interest, expiration_date, customer_id)
		VALUES(`start`, loan_amount, interest_rate, NULL, target_customer_id);
	COMMIT;
END //

-- Section 4. Programmability
-- Problem 4
DELIMITER //
DROP TRIGGER IF EXISTS tr_isert_employee //

CREATE TRIGGER tr_isert_employee
AFTER INSERT
ON employees
FOR EACH ROW
BEGIN
	DECLARE loan_id_to_take INT; 
	SET loan_id_to_take = (SELECT loan_id FROM employees_loans
							     WHERE employee_id = NEW.employee_id - 1);
						
 	INSERT INTO employees_loans(employee_id, loan_id)
 		VALUES(NEW.employee_id, loan_id_to_take);
END //

-- Section 5. Bonus
-- Problem 5
CREATE TABLE IF NOT EXISTS account_logs 
SELECT * FROM accounts;
-- WHERE NULL = NULL;
DELETE FROM account_logs;

DELIMITER //
DROP TRIGGER IF EXISTS tr_log_accounts //

CREATE TRIGGER tr_log_accounts
BEFORE DELETE
ON accounts
FOR EACH ROW
BEGIN
	DELETE FROM employees_accounts
	WHERE account_id = OLD.account_id;

 	INSERT INTO account_logs(account_id, account_number, start_date, customer_id)
 		VALUES(OLD.account_id, OLD.account_number, OLD.start_date, OLD.customer_id);
END //