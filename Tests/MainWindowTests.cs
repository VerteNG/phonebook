using NUnit.Framework;
using Projekt_Lukasz_Motak;
using System.Collections.Generic;

[TestFixture]
public class MainWindowTests
{
    private MainWindow window;

    [SetUp]
    public void SetUp()
    {
        window = new MainWindow();
    }

    [Test]
    public void OnDataChange_SetsContactsList()
    {
        window.OnDataChange();
        Assert.IsNotNull(window.contacts);
    }

    [Test]
    public void ContactsFilter_ReturnsTrue_WhenSearchBoxIsEmpty()
    {
        window.searchBox.Text = "";
        Assert.IsTrue(window.ContactsFilter(new Contact()));
    }

    [Test]
    public void CountDate_SetsBirthdaysDataBinding()
    {
        var contacts = new List<Contact>
        {
            new Contact { Birthday = "2000-04-04" }
        };
        window.CountDate(contacts);
        Assert.IsNotNull(window.BirthdaysDataBinding.ItemsSource);
    }

    [Test]
    public void convertDaysCode_Returns6_WhenCodeIs0()
    {
        Assert.AreEqual(6, window.convertDaysCode(0));
    }

    [Test]
    public void HandleCheck_SetsDeleteButtonEnabled_WhenSelectedItemsCountIsAtLeast1()
    {
        window.ListViewDataBinding.SelectedItems.Add(new Contact());
        window.HandleCheck(null, null);
        Assert.IsTrue(window.DeleteButton.IsEnabled);
    }

    [Test]
    public void HandleUnchecked_SetsDeleteButtonDisabled_WhenSelectedItemsCountIsLessThan1()
    {
        window.ListViewDataBinding.SelectedItems.Clear();
        window.HandleUnchecked(null, null);
        Assert.IsFalse(window.DeleteButton.IsEnabled);
    }
}
