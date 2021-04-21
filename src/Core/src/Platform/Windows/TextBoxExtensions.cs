namespace Microsoft.Maui
{
	public static class TextBoxExtensions
	{
		public static void UpdateText(this MauiTextBox textBox, IEntry entry)
		{
			textBox.Text = entry.Text;
		}

		public static void UpdateTextColor(this MauiTextBox textView, ITextStyle textStyle)
		{
			if (textStyle.TextColor == null)
				return;

			var brush = textStyle.TextColor.ToNative();
			textView.Foreground = brush;
			textView.ForegroundFocusBrush = brush;

		public static void UpdateIsPassword(this MauiTextBox textBox, IEntry entry)
		{
			textBox.IsPassword = entry.IsPassword;
		}
	}
}