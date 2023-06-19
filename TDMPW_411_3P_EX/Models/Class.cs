namespace TDMPW_411_3P_EX.Models
{
    public class Class : ICloneable
    {
        public string name;
        public List<GradingItem> gradingItems = new List<GradingItem>();

        public Class(string _name, List<GradingItem> _gradientItems)
        {
            this.name = _name;
            this.gradingItems = _gradientItems;
        }
        public Class(string _name)
        {
            this.name = _name;
            this.gradingItems = new List<GradingItem>();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public struct GradingItem
    {
        public string name;
        public double valueOverOne;
        public double gradeOverOne = 0;
        public double gradeOverBase = 0;
        public double baseOfGrade = 1;

        public GradingItem(string _name, double _valueOverOne)
        {
            this.name= _name;
            this.valueOverOne= _valueOverOne;
        }

        public GradingItem(string _name, double _gradeOverBase, double _baseOfGrade, double _valueOverOne)
        {
            this.name=_name;
            this.gradeOverBase= _gradeOverBase;
            this.baseOfGrade= _baseOfGrade;
            this.gradeOverOne = _gradeOverBase / _baseOfGrade;
            this.valueOverOne = _valueOverOne;
        }

        public void changeGrade(double _gradeOverBase, double _baseOfGrade)
        {
            this.gradeOverBase = _gradeOverBase;
            this.baseOfGrade = _baseOfGrade;
            this.gradeOverOne = gradeOverBase / baseOfGrade;
        }
    }
}
