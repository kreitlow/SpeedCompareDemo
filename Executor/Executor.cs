using System;
using System.Collections.Generic;
using System.Diagnostics;
using Common;
using Generator;

namespace Executor
{
    class Executor
    {
        private InMemorySetGenerator _setGenerator;
        private Searcher.Searcher _searcher;
        private Stopwatch _timer = new Stopwatch();
        private List<BoysBroughtByArtist> _spreadOutSet = new List<BoysBroughtByArtist>();
        private List<BoysBroughtByArtist> _minSet = new List<BoysBroughtByArtist>();

        public Executor()
        {
            _setGenerator = new InMemorySetGenerator();
            _searcher = new Searcher.Searcher();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void RunGenerateComparison()
        {
            // Create a set with the spread out code
            _timer.Reset();
            Console.WriteLine("Starting spread out code generation.");
            _timer.Start();
            _spreadOutSet = _setGenerator.GetSpreadOutCodeSet(Constants.NumberOfRecordsToProduce);
            _timer.Stop();
            var spreadOutTime = _timer.Elapsed;

            //Create a set with the minned code
            _timer.Reset();
            Console.WriteLine("Starting min code generation.");
            _timer.Start();
            _minSet = _setGenerator.MinCdSt(Constants.NumberOfRecordsToProduce);
            _timer.Stop();
            var minCodeTime = _timer.Elapsed;

            // Display time taken
            Console.WriteLine();
            Console.WriteLine($"Spread Out Code Generation Time Elapsed: {spreadOutTime}");
            Console.WriteLine($"Minned Code Time Generation Elapsed: {minCodeTime}");

            // Display Difference
            Console.WriteLine();
            var currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{((spreadOutTime>minCodeTime)? "Min code was faster":"Spread code was faster")} by {((spreadOutTime>minCodeTime)? spreadOutTime-minCodeTime : minCodeTime-spreadOutTime)}");
            Console.ForegroundColor = currentConsoleColor;
            Console.WriteLine();
            Console.WriteLine();
        }

        public void RunGenerateOppositeOrderComparison()
        {
            //Create a set with the minned code
            _timer.Reset();
            Console.WriteLine("Starting min code generation.");
            _timer.Start();
            _minSet = _setGenerator.MinCdSt(Constants.NumberOfRecordsToProduce);
            _timer.Stop();
            var minCodeTime = _timer.Elapsed;

            // Create a set with the spread out code
            _timer.Reset();
            Console.WriteLine("Starting spread out code generation.");
            _timer.Start();
            _spreadOutSet = _setGenerator.GetSpreadOutCodeSet(Constants.NumberOfRecordsToProduce);
            _timer.Stop();
            var spreadOutTime = _timer.Elapsed;

            // Display time taken
            Console.WriteLine();
            Console.WriteLine($"Spread Out Code Generation Time Elapsed: {spreadOutTime}");
            Console.WriteLine($"Minned Code Time Generation Elapsed: {minCodeTime}");

            // Display Difference
            Console.WriteLine();
            var currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{((spreadOutTime > minCodeTime) ? "Min code was faster" : "Spread code was faster")} by {((spreadOutTime > minCodeTime) ? spreadOutTime - minCodeTime : minCodeTime - spreadOutTime)}");
            Console.ForegroundColor = currentConsoleColor;
            Console.WriteLine();
            Console.WriteLine();
        }

        public void RunSearchComparison()
        {
            _timer.Reset();
            Console.WriteLine("Starting minned code search of sets");
            _timer.Start();
            var spreadOutResult = _searcher.WhoseMilkshakeBroughtTheBoysToTheYardSpreadOut(_minSet);
            _timer.Stop();
            var spreadOutTime = _timer.Elapsed;

            _timer.Reset();
            Console.WriteLine("Starting spread out code search of sets");
            _timer.Start();
            var assignment = _searcher.WhoseMilkshakeBroughtTheBoysToTheYardMinned(_minSet);
            _timer.Stop();
            var minCodeTime = _timer.Elapsed;

            // Display time taken
            Console.WriteLine($"Spread Out Code Generation Time Elapsed: {spreadOutTime}");
            Console.WriteLine($"Minned Code Time Generation Elapsed: {minCodeTime}");

            // Display Difference
            Console.WriteLine();
            var currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{((spreadOutTime > minCodeTime) ? "Min code was faster" : "Spread code was faster")} by {((spreadOutTime > minCodeTime) ? spreadOutTime - minCodeTime : minCodeTime - spreadOutTime)}");
            Console.ForegroundColor = currentConsoleColor;
            Console.WriteLine();
            Console.WriteLine();
        }

        public void RunOppositeOrderSearchComparison()
        {
            _timer.Reset();
            Console.WriteLine("Starting spread out code search of sets");
            _timer.Start();
            var assignment = _searcher.WhoseMilkshakeBroughtTheBoysToTheYardMinned(_minSet);
            _timer.Stop();
            var minCodeTime = _timer.Elapsed;

            _timer.Reset();
            Console.WriteLine("Starting minned code search of sets");
            _timer.Start();
            var spreadOutResult = _searcher.WhoseMilkshakeBroughtTheBoysToTheYardSpreadOut(_minSet);
            _timer.Stop();
            var spreadOutTime = _timer.Elapsed;


            // Display time taken
            Console.WriteLine($"Minned Code Time Generation Elapsed: {minCodeTime}");
            Console.WriteLine($"Spread Out Code Generation Time Elapsed: {spreadOutTime}");

            // Display Difference
            Console.WriteLine();
            var currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{((spreadOutTime > minCodeTime) ? "Min code was faster" : "Spread code was faster")} by {((spreadOutTime > minCodeTime) ? spreadOutTime - minCodeTime : minCodeTime - spreadOutTime)}");
            Console.ForegroundColor = currentConsoleColor;
            Console.WriteLine();
            Console.WriteLine();

            // Show Results
            ShowMilkShakeResults(spreadOutResult);
        }



        private void ShowMilkShakeResults(List<BoysBroughtByArtist> orderedResult)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Artist\tNumber of Boys\tMilkShake Flavor\tYard Name\tPerformance Date");

            foreach (var result in orderedResult)
            {
                // Alternate Colors
                if (Console.ForegroundColor == ConsoleColor.Green)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{result.Artist}\t{result.NumberOfBoysBrought:#,#}\t{result.MilkShake}\t\t{result.Yard}\t{result.PerformanceDateTime:d}");
            }
        }
    }
}
