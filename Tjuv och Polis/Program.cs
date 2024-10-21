namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int spelplanWidth = 100;
            int speplanHeight = 25; 

            List<Persons> allPersons = new List<Persons>();

            Random rnd = new Random();

            //Skapa persons Police
            
            for(int i = 0; i < 10; i++)
            {
                int startx = rnd.Next(1, spelplanWidth -1);
                int starty = rnd.Next(1, speplanHeight -1);
                allPersons.Add(new Police(startx, starty));
            }

            //Skapa persons Tjuvar
            for(int i = 0; i < 20; i++)
            {
                int startx = rnd.Next(1, spelplanWidth - 1);
                int starty = rnd.Next(1, speplanHeight - 1);
                allPersons.Add(new Theif(startx, starty));
            }

            //Skapa persons Citizen
            for(int i = 0; i < 30; i++)
            {
                int startx = rnd.Next(1, spelplanWidth - 1);
                int starty = rnd.Next(1, speplanHeight - 1);
                allPersons.Add(new Citizen(startx, starty));
            }
        }
    }
}
