Uniforms
========

The missing helpers library for awesome [Xamarin Forms](https://www.xamarin.com/forms)!

Why
---

There are [Xamarin-Forms-Labs](https://github.com/XLabs/Xamarin-Forms-Labs) and [Xamarin.Plugins](https://github.com/jamesmontemagno/Xamarin.Plugins) projects and probably some more but still some basic things are just missing out of box.

So, we'll try to keep simple things simple and fill some gaps. Stay tuned! :)

Install
-------

`Uniforms.Misc` package is available via NuGet:  
https://www.nuget.org/packages/Uniforms.Misc/

Alternitavely, you may just clone this repo and references to your projects.

Usage
-----

See example in `CoreSample` project:
https://github.com/TheUniforms/Uniforms-Misc/blob/master/CoreSample/CoreSample.cs#L20


1. Init utilities right after `Forms.Init()`:


    On **Android**:

    ```csharp
    Uniforms.Misc.Droid.Utils.Init();
    ```

    On **iOS**:

    ```csharp
    Uniforms.Misc.iOS.Utils.Init();
    ```

2. Then use `Uniforms.Misc.Utils` in your cross-platform code!

Quick reference
---------------

All interface is provided via single static class `Uniforms.Misc.Utils`.

## Get screen size

```csharp
var screenSize = Uniforms.Misc.Utils.ScreenSize;
```

## Handle keyboard change events

```csharp
var keyboardEvents = DependencyService.Get<IKeyboardEvents> ();
keyboardEvents.KeyboardHeightChanged += (height) => {
    Debug.WriteLine ($"KeyboardHeightChanged: {height}");
};
```

## Get current locale and culture info

```csharp
var cultureInfo = Uniforms.Misc.Utils.GetCurrentCultureInfo();
```

## Get image size by file name

```csharp
var imageSize = Uniforms.Misc.Utils.GetImageSize("Graphics/icon.png");
```

## Rounded box view

```csharp
var box = new RoundedBox {
    HeightRequest = 50,
    WidthRequest = 50,
    BackgroundColor = Color.Purple,
    CornerRadius = 10,
    ShadowOffset = new Size(0, 2.0),
    ShadowOpacity = 0.5,
    ShadowRadius = 2.0,
};
```

<img src="./Screenshots/Screenshot1.png" style="border: 1px solid #eee;">
