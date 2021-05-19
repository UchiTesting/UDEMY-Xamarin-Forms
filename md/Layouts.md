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

## Grid Layout

As the name implies the Grid layout allows to divide the available space in rows and columns.

It is represented by a `<Grid>` tag. Similarly to `<StackLayout>` it fills the available space. There is also a spacing between elements that can be overriden with attributes such as `RowSpacing` or `ColumnSpacing`.

We can define the grid layout as follows:

```xml
<Grid.RowDefinitions>
	<RowDefinition Height="2*"/>
	... any other row(s) ...
</Grid.RowDefinitions>
<Grid.ColumnDefinitions>
	<ColumnDefinition Width="*" />
	... any other column(s) ...
</Grid.ColumnDefinitions>
```

Each row of column ask for their respective height and width. They are usually set with integer values. They can also be given proportional values with `x*` where `x` is an integer above 0. Another option is to set the value to `Auto`, which means the dimension will be given the necessary space relative to their content.

Each child component of a grid can be assigned a row and column with `Grid.Row` and `Grid.Column` which are **Attached Bindable Properties**. They are not available from code-behind directly on the element (say a label so you can't do label.Row or label.Column). They are defined by the Grid class but can be set by other classes. The value is the zero-indexed number of the row/column.

We can also do row or column spanning with `Grid.RowSpan` or `Grid.ColumnSpan` which take an integer value.

### Code-behind

We can define a grid with its spacings in code-behind as follows.

```csharp
var grid = new Grid {
	RowSpacing = 20,
	ColumnSpacing = 40
};
```

Then we can add controls such as a label with the `Children` property.

```csharp

var label = new Label{Text="Label"};

grid.Children.Add(label, 0,0);
```

The `Grid` class provides static methods to place controls.

```csharp
Grid.SetRowSpan(label,2);
Grid.SetColumnSpan(label,2);
Grid.SetRow(label, 0);
Grid.SetColumn(label, 0);
```

Rows and column mays be define as follows:

```csharp
grid.RowDefinitions.Add(new RowDefinition{
	Height = new GridLength(100, GridUnitType.Absolute);
});

grid.RowDefinitions.Add(new RowDefinition{
	Height = new GridLength(2, GridUnitType.Star);
});

grid.RowDefinitions.Add(new RowDefinition{
	Height = new GridLength(1, GridUnitType.Star);
});

grid.ColumnDefinitions.Add( new ColumnDefinition{
	Width = new GridLength(1, GridUnitType.Auto);
});

grid.ColumnDefinitions.Add( new ColumnDefinition{
	Width = new GridLength(1, GridUnitType.Auto);
});
```

## Absolute Layout

Provides more control on the layout such as overlay and anchoring elements to borders. Its sizing may adapt to the device. As the previous layouts it fills its container.

Similar to `<Grid>` we are given Attached Bindable Properties. Each control into the layout can use them to define their aspect and position. 

First, there is `AbsoluteLayout.LayoutBounds`  which takes 4 numbers. Respectively x coordinate, y coordinate, width and height. They can be absolute or proportional values. Proportional values are represented by double values between 0 and 1.

Second there is `AbsoluteLayout.LayoutFlags` which is there to tell if any value provided to the previous property are proportional. It can take one of the following values or a comma separated combination of them:

| Value | Description |
|---|---|
| None | All values are absolute. |
| All | All values are proportional. |
| WidthProportional | Width (3rd value) is proportional |
| HeightProportional | Height (4th value) is proportional |
| XProportional | X coordinate (1st value) is proportional. |
| YProportional | Y coordinate (2nd value) is propotional. |
| PositionProportional | X and Y are proportional. |
| SizeProportional | Width and Height are proportional. |

Example of combination
```xml
<button Text="OK" 
	AbsoluteLayout.LayoutBounds="0,1,1,50"
	AbsoluteLayout.LayoutFlags="PositionProportional, WidthProportional"
	/>
```
A proportional value of 1 on the Y coordinate ensures the button is at the far bottom of the page.

### Code-behind

We set an absolute layout and a control for demonstration.

```csharp
var layout = new AbsoluteLayout();

var aquaBox = new BoxView{ Color=Color.Aqua };
```

Then we link the two as usual with the `Chidren` property. The `Add()` method takes the control to be added, a `Rectangle` object which parameters respect the order presented above (X, Y, Width, Height) and flags to define which values in the `Rectangle` object are proportional.

```csharp
layout.Children.Add(aquaBox, 
	new Rectangle(0,0,1,1),
	AbsoluteLayoutFlags.All);
```

We also have static method to redefine any of the bounds or flags at runtime.

```csharp
AbsoluteLayout.SetLayoutBounds(aquaBox, new Rectangle(0,0,1,1));
AbsoluteLayout.SetLayoutFlags(aquaBox, AbsoluteLayoutFlags.HeightProportional);
```

## Relative Layout

Similarly to Absolute Layout can overlay elements. Contraints can be based on another element. Gives more control about position and size of elements. 
Uses bindable properties:

- XConstraint
- YConstraint
- WidthConstraints
- HeightConstraints
- BoundsConstraints

Values are **constraint expression**.

```xml
<BoxView Color="Aqua" x:Name="banner"
	RelativeLayout.WidthConstraint="{ConstraintExpression 
		Type=RelativeToParent,
		Property=Width,
		Factor=1}"

	RelativeLayout.HeightConstraint="{ConstraintExpression
		Type=RelativeToParent,
		Property=Height,
		Factor=0.3	}"
/>

<BoxView Color="Silver"
	RelativeLayout.YConstraint="{ConstraintExpression
		Type=RelativeToView,
		ElementName=banner,
		Property=Height,
		Factor=1,
		Constant=20}"
/>
```

### Code-behind

```csharp
var layout = new relativeLayout();
var aquaBox = new BoxView {Color = Color.Aqua };

layout.Children.Add(aquaBox,
	widthConstraint: Constraint.RelativeToParent(parent => parent.Width),
	heightConstraint: Constraint.RelativeToParent(parent => parent.Height * 0.3));

var silverBox = new BoxView {Color = Color.Silver };

layout.Children.Add( silverBox,
	yConstraint: Constraint.RelativeToView(aquaBox, (RelativeLayout, element) => element.Height +20);
);
```