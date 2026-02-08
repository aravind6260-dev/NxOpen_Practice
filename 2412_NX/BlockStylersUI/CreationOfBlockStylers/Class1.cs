using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen.Features;
using NXOpen;

namespace CreationOfBlockStylers
{
    public class Class1
    {
        public static void CreateBlock(Point3d originPoint_1, string length_1, string width_1, string height_1)
        {
                    
            try
            {
                Session theSession = Session.GetSession();
                Part workPart = theSession.Parts.Work;
                Part displayPart = theSession.Parts.Display;

                Feature nullNXOpen_Features_Feature = null;
                BlockFeatureBuilder blockFeatureBuilder1;
                blockFeatureBuilder1 = workPart.Features.CreateBlockFeatureBuilder(nullNXOpen_Features_Feature);

                blockFeatureBuilder1.SetOriginAndLengths(originPoint_1, length_1, width_1, height_1);

                Feature feature1;
                feature1 = blockFeatureBuilder1.CommitFeature();

                blockFeatureBuilder1.Destroy();
            }
            catch (Exception ex)
            {
                UI.GetUI().NXMessageBox.Show("Error in CreateBlock Method ", NXMessageBox.DialogType.Error, ex.Message);
            }


        }
        public static void CreateCylinder(Vector3d directions_1, Point3d originPoint_2, string diameter_1, string height_2)
        {
            try
            {
                Session theSession = Session.GetSession();
                Part workPart = theSession.Parts.Work;

                Feature nullNXOpen_Features_Feature = null;
                CylinderBuilder cylinderBuilder1;
                cylinderBuilder1 = workPart.Features.CreateCylinderBuilder(nullNXOpen_Features_Feature);


                cylinderBuilder1.Diameter.RightHandSide = diameter_1;

                cylinderBuilder1.Height.RightHandSide = height_2;
                Point startpoint = workPart.Points.CreatePoint(originPoint_2);
                cylinderBuilder1.Axis.Point = startpoint;
                startpoint.RemoveViewDependency();
                Direction manualDirection = workPart.Directions.CreateDirection(originPoint_2, directions_1, SmartObject.UpdateOption.WithinModeling);
                cylinderBuilder1.Axis.Direction = manualDirection;

                NXObject nXObject1;
                nXObject1 = cylinderBuilder1.Commit();

                cylinderBuilder1.Destroy();
            }
            catch (Exception ex)
            {
                UI.GetUI().NXMessageBox.Show("Error in CreateCylinder Method ", NXMessageBox.DialogType.Error, ex.Message);
            }

        }
        public static void CreateCone(Vector3d directions_2, Point3d originPoint_3, string baseDiameter, string topDiameter, string height_3)
        {
            try
            {
                Session theSession = Session.GetSession();
                Part workPart = theSession.Parts.Work;

                Cone nullNXOpen_Features_Cone = null;
                ConeBuilder coneBuilder1;
                coneBuilder1 = workPart.Features.CreateConeBuilder(nullNXOpen_Features_Cone);

                coneBuilder1.BaseDiameter.RightHandSide = baseDiameter;

                coneBuilder1.TopDiameter.RightHandSide = topDiameter;

                coneBuilder1.Height.RightHandSide = height_3;
                Point startpoint = workPart.Points.CreatePoint(originPoint_3);
                startpoint.RemoveViewDependency();
                coneBuilder1.Axis.Point = startpoint;
                Direction manualDirection = workPart.Directions.CreateDirection(originPoint_3, directions_2, SmartObject.UpdateOption.WithinModeling);
                //coneBuilder1.AxisDirection.RightHandSide = manualDirection;
                coneBuilder1.Axis.Direction = manualDirection;

                //coneBuilder1.HalfAngle.RightHandSide = "45";

                NXObject nXObject1;
                nXObject1 = coneBuilder1.Commit();

                coneBuilder1.Destroy();
            }
            catch (Exception ex)
            {
                UI.GetUI().NXMessageBox.Show("Error in CreateCone Method ", NXMessageBox.DialogType.Error, ex.Message);
            }

        }
        public static void CreateSphere(Point3d originPoint_4, string diameter_2)
        {
            try
            {

                Session theSession = Session.GetSession();
                Part workPart = theSession.Parts.Work;

                Sphere nullNXOpen_Features_Sphere = null;
                SphereBuilder sphereBuilder1;
                sphereBuilder1 = workPart.Features.CreateSphereBuilder(nullNXOpen_Features_Sphere);

                sphereBuilder1.Diameter.RightHandSide = diameter_2;
                Point centerPoint = workPart.Points.CreatePoint(originPoint_4);
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
