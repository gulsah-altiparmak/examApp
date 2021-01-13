using System.Collections.Generic;

namespace Domain.Entities
{
    public class ExamQuestion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExamId { get; set; }
       public int Answer { get; set; }

       public virtual Exam Exam {get; set;}
       public virtual ICollection<QuestionOption> QuestionOption{ get; set; }
       

    }
}