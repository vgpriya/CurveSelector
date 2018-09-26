using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurveSelectionClient
{
    /// <summary>
    /// Hide and Show Curve A in the grid
    /// </summary>
    public class SocketClient
    {   
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream;

        /// <summary>
        /// Connect to the server
        /// </summary>
        public void Connect(string ipAddress, int port)
        {
            clientSocket.Connect(ipAddress, port);
        }

        /// <summary>
        /// Connect to the server
        /// </summary>
        public bool Connected()
        {
            return clientSocket.Connected;
        }
        /// <summary>
        /// Send data to server
        /// </summary>
        public void Send(List<string> data)
        {
            try
            {
                serverStream = clientSocket.GetStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(serverStream, data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }           
        }
        /// <summary>
        /// Receive data from server
        /// </summary>
        public string Receive()
        {
            try
            {
                byte[] inStream = new byte[70000];
                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                return returndata;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }        
        }
        /// <summary>
        /// Close client connection
        /// </summary>
        public void Close()
        {
            clientSocket.Close();
        }            
    }
}
