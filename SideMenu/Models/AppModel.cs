using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideMenu.Models
{
    public class AppModel
    {
        public string FileName { get; set; }
        public AppModel(string fileName)
        {
            FileName = fileName;
        }
    }
}
