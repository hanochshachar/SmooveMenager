// See https://aka.ms/new-console-template for more information
using SmooveMenager;

/*Console.Write("enter api key: ");
string apiKey = Console.ReadLine();
Console.Write("give a private name: ");
string name = Console.ReadLine();
Console.Write("give a public name: ");
string publicName = Console.ReadLine();*/

Smoove smoove = new Smoove();

//await smoove.CreateList( apiKey, name, publicName);

/*Console.Write("enter api key: ");
string apiKeyAdd = Console.ReadLine();

Console.Write("enter an email: ");
string email = Console.ReadLine();

Console.Write("enter a phone number: ");
string phone = Console.ReadLine();

Console.Write("Enter lists: ");
string list = Console.ReadLine();

Console.Write("enter last name: ");
string lName = Console.ReadLine();

Console.Write("enter first name: ");
string fName = Console.ReadLine();



await smoove.AddToList(apiKeyAdd, email, phone, list, fName, lName);*/

Console.Write("enter api key: ");
string apiKeyMsg = Console.ReadLine();

Console.Write("enter reciever phone nu: ");
string reciever = Console.ReadLine();

Console.Write("enter sender phone nu: ");
string sender = Console.ReadLine();

Console.Write("enter message: ");
string msg = Console.ReadLine();

await smoove.SendMessage(apiKeyMsg, reciever, sender, msg);

Console.Write("enter api key: ");
string apiKeyList = Console.ReadLine();

await smoove.GetLists(apiKeyList);




