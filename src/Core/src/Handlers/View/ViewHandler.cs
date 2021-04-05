#if __IOS__
using NativeView = UIKit.UIView;
#elif __MACOS__
using NativeView = AppKit.NSView;
#elif MONOANDROID
using NativeView = Android.Views.View;
#elif WINDOWS
using NativeView = Microsoft.UI.Xaml.FrameworkElement;
#elif NETSTANDARD
using NativeView = System.Object;
#endif

namespace Microsoft.Maui.Handlers
{
	public partial class ViewHandler
	{
		public static PropertyMapper<IView> ViewMapper = new PropertyMapper<IView>
		{
			[nameof(IView.BackgroundColor)] = MapBackgroundColor,
			[nameof(IView.BorderColor)] = MapBorderColor,
			[nameof(IView.BorderWidth)] = MapBorderWidth,
			[nameof(IView.CornerRadius)] = MapCornerRadius,
			[nameof(IView.Frame)] = MapFrame,
			[nameof(IView.IsEnabled)] = MapIsEnabled,
			[nameof(IView.AutomationId)] = MapAutomationId
		};

		public static void MapBackgroundColor(IViewHandler handler, IView view)
		{
			(handler.NativeView as NativeView)?.UpdateBackgroundColor(view);
		}

		public static void MapBorderColor(IViewHandler handler, IView view)
		{
			(handler.NativeView as NativeView)?.UpdateBorderColor(view);
		}

		public static void MapBorderWidth(IViewHandler handler, IView view)
		{
			(handler.NativeView as NativeView)?.UpdateBorderWidth(view);
		}

		public static void MapCornerRadius(IViewHandler handler, IView view)
		{
			(handler.NativeView as NativeView)?.UpdateCornerRadius(view);
		}

		public static void MapFrame(IViewHandler handler, IView view)
		{
			handler.SetFrame(view.Frame);
		}

		public static void MapIsEnabled(IViewHandler handler, IView view)
		{
			(handler.NativeView as NativeView)?.UpdateIsEnabled(view);
		}

		public static void MapAutomationId(IViewHandler handler, IView view)
		{
			(handler.NativeView as NativeView)?.UpdateAutomationId(view);
		}
	}
}