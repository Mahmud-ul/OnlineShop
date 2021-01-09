using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Manager.Base;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class AccountManager : BaseManager<Account> , IAccountManager
    {
        private readonly IAccountRepository _iAccountRepository;
        public AccountManager(IAccountRepository iAccountRepository) : base(iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }
    }
}
