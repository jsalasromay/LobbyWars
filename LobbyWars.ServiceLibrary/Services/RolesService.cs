using LobbyWars.Core.Models;
using LobbyWars.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.ServiceLibrary.Services
{
    public class RolesService : IRoleService
    {
        public List<Roles> GetListOfRoles(string roles)
        {
            List<Roles> listRole = new List<Roles>();
            foreach (char role in roles.ToCharArray())
            {
                listRole.Add(new Roles { Role = role, Value = GetValueFromRoles(role)});
            }
            return listRole;
        }

        public int GetValueFromRoles(char role)
        {
            switch (role)
            {
                case 'K':
                    return 5;
                case 'N':
                    return 2;
                case 'V':
                    return 1;
                default: return 0;
            }
        }
    }
}
