using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Interaction;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new Host();
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();
            //gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => Console.WriteLine("X: {0} Y:{1}", gazePointX, gazePointY));
            
            // Initialize Fixation data stream.
            var fixationDataStream = host.Streams.CreateFixationDataStream();

            // Because timestamp of fixation events is relative to the previous ones
            // only, we will store them in this variable.
            var fixationBeginTime = 0d;

            gazePointDataStream.Next += (o, datation) =>
            {
                var fixationPointX = datation.Data.X;
                var fixationPointY = datation.Data.Y;
                if(fixationPointX > 930.0)
                {
                    if(fixationPointY > 496.0)
                    {
                        //Console.WriteLine("Right - Down X: {0}, Y: {1}", fixationPointX, fixationPointY);
                        Console.WriteLine("Cantaloupe");
                    }
                    else
                    {
                        //Console.WriteLine("Right - Up X: {0}, Y: {1}", fixationPointX, fixationPointY);
                        Console.WriteLine("Carrot");
                    }
                    
                } else
                {
                    if (fixationPointY > 496.0)
                    {
                        //Console.WriteLine("Left - Down X: {0}, Y: {1}", fixationPointX, fixationPointY);
                        Console.WriteLine("Apple");
                    }
                    else
                    {
                        //Console.WriteLine("Left - Up X: {0}, Y: {1}", fixationPointX, fixationPointY);
                        Console.WriteLine("Strawberry");
                    }
                }
            };
            Console.ReadKey();
            // we will close the coonection to the Tobii Engine before exit.
            host.DisableConnection();
        }
    }
}
