using Autofac;
using Library.Business.Abstract;
using Library.Business.Concrete.Managers;
using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete.Dapper;

namespace Library.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DpBookDal>().As<IBookDal>();
            builder.RegisterType<BookManager>().As<IBookService>();
        }
    }
}
