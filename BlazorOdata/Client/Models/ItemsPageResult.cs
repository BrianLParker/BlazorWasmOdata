// ----------------------------------------------------
// Copyright ©️ 2022, Brian Parker. All rights reserved.
// ----------------------------------------------------

using System.Collections.Generic;

namespace BlazorOdata.Client.Models;

public readonly struct ItemsPageResult<TItem>
{
    public ICollection<TItem> Items { get; }

    public int TotalItemsCount { get; }

    public ItemsPageResult(ICollection<TItem> items, int totalItemsCount)
    {
        Items = items;
        TotalItemsCount = totalItemsCount;
    }
}
