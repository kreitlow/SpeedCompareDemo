using System;
using Generator;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new Executor();
            var searcher = new Searcher.Searcher();

            // Create the sets
            executor.RunGenerateComparison();
            executor.RunGenerateOppositeOrderComparison();

            // Query the Sets
            executor.RunSearchComparison();
            executor.RunOppositeOrderSearchComparison();
        }
    }
}
