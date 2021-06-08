Navigation
==========

## Hierarchical Navigation

Represent as a view with a top section having an optional title and navigation options. It has a stack structure kind of like the navigation of web pages. The page on top is the *active page*.

A setup at application level is made by wrapping the main page into a NavigationPage in `App.xaml.cs`.

```csharp
public App(){
	InitializeComponent();

	MainPage = new NavigationPage(new WelcomePage());
}
```

`ContentPage` has `Navigation` property of type `INavigation`.

Going to another page : `Navigation.PushAsync(Page page)`.

```csharp
await Navigation.PushAsync(new MyPage());
```

The OS have the necessary to go back in the navigation, but it can be handled programmatically with `Navigation.PopAsync()`.

```csharp
await Navigation.PopAsync();
```

Bindable properties allow us to act on the look and feel.

Removing the navigation bar can be done in XAML as follows:

`NavigationPage.HasNavigationBar="false"`

It must be done on every page explicitely where needed. Otherwise there will be a navigation bar on some pages.

In the `App` class we can change text and background color:

```csharp
public App(){
	InitializeComponent();

	MainPage = new NavigationPage(new WelcomPage()){
		BarBackgroundColor = Color.Silver,
		BarTextColor = Color.Red;
	};
}
```

Hiding the back button from navigation bar in XAML:

`NavigationPage.HasBackButton="false"`

This is cosmetic only. Android and Windows have Back button at the OS level. To prevent its usage we need to override `OnBackButtonPressed()` event handler to return `true`.

```csharp
protected override bool OnBackButtonPressed(){
	return true;
}
```

## Modal pages

Modal pages are pages that the user cannot remove outside of the planned ways.
The navigation bar is no more. Therefore we need to dev a button explicitely to exit it.

```csharp
await Navigation.PushModalAsync();
```

Goes along with `PopModalAsync()` and `OnBackButtonPressed` disabled.

## Simple Master Detail

This is made out of classic views. One holding a `<ListView>` in which we handle the `ItemSelected` event to display the correct page.	

The problem that occurs is we need to pass the selected item to the view.

Several ways:
- Use a constructor that takes the selected Item. `new TargetPage(content)`
- Use a property that is set inline. `new TargetPage{Content = content}`
- Set the binding context inline. `new TargetPage{BindingContext = content}`

The best option is constructor. The other options are poor from OOP perspective. The target page does not hold the passed element so it should be provided at initialisation. Hence method one via constructors.

On the target page we shall check the argument is not null or `throw new ArgumentNullException()`.

At `App.cs` it needs `NavigationPage` use.

```csharp
async void Handle_SelectedItem(object sender, SelectedItemChanged e){
	if (e.SelectedItem is null) return; // The last satement sets SelectedItem to null. But retriggers the event. This prevents unexpected behaviours such as loops.

	var data = e.SelectedItem as TargetType;
	await Navigation.PushAsync(new TargetPage(data));
	listView.SelectedItem = null // This is because when we come back the last selected item is still selected. So this acts as a reset.
	
	
}
```

## Master Detail

Xamarin have a specific `MasterDetailPage` that is visually a bit different from the previous implementation.
On Mobile it shows a preview (a few pixels in width available on the screen) before showing the full detail page. On tablet, the screen is wide enough to display the full detail page. Hence it looks like tabs on the left-hand border.

`MasterDetailPage` has 2 properties of type `Page` letting it set the `Master` and `Detail` pages to be displayed.

Master can be set using PES (Property Element Syntax) so that there is no extra page to deal with.

The detail page though will be likely set dynamically and therefore dealt with in the code-behind. It cannot be empty though so  in XAML it must be set to an empty `ContentPage`. Also it should be wrapped into a `NavigationPage` for it has no mechanism to browse back by default.

```xml
<MasterDetailPage>
<MasterDetailPage.Master>
</MasterDetailPage.Master>
<MasterDetailPage.Detail>
	<ContentPage />
</MasterDetailPage.Detail>
</MasterDetailPage>
```

```csharp
async void Handle_SelectedItem(object sender, SelectedItemChanged e){
	var data = e.SelectedItem as TargetType;
	Detail = new TargetPage(data);	
	IsPresented = false;
}
```
`IsPresented` allows to hide the Master part of the view when an item has been selected when set to `false`. In XAML however it shall be set to `true`.

## Tabbed Page

It has a `Children` property of type `IList<Page>` to which we can add.

In XAML we can put the code directly in the source.

```xml
<TabbedPage>
	<ContentPage Title="TabTitle" Icon="Image.png">
	 Markup Here
	</ContentPage>
</TabbedPage>
```

It takes a `Title` and `Icon`. The latter shall be 30×30 pixels.

Pages displayed as tabs are likely to be complex enough to benefit from being in their own source files. So instead of doing the above, we can just reference the pages to display.

This means putting an `xmlns` reference to the namespace where pages are located.

> In that matter I love to put Pages in a folder called `Views` and name the `xmlns` **v** or **views**.  
> One of the first things I do when I start a XAML project is to move the main page to that folder and update `App.cs` with the correct reference.

```xml
<TabbedPage 
	xmlns:v="clr-namespace:Proper.Namespace.Views">
	<v:ContentPage Title="TabTitle" Icon="Image.png" />
	<v:AnotherContentPage Title="Another" Icon="Another.png" />
</TabbedPage>
```

Should we wish to wrap a content page in `NavigationPage` from XAML, we would get an error if we'd simply do it. This is because it needs a root page to display.  In C# code we pass that page as an argument.

```xml
<TabbedPage 
	xmlns:v="clr-namespace:Proper.Namespace.Views">
	<NavigationPage Title="TabTitle" Icon="Image.png">
		<x:Arguments>
			<v:ContentPage />
		<x:Arguments>
	</NavigationPage>
	<v:AnotherContentPage Title="Another" Icon="Another.png" />
</TabbedPage>
```

> We shall not forget that it is the `NavigationPage that shall be set the `Title` and `Icon` properties.

## Carousel Page

## Pop-ups

## Toolbars