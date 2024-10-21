using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Person
    {
        public int XLocation { get; set; }

        public int YLocation{ get; set; }

       // List<string> Items { get; set; }

        public virtual char Symbol { get; } 

        protected static Random random = new Random();

        //constructor
        public Person(int xLocation, int yLocation)
        {
            XLocation = xLocation;
            YLocation = yLocation;
        }

        //Virtual method for movement
        public virtual void Movement(int width, int height, List<Person> allPersons)
        {
            int direction = random.Next(0, 6);
            int xdirection = 0;
            int ydirection = 0;

            switch(direction)
            {
                case 0:
                    ydirection = 1; //Upp
                    break;
                case 1:
                    ydirection = -1; //Ner
                    break;
                case 2:
                    xdirection = 1; //Höger
                    break;
                case3:
                    xdirection = -1; //Vänster
                    break;
                case 4:
                    xdirection = 1; //Upp höger tsm
                    ydirection = -1; 
                    break;
                case 5:
                    xdirection = -1; //Ner vänster tsm
                    ydirection = 1;
                    break;
            }

            XLocation = XLocation + xdirection;
            YLocation = YLocation + ydirection;
        }

        //Metod för symbol
        public virtual char Character()
        {
            return Symbol;
        }


        
    }

    class Theif : Person
    {
        public Theif(int x, int y) : base(x,y new )
        public override char Symbol
        { get 
            { 
                return 'T'; 
            } 
        }
    }

    class Police : Person
    {
        public override char Symbol
        {
            get
            {
                return 'P';
            }
        }
    }

    class Citizen : Person
    {
        public override char Symbol
        {
            get
            {
                return 'M';
            }
        }
    }
}
