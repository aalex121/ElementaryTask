using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TriangleSort
{
    static class Application
    {
        public static bool Run()
        {
            SortedSet<Triangle> trSet = new SortedSet<Triangle>(new TriangleComparer());

            string name;
            double side1;
            double side2;
            double side3;

            do
            {
                UI.ReqestTriangleParams(out name, out side1, out side2, out side3);

                try
                {
                    Triangle.GetArea(side1, side2, side3);
                }
                catch (UnableToBuildTriangleException ex)
                {
                    UI.PrintWarning(ex.Message);
                    continue;
                }

                trSet.Add(new Triangle(name, side1, side2, side3));

            } while (UI.GetUserConfirmation(PromptTypes.AddTriangle));

            foreach (Triangle item in trSet)
            {
                Console.WriteLine(item);
            }

            return UI.GetUserConfirmation(PromptTypes.ExitApp);
        }
    }
}
