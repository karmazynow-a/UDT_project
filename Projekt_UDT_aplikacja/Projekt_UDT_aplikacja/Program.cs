/* TODO
 * za mało argumentów w parse - error że out of range - catch
 * add more figures
 * */

using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Projekt_UTD_aplikacja
{
    class Projekt_UDT_aplikacja
    {
        static Figure _currentFigure = Figure.Nieznana;

        static Dictionary<string, Command> _commands = new Dictionary<string, Command>();

        enum Figure
        {
            Nieznana,
            Kolo,
            Trojkat,
            Prostokat,
            Kwadrat,
            Trapez,
            Rownoleglobok,
            Wszystkie
        };

        private static void InitMap()
        {
            //init map
            _commands.Add("Kolo_get", new Command("select kolo.ToString() as kolo from Kolo;", Command.Type.Select, "", new List<string>() { "kolo" }));
            _commands.Add("Kolo_pole", new Command("select kolo.ToString() as kolo, kolo.Pole() as pole from Kolo;", Command.Type.Select, "", new List<string>() { "kolo", "pole" }));
            _commands.Add("Kolo_pole_sort", new Command("select kolo.ToString() as kolo, kolo.Pole() as pole from Kolo order by pole;", Command.Type.Select, "", new List<string>() { "kolo", "pole" }));
            _commands.Add("Kolo_pole_search", new Command("select kolo.ToString() as kolo, kolo.Pole() as pole FROM Kolo WHERE kolo.Pole() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "kolo", "pole" }));
            _commands.Add("Kolo_obw", new Command("select kolo.ToString() as kolo, kolo.Obwod() as obwod from Kolo;", Command.Type.Select, "", new List<string>() { "kolo", "obwod" }));
            _commands.Add("Kolo_obw_sort", new Command("select kolo.ToString() as kolo, kolo.Obwod() as obwod from Kolo order by obwod;", Command.Type.Select, "", new List<string>() { "kolo", "obwod" }));
            _commands.Add("Kolo_obw_search", new Command("select kolo.ToString() as kolo, kolo.Obwod() as obwod FROM Kolo WHERE kolo.Obwod() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "kolo", "obwod" }));
            _commands.Add("Kolo_add", new Command("insert into Kolo (kolo) values ", Command.Type.Insert, "Podaj promień oraz wspołrzędne", new List<string>() {}));

            _commands.Add("Trojkat_get", new Command("select trojkat.ToString() as trojkat from Trojkat;", Command.Type.Select, "", new List<string>() { "trojkat" }));
            _commands.Add("Trojkat_pole", new Command("select trojkat.ToString() as trojkat, trojkat.Pole() as pole from Trojkat;", Command.Type.Select, "", new List<string>() { "trojkat", "pole" }));
            _commands.Add("Trojkat_pole_sort", new Command("select trojkat.ToString() as trojkat, trojkat.Pole() as pole from Trojkat order by pole;", Command.Type.Select, "", new List<string>() { "trojkat", "pole" }));
            _commands.Add("Trojkat_pole_search", new Command("select trojkat.ToString() as trojkat, trojkat.Pole() as pole from Trojkat WHERE trojkat.Pole() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "trojkat", "pole" }));
            _commands.Add("Trojkat_obw", new Command("select trojkat.ToString() as trojkat, trojkat.Obwod() as obwod from Trojkat;", Command.Type.Select, "", new List<string>() { "trojkat", "obwod" }));
            _commands.Add("Trojkat_obw_sort", new Command("select trojkat.ToString() as trojkat, trojkat.Obwod() as obwod from Trojkat order by obwod;", Command.Type.Select, "", new List<string>() { "trojkat", "obwod" }));
            _commands.Add("Trojkat_obw_search", new Command("select trojkat.ToString() as trojkat, trojkat.Obwod() as obwod from Trojkat WHERE trojkat.Obwod() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "trojkat", "obwod" }));
            _commands.Add("Trojkat_add", new Command("insert into Trojkat (trojkat) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            _commands.Add("Prostokat_get", new Command("select prostokat.ToString() as prostokat from Prostokat;", Command.Type.Select, "", new List<string>() { "prostokat" }));
            _commands.Add("Prostokat_pole", new Command("select prostokat.ToString() as prostokat, prostokat.Pole() as pole from Prostokat;", Command.Type.Select, "", new List<string>() { "prostokat", "pole" }));
            _commands.Add("Prostokat_pole_sort", new Command("select prostokat.ToString() as prostokat, prostokat.Pole() as pole from Prostokat order by pole;", Command.Type.Select, "", new List<string>() { "prostokat", "pole" }));
            _commands.Add("Prostokat_pole_search", new Command("select prostokat.ToString() as prostokat, prostokat.Pole() as pole from Prostokat WHERE prostokat.Pole() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "prostokat", "pole" }));
            _commands.Add("Prostokat_obw", new Command("select prostokat.ToString() as prostokat, prostokat.Obwod() as obwod from Prostokat;", Command.Type.Select, "", new List<string>() { "prostokat", "obwod" }));
            _commands.Add("Prostokat_obw_sort", new Command("select prostokat.ToString() as prostokat, prostokat.Obwod() as obwod from Prostokat order by obwod;", Command.Type.Select, "", new List<string>() { "prostokat", "obwod" }));
            _commands.Add("Prostokat_obw_search", new Command("select prostokat.ToString() as prostokat, prostokat.Obwod() as obwod from Prostokat WHERE prostokat.Obwod()", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "prostokat", "obwod" }));
            _commands.Add("Prostokat_add", new Command("insert into Prostokat (prostokat) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            _commands.Add("Kwadrat_get", new Command("select kwadrat.ToString() as kwadrat from Kwadrat;", Command.Type.Select, "", new List<string>() { "kwadrat" }));
            _commands.Add("Kwadrat_pole", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Pole() as pole from Kwadrat;", Command.Type.Select, "", new List<string>() { "kwadrat", "pole" }));
            _commands.Add("Kwadrat_pole_sort", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Pole() as pole from Kwadrat order by pole;", Command.Type.Select, "", new List<string>() { "kwadrat", "pole" }));
            _commands.Add("Kwadrat_pole_search", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Pole() as pole from Kwadrat WHERE kwadrat.Pole() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "kwadrat", "pole" }));
            _commands.Add("Kwadrat_obw", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Obwod() as obwod from Kwadrat;", Command.Type.Select, "", new List<string>() { "kwadrat", "obwod" }));
            _commands.Add("Kwadrat_obw_sort", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Obwod() as obwod from Kwadrat order by obwod;", Command.Type.Select, "", new List<string>() { "kwadrat", "obwod" }));
            _commands.Add("Kwadrat_obw_search", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Obwod() as obwod from Kwadrat WHERE kwadrat.Obwod() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "kwadrat", "obwod" }));
            _commands.Add("Kwadrat_add", new Command("insert into Kwadrat (kwadrat) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            _commands.Add("Rownoleglobok_get", new Command("select rownoleglobok.ToString() as rownoleglobok from Rownoleglobok;", Command.Type.Select, "", new List<string>() { "rownoleglobok" }));
            _commands.Add("Rownoleglobok_pole", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Pole() as pole from Rownoleglobok;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "pole" }));
            _commands.Add("Rownoleglobok_pole_sort", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Pole() as pole from Rownoleglobok order by pole;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "pole" }));
            _commands.Add("Rownoleglobok_pole_search", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Pole() as pole from Rownoleglobok WHERE rownoleglobok.Pole() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "rownoleglobok", "pole" }));
            _commands.Add("Rownoleglobok_obw", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Obwod() as obwod from Rownoleglobok;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "obwod" }));
            _commands.Add("Rownoleglobok_obw_sort", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Obwod() as obwod from Rownoleglobok order by obwod;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "obwod" }));
            _commands.Add("Rownoleglobok_obw_search", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Obwod() as obwod from Rownoleglobok WHERE rownoleglobok.Obwod()", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "rownoleglobok", "obwod" }));
            _commands.Add("Rownoleglobok_add", new Command("insert into Rownoleglobok (rownoleglobok) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            _commands.Add("Trapez_get", new Command("select trapez.ToString() as trapez from Trapez;", Command.Type.Select, "", new List<string>() { "trapez" }));
            _commands.Add("Trapez_pole", new Command("select trapez.ToString() as trapez, trapez.Pole() as pole from Trapez;", Command.Type.Select, "", new List<string>() { "trapez", "pole" }));
            _commands.Add("Trapez_pole_sort", new Command("select trapez.ToString() as trapez, trapez.Pole() as pole from Trapez order by pole;", Command.Type.Select, "", new List<string>() { "trapez", "pole" }));
            _commands.Add("Trapez_pole_search", new Command("select trapez.ToString() as trapez, trapez.Pole() as pole from Trapez WHERE trapez.Pole() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "trapez", "pole" }));
            _commands.Add("Trapez_obw", new Command("select trapez.ToString() as trapez, trapez.Obwod() as obwod from Trapez;", Command.Type.Select, "", new List<string>() { "trapez", "obwod" }));
            _commands.Add("Trapez_obw_sort", new Command("select trapez.ToString() as trapez, trapez.Obwod() as obwod from Trapez order by obwod;", Command.Type.Select, "", new List<string>() { "trapez", "obwod" }));
            _commands.Add("Trapez_obw_search", new Command("select trapez.ToString() as trapez, trapez.Obwod() as obwod from Trapez WHERE trapez.Obwod() ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "trapez", "obwod" }));
            _commands.Add("Trapez_add", new Command("insert into Trapez (trapez) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            _commands.Add("Wszystkie_get", new Command("select opis from getAllAreas()", Command.Type.Select, "", new List<string>() { "opis" }));
            _commands.Add("Wszystkie_pole", new Command("select * from getAllAreas()", Command.Type.Select, "", new List<string>() { "opis", "pole" }));
            _commands.Add("Wszystkie_pole_sort", new Command("select * from getAllAreas() order by pole", Command.Type.Select, "", new List<string>() { "opis", "pole" }));
            _commands.Add("Wszystkie_pole_search", new Command("select * from getAllAreas() WHERE pole ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "opis", "pole" }));
            _commands.Add("Wszystkie_obw", new Command("select * from getAllCircuit()", Command.Type.Select, "", new List<string>() { "opis", "obw" }));
            _commands.Add("Wszystkie_obw_sort", new Command("select * from getAllCircuit() order by obw", Command.Type.Select, "", new List<string>() { "opis", "obw" }));
            _commands.Add("Wszystkie_obw_search", new Command("select * from getAllCircuit() WHERE obw ", Command.Type.Search, "Podaj warunek (np > 300.5)", new List<string>() { "opis", "obw" }));
        }

        static void PrintMenu()
        {
            String s = "Wybierz figure:\n"
                + "k - koło \n"
                + "t - trójkąt\n"
                + "p - prostokąt\n"
                + "w - kwadrat\n"
                + "z - trapez\n"
                + "r - równoległobok\n"
                + "f - wszystkie figury\n"
                + "m - menu\n"
                + "e - wyjście\n"
                + "---------------------------------\n\n";
            Console.Write(s);
        }

        static Figure HandleMenu(int c)
        {
            Figure fig = Figure.Nieznana;
            switch (c)
            {
                case 'k':
                    fig = Figure.Kolo;
                    break;
                case 't':
                    fig = Figure.Trojkat;
                    break;
                case 'p':
                    fig = Figure.Prostokat;
                    break;
                case 'w':
                    fig = Figure.Kwadrat;
                    break;
                case 'z':
                    fig = Figure.Trapez;
                    break;
                case 'r':
                    fig = Figure.Rownoleglobok;
                    break;
                case 'f':
                    fig = Figure.Wszystkie;
                    break;
                case 'm':
                    PrintMenu();
                    break;
                case 'e':
                    Console.Write("Do zobaczenia....");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.Write("\nNieznana opcja!");
                    break;
            }
            return fig;
        }

        static void PrintFigureMenu()
        {
            String s = "\nWybierz operacje:\n"
                + "d - dodaj nową figurę\n"
                + "w - wypisz dane \n"
                + "p - wypisz pole\n"
                + "s - posortuj względem pola \n"
                + "y - szukaj względem pola \n"
                + "o - wypisz obwod\n"
                + "b - posortuj względem obwodu \n"
                + "u - szukaj względem obwodu \n"
                + "m - przejdź do menu głównego \n"
                + "e - wyjście\n"
                + "---------------------------------\n\n";
            Console.Write(s);
        }

        static void HandleFigureMenu(int c)
        {
            Command res;
            switch (c)
            {
                case 'd':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_add", out res))
                        SendCommand(res);
                    break;
                case 'w':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_get", out res))
                        SendCommand(res);
                    break;
                case 'p':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_pole", out res))
                        SendCommand(res);
                    break;
                case 's':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_pole_sort", out res))
                        SendCommand(res);
                    break;
                case 'y':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_pole_search", out res))
                        SendCommand(res);
                    break;
                case 'o':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_obw", out res))
                        SendCommand(res);
                    break;
                case 'b':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_obw_sort", out res))
                        SendCommand(res);
                    break;
                case 'u':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_obw_search", out res))
                        SendCommand(res);
                    break;
                case 'm':
                    _currentFigure = Figure.Nieznana;
                    PrintMenu();
                    break;
                case 'e':
                    Console.Write("Do zobaczenia....");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.Write("\nNieznana opcja!");
                    break;
            }
        }

        static void Print2DFigureMenu()
        {
            String s = "\nWybierz operacje:\n"
                + "w - wypisz wszystkie figury \n"
                + "p - wypisz pola\n"
                + "s - posortuj względem pola \n"
                + "y - szukaj względem pola \n"
                + "o - wypisz obwody\n"
                + "b - posortuj względem obwodów \n"
                + "u - szukaj względem obwodu \n"
                + "m - przejdź do menu głównego \n"
                + "e - wyjście\n"
                + "---------------------------------\n\n";
            Console.Write(s);
        }

        static void Handle2DFigureMenu(int c)
        {
            Command res;
            switch (c)
            {
                case 'w':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_get", out res))
                        SendCommand(res);
                    break;
                case 'p':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_pole", out res))
                        SendCommand(res);
                    break;
                case 's':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_pole_sort", out res))
                        SendCommand(res);
                    break;
                case 'y':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_pole_search", out res))
                        SendCommand(res);
                    break;
                case 'o':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_obw", out res))
                        SendCommand(res);
                    break;
                case 'b':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_obw_sort", out res))
                        SendCommand(res);
                    break;
                case 'u':
                    if (_commands.TryGetValue(_currentFigure.ToString() + "_obw_search", out res))
                        SendCommand(res);
                    break;
                case 'm':
                    _currentFigure = Figure.Nieznana;
                    PrintMenu();
                    break;
                case 'e':
                    Console.Write("Do zobaczenia....");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.Write("\nNieznana opcja!");
                    break;
            }
        }

        static string GetInsertData(Command c)
        {
            String str = c.GetCommand();
            str += "('";
            Console.WriteLine(c.GetInsertHelper());
            Console.ReadLine(); //for trash left in console
            str += Console.ReadLine() + "');";

            return str;
        }

        static string GetSearchData(Command c)
        {
            String str = c.GetCommand();
            Console.WriteLine(c.GetInsertHelper());
            Console.ReadLine(); //for trash left in console
            String request = Console.ReadLine();
            if (request.Split(' ').Length < 2)
            {
                Console.WriteLine("Zła ilość argumentów. Pamiętaj o spacji między operatorem a liczbą");
                return null;
            }

            String op = request.Split(' ')[0];
            String num = request.Split(' ')[1];
            if (op == "=" || op == ">" || op == "<")
            {
                if (num.Split(',').Length > 1)
                {
                    Console.WriteLine("Podaj liczbę po operatorze. Użyj kropki zamiast przecinka.");
                    return null;
                }
                else
                {
                    str += request + ";";
                    return str;
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny operator! Dostępne =, >, <");
                return null;
            }
        }

        static void SendCommand(Command c)
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer;"
                + "INITIAL CATALOG=projektUDT; INTEGRATED SECURITY=SSPI;";

            string sqlcommand = c.GetCommand();
            if (c.GetCommandType().Equals(Command.Type.Insert))
            {
                //ask for values and add them to command
                sqlcommand = GetInsertData(c);
            }
            else if (c.GetCommandType().Equals(Command.Type.Search))
            {
                //ask for values and add them to command
                sqlcommand = GetSearchData(c);
                if (sqlcommand == null) return;
            }

            SqlConnection connection = new SqlConnection(sqlconnection);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    foreach (var item in c.GetAttributes())
                    {
                        Console.Write("{0, -20} ", datareader[item].ToString());
                    }
                    
                    Console.Write("\n");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("\nBłąd!");
                String mess = ex.Message.Split(new string[] { "Exception: " }, StringSplitOptions.None)[1].Split('\n')[0] ;
                Console.WriteLine(mess);
            }
            finally { connection.Close(); }
        }

        static void Main(string[] args)
        {
            InitMap();
            PrintMenu();
            int result;

            while (true)
            {
                if (_currentFigure == Figure.Wszystkie)
                {
                    Print2DFigureMenu();
                    Console.Write("{0} > ", _currentFigure.ToString());
                    do { result = Console.Read(); } while (result == 10 || result == 13);
                    Handle2DFigureMenu(result);
                }
                else if (_currentFigure != Figure.Nieznana)
                {
                    PrintFigureMenu();
                    Console.Write("{0} > ", _currentFigure.ToString());
                    do { result = Console.Read(); } while (result == 10 || result == 13);
                    HandleFigureMenu(result);
                }
                else
                {
                    Console.Write("> ");
                    do { result = Console.Read(); } while (result == 10 || result == 13);
                    _currentFigure = HandleMenu(result);
                }
            }
        }
    }

}