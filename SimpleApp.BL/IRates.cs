using System.Collections.Generic;

namespace SimpleApp.BL
{
    internal interface IRates
    {
        List<RateModel> Load();
    }
}