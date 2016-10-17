-- Problem 1
CREATE PROCEDURE usp_get_employees_salary_above_35000()
	SELECT first_name, last_name
	FROM employees
	WHERE salary > 35000;

-- Problem 2
CREATE PROCEDURE usp_get_employees_salary_above(IN target_salary DOUBLE)
	SELECT first_name, last_name
	FROM employees
	WHERE salary >= target_salary;
	
-- Problem 3
CREATE PROCEDURE usp_get_towns_starting_with(IN start_str VARCHAR(255))
	SELECT name
	FROM towns
	WHERE LEFT(name, CHAR_LENGTH(start_str)) = start_str;
	
-- Problem 4
CREATE PROCEDURE usp_get_employees_from_town(IN town_name VARCHAR(255))
	SELECT e.first_name, e.last_name
	FROM employees AS e
		JOIN addresses AS a ON e.address_id = a.address_id
		JOIN towns AS t ON a.town_id = t.town_id
	WHERE t.name = town_name;
	
-- Problem 5
DELIMITER //
DROP FUNCTION IF EXISTS ufn_get_salary_level //

CREATE FUNCTION ufn_get_salary_level(salary DECIMAL)
RETURNS VARCHAR(50)
NOT DETERMINISTIC

BEGIN	

DECLARE salary_Level VARCHAR(30);

IF (salary < 30000)
	THEN SET salary_Level = 'Low';
ELSEIF (salary >= 30000 AND salary <= 50000)
	THEN SET salary_Level = 'Average';
ELSEIF (salary > 50000)
	THEN SET salary_Level = 'High';
END IF;
	
RETURN (salary_Level);
END //

-- Problem 6
DELIMITER //
DROP PROCEDURE IF EXISTS usp_get_employees_by_salary_level //

CREATE PROCEDURE usp_get_employees_by_salary_level(IN salary_level VARCHAR(30))

BEGIN
	IF (salary_level = 'low')
		THEN (SELECT first_name, last_name
				FROM employees
				WHERE salary < 30000);
	ELSEIF (salary_level = 'average')
		THEN (SELECT first_name, last_name
					FROM employees
					WHERE salary >= 30000 AND salary <= 50000);
	ELSEIF (salary_level = 'high')
		THEN (SELECT first_name, last_name
				FROM employees
		 		WHERE salary > 50000);
	END IF;
END //

-- Problem 7
delimiter //
DROP FUNCTION IF EXISTS ufn_is_word_comprised //

CREATE FUNCTION ufn_is_word_comprised(set_of_letters VARCHAR(255), word VARCHAR(255))
RETURNS TINYINT

BEGIN

DECLARE word_index INT DEFAULT 0;
DECLARE current_letter VARCHAR(1);

for_loop: LOOP
	SET word_index = word_index + 1;
	SET current_letter = LOWER(SUBSTRING(word, word_index, 1));
	
	IF (LOCATE(current_letter, LOWER(set_of_letters)) = 0)
		THEN RETURN(0);
	END IF;
	
	IF (word_index < CHAR_LENGTH(word) - 1)
		THEN ITERATE for_loop;
	END IF;
	LEAVE for_loop;
END LOOP for_loop;

RETURN (1);
END //

-- Problem 9
delimiter //
DROP PROCEDURE IF EXISTS usp_get_holders_full_name //

CREATE PROCEDURE usp_get_holders_full_name()

BEGIN
	SELECT CONCAT(first_name, ' ', last_name ) AS full_name
	FROM account_holders;
END //

-- Problem 10
DELIMITER //
DROP PROCEDURE IF EXISTS usp_get_holders_with_balance_higher_than //

CREATE PROCEDURE usp_get_holders_with_balance_higher_than(IN target_amount DOUBLE)

BEGIN
	SELECT ah.first_name
			,ah.last_name
	FROM account_holders AS ah
		JOIN accounts AS a ON a.account_holder_id = ah.id
	GROUP BY (CONCAT(ah.first_name, ah.last_name))
	HAVING SUM(a.balance) > target_amount;
END //

-- Problem 11
DELIMITER //
DROP FUNCTION IF EXISTS ufn_calculate_future_value //

CREATE FUNCTION ufn_calculate_future_value
	(initial_sum DOUBLE, yearly_interest_rate DOUBLE, number_of_years DOUBLE)
RETURNS DOUBLE 

BEGIN	
	DECLARE result DOUBLE;
	
	SET result = initial_sum * POW((1 + yearly_interest_rate), number_of_years);

	RETURN (result);
END //

-- Problem 12
DELIMITER //
DROP PROCEDURE IF EXISTS usp_calculate_future_value_for_account  //

CREATE PROCEDURE usp_calculate_future_value_for_account(IN target_id INT, IN interest_rate DOUBLE)
BEGIN
	SELECT a.id AS account_id
			,ah.first_name
			,ah.last_name
			,a.balance AS current_balance
			,ufn_calculate_future_value(a.balance, interest_rate, 5) AS balance_in_5_years
	FROM account_holders AS ah 
		JOIN accounts AS a ON a.account_holder_id = ah.id
	WHERE a.id = target_id;
END //

-- Problem 13
DELIMITER //
DROP PROCEDURE IF EXISTS usp_deposit_money  //

CREATE PROCEDURE usp_deposit_money(IN account_id INT, IN money_amount DECIMAL)
BEGIN
	START TRANSACTION;
   
	 UPDATE accounts
      SET balance = balance + money_amount
      WHERE id = account_id;	
    COMMIT;
END //

-- Problem 14
DELIMITER //
DROP PROCEDURE IF EXISTS usp_withdraw_money //

CREATE PROCEDURE usp_withdraw_money(IN account_id INT, IN money_amount DECIMAL)
BEGIN
	START TRANSACTION;
	
    UPDATE accounts
      SET balance = balance - money_amount
      WHERE id = account_id;	
      
   COMMIT;
END //

-- Problem 15
DELIMITER //
DROP PROCEDURE IF EXISTS usp_transfer_money //

CREATE PROCEDURE usp_transfer_money(
	IN source_account_id INT, IN destination_account_id INT, IN money_amount DOUBLE)
BEGIN
	START TRANSACTION;
	
	IF (source_account_id NOT IN (SELECT id FROM accounts) OR destination_account_id NOT IN (SELECT id FROM accounts))
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "One of the id's is invalid.";
		ROLLBACK;
	ELSEIF (source_account_id IS NULL OR destination_account_id IS NULL)
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "One of the id's is null.";
		ROLLBACK;
	ELSEIF (money_amount < 0)
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "The money amount cannot be negative.";
		ROLLBACK;
	END IF;
	
	IF ((SELECT balance FROM accounts 
		  WHERE id = source_account_id) < money_amount)
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "Not enough money in the source account.";
		ROLLBACK;
	END IF;
		  								  
	UPDATE accounts
	SET balance = balance - money_amount
	WHERE id = source_account_id;
	
	UPDATE accounts
	SET balance = balance + money_amount
	WHERE id = destination_account_id;
	
   COMMIT;
END //

-- Problem 16
CREATE TABLE IF NOT EXISTS accounts_logs(
id INT NOT NULL AUTO_INCREMENT,
account_id INT NOT NULL,
old_sum DOUBLE NOT NULL,
new_sum DOUBLE NOT NULL,
PRIMARY KEY(id)
);

DELIMITER //
DROP TRIGGER IF EXISTS tr_after_insert_accounts //

CREATE TRIGGER tr_after_insert_accounts
AFTER UPDATE
ON accounts
FOR EACH ROW
BEGIN
	INSERT INTO accounts_logs(account_id, old_sum, new_sum)
	 VALUES(NEW.id, OLD.balance, NEW.balance);
END //

-- Problem 17 
CREATE TABLE IF NOT EXISTS notification_emails(
id INT NOT NULL AUTO_INCREMENT,
recipient INT NOT NULL,
subject VARCHAR(225) NOT NULL,
body VARCHAR(225) NOT NULL,
PRIMARY KEY(id),
FOREIGN KEY(recipient) REFERENCES accounts(id)
);

DELIMITER //

DROP TRIGGER IF EXISTS tr_insert_logs //

CREATE TRIGGER tr_insert_logs
AFTER INSERT
ON `logs`
FOR EACH ROW
BEGIN
	INSERT INTO notification_emails(recipient, subject, body)
	 VALUES(NEW.account_id
	 		 ,CONCAT('Balance change for account: ', NEW.account_id)
			 ,CONCAT('On ', NOW(), 'your balance was changed from ', NEW.old_sum, ' to ', NEW.new_sum, '.'));
END //

-- Problem 20
SELECT SUBSTR(email, LOCATE('@', email) + 1) AS email_provider
 	   ,COUNT(*) AS number_of_users
FROM users
GROUP BY email_provider 
ORDER BY COUNT(*) DESC, email_provider;

-- Problem 21
SELECT g.name AS game
		,gt.name AS game_type
		,u.user_name AS username
		,ug.`level` 
		,ug.cash
		,c.name AS `character`
FROM games AS g
	JOIN game_types AS gt ON g.game_type_id = gt.id
	JOIN users_games AS ug ON g.id = ug.game_id
	JOIN characters AS c ON c.id = ug.character_id
	JOIN users AS u ON ug.user_id = u.id
ORDER BY ug.`level` DESC, username, game

-- Problem 22
SELECT u.user_name
	   ,g.name AS game
	   ,COUNT(i.id) AS items_count
	   ,SUM(i.Price) AS items_price
FROM users AS u
	JOIN users_games AS ug ON u.id = ug.user_id
	JOIN games AS g ON ug.game_id = g.id
	JOIN user_game_items AS ugi ON ugi.user_game_id = ug.id
	JOIN items AS i ON ugi.item_id = i.id
GROUP BY u.user_name, game
HAVING COUNT(i.Id) >= 10
ORDER BY COUNT(i.Id) DESC, SUM(i.Price) DESC, u.user_name;

-- Problem 23
select u.user_name 
		,g.name AS game 
		,MAX(c.name) AS `character`
		,SUM(its.strength) + MAX(gts.strength) + MAX(cs.strength) AS  strength
		,SUM(its.defence) + MAX(gts.defence) + MAX(cs.defence) AS defence
		,SUM(its.speed) + MAX(gts.speed) + MAX(cs.speed) as speed
		,SUM(its.mind) + MAX(gts.mind) + MAX(cs.mind) as mind
		,SUM(its.luck) + MAX(gts.luck) + MAX(cs.luck) as luck
FROM users AS u
	JOIN users_games AS ug ON ug.user_id = u.id
	JOIN games AS g ON ug.game_id = g.id
	JOIN game_types AS gt ON gt.id = g.game_type_id
	JOIN statistics AS gts ON gts.id = gt.bonus_stats_id
	JOIN characters AS c ON ug.character_id = c.id
	JOIN statistics AS cs ON cs.id = c.statistics_id
	JOIN user_game_items AS ugi ON ugi.user_game_id = ug.id
	JOIN items AS i ON i.id = ugi.item_id
	JOIN statistics AS its ON its.id = i.statistics_id
GROUP BY u.user_name, g.name
ORDER BY strength DESC, defence DESC, speed DESC, mind DESC, luck DESC;

-- Problem 24
select 
	i.name, 
	i.price, 
	i.min_level,
	s.strength,
	s.defence,
	s.speed,
	s.luck,
	s.mind
FROM items AS i
JOIN statistics AS s ON s.id = i.statistics_id
WHERE s.mind > (SELECT AVG(s.Mind) FROM Items i 
					 JOIN statistics AS s ON s.id = i.statistics_id) 
	AND s.luck > (SELECT AVG(s.Luck) FROM items AS i 
					  JOIN statistics AS s ON s.id = i.statistics_id) 
	AND s.speed > (SELECT AVG(s.Speed) FROM Items i 
						JOIN statistics AS s ON s.id = i.statistics_id) 
ORDER BY i.name;

-- Problem 25
SELECT i.name AS item
		,price	
		,min_level
		,gt.name AS forbidden_game_type
from items AS i
LEFT JOIN game_type_forbidden_items gtf ON gtf.item_id = i.id
LEFT JOIN game_types gt ON gt.id = gtf.game_type_id
ORDER BY forbidden_game_type DESC, item;

-- Problem 27
SELECT peak_name
		,mountain_range AS mountain
  		,elevation
FROM peaks AS p 
  JOIN mountains AS m ON p.mountain_id = m.id
ORDER BY elevation DESC, peak_name;

-- Problem 28
SELECT p.peak_name
		,mountain_range AS Mountain
		,c.country_name
		,cn.continent_name
FROM peaks AS p 
  JOIN mountains AS m ON p.mountain_id = m.id
  JOIN mountains_countries AS mc ON m.id = mc.mountain_id
  JOIN countries AS c ON c.country_code = mc.country_code
  JOIN continents AS cn ON cn.continent_code = c.continent_code
ORDER BY p.peak_name, c.country_name;

-- Problem 29
SELECT c.country_name
		,ct.continent_name
  		,COUNT(r.river_name) AS rivers_count
	   ,IFNULL(SUM(r.`length`), 0) AS total_length
FROM countries AS c
  LEFT JOIN continents AS ct ON ct.continent_code = c.continent_code
  LEFT JOIN countries_rivers AS cr ON c.country_code = cr.country_code
  LEFT JOIN rivers AS r ON r.id = cr.river_id
GROUP BY c.country_name, ct.continent_name
ORDER BY rivers_count DESC, total_length DESC, c.country_name;

-- Problem 30
SELECT cur.currency_code
  		,MIN(cur.description) AS currency
  		,COUNT(c.country_name) AS number_of_countries
FROM currencies AS cur
  LEFT JOIN Countries AS c ON cur.currency_code = c.currency_code
GROUP BY cur.currency_code
ORDER BY number_of_countries DESC, currency ASC;

-- Problem 31
SELECT c.continent_name
		,SUM(ct.area_in_sq_km) AS countries_area
		,SUM(ct.population) AS countries_population
FROM continents AS c
	LEFT JOIN countries AS ct ON ct.continent_code = c.continent_code
GROUP BY c.continent_name
ORDER BY countries_population DESC;

-- Problem 32
CREATE TABLE monasteries(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(225) NOT NULL,
country_code VARCHAR(225) NOT NULL,
PRIMARY KEY(id),
FOREIGN KEY (country_code) REFERENCES countries(country_code)
);

INSERT INTO monasteries(name, country_code) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR');

ALTER TABLE countries 
ADD COLUMN is_deleted TINYINT(1) DEFAULT 0;

UPDATE countries AS c
SET c.is_deleted = 1
WHERE c.country_code IN (SELECT cr.country_code
							  	 FROM countries_rivers AS cr
								  JOIN rivers AS r ON r.id = cr.river_id
								 WHERE cr.country_code = c.country_code
							    GROUP BY c.country_code
							    HAVING COUNT(r.id) > 3);
							    
SELECT m.name, c.country_name
FROM countries AS c
	JOIN monasteries AS m ON m.country_code = c.country_code
WHERE c.is_deleted = 0
ORDER BY m.name;

-- Problem 33
UPDATE countries
SET country_name = 'Burma'
WHERE country_name = 'Myanmar';

INSERT INTO monasteries(name, country_code) VALUES
('Hanga Abbey', (SELECT country_code FROM countries WHERE country_name = 'Tanzania'));
INSERT INTO monasteries(name, country_code) VALUES
('Myin-Tin-Daik', (SELECT country_code FROM countries WHERE country_name = 'Maynmar'));

SELECT ct.continent_name
		,c.country_name
		,COUNT(m.id) AS monasteries_count
FROM continents ct
  LEFT JOIN countries c ON ct.continent_code = c.continent_code
  LEFT JOIN monasteries m ON m.country_code = c.country_code
WHERE c.is_deleted = 0
GROUP BY ct.continent_name, c.country_name
ORDER BY monasteries_count DESC, c.country_name;