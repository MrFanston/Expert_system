namespace Expert_system
{
    internal class KnowledgeBase
    {
        public List<Fact> Facts { get; set; }
        public List<Rule> Rules { get; set; }

        public KnowledgeBase()
        {
            Facts = new List<Fact>();
            Rules = new List<Rule>();
        }

        public void AddFact(Fact fact)
        {
            Facts.Add(fact);
        }

        public void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }

        // Возвращает значение факта по имени
        public bool? GetFactValue(string factName)
        {
            var fact = Facts.Find(f => f.Name == factName);
            return fact.Value;
        }

        // Устанавливает значение факта по имени
        public void SetFactValue(string factName, bool value)
        {
            var fact = Facts.Find(f => f.Name == factName);
            if (fact != null)
            {
                fact.Value = value;
            }
        }

        // Возвращает список входных фактов (факты, которые не являются выводами правил)
        public List<Fact> GetInputFacts()
        {
            // Все факты, которые являются выводами правил
            var conclusionFacts = Rules.Select(r => r.ConclusionFact).ToHashSet();

            // Возвращаем только те факты, которые не являются выводами
            return Facts.Where(f => !conclusionFacts.Contains(f.Name)).ToList();
        }

        // Возвращает список конечных фактов (факты, которые не используются в условиях других правил)
        public HashSet<string> GetFinalFacts()
        {
            // Все факты, которые используются в качестве условий других правил
            var conditionFacts = Rules.SelectMany(r => r.ConditionFacts).ToHashSet();

            // Конечные факты — это факты, которые не используются в качестве условий
            var finalFacts = Rules.Select(r => r.ConclusionFact)
                                  .Where(conclusion => !conditionFacts.Contains(conclusion))
                                  .ToHashSet();

            return finalFacts;
        }

    }
}
