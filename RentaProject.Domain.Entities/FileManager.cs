using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Domain.Entities
{
    public class FileManager
    {
        public string MyFile { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FileManager manager &&
                   MyFile == manager.MyFile;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MyFile);
        }
    }
}
