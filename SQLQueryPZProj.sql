/*1*/--CREATE DATABASE Baza_PZ

/*2*/--use Baza_PZ


/*3*//*
CREATE TABLE ProfileTable 
( nick varchar(30)primary key,
imie varchar(30),
 nazwisko varchar(30),
  funkcja varchar(30),
  Sstatus bit,
  zdjecie image
  );*/
  
  -- drop table Timetable;
  
  
  /*4*//*
  CREATE TABLE TimeTable
 (id int primary key not null IDENTITY,
  nick varchar(30)  foreign key references ProfileTable(nick),
  czasIN smalldatetime,
  czasOUT smalldatetime  );*/
  --create login Usr with password = 'pass', default_database = Baza_PZ;


--CREATE USER Usr   from LOGIN Usr;
