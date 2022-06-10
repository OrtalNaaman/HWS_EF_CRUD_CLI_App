using System;

namespace HWS_EF_CRUD_CLI_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to College App!");
            StartApp();
        }

        public static void StartApp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMenu:\n1. Create Student.\n2. Delete Student.\n3. Update Student." +
                              "\n4. Get Student Details.\n5. Get the List of Students.\n6. Quit the app." +
                              "\n\nPlease select your choice: ");
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());
            while (choice < 1 || choice > 6)
            {
                Console.WriteLine("Please select number between 1 to 6:");
                choice = int.Parse(Console.ReadLine());
            }
            switch (choice)
            {
                case 1: Creator.CreateNewStudent(); break;  
                case 2: Creator.DeleteStudentFromDb(); break;
                case 3: Creator.UpdateStudentDetails(); break;
                case 4: Creator.GetStudentDetails(); break;
                case 5: Creator.GetStudentsList(); break;
                case 6: Console.WriteLine("\nThank you for using College App, Hope to see you again!"); return;
            }
            StartApp();
        }
    }
}
