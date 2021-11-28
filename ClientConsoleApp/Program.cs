using ClientConsoleApp.Helper;
using ClientConsoleApp.Models;
using ClientConsoleApp.Services.Client;
using ClientConsoleApp.Services.Figure;
using System;

namespace ClientConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var client = new ClientService();
            var loginUser = new LoginModel
            {
                Login = "Admin",
                Password = "123"
            };

            var newFigure = new FigureModel
            {
                Id = Guid.NewGuid(),
                FigureName = "kwadrat",
                SideOne = 12
            };


            Console.WriteLine("Rozpoczęcie logowania dla Admin");
            var isLogged = client.Login(loginUser);
            Console.WriteLine("Zakończenie logowania dla Admin");

            var figure = new FigureService();
            Console.WriteLine("Dodanie nowej figury");

            var added = figure.AddFigure(newFigure);
            if (added)
                Console.WriteLine("Dodano figurę");

            Console.WriteLine("Zczytywanie figur");
            var list = figure.GetAllFiguresByName("kwadrat");
            
            
            Console.WriteLine("Wypisanie figur");
            Console.WriteLine();
            Console.WriteLine("--- *** ----"); 
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item.FigureName);
                Console.WriteLine(item.Area);
                Console.WriteLine("--- następna figura ---");
            }

            Console.WriteLine("Zakończenie programu, wciśnij dowolny przycisk");
            Console.ReadLine();
        }
    }
}
