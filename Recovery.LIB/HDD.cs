using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recovery.LIB
{
    class HDD : Storage
    {
        public static int Hcounter = 0;
        public TypeUSB TypeUSB { get; set; }
        public int PartitionCount { get; set; }
        public double PartitionCapacity { get; set; }
        public double Memory { get; set; }
        public double FreeMemory { get; set; }

        public HDD() : this(TypeUSB.USB1, 0, 0.0) { }
        public HDD(TypeUSB TypeUSB, int PartitionCount, double PartitionCapacity)
        {
            this.TypeUSB = TypeUSB;
            this.PartitionCount = PartitionCount;
            this.PartitionCapacity = PartitionCapacity;
            Memory = PartitionCount * PartitionCapacity;
            FreeMemory = PartitionCount * PartitionCapacity;
            Hcounter++;
        }
        public override double GetMemory()
        {
            return Memory;
        }
        public override double GetFreeMemory()
        {
            return FreeMemory;
        }
        public override bool CopyData(double memoryData)
        {
            if (GetFreeMemory() >= memoryData)
            {
                FreeMemory -= memoryData;
                for (int i = 0; i < GetTimeToCopy(memoryData).Minutes; i++)
                {
                    Thread.Sleep(GetTimeToCopy(memoryData).Seconds);
                    Console.WriteLine(".");
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
            return TimeSpan.FromSeconds(memoryData / (int)TypeUSB);
        }
    }
}
