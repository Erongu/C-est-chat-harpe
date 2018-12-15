using Controller.Network.Server;
using Model.Network.Protocol;
using Model.Network.Protocol.Identification;
using Model.Network.Protocol.Salle;
using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Model.Network
{
    public class NetworkClient : IDisposable
    {
        public Socket Socket
        {
            get;
            private set;
        }

        public string IP
        {
            get;
            private set;
        }
        public BufferPool Buffer
        {
            get;
            private set;
        }

        public bool Connected
        {
            get { return Socket != null && Socket.Connected; }
        }


        public NetworkClient(Socket socket)
        {
            Socket = socket;
            IP = ((IPEndPoint)socket.RemoteEndPoint).Address.ToString();
            Buffer = new BufferPool();

            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            Send(new PingMessage(unixTimestamp));

            ResumeReceive();
        }




        private void ResumeReceive()
        {
            if (!Connected)
                return;

            SocketAsyncEventArgs socketArgs = new SocketAsyncEventArgs();

            socketArgs.SetBuffer(Buffer.Data, 0, Buffer.Data.Length);
            socketArgs.UserToken = this;
            socketArgs.Completed += ProcessReceive;

            var willRaiseEvent = Socket.ReceiveAsync(socketArgs);
            if (!willRaiseEvent)
            {
                ProcessReceive(this, socketArgs);
            }
        }

        private void ProcessReceive(object sender, SocketAsyncEventArgs args)
        {
            try
            {
                args.Completed -= ProcessReceive;
                var bytesReceived = args.BytesTransferred;

                if (args.LastOperation != SocketAsyncOperation.Receive || bytesReceived == 0)
                {
                    Disconnect();
                    return;
                }

                var message = MessageHandler.Read(Buffer.Data);

                HandleMessage(message);

                Buffer.ResetBuffer();

                ResumeReceive();
            }
            catch
            {

            }
        }

        public void Send(byte[] data)
        {
            if (!Connected)
            {
                return;
            }

            Socket.Send(data);
        }
        public void Send(Message message)
        {
            Send(MessageHandler.Write(message));
        }

        private void HandleMessage(Message message)
        {
            LogController.Instance.Network($"RCV: {message.GetType().Name}");

            switch (message.MessageId)
            {
                case PongMessage.Id:
                    var crtl = message as PongMessage;
                    break;
                case CommandeMessage.Id:
                    var cm = message as CommandeMessage;
                    //LogController.Instance.Debug($" {cm.Plats.Count} plats / {cm.Tables.Count} tables");
                    LogController.Instance.Debug($" {cm.Plats.Count} plats");
                    //cm.Plats ===>Pour le cuisinier
                    break;
            }


        }

        protected virtual void Dispose()
        {
            NetworkController.Instance.OnClientDisconnected(this);

            GC.SuppressFinalize(this);

            if (Connected)
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();
            }
        }

        public void Disconnect()
        {
            Dispose();
        }

        ~NetworkClient()
        {
            Dispose();
        }

        void IDisposable.Dispose()
        {
            Dispose();
        }


    }
}
