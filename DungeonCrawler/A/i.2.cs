using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000036 RID: 54
	internal class i : State
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000173 RID: 371 RVA: 0x000141CC File Offset: 0x000123CC
		public override string DisplayName
		{
			get
			{
				return "dGetFollowTarget";
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000174 RID: 372 RVA: 0x000141E0 File Offset: 0x000123E0
		// (set) Token: 0x06000175 RID: 373 RVA: 0x00008DCB File Offset: 0x00006FCB
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

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000176 RID: 374 RVA: 0x000141F8 File Offset: 0x000123F8
		public override bool NeedToRun
		{
			get
			{
				return Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause && i.A.IsInParty && C.a() && this.A.IsReady;
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00014238 File Offset: 0x00012438
		public override void Run()
		{
			i.A a = new i.A();
			if (e.a() == null)
			{
				e.A();
			}
			this.A = new Timer(10000.0);
			a.A = C.E().Replace("#||#", "");
			if (!string.IsNullOrWhiteSpace(a.A))
			{
				Main.logDebug("Setting lfgHealer to '" + a.A + "'", false);
				global::A.A.a(Party.GetPartyHomeAndInstance().FirstOrDefault(new Func<WoWPlayer, bool>(a.A)));
			}
			if (!string.IsNullOrWhiteSpace(DungeonCrawlerSettings.CurrentSetting.FollowOverrideName))
			{
				Main.logDebug("Setting followTarget to OverrideName", false);
				global::A.A.A(ObjectManager.GetObjectWoWUnit().Where(new Func<WoWUnit, bool>(i.a.A.A)).FirstOrDefault<WoWUnit>());
			}
			a.a = C.d().Replace("#||#", "");
			if (!string.IsNullOrWhiteSpace(a.a))
			{
				Main.logDebug("Setting followTarget to '" + a.a + "'", false);
				global::A.A.A(Party.GetPartyHomeAndInstance().FirstOrDefault(new Func<WoWPlayer, bool>(a.a)));
			}
			else
			{
				WoWPlayer woWPlayer = Party.GetPartyHomeAndInstance().First<WoWPlayer>();
				Main.logDebug("Setting followTarget to '" + woWPlayer.Name + "'", false);
				global::A.A.A(woWPlayer);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x040000DE RID: 222
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x040000DF RID: 223
		private Timer A = new Timer(250.0);

		// Token: 0x040000E0 RID: 224
		private int A;

		// Token: 0x02000037 RID: 55
		[CompilerGenerated]
		private sealed class A
		{
			// Token: 0x0600017D RID: 381 RVA: 0x00008DFC File Offset: 0x00006FFC
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.Name == this.A;
			}

			// Token: 0x0600017E RID: 382 RVA: 0x00008E0F File Offset: 0x0000700F
			internal bool a(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.Name == this.a;
			}

			// Token: 0x040000E1 RID: 225
			public string A;

			// Token: 0x040000E2 RID: 226
			public string a;
		}

		// Token: 0x02000038 RID: 56
		[CompilerGenerated]
		[Serializable]
		private sealed class a
		{
			// Token: 0x06000181 RID: 385 RVA: 0x00008E2E File Offset: 0x0000702E
			internal bool A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.Name == DungeonCrawlerSettings.CurrentSetting.FollowOverrideName;
			}

			// Token: 0x040000E3 RID: 227
			public static readonly i.a A = new i.a();

			// Token: 0x040000E4 RID: 228
			public static Func<WoWUnit, bool> A;
		}
	}
}
