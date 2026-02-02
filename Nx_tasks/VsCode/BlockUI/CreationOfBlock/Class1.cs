using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen.Features;
using NXOpen;

namespace CreationOfBlock
{
    public class Class1
    {
       
        public static void CreateBlock(Point3d originPoint, string length, string width, string height)
        {
            
            /*Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;
                      
            Feature nullNXOpen_Features_Feature = null;
            BlockFeatureBuilder blockFeatureBuilder1;
            blockFeatureBuilder1 = workPart.Features.CreateBlockFeatureBuilder(nullNXOpen_Features_Feature);
                         
            Point3d originPoint1 = new Point3d(0.0, 0.0, 0.0);
            blockFeatureBuilder1.SetOriginAndLengths(originPoint1, "100", "100", "100");
                       
            Feature feature1;
            feature1 = blockFeatureBuilder1.CommitFeature();
                                  
            blockFeatureBuilder1.Destroy();*/

            /*Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;

            Feature nullNXOpen_Features_Feature = null;
            BlockFeatureBuilder blockFeatureBuilder1;
            blockFeatureBuilder1 = workPart.Features.CreateBlockFeatureBuilder(nullNXOpen_Features_Feature);*/

           /*oint3d point3D = BlockCreation_1.originPoint;
            double length = BlockCreation_1.length;
            double width = BlockCreation_1.width;
            double height = BlockCreation_1.height;
            blockFeatureBuilder1.SetOriginAndLengths(point3D, length.ToString(), width.ToString(), height.ToString());*/
            ;
            //Point3d originPoint = new Point3d(0.0, 0.0, 0.0);
            /*blockFeatureBuilder1.SetOriginAndLengths(originPoint, length, width, height);

            Feature feature1;
            feature1 = blockFeatureBuilder1.CommitFeature();

            blockFeatureBuilder1.Destroy();*/
            
            try
            {
            Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;

            Feature nullNXOpen_Features_Feature = null;
            BlockFeatureBuilder blockFeatureBuilder1;
            blockFeatureBuilder1 = workPart.Features.CreateBlockFeatureBuilder(nullNXOpen_Features_Feature);

          
            blockFeatureBuilder1.SetOriginAndLengths(originPoint, length, width, height);

            Feature feature1;
            feature1 = blockFeatureBuilder1.CommitFeature();

            blockFeatureBuilder1.Destroy();
            }
            catch(Exception ex) 
            {
            UI.GetUI().NXMessageBox.Show("Error in CreateBlock Method ",NXMessageBox.DialogType.Error,ex.Message);
            }
            

        }
    }
}
