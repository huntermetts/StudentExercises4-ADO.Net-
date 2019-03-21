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


        /*
         Get all exercises
        */
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


        /*
         Get all exercises where the language is Javascript 
        */
        public List<Exercise> GetAllJavascriptExercises()
        {

            using (SqlConnection conn = Connection)
            {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT Id, [Name], [Language] " +
                        "FROM Exercise " +
                        "WHERE CONVERT(VARCHAR, [Language])= 'Javascript'; ";

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

        /*
        Get all exercises where the language is Javascript 
       */
        public void addExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // More string interpolation
                    cmd.CommandText = $"INSERT INTO Exercise (Name, Language) Values ('{exercise.Name}', '{exercise.Language}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*
       Get all instructors with their cohort 
      */
        public List<Instructor> GetAllInstructorsWithCohort()
        {

            using (SqlConnection conn = Connection)
            {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT FirstName, LastName, cohort.[name] FROM Instructor " +
                        "LEFT JOIN Cohort " +
                        "ON Instructor.CohortId = Cohort.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while (reader.Read())
                    {

                        
                        int instructorFirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        int instructorLastNameColumnPosition = reader.GetOrdinal("LastName");
                        int cohortNameColumnPosition = reader.GetOrdinal("name");

                        
                        string FirstNameValue = reader.GetString(instructorFirstNameColumnPosition);
                        string LastNameValue = reader.GetString(instructorLastNameColumnPosition);
                        string cohortNameValue = reader.GetString(cohortNameColumnPosition);

                        Instructor instructor = new Instructor
                        {
                            
                            FirstName = FirstNameValue,
                            LastName = LastNameValue,
                            CohortName = cohortNameValue
                        };

                        instructors.Add(instructor);
                    }

                    reader.Close();
                    return instructors;
                }
            }
        }


    }
}
    
    

