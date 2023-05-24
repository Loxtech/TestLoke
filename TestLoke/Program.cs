using System.Xml.Serialization;
using TestLoke;

namespace TestLoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Butterfly butterfly = new Butterfly() { Age = 22, Color = "Yellow", FirstName = "Scorn", LastName = "Chers", Name = "", Mood = "Sweet" };
            Butterfly butterfly1 = new Butterfly() { Age = 4, Color = "Brown", FirstName = "Mich", LastName = "Mach", Name = "", Mood = "Rude" };

            int answer = 0;
            Console.WriteLine("Choose 1 to insert/Delete single item, or Choose 2 to insert multiple items");
            try
            {
                answer = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                throw;
            }

            if (answer == 1)
            {
                Console.WriteLine("Insert or Delete?");
                string? choice = Console.ReadLine();
                butterfly1.InsertDelete(choice);
            }
            else if (answer == 2)
            {
                Console.WriteLine("Pick the number of insert queries wanted (2-5)");
                int choice = Convert.ToInt32(Console.ReadLine());
                Butterfly.TwoToFive(choice);
            }
            else
            {
                Console.WriteLine("incorrect answer");
            }
        }
    }
}