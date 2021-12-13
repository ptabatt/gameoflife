using GameOfLifeLib;
using System;
using System.Threading;

namespace GameOfLifeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            
            Console.ReadLine();
        }

        static void Start()
        {
            var objGOL = new GameOfLifeCore(25, 25);

            objGOL.SetGlider();

            var iFrames = 100;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (iFrames > 0)
            {
                objGOL.PrintStateOfLife();
                objGOL.LiveLifeSegment();
                Thread.Sleep(1000);
                Console.Clear();

                iFrames--;
            }
        }
    }
}
