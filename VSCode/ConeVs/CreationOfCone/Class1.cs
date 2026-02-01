using NXOpen;
using NXOpen.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationOfCone
{
    public class Class1
    {
        public static void CreateCone(Point3d originPoint,Vector3d directions ,string baseDiameter, string topDiameter, string height)
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
            coneBuilder1.Axis.Point = startpoint;
            Direction manualDirection = workPart.Directions.CreateDirection(originPoint, directions, SmartObject.UpdateOption.WithinModeling);
            //coneBuilder1.AxisDirection.RightHandSide = manualDirection;
            coneBuilder1.Axis.Direction = manualDirection;

            //coneBuilder1.HalfAngle.RightHandSide = "45";

            NXOpen.NXObject nXObject1;
            nXObject1 = coneBuilder1.Commit();
         
            coneBuilder1.Destroy();
                                   
        }
    }
}
