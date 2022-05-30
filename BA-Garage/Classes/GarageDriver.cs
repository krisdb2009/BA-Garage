using System.Net.Sockets;
using System.Net;

namespace BA_Garage
{
    public static class GarageDriver
    {
        public static UdpClient UdpClient = new UdpClient();
        public static void Trigger(byte RelayIndex)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.RelayIP), 60000);
            byte onWithIndex = (byte)((RelayIndex << 1) | 0b00000001);
            UdpClient.Send(new byte[] { 0xff, 0xaa, 0x0, 0x3, 0x0, 0x0, onWithIndex }, 7, ipe);
        }
    }
}