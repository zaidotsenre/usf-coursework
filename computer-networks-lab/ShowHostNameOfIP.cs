/*
 * This is a C# Program which displays the Host Name of an input IP address.
 * Written by Ernesto Diaz
 */

using System;
using System.Net;

namespace CNT4104L
{
    class ShowHostNameOfIP
    {
        static void Main()
        {
		// Get input from user
        	Console.Write("Enter an IP address (eg., 131.247.2.211):   ");
		String ipAddressStr = Console.ReadLine();

		// Create IPAddress object and get the corresponding host entry
		IPAddress ipAddress = IPAddress.Parse(ipAddressStr);
		IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
		
		// Print the input IP and its hostname
		Console.Write("Host name of " + ipAddressStr + " is: " + hostEntry.HostName);
        }
    }
}