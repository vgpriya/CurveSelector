using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace CurveSelectionServer
{
    public class SocketServer
    {
        TcpListener serverSocket = new TcpListener(Settings.TcpPort);
        TcpClient clientSocket = default(TcpClient);
        private DataTable curveDataTable = new DataTable();

        /// <summary>
        /// Start async connection to server
        /// </summary>
        public async Task StartServerAsync(DataTable curveDataTable)
        {
            try
            {
                serverSocket.Start();
                Console.WriteLine(" >> Server Started");
                
                this.curveDataTable = curveDataTable;
                WaitForClients();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }         
        }
        /// <summary>
        /// Wait for the client to connect to server
        /// </summary>
        private void WaitForClients()
        {
            serverSocket.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnected), null);
        }
        /// <summary>
        /// After the client connection established
        /// </summary>
        private void OnClientConnected(IAsyncResult asyncResult)
        {
            try
            {

                clientSocket = serverSocket.EndAcceptTcpClient(asyncResult);

                if (clientSocket != null)

                    Console.WriteLine("Received connection request from: " + clientSocket.Client.RemoteEndPoint.ToString());

                HandleClientRequest(clientSocket);

            }
            catch(Exception ex)
            {
                throw ex;
            }
            WaitForClients();
        }
        /// <summary>
        /// Handles the request coming from client
        /// </summary>
        private void HandleClientRequest(TcpClient clientSocket)
        {
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] bytesFrom = new byte[70000];
                
                //Get selected Curves from Client
                BinaryFormatter formatter = new BinaryFormatter();
                List<string> selectedCurves = (List<string>)formatter.Deserialize(networkStream);
                CurveDataModel curveDataModel=new CurveDataModel();
                foreach (var curve in selectedCurves)
                {
                    curveDataModel.ColumnValues.Add(curve,"");
                }

                //Send the count of rows in CSV file, to the client
                byte[] outCurveTableCountStream;                 
                outCurveTableCountStream = System.Text.Encoding.ASCII.GetBytes(curveDataTable.Rows.Count+"##");                  
                networkStream.Write(outCurveTableCountStream, 0, outCurveTableCountStream.Length);
                networkStream.Flush();


                int i = 0;

                foreach (DataRow curveDataRow in curveDataTable.Rows)
                {
                    byte[] outStream;
                    var dataSetRow = curveDataRow;
                    
                    //Converts the records in datatable to a dictionary
                    curveDataModel.ColumnValues = (from DataColumn c in curveDataTable.Columns
                        where curveDataModel.ColumnValues.ContainsKey(c.ColumnName) && dataSetRow[c] != DBNull.Value
                        select new KeyValuePair<string, string>(c.ColumnName.Trim(), dataSetRow[c].ToString().Trim())).ToDictionary(x => x.Key, x => x.Value);

                    //Each record is parsed as xml stringS
                    XElement el = new XElement("root", curveDataModel.ColumnValues.Select(kv => new XElement(kv.Key.Trim(), kv.Value.Trim())));
                    
                    //Convert the xml string to bytes
                    if (i > 0)
                    {
                        outStream = System.Text.Encoding.ASCII.GetBytes("$" + el.ToString()+"@");
                    }
                    else
                    {
                        outStream = System.Text.Encoding.ASCII.GetBytes(el.ToString()+"@");
                    }
                    
                    //Sleeps for 1000ms to wait for the client to read each record
                    System.Threading.Thread.Sleep(1000);

                    //Write the records to the stream
                    networkStream.Write(outStream, 0, outStream.Length);
                    networkStream.Flush();
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Stop the connection to the server
        public void StopServer()
        {
            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }
    }
}
