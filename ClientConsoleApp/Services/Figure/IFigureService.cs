using ClientConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp.Services.Figure
{
    public interface IFigureService
    {
        public List<FigureResponseModel> GetAllFiguresByName(string figureName);
        public bool AddFigure(FigureModel figure);
    }
}
