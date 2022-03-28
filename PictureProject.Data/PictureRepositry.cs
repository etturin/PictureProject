using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureProject.Data
{
    public class PictureRepositry
    {
        string _connectionString;

            public PictureRepositry(string connectionString)
            {
                _connectionString = connectionString;
            }

            public int AddImage(string filePath, string password, string FileName)
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Images (ImagePath, Password,FileName, Views) VALUES (@path, @password,@FileName,0)SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@path", filePath);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@FileName", FileName);
                conn.Open();
                int id = (int)(decimal)cmd.ExecuteScalar();
                return id;
            }
            public string GetImagePasswordById(int id)
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Password FROM IMAGES WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                string password = (string)cmd.ExecuteScalar();
                return password;
            }
            public Image GetimageById(int id)
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT imagePath,  FileName, views FROM  Images where id=@id";
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                reader.Read();
                return new Image
                {
                    imagePath = (string)reader["ImagePath"],
                    view = (int)reader["views"],
                    FileName=(string)reader["FileName"]
                };


            }

            public void IncrementView(int id)
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"Update images set Views=Views+1 Where Id=@id";

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
