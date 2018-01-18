using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointOfSaleProject.DAL
{
    public class Image
    {
            public byte[] ImageConvertToByte(HttpPostedFileBase imageFile)
            {
                byte[] imageData = null;

                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    if (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/JPG" || imageFile.ContentType == "image/jpg" ||
                        imageFile.ContentType == "image/png" || imageFile.ContentType == "image/gif")
                    {
                        if (imageFile.ContentLength <= (1 * 1024 * 1024))
                        {
                            imageData = new byte[imageFile.ContentLength];
                            imageFile.InputStream.Read(imageData, 0, imageFile.ContentLength);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }

                return imageData;
            }
        }
    }