XAML Essentials
===============

XAML is a XML based language that provides a mean to describe the UI. XAML is cleaner than C# code for that matter. XAML is converted to C# when compiled. In the `obj\Debug` folder, there will be `xaml.g.cs` files where g stand for "generated". This is a `partial` class and this is why code-behind is also `partial`. This generated code has the `InitializeComponent` and loads the UI from XAML
```csharp
private void InitializeComponent() {this.LoadFromXaml(typeof(MyPage));}
```
`MyPage` is the class name of the page.

1. At compile time XAML is embedded in the assembly.
2. At runtime, when `InitializeComponent()` is called the XAML file is extracted from assembly.
3. XAML file is passed to the XAML parser.
4. XAML parser create a C# source corresponding  to the XAML code.

## Accessing controls from code

3 ways : 
- Giving the controls a name in XAML with `x:Name` attribute.
- Working with events.
- Data Binding

XAML controls are initialised into the `InitializeComponent()` call. So any work with the control variables in the constructor shall be made after this method call.

## Data Binding

Values of attributes from XAML code are converted to a primitive type or object at runtime by an type converter. In case of Databinding, we cannot convert a string value to binding expression. This is why there is a special syntax for this. This is the purpose of **XAML Markup Expression** to tell the XAML parser it is not a simple string but an expression. It is done by putting curly braces into double quotes. Like `"{expression}"`

```xml
<Label Text="{Binding Source={x:Reference slider}, Path=Value, StringFormat='Value: {0:F2}'}" />
```

### Binding Context
When a control or a group of controls regularly use the same control as binding source, we can define the `BindingSource` attribute in XAML when available. 

```xml
<Label BindingContext="{x:Reference slider}"/>
```

In such case, the `Path` property is not necessary because the context has been defined.

## Device differences

Xamarin.Forms allows to share code for several target platforms. This is how to manage those differences when it comes to UI.
There is a `Device` type having an `OS` Property which is an enumeration of target platforms available. On iOS, we must usually add a 20 px padding on top of the screen.

```csharp
if (device.OS == TargetPLatform.iOS)
	Padding = new Thickness(0,20,0,0);
```

There is also the `OnPlatform()` method to write cleaner code should we do a check for several OS. It has both simple or generic versions.

```csharp
Padding = Device.OnPlatform<Thickness>(
	iOS: new Thickness(0,20,0,0),
	Android: new Thickness(10,20,0,0),
	WinPhone: new Thickness(30,20,0,0)
);
```

A variant of the above is to use the non-generic version to execute platform specific actions.

```csharp
Device.OnPlatform(
	iOS: () => { Padding = new Thickness(0,20,0,0); },
	Android: () => { // Android specific code... },
	WinPhone: () => { // Windows Phone specific code... }
);
```
### Property Element Syntax

We can also do Device specific XAML code. To get back to our 20 px on iOS, the `<ContentPage>` have a `Padding` attribute available. Should we need to do a platform specific action, `<OnPlatform>` is available with their respective attributes for each OS. The issue is we cannot feed the `Padding` attribute with XAML code as a value because they must be simple strings or XAML Markup Extensions.

This is solved using **Property Element Syntax-**. The content can remain a simple string, or become an XAML content.
```xaml
<ContentPage.Padding>
	<OnPlatform x:TypeArguments="Thickness"
		iOS="0, 20, 0, 0" />
</ContentPage.Padding>
```

We use Property Element Syntax when we are dealing with complex objects that cannot be represented using simple strings.

## XAML Compilation

XAML does not show errors in Visual Studio at compile time. This is because XAML compilation is disabled by default. This leads to situations where compilation went fine but there are runtime errors that could have been caught at compile time.

Benefits of XAML compilation:
- Catch errors at compile time.
- Reduced  assembly size because XAML is compiled to IL.
- Faster loading due to inherent optimisation.

XAML compilation is enabled by modifying `AssemblyInfo.cs` file.
Add in the file:

`[assembly: Xamarin.Forms.Xaml.XamlCompilation(XamlCompilationOptions.Compile)]`

This will apply XAML compilation for the whole assembly. Should we need to disable it for a specific file, we can add the following in its code-behind file.

```csharp
using Xamarin.Forms.Xaml

// Just above the class name
[XamlCompilation(XamlCompilationOptions.Skip)]
```

## Containers

There can be only one child in a page. Which means the content of the page must be surrounded by a unique element. This is the role of containers.

- `StackLayout`: Stacks the elements of the view one after the other vertically or horizontally.

## Controls

 Most of the time controls shall be coded in XAML. They will be dealt with in C# source only when dynamic.

More info about controls in [Controls.md](Controls.md)

## Positionning

`VerticalOptions` and `HorizontalOptions` are attributes in XAML and properties in code-behind. give several values to position the control they are applied to.

- `Start`
- `Center`
- `End`
- `Fill`
- ``

## Events
Visual Studio helps creating events from XAML code. It will create the new event in code-behind. Often the signature of that event handler will look like `ControlNameEventName(object sender, EventType e)`