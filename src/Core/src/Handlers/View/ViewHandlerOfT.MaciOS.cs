using Microsoft.Maui;
using UIKit;

#if __IOS__ || IOS || MACCATALYST
using NativeColor = UIKit.UIColor;
#else
using NativeColor = AppKit.NSColor;
#endif

namespace Microsoft.Maui.Handlers
{
	public partial class ViewHandler<TVirtualView, TNativeView> : INativeViewHandler
	{
		UIView? INativeViewHandler.NativeView => (UIView?)base.NativeView;

		public override void SetFrame(Rectangle rect)
		{
			if (NativeView != null)
				NativeView.Frame = rect.ToCGRect();
		}

		public override Size GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			if (NativeView == null)
			{
				return new Size(widthConstraint, heightConstraint);
			}

			var sizeThatFits = NativeView.SizeThatFits(new CoreGraphics.CGSize((float)widthConstraint, (float)heightConstraint));

			var size = new Size(
				sizeThatFits.Width == float.PositiveInfinity ? double.PositiveInfinity : sizeThatFits.Width,
				sizeThatFits.Height == float.PositiveInfinity ? double.PositiveInfinity : sizeThatFits.Height);

			if (double.IsInfinity(size.Width) || double.IsInfinity(size.Height))
			{
				NativeView.SizeToFit();

				size = new Size(NativeView.Frame.Width, NativeView.Frame.Height);
			}

			return size;
		}

		protected override void SetupContainer()
		{
			var oldParent = NativeView?.Superview;
			ContainerView ??= new ContainerView();

			if (oldParent == ContainerView)
				return;

			ContainerView.MainView = NativeView;
		}

		protected override void RemoveContainer()
		{


		}
	}
}