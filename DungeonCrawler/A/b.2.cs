using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using wManager.Wow.Enums;
using wManager.Wow.Helpers;

namespace A
{
	// Token: 0x02000007 RID: 7
	internal static class b
	{
		// Token: 0x06000028 RID: 40 RVA: 0x0000ACD4 File Offset: 0x00008ED4
		public static int A(int int_0, int int_1, string string_0 = "")
		{
			int num = new Random().Next(int_0, int_1);
			Main.log(string.Format("Waiting {0}ms {1}", num, string_0));
			return num;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000AD08 File Offset: 0x00008F08
		public static void A(LuaEventsId luaEventsId_0, List<string> list_0)
		{
			b.A a = new b.A();
			a.A = list_0;
			if (luaEventsId_0 <= 271)
			{
				if (luaEventsId_0 <= 263)
				{
					if (luaEventsId_0 != 262)
					{
						if (luaEventsId_0 == 263)
						{
							Task.Delay(b.A(1000, 4000, "to complete votekick.")).ContinueWith(new Action<Task>(b.a.A.c));
							if (!string.IsNullOrWhiteSpace(DungeonCrawlerSettings.CurrentSetting.LeaderName) && a.A[0].ToLower() == DungeonCrawlerSettings.CurrentSetting.LeaderName.ToLower())
							{
								b.A(500, 3000, "before accepting party request.");
								Lua.LuaDoString("StaticPopup1Button1:Click()", false);
								Main.log("Party request accepted.");
							}
						}
					}
					else
					{
						Task.Delay(b.A(1000, 4000, "to complete votekick.")).ContinueWith(new Action<Task>(b.a.A.C));
						Main.log("Rezz request from '" + a.A[0] + "'.");
						if (Lua.LuaDoString<bool>("return StaticPopup1 and StaticPopup1:IsVisible();", ""))
						{
							b.A(500, 3000, "before accepting rezz.");
							Lua.LuaDoString("StaticPopup1Button1:Click()", false);
							Main.log("Rezz request accepted.");
						}
					}
				}
				else if (luaEventsId_0 != 270)
				{
					if (luaEventsId_0 == 271)
					{
						Task.Delay(b.A(200, 500, "to confirm soulbound equip.")).ContinueWith(new Action<Task>(b.a.A.b));
					}
				}
				else
				{
					Lua.LuaDoString("ConfirmLootSlot(1)", false);
				}
			}
			else if (luaEventsId_0 <= 473)
			{
				switch (luaEventsId_0)
				{
				case 442:
					Task.Delay(b.A(2000, 5000, "before rolling.")).ContinueWith(new Action<Task>(a.A));
					break;
				case 443:
				case 445:
					break;
				case 444:
					Task.Delay(b.A(200, 500, "to confirm soulbound roll.")).ContinueWith(new Action<Task>(a.a));
					break;
				case 446:
					Task.Delay(b.A(1000, 4000, "to complete votekick.")).ContinueWith(new Action<Task>(b.a.A.B));
					break;
				default:
					if (luaEventsId_0 == 473)
					{
						Task.Delay(b.A(500, 3000, "before accepting ready check.")).ContinueWith(new Action<Task>(a.B));
					}
					break;
				}
			}
			else if (luaEventsId_0 != 503)
			{
				if (luaEventsId_0 != 508)
				{
					if (luaEventsId_0 == 517)
					{
						e.A(true);
					}
				}
				else
				{
					Task.Delay(b.A(2000, 5000, "to complete rolecheck.")).ContinueWith(new Action<Task>(b.a.A.a));
				}
			}
			else
			{
				Task.Delay(b.A(2000, 5000, "until accepting proposal.")).ContinueWith(new Action<Task>(b.a.A.A));
			}
		}

		// Token: 0x02000008 RID: 8
		[CompilerGenerated]
		private sealed class A
		{
			// Token: 0x0600002B RID: 43 RVA: 0x0000B0B8 File Offset: 0x000092B8
			internal void A(Task task_0)
			{
				if (DungeonCrawlerSettings.CurrentSetting.AlwaysGreed)
				{
					Lua.LuaDoString("RollOnLoot(" + this.A[0].ToString() + ", 2)", false);
				}
				else
				{
					int num;
					if (!global::A.B.A(int.Parse(this.A[0])))
					{
						num = 2;
						Main.log("Rolling Greed.");
					}
					else
					{
						num = 1;
						Main.log("Rolling Need.");
					}
					Lua.LuaDoString(string.Concat(new string[]
					{
						"RollOnLoot(",
						this.A[0].ToString(),
						", ",
						num.ToString(),
						")"
					}), false);
				}
			}

			// Token: 0x0600002C RID: 44 RVA: 0x0000B174 File Offset: 0x00009374
			internal void a(Task task_0)
			{
				Lua.LuaDoString(string.Concat(new string[]
				{
					"ConfirmLootRoll(",
					this.A[0],
					",",
					this.A[1],
					")"
				}), false);
			}

			// Token: 0x0600002D RID: 45 RVA: 0x0000B1C8 File Offset: 0x000093C8
			internal void B(Task task_0)
			{
				Main.log("Ready check started by '" + this.A[0] + "'.");
				if (Lua.LuaDoString<bool>("return StaticPopup1 and StaticPopup1:IsVisible();", ""))
				{
					Lua.LuaDoString("StaticPopup1Button1:Click()", false);
					Main.log("Ready check accepted.");
				}
			}

			// Token: 0x0400001A RID: 26
			public List<string> A;
		}

		// Token: 0x02000009 RID: 9
		[CompilerGenerated]
		[Serializable]
		private sealed class a
		{
			// Token: 0x06000030 RID: 48 RVA: 0x0000B21C File Offset: 0x0000941C
			internal void A(Task task_0)
			{
				if (global::A.A.b())
				{
					e.A(false);
					e.a(null);
					Lua.LuaDoString("AcceptProposal()", false);
				}
				else
				{
					Lua.LuaDoString("RejectProposal()", false);
				}
			}

			// Token: 0x06000031 RID: 49 RVA: 0x0000B254 File Offset: 0x00009454
			internal void a(Task task_0)
			{
				if (global::A.A.b())
				{
					Lua.LuaDoString("CompleteLFGRoleCheck(true)", false);
				}
				else
				{
					Lua.LuaDoString("CompleteLFGRoleCheck(false)", false);
				}
			}

			// Token: 0x06000032 RID: 50 RVA: 0x000084B3 File Offset: 0x000066B3
			internal void B(Task task_0)
			{
				Lua.LuaDoString("SetLFGBootVote(true)", false);
			}

			// Token: 0x06000033 RID: 51 RVA: 0x000084C0 File Offset: 0x000066C0
			internal void b(Task task_0)
			{
				Lua.LuaDoString("ConfirmBindOnUse()", false);
			}

			// Token: 0x06000034 RID: 52 RVA: 0x000084B3 File Offset: 0x000066B3
			internal void C(Task task_0)
			{
				Lua.LuaDoString("SetLFGBootVote(true)", false);
			}

			// Token: 0x06000035 RID: 53 RVA: 0x000084B3 File Offset: 0x000066B3
			internal void c(Task task_0)
			{
				Lua.LuaDoString("SetLFGBootVote(true)", false);
			}

			// Token: 0x0400001B RID: 27
			public static readonly b.a A = new b.a();

			// Token: 0x0400001C RID: 28
			public static Action<Task> A;

			// Token: 0x0400001D RID: 29
			public static Action<Task> a;

			// Token: 0x0400001E RID: 30
			public static Action<Task> B;

			// Token: 0x0400001F RID: 31
			public static Action<Task> b;

			// Token: 0x04000020 RID: 32
			public static Action<Task> C;

			// Token: 0x04000021 RID: 33
			public static Action<Task> c;
		}
	}
}
