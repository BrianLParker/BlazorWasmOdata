// ----------------------------------------------------
// Copyright ©️ 2022, Brian Parker. All rights reserved.
// ----------------------------------------------------

namespace BlazorOdata.Client.Models;

public readonly struct ItemContextResult<TItem>
{
    public TItem Item { get; }
    public int Offset { get; }

    public ItemContextResult(TItem item, int offset)
    {
        Item = item;
        Offset = offset;
    }
}
