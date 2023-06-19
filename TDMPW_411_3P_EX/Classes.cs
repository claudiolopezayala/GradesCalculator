using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDMPW_411_3P_EX.Models;

namespace TDMPW_411_3P_EX
{
    public sealed class Classes
    {
        public EventHandler classesUpdated;


        List<GradingItem> defaultGradingItems = new List<GradingItem>()
        {
            new GradingItem("primer rubro default", 0.2),
            new GradingItem("segundo rubro default", 0.2),
            new GradingItem("tercer rubro default", 0.2),
            new GradingItem("cuarto rubro default", 0.2)
        };
        private List<Class> classes = new List<Class>();

        private Classes ()
        {
            classes.Add(new Class("Clase Default", defaultGradingItems));
        }

        private static Classes instance = new Classes();

        public static Classes classesInstance { get { return instance; } }

        public void addClass(Class classToAdd)
        {
            this.classes.ForEach((classToCheck) =>
            {
                if (classToCheck.name == classToAdd.name)
                {
                    throw new Exception("DuplicatedClass");
                }
            });
            classes.Add(classToAdd);
            classesUpdated?.Invoke(this, EventArgs.Empty);
        }

        public List<Class> getClonedClasses()
        {
            List<Class> classesToReturn = new List<Class>(this.classes.Count);
            this.classes.ForEach((classToAdd) =>
            {
                classesToReturn.Add((Class)classToAdd.Clone());
            });
            return classesToReturn;
        }

        public void removeClass(Class classToRemove)
        {
            foreach (Class classToCheck in this.classes)
            {
                if(classToCheck.name == classToRemove.name)
                {
                    this.classes.Remove(classToCheck);
                    classesUpdated?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }

        public void editClassByNameOfClass(Class classToEdit)
        {
            int index = 0;
            foreach (Class classToCheck in this.classes)
            {
                if (classToCheck.name == classToEdit.name)
                {
                    this.classes[index] = (Class)classToEdit;
                    classesUpdated?.Invoke(this, EventArgs.Empty);
                    return;
                }
                index++;
            }
            throw new Exception("ClassNotFound");
        }
    }
}
