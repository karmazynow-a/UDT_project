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

        static Dictionary<string, Command> commands = new Dictionary<string, Command>();

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
            commands.Add("Kolo_get", new Command("select kolo.ToString() as kolo from Kolo;", Command.Type.Select, "", new List<string>() { "kolo" }));
            commands.Add("Kolo_pole", new Command("select kolo.ToString() as kolo, kolo.Pole() as pole from Kolo;", Command.Type.Select, "", new List<string>() { "kolo", "pole" }));
            commands.Add("Kolo_pole_sort", new Command("select kolo.ToString() as kolo, kolo.Pole() as pole from Kolo order by pole;", Command.Type.Select, "", new List<string>() { "kolo", "pole" }));
            commands.Add("Kolo_obw", new Command("select kolo.ToString() as kolo, kolo.Obwod() as obwod from Kolo;", Command.Type.Select, "", new List<string>() { "kolo", "obwod" }));
            commands.Add("Kolo_obw_sort", new Command("select kolo.ToString() as kolo, kolo.Obwod() as obwod from Kolo order by obwod;", Command.Type.Select, "", new List<string>() { "kolo", "obwod" }));
            commands.Add("Kolo_add", new Command("insert into Kolo (kolo) values ", Command.Type.Insert, "Podaj promień oraz wspołrzędne", new List<string>() {}));

            commands.Add("Trojkat_get", new Command("select trojkat.ToString() as trojkat from Trojkat;", Command.Type.Select, "", new List<string>() { "trojkat" }));
            commands.Add("Trojkat_pole", new Command("select trojkat.ToString() as trojkat, trojkat.Pole() as pole from Trojkat;", Command.Type.Select, "", new List<string>() { "trojkat", "pole" }));
            commands.Add("Trojkat_pole_sort", new Command("select trojkat.ToString() as trojkat, trojkat.Pole() as pole from Trojkat order by pole;", Command.Type.Select, "", new List<string>() { "trojkat", "pole" }));
            commands.Add("Trojkat_obw", new Command("select trojkat.ToString() as trojkat, trojkat.Obwod() as obwod from Trojkat;", Command.Type.Select, "", new List<string>() { "trojkat", "obwod" }));
            commands.Add("Trojkat_obw_sort", new Command("select trojkat.ToString() as trojkat, trojkat.Obwod() as obwod from Trojkat order by obwod;", Command.Type.Select, "", new List<string>() { "trojkat", "obwod" }));
            commands.Add("Trojkat_add", new Command("insert into Trojkat (trojkat) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            commands.Add("Prostokat_get", new Command("select prostokat.ToString() as prostokat from Prostokat;", Command.Type.Select, "", new List<string>() { "prostokat" }));
            commands.Add("Prostokat_pole", new Command("select prostokat.ToString() as prostokat, prostokat.Pole() as pole from Prostokat;", Command.Type.Select, "", new List<string>() { "prostokat", "pole" }));
            commands.Add("Prostokat_pole_sort", new Command("select prostokat.ToString() as prostokat, prostokat.Pole() as pole from Prostokat order by pole;", Command.Type.Select, "", new List<string>() { "prostokat", "pole" }));
            commands.Add("Prostokat_obw", new Command("select prostokat.ToString() as prostokat, prostokat.Obwod() as obwod from Prostokat;", Command.Type.Select, "", new List<string>() { "prostokat", "obwod" }));
            commands.Add("Prostokat_obw_sort", new Command("select prostokat.ToString() as prostokat, prostokat.Obwod() as obwod from Prostokat order by obwod;", Command.Type.Select, "", new List<string>() { "prostokat", "obwod" }));
            commands.Add("Prostokat_add", new Command("insert into Prostokat (prostokat) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            commands.Add("Kwadrat_get", new Command("select kwadrat.ToString() as kwadrat from Kwadrat;", Command.Type.Select, "", new List<string>() { "kwadrat" }));
            commands.Add("Kwadrat_pole", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Pole() as pole from Kwadrat;", Command.Type.Select, "", new List<string>() { "kwadrat", "pole" }));
            commands.Add("Kwadrat_pole_sort", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Pole() as pole from Kwadrat order by pole;", Command.Type.Select, "", new List<string>() { "kwadrat", "pole" }));
            commands.Add("Kwadrat_obw", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Obwod() as obwod from Kwadrat;", Command.Type.Select, "", new List<string>() { "kwadrat", "obwod" }));
            commands.Add("Kwadrat_obw_sort", new Command("select kwadrat.ToString() as kwadrat, kwadrat.Obwod() as obwod from Kwadrat order by obwod;", Command.Type.Select, "", new List<string>() { "kwadrat", "obwod" }));
            commands.Add("Kwadrat_add", new Command("insert into Kwadrat (kwadrat) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            commands.Add("Rownoleglobok_get", new Command("select rownoleglobok.ToString() as rownoleglobok from Rownoleglobok;", Command.Type.Select, "", new List<string>() { "rownoleglobok" }));
            commands.Add("Rownoleglobok_pole", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Pole() as pole from Rownoleglobok;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "pole" }));
            commands.Add("Rownoleglobok_pole_sort", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Pole() as pole from Rownoleglobok order by pole;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "pole" }));
            commands.Add("Rownoleglobok_obw", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Obwod() as obwod from Rownoleglobok;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "obwod" }));
            commands.Add("Rownoleglobok_obw_sort", new Command("select rownoleglobok.ToString() as rownoleglobok, rownoleglobok.Obwod() as obwod from Rownoleglobok order by obwod;", Command.Type.Select, "", new List<string>() { "rownoleglobok", "obwod" }));
            commands.Add("Rownoleglobok_add", new Command("insert into Rownoleglobok (rownoleglobok) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            commands.Add("Trapez_get", new Command("select trapez.ToString() as trapez from Trapez;", Command.Type.Select, "", new List<string>() { "trapez" }));
            commands.Add("Trapez_pole", new Command("select trapez.ToString() as trapez, trapez.Pole() as pole from Trapez;", Command.Type.Select, "", new List<string>() { "trapez", "pole" }));
            commands.Add("Trapez_pole_sort", new Command("select trapez.ToString() as trapez, trapez.Pole() as pole from Trapez order by pole;", Command.Type.Select, "", new List<string>() { "trapez", "pole" }));
            commands.Add("Trapez_obw", new Command("select trapez.ToString() as trapez, trapez.Obwod() as obwod from Trapez;", Command.Type.Select, "", new List<string>() { "trapez", "obwod" }));
            commands.Add("Trapez_obw_sort", new Command("select trapez.ToString() as trapez, trapez.Obwod() as obwod from Trapez order by obwod;", Command.Type.Select, "", new List<string>() { "trapez", "obwod" }));
            commands.Add("Trapez_add", new Command("insert into Trapez (trapez) values ", Command.Type.Insert, "Podaj kolejne współrzędne wierzchołków oddzielone spacją", new List<string>() { }));

            commands.Add("Wszystkie_get", new Command("select opis from getAllAreas()", Command.Type.Select, "", new List<string>() { "opis" }));
            commands.Add("Wszystkie_pole", new Command("select * from getAllAreas()", Command.Type.Select, "", new List<string>() { "opis", "pole" }));
            commands.Add("Wszystkie_pole_sort", new Command("select * from getAllAreas() order by pole", Command.Type.Select, "", new List<string>() { "opis", "pole" }));
            commands.Add("Wszystkie_obw", new Command("select * from getAllCircuit()", Command.Type.Select, "", new List<string>() { "opis", "obw" }));
            commands.Add("Wszystkie_obw_sort", new Command("select * from getAllCircuit() order by obw", Command.Type.Select, "", new List<string>() { "opis", "obw" }));
        
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
                + "o - wypisz obwod\n"
                + "b - posortuj względem obwodu \n"
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
                    if (commands.TryGetValue(_currentFigure.ToString() + "_add", out res))
                        SendCommand(res);
                    break;
                case 'w':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_get", out res))
                        SendCommand(res);
                    break;
                case 'p':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_pole", out res))
                        SendCommand(res);
                    break;
                case 's':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_pole_sort", out res))
                        SendCommand(res);
                    break;
                case 'o':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_obw", out res))
                        SendCommand(res);
                    break;
                case 'b':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_obw_sort", out res))
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
                + "o - wypisz obwody\n"
                + "b - posortuj względem obwodów \n"
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
                    if (commands.TryGetValue(_currentFigure.ToString() + "_get", out res))
                        SendCommand(res);
                    break;
                case 'p':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_pole", out res))
                        SendCommand(res);
                    break;
                case 's':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_pole_sort", out res))
                        SendCommand(res);
                    break;
                case 'o':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_obw", out res))
                        SendCommand(res);
                    break;
                case 'b':
                    if (commands.TryGetValue(_currentFigure.ToString() + "_obw_sort", out res))
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
            Console.ReadLine(); //for trash left in console TODO fix this 
            str += Console.ReadLine() + "');";

            return str;
        }

        static void SendCommand(Command c)
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer;"
                + "INITIAL CATALOG=testCLR; INTEGRATED SECURITY=SSPI;";

            string sqlcommand = c.GetCommand();
            if (c.GetCommandType().Equals(Command.Type.Insert))
            {
                //ask for values and add them to command
                sqlcommand = GetInsertData(c);
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