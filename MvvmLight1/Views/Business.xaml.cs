using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MvvmLight1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Business : Page
    {
        private static int _persistedItemIndex = -1;

        public string ParallaxImage
        {
            get
            {
                return "imagesource";
            }
        }
        

        public Business()
        {
            this.InitializeComponent();
        }


        #region staggering
        private void HomeFeedGrid_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            args.ItemContainer.Loaded += ItemContainer_Loaded;
        }

        private void ItemContainer_Loaded(object sender, RoutedEventArgs e)
        {
            var itemsPanel = (ItemsStackPanel)this.HomeFeedGrid.ItemsPanelRoot;
            var itemContainer = (GridViewItem)sender;

            var itemIndex = this.HomeFeedGrid.IndexFromContainer(itemContainer);

            var relativeIndex = itemIndex - itemsPanel.FirstVisibleIndex;

            var uc = itemContainer.ContentTemplateRoot as Grid;

            if (itemIndex != _persistedItemIndex && itemIndex >= 0 && itemIndex >= itemsPanel.FirstVisibleIndex && itemIndex <= itemsPanel.LastVisibleIndex)
            {
                var itemVisual = ElementCompositionPreview.GetElementVisual(uc);
                ElementCompositionPreview.SetIsTranslationEnabled(uc, true);

                var easingFunction = Window.Current.Compositor.CreateCubicBezierEasingFunction(new Vector2(0.1f, 0.9f), new Vector2(0.2f, 1f));

                // Create KeyFrameAnimations
                var offsetAnimation = Window.Current.Compositor.CreateScalarKeyFrameAnimation();
                offsetAnimation.InsertKeyFrame(0f, 100);
                offsetAnimation.InsertKeyFrame(1f, 0, easingFunction);
                offsetAnimation.Target = "Translation.X";
                offsetAnimation.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
                offsetAnimation.Duration = TimeSpan.FromMilliseconds(700);
                offsetAnimation.DelayTime = TimeSpan.FromMilliseconds(relativeIndex * 100);

                var fadeAnimation = Window.Current.Compositor.CreateScalarKeyFrameAnimation();
                fadeAnimation.InsertExpressionKeyFrame(0f, "0");
                fadeAnimation.InsertExpressionKeyFrame(1f, "1");
                fadeAnimation.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
                fadeAnimation.Duration = TimeSpan.FromMilliseconds(700);
                fadeAnimation.DelayTime = TimeSpan.FromMilliseconds(relativeIndex * 100);

                // Start animations
                itemVisual.StartAnimation("Translation.X", offsetAnimation);
                itemVisual.StartAnimation("Opacity", fadeAnimation);
            }
          

            itemContainer.Loaded -= this.ItemContainer_Loaded;
        }

        #endregion

    }
}
