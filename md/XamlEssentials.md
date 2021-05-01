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

## Containers

There can be only one child in a page. Which means the content of the page must be surrounded by a unique element. This is the role of containers.

## Controls

 Most of the time controls shall be coded in XAML. They will be dealt with in C# source only when dynamic.

### Labels
`<Label Text="Label text as it shall appear./>"`

#### Attributes
- `Text` The actual text displayed.
- 

## Positionning

`VerticalOptions` and `HorizontalOptions` are attributes in XAML and properties in code-behind. give several values to position the control they are applied to.

- ``
- ``