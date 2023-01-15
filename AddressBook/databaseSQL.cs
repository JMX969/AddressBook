using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBook;
internal class databaseSQL
{
    public static string connString { get; set; }

    public static List<ContactClass> loadContacts()
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            var output = conn.Query<ContactClass>("Select * from CONTACT");
            return output.ToList();
        }
    }
    public static List<ContactGroup> loadGroups()
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            var output = conn.Query<ContactGroup>("Select * from ADDRESSGROUP");
            return output.ToList();
        }
    }
    public static void saveContact(ContactClass contact)
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            conn.Execute("Insert into CONTACT (firstName, lastName, number, email, city, province, street, zipCode) " +
                "values (@firstName, @lastName, @number, @email, @city, @province, @street, @zipCode)", contact);
        }
    }
    public static void saveGroup(ContactGroup group)
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            conn.Execute("Insert into ADDRESSGROUP (groupName, groupDescription) values (@groupName, @groupDescription)", group);
        }
    }
    public static void updateContact(ContactClass contact)
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            conn.Execute("Update CONTACT Set firstName = @firstName, lastName = @lastName, number = @number, " +
                "email = @email, city = @city, province = @province, street = @street, zipCode = @zipCode " +
                "where contactID = @ContactId", contact);
        }
    }

    public static List<GroupList> loadContactsInGroups(string id)
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            var output = conn.Query<GroupList>("Select * from GROUPCONTACT where groupId = "+id+"");
            return output.ToList();
        }
    }
    public static void addContactsToGroup(GroupList group)
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            conn.Execute("Insert into GROUPCONTACT (groupId, contactID) values (@groupID, @contactID)", group);
        }
    }

    public static void deleteContact(string id)
    {
        using (IDbConnection conn = new SqliteConnection(loadConnectionString()))
        {
            conn.Execute("Delete from CONTACT where contactID = "+id+"");
        }
    }

    private static string loadConnectionString(string id = @"Data Source=addressBookDB.db;")
    {
        return id;
    }
    

}
