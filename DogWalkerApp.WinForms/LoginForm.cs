using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using System;
using System.Windows.Forms;

namespace DogWalkerApp.WinForms
{
    public partial class LoginForm : Form
    {
        private readonly ILoginService _loginService;
        private readonly DogWalkerDbContext _context;

        public LoginForm(ILoginService loginService, DogWalkerDbContext context)
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            _loginService = loginService;
            _context = context;

            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += (_, _) => System.Windows.Forms.Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (_loginService.ValidateCredentials(username, password))
            {
                Hide();

                var main = new MainMenuForm(_context);
                main.FormClosed += (_, _) => Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
