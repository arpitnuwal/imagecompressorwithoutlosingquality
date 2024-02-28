using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
         string  filename = "new.jpg";
            VaryQualityLevel(FileUpload1.PostedFile.InputStream, filename);
           
        }
    }

    private void VaryQualityLevel(Stream stream, string fname)
    {



        //  size 
        System.Drawing.Image photo = new Bitmap(stream);
       

       
        // without size
          Bitmap bmp1 = new Bitmap(stream);
        ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
        myEncoderParameters.Param[0] = myEncoderParameter;
        bmp1.Save(Server.MapPath("~/img/" + fname), jgpEncoder, myEncoderParameters);
        bmp1.Dispose();

    }
    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;

    }
}