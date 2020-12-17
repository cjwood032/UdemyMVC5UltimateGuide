using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UdemyMVC5UltimateGuide.Models
{
    public class CustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int StudentId = Convert.ToInt32(controllerContext.HttpContext.Request.Form["StudentId"]);
            var StudentName = controllerContext.HttpContext.Request.Form["StudentName"];
            var AddressLn1 = controllerContext.HttpContext.Request.Form["AddressLn1"];
            var City = controllerContext.HttpContext.Request.Form["City"];
            var State = controllerContext.HttpContext.Request.Form["State"];
            return new Student() { StudentID = StudentId, StudentName = StudentName, Address = (AddressLn1 + " " + City + " " + State)};
        }

    }
}