using Niceland_Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Niceland_Inventory.Controllers
{
    public class ItemsController : ApiController
    {
        IItemValueService service;

        public ItemsController(IItemValueService service)
        {
            this.service = service;
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<List<string>>(service.GetAllItems());
        }
        public HttpResponseMessage CalcInventoryValue([FromBody] List<string> itemsInput)
        {
           return Request.CreateResponse<List<string>>(service.CalculateInventoryValueChange(itemsInput));
        }
    }
}