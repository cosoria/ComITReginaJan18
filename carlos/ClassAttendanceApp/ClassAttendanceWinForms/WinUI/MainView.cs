using System;
using System.Collections.Generic;
using System.Linq;
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
            RefreshBindings();
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

        public StudentViewModel SelectedItem => lstStudents.SelectedItem as StudentViewModel;

        public void RefreshBindings()
        {
            lstStudents.DataSource = null;
            lstStudents.DisplayMember = "FullName";
            lstStudents.DataSource = _students;
        }

        private void RefreshDetailsBindings()
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
                lstLanguages.DataSource = null;
                lstLanguages.DataSource = model.Languages;
            }
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDetailsBindings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new LanguageDialog();
            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                var model = lstStudents.SelectedItem as StudentViewModel;
                if (model == null)
                {
                    return;
                }
                
                model.Languages.AddRange(dlg.SelectedLanguages);

                RefreshBindings();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var model = lstStudents.SelectedItem as StudentViewModel;
            if (model == null)
            {
                return;
            }

            var language = lstLanguages.SelectedItem as string;
            model.Languages.Remove(language);

            RefreshDetailsBindings();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var model = lstStudents.SelectedItem as StudentViewModel;
            if (model == null)
            {
                return;
            }

            _students.Remove(model);

            RefreshBindings();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var model = new StudentViewModel()
            {
                FistName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Level = cbxLevel.SelectedIndex,
            };
            foreach (var item in lstLanguages.Items)
            {
                model.Languages.Add(item.ToString());
            }

            _students.Add(model);

            DisableAdding();
            RefreshBindings();
            
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            cbxLevel.SelectedIndex = 0;
            lstLanguages.DataSource = null;

            txtFirstName.Focus();
            EnableAdding();
        }

        private void EnableAdding()
        {
            btnAddStudent.Visible = true;
            lstStudents.Enabled = false;
            lstStudents.Focus();
        }

        private void DisableAdding()
        {
            btnAddStudent.Visible = false;
            lstStudents.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dataset has been successfully saved", "Save Data", MessageBoxButtons.OK);
        }
    }
}
