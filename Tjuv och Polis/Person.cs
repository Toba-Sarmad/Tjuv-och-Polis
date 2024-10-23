using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Persons
    {
        public int XLocation { get; set; }

        public int YLocation{ get; set; }

        public List<string> Iteams { get; set; }

        public virtual char Symbol { get; } 

        protected static Random random = new Random();

        public Persons(int x, int y, List<string> iteams)
        {
            XLocation = x;
            YLocation = y;
            Iteams = iteams;
        }

        //constructor
        //public Persons(int xLocation, int yLocation)
        //{
        //    XLocation = xLocation;
        //    YLocation = yLocation;
        //}

        //Virtual method for movement
        public virtual void Movement(int width, int height, List<Persons> allPersons)
        {
            int direction = random.Next(0, 6);
            int xdirection = 0;
            int ydirection = 0;

            switch(direction)
            {
                case 0:
                    ydirection = -1; //Upp
                    break;
                case 1:
                    ydirection = 1; //Ner
                    break;
                case 2:
                    xdirection = 1; //Höger
                    break;
                case3:
                    xdirection = -1; //Vänster
                    break;
                case 4:
                    xdirection = 1; //Uppåt höger tillsammans
                    ydirection = -1; 
                    break;
                case 5:
                    xdirection = -1; //Nedåt vänster tillsammans
                    ydirection = 1;
                    break;
            }

            XLocation += xdirection;
            YLocation += ydirection;
        }

        //Metod för symbol
        public virtual char GetCharacter()
        {
            return Symbol;
        }


        
    }

    class Theif : Persons
    {
        public override char Symbol => 'T'; //Symbolen för tjuv, innan hade get return Symbol 'T'

        public Theif(int x, int y) : base(x, y, new List<string>()) { }

        public override void Movement(int width, int height, List<Persons>allpersrons)
        {
            base.Movement(width, height, allpersrons);
            
            foreach(Persons person in allpersrons)
            {
                if(person is Citizen citizen && citizen.XLocation == YLocation && citizen.YLocation == YLocation)
                {
                    if(citizen.Iteams.Count > 0)
                    {
                        int iteamsindex = random.Next(citizen.Iteams.Count);
                        string stolenIteam = citizen.Iteams[iteamsindex];
                        citizen.Iteams.RemoveAt(iteamsindex);

                        Console.WriteLine($"Theif stole {stolenIteam} from Citizen at {citizen.XLocation}, {citizen.YLocation}.");
                    }
                }
            }
        }
    }

    class Police : Persons
    {
        public override char Symbol => 'P';

        public Police(int x, int y) : base(x, y, new List<string>()) { }

        public override void Movement(int width, int height, List<Persons> allPersons)
        {
            base.Movement(width, height, allPersons);

            foreach(Persons person in allPersons)
            {
                if(person is Theif theif && theif.XLocation == XLocation && theif.YLocation == YLocation)
                {
                    if(theif.Iteams.Count > 0)
                    {
                        Console.WriteLine("Polisen möter tjuven och tar stulna iteams från Theif.");
                        theif.Iteams.Clear();
                    }
                }
                else if(person is Citizen citizen && citizen.XLocation == XLocation && citizen.YLocation == YLocation)
                {
                    Console.WriteLine($"Antal gripna tjuvar: ");
                }
            }
        }

    }

    class Citizen : Persons
    {
        public override char Symbol => 'C';
        
        public Citizen(int x, int y) : base(x, y, new List<string>()) { }

        //public override void Movement(int width, int height, List<Persons> allPersons)
        //{
        //    base.Movement(width, height, allPersons);
        //}


    }
}
