-- Problem 1
SELECT first_name, last_name FROM employees
	WHERE first_name LIKE 'SA%';
	
-- Problem 2
SELECT first_name, last_name FROM employees
	WHERE last_name LIKE '%ei%';	
	
-- Problem 3
SELECT first_name FROM employees
	WHERE (department_id = 3 OR department_id = 10) AND
		   (YEAR(hire_date) > 1995 AND YEAR(hire_date) <= 2005);
	
-- Problem 4
SELECT first_name, last_name FROM employees
	WHERE job_title NOT LIKE '%engineer%';
	
-- Problem 5
SELECT name FROM towns
	WHERE LENGTH(name) = 5 OR LENGTH(name) = 6
	ORDER BY name;
	
-- Problem 6
SELECT town_id, name FROM towns
	WHERE name LIKE 'M%' OR 
			name LIKE 'K%' OR
			name LIKE 'B%' OR
			name LIKE 'E%'			
	ORDER BY name;
	
-- Problem 7
SELECT town_id, name FROM towns
	WHERE name NOT LIKE 'R%' AND 
			name NOT LIKE 'B%' AND
			name NOT LIKE 'D%'	
	ORDER BY name;
	
-- Problem 8
CREATE VIEW v_employees_hired_after_2000 AS
SELECT first_name, last_name FROM employees
	WHERE YEAR(hire_date) > 2000;
	
-- Proeblem 9
SELECT first_name, last_name FROM employees
	WHERE LENGTH(last_name) = 5;
	
-- Problem 10
SELECT country_name, iso_code FROM countries
	WHERE country_name LIKE '%a%a%a%'
ORDER BY iso_code;

-- Problem 11
SELECT peak_name, river_name,
CONCAT(
LOWER(SUBSTRING(peak_name, 1, CHAR_LENGTH(peak_name) - 1)),
LOWER(SUBSTRING(river_name, 1, CHAR_LENGTH(river_name)))
) AS mix
FROM peaks, rivers
 	WHERE 
   LOWER(SUBSTRING(peak_name, CHAR_LENGTH(peak_name), 1)) = 	
   LOWER(SUBSTRING(river_name, 1, 1))
ORDER BY mix;

-- Problem 12
SELECT name AS game, DATE_FORMAT(`start`,'%Y-%m-%d') as `start` FROM games
	WHERE YEAR(`start`) = 2011 OR YEAR(`start`) = 2012
	ORDER BY `start`, game
	LIMIT 50;
	
-- Problem 13
SELECT user_name, SUBSTRING(email, LOCATE('@', email) + 1, LENGTH(email)) AS email 
	FROM users
	ORDER BY email, user_name;
	
-- Proeblem 14
SELECT user_name, ip_address FROM users
	WHERE ip_address LIKE '___.1%.%.___'
	ORDER BY user_name;
	
-- Problem 15
SELECT name AS game,
	CASE WHEN HOUR(`start`) >= 0 AND HOUR(`start`) < 12 THEN 'Morning' 
	WHEN HOUR(`start`) >= 12 AND HOUR(`start`) < 18 THEN 'Afternoon' 
	WHEN HOUR(`start`) >= 18 AND HOUR(`start`) < 24 THEN 'Evening' 
	END AS part_of_the_day,
	CASE WHEN duration <= 3 THEN 'Extra Short' 
	WHEN duration >= 4 AND duration <= 6 THEN 'Short' 
	WHEN duration >= 6 THEN 'Long' 
	WHEN duration IS NULL THEN 'Extra Long' 
	END AS duration
FROM games
ORDER BY game, duration, part_of_the_day;

-- Problem 16
SELECT product_name,
		 order_date,
		 DATE_ADD(order_date, INTERVAL 3 DAY) AS pay_due,		 
		 DATE_ADD(order_date, INTERVAL 1 MONTH) AS deliver_due
FROM orders;