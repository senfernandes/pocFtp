﻿using System;

namespace pocFtp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sending File to FTP server");
            SendFileToServer.Send("test_file.txt");
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
