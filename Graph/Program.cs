using Graph.Models;

class Program
{
    static void Main(string[] args)
    {
        var network = new Network(8);

        network.Connect(1, 2);
        network.Connect(6, 2);
        network.Connect(2, 4);
        network.Connect(5, 8);

        Console.WriteLine("CONEXÕES--------------------\n");

        Console.WriteLine($"1 e 6 estão conectados? {network.Query(1, 6)}"); // true (1–2–6)
        Console.WriteLine($"6 e 4 estão conectados? {network.Query(6, 4)}"); // true (6–2–4)
        Console.WriteLine($"7 e 4 estão conectados? {network.Query(7, 4)}"); // false
        Console.WriteLine($"5 e 6 estão conectados? {network.Query(5, 6)}"); // false

        Console.WriteLine("\n NÍVEL DE CONEXÃO--------------------\n");

        Console.WriteLine($"Nível entre 1 e 6: {network.LevelConnetion(1, 6)}"); // 2 (1–2–6)
        Console.WriteLine($"Nível entre 1 e 2: {network.LevelConnetion(1, 2)}"); // 1 (1–2)
        Console.WriteLine($"Nível entre 6 e 4: {network.LevelConnetion(6, 4)}"); // 2 (6–2–4)
        Console.WriteLine($"Nível entre 5 e 8: {network.LevelConnetion(5, 8)}"); // 1 (5–8)
        Console.WriteLine($"Nível entre 7 e 4: {network.LevelConnetion(7, 4)}"); // 0 (sem conexão)

        Console.WriteLine("\n DESCONEXÃO--------------------\n");

        network.Disconnect(1, 2);
        Console.WriteLine($"Após desconectar 1 e 2, eles ainda estão conectados? {network.Query(1, 2)}"); // false
    }
}
