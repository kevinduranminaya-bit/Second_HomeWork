try 
{ 
  Console.WriteLine("<=== Workshop Tool Control ===>");
    Dictionary<int, string> names = new Dictionary<int, string> ();
    Dictionary<int, string> categories = new Dictionary<int, string> ();
    Dictionary<int, string> states = new Dictionary<int, string>();
    List<int> ids = new List<int>();

    List<string> categoryCatalog = new List<string>() { "Hand tools", "Power tools", "Measuring" };
    List<string> stateCatalog = new List<string>() { "Available", "In Use", "Under maintenance", "Damaged" };

    bool running = true;
    while (running)
    {
        try
        {
            Console.WriteLine("\n1. Add tool");
            Console.WriteLine("2. View tools");
            Console.WriteLine("3. Search tools");
            Console.WriteLine("4. Edit tools");
            Console.WriteLine("5. Change state");
            Console.WriteLine("6. Delete tool");
            Console.WriteLine("7. Add category");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Let's register a new tool.");

                        Console.Write("Tool name: ");
                        string name = Console.ReadLine() ?? string.Empty;
                        ArgumentException.ThrowIfNullOrWhiteSpace(name, "The name");

                        Console.WriteLine("Categories:");
                        for (int i = 0; i < categoryCatalog.Count; i++)
                        {
                            Console.WriteLine($"  {i + 1}. {categoryCatalog[i]}");
                        }
                        Console.Write("Choose a number: ");
                        int categoryNumber = Convert.ToInt32(Console.ReadLine());
                        string category = categoryCatalog[categoryNumber - 1];

                        int id = ids.DefaultIfEmpty(0).Max() + 1;
                        ids.Add(id);
                        names.Add(id, name.Trim());
                        categories.Add(id, category);
                        states.Add(id, stateCatalog[0]); 

                        Console.WriteLine("Tool registered with ID " + id);
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine($"{"Id",-5}{"Name",-25}{"Category",-15}State");
                        Console.WriteLine("--------------------------------------------");
                        foreach (var id in ids)
                        {
                            Console.WriteLine($"{id,-5}{names[id],-25}{categories[id],-15}{states[id]}");
                        }
                        Console.WriteLine("Total: " + ids.Count);
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Search by: 1. Name  2. Category  3. State  4. ID");
                        Console.Write("Criteria: ");
                        int criteria = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Value to search: ");
                        string value = Console.ReadLine() ?? string.Empty;
                        ArgumentException.ThrowIfNullOrWhiteSpace(value, "The value");

                        var comparison = StringComparison.OrdinalIgnoreCase;
                        List<int> found = criteria switch
                        {
                            1 => ids.Where(toolId => names[toolId].Contains(value, comparison)).ToList(),
                            2 => ids.Where(toolId => categories[toolId].Contains(value, comparison)).ToList(),
                            3 => ids.Where(toolId => states[toolId].Contains(value, comparison)).ToList(),
                            4 => ids.Where(toolId => toolId == Convert.ToInt32(value)).ToList(),
                            _ => throw new ArgumentException("Invalid search criteria.")
                        };

                        Console.WriteLine($"{"Id",-5}{"Name",-25}{"Category",-15}State");
                        Console.WriteLine("--------------------------------------------------------------");
                        foreach (var id in found)
                        {
                            Console.WriteLine($"{id,-5}{names[id],-25}{categories[id],-15}{states[id]}");
                        }
                        Console.WriteLine("Results found: " + found.Count);
                        break;
                    }

                case 4:
                    {
                        foreach (var toolId in ids)
                        {
                            Console.WriteLine($"{toolId,-5}{names[toolId],-25}{categories[toolId],-15}{states[toolId]}");
                        }

                        Console.Write("Enter the ID of the tool to edit: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        string currentName = names[id]; // Throws KeyNotFoundException if the ID does not exist
                        string currentCategory = categories[id];

                        Console.Write($"The name is: {currentName}. Enter the new name: ");
                        string newName = Console.ReadLine() ?? string.Empty;
                        ArgumentException.ThrowIfNullOrWhiteSpace(newName, "The name");

                        Console.WriteLine($"The category is: {currentCategory}. Choose the new one:");
                        for (int i = 0; i < categoryCatalog.Count; i++)
                        {
                            Console.WriteLine($"  {i + 1}. {categoryCatalog[i]}");
                        }
                        Console.Write("Choose a number: ");
                        int categoryNumber = Convert.ToInt32(Console.ReadLine());

                        names[id] = newName.Trim();
                        categories[id] = categoryCatalog[categoryNumber - 1];

                        Console.WriteLine("Tool updated successfully.");
                        break;
                    }

                case 5:
                    {
                        foreach (var toolId in ids)
                        {
                            Console.WriteLine($"{toolId,-5}{names[toolId],-25}{categories[toolId],-15}{states[toolId]}");
                        }

                        Console.Write("Enter the ID of the tool: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        string currentState = states[id]; // Throws KeyNotFoundException if the ID does not exist

                        Console.WriteLine($"The current state is: {currentState}. Choose the new one:");
                        for (int i = 0; i < stateCatalog.Count; i++)
                        {
                            Console.WriteLine($"  {i + 1}. {stateCatalog[i]}");
                        }
                        Console.Write("Choose a number: ");
                        int stateNumber = Convert.ToInt32(Console.ReadLine());

                        states[id] = stateCatalog[stateNumber - 1];

                        Console.WriteLine("State updated successfully.");
                        break;
                    }

                case 6:
                    {
                        foreach (var toolId in ids)
                        {
                            Console.WriteLine($"{toolId,-5}{names[toolId],-25}{categories[toolId],-15}{states[toolId]}");
                        }

                        Console.Write("Enter the ID of the tool to delete: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        string name = names[id]; // Throws KeyNotFoundException if the ID does not exist

                        Console.WriteLine($"Are you sure you want to delete '{name}'? 1. Yes, 2. No");
                        int confirmation = Convert.ToInt32(Console.ReadLine());

                        switch (confirmation)
                        {
                            case 1:
                                names.Remove(id);
                                categories.Remove(id);
                                states.Remove(id);
                                ids.Remove(id);
                                Console.WriteLine("Tool deleted.");
                                break;
                            default:
                                Console.WriteLine("Deletion cancelled.");
                                break;
                        }
                        break;
                    }

                case 7:
                    {
                        Console.Write("New category name: ");
                        string newCategory = Console.ReadLine() ?? string.Empty;
                        ArgumentException.ThrowIfNullOrWhiteSpace(newCategory, "The category name");

                        categoryCatalog.Add(newCategory.Trim());
                        Console.WriteLine("Category added.");
                        break;
                    }

                case 8:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        catch (FormatException)
        {
            Console.WriteLine("Error: you must enter a valid number.");
        }

        catch (KeyNotFoundException)
        {
            Console.WriteLine("Error: the ID you entered does not exist. Please try again.");
        }

        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Error: the ID you entered is out of range. Please try again.");
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    Console.WriteLine("Goodbye!");
}
catch (Exception ex)
{
    Console.WriteLine("An unexpected error occurred: " + ex.Message);
}