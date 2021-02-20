using System.Collections.Generic;
using System.Linq;

using Common;

namespace Searcher
{
    public class Searcher
    {
        public List<BoysBroughtByArtist> WhoseMilkshakeBroughtTheBoysToTheYardOneLiner(List<BoysBroughtByArtist> setToSearch) => setToSearch.GroupBy(x => x.Artist, (key, g) => g.OrderByDescending(byArtist => byArtist.NumberOfBoysBrought).FirstOrDefault()).ToList();

        public List<BoysBroughtByArtist> WhoseMilkshakeBroughtTheBoysToTheYardMinned(List<BoysBroughtByArtist> setToSearch) =>
            
            // Group by artist
            // Order by descending Number of boys brought
            // Take first from each group 
            // Convert To a List
            
            setToSearch
                .GroupBy(x => x.Artist,
                    (key, g) => g.OrderByDescending(byArtist => byArtist.NumberOfBoysBrought)
                .FirstOrDefault())
                .ToList();


        public List<BoysBroughtByArtist> WhoseMilkshakeBroughtTheBoysToTheYardSpreadOut(List<BoysBroughtByArtist> setToSearch)
        {
            // Create list to return
            var setToReturn = new List<BoysBroughtByArtist>();

            // Separate into groups by artist
            var seperatedByArtist = setToSearch
                .GroupBy(x => x.Artist);
                    

            foreach (var group in seperatedByArtist)
            {
                // Order the group
                var individualArtistOrderedByNumberOfBoys = group.OrderByDescending(x => x.NumberOfBoysBrought);

                // Take the best performance
                var topPerformanceByNumberOfBoys = individualArtistOrderedByNumberOfBoys.FirstOrDefault();

                // Add to the set to return
                setToReturn.Add(topPerformanceByNumberOfBoys);
            }

            //Order the set to return
            setToReturn = setToReturn.OrderByDescending(x => x.NumberOfBoysBrought).ToList();

            // Return the ordered set
            return setToReturn;
        }
    }
}
