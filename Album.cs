using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace photoViewer
{
	public class Album
    {
        public List<Picture> listImage;
        public String frontPictureName;
        public String name;
        public String path;

        public Album()
        {

            frontPictureName = "";

        }

        //création d'un nouvel Album
        public Album(String name, String path)
        {
            this.name = name;
            this.path = path;
            this.frontPictureName = "";
            listImage = new List<Picture>();
        }

        public void setName(String name)
        {

            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public String getFrontPic()
        {
            return this.frontPictureName;
        }

        public void setFrontPic(String frontPic)
        {
            this.frontPictureName = frontPic;
        }

        public List<Picture> getAllImages()
        {
            return this.listImage;
        }

        public void addImage(String name, String path)
        {
            Console.WriteLine(" add image album : " + name);
            this.listImage.Add(new Picture(name, path));
        }
       
        public void addImage(String path)
        {
            this.listImage.Add(new Picture(path, name));
        }

        //supprimer une image
        public void deleteImage(Picture p)
        {
            this.listImage.Remove(p);

        }

        public String getPath()
        {
            return this.path;
        }
    }
}
