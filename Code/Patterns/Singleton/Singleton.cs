using Sandbox;
using System.Collections.Generic;

namespace WackyLib.Patterns;

/// <summary>
/// Represents a Singleton component. Which is a component that we can access through an instance, and only one can be allowed in a scene at once.
/// </summary>
public abstract class Singleton<T> : Component, IHotloadManaged where T : Singleton<T>
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
			Log.Info( $"OnAwake called in editor with ExecuteInEditor, creating once." );
			
			if ( Active )
			{
				Instance = (T)this;
			}
			
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
