Lists
=====

## Populating a basic list

In XAML:

```xml
<ListView x:Name="listView"
	SeparatorVisibility="None"
	SeparatorColor="Silver"
/>
```

In Xamarin XAML, A list  control is made using the `<ListView>` tag. It displays a separator between each element. Its visibility and color can be modified with `SeparatorVisibility` and `SeparatorColor` properties.

In code-behind:

```csharp
var names = new List<string>{
	"Mosh",
	"John",
	"Bob"
}

listView.ItemSource = names;
```

We take advantage of the `x:Name` we gave our `<ListView>` to populate it in code behind. Setting the content is as simple as passing a list of items to the `ItemSource` property.

## Cell Appearance

In real world scenario, lists would actually display complex content. List items can be selected. We can then retrieve them with `SelectedItem` which provides an instance of the type linked to the `ItemSource`.

For Instance, in the example from the previous section, selecting an item would return a `string`. But any type can be retrieved. We can therefore use a complex type to display the whole or a part of its properties.

Let's consider, we want to display a list of `Contact` items.

```csharp
public class Contact{
	public string Name { get; set; }
	public string Status { get; set; }
	public string ImageUrl { get; set; }
}
```

We will bind the `ItemSource` directly in code behind

```csharp
listView.ItemSource = new List<Contact>{
	new Contact{Name="Mosh", ImageUrl="https://lorempixel.com/100/100/people/1"},
	new Contact{Name="John", Status="Let's talk.", ImageUrl="https://lorempixel.com/100/100/people/2"},
	new Contact{Name="Bob", ImageUrl="https://lorempixel.com/100/100/people/3"}
}
```

The result is displaying the full qualified name of the type used. Likely `AppName.Contact`. This is because it renders from the `ToString()` which returns that by default. One option would be to override that method so it displays the fields we want. As its signature implies, it can only return a `string` though.

We are heading toward a more complex representation of our type. With an avatar and other informations displayed.

To that matter we can use XAML **Property Element Syntax** (PES).

Our previous `<ListView>` will be rewritten as follows:

```xml
<ListView>
	<ListView.ItemTemplate>
		<DataTemplate>
			<ImageCell Text="{Binding Name}" Detail="{Binding Status}" ImageSource="{Binding ImageUrl}" />
		</DataTemplate>
	</ListView.ItemTemplate>
</ListView>
```

Using PES as stated before, we will describe the `ItemTemplate` property. It will take a `<DataTemplate>` element in which the description for each list item will be written.

We have 2 ways to proceed:
- Use available items such as:
  - `TextCell` with properties:
	 - `Text`
	 - `Detail`
  - `ImageCell` with properties:
	 - `Text`
	 - `Detail`
	 - `ImageSource`
- Completely control the display with `ViewCell`.

Each Contact object will be the binding context for their respective item in the list. This allow us not to precise the `Source` property in the **XAML Markup Expression** and simply provide the property name we're after.

## Custom Cells

As mentioned before, we can customise the rendering of a list item with `<ViewCell>`. As the name implies it is taking a view, so anything related to a view will be OK. It is often begun with a layout element such as `<StackLayout>` for instance. This is because we most likely need to describe multiple elements.

```xml
<ViewCell>
	<StackLayout Orientation="Horizontal" Padding="5" >
		<Image Source="{Binding ImageUrl}" />
		<StackLayout HorizontalOptions="StartAndExpand">
			<Label Text="{Binding Name}" />
			<Label Text="{Binding Status}" Color="Silver" />
		</StackLayout>
		<Button Text="Follow" />
	</StackLayout>
</ViewCell>
```

> Note: On custom views, each line has the same height by default. This can result in bad display should there be several elements that share the height of the list item. To solve this issue, set `HasUnevenRows` to `true` on the `<ListView>`. This forces to adapt the height of the list item to its content.

## Grouping Items

In XAML `<ListView>` needs `IsGroupingEnabled` set to `true` , `GroupDisplayBinding` and `GroupShortNameBinding` set to their respective display text.

A good solution to handle that is create a type that is a list of the type we group. In our example, a `List<Contact>`.

```csharp
public class ContactGroup : List<Contact>{

	public string Title { get; set; }
	public string ShortTitle { get; set; }

	ContactGroup(string title, string shortTitle){
		Title = title;
		ShortTitle = shortTitle;
	}
}
```

Then we redefine the list `ItemSource` as follows:

```csharp
listView.ItemSource = new List<ContactGroupt>{
	new ContactGroup("B","B") {
		new Contact{Name="Bob", ImageUrl="https://lorempixel.com/100/100/people/3" }
	}
	new ContactGroup("J","J") {
		new Contact{Name="John", Status="Let's talk.", ImageUrl="https://lorempixel.com/100/100/people/2" },
	}
	new ContactGroup("M","M") {
		new Contact{Name="Mosh", ImageUrl="https://lorempixel.com/100/100/people/1" },
	}
}
```

We can finally do the setup we brought up earlier in XAML.

```xml
<ListView x:Name="listView"
	IsGroupingEnabled="true"
	GroupDisplayBinding="{Binding Title}"
	GroupShortNameBinding="{Binding ShortTitle}"
/>
```

`GroupDisplayBinding` and `GroupShortNameBinding` are now bound to properties in our `ContactGroup` items.

## Handling selection

This is done by implementing `ItemTapped` and `ItemSelected` events.

```xml
<ListView x:Name="listView"
	ItemTapped="Handle_ItemTapped"
	ItemSelected="Handle_ItemSelected"
/>
```

VS would generate Default event handlers in code-behind upon typing in XAML code editor.

```csharp
void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e){
	
void Handle_ItemSelected(object sender, Xamarin.Forms.ItemSelectedEventArgs e){
}
```

In those event handlers the `e` argument provide information about the selected item. Its most important property is `SelectedItem` or `Item` which returns an instance of the item respectively for `ItemSelected` and `ItemTapped`. In our example, we would likely work with that instance with such line:

```csharp
// In ItemSelected
var contact = e.SelectedItem as Contact;
// In ItemTapped
var contact = e.Item as Contact;
```

The default behaviour is when an item is selected in the list only `ItemSelected` gets fired. Then any further tap on that Item will fire `ItemTapped`. We can disable `ItemSelected` event by setting the `SelectedItem` to `null` on the list view. Then The fired event is directly `ItemTapped`. This will also remove the selected item color.

```csharp
void Handle_ItemSelected(object sender, Xamarin.Forms.ItemSelectedEventArgs e){
	listView.SelectedItem = null.
}
```

## Context Actions

These are commands we can see when swiping on a list view item.

We can implement them in XAML using **[PES](# "Property Element Syntax")** in a Cell to define `ContextActions`.

```xml
<TextCell>
	<TextCell.ContextActions>
		<MenuItem Text="Call" Clicked="Call_Clicked" CommandParameter="{Binding .}">
		<MenuItem Text="Delete" Clicked="Delete_Clicked" IsDestructive="true" CommandParameter="{Binding .}">
	</TextCell.ContextActions>
</TextCell>
```
> `{Binding .}` refers to the entire binding context which means a Contact in our example.

Then we can define several `<MenuItem>` elements. Some of the most useful attributes are:
- `Text` to set the display text on the menu item.
- `Clicked` to set a click event handler.
- `CommandParameter` to pass further data to the event.
- `IsDestructive` applies a special formatting to distinguish destructive operations such as deleting an item.

Lest have a closer look at event handlers.

```csharp
void Call_Clicked(object sender, System.EventArgs e){}
void Delete_Clicked(object sender, System.EventArgs e){}
```

Unlike before `EventArgs` does not carry any information about the selected item. That said `sender` refers to our `<MenuItem>`.

```csharp
void Call_Clicked(object sender, System.EventArgs e){
	var menuItem = sender as MenuItem;
	var contact = menuItem.CommandParameter as Contact;

	// Or in a single line
	var menuItem = (sender as MenuItem).CommandParameter as Contact;

	// ... Do Anything ...
}
```

> We used a `List<Contact>` to work with our list. Adding or Removing to that list would not update the view. When working with `<ListView>`, we should work with `ObservableCollection<T>` instead.

## Pull to refresh

Lists can often be updated by pulling them down.

In XAML We shall define the `IsPullToRefreshEnabled` and `Refreshing` attributes respectively with a boolean value and an event handler.

```xml
<ListView x:Name="listView"
	IsPullToRefreshEnabled="true"
	Refreshing="Handle_Refreshing"
/>
```

It is important to signify we finished our refreshing process. Otherwise, upon pulling down our list so that it refreshes, the activity indicator that appears, neverendlessly circles.

```csharp
void Handle_Refreshing(object sender, EventArgs e){
	listView.ItemsSource = GetContacts();
	// Stating update is over
	// 1st way
	listView.IsRefreshing = false;
	// 2nd way
	listView.EndRefresh(); // Does the same as above
}
```

## Search bar

It is simply done by using the `<SearchBar>` element in XAML.
This element has several interesting attributes:
- `Placeholder` is the text displayed when the search input is empty. It should provide some directions on what to input.
- `TextChanged` is the main event we would like to interract with.
- `SearchButtonPressed` is an event handler to do the search only upon manual pressure on a button.

Here is a method that provides data.

```csharp
IEnumerable<Contact> GetContacts(string searchText = null){
	var contacts = // Any list of contact initialized

	if (string.IsNullOrWhiteSpace(searchText)) return contacts;

	return contacts.Where(c => c.Name.Contains(searchText));
}
```

Our `TextChangedEventArgs` provides us with both self-explanatory properties `OldTextValue` and `NewTextValue`.

```csharp
void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e){
	listView.ItemsSource = GetContacts(e.NewTextValue);
}
```