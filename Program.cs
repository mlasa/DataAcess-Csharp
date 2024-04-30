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

        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "AWS Fundamentals part 2";
        category.Url = "amazon";
        category.Description = "Aprenda os fundamentos de uma das plataformas mais utilizadas pelas empresas hoje.";
        category.Summary = "AWS Cloud";
        category.Order = 8;

        //Category Id (teste): 55a76f63-2260-4565-bb10-bb1db982681e
        //Course Id: 5c34a0a9-e717-9a7d-1241-14ac00000000 - xamarin

        using (var connection = new SqlConnection(connectionString)){
            connection.Open();

            //RegisterCategory(connection, category);
            //DeleteCategory(connection, new Guid("55a76f63-2260-4565-bb10-bb1db982681e"));
            //UpdateCategory(connection, new Guid("55a76f63-2260-4565-bb10-bb1db982681e"), "Minha nova categoria");
            //GetCategories(connection);
            OneToOne(connection);

            connection.Close();
        }
    }
   
    static void DeleteCategory(SqlConnection connection, Guid id)
    {
        const string deleteSql = "DELETE FROM [Category] WHERE [Id] = @Id";
        var affected = connection.Execute(deleteSql, new{Id = id});
        Console.WriteLine($"{affected} registros apagados");
    }
    static void UpdateCategory(SqlConnection connection, Guid id, string title){
        var updateSql = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@Id";

        var rows = connection.Execute(updateSql, new{ Id = id, Title = title});
        Console.WriteLine($"{rows} registros atualizados");
    }
    static void RegisterCategory(SqlConnection connection, Category newCategory)
    {
        const string insertSql = "INSERT INTO [Category] VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        var affected = connection.Execute(insertSql, new
        {
            newCategory.Id,
            newCategory.Title,
            newCategory.Url,
            newCategory.Description,
            newCategory.Summary,
            newCategory.Order,
            newCategory.Featured
        });
        
        Console.WriteLine($"{affected.ToString()} linhas inseridas");
    }
    static void GetCategories(SqlConnection connection)
    {
        const string selectSql = "SELECT TOP 10 [Id], [Title] FROM [Category]";

        var categories = connection.Query<Category>(selectSql);
        
        Console.WriteLine($"{categories.Count()} categorias encontradas");
        foreach(var category in categories) Console.WriteLine(category.Title);
    }

    static void OneToOne(SqlConnection connection){
        const string sql = @"SELECT * FROM [CareerItem] INNER JOIN [Course]
                        ON [CareerItem].[CourseId] = [Course].[Id]
                        ";

        var items = connection.Query<CarreerItem, Course, CarreerItem>(sql,
        (carreerItem, course) => {
            carreerItem.Course = course;
            return carreerItem;
        },  splitOn: "Id");

        foreach (var item in items) Console.WriteLine( item.Title + item.Course.Title);
    }
}
