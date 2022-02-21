using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LobbyWars.Core.Models;
using LobbyWars.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace LobbyWars.ServiceLibraryUnitTest
{
    [TestClass]
    public class RolesServiceTest
    {
        private IRoleService _roleService;
        public RolesServiceTest(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [TestMethod]
        public void GetListOfRolesFromString()
        {
            string roles = "KNV";
            var listRoles = _roleService.GetListOfRoles(roles);
            Assert.IsTrue(roles.Equals(listRoles.ToString()));
        }
    }
}
