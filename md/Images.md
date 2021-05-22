Images
======

## Image sources

2 types:
- Platform independent:
  - Backgrounds
  - Any image needed to the app
- Platform specific:
  - icons
  - splash screen

Platform independent images can be either downloaded via an URI or embedded in the PCL.
Platform specific images need to be added to related platform projects.

## Downloaded Images

In XAML:

```xml
<Image Source="Any URI" />
```

Internally XAML parser creates an `UriImageSource`. Caching is enabled by default so images are available for 24 hours.

`Source` is of type `ImageSource`. It is an abstract class that has many derivatives.
To init an `ImageSource` you have 2 ways:
- Use factory methods in the `ImageSource` class.
  - `FromUri`
  - `FromFile`
  - `FromStream`
  - `FromResource`
- Instanciate a derivative type directly.

```csharp
var theUri = "http://domain/uri/younameit/";

// Using factory methods
var imageSource = (UriImageSource) ImageSource.FromUri(new Uri(theUri));

// Using derivative type directly.
var imageSource = new UriImageSource{Uri= new Uri(theUri)};
```

`UriImageSource` has several properties :
- `CachingEnabled`: Enable caching.
- `CacheValidity`: Determine how long does cache need to keep images. Default 24 hours. Use `TimeSpan` type to define.

The image has a `Source` property to which we can pass our `imageSource`. It can also implicitly cast `string` to `Uri`.

## Aspect

Images have an `Aspect` property which has these options:
- `AspectFill`: Keeps the aspect ratio of the image but resize it to fill the container.
- `AspectFit`: Keeps the aspect ratio of the image and fit into its container.
- `Fill`: Fills the container distorting the image if needs be.

The default display of an image is `AspectFit`. It means that if the image is too big for its container, it will be scaled-down to fit it.

## Actvity Indicator

In XAML:

```xml
<ActivityIndicator IsRunning="true" Color="White" />
```

The activity indicator is displayed if the value of `IsRunning` is `true`.

```xml
<Image IsVisible="false" x:Name="image" />

<ActivityIndicator
	IsRunning="{Binding Source={x:Reference image}, Path=IsLoading}"
	Color="White" />
```

On the above example we did bind the display of the activity inidcator with the `IsLoading` property of the image. This value is `true` while loading the image and becomes `false` after it has.

## Embedded Images

To add images to PCL, we can add a folder to regroup images. Then <kbd>Add Files...</kbd>.

Define **Build Action** to **EmbeddedResource**. In VS, it is done from file properties. A **Resource ID** will automatically be generated. We can copy the value to be used in code. Either XAML or code-behind.

```csharp
image.Source = ImageSource.FromResource("ApplicationName.Folder.Filename.extension");
```

## Embedded image in XAML

Because `Source` property of an `<Image>` is interpreted as Uri, we cannot simply use an embedded resource such as images.

We need to create a markup extension to add this functionality.

Bellow is what we would like to use it.

```xml
<Image Source="{EmbeddedImage ResourceId=ApplicationName.Folder.Filename.extension}" />
```

For the sake of keeping things organized, we will add a folder for that matter.

We then need to create a class that implements `Xamarin.Forms.Xaml.IMarkupExtension`. Our custom properties in the XAML Markup Extension are actual properties in our new class. `[ContentProperty]` annotation takes a string that is the name of a *content property*. This results in `ResourceId` property becoming optional in XAML.

```csharp
[ContentProperty("ResourceId")]
public class EmbeddedImage : IMarkupextension {
	public string ResourceId {get;set;}

	public object ProvideValue(IServiceProvider serviceProvider){
		if (string.IsNullOrWhiteSpace(ResourceId))
			return null;

		return ResourceId;
	}
}
```

We shall also provide the relevant `xmlns` in the pages that need our newly made Markup Extension. For instance:

```xml
xmlns:xme="clr-namespace:application.namespace.MarkupExtension; assembly=AssemblyName"
```

`assembly` is needed only if it is in another assembly.

## Platform specific images

When we provide a different look and feel to repect guidelines that are platform specific, we need to use put images in their respective platform project.

We can simply call the image once it is available in expected location and naming convention.

```xml
<Image Source="image.png" />
```

Both iOS and Android are capable to load images in different resolution.

The convention for iOS is:
- An reference image say 32×32 image.png
- An image at twice the resolution, say 64×64 image@2x.png
- An image at trice the resolution, say 96×96 image@3x.png
- And so on...

Everything shall be put in the `Resources` folder.

The convention for Android is folders separated:
- drawable/ 32×32
- drawable-**hdpi**/ 48×48
- drawable-**xhdpi**/ 64×64
- drawable-**xxhdpi**/ 96×96

The filename is the same in each folder.

Naming restrictions for Android.	
Valid characters are:
- Lowercase letters
- Numbers
- Underscore
- Period

Convention in Windows is files go in the root folder by default, which is messy. this can be overriden by giving a `x:Name` to the target control so that we can go through code-behind an use OnPlatform to include the folder name.

```csharp
btn.Image = (FileImageSource)ImageSource.FromFile("image.png");


// With OnPlatfom
btn.Image = (FileImageSource)ImageSource.FromFile(Device.OnPlatform(
	iOS: "image.png,
	Android: "image.png,
	WinPhone: "Images/image.png"
));
```

In XAML we can use **Property Element Syntax**:

```xml
<Button>
	<Button.Image>
		<OnPlatfom> x:TypeArguments="FileImageSource" 
			Android="image.png"
			iOS="image.png"
			WinPhone="Images/image.png"
		/>
	</Button.Image>
</Button>
```

## Application Icon

For iOS, icons are in `info.plist` then `Universal icons`. Placeholders will be available to edit.

For Android, in project properties go to `Android Manifest` then there is an application icon drop down list.

For Windows, it is in file `Package.appxmanifest`. In `Visual assets` tab.

## Rounded images

The course claims we need to intall a NuGet package  `Xam.Plugins.Forms.ImageCircle` in platform projects. For each of them, there will be an extra setup.

### Setup of ImageCircle plugin.

For Android we need to edit `MainActivity.cs`. In the `OnCreate()` method, we need to add a line of code as bellow:

```csharp
using ImageCircle.Forms.Plugins.Droid

// ...

global::Xamarin.Forms.Forms.Init(this, bundle);
ImageCircleRenderer.Init();
```

In iOS we need to edit `AppDelegate.cs` file. In the `FinishedLaunching()` method we need to put a line of code after Xamarin.Forms init similar to what we did before.

```csharp
using ImageCircle.Forms.Plugins.iOS

//...

global::Xamarin.Forms.Forms.Init();
ImageCircleRenderer.Init();
```

Similarly in Windows, in the constructor of the `App.xaml.cs` file

```csharp
using ImageCircle.Forms.Plugin.UWP

// ...

Xamarin.Forms.Forms.Init(e);
ImageCircleRenderer.Init();
```

### Usage of ImageCircle

We first need to define an `xmlns` for ImageCircle:

```xml
xmlns:ic="clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin"
```

Then where needed, we can use our CircleImage component.

```xml
<ic:CircleImage
	WidthRequest="100"
	HeightRequest="100"
	Aspect="AspectFill"
	Source="https://domain/image.png"
/>
```

### Alternate way without plugins

I did not follow that and found an alternative way that takes a bit of markup but no plugin at all.

```xml
<Frame
	CornerRadius="100"
	IsClippedToBounds="True"
	Padding="0"
	WidthRequest="40"
	HeightRequest="40"
	HorizontalOptions="Start"
	>
	<Image 
		Aspect="AspectFill"
		Source="https://lh3.googleusercontent.com/GjSjkTmQYlCAUaGt7sub6APGlRbB0brk_xqXEI4L7owXqMBT8WJeDvNAuMK2GHBPZyG66caov8aj2rMEXeMwmOr7jH4CzD5pygQv5XCc=s660" />
</Frame>
```

## Dealing with Sizes

In Xamarin.Forms, when we provide integer value for anything related to dimensions or position, we are not using pixels. We use **Device-independent units**. Depending on the platform, the pixel can be 1 or more units.

The target would be 160 units for 1 inch.