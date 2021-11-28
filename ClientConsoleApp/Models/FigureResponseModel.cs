using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp.Models
{
    public class FigureResponseModel
    {
        public Guid Id { get; set; }
        public string FigureName { get; set; }
        public decimal? Area { get; set; }
    }
}
