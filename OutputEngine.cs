using Expert_system;
using System.Diagnostics;

internal class OutputEngine
{
    private KnowledgeBase _knowledgeBase;
    private HashSet<string> _finalFacts;
    private HashSet<Rule> _appliedRules; // Отслеживание примененных правил

    public OutputEngine(KnowledgeBase knowledgeBase)
    {
        _knowledgeBase = knowledgeBase;
        _finalFacts = knowledgeBase.GetFinalFacts();  // Получаем конечные факты
        _appliedRules = new HashSet<Rule>();          // Инициализация множества применённых правил
    }

    // Применяет правила динамически после каждого изменения факта
    public string ApplyRulesDynamically()
    {
        bool newFactAdded;

        // Продолжаем проверку до тех пор, пока новые правила продолжают срабатывать
        do
        {
            newFactAdded = false; // Флаг для отслеживания, было ли применено новое правило

            foreach (var rule in _knowledgeBase.Rules)
            {
                // Проверяем, что правило ещё не было применено
                if (_appliedRules.Contains(rule))
                {
                    continue;  // Пропускаем правило, если оно уже было применено
                }

                // Проверяем, что все факты условия правила истинны
                if (rule.ConditionFacts.All(fact => _knowledgeBase.GetFactValue(fact) ?? false))
                {
                    // Устанавливаем результат (выводимый факт) в истину
                    _knowledgeBase.SetFactValue(rule.ConclusionFact, true);

                    // Добавляем правило в список применённых
                    _appliedRules.Add(rule);

                    // Устанавливаем флаг, что был добавлен новый факт
                    newFactAdded = true;

                    // Проверяем, является ли выводимый факт конечным
                    if (_finalFacts.Contains(rule.ConclusionFact))
                    {
                        Debug.WriteLine($"Применено конечное правило: Если [{string.Join(", ", rule.ConditionFacts)}], то {rule.ConclusionFact}");
                        return rule.ConclusionFact;
                    }
                    else
                    {
                        Debug.WriteLine($"Применено промежуточное правило: Если [{string.Join(", ", rule.ConditionFacts)}], то {rule.ConclusionFact}");
                    }
                }
            }

        } while (newFactAdded); // Повторяем цикл, пока применяются новые правила

        return null; // Если правило не найдено, возвращаем null
    }
}
