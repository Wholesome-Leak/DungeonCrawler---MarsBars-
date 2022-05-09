using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using wManager.Wow.Enums;
using wManager.Wow.Helpers;

namespace A
{
	// Token: 0x0200000A RID: 10
	internal static class C
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000084CD File Offset: 0x000066CD
		public static bool A()
		{
			return Lua.LuaDoString<bool>("return GetLFGDeserterExpiration() ~= nil or GetLFGRandomCooldownExpiration() ~= nil;", "");
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000084DE File Offset: 0x000066DE
		public static bool a()
		{
			return global::A.e.A.Count(new Func<Dungeon, bool>(global::A.C.A.A.A)) != 0;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000850C File Offset: 0x0000670C
		public static void B()
		{
			Lua.LuaDoString("LFGTeleport(false);", false);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00008519 File Offset: 0x00006719
		public static void b()
		{
			Lua.LuaDoString("LFGTeleport(true);", false);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000B280 File Offset: 0x00009480
		public static void A(LFGRole lfgrole_0)
		{
			switch (lfgrole_0)
			{
			case LFGRole.Tank:
				Lua.LuaDoString("SetLFGRoles(false, true, false, false)", false);
				break;
			case LFGRole.DPS:
				Lua.LuaDoString("SetLFGRoles(false, false, false, true)", false);
				break;
			case LFGRole.Heal:
				Lua.LuaDoString("SetLFGRoles(false, false, true, false)", false);
				break;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000ACD4 File Offset: 0x00008ED4
		public static int A(int int_0, int int_1, string string_0 = "")
		{
			int num = new Random().Next(int_0, int_1);
			Main.log(string.Format("Waiting {0}ms {1}", num, string_0));
			return num;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000B2CC File Offset: 0x000094CC
		public static void A(LuaEventsId luaEventsId_0, List<string> list_0)
		{
			C.a a = new C.a();
			a.A = list_0;
			if (luaEventsId_0 <= 271)
			{
				if (luaEventsId_0 <= 263)
				{
					if (luaEventsId_0 != 262)
					{
						if (luaEventsId_0 == 263)
						{
							Task.Delay(global::A.C.A(1000, 4000, "to complete votekick.")).ContinueWith(new Action<Task>(global::A.C.A.A.c));
							if (!string.IsNullOrWhiteSpace(DungeonCrawlerSettings.CurrentSetting.LeaderName) && a.A[0].ToLower() == DungeonCrawlerSettings.CurrentSetting.LeaderName.ToLower())
							{
								global::A.C.A(500, 3000, "before accepting party request.");
								Lua.LuaDoString("StaticPopup1Button1:Click()", false);
								Main.log("Party request accepted.");
							}
						}
					}
					else
					{
						Task.Delay(global::A.C.A(1000, 4000, "to complete votekick.")).ContinueWith(new Action<Task>(global::A.C.A.A.C));
						Main.log("Rezz request from '" + a.A[0] + "'.");
						if (Lua.LuaDoString<bool>("return StaticPopup1 and StaticPopup1:IsVisible();", ""))
						{
							global::A.C.A(500, 3000, "before accepting rezz.");
							Lua.LuaDoString("StaticPopup1Button1:Click()", false);
							Main.log("Rezz request accepted.");
						}
					}
				}
				else if (luaEventsId_0 != 270)
				{
					if (luaEventsId_0 == 271)
					{
						Task.Delay(global::A.C.A(200, 500, "to confirm soulbound equip.")).ContinueWith(new Action<Task>(global::A.C.A.A.b));
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
					Task.Delay(global::A.C.A(2000, 5000, "before rolling.")).ContinueWith(new Action<Task>(a.A));
					break;
				case 443:
				case 445:
					break;
				case 444:
					Task.Delay(global::A.C.A(200, 500, "to confirm soulbound roll.")).ContinueWith(new Action<Task>(a.a));
					break;
				case 446:
					Task.Delay(global::A.C.A(1000, 4000, "to complete votekick.")).ContinueWith(new Action<Task>(global::A.C.A.A.B));
					break;
				default:
					if (luaEventsId_0 == 473)
					{
						Task.Delay(global::A.C.A(500, 3000, "before accepting ready check.")).ContinueWith(new Action<Task>(a.B));
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
						global::A.e.A(true);
					}
				}
				else
				{
					Task.Delay(global::A.C.A(2000, 5000, "to complete rolecheck.")).ContinueWith(new Action<Task>(global::A.C.A.A.a));
				}
			}
			else
			{
				Task.Delay(global::A.C.A(2000, 5000, "until accepting proposal.")).ContinueWith(new Action<Task>(global::A.C.A.A.A));
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000B67C File Offset: 0x0000987C
		public static string C()
		{
			return Lua.LuaDoString<string>("mode, submode= GetLFGMode(); if mode == nil then return 'nil' else return mode end;", "");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000B69C File Offset: 0x0000989C
		public static void c()
		{
			if (!Lua.LuaDoString<bool>("return LFDQueueFrame: IsVisible()", ""))
			{
				Lua.RunMacroText("/lfd");
			}
			if (Lua.LuaDoString<bool>("return LFDQueueFrame: IsVisible()", "") && !Lua.LuaDoString<bool>("return LFDQueueFrameRandom: IsVisible()", ""))
			{
				Lua.LuaDoString("LFDQueueFrameTypeDropDownButton:Click(); DropDownList1Button2:Click()", false);
			}
			if (Lua.LuaDoString<bool>("return LFDQueueFrame: IsVisible()", "") && Lua.LuaDoString<bool>("return LFDQueueFrameRandom: IsVisible()", ""))
			{
				Lua.LuaDoString("LFDQueueFrameFindGroupButton:Click()", false);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000B72C File Offset: 0x0000992C
		public static void D()
		{
			if (!Lua.LuaDoString<bool>("return LFDQueueFrame: IsVisible()", ""))
			{
				Lua.RunMacroText("/lfd");
			}
			if (Lua.LuaDoString<bool>("return LFDQueueFrame: IsVisible()", "") && Lua.LuaDoString<bool>("return LFDQueueFrameRandom: IsVisible()", ""))
			{
				Lua.LuaDoString("LFDQueueFrameTypeDropDownButton:Click(); DropDownList1Button1:Click()", false);
			}
			if (Lua.LuaDoString<bool>("return LFDQueueFrame: IsVisible()", "") && !Lua.LuaDoString<bool>("return LFDQueueFrameRandom: IsVisible()", ""))
			{
				Lua.LuaDoString("\r\n                for i = 1, NUM_LFD_CHOICE_BUTTONS do\r\n                    local button = _G[\"LFDQueueFrameSpecificListButton\"..i];                                       \r\n                    LFDList_SetDungeonEnabled(button.id,false);\r\n                    LFDQueueFrameSpecificList_Update();                   \r\n                end\r\n                ", false);
				foreach (QueueDungeon queueDungeon in DungeonCrawlerSettings.CurrentSetting.SpecificDungeons.Where(new Func<QueueDungeon, bool>(global::A.C.A.A.A)))
				{
					Lua.LuaDoString(string.Format("LFDList_SetDungeonEnabled({0},true);\r\n                                         LFDQueueFrameSpecificList_Update();\r\n                                        ", queueDungeon.DungeonId), false);
				}
				Lua.LuaDoString("LFDQueueFrameFindGroupButton:Click()", false);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000B848 File Offset: 0x00009A48
		public static string d()
		{
			return Lua.LuaDoString<string>("\r\n                            for i = 1, 4 do \r\n                                local isTank,_,_ = UnitGroupRolesAssigned('party' .. i)\r\n                                if isTank then\r\n                                    name, realm = UnitName('party' .. i)\r\n                                    return name;\r\n                                end\r\n                            end", "");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000B868 File Offset: 0x00009A68
		public static string E()
		{
			return Lua.LuaDoString<string>("\r\n                            for i = 1, 4 do \r\n                                local isTank,isHeal,_ = UnitGroupRolesAssigned('party' .. i)\r\n                                if isHeal then                                    \r\n                                    name, realm = UnitName('party' .. i)\r\n                                    return name;\r\n                                end\r\n                            end", "");
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000B888 File Offset: 0x00009A88
		public static void e()
		{
			if (Lua.LuaDoString<bool>("is = IsInInstance()", "is") && global::A.C.C() == "abandonedInDungeon")
			{
				global::A.C.b();
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000B8C0 File Offset: 0x00009AC0
		public static List<string> F()
		{
			string text = Lua.LuaDoString<string>("\r\n                            plist='';\r\n                            for i=1,4 do\r\n                                if (UnitName('party'..i)) then\r\n                                    plist = plist .. UnitName('party'..i) ..','\r\n                                end\r\n                            end", "plist");
			return text.Remove(text.Length - 1, 1).Split(new char[]
			{
				','
			}).ToList<string>();
		}

		// Token: 0x0200000B RID: 11
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x06000046 RID: 70 RVA: 0x00008532 File Offset: 0x00006732
			internal bool A(Dungeon dungeon_0)
			{
				return dungeon_0.MapId == Usefuls.ContinentId;
			}

			// Token: 0x06000047 RID: 71 RVA: 0x0000B21C File Offset: 0x0000941C
			internal void A(Task task_0)
			{
				if (global::A.A.b())
				{
					global::A.e.A(false);
					global::A.e.a(null);
					Lua.LuaDoString("AcceptProposal()", false);
				}
				else
				{
					Lua.LuaDoString("RejectProposal()", false);
				}
			}

			// Token: 0x06000048 RID: 72 RVA: 0x0000B254 File Offset: 0x00009454
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

			// Token: 0x06000049 RID: 73 RVA: 0x000084B3 File Offset: 0x000066B3
			internal void B(Task task_0)
			{
				Lua.LuaDoString("SetLFGBootVote(true)", false);
			}

			// Token: 0x0600004A RID: 74 RVA: 0x000084C0 File Offset: 0x000066C0
			internal void b(Task task_0)
			{
				Lua.LuaDoString("ConfirmBindOnUse()", false);
			}

			// Token: 0x0600004B RID: 75 RVA: 0x000084B3 File Offset: 0x000066B3
			internal void C(Task task_0)
			{
				Lua.LuaDoString("SetLFGBootVote(true)", false);
			}

			// Token: 0x0600004C RID: 76 RVA: 0x000084B3 File Offset: 0x000066B3
			internal void c(Task task_0)
			{
				Lua.LuaDoString("SetLFGBootVote(true)", false);
			}

			// Token: 0x0600004D RID: 77 RVA: 0x00008541 File Offset: 0x00006741
			internal bool A(QueueDungeon queueDungeon_0)
			{
				return queueDungeon_0.Enabled && queueDungeon_0.DungeonId > 0;
			}

			// Token: 0x04000022 RID: 34
			public static readonly C.A A = new C.A();

			// Token: 0x04000023 RID: 35
			public static Func<Dungeon, bool> A;

			// Token: 0x04000024 RID: 36
			public static Action<Task> A;

			// Token: 0x04000025 RID: 37
			public static Action<Task> a;

			// Token: 0x04000026 RID: 38
			public static Action<Task> B;

			// Token: 0x04000027 RID: 39
			public static Action<Task> b;

			// Token: 0x04000028 RID: 40
			public static Action<Task> C;

			// Token: 0x04000029 RID: 41
			public static Action<Task> c;

			// Token: 0x0400002A RID: 42
			public static Func<QueueDungeon, bool> A;
		}

		// Token: 0x0200000C RID: 12
		[CompilerGenerated]
		private sealed class a
		{
			// Token: 0x0600004F RID: 79 RVA: 0x0000B904 File Offset: 0x00009B04
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

			// Token: 0x06000050 RID: 80 RVA: 0x0000B9C0 File Offset: 0x00009BC0
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

			// Token: 0x06000051 RID: 81 RVA: 0x0000BA14 File Offset: 0x00009C14
			internal void B(Task task_0)
			{
				Main.log("Ready check started by '" + this.A[0] + "'.");
				if (Lua.LuaDoString<bool>("return StaticPopup1 and StaticPopup1:IsVisible();", ""))
				{
					Lua.LuaDoString("StaticPopup1Button1:Click()", false);
					Main.log("Ready check accepted.");
				}
			}

			// Token: 0x0400002B RID: 43
			public List<string> A;
		}
	}
}
