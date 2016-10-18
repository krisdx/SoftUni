-- Section 1: DDL
CREATE TABLE flights(
flight_id INT NOT NULL DEFAULT 1,
departure_time DATETIME NOT NULL,
arrival_time DATETIME NOT NULL,
`status` VARCHAR(9),
origin_airport_id INT,
destination_airport_id INT,
airline_id INT,
PRIMARY KEY(flight_id),
FOREIGN KEY(origin_airport_id) REFERENCES airports(airport_id),
FOREIGN KEY(destination_airport_id) REFERENCES airports(airport_id),
FOREIGN KEY(airline_id) REFERENCES airlines(airline_id)
);

CREATE TABLE tickets(
ticket_id INT NOT NULL DEFAULT 1,
price DECIMAL(8, 2) NOT NULL,
class VARCHAR(6),
seat VARCHAR(5) NOT NULL,
customer_id INT DEFAULT 1,
flight_id INT DEFAULT 1,
PRIMARY KEY(ticket_id),
FOREIGN KEY(customer_id) REFERENCES customers(customer_id),
FOREIGN KEY(flight_id) REFERENCES flights(flight_id)
);

-- Section 2: DML - 01. Data Insertion
INSERT INTO flights
	(flight_id, departure_time, arrival_time, status, origin_airport_id, destination_airport_id, airline_id)
VALUES 
	(1, STR_TO_DATE('2016-10-13 06:00 AM', '%Y-%m-%d %h:%i %p'),
		 STR_TO_DATE('2016-10-13 10:00 AM', '%Y-%m-%d %h:%i %p'), 'Delayed', 1, 4, 1),
	(2, STR_TO_DATE('2016-10-12 12:00 PM', '%Y-%m-%d %h:%i %p'),
			STR_TO_DATE('2016-10-12 12:01 PM', '%Y-%m-%d %h:%i %p'),	'Departing', 1, 3, 2),
	(3, STR_TO_DATE('2016-10-14 03:00 PM', '%Y-%m-%d %h:%i %p'), 
		 STR_TO_DATE('2016-10-20 04:00 AM', '%Y-%m-%d %h:%i %p'), 'Delayed', 4, 2,	4),
	(4, STR_TO_DATE('2016-10-12 01:24 PM', '%Y-%m-%d %h:%i %p'), 
		 STR_TO_DATE('2016-10-12 4:31 PM', '%Y-%m-%d %h:%i %p'), 'Departing', 3, 1, 3),
	(5, STR_TO_DATE('2016-10-12 08:11 AM', '%Y-%m-%d %h:%i %p'),
		 STR_TO_DATE('2016-10-12 11:22 PM', '%Y-%m-%d %h:%i %p'), 'Departing',	4,	1,	1),
	(6, STR_TO_DATE('1995-06-21 12:30 PM', '%Y-%m-%d %h:%i %p'),
	    STR_TO_DATE('1995-06-22 08:30 PM', '%Y-%m-%d %h:%i %p'), 'Arrived',	2,	3,	5),
	(7, STR_TO_DATE('2016-10-12 11:34 PM', '%Y-%m-%d %h:%i %p'),
		 STR_TO_DATE('2016-10-13 03:00 AM', '%Y-%m-%d %h:%i %p'), 'Departing', 2, 4, 2),
	(8, STR_TO_DATE('2016-11-11 01:00 PM', '%Y-%m-%d %h:%i %p'),
		 STR_TO_DATE('2016-11-12 10:00 PM', '%Y-%m-%d %h:%i %p'), 'Delayed',	4,	3,	1),
	(9, STR_TO_DATE('2015-10-01 12:00 PM', '%Y-%m-%d %h:%i %p'),
		 STR_TO_DATE('2015-12-01 01:00 AM', '%Y-%m-%d %h:%i %p'), 'Arrived',	1,	2,	1),
	(10, STR_TO_DATE('2016-10-12 07:30 PM', '%Y-%m-%d %h:%i %p'), 
		  STR_TO_DATE('2016-10-13 12:30 PM', '%Y-%m-%d %h:%i %p'), 'Departing',	2,	1,	7);

-- Section 2: DML - 02. Update Flights
UPDATE flights
SET airline_id = 1
WHERE `status` = 'Arrived';

-- Section 2: DML - 03. Update Tickets
UPDATE tickets AS t 
    JOIN flights AS f ON t.flight_id = f.flight_id 
    JOIN airlines AS a ON a.airline_id = f.airline_id
SET t.price = t.price + (t.price / 2)
WHERE a.rating = (SELECT MAX(rating) FROM airlines);

-- Section 2: DML - 04. Table Creation
CREATE TABLE customer_reviews(
review_id INT NOT NULL,
review_content VARCHAR(225) NOT NULL,
review_grade TINYINT,
airline_id INT DEFAULT 1,
customer_id INT DEFAULT 1,
PRIMARY KEY(review_id),
FOREIGN KEY(airline_id) REFERENCES airlines(airline_id),
FOREIGN KEY(customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE customer_bank_accounts(
account_id INT NOT NULL DEFAULT 1,
account_number VARCHAR(10) NOT NULL UNIQUE,
balance DECIMAL(10, 2) NOT NULL,
customer_id INT DEFAULT 1,
PRIMARY KEY(account_id),
FOREIGN KEY(customer_id) REFERENCES customers(customer_id)
);
	
-- Section 2: DML - 05. Fillin New Tables
INSERT INTO	customer_reviews 
VALUES(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
(2,	'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
(3,	'Meh...', 5, 4, 3),
(4,	"Well I've seen better, but I've certainly seen a lot worse...", 7,	3, 5);

INSERT INTO customer_bank_accounts
VALUES(1, '123456790', 2569.23, 1),
(2,	'18ABC23672', 14004568.23, 2),
(3,	'F0RG0100N3', 19345.20, 5);

-- Section 3: Querying - 01. Extract All Tickets
SELECT ticket_id, price, class, seat
FROM tickets
ORDER BY ticket_id;

-- Section 3: Querying - 02. Extract All Customers
SELECT customer_id, CONCAT(first_name, ' ', last_name) AS full_name, gender
FROM customers
ORDER BY full_name, customer_id

-- Section 3: Querying - 03. Extract Delayed Flights
SELECT flight_id, departure_time, arrival_time
FROM flights
WHERE `status` = 'Delayed'
ORDER BY flight_id;

-- Section 3: Querying - 04. Top 5 Airlines
SELECT a.airline_id	,airline_name ,nationality, rating
FROM airlines AS a
WHERE a.airline_id IN (SELECT airline_id FROM flights)
ORDER BY rating DESC, airline_id
LIMIT 5;

-- Section 3: Querying - 05. All Tickets Below 5000
SELECT ticket_id
	  ,a.airport_name AS destination	
	  ,CONCAT(first_name, ' ', last_name) AS customer_name
FROM tickets AS t
	JOIN flights as f ON t.flight_id = f.flight_id
	JOIN airports AS a ON f.airline_id = a.airline_id
	JOIN customers AS c ON c.customer_id = t.customer_id
WHERE t.price < 5000 AND t.class = 'First';

-- Section 3: Querying - 06. Customers From Home
SELECT c.customer_id
	  ,CONCAT(first_name, ' ', last_name) AS customer_name
	  ,t.town_name AS home_town
FROM customers AS c
	JOIN towns AS t ON c.home_town_id = t.town_id
	JOIN tickets AS tic ON tic.customer_id = c.customer_id -- left join ?
	JOIN flights AS f ON tic.flight_id = f.flight_id
	JOIN airports AS a ON a.airport_id = f.origin_airport_id
	JOIN towns AS t1 ON a.town_id = t1.town_id
WHERE t.town_id = t1.town_id
GROUP BY c.customer_id
ORDER BY c.customer_id;

-- Section 3: Querying - 07. Customers who will fly
SELECT c.customer_id
	   ,CONCAT(first_name, ' ', last_name) AS customer_name
	   ,2016 - YEAR(c.date_of_birth) AS age
FROM customers AS c
	JOIN tickets AS t ON c.customer_id = t.customer_id
	JOIN flights AS f ON f.flight_id = t.flight_id
WHERE `status` = 'Departing'
GROUP BY c.customer_id
ORDER BY age, c.customer_id;

-- Section 3: Querying - 08. Top 3 Customers Delayed
SELECT c.customer_id
	   ,CONCAT(first_name, ' ', last_name) AS customer_name
	   ,t.price
	   ,a.airport_name
FROM customers AS c
	JOIN tickets AS t ON c.customer_id = t.customer_id
	JOIN flights AS f ON f.flight_id = t.flight_id
	JOIN airports AS a ON f.destination_airport_id = a.airport_id
WHERE `status` = 'Delayed'
GROUP BY c.customer_id
ORDER BY t.price DESC, c.customer_id
limit 3;

-- Section 3: Querying - 09. Last 5 Departing Flights
SELECT flight_id
	   ,departure_time
	   ,arrival_time
	   ,a.airport_name AS origin
	   ,a2.airport_name AS destination
FROM flights AS f
	JOIN airports AS a ON f.origin_airport_id = a.airport_id
	JOIN airports AS a2 ON f.destination_airport_id = a2.airport_id
WHERE `status` = 'Departing'
ORDER BY departure_time, flight_id
LIMIT 5;

-- Section 3: Querying - 10. Customers Below 21
SELECT c.customer_id
	   ,CONCAT(first_name, ' ', last_name) AS customer_name
	   ,2016 - YEAR(date_of_birth) AS age
FROM customers AS c
	JOIN tickets AS t ON c.customer_id = t.customer_id
	JOIN flights AS f ON f.flight_id = t.flight_id
	JOIN airports AS a ON f.destination_airport_id = a.airport_id
WHERE `status` = 'Arrived'
ORDER BY age DESC, c.customer_id

-- Section 3: Querying - 11. AIrports and Passengers
SELECT a.airport_id
	   ,a.airport_name
	   ,COUNT(c.customer_id)
FROM airports AS a
	JOIN flights AS f ON a.airport_id = f.origin_airport_id	 
	JOIN tickets AS t ON t.flight_id = f.flight_id
 	JOIN customers AS c ON c.customer_id = t.customer_id
WHERE `status` = 'Departing'
GROUP BY a.airport_id
ORDER BY a.airport_id;

-- Section 4: Programmibility - 01. Submit Review
CREATE PROCEDURE usp_submit_review(
	target_customer_id INT
   ,target_review_content VARCHAR(255)
   ,target_review_grade TINYINT
   ,target_airline_name VARCHAR(225))
BEGIN 
	DECLARE target_airline_id INT DEFAULT -1;
	SET target_airline_id = (SELECT airline_id FROM airlines 
									 WHERE airline_name = target_airline_name);
									 
	IF (target_airline_id = -1)
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "Airline does not exist.";
	ELSE 
		INSERT INTO customer_reviews(review_content, review_grade, airline_id, customer_id)
		 VALUES(target_review_content, target_review_grade, target_airline_id, target_customer_id);
	END IF;
END

-- Section 4: Programmibility - 02. Ticket Purchase
CREATE PROCEDURE usp_purchase_ticket(
	 target_customer_id INT
	,target_flight_id INT
	,target_ticket_price DECIMAL(8, 2)
	,target_class VARCHAR(225)
	,target_seat VARCHAR(225)) 
usp_purchase_ticket_label: BEGIN 
	
	DECLARE customer_balance DECIMAL(10, 2);
	SET customer_balance = (SELECT balance FROM customer_bank_accounts
							WHERE customer_id = target_customer_id);
								
	IF(customer_balance < target_ticket_price)
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "Insufficient bank account balance for ticket purchase.";
		LEAVE usp_purchase_ticket_label;
	END IF;
	
	UPDATE customer_bank_accounts
	SET balance = balance - target_ticket_price
	WHERE customer_id = target_customer_id;
	
	INSERT INTO tickets(price, class, seat, customer_id, flight_id)
	 VALUES(target_ticket_price, target_class, target_seat, target_customer_id, target_flight_id);
END

-- BONUS Section 5: Update Trigger
CREATE TRIGGER tr_after_update_flights
AFTER UPDATE
ON flights
FOR EACH ROW
BEGIN
		DECLARE origin_name VARCHAR(225);
		DECLARE destination_name VARCHAR(225);
		DECLARE passengers_count INT;
		
		SET origin_name = (SELECT a.airport_name FROM flights AS f
									JOIN airports AS a ON NEW.origin_airport_id = a.airport_id
								 WHERE f.flight_id = NEW.flight_id);
	
		SET destination_name = (SELECT a.airport_name FROM flights AS f
											JOIN airports AS a ON NEW.destination_airport_id = a.airport_id
										WHERE f.flight_id = NEW.flight_id);
	
		SET passengers_count = (SELECT COUNT(t.customer_id)
										FROM flights AS f
											JOIN tickets AS t on t.flight_id = f.flight_id
										WHERE f.flight_id = NEW.flight_id);	
	
		INSERT INTO arrived_flights(flight_id, arrival_time, origin, destination, passengers)
		 VALUES(NEW.flight_id, NEW.arrival_time, origin_name, destination_name, passengers_count);
END