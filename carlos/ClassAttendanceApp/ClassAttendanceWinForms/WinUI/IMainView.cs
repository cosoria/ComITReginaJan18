using System.Collections.Generic;

namespace WinUI
{
    public interface IMainView
    {
        IList<StudentViewModel> Students { get; set; }
        List<LevelViewModel> Levels { get; set; }
        StudentViewModel SelectedItem { get; }
        void RefreshBindings();
    }
}