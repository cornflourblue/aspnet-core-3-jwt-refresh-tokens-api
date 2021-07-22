using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class UserScore
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }

        public int Time { get; set; }
        public int Correct { get; set; }
        public int Wrong { get; set; }
    }
}
