using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recovery.LIB
{
    public enum TypeDevice
    {
        Flash, DVD, HDD
    }

    class ServiceStorage
    {
        public static List<Flash> Flashes;
        public static List<HDD> HDDs;
        public static List<DVD> DVDs;

        public ServiceStorage()
        {
            Flashes = new List<Flash>();
            HDDs = new List<HDD>();
            DVDs = new List<DVD>();
        }
        public static void AddFlash(Flash flash)
        {
            Flashes.Add(flash);
        }
        public static void AddHDD(HDD hdd)
        {
            HDDs.Add(hdd);
        }
        public static void AddDVD(DVD dvd)
        {
            DVDs.Add(dvd);
        }

        public static double totalMemory;
        public static double totalFreeMemory;

        public static double GetMemoryDevice()
        {
            totalMemory = Flashes.Sum(s => s.GetMemory());
            Console.WriteLine("Объем всех носителей = {0}", totalMemory);
            return totalMemory;
        }
        public static double GetFreeMemoryDevice()
        {
            totalFreeMemory = Flashes.Sum(s => s.GetFreeMemory());
            Console.WriteLine("Объем свободного пространства всех носителей = {0}", totalFreeMemory);
            return totalFreeMemory;
        }
        public static void GetCountDevice(TypeDevice typeDevice, double sizeData)
        {
            double total = 0;
            switch (typeDevice)
            {
                case TypeDevice.Flash:
                    {
                        int i = 1;
                        foreach (Flash item in Flashes)
                        {
                            total = Math.Floor(sizeData / item.Memory);
                            if (total == 0)
                                total++;
                            Console.WriteLine("{0}. {1} ({2}) - {3}Mb \t - {4}штук",
                                i++, item.Name, item.Model, item.Memory, total);
                        }
                        Console.WriteLine("Введите тип флешки");
                        i = Int32.Parse(Console.ReadLine());
                        GetTimeToCopy(typeDevice, i, sizeData);
                    }
                    break;
                case TypeDevice.HDD:
                    {

                    }
                    break;
                case TypeDevice.DVD:
                    {

                    }
                    break;
            }
        }
        public static void GetTimeToCopy(TypeDevice typeDevice,int choise,double sizeData)
        {
            switch(typeDevice)
            {
                case TypeDevice.Flash:
                    {

                    }
                    break;
                case TypeDevice.HDD:
                    {

                    }
                    break;
                case TypeDevice.DVD:
                    {

                    }
                    break;
            }
        }
    }
}
