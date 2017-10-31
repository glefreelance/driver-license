using Api.Entities.Default;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities.QA
{
    public class Answer : DefaultEntity
    {
        public string Content { get; set; }
        public double Value { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
