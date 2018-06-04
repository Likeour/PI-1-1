using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ninject
{
    public static class LogicDependencyResolver
    {
        static DAL.UnitOfWork UoW;
        static LogicDependencyResolver()
        {
            UoW = new UnitOfWork();
        }

        public static IUnitOfWork ResolveUoW()
        {
            return UoW;
        }
    }
}
