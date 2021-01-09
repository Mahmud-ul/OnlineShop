using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApp.Model.Models;
using EcommerceApp.ViewModel;
using EcommerceApp.ViewModel.Account;
using EcommerceApp.ViewModel.Brand;
using EcommerceApp.ViewModel.Category;
using EcommerceApp.ViewModel.Product;
using EcommerceApp.ViewModel.ProductPhoto;
using EcommerceApp.ViewModel.Role;
using EcommerceApp.ViewModel.RoleAccount;
using EcommerceApp.ViewModel.SlideShow;

namespace EcommerceApp.Utility
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<SlideShow, SlideShowViewModel>();
            CreateMap<SlideShowViewModel, SlideShow>();            
            CreateMap<SlideShow, SlideShowUpdateViewModel>();
            CreateMap<SlideShowUpdateViewModel, SlideShow>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryCreateViewModel>();
            CreateMap<CategoryCreateViewModel, Category>();
            CreateMap<Category, CategoryUpdateViewModel>();
            CreateMap<CategoryUpdateViewModel, Category>();
            CreateMap<Category, CategorySubViewModel>();
            CreateMap<CategorySubViewModel, Category>();

            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();
            CreateMap<Brand, CreateBrandViewModel>();
            CreateMap<CreateBrandViewModel, Brand>();
            CreateMap<Brand, UpdateBrandViewModel>();
            CreateMap<UpdateBrandViewModel, Brand>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductCreateViewModel>();
            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<Product, ProductUpdateViewModel>();
            CreateMap<ProductUpdateViewModel, Product>();

            CreateMap<ProductPhoto, ProductPhotoViewModel>();
            CreateMap<ProductPhotoViewModel, ProductPhoto>();
            CreateMap<ProductPhoto, ProductPhotoCreateViewModel>();
            CreateMap<ProductPhotoCreateViewModel, ProductPhoto>();
            CreateMap<ProductPhoto, ProductPhotoUpdateViewModel>();
            CreateMap<ProductPhotoUpdateViewModel, ProductPhoto>();

            CreateMap<Account, AccountViewModel>();
            CreateMap<AccountViewModel, Account>();
            CreateMap<Account, AccountCreateViewModel>();
            CreateMap<AccountCreateViewModel, Account>();
            CreateMap<Account, AccountUpdateViewModel>();
            CreateMap<AccountUpdateViewModel, Account>();

            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();
            CreateMap<Role, RoleCreateViewModel>();
            CreateMap<RoleCreateViewModel, Role>();
            CreateMap<Role, RoleUpdateViewModel>();
            CreateMap<RoleUpdateViewModel, Role>();

            CreateMap<RoleAccount, RoleAccountViewModel>();
            CreateMap<RoleAccountViewModel, RoleAccount>();
            CreateMap<RoleAccount, RoleAccountCreateViewModel>();
            CreateMap<RoleAccountCreateViewModel, RoleAccount>();
            CreateMap<RoleAccount, RoleAccountUpdateViewModel>();
            CreateMap<RoleAccountUpdateViewModel, RoleAccount>();
        }
    }
}
