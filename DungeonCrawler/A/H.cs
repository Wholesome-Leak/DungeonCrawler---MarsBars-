using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.FiniteStateMachine;
using wManager.Wow.Helpers;

namespace A
{
	// Token: 0x0200002D RID: 45
	internal class H : State
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00013A04 File Offset: 0x00011C04
		public override string DisplayName
		{
			get
			{
				return "dPartyInvites";
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00013A18 File Offset: 0x00011C18
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00008D0E File Offset: 0x00006F0E
		public override int Priority
		{
			get
			{
				return this.A;
			}
			set
			{
				this.A = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00013A30 File Offset: 0x00011C30
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause || DungeonCrawlerSettings.CurrentSetting.PlayersToInvite.Count == 0 || !DungeonCrawlerSettings.CurrentSetting.IsLeader || !DungeonCrawlerSettings.CurrentSetting.QueueGroup || C.a())
				{
					result = false;
				}
				else if (!Party.IsInGroup())
				{
					result = true;
				}
				else
				{
					using (List<string>.Enumerator enumerator = DungeonCrawlerSettings.CurrentSetting.PlayersToInvite.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							H.A a = new H.A();
							a.A = enumerator.Current;
							if (C.F().Count(new Func<string, bool>(a.A)) == 0)
							{
								return true;
							}
						}
					}
					result = false;
				}
				return result;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00013B00 File Offset: 0x00011D00
		public override void Run()
		{
			using (List<string>.Enumerator enumerator = DungeonCrawlerSettings.CurrentSetting.PlayersToInvite.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					H.a a = new H.a();
					a.A = enumerator.Current;
					if (!Party.IsInGroup())
					{
						Main.log("Inviting " + a.A + ".");
						Lua.LuaDoString("InviteUnit('" + a.A + "');", false);
					}
					else if (C.F().Count(new Func<string, bool>(a.A)) == 0)
					{
						Main.log("Inviting " + a.A + ".");
						Lua.LuaDoString("InviteUnit('" + a.A + "');", false);
					}
				}
			}
			Thread.Sleep(5000);
		}

		// Token: 0x040000CC RID: 204
		private int A;

		// Token: 0x0200002E RID: 46
		[CompilerGenerated]
		private sealed class A
		{
			// Token: 0x0600014F RID: 335 RVA: 0x00008D17 File Offset: 0x00006F17
			internal bool A(string string_0)
			{
				return string_0.ToLower() == this.A.ToLower();
			}

			// Token: 0x040000CD RID: 205
			public string A;
		}

		// Token: 0x0200002F RID: 47
		[CompilerGenerated]
		private sealed class a
		{
			// Token: 0x06000151 RID: 337 RVA: 0x00008D2F File Offset: 0x00006F2F
			internal bool A(string string_0)
			{
				return string_0.ToLower() == this.A.ToLower();
			}

			// Token: 0x040000CE RID: 206
			public string A;
		}
	}
}
