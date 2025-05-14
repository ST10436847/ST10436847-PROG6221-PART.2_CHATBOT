using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using NAudio.Wave;

namespace St10436847_PROG6221_Part._2_Chatbot
{                           //github link: https://github.com/ST10436847/ST10436847-PROG6221-PART.2_CHATBOT
    class Program
    {
        static Dictionary<string, string> userMemory = new Dictionary<string, string>();
        static Dictionary<string, string[]> keywordResponses = new Dictionary<string, string[]>
        {     //keyword
            { "password", new[] {
                "Make sure to use strong, unique passwords for each account.",
                "Avoid using personal details in your passwords.",
                "Use a combination of letters, numbers, and symbols."
            }},
            { "phishing", new[] {
                "Be cautious of emails asking for personal info. Scammers often disguise themselves as trusted sources.",
                "Don't click links in suspicious emails. Verify the sender first.",
                "Look for spelling mistakes in phishing messages—they’re a red flag."
            }},
            { "scam", new[] {
                "Scams are common. Always verify sources and don't give out personal info.",
                "Be cautious with unfamiliar calls or emails. Stay alert!",
                "Report any suspicious activity to the proper authorities."
            }}
        };

        static Random random = new Random();

        static void Main()
        {
            Console.Title = "Cybersecurity Awareness Bot";

            //voice greeting 
            PlayGreeting();

            //display ASCII
            DisplayAsciiLogo();

            //Welcome message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWelcome to the Cybersecurity Awareness Bot!\n");
            Console.ResetColor();

            //ask for user name
            Console.Write("Enter your name: ");
            string name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name)) name = "User";
            userMemory["name"] = name;

            Console.WriteLine($"\nHello, {name}! How can I assist you today?\n");

            //chatbot loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter a valid question.");
                    continue;
                }

                if (userInput == "exit" || userInput == "quit")
                {
                    Console.WriteLine("Goodbye! Stay safe online.");
                    break;
                }

                try
                {
                    RespondToUser(userInput);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oops! Something went wrong: " + ex.Message);
                    Console.WriteLine("Let’s try that again. Could you rephrase your question?");
                }
            }
        }

        static void RespondToUser(string input)
        {
            //Optimised keyword response
            foreach (var pair in keywordResponses)
            {
                if (input.Contains(pair.Key))
                {
                    PrintWithTypingEffect(RandomResponse(pair.Value));
                    return;
                }
            }

            //Sentiment detection
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
            {
                PrintWithTypingEffect("It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe.");
            }
            else if (input.Contains("curious") || input.Contains("interested"))
            {
                PrintWithTypingEffect("I'm glad you're curious! Learning about cybersecurity is a smart move. What would you like to know more about?");
            }
            else if (input.Contains("frustrated") || input.Contains("confused"))
            {
                PrintWithTypingEffect("I'm here to help. Cybersecurity can be tricky, but I’ll do my best to guide you through it.");
            }
            else if (input.Contains("privacy"))
            {
                userMemory["interest"] = "privacy";
                PrintWithTypingEffect("Great! I'll remember that you're interested in privacy. It's an important aspect of cybersecurity.");
            }
            else if (input.Contains("more details") || input.Contains("explain more"))
            {
                if (userMemory.ContainsKey("interest") && userMemory["interest"] == "privacy")
                {
                    PrintWithTypingEffect("As someone interested in privacy, you might want to review the security settings on your accounts.");
                }
                else
                {
                    PrintWithTypingEffect("Could you tell me what you'd like to learn more about?");
                }
            }
            else if (input.Contains("how are you")) 
            {
                PrintWithTypingEffect("I'm just a bot, but I'm here to help!");
            }
            else if (input.Contains("what's your purpose"))
            {
                PrintWithTypingEffect("I provide cybersecurity tips and answer your security-related questions.");
            }
            else if (input.Contains("what can i ask") || input.Contains("help"))
            {
                PrintWithTypingEffect("You can ask about password safety, phishing, scams, or privacy tips.");
            }
            else
            {
                PrintWithTypingEffect("I'm not sure I understand. Can you try rephrasing your question?");
            }
        }

        static string RandomResponse(string[] responses)
        {
            int index = random.Next(responses.Length);
            return responses[index];
        }

        static void PrintWithTypingEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }

        static void PlayGreeting()
        {
            try
            {
                string filePath = "greeting.wav";
                if (System.IO.File.Exists(filePath))
                {
                    SoundPlayer player = new SoundPlayer(filePath);
                    player.PlaySync();
                }
                else
                {
                    Console.WriteLine("Voice greeting file not found. Skipping audio...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing greeting: " + ex.Message);
            }
        }

        static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
         ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
        ██╔════╝██║   ██║██╔══██╗██╔════╝██╔══██╗
        ██║     ██║   ██║██████╔╝█████╗  ██████╔╝
        ██║     ██║   ██║██╔══██╗██╔══╝  ██╔═══╝ 
        ╚██████╗╚██████╔╝██████╔╝███████╗██║     
         ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝
        ");
            Console.ResetColor();
        }
    }
}