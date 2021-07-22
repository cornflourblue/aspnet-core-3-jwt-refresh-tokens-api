using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;


namespace WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class UserScoreController : ControllerBase
    {
         DataContext db;

        public UserScoreController(DataContext context)
        {
            db = context;
            if (!db.Categories.Any())
            {
                db.Categories.Add(new Categories { Name = "Тесты ПДР" });
                db.Categories.Add(new Categories { Name = "Тесты по психологии" });
                db.Categories.Add(new Categories { Name = "Тесты на нарко.алко зависимость" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Categories> Get()
        {
            return db.Categories.ToList();
        }

        [HttpGet("{id}")]
        public Categories Get(int id)
        {
            Categories categories = db.Categories.FirstOrDefault(x => x.Id == id);
            return categories;
        }

        [HttpPost]
        
        public IActionResult Post(Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categories);
                db.SaveChanges();
                return Ok(categories);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Update(categories);
                db.SaveChanges();
                return Ok(categories);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Categories categories = db.Categories.FirstOrDefault(x => x.Id == id);
            if (categories != null)
            {
                db.Categories.Remove(categories);
                db.SaveChanges();

            }
            return Ok(categories);
        }
    }
}
