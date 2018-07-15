using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recovery.LIB
{
    class DVD : Storage
    {
        public static int Dcounter = 0;
        public TypeDVD TypeDVD { get; set; }
        public double ReadSpeed { get; set; }
        public double WriteSpeed { get; set; }
        public double FreeMemory { get; set; }


        public DVD() : this(TypeDVD.SimpleSide, 0, 0) { }

        public DVD(TypeDVD TypeDVD, double ReadSpeed, double WriteSpeed)
        {
            this.TypeDVD = TypeDVD;
            this.ReadSpeed = ReadSpeed;
            this.WriteSpeed = WriteSpeed;
            FreeMemory = (int)TypeDVD;
            Dcounter++;
        }

        public override double GetMemory()
        {
            return (double)TypeDVD;
        }
        public override double GetFreeMemory()
        {
            return FreeMemory;
        }
        public override bool CopyData(double memoryData)
        {
            if (GetFreeMemory() >= memoryData)
            {
                if (TypeDVD == TypeDVD.SimpleSide)
                {
                    for (int i = 0; i < GetTimeToCopy(memoryData).Minutes; i++)
                    {
                        Thread.Sleep(GetTimeToCopy(memoryData).Seconds);
                        Console.WriteLine(".");
                    }
                }
                else
                {
                    for (int i = 0; i < GetTimeToCopy(memoryData).Minutes / 2; i++)
                    {
                        Thread.Sleep(GetTimeToCopy(memoryData).Seconds);
                        Console.WriteLine(".");
                    }
                    Console.WriteLine("Переворачиваем диск");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Переворачиваем диск.");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Переворачиваем диск..");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Переворачиваем диск...");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Переворачиваем диск");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Переворачиваем диск.");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Переворачиваем диск..");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Переворачиваем диск...");
                    Thread.Sleep(500);
                    Console.Clear();
                    for (int i = 0; i < GetTimeToCopy(memoryData).Minutes / 2; i++)
                    {
                        Thread.Sleep(GetTimeToCopy(memoryData).Seconds);
                        Console.WriteLine(".");
                    }
                }
                Console.WriteLine("\nCopied successful!");
                return true;
            }
            else
            {
                Console.WriteLine("{0} не хватает свободного пространства для носителя с объемом {1}", memoryData, GetMemory());
                return false;
            }
        }
        protected override TimeSpan GetTimeToCopy(double memoryData)
        {
            TimeSpan ts = new TimeSpan();
            return TimeSpan.FromSeconds(memoryData / WriteSpeed + ReadSpeed);
        }
    }
}
