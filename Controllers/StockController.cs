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
        public async Task <ActionResult> getProduct(int productIdx){
            try
            {
                var task = Task.Run(()=> StockServices.getProduct(productIdx));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("SearchProduct")]
        public async Task <ActionResult> SearchProduct(string product){
            try {
                var task = Task.Run(()=>StockServices.searchProduct(product));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
       
        [HttpGet]
        [Route("GetProducts")]
        public async Task <ActionResult> GetProducts(){
            try {                
                var task = Task.Run(()=>StockServices.listAllProducts());
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpGet]
        [Route("listProductByCategory")]
        public async Task <ActionResult> listProductByCategory(int categoryIdx){
            try {
                var task = Task.Run(()=>StockServices.listProductByCategory(categoryIdx));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }        
        
        [HttpPost]
        [Route("AddProduct")]
        public async Task <ActionResult> AddProduct([FromBody]Product product){
            try {
                var task = Task.Run(()=>StockServices.addProduct(product));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task <ActionResult> UpdateProduct([FromBody]Product product){
            try {
                var task = Task.Run(()=>StockServices.updateProduct(product));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpDelete]
        [Route("removeProduct")]
        public async Task <ActionResult> removeProduct(int productIdx){
            try {
                var task = Task.Run(()=>StockServices.removeProduct(productIdx));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task <ActionResult> GetCategory(int categoryIdx){
            try {
                var task = Task.Run(()=>StockServices.getCategory(categoryIdx));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("SearchCategory")]
        public async Task <ActionResult> SearchCategory(string category){
            try {
                var task = Task.Run(()=>StockServices.searchCategory(category));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        } 
        
        [HttpGet]
        [Route("GetCategories")]
        public async Task <ActionResult> GetCategories(){
            try {
                var task = Task.Run(()=>StockServices.listAllCategories());
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpPost]
        [Route("AddCategory")]
        public async Task <ActionResult> AddCategory([FromBody]Category category){
            try {
                var task = Task.Run(()=>StockServices.addCategory(category));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpPut]
        [Route("UpdateCategory")]
        public async Task <ActionResult> UpdateCategory([FromBody]ICategory category){
            try {
                var task = Task.Run(()=>StockServices.updateCategory(category));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        [HttpDelete]
        [Route("RemoveCategory")]
        public async Task <ActionResult> RemoveCategory(int categoryIdx){
            try {
                var task = Task.Run(()=>StockServices.removeCategory(categoryIdx));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
    }
}