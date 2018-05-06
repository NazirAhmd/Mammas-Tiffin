using AutoMapper;
using MammasTiffin.BusinessComponent.BusinessModels;
using MammasTiffin.DataAccess.Repository;
using MammasTiffin.DataAccess.UnitOfWork;
using MammasTiffin.Entities.EntityFramework;
using System;

namespace MammasTiffin.BusinessComponent.BusinessClasses.Admin
{
    public class AdminBusinessClass
    {
        public bool SaveNewItem(ItemBM itemBM, ItemImageBM itemImageBM)
        {
            bool success = false;
            Item item = Mapper.Map<Item>(itemBM);
            item.DateAndTime = DateTime.Now;
            item.ItemImage = Mapper.Map<ItemImage>(itemImageBM);
            item.ItemImage.DateAndTime = DateTime.Now;
            
            using (UnitOfWork unitOfWork=new UnitOfWork())
            {
                IRepository<Item> itemRepo = unitOfWork.GetRepository<Item>();
                itemRepo.Insert(item);
                unitOfWork.Save();
                success = true;
            }
            return success;
        }
    }
}
