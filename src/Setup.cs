using ApexCharts;
using BcdLib.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Opx.Blazor.BsCore.Extras
{
	public class BsCoreExtras
	{
		private IServiceCollection _services;

		public BsCoreExtras(IServiceCollection services)
		{
			_services = services;
		}

		public BsCoreExtras AddApexChart(ApexChartBaseOptions? options = null)
		{
			if (options != null)
			{
				_services.AddApexCharts(o =>
				{
					o.GlobalOptions = options;
				});
			}
			else
			{
				// Default options can be set here if needed
				_services.AddApexCharts();
			}

			return this;
		}

		public BsCoreExtras AddBcdPullComponent()
		{
			_services.AddBcdLibPullComponent();

			return this;
		}
	}

	public static class Setup
	{
		public static BsCoreExtras UseBsExtras(this IServiceCollection services)
		{
			return new BsCoreExtras(services);
		}
	}
}