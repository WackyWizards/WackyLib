global using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WackyLib.Tests;

[TestClass]
public class TestInit
{
	private static Sandbox.TestAppSystem s_appSystem;
	
	[AssemblyInitialize]
	public static void AssemblyInitialize( TestContext context )
	{
		s_appSystem = new Sandbox.TestAppSystem();
		s_appSystem.Init();
	}
	
	[AssemblyCleanup]
	public static void AssemblyCleanup()
	{
		s_appSystem.Shutdown();
	}
}
