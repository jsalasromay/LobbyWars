using LobbyWars.Core.Models;
using LobbyWars.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.ServiceLibrary.Services
{
    public class OperationService : IOperationService
    {
        private IRoleService _roleService;

        public OperationService()
        {
        }

        public OperationService(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public int DifferenceOfWinner(int valuePartyOne, int valuePartyTwo)
        {
            int valueOfDifference = valuePartyOne - valuePartyTwo;
            if (valueOfDifference < 0)
            {
                valueOfDifference *= -1;
            }
            return valueOfDifference;
        }

        public List<Roles> GetAllRolesWithNewRole(List<Roles> roles, string partyOne, string partyTwo)
        {
            List<Roles> newRoles = roles;
            int value = DifferenceOfWinner(GetValueOfParty(_roleService.GetListOfRoles(partyOne)), GetValueOfParty(_roleService.GetListOfRoles(partyTwo)));
            Roles? role = roles.FirstOrDefault(x => x.Role == '#');
            if (role != null)
            {
                role.Role = NewRoleAndValue(value).Role;
                role.Value = NewRoleAndValue(value).Value;
                value -= role.Value;
            }
            while (value >= 0)
            {
                newRoles.Add(new Roles { Role = NewRoleAndValue(value).Role, Value = NewRoleAndValue(value).Value });
                value -= NewRoleAndValue(value).Value;
            }
            return newRoles;
        }

        public int GetValueOfParty(List<Roles> roles)
        {
            int value = 0;
            foreach (var role in roles)
            {
                value = value + role.Value;
            }
            return value;
        }

        public string GetWinner(int valuePartyOne, int valuePartyTwo, string partyOne, string partyTwo)
        {
            if (valuePartyOne > valuePartyTwo)
            {
                return partyOne;
            }
            else
            {
                return partyTwo;
            }
        }

        public string GetWinnerParty(string partyOne, string partyTwo)
        {
            int valueOfPartyOne = GetValueOfParty(_roleService.GetListOfRoles(partyOne));
            int valueOfPartyTwo = GetValueOfParty(_roleService.GetListOfRoles(partyTwo));
            if (_roleService.ValidateRoles(_roleService.GetListOfRoles(partyOne)))
            {
                List<Roles> roles = GetAllRolesWithNewRole(_roleService.GetListOfRoles(partyOne), partyOne, partyTwo);
                valueOfPartyOne = GetValueOfParty(roles);
                partyOne = _roleService.ConvertListToString(roles);
            }
            if (_roleService.ValidateRoles(_roleService.GetListOfRoles(partyTwo)))
            {
                List<Roles> roles = GetAllRolesWithNewRole(_roleService.GetListOfRoles(partyTwo), partyOne, partyTwo);
                valueOfPartyTwo = GetValueOfParty(roles);
                partyTwo = _roleService.ConvertListToString(roles);
            }
            return GetWinner(valueOfPartyOne, valueOfPartyTwo, partyOne, partyTwo);
        }

        public Roles NewRoleAndValue(int value)
        {
            Roles role = new Roles();
            if (value >= 5)
            {
                role.Role = 'K';
                role.Value = 5;
                return role;
            }
            if (value >= 2)
            {
                role.Role = 'N';
                role.Value = 2;
                return role;
            }
            role.Role = 'V';
            role.Value = 1;
            return role;
        }
    }
}
