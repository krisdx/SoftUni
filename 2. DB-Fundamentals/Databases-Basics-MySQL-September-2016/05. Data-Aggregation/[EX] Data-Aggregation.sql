-- Problem 1
SELECT COUNT(*) FROM wizzard_deposits;

-- Problem 2
SELECT MAX(magic_wand_size) FROM wizzard_deposits;

-- Problem 3
SELECT deposit_group, MAX(magic_wand_size)
FROM wizzard_deposits
GROUP BY deposit_group;

-- Problem 4
SELECT deposit_group
FROM wizzard_deposits 
GROUP BY deposit_group
ORDER BY AVG(magic_wand_size)
LIMIT 1;

-- Problem 5
SELECT deposit_group, SUM(deposit_amount)
FROM wizzard_deposits
GROUP BY deposit_group;

-- Problem 6
SELECT deposit_group, SUM(deposit_amount)
FROM wizzard_deposits
	WHERE magic_wand_creator = 'Ollivander family'
GROUP BY deposit_group;

-- Problem 7
SELECT deposit_group, SUM(deposit_amount) AS total_sum
FROM wizzard_deposits
	WHERE magic_wand_creator = 'Ollivander family'
GROUP BY deposit_group
HAVING SUM(deposit_amount) < 150000 
ORDER BY total_sum DESC;

-- Problem 8
-- TODO

-- Problem 9
SELECT 
 CASE 
	WHEN age >= 0 AND age <= 10 THEN '[0-10]'
	WHEN age >= 11 AND age <= 20 THEN '[11-20]'
	WHEN age >= 21 AND age <= 30 THEN '[21-30]'
	WHEN age >= 31 AND age <= 40 THEN '[31-40]'
	WHEN age >= 41 AND age <= 50 THEN '[41-50]'
	WHEN age >= 51 AND age <= 60 THEN '[51-60]'
	WHEN age >= 61 THEN '[61+]'
	END as `group`,
COUNT(*) AS `count`
FROM wizzard_deposits
GROUP BY `group`;

-- Problem 10
SELECT DISTINCT SUBSTRING(first_name, 1, 1) AS first_letter
FROM wizzard_deposits
	WHERE deposit_group = 'Troll Chest'
ORDER BY first_letter;

-- Problem 11
SELECT deposit_group
		,is_deposit_expired
		,AVG(deposit_interest) AS average_interest
FROM wizzard_deposits
	WHERE DATE(deposit_start_date) > '1985/01/01'
GROUP BY deposit_group, is_deposit_expired
ORDER BY deposit_group DESC, is_deposit_expired;

-- Problem 12
SELECT SUM(w.deposit_amount - w1.deposit_amount) AS sum_difference
	FROM wizzard_deposits AS w
	JOIN (SELECT id, deposit_amount FROM wizzard_deposits) AS w1
	 ON w.id + 1 = w1.id 

-- Problem 13
SELECT department_id, MIN(salary)
FROM employees
	WHERE department_id IN (2, 5, 7) AND
			hire_date > '2000/01/01'
GROUP BY department_id

-- Problem 14
CREATE TABLE employees_salaries
	SELECT * FROM employees
	WHERE salary > 30000;
	
DELETE FROM employees_salaries 
	WHERE manager_id = 42;
	
UPDATE employees_salaries 
	SET salary = salary + 5000
	WHERE department_id = 1;
	
SELECT department_id, AVG(salary) AS manager_id
	FROM employees_salaries
GROUP BY department_id;

-- Problem 15
SELECT department_id, MAX(salary) AS max_salary
FROM employees
GROUP BY department_id
HAVING MAX(salary) < 30000 OR MAX(salary) > 70000

-- Problem 16
SELECT COUNT(salary) AS `count`
FROM employees
	WHERE manager_id IS NULL;
	
-- Problem 17
SELECT e.department_id
	  ,e.salary 
FROM employees AS e
	WHERE e.salary = (SELECT DISTINCT e1.salary
		 FROM employees AS e1
		 WHERE e.department_id = e1.department_id
		 GROUP BY e1.salary
		 ORDER BY e1.salary DESC
		 LIMIT 1 OFFSET 2)
GROUP BY e.department_id