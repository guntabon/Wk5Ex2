using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5Ex2
{
    class Program
    {
        //I initialized the dictionary contactList at the beginning so I could reference it later in methods and in main. I set up the phone number as a string so i didnt have to worry about the format the user entered
        static Dictionary<string, string> contactList = new Dictionary<string, string>();

        //Created a method called addContact to edit the dictionary contactList
        public static void addContact(string contact, string phoneNumber)
        {
            //adds a contact using the parameters from contact and phoneNumber 
            contactList.Add(contact, phoneNumber);
            
        }

        //Created a method called removeContact to search and remove contacts from the dictionary
        public static void removeContact(string contact)
        {
            //Used if statement to check if the searched contact exists, then erases it
            if (contactList.ContainsKey(contact))
            {
                //Command to remove the contact using the contact parameter
                contactList.Remove(contact);
                //Informs the user the operation was successful
                Console.WriteLine("Successfully removed");
            }
            //else statement for any errors
            else
            {
                //Informs user the contact has not been found
                Console.WriteLine("Contact not found");
            }
        }

        //Method that allows the user to search a contact
        static void searchContact(string contact)
        {
            //If statement to check entered value matches anything within the dictionary
            if (contactList.ContainsKey(contact))
            {
                //Writes out the contact name and phone number using the parameters entered into it previously
                Console.WriteLine($"Name: {contact}, Phone Number: {contactList[contact]}");
            }
            //else  statement to continue for error
            else
            {
                //Informs user the contact entered could not be found
                Console.WriteLine("Contact not found.");

            }
        }

        //Method to display all stored contacts
        public static void displayContact()
        {
            //Initialized an int myCount to see if there are any values entered into contactList
            int myCount = contactList.Count();
            //Set if statement to inform user there are no entries in the contactList
            if (myCount == 0)
            {
                //Writes a message informing the user there are no contacts
                Console.WriteLine("There are no contacts entered.");
            }
            //Else statement to proceed with normal displayContact() method
            else
            {
                //Used a foreach statement, using the key value pairs to list them out
                foreach (KeyValuePair<string, string> contact in contactList)
                {
                    //Writes out Name and Phone number, using the 0 and 1 postions, from teh .key and .Value 
                    Console.WriteLine("Name: {0}, Phone Number: {1}", contact.Key, contact.Value);
                }

            }
        }

        static void Main(string[] args)
        {
            //initialized userChoice so I could let users select an option
            int userChoice = 0;

            //Set a bool to control if loop runs again or not
            bool isTrue = true;

            




            //While loop to control status of user's intent to continue
            while (isTrue == true)
            {


                //Informs user of application name
                Console.WriteLine("Welcome to Contact Management application.");

                //Prompts option 1, add contact
                Console.WriteLine("1. Add Contact");

                //Prompts option 2, remove contact
                Console.WriteLine("2. Remove Contact");

                //Prompts option 3, search contact
                Console.WriteLine("3. Search Contact");

                //Prompts option 4, Display all currently stored contacts
                Console.WriteLine("4. Display All Contacts");

                //Prompts option 4, Exiting the application
                Console.WriteLine("5. Exit");

                //Try to catch improper input in the user selection. Kept it in the while loop so the user doesnt need to restart the application in case of a mistake
                try
                {
                    //Converts userChoice to an entered value to control the switch case
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                //Catch error to make sure no values are entered incorrectly
                catch (Exception e)
                {
                    //Writes out error message for user
                    Console.WriteLine("Please enter a valid number (1-5)");

                }
                //used a switch case as a form of user GUI
                switch (userChoice)
                {
                    //Case 1, add contact. I referenced addContact() using two Console.ReadLine commands so the user could input values to use
                    case 1:

                        //Prompts user to enter values for use
                        Console.WriteLine("Please enter the name, press the enter key, and then enter phone number for the new contact");

                        //References addContact and allows the user to enter two values to add to the contact list
                        addContact(Console.ReadLine(), Console.ReadLine());
                        //Informs user the operation was successful
                        Console.WriteLine("You have successfully added your contact to the list.");
                        //breaks switch case
                        break;

                    //Case 2, remove contact
                    case 2:
                        //Prompts user to enter a contact to remove
                        Console.WriteLine("Please enter a contact to remove: ");
                        //Creates the remove variable and assigns it to the value the user enters
                        string remove = Console.ReadLine();
                        //Takes the value the user entered and uses it as a condition for the removeContact operation
                        removeContact(remove);
                        //breaks code for second case
                        break;
                    //Case 3, searches specific contact
                    case 3:
                        //Prompts user to enter specific contact name
                        Console.WriteLine("Please enter a contact to search: ");
                        //Assigns string variable newSearch to user entry through Console.ReadLine()
                        string newSearch = Console.ReadLine();
                        //Uses the searchContact method with newSearch as the variable
                        searchContact(newSearch);
                        //breaks code for case 3
                        break;

                    //Case 4, displays all contacts
                    case 4:
                        //Uses method for displayContact(), listing all currently stored values in the dictionary
                        displayContact();
                        //Breaks code for case 4
                        break;
                    //Case 5, exits the application
                    case 5:
                        //Sets the isTrue variable to false, allowing the while loop to close
                        isTrue = false;
                        //Breaks the code for case 5
                        break;
                    //Default case, prompts user to enter a correct value
                    default:
                        //Prompts user to enter a number between 1-5
                        Console.WriteLine("Please select an option between (1-5)");
                        //Breaks code for default case
                        break;
                }

            }


        }
    }
}
