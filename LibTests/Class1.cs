using System.Collections.Generic;
namespace LibTests
{
    public class MergeNames
    {
        
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            string[] namesConc=names1.Concat(names2).ToArray();
            List<string> result = new List<string>();
            
            foreach (string name in namesConc) 
            {
                if (!result.Contains(name)) { 
                    result.Add(name); 
                }
            }
            return result.ToArray();
        }

        public static void Main(string[] args)
        {
            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
            Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
        }
    

}
}