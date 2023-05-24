using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace TestLoke
{
    public class Butterfly: Animal, IButterFly
    {
        #region properties
        //public static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=h1Test; Trusted_Connection=true; TrustServerCertificate=True";
        //public int Id { get; set; }
        //public string? Color { get; set; }
        //public int Age { get; set; }
        //public string? Name { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public string? Mood { get; set; }
        #endregion

        #region ClassAndInterface
        /// <summary>
        /// The difference between an Interface and a Class
        /// An Interface is a type which holds only the requirements for other classes which utilize/implement it.
        /// this might be things such as methodes. Interfaces forces classes who implement them to have
        /// the same methodes present. This means if you have multiple classes who all have identical 
        /// methodes needed, if you implement a interface it is required for them all to have each methode
        /// 
        /// A Class is a type which can hold things such as properties, methodes and fields, properties 
        /// play the roll that if an instance of the class is made (-Classname- -name- = new -Classname-)
        /// if will need said properties. As said a class can also hold methodes which can be called
        /// or invoked to perform a certain action. Classes also have a thing called "constructor",
        /// which is basically another methode which will always run when an object is made of the class.
        /// </summary>
        #endregion
        public void InsertDelete(string choice)
        {

            if (choice.ToLower() == "insert")
            {
                if (this.Mood == "Sweet")
                {
                    Console.WriteLine("Insert chosen");
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string query = $"insert into butterfly values('{Color}','','{FirstName}','{LastName}','{Mood}','{Age}')";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Butterfly was not sweet and further action was therefore abandoned");
                }
            }
            else if (choice.ToLower() == "delete")
            {
                int id = 0;
                Console.WriteLine("Delete chosen, please choose the \"ID\" of the butterfly you would like to delete");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string query = $"DELETE FROM butterfly WHERE id={id}";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Incorrect input detected: {e}");
                }
            }
            else
            {
                Console.WriteLine("Incorrect answer");
            }


        }

        public static void TwoToFive(int choice)
        {
            if (choice > 1 && choice < 6)
            {
                for (int i = 0; i < choice; i++)
                {
                    try
                    {
                        Console.WriteLine("please input the following: ");
                        Console.Write("Color: ");
                        string? Color = Console.ReadLine();
                        Console.Write("Firstname: ");
                        string? FirstName = Console.ReadLine();
                        Console.Write("Lastname: ");
                        string? LastName = Console.ReadLine();
                        Console.Write("Mood: ");
                        string? Mood = Console.ReadLine();
                        Console.Write("Age (As number): ");
                        int Age = Convert.ToInt32(Console.ReadLine());
                        SqlConnection con = new SqlConnection(connectionString);
                        con.Open();
                        string? query = $"insert into butterfly values('{Color}','','{FirstName}','{LastName}','{Mood}','{Age}')";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error occured: {e}");
                        throw;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect answer");
            }
        }

        // Kunne ikke rigtig få denne version til at virke, prøvede at bruge arrays men kunne ikke indlæse det som enkelt query
        public static void TwoToFive2(int choice)
        {
            if (choice > 1 && choice < 6)
            {
                string[] Color = new string[choice];
                string[] FirstName = new string[choice];
                string[] LastName = new string[choice];
                string[] Mood = new string[choice];
                int[] Age = new int[choice];
                string[] queryArr = new string[choice];
                for (int i = 0; i < choice; i++)
                {
                    try
                    {
                        Console.WriteLine("please input the following: ");
                        Console.Write("Color: ");
                        Color[i] = Console.ReadLine();
                        Console.Write("Firstname: ");
                        FirstName[i] = Console.ReadLine();
                        Console.Write("Lastname: ");
                        LastName[i] = Console.ReadLine();
                        Console.Write("Mood: ");
                        Mood[i] = Console.ReadLine();
                        Console.Write("Age (As number): ");
                        Age[i] = Convert.ToInt32(Console.ReadLine());

                        queryArr[i] = $"('{Color[i]}','','{FirstName[i]}','{LastName[i]}','{Mood[i]}','{Age[i]}')";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error occured: {e}");
                        throw;
                    }
                }
                

                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                string queryRunthrough = "";
                for (int i = 0; i < choice; i++)
                {
                    if (i == choice-1)
                    {
                        queryRunthrough = queryRunthrough + "\n" + queryArr[i] + ";";
                    }
                    queryRunthrough = queryRunthrough + "\n"  + queryArr[i] + ",";
                }
                Console.WriteLine(queryRunthrough);
                string query = "insert into butterfly values" + queryRunthrough;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();


            }
            else
            {
                Console.WriteLine("Incorrect answer");
            }
        }

    }
}
