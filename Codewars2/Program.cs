using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Collections.Generic;

namespace Codewars2;

class Program 
{//The Feast of Many Beast 
    public static bool Beast(string beast, string dish)
    { 
        return char.ToLower(beast[0]) == char.ToLower(dish[0]) && char.ToLower(beast[^1]) == char.ToLower(dish[^1]);
    }
//Two Sum : Take the sum of two int in the numbers array and return a value equal to the target 
    public static int[] TwoSums(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)//1st int in the array 
        {
            for (int j = i + 1; j < numbers.Length; j++)//2nd int in the array
            {
                if (numbers[i] + numbers[j] == target)//Sum of two ints that equal the target 
                    return new int[] { i, j }; //return the two ints 
            }
        }

        return new int[] { }; //no solution found 
    }
    
    
    
    // 5 without numbers: Can't use these 0123456789*+-/
    public static int UnusualFive()
    {
        return "five!".Length;//This works because it has a length of 5 and contains no restricted characters
    } 

    //Find the stray number
    public static int differentArray(int[] numbers)
    {
        return numbers.GroupBy(x => x).First(x => x.Count() == 1).Key; 
    }
    //Fix String Case 
    public static string Solve(string s)
    {
        int upper = s.Count(char.IsUpper);
        int lower = s.Count(char.IsLower);
        return upper > lower ? s.ToUpper() : s.ToLower();
    }
    
    
    //Triple Trouble 
    public static string TripleTrouble(string one, string two, string three)
    {
        string result = " "; //Variable created outside the for loop to concat the results ;
        for (int i = 0; i < one.Length; i++)//could use two.Length or three.Length no difference 
        {
            result += one[i];
            result += two[i];
            result += three[i];
        }
        return result;
    }

    //Count the Smiley Faces 
   
    public static int CountSmileys(string[] smileys)
    {
        return smileys.Count(s => s switch //switch case to account for all versions of the smileys
        {
            ":)" or ":D" or ";D" or ";)" => true,//This matches the two character smileys
            ":-)" or ":-D" or ":~)" or ":~D" or ";-)" or ";-D" or ";~)" or ";~D" => true,//This is 3 smileys
            _ => false //default to false for all others
        });
        

    }
    
    //Count the Smileys Faces: Saving this approach because this was what I originally tried unsuccessfully
    public static int CountSmiley(string[] smileys)//Dropped the s on the method name to prevent overload
    {
        int c = 0;
        List<string> smileysList = smileys.ToList<string>();
        List<char> eyes = new List<char> { ':', ';' };
        List<char> nose = new List<char> { '-', '~'};//I forgot to account for the nose
        List<char> mouth = new List<char> { ')', 'D' };

        foreach(string str in smileys)
        {
            if(str.Length==2 || str.Length == 3)
            {//Was not aware of the .Exists() 
                if (eyes.Exists(symbol => symbol.Equals(str.First<char>())))
                {
                    if (mouth.Exists((symbol => symbol.Equals(str.Last<char>()))))
                    {
                        if(nose.Exists(symbol=> symbol.Equals(str.ElementAt<char>(1))))
                            c++;

                        else if (str.Length == 2)
                            c++;
                    } 
                }
            }  
        }
        return c;
    }
    
    
    //Sum Mixed Array
    public static int SumMix(object[] x)
    {
        return x.Sum(Convert.ToInt32);//Simply get the Sum of the array and inside the sum method convert all to int
    }
    //The Supermarket Queue
    //The function should return an int, the total time to checkout
    public static long QueueTime(int[] customers, int registers)
    {
        var result = new int[registers];//Declare a variable for registers
        foreach (var customer in customers)//Loop to go through the array 
        {
            result[Array.IndexOf(result, result.Min())] += customer;//compare number of registers to customers
        }
        return result.Max();//max number of registers 
    }
    //Duplicate Count: Return the number of duplicates that occur inside a string
    public static int DuplicateCount(string str)
    {
        return str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Select(g => g.Key).Count();
    }
    /*Things I worked through on this exercise: Uniformity-.ToLower(), Grouping-.GroupBy(), and Filtering-.Where() .Count()
     and .Select(). I tried the first time using the .Contains and was only searching for the single character. I also tried using the .ToLower() 
     at the end and it did not work because it was so far down the line of code it wasn't being applied to the "str"*/
    
    
    //Break the camelCase
    public static string BreakCamelCase(string str) =>
    
        new Regex("([A-Z])").Replace(str, " $1");
         /*Instead of looking for a specific transition(like lowercase to uppercase) it treats every single
          uppercase letter as a trigger to insert a space
          My original code: Regex.Replace(str, "([a-z])([A-Z])", "$1 $2") looked for a transition from lower to upper*/
         
    //Get the mean of an Array
    public static int GetAverage(int[] marks)
    {
        return marks.Sum() / marks.Length;//Average() doesn't work because it is an int not a double. Basic math to get
        //the average. Added all numbers in the array and divided it by the number of numbers in the array. 
    }
    
    
    static void Main(string[] args)
    {
        //Beast Method Test
        Console.WriteLine($"Beast('great blue heron', 'garlic naan') -> {Beast("great blue heron", "garlic naan")} (Expected: True)");
        Console.WriteLine($"Beast('chickadee', 'chocolate cake') -> {Beast("chickadee", "chocolate cake")} (Expected: True)");
        Console.WriteLine($"Beast('brown bear', 'bear claw') -> {Beast("brown bear", "bear claw")} (Expected: False)");
        Console.WriteLine("--------------------------");
        
        //BreakCamelCase Method Test
        Console.WriteLine($"'camelCase' -> '{BreakCamelCase("camelCase")}'");
        Console.WriteLine($"'NASA' -> '{BreakCamelCase("NASA")}'");
        Console.WriteLine($"'SomeABCWord' -> '{BreakCamelCase("SomeABCWord")}'");

        Console.WriteLine("--------------------------");
        
        //DuplicateCount Method Test 
        Console.WriteLine($"$aabbccdd {DuplicateCount("aabbccdd")}");
        Console.WriteLine($"$abcde {DuplicateCount("abcde")}");
        Console.WriteLine($"$aAbBcdef {DuplicateCount("aAbBcdef")}");
        Console.WriteLine($"Mississippi {DuplicateCount("Mississippi")}");
        Console.WriteLine("--------------------------");
        
        //GetAverage Method Test
        Console.WriteLine($"Average [1, 2, 3, 4, 5] -> {GetAverage(new int[] { 1, 2, 3, 4, 5 })}");
        Console.WriteLine($"Average [1, 1, 1, 1, 1, 1, 1, 2] -> {GetAverage(new int[] { 1, 1, 1, 1, 1, 1, 1, 2 })}");
        Console.WriteLine($"Average [2, 2, 2, 2] -> {GetAverage(new int[] { 2, 2, 2, 2 })}");
        Console.WriteLine("--------------------------");

        //QueueTime Method Test
        Console.WriteLine($"QueueTime [5, 3, 4], 1 -> {QueueTime(new int[] { 5, 3, 4 }, 1)} (Expected: 12)");
        Console.WriteLine($"QueueTime [10, 2, 3, 3], 2 -> {QueueTime(new int[] { 10, 2, 3, 3 }, 2)} (Expected: 10)");
        Console.WriteLine($"QueueTime [2, 3, 10], 2 -> {QueueTime(new int[] { 2, 3, 10 }, 2)} (Expected: 12)");
        Console.WriteLine("--------------------------");
        
        //SumMix Method Test
        Console.WriteLine($"SumMix [9, 3, \"7\", \"3\"] -> {SumMix(new object[] { 9, 3, "7", "3" })} (Expected: 22)");
        Console.WriteLine($"SumMix [\"5\", \"0\", 9, 3, 2, 1, \"9\", 6, 7] -> {SumMix(new object[] { "5", "0", 9, 3, 2, 1, "9", 6, 7 })} (Expected: 42)");
        Console.WriteLine($"SumMix [\"3\", 6, 6, 0, \"5\", 8, 5, \"6\", 2, \"0\"] -> {SumMix(new object[] { "3", 6, 6, 0, "5", 8, 5, "6", 2, "0" })} (Expected: 41)");
        Console.WriteLine("--------------------------");
        
        //TripleTrouble Method Test
        Console.WriteLine($"TripleTrouble(\"aa\", \"bb\", \"cc\") -> \"{TripleTrouble("aa", "bb", "cc")}\" (Expected: \"abcabc\")");
        Console.WriteLine($"TripleTrouble(\"Bm\", \"aa\", \"tn\") -> \"{TripleTrouble("Bm", "aa", "tn")}\" (Expected: \"Batman\")");
        Console.WriteLine($"TripleTrouble(\"LLh\", \"euo\", \"edr\") -> \"{TripleTrouble("LLh", "euo", "edr")}\" (Expected: \"Leouheder\")");
    }
}