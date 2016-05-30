using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace MessageGeneratorApp.Helpers
{
    [Synchronization]
    public class StringHelper
    {
        private const string availableChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
        
        private static Mutex mutex = new Mutex();

        static Random rd = new Random();

        internal static string CreateString(int number)
        {
            var message = string.Empty;
            var length = rd.Next(5, 10);

            try
            {
                mutex.WaitOne();
                Console.WriteLine("{0} has entered in the Domain", number);
                char[] chars = new char[length];

                for (int i = 0; i < length; i++)
                {
                    chars[i] = availableChars[rd.Next(0, availableChars.Length)];
                }

                message = new string(chars);
                Console.WriteLine("{0} Message generated: {1}\r\n", number, message);

            }
            catch
            {
            }
            finally
            {
                mutex.ReleaseMutex();
            }

            return message;
        }
        
    }
}
