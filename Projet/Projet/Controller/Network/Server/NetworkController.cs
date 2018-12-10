using Model.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Controller.Network.Server
{
    public class NetworkController
    {
        private readonly Socket m_listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private readonly SocketAsyncEventArgs m_acceptArgs = new SocketAsyncEventArgs(); // async arg used on client connection

        private static NetworkController m_instance;
        private List<NetworkClient> m_clients = new List<NetworkClient>();

        public static NetworkController Instance // SINGLETON
        {
            get
            {
                if (m_instance == null)
                    m_instance = new NetworkController();

                return m_instance;
            }
        }

        public NetworkController()
        {

        }

        public void Start(string host, int port)
        {
            var ipEndPoint = new IPEndPoint(Dns.GetHostAddresses(host).First(ip => ip.AddressFamily == AddressFamily.InterNetwork), port);

            m_listenSocket.NoDelay = true;
            m_listenSocket.Bind(ipEndPoint);
            m_listenSocket.Listen(100);

            StartAccept();

            m_acceptArgs.Completed += (sender, e) => ProcessAccept(e);
        }

        private void StartAccept()
        {
            m_acceptArgs.AcceptSocket = null;

            if (!m_listenSocket.AcceptAsync(m_acceptArgs))
            {
                ProcessAccept(m_acceptArgs);
            }
        }

        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            NetworkClient client = null;

            try // Il peut arriver beaucoup de chose pendant l'acceptation d'un client, un try catch rendra le truc très safe, un serveur ne doit jamais avoir d'erreur.
            {
                client = new NetworkClient(e.AcceptSocket);

                lock (m_clients)
                    m_clients.Add(client);

                OnClientConnected(client);
            }
            catch
            {
                Console.WriteLine("Error when accepting client");
            }
            finally
            {
                StartAccept();
            }
        }

        private void OnClientConnected(NetworkClient client)
        {
            Console.WriteLine("[Server] New client connected !");
        }

        public void OnClientDisconnected(NetworkClient client)
        {
            bool removed;
            lock (m_clients)
                removed = m_clients.Remove(client);

            if (!removed)
                return;

            Console.WriteLine("[Server] Client disconnected !");
        }
    }
}
