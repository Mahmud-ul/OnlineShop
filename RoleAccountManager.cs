using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Manager.Base;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class RoleAccountManager : BaseManager<RoleAccount> , IRoleAccountManager
    {
        private readonly IRoleAccountRepository _iRoleAccountRepository;
        public RoleAccountManager(IRoleAccountRepository iRoleAccountRepository) : base(iRoleAccountRepository)
        {
            _iRoleAccountRepository = iRoleAccountRepository;
        }
    }
}
