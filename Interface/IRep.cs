using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather_info.DataModel;

namespace weather_info.Interface
{
    public interface IRep<T>
    {
        void Create();

        void Add();

        int Counter();

        void PrintTable();

        void Clear();

    }
}
