using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FormsAnimations
{
  public class App
  {
    public static Page GetMainPage()
    {
      var contentPage = new ContentPage();
      contentPage.Title = "Fun animations!";

      var button = new Button
      {
        Text = "Animate"
      };

      var box = new BoxView
      {
        WidthRequest = 100,
        HeightRequest = 100,
        Color = Color.Red,
        HorizontalOptions = LayoutOptions.Center
      };


      var stack = new StackLayout
      {
        Padding = 10,
        Spacing = 10,
        VerticalOptions = LayoutOptions.FillAndExpand,
        Children = { button, box }
      };

      button.Clicked += async (sender, args) =>
      {
        button.IsEnabled = false;

        box.Color = Color.Green;

        var originalPosition = box.Bounds;
        var newPosition = box.Bounds;
        newPosition.Y = contentPage.Height - box.Height;

        await box.LayoutTo(newPosition, 2000, Easing.BounceOut);

        box.FadeTo(0, 2000);
        box.Color = Color.Yellow;

        await box.ScaleTo(2, 2000);

        box.FadeTo(1, 2000);
        await box.ScaleTo(1, 2000);

        box.Color = Color.Green;

        await box.LayoutTo(originalPosition, 2000, Easing.Linear);

        box.Color = Color.Red;
        button.IsEnabled = true;

      };



      contentPage.Content = stack;
      return new NavigationPage(contentPage);
    }
  }
}
