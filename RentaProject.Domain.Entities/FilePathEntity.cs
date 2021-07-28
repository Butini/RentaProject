using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Domain.Entities
{
    public class FilePathEntity
    {
        public string Path { get; set; }

        public FilePathEntity(string path)
        {
            Path = path;
        }

        public override bool Equals(object obj)
        {
            return obj is FilePathEntity manager &&
                   Path == manager.Path;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Path);
        }
    }
}
