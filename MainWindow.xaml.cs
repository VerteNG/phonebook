using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System;

namespace Projekt_Lukasz_Motak
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, DataChangeListener
    {
        public DatabaseUtils databaseUtils;
        public List<Contact> contacts;
        public List<DateTime> thisWeek;
        public List<Contact> checkedContacts;

        public MainWindow()
        {
            InitializeComponent();
            countThisWeek();
            databaseUtils = new DatabaseUtils();
            checkedContacts = new List<Contact>();
            OnDataChange();
        }

        public void OnDataChange()
        {
            contacts = databaseUtils.GetContactsList();
            CountDate(contacts);
            ListViewDataBinding.ItemsSource = contacts;
            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(ListViewDataBinding.ItemsSource);
            collectionView.Filter = ContactsFilter;
        }

        public bool ContactsFilter(object item)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
                return true;
            else
                return ((item as Contact).FirstName.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as Contact).LastName.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as Contact).Email.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as Contact).PhoneNumber.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as Contact).Birthday.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void CountDate(List<Contact> contacts)
        {
            List<Contact> birthdayContacts = new List<Contact>();
            foreach (Contact contact in contacts)
            {
                DateTime birthday = Convert.ToDateTime(contact.Birthday);
                birthday = birthday.AddYears(DateTime.Now.Year - birthday.Year);
                foreach (DateTime day in thisWeek)
                {
                    if (birthday == day)
                    {
                        var c = new Contact(contact);
                        c.Birthday = c.Birthday.Substring(0, 5);
                        birthdayContacts.Add(c);
                        break;
                    }
                }
            }
            BirthdaysDataBinding.ItemsSource = birthdayContacts;
        }

        public void countThisWeek()
        {
            thisWeek = new List<DateTime>();
            for (int i = 0; i <= 6; i++)
            {
                DateTime day = DateTime.Now.AddDays(i - convertDaysCode(DateTime.Now.DayOfWeek.GetHashCode()));
                DateTime _day = new DateTime(day.Year, day.Month, day.Day);
                thisWeek.Add(_day);
                Console.WriteLine(thisWeek[thisWeek.Count - 1]);
            }
        }

        public int convertDaysCode(int code)
        {
            if (code == 0) return 6;
            else return code - 1;
        }

        public void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            AddContactWindow addContactWindow = new AddContactWindow(this);
            addContactWindow.Show();
        }

        public void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                AddContactWindow addContactWindow = new AddContactWindow(this, item.Content as Contact);
                addContactWindow.Show();
            }
        }

        public void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListViewDataBinding.ItemsSource).Refresh();
        }

        public void HandleCheck(object sender, RoutedEventArgs e)
        {
            if (ListViewDataBinding.SelectedItems.Count >= 1)
            {
                DeleteButton.IsEnabled = true;
            }
        }

        public void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            if (ListViewDataBinding.SelectedItems.Count < 1)
            {
                DeleteButton.IsEnabled = false;
            }
        }

        public void DeleteCheckedButton_Click(object sender, RoutedEventArgs e)
        {
            var items = ListViewDataBinding.SelectedItems;
            if (items.Count > 0)
            {
                string text = "Czy na pewno chcesz usunać te kontakty: \n";
                foreach (Contact item in items)
                {
                    text += item.FirstName + " " + item.LastName + "\n";
                }
                text += "?";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(text, "Usuń", button);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            foreach (Contact item in items)
                            {
                                databaseUtils.DeleteContact(item.Id);
                            }
                            OnDataChange();
                            break;
                        }
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}