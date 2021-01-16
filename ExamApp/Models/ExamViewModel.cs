using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Models
{
    public class ExamViewModel
    { public ExamViewModel()
    {
        FirstQuestion= new QuestionViewModel();
        SecondQuestion= new QuestionViewModel();
        ThirdQuestion= new QuestionViewModel();
        FourthQuestion= new QuestionViewModel();

    
    }
        public SelectList Exams { get; set; }
        public int ExamId { get; set; }
        public string Content { get; set; }
        public QuestionViewModel FirstQuestion { get; set; }
        public QuestionViewModel SecondQuestion { get; set; }
        public QuestionViewModel ThirdQuestion { get; set; }
        public QuestionViewModel FourthQuestion { get; set; }

        public List<QuestionViewModel> QuestionViewModels {get;set;}
    


    }
}