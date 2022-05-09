using System;
using System.Collections.Generic;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000039 RID: 57
	internal class J : State
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000182 RID: 386 RVA: 0x000143B4 File Offset: 0x000125B4
		public override string DisplayName
		{
			get
			{
				return "dFollowing";
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000183 RID: 387 RVA: 0x000143C8 File Offset: 0x000125C8
		// (set) Token: 0x06000184 RID: 388 RVA: 0x00008E45 File Offset: 0x00007045
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

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000185 RID: 389 RVA: 0x000143E0 File Offset: 0x000125E0
		public override bool NeedToRun
		{
			get
			{
				return Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause && J.A.IsInParty && C.a() && global::A.A.a() != null && this.A.IsReady;
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00014428 File Offset: 0x00012628
		public override void Run()
		{
			this.A = new Timer(250.0);
			try
			{
				if (global::A.A.a().IsValid)
				{
					if (global::A.A.a().GetDistance < this.A)
					{
						MovementManager.StopMoveOnly();
					}
					if (!MovementManager.InMovement)
					{
						if (global::A.A.a().GetDistance > this.A && !global::A.A.a().IsDead)
						{
							if (global::A.A.a().IsMounted)
							{
								MountTask.Mount(true, 0);
							}
							List<Vector3> list = PathFinder.FindPath(global::A.A.a().Position);
							if (list != null && list.Count > 0)
							{
								if (!TraceLine.TraceLineGo(global::A.A.a().Position) && list.Count > 6)
								{
									MovementManager.MoveTo(global::A.A.a().Position);
								}
								else
								{
									MovementManager.Go(list, false);
								}
							}
						}
						else if (global::A.A.a().IsValid && J.A.IsMounted && !global::A.A.a().IsMounted && !MovementManager.InMovement)
						{
							MountTask.DismountMount(true, true, 250);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Main.logError(ex.Message);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x040000E5 RID: 229
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x040000E6 RID: 230
		private float A = (float)DungeonCrawlerSettings.CurrentSetting.OOCFollowDistance;

		// Token: 0x040000E7 RID: 231
		private Timer A = new Timer(250.0);

		// Token: 0x040000E8 RID: 232
		private int A;
	}
}
