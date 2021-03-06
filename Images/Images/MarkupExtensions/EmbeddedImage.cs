﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackLayoutEx1.MarkupExtensions
{
    [ContentProperty("ResourceId")]
    class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(ResourceId))
                return null;

            return ImageSource.FromResource(ResourceId);
        }
    }
}
