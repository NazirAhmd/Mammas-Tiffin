using MammasTiffin.BusinessComponent.BusinessClasses.MammasTiffin;
using MammasTiffin.BusinessComponent.BusinessModels;
using MammasTiffin.Common.AutoMapperConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MammasTiffin.BusinessComponent.Test.MammasTiffin
{
    [TestClass]
    public class MammasTiffin
    {
        private readonly MammasTiffinBusinessClass _mammasTiffinBusinessClass;
        public MammasTiffin()
        {
            _mammasTiffinBusinessClass = new MammasTiffinBusinessClass();
            MapperConfig.RegisterAutoMapperConfigurations();
        }
        [TestMethod]
        public void GetAllMenuItemsFromDb_TestMethod()
        {
            IEnumerable<MenuDetailBM> menuDetailBmList = new List<MenuDetailBM>();
            menuDetailBmList = _mammasTiffinBusinessClass.GetAllMenuItemsFromDb();
            Assert.AreEqual(menuDetailBmList.ToList()[0].ItemName, "Chicken");
        }
    }
}
