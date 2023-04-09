using GeometryShapes.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShapes
{
    public interface IFileManager
    {
        List<Shape> Load(string fileName);
        void Save(List<Shape> json, string fileName);
    }
}
