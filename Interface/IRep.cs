using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather_info.Interface
{
    public interface IRep
    {
        void Create();

        void Add();

        int Counter();

        void PrintTable();

        void Clear();
    }
}
