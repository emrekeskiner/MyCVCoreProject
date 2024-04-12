using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCvCore.Api.DAL.ApiContext;
using MyCvCore.Api.DAL.Entity;

namespace MyCvCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ApiContext apiContext=new ApiContext();
        [HttpGet]
        public IActionResult CategoryList()
        {
            

            return Ok(apiContext.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = apiContext.Categories.Find(id);
            if (values == null)
            { 
             return NotFound();
            }else
            {
                return Ok(values);
            }
            
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            apiContext.Categories.Add(category);
            apiContext.SaveChanges();
            return Created("",category);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var value = apiContext.Categories.Find(id);

            if(value == null)
            {
                 return NotFound();
            }
            else
            {
                apiContext.Categories.Remove(value);
                apiContext.SaveChanges();
                return Created("", value);
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var value = apiContext.Categories.Find(category.CategoryId);
            if (value == null)
            {
                return NotFound();
            }else
            {
                value.CategoryName = category.CategoryName;
                apiContext.Update(value);
                apiContext.SaveChanges() ;
                return Ok("Güncelleme Başarılı");
            }
        }
    }
}
