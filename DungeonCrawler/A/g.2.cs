using System;
using System.Collections.Generic;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200002C RID: 44
	internal class g : State
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0001399C File Offset: 0x00011B9C
		public override string DisplayName
		{
			get
			{
				return "dGetDungeonState";
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600013E RID: 318 RVA: 0x000139B0 File Offset: 0x00011BB0
		// (set) Token: 0x0600013F RID: 319 RVA: 0x00008CBD File Offset: 0x00006EBD
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

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000140 RID: 320 RVA: 0x000139C8 File Offset: 0x00011BC8
		public override bool NeedToRun
		{
			get
			{
				return Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause && C.a() && e.a() == null && this.A.IsReady;
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00008CC6 File Offset: 0x00006EC6
		public override void Run()
		{
			this.A = new Timer(1000.0);
			e.a(e.A());
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x040000C9 RID: 201
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x040000CA RID: 202
		private Timer A = new Timer(250.0);

		// Token: 0x040000CB RID: 203
		private int A;
	}
}
