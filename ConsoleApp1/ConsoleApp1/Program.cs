using System;
using System.Threading;
namespace ConsoleApp1
{
    delegate void delPing(string message);
    delegate void delPong(string message2);
    class Ping
    {

        public event delPing PingMaker;
        public void Display()
        {

            PingMaker?.Invoke("Ping");

        }

        public void ReceivePong()
        {
            Console.WriteLine("Ping received Pong");
        }
    }
    class Pong
    {

        public event delPong PongMaker;
        public void Display()
        {

            PongMaker?.Invoke($"Pong");

        }

        public void ReceivePing()
        {
            Console.WriteLine("Pong received Ping");
        }
    }
    class Program
    {
        static Ping ping = new Ping();
        static Pong pong = new Pong();
        public static int Random()
        {
            Random random = new Random();
            int num = random.Next(10);
            return num;

        }
        static void Main(string[] args)
        {
            int num = Random();
            Console.WriteLine(num);

            ping.PingMaker += PingPongHandler;
            pong.PongMaker += PingPongHandler;

            //do
            //{

            //    ping.PingMaker += PingPongHandler ;
            //    ping.Display();
            //    i++;
            //    do
            //    {
            //        pong.PongMaker += PingPongHandler ;
            //        pong.Display();
            //        j++;
            //    }
            //    while(j  <= Random());
            //}
            //while (i <= Random());

            for (int i = 0; i < num; i++)
            {
                if (i % 2 == 0)
                    ping.Display();
                else
                    pong.Display();
            }
            if (num % 2 == 0)
                Console.WriteLine($"Ping wins");
            else
                Console.WriteLine($"Pong wins");

            Console.ReadKey();
        }



        static void PingPongHandler(string message)
        {
            if (message.Equals("Ping"))
            {
                pong.ReceivePing();
                Thread.Sleep(1000);
            }
            else
            {
                ping.ReceivePong();
                Thread.Sleep(1000);
            }
        }

    }

}
