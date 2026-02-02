using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.Features;

namespace CreationOfSphere_1
{
    public class Class1
    {
        public static void CreateSphere(Point3d originPoint, string diameter)
        {
            try
            {

                Session theSession = Session.GetSession();
                Part workPart = theSession.Parts.Work;

                Sphere nullNXOpen_Features_Sphere = null;
                SphereBuilder sphereBuilder1;
                sphereBuilder1 = workPart.Features.CreateSphereBuilder(nullNXOpen_Features_Sphere);

                sphereBuilder1.Diameter.RightHandSide = diameter;
                Point centerPoint = workPart.Points.CreatePoint(originPoint);
                centerPoint.RemoveViewDependency();

                sphereBuilder1.CenterPoint = centerPoint;

                NXObject nXObject1;
                nXObject1 = sphereBuilder1.Commit();

                //Expression expression2 = sphereBuilder1.Diameter;
                sphereBuilder1.Destroy();
            }
            catch (Exception ex)
            {
                UI.GetUI().NXMessageBox.Show("Error in CreateSphere Method ", NXMessageBox.DialogType.Error, ex.Message);
            }

        }

    }
}
