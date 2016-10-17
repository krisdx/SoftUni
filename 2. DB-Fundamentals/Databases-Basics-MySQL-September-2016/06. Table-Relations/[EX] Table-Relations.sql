-- Problem 1
CREATE TABLE passports(
passport INT NOT NULL,
passport_number VARCHAR(50) NOT NULL,
PRIMARY KEY(passport)
);	

CREATE TABLE persons(
person_id INT NOT NULL,
first_name VARCHAR(50) NOT NULL,
salary DOUBLE NOT NULL,
passport_id INT NOT NULL,
PRIMARY KEY(person_id),
FOREIGN KEY(passport_id) REFERENCES passports(passport)
);

-- Problem 2
CREATE TABLE manufacturers(
manufacturer_id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(30) NOT NULL,
established_on DATE NOT NULL,
PRIMARY KEY(manufacturer_id)
);	

CREATE TABLE models(
model_id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(30) NOT NULL,
manufacturer_id INT,
PRIMARY KEY(model_id),
FOREIGN KEY(manufacturer_id) REFERENCES manufacturers(manufacturer_id)
);
 
-- Problem 3
CREATE TABLE students(
student_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(255) NOT NULL);

CREATE TABLE exams(
exam_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(255) NOT NULL);

CREATE TABLE students_exams(
student_id INT NOT NULL,
exam_id INT NOT NULL,
PRIMARY KEY(student_id, exam_id),
FOREIGN KEY (student_id) REFERENCES students(student_id),
FOREIGN KEY (exam_id) REFERENCES exams(exam_id));

-- Problem 4
CREATE TABLE teachers(
teacher_id INT NOT NULL,
name VARCHAR(50) NOT NULL,
manager_id INT,
PRIMARY KEY(teacher_id),
FOREIGN KEY(manager_id) REFERENCES teachers(teacher_id)
);	

-- Problem 5 
CREATE TABLE item_types(
item_type_id INT NOT NULL PRIMARY KEY,
name VARCHAR(50));

CREATE TABLE items(
item_id INT NOT NULL PRIMARY KEY,
name VARCHAR(50),
item_type_id INT NOT NULL,
FOREIGN KEY(item_type_id) REFERENCES item_types(item_type_id));

CREATE TABLE cities(
city_id INT NOT NULL PRIMARY KEY,
name VARCHAR(50));

CREATE TABLE customers(
customer_id INT NOT NULL PRIMARY KEY,
name VARCHAR(50),
birthdate DATE,
city_id INT NOT NULL,
FOREIGN KEY(city_id) REFERENCES cities(city_id));

CREATE TABLE orders(
order_id INT NOT NULL PRIMARY KEY,
customer_id INT NOT NULL,
FOREIGN KEY(customer_id) REFERENCES customers(customer_id));

CREATE TABLE order_items(
order_id INT NOT NULL,
item_id INT NOT NULL,
PRIMARY KEY(order_id, item_id),
FOREIGN KEY(item_id) REFERENCES items(item_id),
FOREIGN KEY (order_id) REFERENCES orders(order_id));

-- Problem 6
CREATE TABLE subjects(
subject_id INT NOT NULL AUTO_INCREMENT, 
subject_name VARCHAR(50) NOT NULL,
PRIMARY KEY(subject_id)
);

CREATE TABLE agenda(
student_id INT NOT NULL AUTO_INCREMENT,
subject_id INT NOT NULL,
PRIMARY KEY(student_id, subject_id),
FOREIGN KEY(subject_id) REFERENCES subjects(subject_id)
);	

CREATE TABLE majors(
major_id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
PRIMARY KEY(major_id)
);	

CREATE TABLE students(
student_id INT NOT NULL AUTO_INCREMENT,
student_number VARCHAR(12) NOT NULL,
student_name VARCHAR(50) NOT NULL,
major_id INT NOT NULL,
PRIMARY KEY(student_id),
FOREIGN KEY(major_id) REFERENCES majors(major_id),
FOREIGN KEY(student_id) REFERENCES agenda(student_id)
);	

CREATE TABLE payments(
payment_id INT NOT NULL AUTO_INCREMENT,
payment_date DATE NOT NULL,
payment_amount DECIMAL(8,2) NOT NULL,
student_id INT NOT NULL,
PRIMARY KEY(payment_id),
FOREIGN KEY(student_id) REFERENCES students(student_id)
);	

-- Problem 9
SELECT e.employee_id, 
		 e.job_title,  
		 a.address_id,
		 a.address_text
FROM employees AS e
	JOIN addresses AS a ON e.address_id = a.address_id
ORDER BY a.address_id
LIMIT 5;

-- Problem 10
SELECT e.employee_id, 
		 e.first_name,  
		 e.salary,
		 d.name
FROM employees AS e
	JOIN departments AS d ON e.department_id = d.department_id
WHERE e.salary > 15000
ORDER BY d.department_id
LIMIT 5;

-- Problem 11
SELECT e.employee_id, 
		 e.first_name
FROM employees AS e
WHERE e.employee_id NOT IN (SELECT ep.employee_id FROM employees_projects AS ep)
ORDER BY e.employee_id
LIMIT 3;
	
-- Problem 12
SELECT e.employee_id, 
		 e.first_name,  
		 p.name AS project_name
FROM employees AS e
	JOIN employees_projects AS ep ON e.employee_id = ep.employee_id
	JOIN projects AS p ON ep.project_id = p.project_id
WHERE p.start_date > '2002/08/13' AND p.end_date IS NULL
ORDER BY e.employee_id
LIMIT 5;

-- Problem 13
SELECT e.employee_id
		,e.first_name
		,p.name AS project_name
FROM employees AS e
	LEFT OUTER JOIN employees_projects AS ep ON e.employee_id = ep.employee_id
	LEFT OUTER JOIN projects AS p ON ep.project_id = p.project_id AND YEAR(p.start_date) < 2005
WHERE e.employee_id = 24

-- Problem 14
SELECT e.employee_id
		,e.first_name
		,e.manager_id
		,m.first_name AS manager_name
FROM employees AS e
	JOIN employees AS m ON e.manager_id = m.employee_id
WHERE e.manager_id = 3 OR e.manager_id = 7
ORDER BY e.employee_id

-- Problem 15
SELECT mc.country_code
		,m.mountain_range
		,p.peak_name
		,p.elevation
FROM peaks AS p
	JOIN mountains AS m ON p.mountain_id = m.id	
	JOIN mountains_countries AS mc ON m.id = mc.mountain_id
WHERE mc.country_code = 'BG' AND p.elevation > 2835
ORDER BY p.elevation DESC

-- Problem 16
SELECT mc.country_code
	   ,COUNT(m.id) AS mountan_ranges
FROM mountains AS m
	JOIN mountains_countries AS mc ON m.id = mc.mountain_id
WHERE mc.country_code IN ('BG', 'US', 'RU')
GROUP BY mc.country_code

-- Problem 17
SELECT c.country_name
	  ,r.river_name
FROM rivers AS r
	JOIN countries_rivers cr ON r.id = cr.river_id
	RIGHT	JOIN countries c ON cr.country_code = c.country_code
	JOIN continents cont ON c.continent_code = cont.continent_code
WHERE cont.continent_code = 'AF'
ORDER BY c.country_name
LIMIT 5;

-- Problem 18
SELECT co.continent_code
		,c.currency_code
		,(SELECT COUNT(c.currency_code)
		  FROM countries AS c
		  WHERE c.continent_code = co.continent_code
		  GROUP BY c.currency_code
		  HAVING COUNT(c.currency_code) > 1
		  ORDER BY COUNT(c.currency_code) DESC
	     LIMIT 1) AS currency_usage
FROM continents AS co
	JOIN countries AS c ON c.continent_code = co.continent_code
WHERE c.currency_code IN (SELECT c1.currency_code
								  FROM countries AS c1
								  WHERE c1.continent_code = co.continent_code
								  GROUP BY c1.currency_code
								  HAVING COUNT(c1.currency_code) > 1 AND
								  	COUNT(c1.currency_code) = (SELECT COUNT(c2.currency_code)
																	   FROM countries AS c2
																	   WHERE c2.continent_code = co.continent_code
																	   GROUP BY c2.currency_code
																	   HAVING COUNT(c2.currency_code) > 1
																	   ORDER BY COUNT(c2.currency_code) DESC
																	   LIMIT 1)
								  ORDER BY COUNT(c.currency_code) DESC)
GROUP BY co.continent_code, c.currency_code
ORDER BY co.continent_code, c.currency_code DESC

-- Problem 19
SELECT COUNT(c.country_code) AS country_code
FROM countries AS c
WHERE c.country_code NOT IN (SELECT mc.country_code FROM mountains_countries AS mc)

-- Problem 20
SELECT c.country_name
		,MAX(p.elevation)	AS highest_peak_elevation
		,MAX(r.`length`) AS longest_river_length
FROM countries AS c 
	LEFT JOIN mountains_countries mc ON c.country_code = mc.country_code
	LEFT JOIN mountains as m ON mc.mountain_id = m.id
	LEFT JOIN peaks as p ON m.id = p.mountain_id
	LEFT JOIN countries_rivers AS cr ON c.country_code = cr.country_code
	LEFT JOIN rivers AS r ON cr.river_id = r.id
GROUP BY c.country_name
ORDER BY highest_peak_elevation DESC, longest_river_length DESC
LIMIT 5;
	
-- Problem 21
SELECT c.country_name
		,IFNULL(p.peak_name, '(no highest peak)') AS highest_peak_name
		,IFNULL(p.elevation, 0) AS highest_peak_elevation
		,IFNULL(m.mountain_range, '(no mountain)') AS mountain
FROM countries AS c
	LEFT OUTER JOIN mountains_countries AS mc
	 ON mc.country_code = c.country_code
	LEFT OUTER JOIN mountains AS m 
	 ON mc.mountain_id = m.id
	LEFT OUTER JOIN peaks AS p
	 ON m.id = p.mountain_id
	LEFT OUTER JOIN (SELECT c.country_name, MAX(p.elevation) AS max_elevation 
						  FROM countries AS c
						     JOIN mountains_countries AS mc
							   ON mc.country_code = c.country_code
							  JOIN mountains AS m 
							   ON mc.mountain_id = m.id
							  JOIN peaks AS p
							   ON m.id = p.mountain_id
						  GROUP BY c.country_name) AS max_elevations 
	 ON max_elevations.country_name = c.country_name 
	 	AND p.elevation = max_elevations.max_elevation
GROUP BY c.country_name
ORDER BY c.country_name, highest_peak_name
LIMIT 5;