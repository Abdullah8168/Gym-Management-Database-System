use Flex_Trainer_Management_System

INSERT INTO admin VALUES('a1','a1','a1');
INSERT INTO admin VALUES('a2','a2','a2');

INSERT INTO trainer (t_name, t_email, t_password, t_address, t_speciality, t_experience, t_qulification)
VALUES
('John Doe', 'john@example.com', 'password123', '123 Main St', 'Weightlifting', '5 years', 'Certified Personal Trainer'),
('Jane Smith', 'jane@example.com', 'pass1234', '456 Elm St', 'Yoga', '3 years', 'Certified Yoga Instructor'),
('Michael Johnson', 'michael@example.com', 'pass5678', '789 Oak St', 'CrossFit', '7 years', 'CrossFit Level 2 Trainer'),
('Emily Davis', 'emily@example.com', 'password', '101 Pine St', 'Pilates', '4 years', 'Certified Pilates Instructor'),
('David Brown', 'david@example.com', 'pass123', '202 Cedar St', 'Cardio', '6 years', 'Certified Cardio Trainer'),
('Sarah Wilson', 'sarah@example.com', 'password456', '303 Maple St', 'Strength Training', '5 years', 'Strength and Conditioning Specialist'),
('Matthew Taylor', 'matthew@example.com', 'pass789', '404 Walnut St', 'Functional Training', '4 years', 'Certified Functional Trainer'),
('Jessica Martinez', 'jessica@example.com', 'pass654', '505 Cherry St', 'HIIT', '3 years', 'Certified HIIT Instructor'),
('Andrew Anderson', 'andrew@example.com', 'password321', '606 Pineapple St', 'Zumba', '2 years', 'Certified Zumba Instructor'),
('Samantha White', 'samantha@example.com', 'pass7890', '707 Banana St', 'Kickboxing', '5 years', 'Certified Kickboxing Trainer'),
('Daniel Lee', 'daniel@example.com', 'passwordabc', '808 Orange St', 'Cycling', '4 years', 'Certified Cycling Instructor'),
('Ashley Harris', 'ashley@example.com', 'passxyz', '909 Grape St', 'Barre', '3 years', 'Certified Barre Instructor'),
('Christopher Moore', 'christopher@example.com', 'passworddef', '1010 Peach St', 'Martial Arts', '6 years', 'Martial Arts Instructor'),
('Amanda Clark', 'amanda@example.com', 'passuvw', '1111 Plum St', 'Aerobics', '4 years', 'Certified Aerobics Instructor'),
('Kevin Lewis', 'kevin@example.com', 'passwordijk', '1212 Kiwi St', 'Swimming', '5 years', 'Certified Swim Instructor'),
('Nicole Turner', 'nicole@example.com', 'passlmn', '1313 Mango St', 'Dance', '3 years', 'Certified Dance Instructor'),
('Ryan Parker', 'ryan@example.com', 'passwordopq', '1414 Coconut St', 'Bootcamp', '4 years', 'Certified Bootcamp Instructor'),
('Michelle Adams', 'michelle@example.com', 'passrst', '1515 Avocado St', 'Gymnastics', '6 years', 'Certified Gymnastics Instructor'),
('Jacob Scott', 'jacob@example.com', 'passwordxyz', '1616 Papaya St', 'Tai Chi', '3 years', 'Certified Tai Chi Instructor'),
('Stephanie Ward', 'stephanie@example.com', 'pass123456', '1717 Pineapple St', 'Pilates', '5 years', 'Certified Pilates Instructor');


INSERT INTO meal (ml_alergies, calories, ml_nutrition, ml_nutrition_quantity, ml_type)
VALUES
(NULL, 350, 'Proteins', 25, 'Breakfast'),
('Gluten', 450, 'Carbohydrates', 30, 'Breakfast'),
('Dairy', 500, 'Fats', 20, 'Breakfast'),
(NULL, 400, 'Fiber', 15, 'Breakfast'),
('Nuts', 300, 'Vitamins', 10, 'Breakfast'),
('Shellfish', 550, 'Proteins', 30, 'Lunch'),
('Soy', 600, 'Carbohydrates', 35, 'Lunch'),
(NULL, 500, 'Fats', 25, 'Lunch'),
('Dairy', 450, 'Fiber', 20, 'Lunch'),
(NULL, 400, 'Vitamins', 15, 'Lunch'),
('Gluten', 700, 'Proteins', 40, 'Dinner'),
('Dairy', 600, 'Carbohydrates', 45, 'Dinner'),
('Shellfish', 650, 'Fats', 30, 'Dinner'),
('Nuts', 550, 'Fiber', 25, 'Dinner'),
(NULL, 500, 'Vitamins', 20, 'Dinner'),
('Gluten', 400, 'Proteins', 20, 'Breakfast'),
(NULL, 450, 'Carbohydrates', 25, 'Breakfast'),
('Shellfish', 700, 'Fats', 35, 'Lunch'),
(NULL, 600, 'Fiber', 30, 'Dinner'),
('Nuts', 550, 'Vitamins', 15, 'Dinner');

INSERT INTO exercise (e_day, e_targetmuscle, e_reps, e_restinterval, e_sets)
VALUES
('Monday', 'Chest', 10, 60, 3),
('Tuesday', 'Back', 12, 45, 4),
('Wednesday', 'Legs', 15, 90, 3),
('Thursday', 'Shoulders', 12, 60, 4),
('Friday', 'Arms', 10, 60, 3),
('Saturday', 'Abs', 20, 30, 3),
('Sunday', 'Rest', NULL, NULL, NULL),
('Monday', 'Chest', 8, 60, 4),
('Tuesday', 'Back', 10, 45, 3),
('Wednesday', 'Legs', 12, 90, 4),
('Thursday', 'Shoulders', 10, 60, 3),
('Friday', 'Arms', 8, 60, 4),
('Saturday', 'Abs', 25, 30, 4),
('Sunday', 'Rest', NULL, NULL, NULL),
('Monday', 'Chest', 12, 60, 3),
('Tuesday', 'Back', 15, 45, 4),
('Wednesday', 'Legs', 20, 90, 3),
('Thursday', 'Shoulders', 15, 60, 4),
('Friday', 'Arms', 12, 60, 3),
('Saturday', 'Abs', 30, 30, 3);

INSERT INTO machinery (m_manufacturer, m_discription) VALUES
('Manufacturer A', 'Treadmill'),
('Manufacturer B', 'Elliptical Machine'),
('Manufacturer C', 'Stationary Bike'),
('Manufacturer D', 'Rowing Machine'),
('Manufacturer E', 'Leg Press Machine'),
('Manufacturer F', 'Smith Machine'),
('Manufacturer G', 'Cable Crossover Machine'),
('Manufacturer H', 'Lat Pulldown Machine'),
('Manufacturer I', 'Bench Press Machine'),
('Manufacturer J', 'Dumbbell Rack'),
('Manufacturer K', 'Barbell Rack'),
('Manufacturer L', 'Leg Curl Machine'),
('Manufacturer M', 'Leg Extension Machine'),
('Manufacturer N', 'Chest Press Machine'),
('Manufacturer O', 'Shoulder Press Machine'),
('Manufacturer P', 'Abdominal Crunch Machine'),
('Manufacturer Q', 'Tricep Extension Machine'),
('Manufacturer R', 'Bicep Curl Machine'),
('Manufacturer S', 'Seated Row Machine'),
('Manufacturer T', 'Calf Raise Machine');

INSERT INTO admin (a_name, a_email, a_password) VALUES
('Admin 1', 'admin1@example.com', 'password123'),
('Admin 2', 'admin2@example.com', 'password456'),
('Admin 3', 'admin3@example.com', 'password789'),
('Admin 4', 'admin4@example.com', 'passwordabc'),
('Admin 5', 'admin5@example.com', 'passworddef');

INSERT INTO owner (o_name, o_email, o_password, o_address) VALUES
('John Smith', 'johnsmith@example.com', 'password123', '123 Main St'),
('Emily Davis', 'emilydavis@example.com', 'password456', '456 Elm St'),
('Michael Johnson', 'michaeljohnson@example.com', 'password789', '789 Oak St'),
('Sarah Wilson', 'sarahwilson@example.com', 'passwordabc', '101 Pine St'),
('David Brown', 'davidbrown@example.com', 'passworddef', '202 Cedar St'),
('Jessica Martinez', 'jessicamartinez@example.com', 'password1234', '303 Maple St'),
('Andrew Anderson', 'andrewanderson@example.com', 'password5678', '404 Walnut St'),
('Ashley Harris', 'ashleyharris@example.com', 'password91011', '505 Cherry St'),
('Matthew Taylor', 'matthewtaylor@example.com', 'password121314', '606 Pineapple St'),
('Nicole Turner', 'nicoleturner@example.com', 'password151617', '707 Banana St'),
('Daniel Lee', 'daniellee@example.com', 'password181920', '808 Orange St'),
('Amanda Clark', 'amandaclark@example.com', 'password212223', '909 Grape St'),
('Kevin Lewis', 'kevinlewis@example.com', 'password242526', '1010 Peach St'),
('Stephanie Ward', 'stephanieward@example.com', 'password272829', '1111 Plum St'),
('Jacob Scott', 'jacobscott@example.com', 'password303132', '1212 Kiwi St'),
('Michelle Adams', 'michelleadams@example.com', 'password333435', '1313 Mango St'),
('Ryan Parker', 'ryanparker@example.com', 'password363738', '1414 Coconut St'),
('Christopher Moore', 'christophermoore@example.com', 'password394041', '1515 Avocado St'),
('Samantha White', 'samanthawhite@example.com', 'password424344', '1616 Papaya St'),
('Taylor Hall', 'taylorhall@example.com', 'password454647', '1717 Pineapple St');


INSERT INTO gym (g_address, g_name, o_id, a_id) VALUES
('123 Main St', 'Fitness First', 1, 1),
('456 Elm St', 'Gym Plus', 2, 2),
('789 Oak St', 'Fit Life', 3, 3),
('101 Pine St', 'Health Haven', 4, 4),
('202 Cedar St', 'Powerhouse Gym', 5, 5),
('303 Maple St', 'Flex Fitness', 6, 1),
('404 Walnut St', 'Iron Gym', 7, 2),
('505 Cherry St', 'Sweat Studio', 8, 3),
('606 Pineapple St', 'Muscle House', 9, 4),
('707 Banana St', 'Body Boost', 10, 5),
('808 Orange St', 'Core Fitness', 11, 1),
('909 Grape St', 'Peak Performance', 12, 2),
('1010 Peach St', 'Endurance Zone', 13, 3),
('1111 Plum St', 'Strength Center', 14, 4),
('1212 Kiwi St', 'Fitness Fusion', 15, 5),
('1313 Mango St', 'Fit Zone', 16, 1),
('1414 Coconut St', 'Shape Up', 17, 2),
('1515 Avocado St', 'Workout World', 18, 3),
('1616 Papaya St', 'Fitness Focus', 19, 4),
('1717 Pineapple St', 'Gym Zone', 20, 5);
