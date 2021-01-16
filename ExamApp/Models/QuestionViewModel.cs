using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Models
{
    public class QuestionViewModel
    { 
  public QuestionViewModel()
  {

  }
        public string Title { get; set; }
        public string FirstOption { get; set; }
         public string SecondOption { get; set; }
          public string ThirdOption { get; set; }
           public string FourthOption { get; set; }
           public SelectList Answers =>new SelectList(new[]
            {
                new {ID="1", Name="A"},
                new {ID="2", Name="B"},
                new {ID="3", Name="C"},
                new {ID="4", Name="D"}
            }, "ID", "Name");
           public int AnswerId { get; set; }
           public List<QuestionOption> QuestionOptions {get;set;}
        public List<QuestionOption> questionOptions(){
            var options=new List<QuestionOption>();
            options.Add(new QuestionOption{
                   Title=FirstOption,
                   OptionsOrder=OptionsOrder.A
               });
                  options.Add(new QuestionOption{
                   Title=SecondOption,
                   OptionsOrder=OptionsOrder.B
               });
                 options.Add(new QuestionOption{
                   Title=ThirdOption,
                   OptionsOrder=OptionsOrder.C
               });
                options.Add(new QuestionOption{
                   Title=FourthOption,
                   OptionsOrder=OptionsOrder.D
               });
             return options;
        } 

    }
    
}