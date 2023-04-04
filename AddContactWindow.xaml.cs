using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Projekt_Lukasz_Motak
{
    /// <summary>
    /// Logika interakcji dla klasy AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {

        public const string DateTimeUiFormat = "dd/MM/yyyy";
        private DataChangeListener dataChangeListener;
        private bool editMode = false;
        private int id;

        public AddContactWindow(DataChangeListener dataChangeListener)
        {
            InitializeComponent();
            this.dataChangeListener = dataChangeListener;
        }
        public AddContactWindow(DataChangeListener dataChangeListener, Contact contact)
        {
            InitializeComponent();
            this.dataChangeListener = dataChangeListener;
            FirstName.Text          = contact.FirstName;
            LastName.Text           = contact.LastName;
            PhoneNumber.Text        = contact.PhoneNumber;
            Email.Text              = contact.Email;
            Birthday.Text           = contact.Birthday;
            DoneButton.Content      = "Edytuj kontakt";
            id                      = contact.Id;
            editMode                = true;
            this.Title              = "Edytuj kontakt";
        }

        private void DoneClick_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields())
            {
                DatabaseUtils database = new DatabaseUtils();
                Contact contact = new Contact
                {
                    FirstName = this.FirstName.Text,
                    LastName = this.LastName.Text,
                    PhoneNumber = this.PhoneNumber.Text,
                    Email = this.Email.Text,
                    Birthday = this.Birthday.Text,
                };

                if (editMode)
                {
                    contact.Id = this.id;
                    database.UpdateContact(contact);
                }
                else
                {
                    database.AddContact(contact);
                }
                dataChangeListener.OnDataChange();
                this.Close();
            }
        }

        private bool CheckFields()
        {
            if (
                FirstName.Text.Length   == 0 || 
                LastName.Text.Length    == 0 || 
                PhoneNumber.Text.Length == 0 || 
                Email.Text.Length       == 0 || 
                Birthday.Text.Length    == 0)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show("Uzupełnij wszystkie pola!", "Nie uzupełniono wszystkich pól", button);
                return false;
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.Match(Email.Text).Success)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show("Email jest nie poprawny!", "Błędny email", button);
                return false;
            }

            return true;
        }

        private void PhoneNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BirthdateValidation(object sender, TextCompositionEventArgs e)
        {
            DatePicker dt = (DatePicker)sender;
            string justNumbers = new String(dt.Text.Where(Char.IsDigit).ToArray());
            if (justNumbers.Length == 8)
            {
                string newDate = justNumbers.Insert(2, "/").Insert(5, "/");
                try
                {
                    dt.SelectedDate = DateTime.Parse(newDate);
                }
                catch (Exception ex)
                {
                    dt.Text = "";
                }
            }
        }
    }
}
