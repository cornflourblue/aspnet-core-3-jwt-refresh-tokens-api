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
    [Route("api/answer")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
         DataContext db;

        public AnswerController(DataContext context)
        {
            db = context;
            if (!db.Answers.Any())
            {
                db.Answers.Add(new Answer { QuestionId = 1, answer = "Відсутність перетинів на одному рівні з іншими дорогами, залізничними або трамвайними коліями, пішохідними чи велосипедними доріжками.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 1, answer = "Наявність не менше шести смуг для руху в кожному напрямку.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 1, answer = "Наявність розділювальної смуги", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 1, answer = "Відповіді, зазначені в пунктах 1 і 3.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 2, answer = "Тільки вантажних і легкових автомобілів.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 2, answer = "Тільки механічних транспортних засобів.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 2, answer = "Транспортних засобів і пішоходів.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 3, answer = "Зупинився на узбіччі через прокол колеса.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 3, answer = "Зупинився на смузі руху через засліплення фарами зустрічного автомобіля.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 3, answer = "Зупинився, щоб надати допомогу пасажиру.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 3, answer = "Відповіді 1,2,3.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 4, answer = "Трамваї, тролейбуси, автобуси, метрополітен.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 4, answer = "Транспортні засоби з кількістю місць для сидіння не менш ніж сімнадцять з місцем водія включно, що рухаються за встановленими маршрутами та мають визначені місця на дорозі для посадки (висадки) пасажирів.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 4, answer = "Автобуси, мікроавтобуси, тролейбуси, трамваї і таксі, що рухаються за встановленими маршрутами та мають певні місця на дорозі для посадки (висадки) пасажирів.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 5, answer = "Обмежена оглядовість менше 300 м.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 5, answer = "Видимість дороги в напрямку руху менше 300 метрів, обмежена поворотом дороги.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 5, answer = "Видимість дороги в напрямку руху менше 300 м у сутінках, в умовах туману, дощу, снігопаду і т. п.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 5, answer = "Небезпечний поворот, небезпечний підйом, небезпечний спуск.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 6, answer = "1. Елементи дороги", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 6, answer = "2. Стан поверхні проїзної частини, наявність перешкод на певній ділянці дороги.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 6, answer = "3. Наявність дорожньої розмітки, дорожніх знаків, дорожнього обладнання, світлофорів і їхній стан.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 6, answer = "4. Відповіді, зазначені в пунктах 1, 2.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 6, answer = "5. Відповіді, зазначені в пунктах 1, 2, 3.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 7, answer = "1. Транспортними засобами або геометричними параметрами дороги.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 7, answer = "2. Придорожніми інженерними спорудами, насадженнями та іншими об\'єктами.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 7, answer = "3. Погодними явищами, такими як дощ, снігопад, туман і т. д.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 7, answer = "4. Правильно все перелічене вище.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 7, answer = "5. Відповіді 1, 2.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 8, answer = "Тільки з лівого боку.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 8, answer = "Тільки з правого боку.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 8, answer = "З будь-якого боку по суміжній смузі з дотриманням заходів безпеки.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 9, answer = "Мокрий сніг.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 9, answer = "Сильна злива.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 9, answer = "Інтенсивний снігопад.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 9, answer = "Світло.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 10, answer = "1. Перехрещення, прилягання або розгалуження доріг на одному рівні, яке не є виїздом з прилеглих територій.", Correct = true });
                db.Answers.Add(new Answer { QuestionId = 10, answer = "2. Місце перетину дороги над іншою дорогою (залізницею) на різних рівнях за допомогою шляхопроводу.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 10, answer = "3. Місце прилягання до дороги виїзду з прилеглої території.", Correct = false });
                db.Answers.Add(new Answer { QuestionId = 10, answer = "4. Відповіді, зазначені в пунктах 2, 3.", Correct = false });


                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Answer> Get()
        {
            return db.Answers.ToList();
        }



        [HttpPost]
        public IActionResult Post(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return Ok(answer);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Update(answer);
                db.SaveChanges();
                return Ok(answer);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Answer answer = db.Answers.FirstOrDefault(x => x.Id == id);
            if (answer != null)
            {
                db.Answers.Remove(answer);
                db.SaveChanges();

            }
            return Ok(answer);
        }
    }
}
