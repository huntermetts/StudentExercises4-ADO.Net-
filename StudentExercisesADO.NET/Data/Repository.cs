using StudentExercisesADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudentExercisesADO.NET
{
    public class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Server=DESKTOP-6QUVPEQ\\SQLEXPRESS;database=StudentExercisesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                return new SqlConnection(_connectionString);
            }
        }
        


        public List<Exercise> GetAllExercises()
        {
         
            using (SqlConnection conn = Connection)
            {
                
                conn.Open();
                
                using (SqlCommand cmd = conn.CreateCommand())
                {
    
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise";
                   
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    List<Exercise> exercises = new List<Exercise>();
                    
                    while (reader.Read())
                    {
                       
                        int idColumnPosition = reader.GetOrdinal("Id");
                        
                        int idValue = reader.GetInt32(idColumnPosition);
                        int exerciseNameColumnPosition = reader.GetOrdinal("name");
                        int exerciseLanguageColumnPosition = reader.GetOrdinal("language");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);
                        string exerciseLanguageValue = reader.GetString(exerciseLanguageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = exerciseNameValue,
                            Language = exerciseLanguageValue
                        };

                        exercises.Add(exercise);
                    }
                    
                    reader.Close();
                    return exercises;
                }
            }
        }
     }
}
    
    

