// See https://aka.ms/new-console-template for more information

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Runtime.CompilerServices;
static string connectionString = @"Data Source=habit-Tracker.db";

using (var connection = new SqliteConnection(connectionString))
{
  connection.Open();
  var tableCmd = connection.CreateCommand();

  tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS drinking_water ( Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)";

  tableCmd.ExecuteNonQuery();
  connection.Close();
}

static void GetUserInput()
{
  Console.Clear();
  bool closeApp = false;

  while (closeApp == false)
  {
    Console.WriteLine("\n\nMAIN MENU");
    Console.WriteLine("\nWhat would you like to do?");
    Console.WriteLine("\nType 0 to Close Application.");
    Console.WriteLine("Type 1 to View All Records.");
    Console.WriteLine("Type 2 to Insert Record.");
    Console.WriteLine("Type 3 to Delete Record.");
    Console.WriteLine("Type 4 to Update Record.");
    Console.WriteLine("------------------------------------------\n");

    string commandInput = Console.ReadLine();

    switch (commandInput)
    {
      case "0":
        Console.WriteLine("\nGoodbye!\n");
        closeApp = true;
        break;
      case "2":
        Insert();
        break;
      default:
        Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
        break;
    }
  }
}

static void Insert()
{
  string date = GetDateInput();

  int quantity = GetNumberInput("\n\nPlease insert number of glasses or other measure of your choice (no decimals allowed)\n\n");
  using (var connection = new SqliteConnection(connectionString))
  {
    connection.Open();
  }
}

static string GetDateInput()
{
  Console.WriteLine("\n\nPlease insert the date: (Formate: dd-mm-yy). Type 0 to return to main menu");
  string dateInput = Console.ReadLine();
  if (dateInput == "0") GetDateInput();
  return dateInput;
}

static int GetNumberInput(string message)
{
  Console.WriteLine(message);

  string numberInput = Console.ReadLine();

  if (numberInput == "0") GetUserInput();
  int finalInput = Convert.ToInt32(numberInput);
  return finalInput;
}


GetUserInput();