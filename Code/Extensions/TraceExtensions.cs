using System.Collections.Generic;

namespace Sandbox;

public static class TraceExtensions
{
	extension( SceneTrace trace )
	{
		/// <summary>
		/// Performs a ray trace along the given ray for the specified distance,
		/// returning only the first hit.
		/// </summary>
		/// <param name="ray">The ray to trace along.</param>
		/// <param name="distance">How far the ray should travel.</param>
		/// <param name="withTags">Optional tags to restrict the trace to objects that have any of these tags.</param>
		/// <returns>Result of the trace.</returns>
		public SceneTraceResult RunRayTrace( Ray ray, float distance = 100f, params string[] withTags )
		{
			return trace.Ray( ray, distance )
				.WithAnyTags( withTags )
				.Run();
		}
		
		/// <summary>
		/// Performs a ray trace along the given ray for the specified distance,
		/// returning all hits along the ray.
		/// </summary>
		/// <param name="ray">The ray to trace along.</param>
		/// <param name="distance">How far the ray should travel.</param>
		/// <param name="withTags">Optional tags to restrict the trace to objects that have any of these tags.</param>
		/// <returns>All results of the trace in order along the ray.</returns>
		public IEnumerable<SceneTraceResult> RunAllRayTrace( Ray ray, float distance = 100f, params string[] withTags )
		{
			return trace.Ray( ray, distance )
				.WithAnyTags( withTags )
				.RunAll();
		}
	}
}
