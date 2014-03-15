using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;


namespace photoViewer
{
    public partial class Form1 : Form
    {
        private List<Album> listAlbum;
       
        private ImportMenu slide;
        ModifyElement mod;
        private bool isFullScreen;

        public Form1()
        {
            #region initialize components

            InitializeComponent();

            this.slideShow.fullScreenClick += new SlideShow.UserControlClickHandler(this.fullScreen_Click);

            this.WindowState = FormWindowState.Maximized;

            this.albumControl1.NextAlbum.Click += clickNextAlbum;
            this.albumControl1.PreviousAlbum.Click += clickPreviousAlbum;
            this.albumControl1.AlbumRightImg.Click += clickNextAlbum;
            this.albumControl1.AlbumLeftImg.Click += clickPreviousAlbum;

            #endregion initialize components


            //Properties
            this.listAlbum = ReadXML();


            #region subscriptions


            albumControl1.LoadAlbumControl(listAlbum);


            if (listAlbum.Count > 0)
            {
                imageFlow1.DisplayImages(listAlbum.ElementAt(albumControl1.getAlbumSelected(listAlbum)));

                foreach (PictureBox p in imageFlow1.pictures)
                {
                    p.MouseDown += selectImageFlow;
                }

               
            }
                imageFlow1.flowLayoutPanel1.DragDrop += dropImagFlow;
            albumControl1.AlbumLeftImg.DragDrop += moveImageInLeft;
            albumControl1.AlbumRightImg.DragDrop += moveImageInRight;

            this.OrganizeView();

            settings.AllowDrop = true;
            trashPicture.AllowDrop = true;

            #endregion
        }


        #region xml Serialisation/Deserialisation

        public static List<Album> ReadXML()
        {
            List<Album> tmp = new List<Album>();

            try
            {
                XmlSerializer xd = new XmlSerializer(typeof(List<Album>));
                using (StreamReader rd = new StreamReader("albums.xml"))
                {
                    tmp = xd.Deserialize(rd) as List<Album>; //deserialize
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("XML read Error: " + e.Message);
            }

            return tmp;
        }

        public static void WriteXML(List<Album> albums)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Album>));
                using (StreamWriter wr = new StreamWriter("albums.xml"))
                {
                    xs.Serialize(wr, albums); // Serialize the array
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("XML Write Error: " + e.Message);
            }
        }

        #endregion

       


        #region Events Management

        private void Form1_Load(object sender, EventArgs e)
        {
           


            if (this.albumControl1.getAlbumSelected(this.listAlbum)!=-1)
            {
                this.slideShow.SlideShow_Load(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getAllImages());
            }       


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                    this.slideShow.GoNext();
                    return true;
                case Keys.Left:
                    this.slideShow.GoPrevious();
                    return true;
                case Keys.Escape:
                    this.slideShow.fullScreenPressed();
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void trash_Enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                System.Console.WriteLine("trash data format: " + e.Data.GetData(DataFormats.Text).ToString());
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void trash_drop(object sender, DragEventArgs e)
        {
            /*try
            {*/
                if (e.Data.GetData(DataFormats.Text).ToString() == "album")
                {
                    Console.WriteLine("hello");
                    System.IO.Directory.Delete(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath(), true);
                    Console.WriteLine("ICII");
                    this.listAlbum.Remove(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)));
                    WriteXML(this.listAlbum);

                    this.albumControl1.LoadAlbumControl(listAlbum);
                    this.updateDisplay();
                    
                    this.imageFlow1.dealloc();
                    this.slideShow.dealloc();
                    
                }
                else
                {
                    int index = int.Parse(e.Data.GetData(DataFormats.Text).ToString());
                    System.IO.File.Delete(listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).getAllImages().ElementAt(index).getPath());
                    this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).deleteImage(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getAllImages().ElementAt(index));

                    try
                    {
                        this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).setFrontPic(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getAllImages().ElementAt(0).getName());  
                    }
                    catch (Exception ex)
                    {
                        this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).setFrontPic(null);
                        this.slideShow.dealloc();
                        System.Console.WriteLine("erreur dans Form1.cs function trashDrop " + ex);
                    }

                    WriteXML(this.listAlbum);    

                    this.updateDisplay();
                    

                    
                }
          /* }
           catch(Exception exception)
           {
               System.Diagnostics.Debug.WriteLine("trash drop: " + exception.Message);
           }*/
        }

        private void webView_Click(object sender, EventArgs e)
        {
            try
            {
                //générer le code HTML
            String code = "<!doctype html><html lang=\"fr\"><head><meta charset=\"utf-8\">";
            code += "<link type=\"text/css\" href=\"" + Application.StartupPath.Replace(" ", "%20").Replace("#", "%23") + "/CSSFile.css\" rel=\"stylesheet\"/>";
            
            code += "<title>Photo Viewer</title></head><body>";

            code += "<h1>Photo Viewer</h1>";

            String imageURL;


            int i = 1;
            code += "<table>";
            foreach(Picture picture in this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getAllImages())
            {
                if (i % 5 == 0)
                {
                    code += "<tr>";
                }

                code += "<td>";

                imageURL = (Application.StartupPath + "\\" + picture.getPath()).Replace(" ", "%20").Replace("#", "%23");

                code += "<img src=\"" + imageURL + "\" />";

                code += "</td>";

                if (i % 4== 0)
                {
                    code += "</tr>";
                }

                i++;
            }

            code += "</table>";
            code += "</body></html>";

            System.IO.File.WriteAllText(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getName() + ".html", code);

            //Générer le code CSS
            String cssCode = "body {  height:1300px;  font: 20px Georgia, serif; margin-top: 0pt; margin-left: 0pt; margin-right: 0pt; margin-bottom: 0pt; padding-top: 0pt; padding-left: 0pt; padding-right: 0pt; padding-bottom: 0pt; border-top: 0pt; border-left: 0pt; border-right: 0pt; border-bottom: 0pt; position:relative; background-color: #0000ff; }";
            cssCode += "img { border: 0px; width: 300px; height: 300px; }";
            cssCode += "ul { padding : 0; /* pas de marge intérieure */ margin : 0; /* ni extérieure */ list-style : none; }";

            System.IO.File.WriteAllText("CSSFile.css", cssCode);

            //obtenir le navigateur par défaut
            string browser = "iexplorer.exe";
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice"))
            {
                if (userChoiceKey != null)
                {
                    object progIdValue = userChoiceKey.GetValue("Progid");
                    if (progIdValue != null)
                    {
                        if (progIdValue.ToString().ToLower().Contains("chrome"))
                            browser = "chrome.exe";
                        else if (progIdValue.ToString().ToLower().Contains("firefox"))
                            browser = "firefox.exe";
                        else if (progIdValue.ToString().ToLower().Contains("safari"))
                            browser = "safari.exe";
                        else if (progIdValue.ToString().ToLower().Contains("opera"))
                            browser = "opera.exe";
                    }
                }
            }

            //ouvrir la page html avec le navigateur web par défaut
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo processStarInf = new ProcessStartInfo();
            processStarInf.FileName = browser;
            String url = "file:///" + Application.StartupPath + "\\" + this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getName() + ".html";
            processStarInf.Arguments = url.Replace(" ", "%20").Replace("#", "%23");
            processStarInf.WindowStyle = ProcessWindowStyle.Maximized;
            proc = Process.Start(processStarInf);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("erreur dans Form1.cs function webView " + ex);
            }
            
        }

        private void fullScreen_Click(object sender, EventArgs e)
        {
            if(isFullScreen)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;
                this.ControlBox = true;
                this.slideShow.Dock = System.Windows.Forms.DockStyle.Right;
                this.isFullScreen = false;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.ControlBox = false;
                this.slideShow.Dock = System.Windows.Forms.DockStyle.Fill;
                this.isFullScreen = true;
            }
            
        }

        private void addAlbum_Click(object sender, EventArgs e)
        {
            //appeler slide pour demander le nom de l'album
            slide = new ImportMenu(this.Width, this.Height, "album");
            slide.BringToFront();

            this.Controls.Add(slide);

            if (slide.Focused) addAlbum.Enabled = false;
            slide.Focus();

            slide.addButton.Click += recupAlbum;            
        }

        private void addPicture_Click(object sender, EventArgs e)
        {
            //appeler slide pour choisir l'image à importer et son nom
            slide = new ImportMenu(this.Width, this.Height, "image");
            slide.BringToFront();

            this.Controls.Add(slide);

            if (slide.Focused) addPicture.Enabled = false;
            slide.Focus();

            slide.addButton.Click += recupImage;
        }

        

       
       

        private void selectImageFlow(object sender, EventArgs ev)
        {
            PictureBox pic = sender as PictureBox;
            int index = 0;
            
            


            index = imageFlow1.pictures.IndexOf(pic) ;

            Console.WriteLine("SelectimageFlow()" + index);

            if (index >=0)
            {

                this.slideShow.selectImage(index);
            }
            
        }

        public void clickNextAlbum(object sender, EventArgs e)
        {
            this.slideShow.stopTimer();
            this.albumControl1.GoNextAlbum(this.listAlbum);
            this.updateDisplay();
        }

        public void clickPreviousAlbum(object sender, EventArgs e)
        {
            this.slideShow.stopTimer();
            this.albumControl1.GoPreviousAlbum(this.listAlbum);
            this.updateDisplay();
        }

        public void dropImagFlow(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));

                LoadingBar load = new LoadingBar(this.Width, this.Height, filePaths.Count());
                this.Controls.Add(load);
                Thread.Sleep(1);

                load.BringToFront();

                try
                {

                foreach (string fileLoc in filePaths)
                {
                    System.IO.File.Copy(System.IO.Path.GetFullPath(fileLoc), this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + System.IO.Path.GetFileName(fileLoc));

                    this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getAllImages().Add(new Picture(System.IO.Path.GetFileName(fileLoc), System.IO.Path.GetDirectoryName(fileLoc)));

                        //changer le path
                        this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).listImage.ElementAt(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).listImage.Count - 1).setPath(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + System.IO.Path.GetFileName(fileLoc));

                        //Actualiser frontPic
                        this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).setFrontPic(System.IO.Path.GetFileName(fileLoc));

                        //sérialization
                        WriteXML(this.listAlbum);

                        load.setValue();
                        Thread.Sleep(1);
                    }
                load.Dispose();
                updateDisplay();

            }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine("Image Flow Drop: " + exception.Message);
                    load.Dispose();
                    updateDisplay();
                }
            }
            else
                e.Effect = DragDropEffects.None;

        }

        private void settings_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                System.Console.WriteLine(e.Data.GetData(DataFormats.Text).ToString());
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void settings_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetData(DataFormats.Text).ToString() == "album")
                {
                    this.mod = new ModifyElement(this.Width, this.Height, listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)));
                    mod.BringToFront();
                    mod.applyButton.Click += modifyClick;
                    this.Controls.Add(mod);
                }
                else
                {
                    int index = int.Parse(e.Data.GetData(DataFormats.Text).ToString());
                    Picture pic = listAlbum.ElementAt(albumControl1.getAlbumSelected(listAlbum)).getAllImages().ElementAt(index);

                    this.mod = new ModifyElement(this.Width, this.Height, pic, index);
                    mod.BringToFront();

                    mod.applyButton.Click += modifyClick;

                    this.Controls.Add(mod);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("erreur dans Form1.cs function settings dragDrop " + ex);
            }
        }

        private void modifyClick(object sender, EventArgs e)
        {
            if (mod.ImageIndex == -1)
            {
                DirectoryInfo dir = new DirectoryInfo(listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).getPath());
                
                Directory.CreateDirectory("albums\\"+mod.getName());



                listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).path = "albums\\" + mod.getName() + "\\";
                 foreach (Picture pic in listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).getAllImages())
                 {
                     System.IO.File.Copy(pic.getPath(), "albums\\"+ mod.getName()+"\\" + pic.getName());

                     pic.setPath("albums\\" + mod.getName() + "\\" + pic.getName());


                 }
                 listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).setName(mod.getName());


                mod.Dispose();

                WriteXML(listAlbum);
                this.updateDisplay();

            }
            else
            {

                listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).listImage.ElementAt(mod.ImageIndex).setName(mod.getName()+mod.file.Extension);
                listAlbum.ElementAt(this.albumControl1.getAlbumSelected(listAlbum)).listImage.ElementAt(mod.ImageIndex).setPath(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + mod.getName() + mod.file.Extension);
                
                
                System.IO.File.Copy(mod.file.FullName, this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + mod.getName() + mod.file.Extension);
                
                System.IO.File.Delete(mod.file.FullName);

                if (this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getFrontPic() == mod.file.Name)
                {
                    this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).setFrontPic(mod.getName() + mod.file.Extension);
                }

                this.mod.Dispose();



                
                Form1.WriteXML(listAlbum);
                this.updateDisplay();
            }
        }

        private void albumControl1_SizeChanged(object sender, EventArgs e)
        {
            this.OrganizeView();

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.OrganizeView();
        }

        private void moveImageInLeft(object sender, DragEventArgs e)
        {

            Picture pic = listAlbum.ElementAt(albumControl1.getAlbumSelected(listAlbum)).listImage.ElementAt(int.Parse(e.Data.GetData(DataFormats.Text).ToString()));

            FileInfo file = new FileInfo(pic.getPath());


            listAlbum.ElementAt(albumControl1.getAlbumLeft(listAlbum)).addImage(pic.getName(), pic.getPath());

            Console.WriteLine("imageinleft: " + this.listAlbum.ElementAt(this.albumControl1.getAlbumLeft(this.listAlbum)).listImage.ElementAt(this.listAlbum.ElementAt(this.albumControl1.getAlbumLeft(this.listAlbum)).listImage.Count - 1).getName());


            //déplacer l'image
            System.IO.File.Copy(file.FullName, this.listAlbum.ElementAt(this.albumControl1.getAlbumLeft(this.listAlbum)).getPath() + pic.getName());

            //changer le path
            this.listAlbum.ElementAt(this.albumControl1.getAlbumLeft(this.listAlbum)).listImage.ElementAt(this.listAlbum.ElementAt(this.albumControl1.getAlbumLeft(this.listAlbum)).listImage.Count - 1).setPath(this.listAlbum.ElementAt(this.albumControl1.getAlbumLeft(this.listAlbum)).getPath() + pic.getName());
            //Actualiser frontPic
            this.listAlbum.ElementAt(this.albumControl1.getAlbumLeft(this.listAlbum)).setFrontPic(Path.GetFileName(pic.getPath()));

            //sérialization
            WriteXML(this.listAlbum);
            System.Console.WriteLine("je suis la");
            updateDisplay();

        }
        private void moveImageInRight(object sender, DragEventArgs e)
        {
            Picture pic = listAlbum.ElementAt(albumControl1.getAlbumSelected(listAlbum)).listImage.ElementAt(int.Parse(e.Data.GetData(DataFormats.Text).ToString()));

            FileInfo file = new FileInfo(pic.getPath());

            listAlbum.ElementAt(albumControl1.getAlbumRight(listAlbum)).addImage(pic.getName(), Path.GetFileName(pic.getPath()));




            //déplacer l'image
            System.IO.File.Copy(file.FullName, this.listAlbum.ElementAt(this.albumControl1.getAlbumRight(this.listAlbum)).getPath() + pic.getName());
            Console.WriteLine("je passe ici");
            //changer le path
            this.listAlbum.ElementAt(this.albumControl1.getAlbumRight(this.listAlbum)).listImage.ElementAt(this.listAlbum.ElementAt(this.albumControl1.getAlbumRight(this.listAlbum)).listImage.Count - 1).setPath(this.listAlbum.ElementAt(this.albumControl1.getAlbumRight(this.listAlbum)).getPath() + pic.getName());

            //Actualiser frontPic
            this.listAlbum.ElementAt(this.albumControl1.getAlbumRight(this.listAlbum)).setFrontPic(Path.GetFileName(pic.getPath()));

            //sérialization
            WriteXML(this.listAlbum);
            updateDisplay();

        }
        
        private void recupImage(object sender, EventArgs ev)
        {
            if (this.albumControl1.getAlbumSelected(this.listAlbum) != -1)
            {

                if ((slide.getName() != "") && (slide.getAddress() != ""))
                {
                    //créer picture
                    Console.WriteLine("remplie");
                    FileInfo file = new FileInfo(slide.getAddress());

                    this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getAllImages().Add(new Picture(slide.getName() + file.Extension, slide.getAddress()));

                    //déplacer l'image
                    System.IO.File.Copy(slide.getAddress(), this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + slide.getName() + file.Extension);

                    //changer le path
                    this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).listImage.ElementAt(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).listImage.Count - 1).setPath(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getPath() + slide.getName() + file.Extension);
                    //Actualiser frontPic
                    this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).setFrontPic(slide.getName() + file.Extension);

                    //sérialization
                    WriteXML(this.listAlbum);

                    slide.Dispose();
                    updateDisplay();
                }
            }
        }
        private void recupAlbum(object sender, EventArgs ev)
        {

            if ((slide.getName() != ""))
            {
                //créer l'album en mémoire
                this.listAlbum.Add(new Album(slide.getName(), "albums\\" + slide.getName() + "\\"));

                //créér l'album dans le projet
                System.IO.Directory.CreateDirectory(this.listAlbum.ElementAt(this.listAlbum.Count - 1).getPath());

                //sérialization
                WriteXML(this.listAlbum);

                slide.Dispose();
                albumControl1.LoadAlbumControl(this.listAlbum);
                updateDisplay();

            }
        }

        #endregion Events Management



        #region Display Functions
        private void updateDisplay()
        {
            this.albumControl1.UpdateAlbumControl(this.listAlbum);
            if (this.albumControl1.getAlbumSelected(this.listAlbum) != -1)
            {
                imageFlow1.DisplayImages(this.listAlbum.ElementAt(albumControl1.getAlbumSelected(listAlbum)));
                this.slideShow.SlideShow_Load(this.listAlbum.ElementAt(this.albumControl1.getAlbumSelected(this.listAlbum)).getAllImages());
            }
            
            foreach (PictureBox p in imageFlow1.pictures)
            {
                p.MouseDown+= selectImageFlow;
            }
        }

        private void OrganizeView()
        {
            this.imageFlow1.organize(this.Width, this.Height);
            this.albumControl1.OrganizeAlbumControl(this.Width, this.Height);
            this.slideShow.organize(this.Width, this.Height);

            this.addAlbum.Location = new Point(imageFlow1.Width + 20,addAlbum.Location.Y);
            this.addPicture.Location = new Point(imageFlow1.Width + 20, addPicture.Location.Y);
            this.trashPicture.Location = new Point(imageFlow1.Width + 20, imageFlow1.Location.Y+imageFlow1.Height-trashPicture.Height);
            this.settings.Location = new Point(imageFlow1.Width + 20, imageFlow1.Location.Y + imageFlow1.Height - trashPicture.Height-settings.Height-5);
            this.webView.Location = new Point(imageFlow1.Width + 20, webView.Location.Y);
        }

        #endregion
 
    }
}
