namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int spelplanWidth = 100;
            int speplanHeight = 25; 

            List<Person> allPersons = new List<Person>();

            Random rnd = new Random();

            //Skapa persons
            //Tjuv
            for(int i = 0; i < 10; i++)
            {
                int startx = rnd.Next(1, spelplanWidth, -1);
                int starty = rnd.Next(1, speplanHeight, -1);
                allPersons.Add(new Police(startx))
            }
        }
    }
}
