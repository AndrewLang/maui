﻿using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Maui.Controls.Sample.Models;
using Maui.Controls.Sample.ViewModels.Base;
using Maui.Controls.Sample.Pages;
using Maui.Controls.Sample.Services;

namespace Maui.Controls.Sample.ViewModels
{
    public class MainViewModel : BaseGalleryViewModel
	{
		readonly IConfiguration _configuration;
		readonly ITextService _textService;

		public MainViewModel(IConfiguration configuration, ITextService textService)
		{
			_configuration = configuration;
			_textService = textService;

			Debug.WriteLine($"Value from config: {_configuration["MyKey"]}");
			Debug.WriteLine($"Value from TextService: {_textService.GetText()}");
		}

		protected override IEnumerable<SectionModel> CreateItems() => new[]
		{
			new SectionModel(typeof(CorePage), "Core",
				"Application development fundamentals like Shell or Navigation."),

			new SectionModel(typeof(LayoutsPage), "Layouts",
				"Layouts are used to compose user-interface controls into visual structures."),

			new SectionModel(typeof(ControlsPage), "Controls",
				"Controls are the building blocks of cross-platform mobile user interfaces."),

			new SectionModel(typeof(UserInterfacePage), "User Interface Concepts",
				"User interface concepts like Animations, Colors, Fonts and more."),

			new SectionModel(typeof(OthersPage), "Others Concepts",
				"Other options like Graphics.")
		};
	}
}