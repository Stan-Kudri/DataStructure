using DataStructure;

public static class Program
{
    public static void Main(string[] args)
    {
        //сложно?

        //У тебя раньше был top level main. тут он не понимал этого, скорее всего где-то какая-то опция должна быть включена
        //    он тебе писал, что нет Main
        var l = new ArrayList<string>(); // тоже назван неправильно, вспоминай, ищи как нужно
        l.Add("Hello");
        l.Add("World");
        Console.WriteLine(string.Join(" ", l));
    }
}