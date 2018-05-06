using MammasTiffin.BusinessComponent.BusinessModels;
using MammasTiffin.DataAccess.UnitOfWork;
using MammasTiffin.DataAccess.Repository;
using MammasTiffin.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace MammasTiffin.BusinessComponent.BusinessClasses.MammasTiffin
{
    public class MammasTiffinBusinessClass
    {
        public MammasTiffinBusinessClass()
        {
        }
        public IEnumerable<MenuDetailBM> GetAllMenuItemsFromDb()
        {
            List<MenuDetailBM> menuDetailList;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IRepository<Item> itemsRepo = unitOfWork.GetRepository<Item>();
                menuDetailList = itemsRepo.Data.Include(x => x.ItemImage).ProjectTo<MenuDetailBM>().ToList();
            }
            menuDetailList.ForEach(x => x.Price = Math.Round(x.Price, 0));
            return menuDetailList;
        }
    }
}
