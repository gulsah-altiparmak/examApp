using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamApp.Controllers
{
    public class ExamController:Controller
    {
        private readonly ILogger<ExamController> _logger;
        private readonly DataContext _context;
         public ExamController(ILogger<ExamController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
          public IActionResult Index()
        {
            
            return View();
        }

          public List<Exam> GetExams()
        {

            var list = _context.Exams.ToList();

            return list;
        }
        public IActionResult DeleteExam(int examId)
        {
            var deletedExam = _context.Exams.FirstOrDefault(x => x.Id == examId);
            deletedExam.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}