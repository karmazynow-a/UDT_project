--PUNKT1 tworzenie bazy danych
--CREATE DATABASE projektUDT
--GO

--PUNKT2 tworzenie tabel
USE projektUDT
GO

--tworzenie tabel
create table Kolo ( kolo dbo.Kolo);
create table Trojkat ( trojkat dbo.Trojkat);
create table Prostokat ( prostokat dbo.Prostokat);
create table Kwadrat ( kwadrat dbo.Kwadrat);
create table Rownoleglobok ( rownoleglobok dbo.Rownoleglobok);
create table Trapez ( trapez dbo.Trapez);

--skrypt do usuwania tabel - nie u¿ywaj go jeœli nie chcesz ich usun¹æ
--drop table Kolo;
--drop table Trojkat;
--drop table Prostokat;
--drop table Kwadrat;
--drop table Rownoleglobok;
--drop table Trapez;

--tworzenie potrzebnych funkcji
--funkcja pobieraj¹ca pola wszystkich figur
IF OBJECT_ID('getAllAreas') IS NOT NULL
	DROP FUNCTION getAllAreas
GO
CREATE FUNCTION getAllAreas() RETURNS @TempTable TABLE ( opis varchar(100), pole float)
AS
BEGIN
	INSERT INTO @TempTable SELECT kolo.ToString(), kolo.Pole() FROM Kolo
	INSERT INTO @TempTable SELECT trojkat.ToString(), trojkat.Pole() FROM Trojkat
	INSERT INTO @TempTable SELECT prostokat.ToString(), prostokat.Pole() FROM Prostokat
	INSERT INTO @TempTable SELECT kwadrat.ToString(), kwadrat.Pole() FROM Kwadrat
	INSERT INTO @TempTable SELECT rownoleglobok.ToString(), rownoleglobok.Pole() FROM Rownoleglobok
	INSERT INTO @TempTable SELECT trapez.ToString(), trapez.Pole() FROM Trapez
	RETURN  
END
GO

--funkcja pobieraj¹ca obwody wszystkich figur
IF OBJECT_ID('getAllCircuit') IS NOT NULL
	DROP FUNCTION getAllCircuit
GO
CREATE FUNCTION getAllCircuit() RETURNS @TempTable TABLE ( opis varchar(100), obw float)
AS
BEGIN
	INSERT INTO @TempTable SELECT kolo.ToString(), kolo.Obwod() FROM Kolo
	INSERT INTO @TempTable SELECT trojkat.ToString(), trojkat.Obwod() FROM Trojkat
	INSERT INTO @TempTable SELECT prostokat.ToString(), prostokat.Obwod() FROM Prostokat
	INSERT INTO @TempTable SELECT kwadrat.ToString(), kwadrat.Obwod() FROM Kwadrat
	INSERT INTO @TempTable SELECT rownoleglobok.ToString(), rownoleglobok.Obwod() FROM Rownoleglobok
	INSERT INTO @TempTable SELECT trapez.ToString(), trapez.Obwod() FROM Trapez
	RETURN  
END
GO