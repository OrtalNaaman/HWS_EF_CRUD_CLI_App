using HWS_EF_CRUD_CLI_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWS_EF_CRUD_CLI_App
{
    public class Creator
    {
        public static void CreateNewStudent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter new student name:");
            string name = Console.ReadLine();
            Student newStudent = new Student { Name = name };

            using (var context = new CollegeContext())
            {
                context.Students?.Add(newStudent);
                context.SaveChanges();
            }
        }
        public static void DeleteStudentFromDb()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter student id to remove:");
            int id = int.Parse(Console.ReadLine());
            using (var context = new CollegeContext())
            {
                var studentToRemove = context.Students?.SingleOrDefault(student => student.StudentId == id);
                if (studentToRemove != null)
                {
                    Console.WriteLine("Are you shure you want to delete the student from college database? Y/N?");
                    string choice = Console.ReadLine();
                    while (choice?.ToUpper() != "N" && choice.ToUpper() != "Y")
                    {
                        Console.WriteLine("Please enter Y to delete the student from database and N otherwise:");
                        choice = Console.ReadLine();
                    }
                    if (choice.ToUpper() == "Y")
                    {
                        context.Students?.Remove(studentToRemove);
                        Console.WriteLine($"Student with id number {id} remove successfully!");
                        context.SaveChanges();
                    }
                    else return;
                }
                else
                {
                    Console.WriteLine($"id number {id} wasn't found.");
                    DeleteStudentFromDb();
                }
            }
        }
        public static void UpdateStudentDetails()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter student id for update:");
            int id = int.Parse(Console.ReadLine());
            using (var context = new CollegeContext())
            {
                var studentToUpdate = context.Students?.SingleOrDefault(student => student.StudentId == id);
                if (studentToUpdate != null)
                {
                    Console.WriteLine("Enter the new name for the student");
                    string name = Console.ReadLine();
                    studentToUpdate.Name = name;
                    Console.WriteLine($"Student name with id number {id} update successfully to be {name}!");
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"id number {id} wasn't found.");
                    UpdateStudentDetails();
                }
            }
        }
        public static void GetStudentDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter student id for getting details:");
            int id = int.Parse(Console.ReadLine());
            using (var context = new CollegeContext())
            {
                var studentToPresent = context.Students?.SingleOrDefault(student => student.StudentId == id);
                if (studentToPresent != null)
                {
                    Console.WriteLine($"Student Details:\n{studentToPresent}");
                }
                else
                {
                    Console.WriteLine($"id number {id} wasn't found.");
                    GetStudentDetails();
                }
            }
        }
        public static void GetStudentsList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            using (var context = new CollegeContext())
            {
                var studentFromDb = context.Students?.ToList();
                if (studentFromDb?.Count != 0)
                {
                    Console.WriteLine($"Students Details:");
                    studentFromDb.ForEach(student => Console.WriteLine(student));
                }
                else
                {
                    Console.WriteLine($"Database is empty");
                }
            }
        }
    }
}
