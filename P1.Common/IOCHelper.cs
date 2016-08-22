using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace P1.Common
{
    public class IOCHelper
    {
        private static IContainer _container;
        public static void Register(IContainer container)
        {
            _container = container;            
        }
        public static T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
