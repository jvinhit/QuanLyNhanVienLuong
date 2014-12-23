using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer;

namespace BusinessLayer
{
    public class LoadCSDL
    {
        public void Initdata()
        {
            TaoCSDL dt = new TaoCSDL();
            dt.ThemDuLieu();
        }
        
    }
}
