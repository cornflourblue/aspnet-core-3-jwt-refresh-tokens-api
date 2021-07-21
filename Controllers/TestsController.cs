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
    [Route("api/tests")]
    [ApiController]
    public class TestsController : ControllerBase
    {
         DataContext db;

        public TestsController(DataContext context)
        {
            db = context;
            if (!db.Tests.Any())
            {
                db.Tests.Add(new Test { Title = "Іспит з ПДР України 2021", Description = "Дати дорогу водій повинен дати дорогу транспортним засобам, що під’їжджають до нерегульованого перехрестя по головній дорозі, а за наявності таблички", CategoryId = 1 });
                db.Tests.Add(new Test { Title = "Дорожні знаки і таблички", Description = "Повний комплект (100%) офіційних тестових питань 2021. Для доступу до статистики тестування потрібно увійти або зареєструватись – це безкоштовно. Зареєстрованим користувачам доступний безкоштовний доступ до відеоуроку з надання першої домедичної допомоги і розбору екзаменаційних питань з цієї теми в особистому кабінеті. Відповіді на часті питання за цим посиланням.", CategoryId = 1 });
                db.Tests.Add(new Test { Title = "Дорожня розмітка", Description = "Дати дорогу водій повинен дати дорогу транспортним засобам, що під’їжджають до нерегульованого перехрестя по головній дорозі, а за наявності таблички", CategoryId = 1 });
                db.Tests.Add(new Test { Title = "Штрафи ПДР", Description = "Дати дорогу водій повинен дати дорогу транспортним засобам, що під’їжджають до нерегульованого перехрестя по головній дорозі, а за наявності таблички", CategoryId = 1 });
                db.Tests.Add(new Test { Title = "Законодавство водія", Description = "Дати дорогу водій повинен дати дорогу транспортним засобам, що під’їжджають до нерегульованого перехрестя по головній дорозі, а за наявності таблички", CategoryId = 1 });
                
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return db.Tests.ToList();
        }

        [HttpGet("{id}")]
        public Test Get(int id)
        {
            Test test = db.Tests.FirstOrDefault(x => x.Id == id);
            return test;
        }

        [HttpGet("categories/{id}")]
        public Test GetWithId(int id)
        {
            Test test = (Test)db.Tests.Where(x => x.CategoryId == id);

            return test;
        }


        [HttpPost]
        public IActionResult Post(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return Ok(test);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Update(test);
                db.SaveChanges();
                return Ok(test);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Test test = db.Tests.FirstOrDefault(x => x.Id == id);
            if (test != null)
            {
                db.Tests.Remove(test);
                db.SaveChanges();

            }
            return Ok(test);
        }
    }
}
