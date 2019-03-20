using StudentExercisesADO.NET.Models;
using System;
using System.Collections.Generic;

namespace StudentExercisesADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Repository repository = new Repository();
            List<Exercise> exercises = repository.GetAllExercises();
            

            foreach(Exercise exercise in exercises)
            {
                Console.WriteLine($"The exercise name is {exercise.Name} and the language is {exercise.Language}");
            }


            Console.ReadKey();
        }
    }
}
