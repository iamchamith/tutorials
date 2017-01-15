using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMATIONS.Service
{
    public interface ILocalWettherServiceProvider
    {
        string GetTemprage(string cityLocation);
    }

    public class LocalWettherServiceProvider : ILocalWettherServiceProvider
    {
        public string GetTemprage(string cityLocation)
        {
            return "it is 25 in"+ cityLocation;
        }
    }
}
