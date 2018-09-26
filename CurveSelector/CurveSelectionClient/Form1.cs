using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace CurveSelectionClient
{
    public partial class Form1 : Form
    {
        private SocketClient socketClient = new SocketClient();
        private ExportData exportData =new ExportData();
        private List<string> curveSelected;
        bool recieveData = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            exportData.ExportList = new List<Dictionary<string, string>>();
            exportData.MinCurve = new Dictionary<string, string>();
            exportData.MaxCurve = new Dictionary<string, string>();
        }
        /// <summary>
        /// Click to Connect to the server
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            socketClient.Connect(Settings.IpAddress, Settings.TcpPort);
            label1.Text = "Client Connected to the Server...";
        }
        /// <summary>
        /// Returns the list of Curves which are selected
        /// </summary>
        private List<string> CurvesChecked()
        {
            var curveCheckedList = new List<string>();
            
            if (chkCurveA.Checked)
            {
                curveCheckedList.Add("A");
            }          
            if (chkCurveA2.Checked)
            {
                curveCheckedList.Add("A2");
            }
            if (chkCurveB.Checked)
            {
                curveCheckedList.Add("B");
            }
            if (chkCurveC.Checked)
            {
                curveCheckedList.Add("C");
            }
            return curveCheckedList;
        }
        /// <summary>
        /// Click to Load the data in the grid
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (socketClient.Connected() == false)
                {
                    MessageBox.Show("Connect to the server and continue!!!");
                    return;
                }
                if (chkCurveA.Checked == false && chkCurveA2.Checked == false && chkCurveB.Checked == false &&
                    chkCurveC.Checked == false)
                {
                    MessageBox.Show("Choose atleast one of the curves and continue!!!");
                    return;
                }
                /***********************************/
                //Send the selected curves to the server,
                //to fetch the data for the selected curves 
                curveSelected = CurvesChecked();             
                socketClient.Send(curveSelected);
                /************************************/
             

                //Recieve the row count from the server
                string returndata = socketClient.Receive();
                int recordCount = Convert.ToInt32(returndata.Substring(0, returndata.IndexOf("##")));

               
                int i = 0;
                
                while (recieveData)
                {
                    //if "i" reaches recordcount no need to fetch data again from server, so break the loop.
                    if (i == recordCount)
                        break;

                    //Iterate to get the rows each time the data is send from server
                    returndata = socketClient.Receive();
                    if (returndata == string.Empty)
                    {
                        recieveData = false;
                        break;
                    }

                    Console.WriteLine("RETURN DATA:"+returndata+"****");

                    //At the end of each data '$' is appended to know the end of the record
                    var splitArray = returndata.Split('$').Select(p => p.Trim()).ToArray();
                    for (int k = 0; k < splitArray.Length; k++)
                    {   
                        if (splitArray[k] == string.Empty)
                            continue;
                        
                        //Stream may contain junk values, to avoid that at the end of each row string '@' is attached
                        var curveElement = splitArray[k].Substring(0, splitArray[k].IndexOf("@"));
                        Console.WriteLine("SPLITDATA"+ curveElement + "SPLITADAT");
                        XElement rootElement = XElement.Parse(curveElement);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        //Parse the elements and store it in a dictionary
                        foreach (var el in rootElement.Elements())
                        {
                            dict.Add(el.Name.LocalName, el.Value);
                        }
                        
                        //Creates a new row and add the elements to the grid.
                        DataGridViewRow row = (DataGridViewRow)grdCurve.Rows[i].Clone();
                        row.Cells[0].Value = dict["index"];
                        if (chkCurveA.Checked)
                        {
                            row.Cells[1].Value = dict["A"];
                            if (i == 0)
                            {
                                exportData.MinCurve["A"]= dict["A"];
                            }
                            else 
                            {
                                exportData.MaxCurve["A"] = dict["A"];
                            }
                        }

                        if (chkCurveA2.Checked)
                        {
                            row.Cells[2].Value = dict["A2"];
                            if (i == 0)
                            {
                                exportData.MinCurve["A2"] = dict["A2"];
                            }
                            else 
                            {
                                exportData.MaxCurve["A2"] = dict["A2"];
                            }
                        }

                        if (chkCurveB.Checked)
                        {
                            row.Cells[3].Value = dict["B"];
                            if (i == 0)
                            {
                                exportData.MinCurve["B"] = dict["B"];
                            }
                            else 
                            {
                                exportData.MaxCurve["B"] = dict["B"];
                            }
                        }

                        if (chkCurveC.Checked)
                        {
                            row.Cells[4].Value = dict["C"];
                            if (i == 0)
                            {
                                exportData.MinCurve["C"] = dict["C"];
                            }
                            else 
                            {
                                exportData.MaxCurve["C"] = dict["C"];
                            }
                        }
                        grdCurve.Rows.Add(row);
                        grdCurve.Update();
                        grdCurve.Refresh();

                        i++;
                        //For exporting we need the list of records currently loaded in the grid.
                        exportData.ExportList.Add(dict);
                        // wait cursor
                        Cursor.Current = Cursors.WaitCursor;        // waiting cursor
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }
        /// <summary>
        /// Hide and Show Curve A in the grid
        /// </summary>
        private void chkCurveA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurveA.Checked)
            {
                this.grdCurve.Columns["CurveA"].Visible = true;
            }
            else
            {
                this.grdCurve.Columns["CurveA"].Visible = false;
            }
        }
        /// <summary>
        /// Hide and Show Curve A2 in the grid
        /// </summary>
        private void chkCurveA2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurveA2.Checked)
            {
                this.grdCurve.Columns["CurveA2"].Visible = true;
            }
            else
            {
                this.grdCurve.Columns["CurveA2"].Visible = false;
            }
        }
        /// <summary>
        /// Hide and Show Curve B in the grid
        /// </summary>
        private void chkCurveB_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurveB.Checked)
            {
                this.grdCurve.Columns["CurveB"].Visible = true;
            }
            else
            {
                this.grdCurve.Columns["CurveB"].Visible = false;
            }
        }
        /// <summary>
        /// Hide and Show Curve C in the grid
        /// </summary>
        private void chkCurveC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurveC.Checked)
            {
                this.grdCurve.Columns["CurveC"].Visible = true;
            }
            else
            {
                this.grdCurve.Columns["CurveC"].Visible = false;
            }
        }
        /// <summary>
        /// Click to Export data to XML
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (exportData.ExportList.Count == 0)
                {
                    MessageBox.Show("Please load the data and continue!!!");
                    return;
                }
                recieveData = false;
                XmlDocument xmlDocument = Extensions.CreateXMLFile(curveSelected, exportData);
                Extensions.DownloadFile(xmlDocument);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            socketClient.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grdCurve.Rows.Clear();
        }
    }
}
