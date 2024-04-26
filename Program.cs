using System;
using System.Linq;
using System.Text.Json;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess;

class Program
{
    static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=root@mlasa00";
        const string sqlQuery = "SELECT [Id], [Title] FROM [Category]";

        using (var connection = new SqlConnection(connectionString)){
            var categories = connection.Query<Category>(sqlQuery);

            Console.WriteLine($"\n\n\n {categories.Count()} categorias de cursos no banco de dados");

            foreach (var category in categories){
                //WriteJson(category);
                Console.WriteLine(category.Title);
            }
        }
    }

    static void WriteJson(object obj){
        Console.WriteLine(JsonSerializer.Serialize(obj));
    }
}
