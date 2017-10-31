using Api.Entities.Default;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities.QA
{
    public class Question : DefaultEntity
    {
        public string Content { get; set; }
        public string Remark { get; set; }
        public int InputType { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
