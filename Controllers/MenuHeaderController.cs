using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using ClothingPro.BusinessLayer.DTO;
using ClothingPro.BusinessLayer.Interface;
using ClothingPro.BusinessLayer.BusinessService;
using ClothingPro.Models;

namespace ClothingPro.Web.Controllers
{
    public class MenuHeaderController : BaseController
    {
        private readonly IMenuHeaderService _MenuHeaderService;

        public MenuHeaderController(IMenuHeaderService menuHeaderService)
        {
            _MenuHeaderService = menuHeaderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = _MenuHeaderService.GetAllMenuHeader();
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet]
        public IActionResult Create(int mnId)
        {
            MenuHeaderDTO model = new MenuHeaderDTO();

            if (mnId > 0)
            {
                model = _MenuHeaderService.GetMenuHeaderByIdd(mnId);
            }
            else
            {

            }

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult CreatePost(MenuHeaderDTO model)
        {
            try
            {


                if (ModelState.IsValid)
                {
                 
                    int StId = _MenuHeaderService.CreateMenuHeader(model);
                    return Json("success");
                }


                return View("Create", model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult UpdateMenuHeader(MenuHeaderDTO model)
        {
            try
            {
                _MenuHeaderService.UpdateMenuHeader(model);
                return Json("success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Delete(int mnId)
        {
            try
            {
                var data = _MenuHeaderService.DeleteMenuHeader(mnId);
                //return this.Ok(data);
                if (data)
                {
                    return Json(new { success = true, message = "Data Deleted Successfully" });
                }
                else // If deletion failed for some reason
                {
                    return Json(new { success = false, message = "Failed to delete the data" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetStockMenuDetail(int mnId)
        {
            List<StockMenuView> StockMenuViewlists = new List<StockMenuView>();

            if (mnId > 0)
            {
                StockMenuViewlists = _MenuHeaderService.GetStockMenuDetail(mnId);
            }
            else
            {

            }

            return View("StockMenuDetail", StockMenuViewlists);
        }

    }
}