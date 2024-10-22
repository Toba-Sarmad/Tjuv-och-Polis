using System.Data;

namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int spelplanWidth = 100;
            int spelplanHeight = 25; 

            List<Persons> allPersons = new List<Persons>();

            Random rnd = new Random();

            //Skapa persons Police
            
            for(int i = 0; i < 10; i++)
            {
                int startx = rnd.Next(1, spelplanWidth -1);
                int starty = rnd.Next(1, spelplanHeight -1);
                allPersons.Add(new Police(startx, starty));
            }

            //Skapa persons Tjuvar
            for(int i = 0; i < 20; i++)
            {
                int startx = rnd.Next(1, spelplanWidth - 1);
                int starty = rnd.Next(1, spelplanHeight - 1);
                allPersons.Add(new Theif(startx, starty));
            }

            //Skapa persons Citizen
            for(int i = 0; i < 30; i++)
            {
                int startx = rnd.Next(1, spelplanWidth - 1);
                int starty = rnd.Next(1, spelplanHeight - 1);
                allPersons.Add(new Citizen(startx, starty));
            }

            while (true)
            {
                char[,] spelplan = new char[spelplanHeight, spelplanWidth];

                for (int row = 0; row < spelplanHeight; row++)
                {
                    for (int col = 0; col < spelplanWidth; col++)
                    {
                        if(row == 0  || row == spelplanHeight - 1 || col == 0 || col == spelplanWidth + 1)
                        {
                            spelplan[row, col] = ' ';
                        }
                        else
                        {
                            spelplan[row, col] = ' ';
                        }
                    }
                }
                foreach(var person in allPersons)
                {
                    if(person.XLocation >= 0 && person.XLocation < spelplanWidth && person.YLocation >= 0 && person.YLocation < spelplanHeight)
                    {
                        spelplan[person.YLocation, person.XLocation] = person.Character();
                    }
                }

                for (int row = 0; row < spelplanHeight; row++)
                {
                    for(int col = 0; col < spelplanWidth; col++)
                    {
                        Console.Write(spelplan[row, col]);
                    }
                    Console.WriteLine();
                }

                foreach(var person in allPersons)
                {
                    person.Movement(spelplanWidth, spelplanHeight, allPersons);
                }

                Thread.Sleep(2000);
            }
        }
        
            



    }
}
