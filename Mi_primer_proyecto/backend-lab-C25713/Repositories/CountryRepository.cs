using backend_lab_C25713.Models;
using Dapper;
using System.Data.SqlClient;

namespace backend_lab_C25713.Repositories;

public class CountryRepository
{
    private readonly string _connectionString;

    public CountryRepository()
    {
        var builder = WebApplication.CreateBuilder();
        _connectionString =
            builder.Configuration.GetConnectionString("CountryContext")!;
    }

    public List<CountryModel> GetCountries()
    {
        using var connection = new SqlConnection(_connectionString);
        string query = "SELECT * FROM dbo.Country";
        return connection.Query<CountryModel>(query).ToList();
    }

    public bool CreateCountry(CountryModel country)
    {
    using var connection = new SqlConnection(_connectionString);
    var query = @"INSERT INTO [dbo].[Country] ([Name],[Language],[Continet])
                VALUES(@Name, @Language, @Continet)";
    var affectedRows = connection.Execute(query, new
    {
    Name = country.Name,
    Language = country.Language,
    Continet = country.Continet
    });
    return affectedRows >= 1;
    }
}