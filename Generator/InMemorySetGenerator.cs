using System;
using System.Collections.Generic;
using Common;

namespace Generator
{
    public class InMemorySetGenerator
    {
        private List<BoysBroughtByArtist> _boysBroughtByArtists = new List<BoysBroughtByArtist>();
        private Random _rnJesus = new Random();

        public List<BoysBroughtByArtist> MinCdSt(long setCount)
        {
            // 3 Lines

            _boysBroughtByArtists.Clear();
            for (int x = 1; x <= setCount; x++) _boysBroughtByArtists.Add(new BoysBroughtByArtist() { Artist = (SingleNameVocalArtists)GetRandomNumberBetween0And19(), Yard = (Yards)GetRandomNumberBetween0And19(), MilkShake = (MilkShakes)GetRandomNumberBetween0And19(), NumberOfBoysBrought = GetNumberOfBoysBrought(), PerformanceDateTime = GetRandomDateTime() });
            return _boysBroughtByArtists;
        }

        public List<BoysBroughtByArtist> ReasonableMinimizedCode(long numberOfRecordsToCreate)
        {
            // Same code as MinCdSt() but formatted for readability

            _boysBroughtByArtists.Clear();

            for (int x = 1; x <= numberOfRecordsToCreate; x++)
            {
                _boysBroughtByArtists.Add(new BoysBroughtByArtist()
                {
                    Artist = (SingleNameVocalArtists)GetRandomNumberBetween0And19(), 
                    Yard = (Yards)GetRandomNumberBetween0And19(), 
                    MilkShake = (MilkShakes)GetRandomNumberBetween0And19(), 
                    NumberOfBoysBrought = GetNumberOfBoysBrought(), 
                    PerformanceDateTime = GetRandomDateTime()
                });
            }

            return _boysBroughtByArtists;
        }

        public List<BoysBroughtByArtist> GetSpreadOutCodeSet(long numberOfRecordsToReturnInSet)
        {

            // Create list to populate
            var setToReturn = new List<BoysBroughtByArtist>();

            // Loop to create the number of records
            for (int x = 1; x <= numberOfRecordsToReturnInSet; x++)
            {
                // Create new record
                var newRecord = new BoysBroughtByArtist();

                // Populate the record
                newRecord.Artist = (SingleNameVocalArtists)GetRandomNumberBetween0And19();
                newRecord.MilkShake = (MilkShakes)GetRandomNumberBetween0And19();
                newRecord.Yard = (Yards)GetRandomNumberBetween0And19();
                newRecord.NumberOfBoysBrought = GetNumberOfBoysBrought();
                newRecord.PerformanceDateTime = GetRandomDateTime();

                // Add the record to the set
                setToReturn.Add(newRecord);
            }

            // Return the populated set
            return setToReturn;
        }

        private int GetRandomNumberBetween0And19()
        {
            return _rnJesus.Next(20);
        }

        private DateTime GetRandomDateTime()
        {
            DateTime startDateTime = new DateTime(1980, 1, 1);
            int range = (DateTime.Today - startDateTime).Days;
            return startDateTime.AddDays(_rnJesus.Next(range));
        }

        private int GetNumberOfBoysBrought()
        {
            return _rnJesus.Next(int.MaxValue);
        }
    }
}
