using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.FiniteStateMachine;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200004B RID: 75
	internal class N : State
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000205 RID: 517 RVA: 0x0000913C File Offset: 0x0000733C
		public override string DisplayName
		{
			get
			{
				return "dWait";
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0001694C File Offset: 0x00014B4C
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00009143 File Offset: 0x00007343
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

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00016964 File Offset: 0x00014B64
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause || DungeonCrawlerSettings.CurrentSetting.Role != LFGRole.Tank || !ObjectManager.Me.IsInParty || !C.a())
				{
					result = false;
				}
				else if (global::A.A.B() != null && global::A.A.B().ManaPercentage <= 40U)
				{
					Main.logDebug(string.Format("dWaitReason: Healer mana below 40%, current set healer: {0}", global::A.A.B()), false);
					result = true;
				}
				else if (Party.GetPartyHomeAndInstance().Any(new Func<WoWPlayer, bool>(N.A.A.A)))
				{
					Main.logDebug("dWaitReason: Party member is drinking", false);
					result = true;
				}
				else if (Party.GetPartyHomeAndInstance().Any(new Func<WoWPlayer, bool>(N.A.A.a)))
				{
					Main.logDebug("dWaitReason: Party member is more than 40 yards away", false);
					result = true;
				}
				else if (global::A.A.B() != null && global::A.A.B().GetDistance > 20f && TraceLine.TraceLineGo(global::A.A.B().Position))
				{
					Main.logDebug("dWaitReason: lfgHealer is more than 20 yards away and not in LoS", false);
					result = true;
				}
				else if ((ulong)(Party.GetPartyNumberPlayers() - 1U) > (ulong)((long)Party.GetPartyHomeAndInstance().Count<WoWPlayer>()))
				{
					Main.logDebug("dWaitReason: Party member is not in the instance or outside objectmanager range", false);
					result = true;
				}
				else if (D.A())
				{
					Main.logDebug("dWaitReason: Party member is dead", false);
					result = true;
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000914C File Offset: 0x0000734C
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000914C File Offset: 0x0000734C
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00016AD0 File Offset: 0x00014CD0
		public override void Run()
		{
			if (MovementManager.InMovement)
			{
				MovementManager.StopMove();
			}
			Thread.Sleep(250);
		}

		// Token: 0x0400011E RID: 286
		private int A;

		// Token: 0x0200004C RID: 76
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x0600020F RID: 527 RVA: 0x0000915F File Offset: 0x0000735F
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.HaveBuff("Drink") && woWPlayer_0.ManaPercentage <= 95U;
			}

			// Token: 0x06000210 RID: 528 RVA: 0x0000917E File Offset: 0x0000737E
			internal bool a(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.GetDistance > 40f;
			}

			// Token: 0x0400011F RID: 287
			public static readonly N.A A = new N.A();

			// Token: 0x04000120 RID: 288
			public static Func<WoWPlayer, bool> A;

			// Token: 0x04000121 RID: 289
			public static Func<WoWPlayer, bool> a;
		}
	}
}
