using System;

namespace ScientificCalculator
{
    public class CalculatorEngine
    {
        private InputHandler input = new InputHandler();
        private OutputHandler output = new OutputHandler();
        private BasicOprations basic = new BasicOprations();
        private ScientificOperations scientific = new ScientificOperations();
        private MemoryManager memory = new MemoryManager();
        private HistoryManager history = new HistoryManager();

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                output.ShowMenu();

                int choice = input.GetIntInput();

                if (choice == 0)
                {
                    Console.WriteLine("Exiting calculator.....");
                    break;
                }

                double result = 0;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            result = basic.Add(input.GetDouble(), input.GetDouble());
                            break;
                        case 2:
                            result = basic.Subtract(input.GetDouble(), input.GetDouble());
                            break;
                        case 3:
                            result = basic.Multiply(input.GetDouble(), input.GetDouble());
                            break;
                        case 4:
                            result = basic.Divide(input.GetDouble(), input.GetDouble());
                            break;
                        case 5:
                            result = scientific.Sqrt(input.GetDouble());
                            break;
                        case 6:
                            result = scientific.power(input.GetDouble(), input.GetDouble());
                            break;
                        case 7:
                            result = scientific.Sin(input.GetDouble());
                            break;
                        case 8:
                            result = scientific.Cos(input.GetDouble());
                            break;
                        case 9:
                            result = scientific.Tan(input.GetDouble());
                            break;
                        case 10:
                            result = scientific.Log(input.GetDouble());
                            break;
                        case 11:
                            memory.Store(input.GetDouble());
                            output.Print("Stored in memory.");
                            continuePromt();
                            continue;
                        case 12:
                            result = memory.Recall();
                            break;
                        case 13:
                            history.ShowHistory();
                            continuePromt();
                            continue;
                        default:
                            output.Print("Invalid choice.");
                            continuePromt();
                            continue;
                    }

                    output.Print("Result: " + result);
                    history.Add(result);

                    continuePromt();
                }
                catch (Exception ex)
                {
                    output.Print("Error: " + ex.Message);
                    continuePromt();
                }
            }
        }

        private void continuePromt()
        {
            while (true)
            {

                Console.WriteLine("\nDo you want to continue? (Y/N): ");
                string choice = Console.ReadLine();

                if (choice == null)
                    continue;

                choice = choice.ToLower();

                if (choice == "y")
                {
                    return;
                }
                else if (choice == "n")
                {
                    Console.WriteLine("Thank You for using the calculator!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input! Pleace enter Y or N.");
                }
            }
        }
    }
}