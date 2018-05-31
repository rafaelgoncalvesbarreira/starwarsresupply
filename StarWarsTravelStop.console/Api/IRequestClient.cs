using System.Collections.Generic;
using StarWarsTravelStop.console.Model;

namespace StarWarsTravelStop.console.Api
{
    public interface IRequestClient
    {
        List<Starship> GetAllStarships();
    }
}