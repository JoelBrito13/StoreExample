using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public StockController(IStockServices stockServices) {
            StockServices = stockServices ?? throw new ArgumentNullException(nameof(stockServices), "Invalid Entry Service");
        }
        
        //Categories
        
        [HttpGet]
        [Route("GetCategory")]
        public async Task <ActionResult> GetCategory(int categoryIdx){
            try {
                var task = Task.Run(()=>StockServices.GetCategoryAsync(categoryIdx));
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
                var task = Task.Run(()=>StockServices.SearchCategoryAsync(category));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        } 

        [HttpGet]
        [Route("ListCategories")]
        public async Task <ActionResult> ListCategories(){
            try {
                var task = Task.Run(()=>StockServices.ListAllCategoriesAsync());
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
                var task = Task.Run(()=>StockServices.AddCategory(category));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task <ActionResult> UpdateCategory([FromBody]Category category){
            try {
                var task = Task.Run(()=> StockServices.UpdateCategoryAsync(category));
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
                var task = Task.Run(()=>StockServices.RemoveCategoryAsync(categoryIdx));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }
        
        
        //Products
        
        
        
        [HttpGet]
        [Route("getProduct")]
        public async Task <ActionResult> getProduct(int productIdx){
            try
            {
                var task = Task.Run(()=> StockServices.GetProductAsync(productIdx));
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
                var task = Task.Run(()=>StockServices.SearchProductAsync(product));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ListProducts")]
        public async Task <ActionResult> ListProducts(){
            try {                
                var task = Task.Run(()=>StockServices.ListAllProducts());
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
                var task = Task.Run(()=>StockServices.ListProductByCategory(categoryIdx));
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
                var task = Task.Run(()=>StockServices.AddProductAsync(product));
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
                var task = Task.Run(()=>StockServices.UpdateProduct(product));
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
                var task = Task.Run(()=>StockServices.RemoveProduct(productIdx));
                await task;
                return Ok(task.Result);
            }
            catch (Exception ex){
                return BadRequest(ex);
            }
        }

        
    }
} 