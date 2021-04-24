Getting Started
===============

## What is Xamarin.Forms

A library that enables to build native apps for Android, iOS and Windows. Using mostly a common code-base.

Each view is separated in 2 parts:
- XAML code which is XML based and allows to describe the interface.
- Code-behind which is an associated source in C# allowing to code the behaviour.

## Architecture I

Xamarin.Forms

Xamarin.Android Xamarin.iOS

Xamarin.Forms is unified and will map to the respective native equivalent.

You need a mac to develop for iOS.

| Coding Machine | Android | iOS | Windows |
|---|---|---|---|
| Windows | × | | × |
| Mac | × | × |  |

## Setup Environment

Visual Studio Installer comes with all needed to develop mobile apps with Xamarin.

Project types:
- PCL (Portable Class Library) is recommended
- SAP (Shared Asset Projects)

|| PCL | SAP |
|---|---|---|
|| Bundled in a DLL references by platform specific projects | Not into a separate class library even-though it looks otherwise in VS. Code is included in each version at  build time. |
|Platform specific code | Use Device class | Use preprocessor directives |

A Xamarin.Forms solution comes in several projects. One per target platform and PCL.
Each project can safely be deleted if not needed. They can be created anytime later if needs be.

## XAML

XML based file. 1 root element. It hax `xmlns` declarations related to XAML in it.

Namespaces:
- prefixless is for Xamarin and contains the XAML elements available.
- x: Extensions by Microsoft.

Always contains an attribute `x:Class="Class.Name"` that refers to the related code-behind. VS uses it to swap when using shortcuts such as <kbd>F7</kbd> or <kbd>Shift</kbd> +<kbd>F7</kbd>.

Page types:
- Content
- MasterDetail
- Navigation
- Carousel

File `App.xaml.cs` allows to set which class is the main view. This is how we can move the default template view in a proper folder if we want to, or add Navigation.

## Architecture II

  > All the libraries are build on top of Mono
![Architecture 01](img/Architecture_01.png)

> Technologies renamed. Give access to .NET base library.
![Architecture 01](img/Architecture_02.png)

They also give acces to respective native API.

### Xamarin.Android

C# ► compiled to IL + Bundled bith `Mono runtime` (similar to CLR).

On launching android app:

runtime is loaded to memory → Gets IL Code → JIT compilation to native code.

### Xamarin.iOS

Apple does not allow JIT.

C# ► compiled to IL → AOT compilation to native code.

### Xamarin Forms

Build on top of the previous 2. `Xamarin.Forms.Core` namespace is common unified API to work with different platforms. In each platform specific project there is a reference to it. In Andoid we also have `Xamarin.Forms.Platform.Android` which has the necessary to do the mapping between Xamarin Forms controls to native controls. Also contain renderers for these controls. In iOS we have `Xamarin.Forms.Platform.iOS` that has the same responsibilities.