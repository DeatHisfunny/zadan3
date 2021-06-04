using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Security.Cryptography;

class Program  
{
    static string HMACKHASH(string key, string str)
    {
        byte[] bkey = Encoding.Default.GetBytes(str);
        using (var hmac = new HMACSHA256(bkey))
        {
            byte[] bstr = Encoding.Default.GetBytes(key);
            var bhash = hmac.ComputeHash(bstr);
            return BitConverter.ToString(bhash).Replace("-", string.Empty);

        }
    }

    static int UserChoose()
    {
        int number;
        do
        {
            Console.Write("Enter a number from 0 to 6 : ");
            int.TryParse(Console.ReadLine(), out number);
            
        } while (number < 0 || number > 6);
        return number;
    }

    static int CompChoose(Random random)
    {
        return random.Next(6);
    }

    static string Message(int number)
    {
        switch (number)
        {
            case 0: return "Rock";
            case 1: return "Fire";
            case 2: return "Scissors";
            case 3: return "Sponge";
            case 4: return "Paper";
            case 5: return "Air";
            case 6: return "Water";

        }
        return null;
    }
    static bool GameOver(int user, int comp)
    {
        if (user == 0 && comp == 1 ||
            user == 0 && comp == 2 ||
            user == 0 && comp == 3 ||

            user == 1 && comp == 2 ||
            user == 1 && comp == 3 ||
            user == 1 && comp == 4 ||

            user == 2 && comp == 3 ||
            user == 2 && comp == 4 ||
            user == 2 && comp == 5 ||

            user == 3 && comp == 4 ||
            user == 3 && comp == 5 ||
            user == 3 && comp == 6 ||

            user == 4 && comp == 5 ||
            user == 4 && comp == 6 ||
            user == 4 && comp == 0 ||

            user == 5 && comp == 6 ||
            user == 5 && comp == 0 ||
            user == 5 && comp == 1 ||

            user == 6 && comp == 0 ||
            user == 6 && comp == 1 ||
            user == 6 && comp == 2
            )
            return true;
        return false;

    }
    static int UserChoosethree()
    {
        int number;
        do
        {
            Console.Write("Enter a number from 0 to 2 : ");
            int.TryParse(Console.ReadLine(), out number);
            
        } while (number < 0 || number > 2);
        return number;
    }
    static int CompChoosethree(Random random)
    {
        return random.Next(3); 
    }
    static string Messagethree(int number)
    {
        switch (number)
        {
            case 0: return "Rock";
            case 1: return "Scissors";
            case 2: return "Paper";
            

        }
        return null;
    }
    static bool GameOverthree(int user, int comp)
    {
        if (user == 0 && comp == 1 ||
            user == 1 && comp == 2 ||
            user == 2 && comp == 0 
            
             )
            return true;
        return false;

    }

    static void Main(string[] args)
    {

        
        if (args.Length == 3 & args.Length % 2 == 1)
        {
            var Corrctthree = args[0] == "Rock" & args[1] == "Scissors" & args[2] == "Paper";
            if (Corrctthree)
            {
                var map = new Dictionary<int, string>();
                for (int i = 0; i != args.Length; i++)
                {
                    map.Add(i, args[i]);
                }
               
                Console.WriteLine("Parameters:" + args.Length.ToString());
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(i.ToString() + "- " + args[i]);
                }
                Console.WriteLine("10 - Exit");
                

                int user, comp;
                Random random = new Random();

                while (true)
                {
                    user = UserChoosethree();
                    comp = CompChoosethree(random);
                    if (user != comp)
                        break;
                    Console.WriteLine("Key:" + HMACKHASH("", Messagethree(user)));
                    Console.WriteLine($"Both chose {Messagethree(user)}. Draw.\n");
                }
                Console.WriteLine("Key:" + HMACKHASH("", Messagethree(user)));
                Console.WriteLine("Player's choice: " + Messagethree(user) + ", Computer choice: " + Messagethree(comp));

                if (GameOverthree(user, comp))
                    Console.WriteLine("Player won");
                else
                    Console.WriteLine("Computer won");

                Console.ReadKey();
                
            
        }
        }
        else
        {
            Console.WriteLine("Enter more than three parameters");
        }
        if (args.Length == 7 & args.Length % 2 == 1)
            {
                var Correctseven = args[0] == "Rock" & args[1] == "Fire" & args[2] == "Scissors" & args[3] == "Sponge" & args[4] == "Paper" & args[5] == "Air" & args[6] == "Water";
                if (Correctseven)
                {
                    var map = new Dictionary<int, string>();
                    for (int i = 0; i != args.Length; i++)
                    {
                        map.Add(i, args[i]);
                    }

                    Console.WriteLine("Available moves:");
                    for (int i = 0; i < args.Length; i++)
                    {
                        Console.WriteLine(i.ToString() + "- " + args[i]);

                    }
                    Console.WriteLine("10 - Exit");
                    int user, comp;
                    Random random = new Random();
                    while (true)
                    {
                        user = UserChoose();
                        comp = CompChoose(random);
                        if (user != comp)
                            break;
                    Console.WriteLine("Key:" + HMACKHASH("", Message(user)));
                    Console.WriteLine($"Both chose  {Message(user)}. Draw.\n");
                    }
                Console.WriteLine("Key:"+ HMACKHASH("", Message(user)));
                Console.WriteLine("Player's choice : " + Message(user) + ", Computer choice: " + Message(comp));
                 
               
                if (GameOver(user, comp))
                        Console.WriteLine("Player won");
                    else
                        Console.WriteLine("Computer won");

                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("Incorrect parameters: Example: Rock Fire Scissors Sponge Paper Air Water ");
                }
            }
           else
            {
                Console.WriteLine("Enter more than three parameters");
            }

        
    }
}