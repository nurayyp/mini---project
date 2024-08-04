using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public class Messages
    {
        public static void SuccessAddMessage(string title, string value) => Console.WriteLine($"{title} - {value} successfully added");
        public static void InvalidInputMessage(string title) => Console.WriteLine($"{title} is invalid");
        public static void SuccessDeleteMessage(string title) => Console.WriteLine($"{title} successfully deleted");
        public static void SuccessUpdateMessage(string title) => Console.WriteLine($"{title} successfully updated");
        public static void PrintWantToChangeMessage(string title) => Console.WriteLine($"Do you want to change {title}? Y or N");
        public static void NotFoundMessage(string title, string value) => Console.WriteLine($"{title} {value} is not found");
        public static void PrintMessage(string title, string value) => Console.WriteLine($"{title} - {value}, ");
        public static void AlreadyExistsMessage(string title, string value) => Console.WriteLine($"{title} - {value} already exists");
        public static void InputMessage(string title) => Console.WriteLine($"Input {title}");
        public static void ErrorOccuredMessage() => Console.WriteLine("Error occured, try again");
    }
}
