using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileApp.Droid.CustomRenderers.Effects;
using MobileApp.ViewControlEffects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName(TintImageEffect.GroupName)]
[assembly: ExportEffect(typeof(TintImageEffectRenderer), TintImageEffect.Name)]
namespace MobileApp.Droid.CustomRenderers.Effects
{
    public class TintImageEffectRenderer : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (ViewControlEffects.TintImageEffect)Element?.Effects?.FirstOrDefault(e => e is ViewControlEffects.TintImageEffect);

                if (effect == null || !(Control is ImageView image))
                {
                    return;
                }

                var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                image.SetColorFilter(filter);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"An error occurred when setting the {typeof(TintImageEffectRenderer)} effect: {ex.Message}\n{ex.StackTrace}");
            }
        }

        protected override void OnDetached() { }
    }
}