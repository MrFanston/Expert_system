namespace Expert_system
{
    internal class Fact
    {
        public string Name { get; set; }
        public bool? Value { get; set; }
        public bool Finish { get; set; }

        public Fact(string name, bool? value = null, bool finish = false)
        {
            Name = name;
            Value = value;
            Finish = finish;
        }
    }
}