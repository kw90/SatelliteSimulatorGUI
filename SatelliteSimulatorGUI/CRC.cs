using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteSimulatorGUI
{
    class CRC
    {
        public static ushort crc16(byte[] bytes)
        {
            ushort crc = 0x00;
            foreach (byte b in bytes)
            {
                crc ^= (ushort)(b << 8);

                for (byte bit = 8; bit > 0; bit--)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc = (ushort)((crc << 1) ^ 0x8005);
                    } else
                    {
                        crc = (ushort)(crc << 1);
                    }
                }
            }

            return crc;
        }
    }
}
