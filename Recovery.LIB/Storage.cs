using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recovery.LIB
{
    public enum TypeDVD { SimpleSide = 5, DoubleSide = 9 }
    public enum TypeUSB { USB1 = 12, USB2 = 480, USB3 = 5000 }
    public abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public abstract double GetMemory();
        public abstract double GetFreeMemory();
        public abstract bool CopyData(double memoryData);
        public virtual void StorageInfo()
        {
            Console.WriteLine("_________________");
            Console.WriteLine("Наименование: \t{0}", Name);
            Console.WriteLine("Модель: \t{0}", Model);
            Console.WriteLine("_________________");
        }
        protected abstract TimeSpan GetTimeToCopy(double memoryData);
    }
}
