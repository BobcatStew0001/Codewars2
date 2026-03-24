using System.Text.RegularExpressions;
using System.Linq; 
namespace Codewars2;

class Program
{
    //Duplicate Count: Return the number of duplicates that occur inside a string
    public static int DuplicateCount(string str)
    {
        return str.Contains("a") ? str.Count(c => c == 'a') : str.Count(c => c == 'b');
    }
    
    //Break the camelCase
    public static string BreakCamelCase(string str) =>
    
        new Regex("([A-Z])").Replace(str, " $1");
         /*Instead of looking for a specific transition(like lowercase to uppercase) it treats every single
          uppercase letter as a trigger to insert a space
          My original code: Regex.Replace(str, "([a-z])([A-Z])", "$1 $2") looked for a transition from lower to upper*/
         
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        //BreakCamelCase Method Test
        Console.WriteLine($"'camelCase' -> '{BreakCamelCase("camelCase")}'");
        Console.WriteLine($"'NASA' -> '{BreakCamelCase("NASA")}'");
        Console.WriteLine($"'SomeABCWord' -> '{BreakCamelCase("SomeABCWord")}'");
        
        //DuplicateCount Method Test 
        Console.WriteLine($"$aabbccdd {DuplicateCount("aabbccdd")}");
        Console.WriteLine($"$abcde {DuplicateCount("abcde")}");
        Console.WriteLine($"$aAbBcdef {DuplicateCount("aAbBcdef")}");
        Console.WriteLine($"Mississippi {DuplicateCount("Mississippi")}");
    }
}