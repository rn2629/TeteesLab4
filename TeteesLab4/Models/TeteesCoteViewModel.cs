using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeteesLab4.Models
{
    public class TeteesCoteViewModel 
    {
        public List<Tetees> Tetees { get; set; }
        public SelectList Cotes { get; set; }
        public string TeteeCote { get; set; }
        public string SearchString { get; set; }
    }
}
