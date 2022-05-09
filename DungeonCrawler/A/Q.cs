using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using wManager.Events;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000064 RID: 100
	internal static class Q
	{
		// Token: 0x060002D2 RID: 722 RVA: 0x00009549 File Offset: 0x00007749
		public static void A()
		{
			FightEvents.OnFightLoop += new FightEvents.FightTargetHandler(Q.A);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000955C File Offset: 0x0000775C
		public static void a()
		{
			FightEvents.OnFightLoop -= new FightEvents.FightTargetHandler(Q.A);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0001A60C File Offset: 0x0001880C
		private static void A(WoWUnit woWUnit_0, CancelEventArgs cancelEventArgs_0)
		{
			Q.A a = new Q.A();
			a.A = woWUnit_0;
			Task.Run(new Action(a.A));
		}

		// Token: 0x02000065 RID: 101
		[CompilerGenerated]
		private sealed class A
		{
			// Token: 0x060002D6 RID: 726 RVA: 0x0001A638 File Offset: 0x00018838
			internal void A()
			{
				if (this.A != null && ObjectManager.Me.InCombatFlagOnly)
				{
					if (DungeonCrawlerSettings.CurrentSetting.Role == LFGRole.Tank)
					{
						WoWUnit woWUnit = d.a();
						if (woWUnit != null && woWUnit.Guid != this.A.Guid)
						{
							Main.logDebug("Need to change target.", false);
							Fight.CurrentTarget = woWUnit;
						}
					}
					if (DungeonCrawlerSettings.CurrentSetting.Role == LFGRole.DPS)
					{
						WoWUnit woWUnit2 = d.B();
						if (woWUnit2 != null && woWUnit2.Guid != this.A.Guid)
						{
							Fight.CurrentTarget = woWUnit2;
						}
					}
				}
			}

			// Token: 0x040001D5 RID: 469
			public WoWUnit A;
		}
	}
}
