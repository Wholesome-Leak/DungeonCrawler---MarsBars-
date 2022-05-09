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
	// Token: 0x02000046 RID: 70
	internal class l : State
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00015338 File Offset: 0x00013538
		public override string DisplayName
		{
			get
			{
				return "dTeleport";
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00015750 File Offset: 0x00013950
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00009080 File Offset: 0x00007280
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

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00015768 File Offset: 0x00013968
		public override bool NeedToRun
		{
			get
			{
				if (this.A.IsReady && Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
				{
					this.A = new Timer(5000.0);
					if (!DungeonCrawlerSettings.CurrentSetting.QueueGroup)
					{
						return global::A.A.b || (global::A.A.a() != null && e.a().Start != null && global::A.A.a().Position.DistanceTo(ObjectManager.Me.Position) > global::A.A.a().Position.DistanceTo(e.a().Start)) || (C.C() != "nil" && C.C() != "queued" && !C.a());
					}
					bool flag;
					if (e.a() == e.A.FirstOrDefault(new Func<Dungeon, bool>(l.A.A.A)))
					{
						if (e.A.FirstOrDefault(new Func<Dungeon, bool>(l.A.A.a)).Start.DistanceTo(ObjectManager.Me.Position) >= 20f)
						{
							flag = (e.A.FirstOrDefault(new Func<Dungeon, bool>(l.A.A.B)).Start.DistanceTo(ObjectManager.Me.Position) < 20f);
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						return true;
					}
					if (global::A.A.b)
					{
						Main.logDebug("Teleporting: NeedToTeleport was true.", false);
						return true;
					}
					if (C.C() != "nil" && C.C() != "queued" && !C.a())
					{
						Main.logDebug("Teleporting: In LFG but not in dungeon, teleporting back in.", false);
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00015960 File Offset: 0x00013B60
		public override void Run()
		{
			if (C.a())
			{
				C.b();
			}
			if (!C.a())
			{
				this.A = new Timer(60000.0);
				if (DungeonCrawlerSettings.CurrentSetting.Role != LFGRole.Tank && e.a() != null)
				{
					e.a().DungeonProfile.DungeonSteps.ForEach(new Action<DungeonStep>(l.A.A.A));
				}
				C.B();
				global::A.A.b = false;
			}
		}

		// Token: 0x0400010F RID: 271
		private int A;

		// Token: 0x04000110 RID: 272
		private Timer A = new Timer(10000.0);

		// Token: 0x02000047 RID: 71
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x060001E5 RID: 485 RVA: 0x000090B1 File Offset: 0x000072B1
			internal bool A(Dungeon dungeon_0)
			{
				return dungeon_0.Name == "Maraudon - Earth Song Falls";
			}

			// Token: 0x060001E6 RID: 486 RVA: 0x000090C3 File Offset: 0x000072C3
			internal bool a(Dungeon dungeon_0)
			{
				return dungeon_0.Name == "Maraudon - Foulspore Cavern";
			}

			// Token: 0x060001E7 RID: 487 RVA: 0x000090D5 File Offset: 0x000072D5
			internal bool B(Dungeon dungeon_0)
			{
				return dungeon_0.Name == "Maraudon - The Wicked Grotto";
			}

			// Token: 0x060001E8 RID: 488 RVA: 0x00008DC2 File Offset: 0x00006FC2
			internal void A(DungeonStep dungeonStep_0)
			{
				dungeonStep_0.StepComplete = false;
			}

			// Token: 0x04000111 RID: 273
			public static readonly l.A A = new l.A();

			// Token: 0x04000112 RID: 274
			public static Func<Dungeon, bool> A;

			// Token: 0x04000113 RID: 275
			public static Func<Dungeon, bool> a;

			// Token: 0x04000114 RID: 276
			public static Func<Dungeon, bool> B;

			// Token: 0x04000115 RID: 277
			public static Action<DungeonStep> A;
		}
	}
}
