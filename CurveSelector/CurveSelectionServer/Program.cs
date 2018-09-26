using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace CurveSelectionServer
{
    class Program
    {
        /// <summary>
        /// Entry to the server
        /// </summary>
        static void Main(string[] args)
        {
            SocketServer socketServer = new SocketServer();
            try
            {
                //Loads all the data from the text file to a datatable
                var curveDataTable = new DataTable {TableName = "CurveTable"};
                curveDataTable = ReadDataFromFile();
                
                //Starts the server
                socketServer.StartServerAsync(curveDataTable);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.ReadLine();
            }          
        }
        ///<summary>
        ///Load data from csv file
        ///</summary>
        static DataTable ReadDataFromFile()
        {
            var dtTable = new DataTable();
            var fileContents = File.ReadAllLines(Settings.DataFilePath);
            var splitContents = (from f in fileContents select f.Split(',')).ToArray();
            int maxLength = (from s in splitContents select s.Count()).Max();
            //Load Heading
            for (int i = 0; i < maxLength; i++)
            {
                dtTable.Columns.Add(splitContents[0][i].Trim(),typeof(string));
            }

            //Load Data
            bool firstRow = true;
            foreach (var line in splitContents)
            {
                if (firstRow)
                {
                    firstRow = false;
                    continue;
                }
 
                DataRow row = dtTable.NewRow();
                row.ItemArray = (object[])line;
                dtTable.Rows.Add(row);
            }
            return dtTable;
        }
    }
}
