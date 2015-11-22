using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatelliteSimulatorGUI
{
    static class Program
    {
        static SerialPort _serialPort;
        static bool _continue;
        static string acknowlegement;
        static string report;
        static Thread readThread;
        static bool acknowlegementReceived;
        static List<byte> bytes = new List<byte>();
        public static bool connectionStatus
        {
            get; set;
        }
        
        
        [STAThread]
        static void Main()
        {
            _serialPort = new SerialPort();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Layout());

            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

        }

        public static void connectToCOMPort()
        {
            //Set the settings
            //PortName is set when connect is clicked.
            _serialPort.BaudRate = 9600;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            readThread = new Thread(Read);
            _serialPort.Open();

            connectionStatus = true;

            readThread.Start();

            _continue = true;

        }

        public static string getAcknowledgement()
        {
            return acknowlegement;
        }

        public static string getReport()
        {
            return report;
        }

        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        bytes.Add((byte) _serialPort.ReadByte());
                    }

                    if (acknowlegementReceived == false && bytes.Count == 7)
                    {
                        acknowlegement = ByteArrayToString(bytes.ToArray());
                        acknowlegementReceived = true;
                        bytes.Clear();
                    } else if (bytes.Count > 7)
                    {
                        report = ByteArrayToString(bytes.ToArray());
                        acknowlegementReceived = false;
                        bytes.Clear();
                    }
                }
                catch (TimeoutException) { }
            }
        }

        public static void setPortName(string portName)
        {
            _serialPort.PortName = portName;
        }

        public static void Write(byte[] command)
        {
            _serialPort.Write(command, 0, 6);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("0x{0:x2} ", b);
                
            return hex.ToString();
        }
    }
}
