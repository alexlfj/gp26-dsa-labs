using System;
using System.Collections.Generic;

namespace DSA.Lab08
{
    public sealed class PreparedQuestStore
    {
        private readonly IReadOnlyList<string> lines;
        private readonly QuestParser parser;

        public PreparedQuestStore(IReadOnlyList<string> lines, QuestParser parser)
        {
            this.lines = lines ?? throw new ArgumentNullException(nameof(lines));
            this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
            /* TODO: parse once and build reusable indexes */
        }

        public QuestRecord? FindById(string id)
        {
            /* TODO: avoid reparsing/scanning raw lines per query */
            for (int i = 0; i < lines.Count; i++)
            {
                QuestRecord q = parser.Parse(lines[i]);
                if (q.Id == id)
                    return q;
            }
            return null;
        }

        public IReadOnlyList<QuestRecord> GetByRegion(string region)
        {
            /* TODO: avoid reparsing/scanning raw lines per query */
            var result = new List<QuestRecord>();
            for (int i = 0; i < lines.Count; i++)
            {
                QuestRecord q = parser.Parse(lines[i]);
                if (q.Region == region)
                    result.Add(q);
            }
            return result;
        }
    }
}
