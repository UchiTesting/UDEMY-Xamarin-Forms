Layouts
=======

Xamarin.Forms provide a set of layouting elements to put elements in various places on the screen in different fashion.

It is perfectly acceptable to nest layouts into others for more complex layouts.


## Stack Layout

As its name implies, stacks children elements should it be horizontally or vertically. The default orientation is vertical. The can be changed by changing the `Orientation` property to `Horizontal`.

It fills the parent container by default. This can be superceded by setting the `VerticalOptions`/`HorizontalOptions` to anything else than `Fill`. Then the dimension is set by the sizes of its children. It also applies a little spacing between elements. This can be changed with the `Spacing` property being an integer value.

`Padding` is the surrounding space between `<StackLayout>` and its children. 

### Code-behind

Working with the UI in XAML should be preffered at most times. The exception to this is when we need to interact with it dynamically at runtime. Then, we need to work in code-behind.

```csharp
var layout = new StackLayout{
	Spacing = 40,
	Padding = new Thickness(0,20,0,0),
	Orientation = StackOrientation.Horizontal
}
```

We also can access children elements.

```csharp
layout.Children.Add(new Label { Text= "Label 1" });
```

Once initialized, we set the page `Content` property with our freshly made layout.

```csharp
Content = layout;
```