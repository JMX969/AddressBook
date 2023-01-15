using AddressBook;
using Microsoft.Data.Sqlite;
using System.Data;

Boolean exitCounter = true;

int displayContacts()
{
    List<ContactClass> cont = new List<ContactClass>();

    cont = databaseSQL.loadContacts();
    int counter = 0;
    foreach (ContactClass c in cont)
    {
        Console.WriteLine("Contact: " + c.ContactId);
        Console.WriteLine("FirstName: " + c.firstName + "\nLastName: " + c.lastName + "\nNumber: " + c.number + "\nEmail: " + c.email + "\nCity: " + c.city + "\nProvince: " + c.province + "\nStreet: " + c.street + "\nZipCode: " + c.zipCode + "\n");
        counter++;
    }
    return counter;
}

while (exitCounter) //Main menu
{
    Console.WriteLine("Welcome to your AddressBook\n");
    Console.WriteLine("1 - View contacts");
    Console.WriteLine("2 - Add new contact");
    Console.WriteLine("3 - Update Contact");
    Console.WriteLine("4 - Search Contacts");
    Console.WriteLine("5 - View Groups");
    Console.WriteLine("6 - Delete Contact");
    Console.WriteLine("7 - Exit");

    string input = Console.ReadLine();//get user input

    if (input == "1")//Display All Contacts
    {
        displayContacts();
    }
    if (input == "2")//Add new contact
    {
        ContactClass cc = new ContactClass();
        Console.WriteLine("Add new Contact");
        Console.Write("Enter FirstName: ");
        cc.firstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        cc.lastName = Console.ReadLine();
        Console.Write("Enter Number: ");
        cc.number = Console.ReadLine();
        Console.Write("Enter Email: ");
        cc.email = Console.ReadLine();
        Console.Write("Enter City: ");
        cc.city = Console.ReadLine();
        Console.Write("Enter Province: ");
        cc.province = Console.ReadLine();
        Console.Write("Enter Street: ");
        cc.street = Console.ReadLine();
        Console.Write("Enter ZipCode: ");
        cc.zipCode = Console.ReadLine();

        databaseSQL.saveContact(cc);

        Console.WriteLine("Contact was succesfully added to AddressBook...");

    }
    if (input == "3")//Update Contact
    {
        List<ContactClass> cont = new List<ContactClass>();

        cont = databaseSQL.loadContacts();
        foreach (ContactClass c in cont)
        {
            Console.WriteLine("Contact: " + c.ContactId);
            Console.WriteLine("FirstName: " + c.firstName + "\nLastName: " + c.lastName + "\nNumber: " + c.number + 
                "\nEmail: " + c.email + "\nCity: " + c.city + "\nProvince: " + c.province + "\nZipCode: " + c.zipCode + "\n");
        }
        Console.Write("Enter contact number to edit: ");
        string conInput = Console.ReadLine();
        try
        {
            int num = Convert.ToInt32(conInput) - 1;
            Console.WriteLine("\nFirstName: " + cont[num].firstName + "\nLastName: " + cont[num].lastName + "\nNumber: " + cont[num].number + 
                "\nEmail: " + cont[num].email + "\nCity: " + cont[num].city + "\nProvince: " + cont[num].province + "\nZipCode: " + cont[num].zipCode + "\n");

            Console.WriteLine("Update contact details or enter blank to keep the original\n");
            string upd = "";
            //Update contact details
            Console.Write("Update FirstName '"+cont[num].firstName+"'' : ");
            upd = Console.ReadLine();
            if(upd.Length>0)
                cont[num].firstName = upd;
            Console.Write("Update LastName '"+cont[num].lastName+"' : ");
            upd = Console.ReadLine();
            if (upd.Length > 0)
                cont[num].lastName = upd;
            Console.Write("Update Number '"+cont[num].number+"' : ");
            upd = Console.ReadLine();
            if (upd.Length > 0)
                cont[num].number = upd;
            Console.Write("Update Email '"+cont[num].email+"' : ");
            upd = Console.ReadLine();
            if (upd.Length > 0)
                cont[num].email = upd;
            Console.Write("Enter City '"+cont[num].city+"' : ");
            upd = Console.ReadLine();
            if (upd.Length > 0)
                cont[num].city = upd;
            Console.Write("Enter Province '"+cont[num].province+"' : ");
            upd = Console.ReadLine();
            if (upd.Length > 0)
                cont[num].province = upd;
            Console.Write("Enter Street '"+cont[num].street+"' : ");
            upd = Console.ReadLine();
            if (upd.Length > 0)
                cont[num].street = upd;
            Console.Write("Enter ZipCode '"+cont[num].zipCode+"' : ");
            upd = Console.ReadLine();
            if (upd.Length > 0)
                cont[num].zipCode = upd;

            databaseSQL.updateContact(cont[num]);
            Console.WriteLine("Update Completed\n");
        }
        catch (Exception ex) { Console.WriteLine("Invalid contact number..."); }
    }
    if (input == "4")
    {
        Boolean searchMenu = true;
        string ser = "";
        while (searchMenu)
        {
            Console.WriteLine("1 - Search by FirstName");
            Console.WriteLine("2 - Search by LastName");
            Console.WriteLine("3 - Exit");
            input = Console.ReadLine();

            if (input == "1")//search by firstName
            {
                Console.Write("Enter FirstName: ");
                ser = Console.ReadLine();

                List<ContactClass> cont = new List<ContactClass>();

                cont = databaseSQL.loadContacts();
                //int counter = 1;
                foreach (ContactClass c in cont)
                {
                    if (c.firstName == ser)
                    {
                        Console.WriteLine("Contact: " + c.ContactId);
                        Console.WriteLine("FirstName: " + c.firstName + "\n");
                    }
                }
                Console.WriteLine("Enter the contact number to view the full contact...");
                Console.WriteLine("Enter 'e' to go back");
                string serInput = Console.ReadLine();
                try
                {
                    int num = Convert.ToInt32(serInput);
                    Console.WriteLine(cont[num].firstName+ "\n");
                }
                catch (Exception ex) { Console.WriteLine("Exit"); }

            }
            if (input == "2")//search by lastName
            {
                Console.Write("Enter LastName: ");
                ser = Console.ReadLine();

                List<ContactClass> cont = new List<ContactClass>();

                cont = databaseSQL.loadContacts();
                foreach (ContactClass c in cont)
                {
                    if (c.lastName == ser)
                    {
                        Console.WriteLine("Contact: " + c.ContactId);
                        Console.WriteLine("LastName: " + c.lastName + "\n");
                    }
                }
                Console.WriteLine("Enter the contact number to view the full contact...");
                Console.WriteLine("Enter 'e' to go back");
                string serInput = Console.ReadLine();
                try
                {
                    int num = Convert.ToInt32(serInput)-1;
                    Console.WriteLine("\nFirstName: " + cont[num].firstName + "\nLastName: " + cont[num].lastName + "\nNumber: " + cont[num].number + 
                        "\nEmail: " + cont[num].email + "\nCity: " + cont[num].city + "\nProvince: " + cont[num].province + "\nZipCode: " + cont[num].zipCode + "\n");
                }
                catch (Exception ex) { Console.WriteLine("Exit"); }
            }
            if (input == "3") searchMenu = false;
        }
        
    }
    if (input == "5") //groups menu
    {
        Boolean groupMenu = true;
        while (groupMenu)
        {
            List<ContactGroup> groupList = new List<ContactGroup>();
            Console.WriteLine("Groups");
            Console.WriteLine("Enter group number to view group \nEnter 0 to create a new group\nEnter e to exit\n");
            //int counter = 0;
            string groupInput = "";
            groupList = databaseSQL.loadGroups();
            
            foreach (ContactGroup group in groupList)
            {
                Console.WriteLine("Group Number: " + group.groupId + 
                    "\nName: " + group.groupName + "\nDesccription: " + group.groupDescription + "\n");
            }
            groupInput = Console.ReadLine();

            if (groupInput == "0")
            {
                ContactGroup cg = new ContactGroup();

                Console.WriteLine("Create a new group...\n");
                Console.Write("Enter group Name: ");
                cg.groupName = Console.ReadLine();
                Console.Write("Enter group Description: ");
                cg.groupDescription = Console.ReadLine();

                databaseSQL.saveGroup(cg);
            }
            if (groupInput == "e") groupMenu = false;
            try
            {
                int contactNum = Convert.ToInt32(groupInput);
                Console.WriteLine("Group Number: " + groupList[contactNum].groupId + "\nName: " + groupList[contactNum].groupName + 
                    "\nDesccription: " + groupList[contactNum].groupDescription + "\n");
                Console.WriteLine("Contacts: ");
                List<GroupList> contactsinGroupList = new List<GroupList>();

                contactsinGroupList = databaseSQL.loadContactsInGroups(groupList[contactNum].groupId);
                List<ContactClass> contacts = new List<ContactClass>();
                contacts = databaseSQL.loadContacts();
                //int counter = 1;
                foreach (ContactClass c in contacts)
                {
                    foreach (GroupList x in contactsinGroupList)
                    {
                        if (c.ContactId == x.contactID)
                        {
                            Console.WriteLine("Contact: " + c.ContactId);
                            Console.WriteLine("FirstName: " + c.firstName + "\nLastName: " + c.lastName + "\nNumber: " + c.number + 
                                "\nEmail: " + c.email + "\nCity: " + c.city + "\nProvince: " + c.province + "\nStreet: " + c.street + "\nZipCode: " + c.zipCode + "\n");
                        }
                    }
                }

                Console.WriteLine("\n1 - Add contacts to group");
                Console.WriteLine("2 - Remove contacts from group");
                Console.WriteLine("3 - Exit");

                string gInput = Console.ReadLine();

                if (gInput == "1")
                {
                    Boolean addContacts = true;

                    List<ContactClass> cont = new List<ContactClass>();

                    cont = databaseSQL.loadContacts();
                    int counter = 0;
                    foreach (ContactClass c in cont)
                    {
                        Console.WriteLine("Contact: " + c.ContactId);
                        Console.WriteLine("FirstName: " + c.firstName + "\nLastName: " + c.lastName + "\nNumber: " + c.number + 
                            "\nEmail: " + c.email + "\nCity: " + c.city + "\nProvince: " + c.province + "\nStreet: " + c.street + "\nZipCode: " + c.zipCode + "\n");
                        counter++;
                    }
                    Console.WriteLine("Enter contact ID to add them to the group\nEnter 'e' to exit");
                    GroupList gList = new GroupList();
                    while(addContacts)
                    {
                        Console.Write("ID number: ");
                        string addInput = Console.ReadLine();
                        try
                        {

                            if (addInput == "e") { addContacts = false; }
                            else
                            {
                                int conNum = Convert.ToInt32(addInput);
                                if (conNum > 0 && conNum <= counter) 
                                {
                                    gList.groupID = groupList[contactNum].groupId;
                                    gList.contactID = conNum.ToString();
                                    databaseSQL.addContactsToGroup(gList);
                                    Console.WriteLine("Contact added to group");
                                }
                            }

                        }catch(Exception e) { Console.WriteLine("Invalid ID number"); }
                    }

                }

            }
            catch(Exception ex) { Console.WriteLine("Invalid input"); }
        }
    }

    if (input == "6")//Delete Contact
    {
        Console.WriteLine("Delete Contact\n");
        int total = displayContacts();
        Boolean del = true;
        while (del)
        {
            Console.WriteLine("Enter Contact ID to delete the Contact");
            Console.WriteLine("Enter 'e' to Exit");
            Console.Write("Input: ");
            string inp = Console.ReadLine();
            if(inp == "e") { del = false;}
            else
            {
                try
                {
                    int delId = Convert.ToInt32(inp);
                    if(delId > 0 && delId <= total)
                    {
                        Console.WriteLine("Contact Deleted");
                        databaseSQL.deleteContact(delId.ToString());
                    }

                }
                catch(Exception e) { Console.WriteLine("Invalid input"); }
            }
        }

    }

    if (input == "7") exitCounter = false;//Exit
}
