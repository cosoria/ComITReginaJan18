using System.Collections.Generic;
using System.Linq;
using Data.Repositories;

namespace WinUI
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly StudentRepository _studentRepository;
        private readonly List<LevelViewModel> _levelList = new List<LevelViewModel>()
        {
           new() { Id = 0, Name ="None"},
           new() { Id = 1, Name ="Beginner"},
           new() { Id = 2, Name ="Intermediate"},
           new() { Id = 3, Name ="Senior"},
           new() { Id = 4, Name ="Alien"},
        };

        public MainPresenter(IMainView view)
        {
            _view = view;
            _studentRepository = new StudentRepository();
        }

        public void OnLoad()
        {
            var students = _studentRepository.GetAll().Select(s => StudentViewModel.FromStudent(s)).ToList();

            _view.Students = students;
            _view.Levels = _levelList;
        }

        public void AddLanguages(List<string> languages)
        {
            var model = _view.SelectedItem;
            if (model == null)
            {
                return;
            }

            var student = _studentRepository.GetOne(model.Id);
            foreach (var language in languages)
            {
                student.AddProgrammingLanguage(language);
            }

            _view.Students = _studentRepository.GetAll().Select(StudentViewModel.FromStudent).ToList();
            _view.RefreshBindings();
        }
    }
}