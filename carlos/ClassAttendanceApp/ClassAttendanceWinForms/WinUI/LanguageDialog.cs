using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinUI
{
    public partial class LanguageDialog : Form
    {
        private readonly List<string> _selectedLanguages;
        public List<string> SelectedLanguages => _selectedLanguages;

        public List<string> _languages = new List<string>()
        {
            "C#",
            "VB.NET",
            "Java",
            "F#",
            "Clojure",
            "Scala",
            "Haskell",
            "Python",
            "JavaScript",
            "TypeScript",
            "Dart",
            "C++",
            "Go",
            "Rust",
            "Kotlin",
            "Swift",
            "R",
            "Powershell",
            "Bash",
            "TSQL",
            "PL/SQL"
        };

        

        public LanguageDialog()
        {
            InitializeComponent();

            _selectedLanguages = new List<string>();
            checkedListBox1.DataSource = _languages;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                _selectedLanguages.Add(item.ToString());
            }
            
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
