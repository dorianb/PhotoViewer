using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoViewer
{
    public class Picture
    {
        public String path;
        public String name;

        public Picture()
        {

        }

        public Picture(string name, string path)
        {
            this.name = name;
            this.path = path;
        }

        public void setName(String name)
        {
            this.name=name;
        }

        public String getName()
        {
            return this.name;
        }

        public void setPath(String path)
        {
            this.path = path;
        }

        public String getPath()
        {
            return this.path;
        }
    }
}
