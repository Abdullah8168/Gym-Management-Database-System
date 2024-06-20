create database Flex_Trainer_Management_System
use Flex_Trainer_Management_System

create table user_
(
u_id INT identity(1,1),
u_name varchar(50) NOT NULL,
u_membertype varchar(50),
u_membershipDate date NOT NULL,
u_email varchar(50) NOT NULL,
u_password varchar(50) NOT NULL,
u_address varchar(50),
PRIMARY KEY (u_id)
);
--
create table trainer
(
t_id INT identity(1,1),
t_name varchar(50) NOT NULL,
t_email varchar(50) NOT NULL,
t_password varchar(50) NOT NULL,
t_address varchar(50) ,
t_speciality varchar(50),
t_experience varchar(50),
t_qulification varchar(50),
PRIMARY KEY (t_id),
);
create table workoutplan
(
W_id INT identity(1,1),
W_purpose varchar(50) NOT NULL,
W_shedule varchar(50),
W_expLevel varchar(50) NOT NULL,
u_id INT NULL,
t_id INT NULL,
PRIMARY KEY(W_id),
FOREIGN KEY (u_id) REFERENCES user_(u_id), 
FOREIGN KEY (t_id) REFERENCES trainer(t_id),
);
create table dietplan
(
d_id INT identity(1,1),
d_type varchar(50) NOT NULL,
d_objective varchar(50) NOT NULL,
d_nutrition varchar(50) NOT NULL,
u_id INT NULL,
t_id INT NULL,
PRIMARY KEY (d_id),
FOREIGN KEY (u_id) REFERENCES user_(u_id),
FOREIGN KEY (t_id) REFERENCES trainer(t_id)
);
--
create table meal
(
ml_id INT identity(1,1),
ml_alergies varchar(50),
calories INT,
ml_nutrition varchar(50) NOT NULL,
ml_nutrition_quantity INT NOT NULL,
ml_type varchar(50) NOT NULL,
PRIMARY KEY (ml_id)
);
--
create table exercise
(
e_id INT identity(1,1),
e_day varchar(50) NOT NULL,
e_targetmuscle varchar(50),
e_reps INT,
e_restinterval INT,
e_sets INT,
PRIMARY KEY (e_id)
);
--
create table machinery
(
m_id INT identity (1,1),
m_manufacturer varchar(50),
m_discription varchar(50),
PRIMARY KEY (m_id)
);

create table R_EXERCISE_MACHINERY
(
r_id INT identity(1,1),
e_id INT,
m_id INT,
FOREIGN KEY(e_id) references exercise(e_id),
FOREIGN KEY(m_id) references machinery(m_id)
);
create table R_WORKOUTPLAN_EXERCISES
(
r_id INT identity(1,1),
e_id INT,
w_id INT,
FOREIGN KEY(e_id) references exercise(e_id),
FOREIGN KEY(w_id) references workoutplan(w_id)
);
create table R_DIETPLAN_MEAL
(
r_id INT identity(1,1),
d_id INT,
ml_id INT,
FOREIGN KEY(d_id) references dietplan(d_id),
FOREIGN KEY(ml_id) references meal(ml_id)
);

create table feedback
(
f_id INT identity (1,1),
f_ratings INT NOT NULL,
u_id INT,
t_id INT,
PRIMARY KEY (f_id),
FOREIGN KEY (u_id) REFERENCES user_(u_id),
FOREIGN KEY (t_id) REFERENCES trainer(t_id)
);

create table trainingsession
(
s_id INT identity (1,1),
s_discription varchar(50),
s_date date NOT NULL,
u_id INT,
t_id INT,
PRIMARY KEY (s_id),
FOREIGN KEY (u_id) REFERENCES user_(u_id),
FOREIGN KEY (t_id) REFERENCES trainer(t_id)
);
--
create table admin
(
a_id INT identity(1,1),
a_name varchar(50),
a_email varchar(50),
a_password varchar(50),
PRIMARY KEY (a_id)
);
create table owner
(
o_id INT identity(1,1),
o_name varchar(50),
o_email varchar(50),
o_password varchar(50),
o_address varchar(50),
PRIMARY KEY (o_id)
);
create table gym
(
g_id INT identity(1,1),
g_address varchar(50) NOT NULL,
g_name varchar(50) NOT NULL,
o_id INT,
a_id INT NULL,
PRIMARY KEY (g_id),
FOREIGN KEY (a_id) REFERENCES admin(a_id),
FOREIGN KEY (o_id) REFERENCES owner(o_id)
);

create table REQUEST_OWNER_ADMIN
(
r_id INT identity(1,1),
o_id INT,
g_id INT , 
PRIMARY KEY (r_id),
FOREIGN KEY (o_id) REFERENCES owner(o_id),
FOREIGN KEY (g_id) REFERENCES gym(g_id) 
);

create table REQUEST_TRAINER_OWNER
(
r_id INT identity(1,1),
g_id INT,
o_id INT,
t_id INT,
PRIMARY KEY (r_id),
FOREIGN KEY (t_id) REFERENCES trainer(t_id),
FOREIGN KEY (o_id) REFERENCES owner(o_id),
FOREIGN KEY (g_id) REFERENCES gym(g_id)
);

create table R_TRAINER_GYM
(
r_id INT identity(1,1),
g_id INT,
t_id INT,
FOREIGN KEY(g_id) REFERENCES gym(g_id),
FOREIGN KEY (t_id) REFERENCES trainer(t_id)
);

create table R_user_gym
(
r_id INT identity(1,1),
u_id INT,
g_id INT,
FOREIGN KEY(g_id) REFERENCES gym(g_id),
FOREIGN KEY (u_id) REFERENCES user_(u_id)
);

------------------------------------------------------------------------------------------------------------------

