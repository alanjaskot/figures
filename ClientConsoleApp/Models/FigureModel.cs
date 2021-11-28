using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp.Models
{
    public class FigureModel
    {
        public Guid Id { get; set; }
        public decimal SideOne { get; set; }
        public string FigureName { get; set; }
#nullable enable
        public decimal? SideTwo { get; set; }
        public decimal? Heigh { get; set; }
#nullable disable
    }
}
