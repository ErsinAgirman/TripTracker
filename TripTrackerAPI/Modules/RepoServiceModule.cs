using Autofac;
using System.Reflection;
using TripTrackerCore.Repositories;
using TripTrackerCore.Services;
using TripTrackerCore.UnitOfWorks;
using TripTrackerRepository;
using TripTrackerRepository.Repositories;
using TripTrackerRepository.UnitOfWorks;
using TripTrackerService.Mapping;
using TripTrackerService.Services;
using Module = Autofac.Module;
namespace TripTrackerAPI.Modules
{

	public class RepoServiceModule : Module
	{

		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



			var apiAssembly = Assembly.GetExecutingAssembly();
			var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
			var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
			("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
			("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
		}

	}
}
