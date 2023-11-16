using System;
using Hl5ugc.Tools;
using Hl5ugc.Extensions;

namespace Hl5ugcTest // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            LogManager log = new LogManager("Samjin_",null);
 
            log.Write("[Beging Processing] -----------\n");

            for(int index = 0; index < 10; index++)
            {
                log.WriteLine("Processing :" + index);
                //
                // Todo
                System.Threading.Thread.Sleep(1000);

                log.WriteLine("Done :" + index);
            }

            log.Write("[End Processing] -----------");
            */
            // Test Method Extension 
            string temp = "";
            Console.WriteLine("Is Numberic ?  " + temp.IsNumberic());
            Console.WriteLine("Is DateTime ?  " + temp.IsDateTime());
        }
    }
    /*
    // 확장 메소드
    public static class ExtensionTest
    {
        public static void WriteConsole(this LogManager log,string data) 
        {
            log.WriteLine(data);
            Console.WriteLine(data);
        }
    }
    */
}
