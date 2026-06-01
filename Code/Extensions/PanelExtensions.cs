using System;
using Sandbox.UI.Construct;

namespace Sandbox.UI;

public static class PanelExtensions
{
	extension( Panel panel )
	{
		/// <summary>
		/// Applies the "hidden" class, which presumably hides the panel somehow.
		/// </summary>
		public void Hide()
		{
			panel.AddClass( "hidden" );
		}
		
		/// <summary>
		/// Removes the "hidden" class, which presumably unhides the panel somehow.
		/// </summary>
		public void Show()
		{
			panel.RemoveClass( "hidden" );
		}
	}
}

public static class PanelComponentExtensions
{
	extension( PanelComponent component )
	{
		/// <summary>
		/// Applies the "hidden" class, which presumably hides the panel somehow.
		/// </summary>
		public void Hide()
		{
			component.Panel.Hide();
		}
		
		/// <summary>
		/// Removes the "hidden" class, which presumably unhides the panel somehow.
		/// </summary>
		public void Show()
		{
			component.Panel.Show();
		}
	}
}

public static class PanelCreatorExtensions
{
	extension( PanelCreator panelCreator )
	{
		public Button Button( string text, string icon, Action onClick )
		{
			var button = new Button( text, icon, onClick );
			return panelCreator.panel.AddChild( button );
		}
		
		public Button Button( string text, string icon, string className, Action onClick )
		{
			var button = new Button( text, icon, className, onClick );
			return panelCreator.panel.AddChild( button );
		}
	}
}
