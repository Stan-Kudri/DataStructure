using DataStructure;

public static class Program
{
    public static void Main(string[] args)
    {
        var list = new ArrayList<string> { "Keny", "Manta", "Polly", "Dandy" };
        var expectList = new List<string> { "Keny", "Manta", "Polly", "Dandy" };

        list.Clear();
        expectList.Clear();

        foreach (var item in expectList)
        {
            Console.WriteLine(item);
        }
    }
}