using LobbyWars.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.Core.Services
{
    public interface IOperationService
    {
        string GetWinnerParty(string partyOne, string partyTwo);
        int GetValueOfParty(List<Roles> roles);
        List<Roles> GetAllRolesWithNewRole(List<Roles> roles, string partyOne, string partyTwo);
        string GetWinner(int valuePartyOne, int valuePartyTwo, string partyOne, string partyTwo);
        int DifferenceOfWinner(int valuePartyOne, int valuePartyTwo);
        Roles NewRoleAndValue(int value);
    }
}
