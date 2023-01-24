// ----------------------------------------------------
// Copyright ©️ 2022, Brian Parker. All rights reserved.
// ----------------------------------------------------

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorOdata.Client.Models;

public class OdataResponce<TItem>
{
    [JsonPropertyName(name: "@odata.context")]
    public string ContextUrl { get; set; } = null!;

    [JsonPropertyName(name: "@odata.count")]
    public int TotalItemsCount { get; set; }

    [JsonPropertyName(name: "value")]
    public IEnumerable<TItem> Items { get; set; } = null!;
}
