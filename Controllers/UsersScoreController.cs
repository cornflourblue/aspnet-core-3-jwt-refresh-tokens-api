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
    [Route("api/score")]
    [ApiController]
    public class UsersScoreController : ControllerBase
    {
         DataContext db;

        public UsersScoreController(DataContext context)
        {
            db = context;
            if (!db.UserScores.Any())
            {
                db.UserScores.Add(new UserScore { TestId = 1, Correct = 5, Wrong = 5, UserId = 1, Time = 120 });
                db.UserScores.Add(new UserScore { TestId = 1, Correct = 3, Wrong = 7, UserId = 2, Time = 90 });
                db.UserScores.Add(new UserScore { TestId = 1, Correct = 7, Wrong = 3, UserId = 2, Time = 160 });
                db.UserScores.Add(new UserScore { TestId = 1, Correct = 6, Wrong = 4, UserId = 1, Time = 180 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<UserScore> Get()
        {
            return db.UserScores.ToList();
        }

        [HttpGet("{id}")]
        public UserScore Get(int id)
        {
            UserScore score = db.UserScores.FirstOrDefault(x => x.Id == id);
            return score;
        }

        [HttpPost]
        
        public IActionResult Post(UserScore score)
        {
            if (ModelState.IsValid)
            {
                db.UserScores.Add(score);
                db.SaveChanges();
                return Ok(score);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(UserScore score)
        {
            if (ModelState.IsValid)
            {
                db.Update(score);
                db.SaveChanges();
                return Ok(score);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserScore score = db.UserScores.FirstOrDefault(x => x.Id == id);
            if (score != null)
            {
                db.UserScores.Remove(score);
                db.SaveChanges();

            }
            return Ok(score);
        }
    }
}
