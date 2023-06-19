using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDMPW_411_3P_EX.Models
{
    public class SemesterCalculation : ICloneable
    {
        public string name;
        public double firstParcialGradeOverOne;
        public double secondParcialGradeOverOne;
        public double firstParcialValueOverOne;
        public double secondParcialValueOverOne;
        public double thirdParcialValueOverOne;
        public double targetGradeOverOne = 0.0;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public SemesterCalculation(string name, double firstParcialGradeOverOne, double secondParcialGradeOverOne, double firstParcialValueOverOne, double secondParcialValueOverOne, double thirdParcialValueOverOne)
        {
            this.name = name;
            this.firstParcialGradeOverOne = firstParcialGradeOverOne;
            this.secondParcialGradeOverOne = secondParcialGradeOverOne;
            this.firstParcialValueOverOne = firstParcialValueOverOne;
            this.secondParcialValueOverOne = secondParcialValueOverOne;
            this.thirdParcialValueOverOne = thirdParcialValueOverOne;
        }
    }
}