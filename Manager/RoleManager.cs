using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Manager.Base;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class RoleManager : BaseManager<Role> , IRoleManager
    {
        private readonly IRoleRepository _iRoleRepository;
        public RoleManager(IRoleRepository iRoleRepository) : base(iRoleRepository)
        {
            _iRoleRepository = iRoleRepository;
        }
    }
}
