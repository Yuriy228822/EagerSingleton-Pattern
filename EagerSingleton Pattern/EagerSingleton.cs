using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerSingleton_Pattern
{
    public sealed class EagerSingleton
    {
        private static readonly EagerSingleton instance = new EagerSingleton();
        private readonly List<string> servers = new List<string>();
        private readonly object lockObject = new object();

        // Private constructor to prevent instantiation.
        private EagerSingleton()
        {
        }

        public static EagerSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        public bool AddServer(string server)
        {
            lock (lockObject)
            {
                if (!servers.Contains(server) && (server.StartsWith("http://") || server.StartsWith("https://")))
                {
                    servers.Add(server);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<string> GetHttpServers()
        {
            lock (lockObject)
            {
                List<string> httpServers = new List<string>();
                foreach (string server in servers)
                {
                    if (server.StartsWith("http://"))
                    {
                        httpServers.Add(server);
                    }
                }
                return httpServers;
            }
        }

        public List<string> GetHttpsServers()
        {
            lock (lockObject)
            {
                List<string> httpsServers = new List<string>();
                foreach (string server in servers)
                {
                    if (server.StartsWith("https://"))
                    {
                        httpsServers.Add(server);
                    }
                }
                return httpsServers;
            }
        }
    }
}
