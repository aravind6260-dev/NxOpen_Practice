using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;

namespace CreationOfCone_1
{
    public class Class1
    {
        public static void CreateCone(Vector3d directions, Point3d originPoint, string baseDiameter, string topDiameter, string height)
        {
            try
            {
                NXOpen.Session theSession = NXOpen.Session.GetSession();
                NXOpen.Part workPart = theSession.Parts.Work;

                NXOpen.Features.Cone nullNXOpen_Features_Cone = null;
                NXOpen.Features.ConeBuilder coneBuilder1;
                coneBuilder1 = workPart.Features.CreateConeBuilder(nullNXOpen_Features_Cone);

                coneBuilder1.BaseDiameter.RightHandSide = baseDiameter;

                coneBuilder1.TopDiameter.RightHandSide = topDiameter;

                coneBuilder1.Height.RightHandSide = height;
                Point startpoint = workPart.Points.CreatePoint(originPoint);
                startpoint.RemoveViewDependency();
                coneBuilder1.Axis.Point = startpoint;
                Direction manualDirection = workPart.Directions.CreateDirection(originPoint, directions, SmartObject.UpdateOption.WithinModeling);
                //coneBuilder1.AxisDirection.RightHandSide = manualDirection;
                coneBuilder1.Axis.Direction = manualDirection;

                //coneBuilder1.HalfAngle.RightHandSide = "45";

                NXOpen.NXObject nXObject1;
                nXObject1 = coneBuilder1.Commit();

                coneBuilder1.Destroy();
            }
            catch (Exception ex)
            {
                UI.GetUI().NXMessageBox.Show("Error in CreateCone Method ", NXMessageBox.DialogType.Error, ex.Message);
            }

        }

    }
}
