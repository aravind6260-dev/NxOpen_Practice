using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.Features;

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

            Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;

            Feature nullNXOpen_Features_Feature = null;
            BlockFeatureBuilder blockFeatureBuilder1;
            blockFeatureBuilder1 = workPart.Features.CreateBlockFeatureBuilder(nullNXOpen_Features_Feature);

            //Point3d originPoint = new Point3d(0.0, 0.0, 0.0);
            blockFeatureBuilder1.SetOriginAndLengths(originPoint, length, width, height);

            Feature feature1;
            feature1 = blockFeatureBuilder1.CommitFeature();

            blockFeatureBuilder1.Destroy();

        }

    }
}
