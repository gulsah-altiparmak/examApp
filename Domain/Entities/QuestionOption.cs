using Domain.Enums;

namespace Domain.Entities
{
    public class QuestionOption
    {
        public int Id { get; set; }
        public  OptionsOrder OptionsOrder { get; set; }

        public bool IsCorrect { get; set; }

        

    }
}