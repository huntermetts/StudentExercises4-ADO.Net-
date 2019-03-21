using StudentExercisesADO.NET.Models;
using System;
using System.Collections.Generic;

namespace StudentExercisesADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             "Query the database for all the exercises"
             (using the "GetAllExercises()" function defined in "Repository" file)
            */
            Repository repository = new Repository();
            List<Exercise> exercises = repository.GetAllExercises();

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"The exercise name is {exercise.Name} and the language is {exercise.Language}");
            }
            Console.ReadKey();


            Console.WriteLine("");


            /*
             Find all exercises in tthe database where the language is C#
             (using the "GetAllJavasriptExercises()" function defined in "Repository" file)
            */
            List<Exercise> javascriptExercises = repository.GetAllJavascriptExercises();

            Console.WriteLine("The JavaScript exercises are:");

            foreach(Exercise javascriptExercise in javascriptExercises)
            {
                Console.WriteLine($"{javascriptExercise.Name}");
            }
            Console.ReadKey();


        }
    }
}
