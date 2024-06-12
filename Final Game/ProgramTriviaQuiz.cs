using System;
using System.Collections.Generic;
using System.IO;


struct QuizQuestions
{
    public string Question;
    public string[] Choices;
    public char RightAnswer;
}
//Stack Overflow (2018). How do you populate a list with a structure at form load in C#//
//Retrieved from//
//https://stackoverflow.com/questions/53252690/how-do-you-populate-a-list-with-a-structure-at-form-load-in-c-sharp//

namespace Final_Game
{
    internal class Program
    {
        static List<QuizQuestions> ScienceQuiz = new List<QuizQuestions>();
        static List<QuizQuestions> HistoryQuiz = new List<QuizQuestions>();
        static List<QuizQuestions> MathQuiz = new List<QuizQuestions>();
        static int Score = 0;
        
        static string NameOfThePlayer;

        static void Main()
        {
            LoadQuizQuestionsFromFile("SciQstn.txt", ScienceQuiz);
            LoadQuizQuestionsFromFile("HistQstn.txt", HistoryQuiz);
            LoadQuizQuestionsFromFile("MathQstn.txt", MathQuiz);
            //Byjus(2020).Maths Quiz Questions with Answers(MCQs)
            //Retrieved from
            //https://byjus.com/maths/maths-quiz-questions/


            GetPlayerName();
            Console.WriteLine($"Greetings {NameOfThePlayer} \nA warm welcome to the Trivia Quiz Game!");
            Console.ReadLine();
            Console.WriteLine("There are three Categories in this game \n1. Science\n2. History\n3. Math ");
            Console.ReadLine();

            int ChosenCategory = CategorySelectionInput("Choose a Category (1, 2 or 3): ", 1, 3);
            List<QuizQuestions> ChosenQuestions = SelectedCategory(ChosenCategory, ScienceQuiz, HistoryQuiz, MathQuiz);
            Console.Clear();

            for (int i = 0; i < ChosenQuestions.Count; i++)
            {
                AskQuizQuestion(ChosenQuestions);
            }

            Console.WriteLine($"{NameOfThePlayer}, Your final score is: " +
                $"{Score} out of {ChosenQuestions.Count}");
            Console.WriteLine($"Total {Score * 100 / ChosenQuestions.Count}%");

            int FinalScore = Score * 100 / ChosenQuestions.Count;
            if (FinalScore == 0) 
            {
                Console.WriteLine("Grade = Fail");
            }
            else if (FinalScore > 0 && FinalScore <= 20)
            {
                Console.WriteLine("Grade = Poor");
            }
            else if (FinalScore > 20 && FinalScore <= 50)
            {
                Console.WriteLine("Grade = Average");
            }
            else if (FinalScore > 50 && FinalScore <= 80)
            {
                 Console.WriteLine("Grade = Good");
            }
            else if (FinalScore > 80 &&  FinalScore <= 90)
            {
                Console.WriteLine("Grade = Excellent");
            }
            else
            {
                Console.WriteLine("Grade = Outstanding");
            }

            ScoreFile("Quiz_Game_Score.txt", FinalScore);
            Console.ReadLine();

            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();
        }
        static void GetPlayerName()
        {
            Console.Write("Enter your name: ");
            NameOfThePlayer = Console.ReadLine();
        }
        static void LoadQuizQuestionsFromFile(string filepathway, List<QuizQuestions> SLQuestion)
        {
            try
            {
                int numberoflines = 6;

                string[] lines = File.ReadAllLines(filepathway);
                //Stack Overflow (2018). File.ReadAllLines or Stream Reader
                //Retrieved from
                //https://stackoverflow.com/questions/23989677/file-readalllines-or-stream-reader
                //Stack Overflow(2021).C# - How to convert string to char?
                //Retrieved from
                //https://stackoverflow.com/questions/33946594/c-sharp-how-to-convert-string-to-char

                for (int i = 0; i < lines.Length; i += numberoflines)
                {
                    QuizQuestions question = new QuizQuestions
                    {
                        Question = lines[i],
                        Choices = new string[] { lines[i + 1], lines[i + 2], lines[i + 3], lines[i + 4] },
                        RightAnswer = lines[i + 5][0]
                    };
                    SLQuestion.Add(question);
                    //Microsoft (n.d.). List<T>.Add(T) Method
                    //Retrieved from
                    //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add?view=net-8.0
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading questions from {filepathway}: {ex.Message}");
            }  
        }
        static int CategorySelectionInput(string comment, int LowerLimit, int UpperLimit)
        {
            int CategoryInput = 0;
            bool CorrectInput = false;
            do
            {
                Console.Write(comment);

                if (int.TryParse(Console.ReadLine(), out CategoryInput) && CategoryInput >= LowerLimit
                    && CategoryInput <= UpperLimit)
                //Microsoft (n.d.). out (C# Reference) (n.d.)
                //Retrieved from
                //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
                {
                    CorrectInput = true;
                }
                else
                {
                    Console.WriteLine("Incorrect input. Choose again.");
                }
            }
            while (!CorrectInput);
            return CategoryInput;
        }
        static List<QuizQuestions> SelectedCategory(int Category, List<QuizQuestions> Science,
            List<QuizQuestions> History, List<QuizQuestions> Math)
        {
            if (Category ==1)
            {
                return Science;
            }
            if (Category ==2)
            {
                return History;
            }
            else
            {
                return Math;
            }
        }
        static void AskQuizQuestion(List<QuizQuestions> AskedQuestion)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, AskedQuestion.Count);
            QuizQuestions question = AskedQuestion[randomIndex];

            Console.WriteLine($"{question.Question} \nYour options are: ");
            AskedQuestion.RemoveAt(randomIndex);
            //freeCodeCamp (2022). How to Remove an Item from a List in C#
            //Retrieved from
            //https://www.freecodecamp.org/news/how-to-remove-an-item-from-a-list-in-c/#:~:text=at%20that%20index.-,Below%20is%20a%20code%20snippet%20showing%20how%20to%20use%20the,an%20item%20from%20a%20list.&text=)%3B%20%7D%20%7D%20%7D%20%7D-,In%20the%20code%20above%2C%20FirstName.,at%200%2C%20not%201

            for (int i = 0; i < question.Choices.Length; i++)
            {
                Console.WriteLine(question.Choices[i]);
            }
            do
            {
                char GamerAnswer = AnswerSelectionFromChoices("Write the Correct Answer (A, B, C, or D): ", 'A',
                    (char)('A' + question.Choices.Length - 1), 3);

                if (GamerAnswer == question.RightAnswer)
                {
                    Score++;
                    Console.WriteLine("Correct Answer");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Answer");
                    Console.WriteLine($"The correct answer is {question.RightAnswer}.");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (false);
            
        }
        static char AnswerSelectionFromChoices(string comment, char LowerLimit, char UpperLimit, int maxAttempts)
        {
            char GamerInput = '\0';
            bool CorrectInput = false;
            int attempts = 0;

            do
            {
                Console.Write(comment);
                string Input = Console.ReadLine();

                if (Input.Length == 1 && Input[0] >= LowerLimit && Input[0] <= UpperLimit)
                {
                    GamerInput = Input[0];
                    CorrectInput = true;
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                    attempts++;
                    if (attempts < maxAttempts)
                    {
                        Console.WriteLine($"Only {maxAttempts - attempts} attempt left");
                    }
                    if (attempts == maxAttempts)
                    {
                        Console.WriteLine("All of your attempts are exhausted");
                        break;
                    }
                }
            }
            while (!CorrectInput);
            return GamerInput;
        }
        static void ScoreFile (string filepathway, int FinalScore)
        {
            try
            {
                using (StreamWriter SavedScore = new StreamWriter (filepathway, true))
                {
                    SavedScore.WriteLine($"{NameOfThePlayer} Your Score is: {FinalScore}%, Date: {DateTime.Now}");
                }
                Console.WriteLine($"Your score has been recorded to {filepathway}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in saving Score: {ex.Message}");
            }
        }
    }
}
