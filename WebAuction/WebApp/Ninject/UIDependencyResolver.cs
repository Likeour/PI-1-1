using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApp.Ninject
{
    public static class UIDependencyResolver<T>
    {
        public static dynamic ResolveDependency()
        {
            if (typeof(T) == typeof(ILots))
                return new LotsService();
           
            else return null;
        }
    }
}