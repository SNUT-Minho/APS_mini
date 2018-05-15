using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APS
{
    public partial class ImageDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.Params["FileName"]))
            {
                Response.End();
            }


            string strFileName = Request.Params["FileName"].ToString();
            string strFileExt = Path.GetExtension(strFileName);
            string strContentType = "";
            if (strFileExt == ".gif" || strFileExt == ".jpg" || strFileExt == ".jpeg" || strFileExt == ".png")
            {
                switch (strFileExt)
                {
                    case ".gif":
                        strContentType = "image/gif";
                        break;

                    case ".jpg":
                        strContentType = "image/jpg";
                        break;

                    case ".jpeg":
                        strContentType = "image/jpeg";
                        break;

                    case ".png":
                        strContentType = "image/png";
                        break;

                    default:
                        break;
                }
            }
            string strFilePath = Server.MapPath("./Image/") + strFileName;

            Response.Clear();
            Response.ContentType = strContentType;
            Response.WriteFile(strFilePath);
            Response.End();
        }
    }
}