using grammerGame.Application.Abstractions.Utilities;
using grammerGame.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.Utilities
{
    public class CustomGuidConverter : ICustomGuidConverter
    {
        private static CustomGuidConverter instance;
        public CustomGuidConverter() { }
        public static CustomGuidConverter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomGuidConverter();
                }
                return instance;
            }
        }

        public string GuidToStringConverter(int guid) => guid.ToString();
    

        public int StringToGuidConverter(string str)
        {
            if (int.TryParse(str, out int parsedId))
                return parsedId;
            else
                throw new IdParseErrorException();
        }
    }
}
