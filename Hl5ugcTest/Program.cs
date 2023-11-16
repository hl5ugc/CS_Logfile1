using System;
using Hl5ugc.Tools; 

namespace Hl5ugcTest // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LogManager log =  new LogManager();
            LogManager log = new LogManager("Samjin_",null);

            log.Write("[Beging Processing] -----------\n");

            for(int index = 0; index < 10; index++)
            {
                log.WriteLine("Processing :" + index);
                //log2.WriteLine("Processing :" + index);
                // Todo
                System.Threading.Thread.Sleep(1000);

                log.WriteLine("Done :" + index);
            }

            log.Write("[End Processing] -----------");
        }
    }
}
