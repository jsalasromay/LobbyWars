using LobbyWars.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.Core.Services
{
    public interface IRoleService
    {
        List<Roles> GetListOfRoles(string roles);
        int GetValueFromRoles(char role);
    }
}
