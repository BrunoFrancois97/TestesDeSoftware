using IndexCalculator.Repository.Implementation;
using IndexCalculator.Service.Implementation;
using IndexCalculator.Service.Validators.Implementation;
using System;

namespace IndexCalculator.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Initialize();
        }
        //TODO: Create Unit Tests
        private static void Initialize()
        {
            Console.WriteLine("Insert your subscription # to get your position");

            var service = new IndexCalculatorService(new IndexCalculatorRepository(), new IndexCalculatorValidator());

            var subscriptionNumber = Console.ReadLine();

            try
            {
                var index = service.GetIndex(subscriptionNumber);

                Console.WriteLine($"Your position is {index}");
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
