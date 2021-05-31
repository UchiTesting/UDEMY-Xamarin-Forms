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

## Simple Master Detail

## Master Detail

## Tabbed Page

## Carousel Page

## Pop-ups

## Toolbars