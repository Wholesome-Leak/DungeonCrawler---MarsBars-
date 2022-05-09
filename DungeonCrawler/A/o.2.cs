using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Class;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000050 RID: 80
	internal class o : State
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000227 RID: 551 RVA: 0x0000923A File Offset: 0x0000743A
		public override string DisplayName
		{
			get
			{
				return "dCombat";
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0001701C File Offset: 0x0001521C
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00009241 File Offset: 0x00007441
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

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00017034 File Offset: 0x00015234
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
					bool flag;
					if (!ObjectManager.Me.InCombatFlagOnly)
					{
						if (!Party.GetPartyHomeAndInstance().Any(new Func<WoWPlayer, bool>(o.A.A.A)))
						{
							flag = ObjectManager.GetObjectWoWUnit().Any(new Func<WoWUnit, bool>(o.A.A.A));
							goto IL_71;
						}
					}
					flag = true;
					IL_71:
					result = flag;
				}
				return result;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600022B RID: 555 RVA: 0x0000914C File Offset: 0x0000734C
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000914C File Offset: 0x0000734C
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000170B4 File Offset: 0x000152B4
		public override void Run()
		{
			if (o.A.IsMounted)
			{
				MountTask.DismountMount(true, true, 250);
			}
			switch (DungeonCrawlerSettings.CurrentSetting.Role)
			{
			case LFGRole.Tank:
				this.A();
				break;
			case LFGRole.DPS:
				this.a();
				break;
			case LFGRole.Heal:
				this.B();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			Thread.Sleep(50);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00017120 File Offset: 0x00015320
		private void A()
		{
			try
			{
				if (this.A.IsReady)
				{
					this.A = new Timer(200.0);
					if (MovementManager.InMovement && !Fight.InFight)
					{
						MovementManager.StopMoveOnly();
					}
					WoWUnit woWUnit = d.a();
					if (woWUnit != null)
					{
						Main.logDebug(string.Format("Targeting {0} - {1}.", woWUnit.Name, woWUnit.Guid), false);
						if (Fight.InFight)
						{
							Fight.StopFight();
						}
						Interact.InteractGameObject(woWUnit.GetBaseAddress, false, false);
						MovementManager.Face(woWUnit.Position);
						Fight.StartFight(woWUnit.Guid, false, true, false, false);
					}
					else
					{
						Main.logDebug("Couldn't get target.", false);
					}
				}
			}
			catch (Exception ex)
			{
				Main.logError(ex.Message);
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00017204 File Offset: 0x00015404
		private void a()
		{
			if (this.A.IsReady)
			{
				this.A = new Timer(200.0);
				WoWUnit woWUnit = d.B();
				if (woWUnit != null)
				{
					Main.logDebug(string.Format("Changing target to {0} - {1}.", woWUnit.Name, woWUnit.Guid), false);
					if (Fight.InFight)
					{
						Fight.StopFight();
					}
					Interact.InteractGameObject(woWUnit.GetBaseAddress, false, false);
					MovementManager.Face(woWUnit.Position);
					Fight.StartFight(woWUnit.Guid, false, true, false, false);
				}
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00017298 File Offset: 0x00015498
		private void B()
		{
			if (this.A.IsReady)
			{
				if (o.A.TargetObject == null)
				{
					Interact.InteractGameObject(global::A.A.a().GetBaseAddress, false, false);
				}
				WoWPlayer woWPlayer = d.A();
				if (woWPlayer != null)
				{
					Interact.InteractGameObject(woWPlayer.GetBaseAddress, false, false);
				}
				if ((double)global::A.A.a().GetDistance <= DungeonCrawlerSettings.CurrentSetting.CombatFollowDistance && !TraceLine.TraceLineGo(global::A.A.a().Position))
				{
					Main.logDebug("Close enough to tank and within LOS, stop following. (A)", false);
					MovementManager.StopMoveOnly();
				}
				if (TraceLine.TraceLineGo(global::A.A.a().Position) || (double)global::A.A.a().GetDistance >= DungeonCrawlerSettings.CurrentSetting.CombatFollowDistance)
				{
					Main.logDebug("Not close enough to tank or not within LOS, start following.", false);
					if (GoToTask.ToPosition(global::A.A.a().Position, 3.5f, true, new BooleanDelegate(o.A.A.A)))
					{
						Main.logDebug("Close enough to tank and within LOS, stop following. (B)", false);
						MovementManager.StopMove();
					}
				}
				this.A = new Timer(100.0);
			}
		}

		// Token: 0x0400012A RID: 298
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x0400012B RID: 299
		private Timer A = new Timer(250.0);

		// Token: 0x0400012C RID: 300
		private int A;

		// Token: 0x02000051 RID: 81
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x06000235 RID: 565 RVA: 0x0000927E File Offset: 0x0000747E
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.InCombatFlagOnly;
			}

			// Token: 0x06000236 RID: 566 RVA: 0x00009286 File Offset: 0x00007486
			internal bool A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.IsPet && woWUnit_0.InCombatFlagOnly && woWUnit_0.Reaction > 3;
			}

			// Token: 0x06000237 RID: 567 RVA: 0x000092A4 File Offset: 0x000074A4
			internal bool A(object object_0)
			{
				return (double)global::A.A.a().GetDistance >= DungeonCrawlerSettings.CurrentSetting.CombatFollowDistance || TraceLine.TraceLineGo(global::A.A.a().Position);
			}

			// Token: 0x0400012D RID: 301
			public static readonly o.A A = new o.A();

			// Token: 0x0400012E RID: 302
			public static Func<WoWPlayer, bool> A;

			// Token: 0x0400012F RID: 303
			public static Func<WoWUnit, bool> A;

			// Token: 0x04000130 RID: 304
			public static BooleanDelegate A;
		}
	}
}
