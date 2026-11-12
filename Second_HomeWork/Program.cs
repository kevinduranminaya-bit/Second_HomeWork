try { 
Console.WriteLine("<=== Workshop Tool Control ===>");
    Dictionary<int, string> nombres = new Dictionary<int, string> ();
    Dictionary<int, string> categorias = new Dictionary<int, string> ();
    Dictionary<int, string> estados = new Dictionary<int, string>();
    List<int> ids = new List<int>();

    List<string> categoryCatalog = new List<string>() { "Hand tools", "Power tools", "Measuring" };
    List<string> stateCatalog = new List<string>() { "Available", "In Use", "Under maintenance", "Damaged" };

    bool runnig = true;
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
                    AddTool(nombres, categorias, estados, ids, categoryCatalog, stateCatalog);
                    break;
                case 2:
                    ViewTools(nombres, categorias, estados, ids);
                    break;
                case 3:
                    SearchTools(nombres, categorias, estados, ids);
                    break;
                case 4:
                    EditTool(nombres, categorias, estados, ids, categoryCatalog);
                    break;
                case 5:
                    ChangeState(estados, ids, stateCatalog);
                    break;
                case 6:
                    DeleteTool(nombres, categorias, estados, ids);
                    break;
                case 7:
                    AddCategory(categoryCatalog);
                    break;
                case 8:
                    running = false;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }



}