using System.Text;

Console.OutputEncoding = Encoding.UTF8;

public delegate int[] MyDelegate(int n);
public class GG
{
    static int[] ListEven(int n)
    {
        List<int> List = new List<int>();
        for (int i = 2; i <= n; i = i + 2)
        {
            List.Add(i);
        }
        return List.ToArray();
    }

    static int[] ListPrime(int n)
    {
        List<int> List = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            int count = 0;
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0)
                    count++;
            }
            if (count == 2)
                List.Add(i);
        }
        return List.ToArray();
    }

    public static void Main(string[] args)
    {
        MyDelegate d1 = new MyDelegate(ListEven);
        int[] result = d1(10);
        Console.WriteLine("Danh sách các số chẵn:");
        foreach (int i in result)
        {
            Console.Write(i + "\t");
        }
        
         d1 = new MyDelegate(ListPrime);
        int[] result2 = d1(10);
        Console.WriteLine("ds các số ngtoo");
        foreach (int i in result2)
        {
            Console.Write(i + "\t");
        }

    }

}





