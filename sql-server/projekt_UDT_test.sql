USE projektUDT
GO

--TEST KOLO
create table test_kolo ( kolo dbo.Kolo);
insert into test_kolo (kolo) values ('2 5,6 7'), ('1, -5, 7,9');
--nieprawid³owe dane
--insert into test_kolo (kolo) values ('-1 2 3'); --b³êdny promieñ
--insert into test_kolo (kolo) values ('1 2.7 3'); --b³êdny format
select kolo.ToString() as kolo from test_kolo;
select kolo.Pole() as pole from test_kolo;
select kolo.Obwod() as pole from test_kolo;
select kolo.CzyPunktNalezyDoKola(5.6, 6) as punkt from test_kolo;
drop table test_kolo;

--TEST TROJKAT
create table test_troj ( complexField dbo.Trojkat);
insert into test_troj (complexField) values ('2 5,6 7 7 8,9 1'), ('1, -5, 7,9 8,9 1 5');
--nieprawid³owe dane
--insert into test_troj (complexField) values ('1, 1, 2, 2, 2, 2');
select complexField.ToString() as trojkaty from test_troj;
select complexField.Pole() as pole from test_troj;
select complexField.Obwod() as pole from test_troj;
select complexField.DlugosciBokow() as boki from test_troj;
drop table test_troj;


--TEST PROSTOKAT
create table test ( complexField dbo.Prostokat);
insert into test (complexField) values ('2 -8 7,8 -8 7,8 6 2 6');
--nieprawid³owe dane
--insert into test_troj (complexField) values ('1, -5, 6, 7, 8, 9, 3, 4');
select complexField.ToString() as figury from test;
select complexField.Pole() as pole from test;
select complexField.Obwod() as pole from test;
drop table test;

--TEST TRAPEZ
create table test ( complexField dbo.Trapez);
insert into test (complexField) values ('0 0 7 0 5 4 2 4');
--nieprawid³owe dane
--insert into test_troj (complexField) values ('2 -8 7,8 -8 7,8 6 2 6');
select complexField.ToString() as figury from test;
select complexField.Pole() as pole from test;
drop table test;

--TEST ROWNOLEGLOBOK
create table test ( complexField dbo.Rownoleglobok);
insert into test (complexField) values ('0 0 5 0 7 4 2 4');
--nieprawid³owe dane
--insert into test_troj (complexField) values ('0 0 7 0 5 4 2 4');
select complexField.ToString() as figury from test;
select complexField.Pole() as pole from test;
drop table test;

--TEST METOD
select * from getAllAreas();
select * from getAllCircuit();