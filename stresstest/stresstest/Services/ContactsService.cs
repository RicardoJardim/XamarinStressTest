using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
namespace stresstest.Services
{
    public class ContactsService
    {
        public ContactsService()
        {
        }

        public async Task GetContacs()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();
                if(status == PermissionStatus.Denied)
                {
                   status =  await Permissions.RequestAsync<Permissions.ContactsRead>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var contacts = await Contacts.GetAllAsync();

                    if (contacts == null)
                        return;

                    foreach (var contact in contacts)
                        Console.WriteLine(contact.DisplayName);
                }
 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
