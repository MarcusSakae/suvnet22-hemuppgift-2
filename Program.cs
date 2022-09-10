const int ADDRESS_BOOK_SIZE = 100;


int Command = 0;
// We use a CSV format for each entry. We replace any actual commas with dots.
string[] Addresses = new string[ADDRESS_BOOK_SIZE];
int AddressCount = 0;

while (true)
{
    ShowMenu();
    Command = ReceiveCommand();

    // Process command
    switch (Command)
    {
        case 1:
            AddAddress();
            break;

        case 2:
            ShowAddresses();
            break;

        case 3:
            ClearAddresses();
            break;

        case 4:
            ExitProgram();
            break;
    }

}

///
///
///
void ShowHeader()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Adressbok:");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("-----------------------------------------");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Antal addresser: ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(AddressCount);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\tAntal tecken: ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(AddressBookCharCount());
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("-----------------------------------------");
}

///
/// Returns the total number of characters in the address book.
///
int AddressBookCharCount()
{
    int total = 0;
    foreach (string entry in Addresses)
    {
        if (entry != null)
        {
            // Vi räknar inte komma-tecknet mellan namn och address.
            total += entry.Replace(",", "").Length;
        }
    }
    return total;
}


///
///
///
void ExitProgram()
{
    ShowHeader();
    AddressCount = 0;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Tack för idag!");
    Environment.Exit(0);
}

///
///
///
void ClearAddresses()
{

    ShowHeader();
    Array.Clear(Addresses);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Adressboken har blivigt rensad!");
    PromptForContinue();
}

///
///
///
void ShowAddresses()
{
    ShowHeader();
    if(AddressCount == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Adressboken är tom!");
        PromptForContinue();
        return;
    }
    foreach (string entry in Addresses)
    {
        if (entry == null)
        {
            continue;
        }

        // The split should give us an array where: 
        //      [0] = name, [1] = address
        string[] entry_data = entry.Split(",");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Name: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(entry_data[0]);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Address: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(entry_data[1]);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("-----------------------");
    }
    PromptForContinue();
}

void PromptForContinue()
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\n\nTryck på en tangent för att fortsätta...");
    Console.ReadKey();
}

///
///
///
void ShowMenu()
{
    ShowHeader();
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("1. ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Lägg till address");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("2. ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Lista alla");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("3. ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Rensa addressbok");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("4. ");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("Avsluta");
}


///
///
///
int ReceiveCommand()
{
    int input = 0;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Välj: ");
    int.TryParse(Console.ReadKey().KeyChar.ToString(), out input);
    return input;

}

///
///
///
void AddAddress()
{
    ShowHeader();

    // Get Input
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Ange namn: ");
    Console.ForegroundColor = ConsoleColor.White;
    string namn = Console.ReadLine()!;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Ange address: ");
    Console.ForegroundColor = ConsoleColor.White;
    string address = Console.ReadLine()!;

    // Replace commas with dots as to not break our CSV format. 
    namn = namn.Replace(",", ".");
    address = address.Replace(",", ".");
    
    // Add to array
    Addresses[AddressCount] = namn + "," + address;
    AddressCount++;
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Address added!");
    PromptForContinue();
}

