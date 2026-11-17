using NUnit.Framework;
using DSA.Lab08;

namespace DSA.Lab08.Tests
{
    public sealed class PreparedQuestStoreTests
    {
        [Test]
        public void FindById_ReturnsCorrectQuest()
        {
            var p = new QuestParser();
            var s = new PreparedQuestStore(DemoData.Lines(20), p);
            Assert.That(s.FindById("Q7")!.Region, Is.EqualTo("West"));
        }

        [Test]
        public void GetByRegion_ReturnsOnlyMatchingRegion()
        {
            var p = new QuestParser();
            var s = new PreparedQuestStore(DemoData.Lines(20), p);
            foreach (var q in s.GetByRegion("North"))
                Assert.That(q.Region, Is.EqualTo("North"));
        }

        [Test]
        public void MissingId_ReturnsNull()
        {
            var p = new QuestParser();
            var s = new PreparedQuestStore(DemoData.Lines(20), p);
            Assert.That(s.FindById("Missing"), Is.Null);
        }

        [Test]
        public void Preparation_ParsesEachInputExactlyOnce()
        {
            var lines = DemoData.Lines(40);
            var p = new QuestParser();
            _ = new PreparedQuestStore(lines, p);
            Assert.That(p.ParseCount, Is.EqualTo(lines.Count));
        }

        [Test]
        public void RepeatedQueries_DoNotReparseInput()
        {
            var lines = DemoData.Lines(40);
            var p = new QuestParser();
            var s = new PreparedQuestStore(lines, p);
            int after = p.ParseCount;
            for (int i = 0; i < 20; i++)
            {
                s.FindById("Q12");
                s.GetByRegion("South");
            }
            Assert.That(p.ParseCount, Is.EqualTo(after));
        }
    }
}
