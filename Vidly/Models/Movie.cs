using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        //short cut for properties is prop + tab
        //Property are use to represent state

        //Control + Tab to quickly switch between active files or tabs in Visual studie
        //Alt + Tab for windows
        public int Id { get; set; }

        public string Name { get; set; }
    }
}