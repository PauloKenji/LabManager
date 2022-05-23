using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;

var databaseConfig = new DatabaseConfig();

new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig); 
var laboratoryRepository = new LaboratoryRepository(databaseConfig);

//routing
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }
    }

    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

        Console.WriteLine("Computer New");
        Console.WriteLine("{0}, {1}, {2}", id, ram, processor);

        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);
        
        command.ExecuteNonQuery();

        connection.Close();
    }

}

if(modelName == "Laboratory"){

    if (modelAction == "List")
    {
       Console.WriteLine("Laboratory List");

       foreach (var laboratory in laboratoryRepository.GetAll())
       {
           Console.WriteLine("{0}, {1}, {2}, {3}", laboratory.Id, laboratory.Number, laboratory.Name, laboratory.Block);
       }
    }

    if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var number = Convert.ToInt32(args[3]);
        var name = args[4];
        var block = args[5];

        var connection = new SqliteConnection(databaseConfig.ConnectionString);

        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = @"
            INSERT INTO Laboratories VALUES($id, $number, $name, $block);
        ";
        command.Parameters.AddWithValue("$id",id);
        command.Parameters.AddWithValue("$number",number);
        command.Parameters.AddWithValue("$name",name);
        command.Parameters.AddWithValue("$block",block);

        command.ExecuteNonQuery();

        connection.Close();
    }
}
