using System;
using System.Collections.Generic;
using robotManager.FiniteStateMachine;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000052 RID: 82
	internal class P : State
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000173C8 File Offset: 0x000155C8
		public override string DisplayName
		{
			get
			{
				return "dQueuing";
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000239 RID: 569 RVA: 0x000173DC File Offset: 0x000155DC
		// (set) Token: 0x0600023A RID: 570 RVA: 0x000092CF File Offset: 0x000074CF
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

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600023B RID: 571 RVA: 0x000173F4 File Offset: 0x000155F4
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
				{
					result = false;
				}
				else
				{
					Main.logDebug(string.Format("dQueuing: InInstance: {0}, LFGMode: {1}, DungeonCD: {2}, LeaderNameSet: {3}, NeedToVendor: {4}", new object[]
					{
						C.a(),
						C.C(),
						C.A(),
						!string.IsNullOrWhiteSpace(DungeonCrawlerSettings.CurrentSetting.LeaderName),
						global::A.A.A
					}), false);
					if (!C.a() && !global::A.A.A && !C.A() && C.C() == "nil" && (string.IsNullOrWhiteSpace(DungeonCrawlerSettings.CurrentSetting.LeaderName) || DungeonCrawlerSettings.CurrentSetting.IsLeader) && (!ObjectManager.Me.IsInParty || ObjectManager.Me.IsPartyLeader))
					{
						result = true;
					}
					else
					{
						if (C.a() && C.C() == "abandonedInDungeon")
						{
							C.b();
						}
						result = false;
					}
				}
				return result;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000174FC File Offset: 0x000156FC
		public override void Run()
		{
			C.A(DungeonCrawlerSettings.CurrentSetting.Role);
			if (DungeonCrawlerSettings.CurrentSetting.QueueRandom)
			{
				C.c();
			}
			else
			{
				C.D();
			}
		}

		// Token: 0x04000131 RID: 305
		private int A;
	}
}
