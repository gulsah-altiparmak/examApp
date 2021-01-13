using System.Collections.Generic;
namespace Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }

    }
}