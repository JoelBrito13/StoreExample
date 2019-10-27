using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreExample.Interfaces;
using StoreExample.Modules.Category;
using StoreExample.Modules.Product;
using StoreExample.Services;

namespace StoreExample.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockServices StockServices;
        
        /*protected readonly IAppServices AppServices;
        protected readonly IUnitOfWork UnitOfWork;
        */
        public StockController(IStockServices stockServices) {
            StockServices = stockServices ?? throw new ArgumentNullException(nameof(stockServices), "Invalid Entry Service");
        }
        /*public StockController(IAppServices appServices, IUnitOfWork unitOfWork, IStockServices stockServices) {
            AppServices = appServices ?? throw new ArgumentNullException(nameof(appServices), "Invalid Application Service");
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "Invalid Unit of Work");
            StockServices = stockServices ?? throw new ArgumentNullException(nameof(stockServices), "Invalid Entry Service");
        }
        */
        
        [HttpGet]
        [Route("getProduct")]
        public ActionResult getProduct(int productIdx){
            try
            {
                Ok(StockServices.getProduct(productIdx));
                return Ok();
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("SearchProduct")]
        public ActionResult SearchProduct(string product){
            try {
                return Ok(StockServices.searchProduct(product));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
       
        [HttpGet]
        [Route("GetProducts")]
        public ActionResult GetProducts(){
            try {
                return Ok(StockServices.listAllProducts());
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpGet]
        [Route("listProductByCategory")]
        public ActionResult listProductByCategory(int categoryIdx){
            try {
                return Ok(StockServices.listProductByCategory(categoryIdx));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }        
        
        [HttpPost]
        [Route("AddProduct")]
        public ActionResult AddProduct([FromBody]Product product){
            try {
                return Ok(StockServices.addProduct(product));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult UpdateProduct([FromBody]Product product){
            try {
                return Ok(StockServices.updateProduct(product));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpDelete]
        [Route("removeProduct")]
        public ActionResult removeProduct(int productIdx){
            try {
                return Ok(StockServices.removeProduct(productIdx));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetCategory")]
        public ActionResult GetCategory(int categoryIdx){
            try {
                return Ok(StockServices.getCategory(categoryIdx));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("SearchCategory")]
        public ActionResult SearchCategory(string category){
            try {
                return Ok(StockServices.searchCategory(category));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        } 
        
        [HttpGet]
        [Route("GetCategories")]
        public ActionResult GetCategories(){
            try {
                return Ok(StockServices.listAllCategories());
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpPost]
        [Route("AddCategory")]
        public ActionResult AddCategory([FromBody]Category category){
            try {
                return Ok(StockServices.addCategory(category));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpPut]
        [Route("UpdateCategory")]
        public ActionResult UpdateCategory([FromBody]ICategory category){
            try {
                return Ok(StockServices.updateCategory(category));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpDelete]
        [Route("RemoveCategory")]
        public ActionResult RemoveCategory(int categoryIdx){
            try {
                return Ok(StockServices.removeCategory(categoryIdx));
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
    }
}