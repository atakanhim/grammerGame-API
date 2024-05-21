using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.Abstractions.Utilities
{
    public interface ICustomGuidConverter
    {
        int StringToGuidConverter(string str);
        string GuidToStringConverter(int guid);
    }
}
