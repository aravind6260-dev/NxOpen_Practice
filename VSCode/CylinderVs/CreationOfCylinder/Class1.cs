using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationOfCylinder
{
    public class Class1
    {
        public static void CreateCylinder(Point3d originPoint,Vector3d directions,string diameter, string height)
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
            Direction manualDirection = workPart.Directions.CreateDirection(originPoint,directions, SmartObject.UpdateOption.WithinModeling);  
            cylinderBuilder1.Axis.Direction = manualDirection;

            NXOpen.NXObject nXObject1;
            nXObject1 = cylinderBuilder1.Commit();
                                         
            cylinderBuilder1.Destroy();
                            
        }
    }
}
