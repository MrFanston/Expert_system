namespace Expert_system
{
    internal class Rule
    {
        public List<string> ConditionFacts { get; set; }  // Список условий
        public string ConclusionFact { get; set; }        // Вывод (факт)

        public Rule(List<string> conditionFacts, string conclusionFact)
        {
            ConditionFacts = conditionFacts;
            ConclusionFact = conclusionFact;
        }
    }
}
