Install Odata on the server:
```
NuGet\Install-Package Microsoft.AspNetCore.OData -Version 8.0.12
```

Install QuickGrid on the Client:
```
NuGet\Install-Package Microsoft.AspNetCore.Components.QuickGrid -Version 0.1.0-alpha.22351.1
```


`Program.cs`
```cs
builder.Services.AddControllers()
    .AddOData(options => options.AddRouteComponents(routePrefix: "odata", GetEdmModel())
        .Select()
        .Filter()
        .Expand()
        .Count()
        .OrderBy()
        .SetMaxTop(maxTopValue: 200));
```

```cs
public static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

    builder.EntitySet<BlobContainer>(name: "BlobContainers")
        .EntityType.HasKey(blobContainer => blobContainer.ContainerName);

    return builder.GetEdmModel();
}
```