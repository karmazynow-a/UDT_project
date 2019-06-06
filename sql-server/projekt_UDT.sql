use testCLR
GO

----TEST KOLO
--create table test_kolo ( kolo dbo.Kolo);
--insert into test_kolo (kolo) values ('2 5,6 7'), ('1, -5, 7,9');
--select kolo.ToString() as kolo from test_kolo;
--select kolo.Pole() as pole from test_kolo;
--select kolo.CzyPunktNalezyDoKola(5.6, 6) as punkt from test_kolo;
--drop table test_kolo;

----TEST TROJKAT
--create table test_troj ( complexField dbo.Trojkat);
--insert into test_troj (complexField) values ('2 5,6 7 7 8,9 1'), ('1, -5, 7,9 8,9 1 5');
----invalid data
----insert into test_troj (complexField) values ('1, 1, 2, 2, 2, 2');
--select complexField.ToString() as trojkaty from test_troj;
--select complexField.Pole() as pole from test_troj;
--select complexField.DlugosciBokow() as boki from test_troj;
--drop table test_troj;


----TEST PROSTOKAT
--create table test ( complexField dbo.Prostokat);
--insert into test (complexField) values ('2 -8 7,8 -8 7,8 6 2 6');
----invalid data
----insert into test_troj (complexField) values ('1, -5, 6, 7, 8, 9, 3, 4');
--select complexField.ToString() as figury from test;
--select complexField.Pole() as pole from test;
--select complexField.DlugosciBokow() as boki from test;
--drop table test;

--TABELE
--create table Kolo ( kolo dbo.Kolo);
--create table Trojkat ( trojkat dbo.Trojkat);
--create table Prostokat ( prostokat dbo.Prostokat);
--create table Kwadrat ( kwadrat dbo.Kwadrat);
--create table Rownoleglobok ( rownoleglobok dbo.Rownoleglobok);
--create table Trapez ( trapez dbo.Trapez);

--drop table Kolo;
--drop table Trojkat;
--drop table Prostokat;
--drop table Kwadrat;
--drop table Rownoleglobok;
--drop table Trapez;

--get areas of all figures
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

--get circuits of all figures
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

--select * from getAllAreas()