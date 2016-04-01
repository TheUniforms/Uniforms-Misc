Uniforms
========

The missing helpers library for [Xamarin Forms](https://www.xamarin.com/forms).

Install
-------

NuGet widget will appear soon.

Untl then just clone repo, copy and references to your projects.

Usage
-----

See example in `CoreSample` project:
https://github.com/TheUniforms/Uniforms-Core/blob/master/CoreSample/CoreSample.cs#L20


1. Init utilities right after `Forms.Init()`:


    On **Android**:

    ```csharp
    Uniforms.Core.Droid.Utils.Init();
    ```

    On **iOS**:

    ```csharp
    Uniforms.Core.iOS.Utils.Init();
    ```

2. Then use `Uniforms.Core.Utils` in your cross-platform code!

Quick reference
---------------

All interface is provided via single static class `Uniforms.Core.Utils`.

## Get screen size

```csharp
var screenSize = Uniforms.Core.Utils.ScreenSize;
```

## Get current locale and culture info

```csharp
var cultureInfo = Uniforms.Core.Utils.GetCurrentCultureInfo();
```

## Get image size by file name

```csharp
var imageSize = Uniforms.Core.Utils.GetImageSize("Graphics/icon.png");
```
