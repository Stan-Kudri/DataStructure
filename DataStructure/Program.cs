using DataStructure;

public static class Program
{
    public static void Main(string[] args)
    {
        var l = new ArrayList<string>();
        l.Add("Hello");
        l.Add("World");
        Console.WriteLine(string.Join(" ", l));
        var rr = new string[10];
        rr = Array.Empty<string>();
        foreach (string s in rr)
        {
            Console.WriteLine(s);
        }
    }
}