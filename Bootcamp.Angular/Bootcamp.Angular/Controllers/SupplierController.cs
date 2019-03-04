using Bootcamp.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp.Angular.Controllers
{
    public class SupplierController : Controller
    {
        private MyContext myContext = null;
        public SupplierController()
        {
            myContext = new MyContext();
        }
        // GET: Supplier
        public JsonResult GetSuppliers()
        {
            List<Supplier> listSuppliers = myContext.Suppliers.ToList();
            return Json(new { list = listSuppliers }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSupplierById(int id)
        {
            Supplier supplier = myContext.Suppliers.Where(x => x.Id == id).SingleOrDefault();
            return Json(new { supplier = supplier }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSupplier(Supplier supplier)
        {
            myContext.Suppliers.Add(supplier);
            myContext.SaveChanges();
            return Json(new { status = "Supplier Added Successfully" });
        }

        public JsonResult UpdateSupplier(Supplier supplier)
        {
            myContext.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
            myContext.SaveChanges();
            return Json(new { status = "Supplier Updated Successfully" });
        }

        public JsonResult DeleteSupplier(int id)
        {
            Supplier supplier = myContext.Suppliers.Where(x => x.Id == id).SingleOrDefault();
            myContext.Suppliers.Remove(supplier);
            myContext.SaveChanges();
            return Json(new { status = "Supplier Deleted Successfully" });
        }
    }
}