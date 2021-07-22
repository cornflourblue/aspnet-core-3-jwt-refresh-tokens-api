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
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
         DataContext db;

        public QuestionController(DataContext context)
        {
            db = context;
            if (!db.Questions.Any())
            {
                db.Questions.Add(new Question { TestId = 1, question = "Які вимоги є обов'язковими для дороги, позначеної знаком «Автомагістраль»?" });
                db.Questions.Add(new Question { TestId = 1, question = "Автомобільна дорога, вулиця (дорога) — це частина території, в тому числі в населеному пункті, призначена для руху:" });
                db.Questions.Add(new Question { TestId = 1, question = "В якому з перелічених випадків водій здійснив вимушену зупинку?" });
                db.Questions.Add(new Question { TestId = 1, question = "До маршрутних транспортних засобів (транспортних засобів загального користування) належать:" });
                db.Questions.Add(new Question { TestId = 1, question = "Недостатньою видимістю вважається:" });
                db.Questions.Add(new Question { TestId = 1, question = "Оглядовістю вважається можливість бачити з місця водія..." });
                db.Questions.Add(new Question { TestId = 1, question = "Обмежена оглядовість – це видимість дороги в напрямку руху, яка обмежена:" });
                db.Questions.Add(new Question { TestId = 1, question = "З якого боку дозволено виконати випередження на проїзній частині?" });
                db.Questions.Add(new Question { TestId = 1, question = "Які фактори можуть призвести до засліплення водія?" });
                db.Questions.Add(new Question { TestId = 1, question = "Перехрестям вважається:" });

                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return db.Questions.ToList();
        }



        [HttpPost]
        public IActionResult Post(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return Ok(question);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Update(question);
                db.SaveChanges();
                return Ok(question);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Question question = db.Questions.FirstOrDefault(x => x.Id == id);
            if (question != null)
            {
                db.Questions.Remove(question);
                db.SaveChanges();

            }
            return Ok(question);
        }
    }
}
