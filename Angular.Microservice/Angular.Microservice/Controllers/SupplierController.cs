using Angular.Microservice.BussinessLogic.Interface;
using Angular.Microservice.DataAccess.Context;
using Angular.Microservice.DataAccess.Model;
using Angular.Microservice.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angular.Microservice.Controllers
{
    public class SupplierController : Controller
    {
        private MyContext myContext = null;
        Supplier param = new Supplier();

        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public SupplierController()
        {
            myContext = new MyContext();
        }
        // GET: Supplier
        public JsonResult GetSuppliers()
        {
            List<Supplier> listSuppliers = myContext.Suppliers.ToList();
            //var listSuppliers = _supplierService.Get();
            return Json(new { list = listSuppliers }, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult GetSupplierById(int id)
        {
            Supplier supplier = myContext.Suppliers.Where(x => x.Id == id).SingleOrDefault();
            //var supplier = _supplierService.Get(id);
            return Json(new { supplier = supplier }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSupplier(Supplier supplier)
        {
            if(supplier.Name != null)
            {
                param.Name = supplier.Name;
                myContext.Suppliers.Add(param);
                myContext.SaveChanges();
                return Json(new { status = "Supplier Added Successfully" });
            }
            return Json(new { status = "Adding Supplier Failed" });
        }

        public JsonResult UpdateSupplier(Supplier supplier)
        {
            param.Name = supplier.Name;
            myContext.Entry(param).State = System.Data.Entity.EntityState.Modified;
            myContext.SaveChanges();
            return Json(new { status = "Supplier Updated Successfully" });
        }

        public JsonResult DeleteSupplier(int id)
        {
            param.IsDelete = true;
            myContext.Entry(param).State = System.Data.Entity.EntityState.Modified;
            myContext.SaveChanges();
            return Json(new { status = "Supplier Was Soft Deleted Successfully" });
        }
    }

}
