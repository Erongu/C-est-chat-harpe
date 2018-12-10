using Model.Network;
using Model.Network.Protocol;
using Model.Network.Protocol.Identification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Network.Client
{
    public class Client
    {
        private Socket m_socket;
        private BufferPool Buffer { get; set; }
        public bool Connected
        {
            get { return m_socket != null && m_socket.Connected; }
        }

        public Client()
        {
            Buffer = new BufferPool();
        }

        public void Connect(string ip, int port)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var args = new SocketAsyncEventArgs();

            args.Completed += OnConnected;
            args.AcceptSocket = m_socket;
            args.RemoteEndPoint = new DnsEndPoint(ip, port);

            if (!m_socket.ConnectAsync(args))
                OnConnected(this, args);
        }
        public void Send(byte[] data)
        {
            if (!Connected)
            {
                return;
            }

            m_socket.Send(data);
        }

        public void Send(Message message)
        {
            Send(MessageHandler.Write(message));
        }

        private void OnConnected(object sender, SocketAsyncEventArgs e)
        {
            e.Completed -= OnConnected;
            e.Dispose();

            Console.WriteLine("[Client] Connected !");

            ResumeReceive();
        }

        private void ResumeReceive()
        {
            if (!Connected)
                return;

            var socketArgs = new SocketAsyncEventArgs();

            socketArgs.SetBuffer(Buffer.Data, 0, Buffer.Data.Length);
            socketArgs.UserToken = this;
            socketArgs.Completed += ProcessReceive;

            var willRaiseEvent = m_socket.ReceiveAsync(socketArgs);
            if (!willRaiseEvent)
            {
                ProcessReceive(this, socketArgs);
            }
        }
        private void ProcessReceive(object sender, SocketAsyncEventArgs args)
        {
            try
            {
                var bytesReceived = args.BytesTransferred;

                if (bytesReceived == 0)
                {
                    Disconnect();
                }
                else
                {
                    var message = MessageHandler.Read(Buffer.Data);
                    HandleMessage(message);

                    Buffer.ResetBuffer();

                    ResumeReceive();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Client] Error receiving");

                Disconnect();
            }
            finally
            {
                args.Completed -= ProcessReceive;
                args.Dispose();
            }
        }
        public void Disconnect()
        {
            if (Connected)
            {
                m_socket.Disconnect(false);
                Console.WriteLine("[Client] Disconnected");
            }
        }

        private void HandleMessage(Message message)
        {
            Console.WriteLine("[Client] Received " + message.GetType().Name);

            switch (message.MessageId)
            {
                case PingMessage.Id:
                    var crtl = message as PingMessage;

                    Console.WriteLine($"  TimeStamp: {crtl.TimeStamp}");

                    Send(new PongMessage(crtl.TimeStamp));
                    break;
            }
        }
    }

}
