using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }

        public string question { get; set; }
    }
}