using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDMPW_411_3P_EX.Models;

namespace TDMPW_411_3P_EX
{
    public sealed class SemesterCalculations
    {
        public EventHandler semesterCalculationsUpdated;

        private List<SemesterCalculation> semesterClalculations = new List<SemesterCalculation>(3);
        private SemesterCalculations()
        {
            SemesterCalculation defaultSemesterCalculation = new SemesterCalculation("Calculo Default",0.5,0.5,0.2,0.2,0.6);
            semesterClalculations.Add(defaultSemesterCalculation);
        }

        private static SemesterCalculations instance = new SemesterCalculations();
        public static SemesterCalculations semesterClalculationsInstance { get { return instance; } }

        public void addSemesterCalculation(SemesterCalculation semesterCalculationToAdd)
        {
            this.semesterClalculations.ForEach((semesterClaculationToCheck) =>
            {
                if (semesterClaculationToCheck.name == semesterCalculationToAdd.name)
                {
                    throw new Exception("DuplicatedSemesterCalculation");
                }
            });
            semesterClalculations.Add(semesterCalculationToAdd);
            semesterCalculationsUpdated?.Invoke(this, EventArgs.Empty);
        }

        public List<SemesterCalculation> getClonedSemesterCalculations()
        {
            List<SemesterCalculation> semesterCalculationsToReturn = new List<SemesterCalculation>(this.semesterClalculations.Count);
            this.semesterClalculations.ForEach((semesterCalculationsToAdd) =>
            {
                semesterCalculationsToReturn.Add((SemesterCalculation)semesterCalculationsToAdd.Clone());
            });
            return semesterCalculationsToReturn;
        }

        public void removeSemesterCalculation(SemesterCalculation semesterCalculationToRemove)
        {
            foreach (SemesterCalculation semesterCalculationToCheck in this.semesterClalculations)
            {
                if (semesterCalculationToCheck.name == semesterCalculationToRemove.name)
                {
                    this.semesterClalculations.Remove(semesterCalculationToCheck);
                    semesterCalculationsUpdated?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }

        public void editClassByNameOfClass(SemesterCalculation calculationToEdit)
        {
            int index = 0;
            foreach (SemesterCalculation calculationToCheck in this.semesterClalculations)
            {
                if (calculationToCheck.name == calculationToEdit.name)
                {
                    this.semesterClalculations[index] = (SemesterCalculation)calculationToEdit;
                    semesterCalculationsUpdated?.Invoke(this, EventArgs.Empty);
                    return;
                }
                index++;
            }
            throw new Exception("ClassNotFound");
        }
    }
}
