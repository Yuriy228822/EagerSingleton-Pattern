using EagerSingleton_Pattern;

class Program
{
    static void Main(string[] args)
    {
        EagerSingleton singleton = EagerSingleton.Instance;

        Console.WriteLine("Adding servers...");
        Console.WriteLine($"Server added: {singleton.AddServer("http://example.com")}");
        Console.WriteLine($"Server added: {singleton.AddServer("https://example.org")}");
        Console.WriteLine($"Server added: {singleton.AddServer("ftp://example.net")}");
        Console.WriteLine($"Server added: {singleton.AddServer("http://example.com")}");

        Console.WriteLine("\nHTTP Servers:");
        List<string> httpServers = singleton.GetHttpServers();
        foreach (string server in httpServers)
        {
            Console.WriteLine(server);
        }

        Console.WriteLine("\nHTTPS Servers:");
        List<string> httpsServers = singleton.GetHttpsServers();
        foreach (string server in httpsServers)
        {
            Console.WriteLine(server);
        }
    }
}