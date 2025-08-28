using ApexCharts;
using Microsoft.AspNetCore.Components;

namespace Opx.Blazor.BsCore.Extras.Charts
{
	public class BsChartBase<T> : ComponentBase where T : class
	{
		private bool _isPrepared = false;
		public bool IsPrepared => _isPrepared;

		public ApexChartOptions<T> ChartOptions { get; set; } = new();
		public ApexChart<T> ChartView = default!;

		private List<T> _data;
		public List<T> Data
		{
			get => _data ??= new List<T>();
			set => _data = value;
		}

		protected virtual async Task LoadDataAsync(int sample = 0) {}

		protected virtual void LoadChartOptions() {}

		async Task UpdateChartAsync()
		{
			await LoadDataAsync();

			Prepare();

			await ChartView.UpdateSeriesAsync(true);
			await ChartView.UpdateOptionsAsync(true, false, false);

			_isPrepared = true;
			StateHasChanged();
		}

		protected virtual void Prepare()
		{
			//_isPrepared = true;
			StateHasChanged();
		}

		public virtual async Task RefreshAsync()
		{
			_isPrepared = false;

			await Task.Delay(100);

			LoadChartOptions();
			await UpdateChartAsync();
		}
	}
}
