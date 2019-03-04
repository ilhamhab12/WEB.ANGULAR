using Bootcamp.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp.Angular.Controllers
{
    public class ItemController : Controller
    {
        private MyContext myContext = null;
        Item param = new Item();
        public ItemController()
        {
            myContext = new MyContext();
        }
        // GET: Item
        public JsonResult GetItems()
        {
            List<Item> listItems = myContext.Items.ToList();
            return Json(new { list = listItems }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemById(int id)
        {
            Item item = myContext.Items.Where(x => x.Id == id).SingleOrDefault();
            return Json(new { item = item }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddItem(Item item)
        {

            if(item.Suppliers != null)
            {
                param.Name = item.Name;
                param.Stock = item.Stock;
                param.Price = item.Price;
                param.Suppliers = myContext.Suppliers.Find(item.Suppliers.Id);
                //myContext.Suppliers.Find(item.Suppliers.Id);
                myContext.Items.Add(param);
                myContext.SaveChanges();
                return Json(new { status = "Item Added Successfully" });
            }
            return Json(new { status = "Item Added Failed" });

        }

        public JsonResult UpdateItem(Item item)
        {
            param.Name = item.Name;
            param.Stock = item.Stock;
            param.Price = item.Price;
            param.Suppliers = myContext.Suppliers.Find(item.Suppliers.Id);
            myContext.Entry(param).State = System.Data.Entity.EntityState.Modified;
            myContext.SaveChanges();
            return Json(new { status = "Item Updated Successfully" });
        }

        public JsonResult DeleteItem(int id)
        {
            Item item = myContext.Items.Where(x => x.Id == id).SingleOrDefault();
            myContext.Items.Remove(item);
            myContext.SaveChanges();
            return Json(new { status = "Item Deleted Successfully" });
        }
    }
}