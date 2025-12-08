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
			component.Panel.AddClass( "hidden" );
		}
		
		/// <summary>
		/// Removes the "hidden" class, which presumably unhides the panel somehow.
		/// </summary>
		public void Show()
		{
			component.Panel.RemoveClass( "hidden" );
		}
	}
}
