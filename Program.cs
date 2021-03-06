using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

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

        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
    }

    if(modelAction == "Delete"){
        var id = Convert.ToInt32(args[2]);

        computerRepository.Delete(id);
    }

    if(modelAction == "Update"){
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

        var computer = new Computer(id, ram, processor);
        computerRepository.Update(computer);
        Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
    }

    if(modelAction == "Show"){
        var id = Convert.ToInt32(args[2]);
        
        if(computerRepository.existsById(id)){
            var computer = computerRepository.GetById(id);
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }else{
            Console.WriteLine($" O computador ${id} não existe");
        }

        
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
        var block = char.Parse(args[5]);

        var laboratory = new Laboratory(id,number,name,block);
        laboratoryRepository.save(laboratory);
    }
}
