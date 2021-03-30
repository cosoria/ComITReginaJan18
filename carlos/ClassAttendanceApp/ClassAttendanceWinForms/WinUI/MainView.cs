using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinUI
{
    public partial class MainView : Form, IMainView
    {
        private readonly List<StudentViewModel> _students;
        private readonly MainPresenter _presenter;
        private readonly List<LevelViewModel> _levels;

        public MainView()
        {
            _levels = new List<LevelViewModel>();
            _students = new List<StudentViewModel>();

            InitializeComponent();
            _presenter = new MainPresenter(this);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            _presenter.OnLoad();

            // Init the form
            cbxLevel.DataSource = _levels;
            lstStudents.DataSource = _students;
        }

        public IList<StudentViewModel> Students
        {
            get => _students;
            set
            {
                _students.Clear();
                _students.AddRange(value);
            }
        }

        public List<LevelViewModel> Levels
        {
            get => _levels;
            set
            {
                _levels.Clear();
                _levels.AddRange(value);
            }
        }

        public StudentViewModel SelectedItem 
        {
            get
            {
                return lstStudents.SelectedItem as StudentViewModel;
            }
        }

        public void RefreshBindings()
        {
            lstStudents.DataSource = null;
            lstStudents.DisplayMember = "FullName";
            lstStudents.DataSource = _students;
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = lstStudents.SelectedItem as StudentViewModel;

            if (model == null)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                cbxLevel.SelectedIndex = 0;
                lstLanguages.DataSource = null;
            }
            else
            {
                txtFirstName.Text = model.FistName;
                txtLastName.Text = model.LastName;
                cbxLevel.SelectedIndex = model.Level;
                lstLanguages.DataSource = model.Languages;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new LanguageDialog();
            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                _presenter.AddLanguages(dlg.SelectedLanguages);
            }
        }
    }
}
