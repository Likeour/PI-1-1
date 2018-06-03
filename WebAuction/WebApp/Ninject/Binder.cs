using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Ninject
{
    public class Binder : NinjectModule
    {
        public override void Load()
        {
            Bind<LotsService>().To<ILots>();
           
        }
    }
}