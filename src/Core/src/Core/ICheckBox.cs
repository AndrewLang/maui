﻿namespace Microsoft.Maui
{
	/// <summary>
	/// Represents a View that is a type of button that can either be
	/// checked or empty.
	/// </summary>
	public interface ICheckBox : IView
	{
		/// <summary>
		/// Gets a value that ndicates whether the CheckBox is checked.
		/// </summary>
		bool IsChecked { get; set; }

		/// <summary>
		/// Gets the CheckBox Color.
		/// </summary>
		Color Color { get; }
	}
}