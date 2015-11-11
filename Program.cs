using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    The code below demonstrate the use of string, datetime, 
    read from a file, create a new file, write to a file,
    and create new methods, array, class, class member functions 

*/


namespace Trainning
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime current = DateTime.Now;
            string header = "Document modified by Edward Chen on " + current.ToShortDateString();
            string filename = "AboutUs.txt";
            bool succeed = createNewModifiedFile(filename, header);
            if (!succeed) Console.WriteLine("Operation Failed");
            else Console.WriteLine("Operation succeeded");


            // Team Class
            string[] teammates = { "John", "Mike", "Sarash", "Lauren" };
            Team myTeam = new Team("TheOne", teammates);
            Console.Write("TeamName: ");
            Console.WriteLine(myTeam.teamName);
            Console.Write("size: ");
            Console.WriteLine(myTeam.getSize());
            Console.Write("Menbers: ");
            print1Darray(myTeam.teamMembers);
            Console.ReadLine();
        }

        class Team
        {
            public string teamName { get; set; }
            public string[] teamMembers { get; set; }
            public int getSize()
            {
                return teamMembers.Length;
            }
            public Team(string Tname, string[] names)
            {
                teamName = Tname;
                teamMembers = names;
            }
        }
     
        // create a new file and copy everything from a old file
        // doing read line by line instead of readAllText
        private static bool createNewModifiedFile(string filename, string header)
        {
        StreamReader reader = new StreamReader(filename);
        StreamWriter writer; 
        string myPath = @"C:\Users\Edward\Documents\Visual Studio 2015\Projects\Trainning\Trainning\newAboutUs.txt";
        // create a new file
        if (!File.Exists(myPath))
            writer = File.CreateText(myPath);
        else return false;

        //write the header into the file
        writer.WriteLine(header);
        writer.WriteLine("\n");
        string line = reader.ReadLine();
        while (line != null)
        {
            writer.WriteLine(line);
            line = reader.ReadLine();
        }
        reader.Close();
        writer.Close();
        return true;
        }
        
        // Give an array, print all the elements out
        private static void print1Darray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i]+" ");
            Console.WriteLine();
        }

     }
}
