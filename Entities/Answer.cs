using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public Boolean Correct { get; set; }
        public string answer { get; set; }
    }
}
