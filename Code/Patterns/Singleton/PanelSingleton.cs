using Sandbox;
using System.Collections.Generic;

namespace WackyLib.Patterns;

public abstract class PanelSingleton<T> : PanelComponent, IHotloadManaged where T : PanelSingleton<T>
{
#nullable enable
#pragma warning disable SB3000
	// ReSharper disable once MemberCanBePrivate.Global
	public static T? Instance { get; private set; }
#pragma warning restore SB3000

	protected override void OnAwake()
	{
		// We're running ExecuteInEditor, which means we should ignore instances.
		if ( ExecutingInEditor() )
		{
			Log.Warning( $"OnAwake called in editor with ExecuteInEditor, ignoring." );
			return;
		}

		if ( Instance.IsValid() )
		{
			Log.Warning( $"Singleton tried to initialize another {typeof(T)}!" );
			Destroy();
			return;
		}

		if ( Active )
		{
			Instance = (T)this;
		}
	}

	protected override void OnDestroy()
	{
		if ( Instance == this )
		{
			Instance = null;
		}
	}
	
	void IHotloadManaged.Destroyed( Dictionary<string, object> state )
	{
		state["IsActive"] = Instance == this;
	}

	void IHotloadManaged.Created( IReadOnlyDictionary<string, object> state )
	{
		if ( state.GetValueOrDefault( "IsActive" ) is true )
		{
			Instance = (T)this;
		}
	}
	
	private static bool ExecutingInEditor()
	{
		var executeInEditorDesc = TypeLibrary.GetType<ExecuteInEditor>();
		return executeInEditorDesc is not null && Game.IsEditor;
	}
}
