using AutoMapper;
using MammasTiffin.BusinessComponent.BusinessClasses.MammasTiffin;
using MammasTiffin.BusinessComponent.BusinessModels;
using MammasTiffin.Web.ViewModels.MammasTiffin;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MammasTiffin.Web.Controllers
{
    public class MammasTiffinController : BaseController
    {
        private readonly MammasTiffinBusinessClass _mammasTiffinBusinessClass;
        public MammasTiffinController()
        {
            _mammasTiffinBusinessClass = new MammasTiffinBusinessClass();
        }

        #region Home
        #region Action Methods
        [HttpGet]
        public ActionResult Home()
        {
            HomeViewModel viewModel = new HomeViewModel();
            return View(viewModel);
        }
        #endregion

        #region Private Methods
        #endregion
        #endregion

        #region Menu
        #region Action Methods
        [HttpGet]
        public ActionResult Menu()
        {
            MenuViewModel viewModel = new MenuViewModel();
            viewModel.MenuDetailsList = GetAllMenuItems()?.ToList();
            return View(viewModel);
        }
        #endregion
        #region Private Methods
        private IEnumerable<MenuDetail> GetAllMenuItems()
        {
            IEnumerable<MenuDetailBM> menuDetailBmList = _mammasTiffinBusinessClass.GetAllMenuItemsFromDb();
            return Mapper.Map<IEnumerable<MenuDetail>>(menuDetailBmList);
        }
        #endregion
        #endregion

        #region Login
        #region Action methods
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel viewModel = new LoginViewModel();
            return View(viewModel);
        }
        #endregion
        #region Private methods
        #endregion
        #endregion

        #region Sign up
        #region Action methods
        [HttpGet]
        public ActionResult SignUp()
        {
            SignUpViewModel viewModel = new SignUpViewModel();
            return View(viewModel);
        }
        #endregion
        #region Private methods
        #endregion
        #endregion

        #region About Us
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }
        #endregion

        #region Contact Us
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        #endregion
    }
}