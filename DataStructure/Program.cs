using DataStructure;

public static class Program
{
    public static void Main(string[] args)
    {
        var l = new ArrayList<string>();
        l.Add("Hello");
        l.Add("World");
        Console.WriteLine(string.Join(" ", l));
    }
}