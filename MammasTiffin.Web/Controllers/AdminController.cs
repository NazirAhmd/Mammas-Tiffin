using AutoMapper;
using MammasTiffin.BusinessComponent.BusinessClasses.Admin;
using MammasTiffin.BusinessComponent.BusinessModels;
using MammasTiffin.Web.ViewModels.Admin;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MammasTiffin.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly AdminBusinessClass _adminBusinessClass;
        public AdminController()
        {
            _adminBusinessClass = new AdminBusinessClass();
        }
        #region Add Item Screen
        #region Action Methods
        [HttpGet]
        public ActionResult AddItem()
        {
            AddItemViewModel viewModel = new AddItemViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddItem(AddItemViewModel postedModel)
        {
            AddItemViewModel viewModel = new AddItemViewModel();
            if (ModelState.IsValid)
            {
                bool isSuccess = SaveMenuItem(postedModel);
            }
            return View(viewModel);
        }
        #endregion
        #region Private Methods
        private bool SaveMenuItem(AddItemViewModel addItemViewModel)
        {
            bool isSuccess = false;
            ItemBM itemBM = Mapper.Map<ItemBM>(addItemViewModel.ItemDetail);
            ItemImageBM itemImageBM = new ItemImageBM
            {
                ImageName = addItemViewModel.ItemDetail.File.FileName,
                ImageData = ReduceSizeOfImgFileFromPostedFile(addItemViewModel.ItemDetail.File)
            };
            itemImageBM.ImageSize = itemImageBM.ImageData.Length;
            isSuccess = _adminBusinessClass.SaveNewItem(itemBM, itemImageBM);
            return isSuccess;
        }
        //private byte[] ReadBytesFromPostedFile(HttpPostedFileBase postedFile)
        //{
        //    byte[] inputBytes = null;
        //    using (BinaryReader binaryReader = new BinaryReader(postedFile.InputStream))
        //    {
        //        inputBytes = binaryReader.ReadBytes(postedFile.ContentLength);
        //    }
        //    return inputBytes;
        //}
        private byte[] ReduceSizeOfImgFileFromPostedFile(HttpPostedFileBase postedFile)
        {
            var jpegQuality = 30;
            Image image = Image.FromStream(postedFile.InputStream);
            var jpegEncoder = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
            Byte[] outputBytes;
            using (var outputStream = new MemoryStream())
            {
                image.Save(outputStream, jpegEncoder, encoderParameters);
                outputBytes = outputStream.ToArray();
            }
            return outputBytes;
        }
        #endregion
        #endregion
    }
}