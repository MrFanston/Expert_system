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
        KnowledgeBase kb; // ���� ������
        OutputEngine engine; // �������� ������
        int numberFact = 0; // ���������� ��� ������ �����
        List<Fact> shuffledInputFacts; //������� �����

        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            // ������ ���� ������
            kb = new KnowledgeBase();

            // ��������� XML-����
            xmlDoc.Load(xml);

            // ���������� ������ �� <fact> �����
            XmlNodeList factNodes = xmlDoc.SelectNodes("/knowledgeBase/facts/fact");
            foreach (XmlNode factNode in factNodes)
            {
                // ��������� ��� ����� �� �������� <name>
                string factName = factNode.SelectSingleNode("name").InnerText;

                // ��������� �������� finish �� �������� <finish>
                bool finish = factNode.SelectSingleNode("finish").InnerText.ToLower() == "true";

                // ��������� ���� � ���� ������
                kb.AddFact(new Fact(factName, null, finish));
            }

            // ���������� ������ �� <rule> �����
            XmlNodeList ruleNodes = xmlDoc.SelectNodes("/knowledgeBase/rules/rule");
            foreach (XmlNode ruleNode in ruleNodes)
            {
                List<string> conditions = new List<string>();
                string conclusion = ruleNode.Attributes["conclusion"].Value;

                // ��������� ������� �� <condition> ����� ������ <rule>
                XmlNodeList conditionNodes = ruleNode.SelectNodes("condition");
                foreach (XmlNode conditionNode in conditionNodes)
                {
                    string condition = conditionNode.InnerText;
                    conditions.Add(condition);
                }

                // ��������� ������� � ���� ������
                kb.AddRule(new Rule(conditions, conclusion));
            }

            // ������ �������� ������
            engine = new OutputEngine(kb);

            // �������� ������ ������� ������ (������, ������� �� �������� �����������)
            List<Fact> inputFacts = kb.GetInputFacts();

            // ������������ ������ ������� ������
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
            // ��������� ����� ��� labelTop
            labelTop.Text = $"��� �������� ���: \n {result}";
            richTextBoxFact.Visible = false;
            buttonYes.Visible = false;
            buttonNo.Visible = false;

            // ���� ��������� �� �����
            XmlNode characterNode = xmlDoc.SelectSingleNode($"/knowledgeBase/facts/fact[name='{result}']");

            if (characterNode != null)
            {
                // �������� ������� finish
                XmlNode finishNode = characterNode["finish"];
                XmlAttribute fileAttribute = finishNode.Attributes["file"];

                if (fileAttribute != null)
                {
                    string imagePath = fileAttribute.Value;

                    // ��������� ����������� �� ���������� ����
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.Visible = true; // ������ pictureBox �������
                }
                else
                {
                    labelTop.Text = "����������� �� ������� ��� ������� ���������.";
                }
            }
            else
            {
                labelTop.Text = "�������� �� ���������";
            }

            Debug.WriteLine($"��� �������� - {result}");
        }
    }
}
