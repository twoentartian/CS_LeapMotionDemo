using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_LeapMotion
{
	class Env
	{
		public static bool NoConnectionWarnSign = false;

		public static string[] Ports;
		public static int NowPort;

		public const int MaxLoc = 1000;
		public const int MinLoc = -1000;

		public const char EndSign = (char) 0xFF;
		public const int SerialBufferLength = 4;
	}

	class State
	{
		public static bool Connection = false;
	}
}
