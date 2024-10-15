using System;
using System.Diagnostics;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Xml;

namespace Expert_system
{
    public partial class Interface : Form
    {
        string xml = "XMLFile.xml";
        XmlDocument xmlDoc = new XmlDocument(); 
        KnowledgeBase kb; // База знаний
        OutputEngine engine; // Механизм вывода
        int numberFact = 0; // Переменная для выбора факта
        List<Fact> shuffledInputFacts; //Входные факты

        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            // Создаём базу знаний
            kb = new KnowledgeBase();

            // Загружаем XML-файл
            xmlDoc.Load(xml);

            // Извлечение фактов из <fact> тегов
            XmlNodeList factNodes = xmlDoc.SelectNodes("/knowledgeBase/facts/fact");
            foreach (XmlNode factNode in factNodes)
            {
                // Извлекаем имя факта из элемента <name>
                string factName = factNode.SelectSingleNode("name").InnerText;

                // Извлекаем значение finish из элемента <finish>
                bool finish = factNode.SelectSingleNode("finish").InnerText.ToLower() == "true";

                // Добавляем факт в базу знаний
                kb.AddFact(new Fact(factName, null, finish));
            }

            // Извлечение правил из <rule> тегов
            XmlNodeList ruleNodes = xmlDoc.SelectNodes("/knowledgeBase/rules/rule");
            foreach (XmlNode ruleNode in ruleNodes)
            {
                List<string> conditions = new List<string>();
                string conclusion = ruleNode.Attributes["conclusion"].Value;

                // Извлекаем условия из <condition> тегов внутри <rule>
                XmlNodeList conditionNodes = ruleNode.SelectNodes("condition");
                foreach (XmlNode conditionNode in conditionNodes)
                {
                    string condition = conditionNode.InnerText;
                    conditions.Add(condition);
                }

                // Добавляем правило в базу знаний
                kb.AddRule(new Rule(conditions, conclusion));
            }

            // Создаём механизм вывода
            engine = new OutputEngine(kb);

            // Получаем список входных фактов (фактов, которые не являются результатом)
            List<Fact> inputFacts = kb.GetInputFacts();

            // Перемешиваем список входных фактов
            Random random = new Random();
            shuffledInputFacts = inputFacts.OrderBy(x => random.Next()).ToList();

            richTextBoxFact.Text = shuffledInputFacts[numberFact].Name;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            kb.SetFactValue(shuffledInputFacts[numberFact++].Name, true);
            ApplyRules();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            kb.SetFactValue(shuffledInputFacts[numberFact++].Name, false);
            ApplyRules();
        }

        private void ApplyRules()
        {
            string result = engine.ApplyRulesDynamically();

            if (result != null)
            {
                finalWindow(result);
            }
            else if (numberFact < shuffledInputFacts.Count)
            {
                richTextBoxFact.Text = shuffledInputFacts[numberFact].Name;
            }
            else
            {
                finalWindow("");
            }
        }

        private void finalWindow(string result)
        {
            // Установим текст для labelTop
            labelTop.Text = $"Ваш персонаж это: \n {result}";
            richTextBoxFact.Visible = false;
            buttonYes.Visible = false;
            buttonNo.Visible = false;

            // Ищем персонажа по имени
            XmlNode characterNode = xmlDoc.SelectSingleNode($"/knowledgeBase/facts/fact[name='{result}']");

            if (characterNode != null)
            {
                // Получаем атрибут finish
                XmlNode finishNode = characterNode["finish"];
                XmlAttribute fileAttribute = finishNode.Attributes["file"];

                if (fileAttribute != null)
                {
                    string imagePath = fileAttribute.Value;

                    // Загружаем изображение из указанного пути
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.Visible = true; // Делаем pictureBox видимым
                }
                else
                {
                    labelTop.Text = "Изображение не найдено для данного персонажа.";
                }
            }
            else
            {
                labelTop.Text = "Персонаж не определен";
            }

            Debug.WriteLine($"Ваш персонаж - {result}");
        }
    }
}
