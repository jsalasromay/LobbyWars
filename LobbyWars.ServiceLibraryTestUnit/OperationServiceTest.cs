using LobbyWars.Core.Models;
using LobbyWars.Core.Services;
using LobbyWars.ServiceLibrary.Services;
using System.Collections.Generic;
using Xunit;

namespace LobbyWars.ServiceLibraryTestUnit
{
    public class OperationServiceTest
    {
        private IOperationService _operationService = new OperationService();
        private IRoleService _roleService = new RolesService();

        [Fact]
        public void DifferenceOfValueTest()
        {
            int winnerValue = 8;
            int losserValue = 5;
            int compareValue = _operationService.DifferenceOfWinner(winnerValue, losserValue);
            Assert.True(compareValue == winnerValue - losserValue);

        }

        [Fact]
        public void ValueOfRoleList()
        {
            List<Roles> roles = new List<Roles>();
            roles.Add(new Roles() { Role = 'K', Value = 5 });
            roles.Add(new Roles() { Role = 'N', Value = 2 });
            int value = _operationService.GetValueOfParty(roles);
            Assert.True(7 == value);
        }

        [Fact]
        public void GetWinner()
        {
            int winnerValue = 8;
            int losserValue = 7;
            string winnerParty = "KNV";
            string losserParty = "NNNV";
            string compareParty = _operationService.GetWinner(winnerValue, losserValue, winnerParty, losserParty);
            Assert.Equal(compareParty, winnerParty);
        }

        [Fact]
        public void NewRole()
        {
            Roles compareRole = new Roles() { Role = 'K', Value = 5};
            Roles role = _operationService.NewRoleAndValue(5);
            Assert.Equal(compareRole.Role, role.Role);
            Assert.True(compareRole.Value == role.Value);
        }
    }
}
