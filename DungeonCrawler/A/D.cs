using System;
using wManager.Wow.Helpers;

namespace A
{
	// Token: 0x0200000F RID: 15
	internal static class D
	{
		// Token: 0x06000057 RID: 87 RVA: 0x0000BB48 File Offset: 0x00009D48
		public static bool A()
		{
			return Lua.LuaDoString<bool>("\r\n                    for i = 1,4 do\r\n                     if (UnitIsDeadOrGhost('party' .. i)) then\r\n                      return true\r\n                     end\r\n                    end\r\n                ", "");
		}
	}
}
