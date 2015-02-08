using System;
using CocosSharp;

namespace Aw
{
	public class HackGameDelegate : CCApplicationDelegate
	{
		public HackGameDelegate ()
		{

		}

		public override void ApplicationDidFinishLaunching (CCApplication application, CCWindow mainWindow)
		{

		}

		public override void ApplicationDidEnterBackground (CCApplication application)
		{
			application.Paused = true;
		}

		public override void ApplicationWillEnterForeground (CCApplication application)
		{
			application.Paused = false;
		}
	}
}

