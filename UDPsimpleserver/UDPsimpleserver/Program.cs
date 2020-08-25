/*
 * Created by SharpDevelop.
 * User: user
 * Date: 8/14/2020
 * Time: 12:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPsimpleserver
{
	class Program
	{

        public static void Main()
        {
            Console.WriteLine("Which port do you want to use?");
            int portnumber = Int32.Parse(Console.ReadLine());
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, portnumber);//port 4444 and 5000 where the originals.
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("Waiting for a client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            data = newsock.Receive(ref sender);

            Console.WriteLine("Message received from {0}:", sender.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            string welcome = "Welcome to my test server";
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.Send(data, data.Length, sender);

            while (true)
            {
                data = newsock.Receive(ref sender);

                Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
                newsock.Send(data, data.Length, sender);
            }
        }

    }
}