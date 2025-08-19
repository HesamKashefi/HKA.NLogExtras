# HKA.NLogExtras

Persian Date Layout Renderers for NLog


## Install

run this command in terminal (or cmd) next to your `.csproj` file
```
dotnet add package HKA.NLogExtras
```

## Usage

Configure NLog and register LayoutRenderers

```
var logger = LogManager.Setup()
    .SetupExtensions(e =>
    {
        e.RegisterLayoutRenderer<PersianLongDateLayoutRenderer>("persianlongdate");
        e.RegisterLayoutRenderer<PersianShortDateLayoutRenderer>("persianshortdate");
    })
    .LoadConfigurationFromFile('nlog.config')
    .GetCurrentClassLogger();
```

Then use it in your layouts in nlog.config file

`${persianlongdate}` or `${persianshortdate}`