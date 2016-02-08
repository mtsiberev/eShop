using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Repository;
using StructureMap;

namespace ClassLibrary.IoC
{
    public sealed class ContainerWrapper
    {
        private static object syncRoot = new Object();
        private static volatile IContainer s_container;
        private ContainerWrapper() { }

        public static IContainer Container
        {
            get
            {
                if (s_container != null) return s_container;
                lock (syncRoot)
                {
                    if (s_container == null)
                        s_container = new Container(x =>
                        {
                            x.For<IRepository<Catalog>>().Singleton().Use<CatalogRepository>();
                            x.For<IRepository<Order>>().Singleton().Use<OrderRepository>();
                            x.For<IRepository<Product>>().Singleton().Use<ProductRepository>();
                            x.For<IRepository<User>>().Singleton().Use<UserRepository>();
                            x.For<IOrderItemRepository>().Singleton().Use<OrderItemRepository>();

                            x.For<Facade.Facade>().Singleton().Use<Facade.Facade>()
                                .Ctor<IRepository<Catalog>>()
                                .Is(new CatalogRepository())
                                .Ctor<IRepository<Order>>()
                                .Is(new OrderRepository())
                                .Ctor<IRepository<Product>>()
                                .Is(new ProductRepository())
                                .Ctor<IRepository<User>>()
                                .Is(new UserRepository())
                                .Ctor<IOrderItemRepository>()
                                .Is(new OrderItemRepository())
                                ;
                        });
                }
                return s_container;
            }
        }
    }
}
