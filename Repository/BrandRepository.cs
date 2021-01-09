using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Base;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
    }
}
