using System;
using System.Collections.Generic;

namespace DSA.Lab07
{
    public sealed class ThreatScanner
    {
        public ScanResult Scan(IReadOnlyList<Enemy> enemies, IReadOnlyList<int> activeEnemyIds, int repetitions)
        {
            if (enemies == null) throw new ArgumentNullException(nameof(enemies));
            if (activeEnemyIds == null) throw new ArgumentNullException(nameof(activeEnemyIds));
            if (repetitions < 0) throw new ArgumentOutOfRangeException(nameof(repetitions));

            long visited = 0;
            long membershipChecks = 0;
            long totalThreat = 0;

            HashSet<int> activeEnemyDatabase = new();
            
            foreach (int id in activeEnemyIds)
            {
                activeEnemyDatabase.Add(id);
            }

            for (int r = 0; r < repetitions; r++)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    visited++;
                    Enemy e = enemies[i];

                    if (activeEnemyDatabase.Contains(e.Id))
                    {
                        membershipChecks++;
                        totalThreat += e.Threat;
                    }
                }
            }

            return new ScanResult(totalThreat, visited, membershipChecks);
        }
    }
}
