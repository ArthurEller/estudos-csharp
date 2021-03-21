using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name; //this.name = Referencia do book, name = associate
        }
        public void AddGrade(double grade)
        {   
            grades.Add(grade);
        }

        public void ShowStatistics() 
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach (var note in grades)
            {
               highGrade = Math.Max(note, highGrade);
               lowGrade = Math.Min(note, lowGrade);

               result += note;
            }

            var media = result / grades.Count;
            Console.WriteLine($"Nome do livro: {name}");
            Console.WriteLine($"Rating total: {result}, media: {media:N1}");
            Console.WriteLine($"Nota mais alta: {highGrade}, mais baixa: {lowGrade}");

            if (media < 60 )
            {
                Console.WriteLine("Livro com selo mediano!");
            } else if (media > 80) {
                Console.WriteLine("Livro altamente recomendado pelos criticos!");
            }
        }
        private List<double> grades;
        private string name;
    }
}