using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatelliteSimulatorGUI
{
    public partial class Layout : Form
    {
        byte[] commandToSend;

        public Layout()
        {
            InitializeComponent();
            availableCommands.Items.Add("Check temperature from board");
        }

        private void connectClicked(object sender, EventArgs e)
        {
            Program.setPortName(portName.SelectedItem.ToString());
            Program.connectToCOMPort();
            if (Program.connectionStatus == true)
            {
                connectionStatusLabel.Text = "Connected to board";
                connectionStatusLabel.BackColor = Color.Green;
            }
        }

        private void checkPortNames(object sender, EventArgs e)
        {
            //Get all COM Ports that are connected
            foreach (string s in SerialPort.GetPortNames())
            {
                this.portName.Items.Add(s);
            }
        }

        private void updateCommand(object sender, EventArgs e)
        {
            //Get temperature
            if (availableCommands.SelectedIndex == 0)
            {
                commandToSend = generatePacket(0, getTemperatureRequestBytes());
            }
        }

        private byte[] generatePacket(int type, byte[] command)
        {
            int headerLength = 3;
            int crc = 2;

            byte[] data = new byte[command.Length + headerLength];
            byte[] dataFinal = new byte[command.Length + headerLength + crc];

            data[0] = (byte) type;
            data[1] = (byte)(((command.Length + crc) & 0xFF00) >> 8);
            data[2] = (byte)((command.Length + crc) & 0xFF);

            for (int i = 0; i < command.Length; i++)
            {
                data[i + headerLength] = command[i];
            }

            Array.Copy(data, dataFinal, data.Length);

            if (crc == 1)
            {
                Trace.TraceError("not implemented crc8");
                //dataFinal[command.Length + headerLength] = CRC.crc8(data);
            }
            else if (crc == 2)
            {
                ushort val = CRC.crc16(data);
                dataFinal[command.Length + headerLength] = (byte)((val & 0xFF00) >> 8);
                dataFinal[command.Length + headerLength + 1] = (byte)(val & 0xFF);
            }
            else if (crc == 4)
            {
                Trace.TraceError("not implemented crc32");
                //int val = CRC.crc32(data);
                //dataFinal[command.Length + headerLength] = (byte)((val & 0xFF000000) >> 24);
                //dataFinal[command.Length + headerLength + 1] = (byte)((val & 0xFF0000) >> 16);
                //dataFinal[command.Length + headerLength + 2] = (byte)((val & 0xFF00) >> 8);
                //dataFinal[command.Length + headerLength + 3] = (byte)(val & 0xFF);
            }

            return dataFinal;
        }

        private byte[] getTemperatureRequestBytes()
        {
            byte[] data = new byte[1];

            data[0] = 1;

            return data;
        }

        private void sendCommandToProgram(object sender, EventArgs e)
        {
            Program.Write(commandToSend);
            Thread.Sleep(200);
            ackBox.Text = Program.getAcknowledgement();
            reportBox.Text = Program.getReport();
        }

        private void COMPortIndexChanged(object sender, EventArgs e)
        {
            connectionStatusLabel.Text = "Not connected.";
            connectionStatusLabel.BackColor = Color.Red;
        }
    }
}
