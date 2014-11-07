using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging
{
    public class Program
    {
        /// <summary>
        /// Author: Nam-Truong
        /// Email: ptnknamhcm@gmail.com
        /// Note: Have fun with coding! :)
        /// </summary>
        public static void Main()
        {
            string s = string.Empty;
            Console.WriteLine("Enter your message below:");
            while (true)
            {

                s = Console.ReadLine();
                Logging.Log("C:\\Log", DateTime.Now.ToString("ddMMyyyy"), Logging.INFOR, s);
            }
        }
    }
}
