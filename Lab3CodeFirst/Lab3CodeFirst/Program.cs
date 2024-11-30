using Lab3.DBFirstModels;
using Lab3CodeFirst;
using Spectre.Console;

bool isAppRunning = true;
while (isAppRunning)
{

    var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .AddChoices(
                MenuOption.ViewTable,
                MenuOption.Insert,
                MenuOption.Update,
                MenuOption.Delete,
                MenuOption.Close
                ));

    switch (option)
    {
        case MenuOption.ViewTable:
            Console.Clear();
            ClientController.ViewClients();
            break;
        case MenuOption.Insert:
            Client newClient = ClientController.getInput();
            ClientController.AddClient(newClient);
            break;
        case MenuOption.Update:
            int id = 0;
            newClient = ClientController.getInput(ref id);
            ClientController.UpdateClient(newClient, id);
            break;
        case MenuOption.Delete:
            id = AnsiConsole.Ask<int>("Enter project id: ");
            ClientController.DeleteClient(id);
            break;
        case MenuOption.Close:
            isAppRunning = false;
            Environment.Exit(0);
            break;
    }
}

enum MenuOption
{
    ViewTable,
    Insert,
    Update,
    Delete,
    Close
}