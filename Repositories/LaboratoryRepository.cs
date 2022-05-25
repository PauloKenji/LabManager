using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class LaboratoryRepository
{
    private DatabaseConfig databaseConfig;

    public LaboratoryRepository(DatabaseConfig databaseConfig) => this.databaseConfig = databaseConfig;

    public List<Laboratory> GetAll(){
        var laboratories = new List<Laboratory>();

        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM Laboratories;";
        
        var reader = command.ExecuteReader();

        while (reader.Read())
        {   
            var laboratory = new Laboratory(
                reader.GetInt32(0), 
                reader.GetInt32(1), 
                reader.GetString(2),
                reader.GetChar(3)
            );

            laboratories.Add(laboratory);            
        }
        connection.Close();

        return laboratories;
    }

    public void save(Laboratory laboratory){

        var connection = new SqliteConnection(databaseConfig.ConnectionString);

        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = @"
            INSERT INTO Laboratories VALUES($id, $number, $name, $block);
        ";
        command.Parameters.AddWithValue("$id",laboratory.Id);
        command.Parameters.AddWithValue("$number",laboratory.Number);
        command.Parameters.AddWithValue("$name",laboratory.Name);
        command.Parameters.AddWithValue("$block",laboratory.Block);

        command.ExecuteNonQuery();

        connection.Close();
    }
}