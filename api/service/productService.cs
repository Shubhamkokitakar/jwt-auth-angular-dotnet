using api.Models;
using Npgsql;
using System.Collections.Generic;

namespace api.Services
{
    public class ProductService : IProductService
    {
        private readonly NpgsqlConnection _connection;

        public ProductService(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public List<PlayingWithNeonData> GetAllData()
        {
            var result = new List<PlayingWithNeonData>();
            _connection.Open();

            using var cmd = new NpgsqlCommand(
                "SELECT id, name, value FROM playing_with_neon",
                _connection
            );

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new PlayingWithNeonData
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Value = reader.GetFloat(2)
                });
            }

            _connection.Close();
            return result;
        }

        public float ProcessValue(PlayingWithNeonData data)
        {
            return data.Value * 10; // simple business logic
        }

        public void InsertData(PlayingWithNeonData data)
        {
            _connection.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO playing_with_neon (name, value) VALUES (@name, @value)",
                _connection
            );
            cmd.Parameters.AddWithValue("name", data.Name);
            cmd.Parameters.AddWithValue("value", data.Value);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
