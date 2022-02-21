using LobbyWars.Core.Models;
using LobbyWars.Core.Services;
using LobbyWars.ServiceLibrary.Services;
using System.Collections.Generic;
using Xunit;

namespace LobbyWars.ServiceLibraryTestUnit
{
    public class RolesServiceTest
    {
        private IRoleService _roleService = new RolesService();

        [Fact]
        public void GetListOfRolesFromString()
        {
            string roles = "KNV";
            var listRoles = _roleService.GetListOfRoles(roles);
            int count = 0;
            foreach (var rol in listRoles)
            {
                Assert.True(roles[count].Equals(rol.Role));
                count++;
            }
        }

        [Fact]
        public void GetValueForRole()
        {
            char role = 'K';
            int valueRole = _roleService.GetValueFromRoles(role);
            Assert.True(5 == valueRole);
        }

        [Fact]
        public void ConvertListRolesToString()
        {
            List<Roles> roles = new List<Roles>();
            roles.Add(new Roles(){ Role = 'K', Value = 5});
            roles.Add(new Roles() { Role = 'N', Value = 2 });
            string listRole = _roleService.ConvertListToString(roles);
            Assert.Equal("KN", listRole);
        }

        [Fact]
        public void ValidateListRoles()
        {
            List<Roles> roles = new List<Roles>();
            roles.Add(new Roles() { Role = 'K', Value = 5 });
            roles.Add(new Roles() { Role = '#', Value = 0 });
            Assert.True(_roleService.ValidateRoles(roles));
        }
    }
}