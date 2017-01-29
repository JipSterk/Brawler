using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking.Match;

namespace Brawler.Networking.Extentions
{
    public static class NetworkExtentions
    {
        public static List<MatchInfoSnapshot> InRange(this List<MatchInfoSnapshot> list, int eloScore, int margin)
        {
            var minMargin = eloScore - margin;
            var maxMargin = eloScore + margin;
            var openMatches = list.Where(t => t.currentSize < t.maxSize).ToList();
            return openMatches.Where(t => t.averageEloScore > minMargin && t.averageEloScore < maxMargin).ToList();
        }
    }
}