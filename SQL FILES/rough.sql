use Flex_Trainer_Management_System

INSERT INTO user_ VALUES('Ali','premium',getdate(),'i22@gmail.com','1234','B-17');

SELECT * FROM user_

DELETE FROM user_
WHERE u_id = 1 OR u_id=2 OR u_id=3;

SELECT TOP 1 u_id from user_ ORDER BY u_id DESC
DELETE FROM R_user_gym
where u_id=2

DBCC CHECKIDENT ('dietplan', RESEED, 0);
DBCC CHECKIDENT ('workoutplan', RESEED, 0);
DBCC CHECKIDENT ('user_', RESEED, 0);
DBCC CHECKIDENT ('meal',RESEED,0);
DBCC CHECKIDENT ('exercise',RESEED,0);
DBCC CHECKIDENT ('gym',RESEED,0);
DBCC CHECKIDENT ('owner',RESEED,0);
DBCC CHECKIDENT ('request_owner_admin',RESEED,0);
INSERT INTO owner Values ('Ali','123@','1234','Islamabad');
select * from owner
select * from R_user_gym
select * from gym
select * from user_
INSERT INTO admin Values ('Ali','123@','1234');

INSERT INTO gym VALUES('gym2','h11',1,NULL);
INSERT INTO gym  VALUES('abc','helo',1,NULL);

select * from gym
INSERT INTO DIETPLAN VALUES('a','a','a');

-- DELETE VAUES OF TABLE
Delete from user_
Delete from workoutplan
DeLETE from dietplan
DELETE from R_workoutplan_exercises
DELETE from R_dietplan_meal
Delete from r_user_gym
Delete from meal
Delete from exercise
Delete from gym
delete from trainingsession
delete from request_trainer_owner
DELETE from request_owner_admin
DELETE FROM r_trainer_gym
DELETE FROM r_user_gym
--View tables
select * from R_USER_GYM
select * from Request_owner_admin
select * from R_trainer_gym
select * from Request_trainer_owner
select * from gym
select * from owner
select * from admin
select * from trainingsession
select * from feedback
select * from r_dietplan_meal
select * from r_workoutplan_exercises
select * from r_exercice_machinery
select * from meal
select * from machinery
select * from exercise
select * from dietplan
select * from workoutplan
select * from trainer
select * from user_
--DELETE ALL TABLES
drop table R_USER_GYM
drop table Request_owner_admin
drop table R_trainer_gym
drop table Request_trainer_owner
drop table gym
drop table owner
drop table admin
drop table trainingsession
drop table feedback
drop table r_dietplan_meal
drop table r_workoutplan_exercises
drop table r_exercice_machinery
drop table meal
drop table machinery
drop table exercise
drop table dietplan
drop table workoutplan
drop table trainer
drop table user_
--
select * from user_
SELECT count(*) from r_user_gym as r
INNER JOIN gym as g on r.g_id=g.g_id
INNER JOIN r_trainer_gym as t on g.g_id=t.g_id
WHERE r.u_id=2 AND t.t_id=6

SELECT g.g_id, g.g_name, g.g_address, g.o_id, COUNT(u.u_membertype) AS count
FROM gym g
INNER JOIN r_user_gym r ON g.g_id = r.g_id
INNER JOIN user_ u ON r.u_id = u.u_id
WHERE u.u_membertype = 'Premium'
GROUP BY g.g_id, g.g_name, g.g_address, g.o_id
ORDER BY count DESC;


--no of members

--no of premium memberships
EXEC sp_rename 'users', 'user_';
select * from user_

SELECT u.u_id, u.u_name, u.u_membertype, u.u_membershipDate, u.u_email, u.u_address
FROM user_ u
INNER JOIN R_user_gym r ON u.u_id = r.u_id
INNER JOIN gym g ON r.g_id = g.g_id
INNER JOIN R_TRAINER_GYM t ON g.g_id = t.g_id
INNER JOIN trainer tr ON t.t_id = tr.t_id
WHERE g.g_id = @gym_id
AND tr.t_id = @trainer_id;
SELECT g.g_id, g.g_name, COUNT(u.u_id) AS total_members
FROM gym g
LEFT JOIN R_user_gym r ON g.g_id = r.g_id
LEFT JOIN user_ u ON r.u_id = u.u_id
WHERE u.u_membershipDate >= DATEADD(MONTH, -6, GETDATE())
GROUP BY g.g_id, g.g_name;


