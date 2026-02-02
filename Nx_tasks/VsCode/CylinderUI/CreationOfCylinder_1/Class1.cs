using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;

namespace CreationOfCylinder_1
{
    public class Class1
    {
        public static void CreateCylinder(Vector3d directions, Point3d originPoint, string diameter, string height)
        {
            try
            {
                NXOpen.Session theSession = NXOpen.Session.GetSession();
                NXOpen.Part workPart = theSession.Parts.Work;

                NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
                NXOpen.Features.CylinderBuilder cylinderBuilder1;
                cylinderBuilder1 = workPart.Features.CreateCylinderBuilder(nullNXOpen_Features_Feature);


                cylinderBuilder1.Diameter.RightHandSide = diameter;

                cylinderBuilder1.Height.RightHandSide = height;
                Point startpoint = workPart.Points.CreatePoint(originPoint);
                cylinderBuilder1.Axis.Point = startpoint;
                startpoint.RemoveViewDependency();
                Direction manualDirection = workPart.Directions.CreateDirection(originPoint, directions, SmartObject.UpdateOption.WithinModeling);
                cylinderBuilder1.Axis.Direction = manualDirection;

                NXOpen.NXObject nXObject1;
                nXObject1 = cylinderBuilder1.Commit();

                cylinderBuilder1.Destroy();
            }
            catch (Exception ex)
            {
                UI.GetUI().NXMessageBox.Show("Error in CreateCylinder Method ", NXMessageBox.DialogType.Error, ex.Message);
            }

        }
    }
}
