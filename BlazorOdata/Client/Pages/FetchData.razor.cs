using System.Net.Http.Json;
using BlazorOdata.Client.Models;
using BlazorOdata.Shared;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace BlazorOdata.Client.Pages;

public partial class FetchData
{
    GridItemsProvider<WeatherForecast> itemsProvider => GetWeatherForecastsAsync;

    public async ValueTask<GridItemsProviderResult<WeatherForecast>> GetWeatherForecastsAsync(GridItemsProviderRequest<WeatherForecast> request)
    {
        var sortColumns = request.GetSortByProperties();
        string queryString = string.Empty;
        foreach (var item in sortColumns)
        {
            var name = item.PropertyName;
            var direction = item.Direction switch
            {
                SortDirection.Descending => "desc",
                _ => "asc"
            };
            queryString += $"{name} {direction}";
        }

        if (queryString != string.Empty)
        {
            queryString = "$orderby=" + queryString;
        }

        ItemsPageResult<ItemContextResult<WeatherForecast>> r = await this.GetTenantsAsync(request.StartIndex, request.Count ?? 200, queryString, request.CancellationToken)!;
        GridItemsProviderResult<WeatherForecast> result = new()
        {
            Items = r.Items.Select(a => a.Item).ToList(),
            TotalItemCount = r.TotalItemsCount
        };
        return result;
    }

    private async ValueTask<ItemsPageResult<ItemContextResult<WeatherForecast>>> GetTenantsAsync(int startIndex, int count, string queryString, CancellationToken cancellationToken) 
        => await GetItemsAsync<WeatherForecast>(endpoint: "WeatherForecasts", startIndex: startIndex, count: count, queryString: queryString, cancellationToken: cancellationToken);

    private async ValueTask<ItemsPageResult<ItemContextResult<TItem>>> GetItemsAsync<TItem>(string endpoint, int startIndex, int count, string queryString, CancellationToken cancellationToken)
    {
        var query = $"odata/{endpoint}?{queryString}&$skip={startIndex}&$top={count}&$count=true";
        OdataResponce<TItem> response = (await this.Http.GetFromJsonAsync<OdataResponce<TItem>>(query, cancellationToken))!;
        var contextItems = response.Items.Select((item, index) => new ItemContextResult<TItem>(item, index + startIndex)).ToList();
        return new ItemsPageResult<ItemContextResult<TItem>>(contextItems, totalItemsCount: response.TotalItemsCount);
    }
}