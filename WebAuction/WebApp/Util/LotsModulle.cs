using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BLL.Services;
using BLL.Interfaces;
namespace WebApp.Util
{
    public class LotsModulle : NinjectModule
    {
        public override void Load()
        {
          //  Bind<ILots>().To<LotsService>();
        }
    }
}