using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000010 RID: 16
	internal static class d
	{
		// Token: 0x06000058 RID: 88 RVA: 0x0000BB64 File Offset: 0x00009D64
		public static WoWPlayer A()
		{
			return d.A(5000f).Where(new Func<WoWPlayer, bool>(d.A.A.A)).OrderBy(new Func<WoWPlayer, double>(d.A.A.a)).FirstOrDefault<WoWPlayer>();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000BBCC File Offset: 0x00009DCC
		public static List<WoWPlayer> A(float float_0 = 5000f)
		{
			d.a a = new d.a();
			a.A = float_0;
			List<WoWPlayer> list = new List<WoWPlayer>();
			IEnumerable<WoWPlayer> enumerable = Party.GetPartyHomeAndInstance().Where(new Func<WoWPlayer, bool>(a.A));
			if (enumerable.Count<WoWPlayer>() > 0)
			{
				foreach (WoWPlayer woWPlayer in enumerable)
				{
					WoWPlayer item = new WoWPlayer(woWPlayer.GetBaseAddress);
					list.Add(item);
				}
			}
			WoWPlayer item2 = new WoWPlayer(ObjectManager.Me.GetBaseAddress);
			list.Add(item2);
			return list;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000BC7C File Offset: 0x00009E7C
		public static WoWUnit a()
		{
			WoWUnit result;
			try
			{
				IOrderedEnumerable<WoWUnit> source = ObjectManager.GetWoWUnitAttackables(float.MaxValue).Where(new Func<WoWUnit, bool>(d.A.A.A)).OrderBy(new Func<WoWUnit, ulong>(d.A.A.a));
				Main.logDebug(string.Format("{0} Potential Targets found.", source.Count<WoWUnit>()), false);
				if (source.Count<WoWUnit>() > 0)
				{
					if (source.FirstOrDefault(new Func<WoWUnit, bool>(d.A.A.B)) != null)
					{
						WoWUnit woWUnit = source.OrderBy(new Func<WoWUnit, float>(d.A.A.b)).FirstOrDefault(new Func<WoWUnit, bool>(d.A.A.C));
						Main.logDebug("Targeting " + woWUnit.Name + " because it's targeting the healer.", false);
						result = woWUnit;
					}
					else if (source.FirstOrDefault(new Func<WoWUnit, bool>(d.A.A.c)) != null)
					{
						WoWUnit woWUnit2 = source.OrderBy(new Func<WoWUnit, float>(d.A.A.D)).FirstOrDefault(new Func<WoWUnit, bool>(d.A.A.d));
						Main.logDebug("Targeting " + woWUnit2.Name + " because it's targeting a party member.", false);
						result = woWUnit2;
					}
					else
					{
						WoWUnit woWUnit3 = source.OrderBy(new Func<WoWUnit, float>(d.A.A.E)).FirstOrDefault<WoWUnit>();
						Main.logDebug("Targeting " + woWUnit3.Name + " because it's the closest enemy.", false);
						result = woWUnit3;
					}
				}
				else
				{
					Main.logDebug("No Target found.", false);
					result = null;
				}
			}
			catch (Exception ex)
			{
				Main.logError(ex.Message);
				result = null;
			}
			return result;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000BEC4 File Offset: 0x0000A0C4
		public static WoWUnit B()
		{
			WoWUnit result;
			if (global::A.A.a() != null && global::A.A.a().HasTarget && !TraceLine.TraceLineGo(global::A.A.a().TargetObject.Position, global::A.A.a().Position, 337) && global::A.A.a().TargetObject.IsAttackable && global::A.A.a().TargetObject.Position.DistanceTo(global::A.A.a().Position) <= 15f)
			{
				Main.logDebug("getting tanks target", false);
				result = global::A.A.a().TargetObject;
			}
			else
			{
				IOrderedEnumerable<WoWUnit> source = ObjectManager.GetWoWUnitAttackables(float.MaxValue).Where(new Func<WoWUnit, bool>(d.A.A.e)).OrderBy(new Func<WoWUnit, ulong>(d.A.A.F));
				if (global::A.A.a() != null && global::A.A.a().IsDead)
				{
					Main.logDebug("Followtarget is dead or doesnt have a target, attack first unit", false);
					result = source.OrderBy(new Func<WoWUnit, float>(d.A.A.f)).FirstOrDefault<WoWUnit>();
				}
				else if (source.Any<WoWUnit>())
				{
					Main.logDebug("dps else", false);
					result = (source.FirstOrDefault(new Func<WoWUnit, bool>(d.A.A.G)) ?? source.FirstOrDefault<WoWUnit>());
				}
				else
				{
					Main.logDebug("No Target found.", false);
					result = null;
				}
			}
			return result;
		}

		// Token: 0x02000011 RID: 17
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x0600005E RID: 94 RVA: 0x0000857D File Offset: 0x0000677D
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.HealthPercent <= 95.0;
			}

			// Token: 0x0600005F RID: 95 RVA: 0x00008593 File Offset: 0x00006793
			internal double a(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.HealthPercent;
			}

			// Token: 0x06000060 RID: 96 RVA: 0x0000859B File Offset: 0x0000679B
			internal bool A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.InCombatFlagOnly && (woWUnit_0.IsTargetingMeOrMyPetOrPartyMember || woWUnit_0.TargetObject.Reaction > 3);
			}

			// Token: 0x06000061 RID: 97 RVA: 0x000085C1 File Offset: 0x000067C1
			internal ulong a(WoWUnit woWUnit_0)
			{
				return woWUnit_0.Guid;
			}

			// Token: 0x06000062 RID: 98 RVA: 0x000085C9 File Offset: 0x000067C9
			internal bool B(WoWUnit woWUnit_0)
			{
				return woWUnit_0.TargetObject == global::A.A.B();
			}

			// Token: 0x06000063 RID: 99 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float b(WoWUnit woWUnit_0)
			{
				return woWUnit_0.GetDistance;
			}

			// Token: 0x06000064 RID: 100 RVA: 0x000085C9 File Offset: 0x000067C9
			internal bool C(WoWUnit woWUnit_0)
			{
				return woWUnit_0.TargetObject == global::A.A.B();
			}

			// Token: 0x06000065 RID: 101 RVA: 0x000085E0 File Offset: 0x000067E0
			internal bool c(WoWUnit woWUnit_0)
			{
				return woWUnit_0.IsTargetingPartyMember;
			}

			// Token: 0x06000066 RID: 102 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float D(WoWUnit woWUnit_0)
			{
				return woWUnit_0.GetDistance;
			}

			// Token: 0x06000067 RID: 103 RVA: 0x000085E0 File Offset: 0x000067E0
			internal bool d(WoWUnit woWUnit_0)
			{
				return woWUnit_0.IsTargetingPartyMember;
			}

			// Token: 0x06000068 RID: 104 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float E(WoWUnit woWUnit_0)
			{
				return woWUnit_0.GetDistance;
			}

			// Token: 0x06000069 RID: 105 RVA: 0x000085E8 File Offset: 0x000067E8
			internal bool e(WoWUnit woWUnit_0)
			{
				return woWUnit_0.InCombatFlagOnly && woWUnit_0.IsTargetingMeOrMyPetOrPartyMember;
			}

			// Token: 0x0600006A RID: 106 RVA: 0x000085C1 File Offset: 0x000067C1
			internal ulong F(WoWUnit woWUnit_0)
			{
				return woWUnit_0.Guid;
			}

			// Token: 0x0600006B RID: 107 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float f(WoWUnit woWUnit_0)
			{
				return woWUnit_0.GetDistance;
			}

			// Token: 0x0600006C RID: 108 RVA: 0x0000C058 File Offset: 0x0000A258
			internal bool G(WoWUnit woWUnit_0)
			{
				return global::A.A.a() != null && woWUnit_0 == global::A.A.a().TargetObject && !TraceLine.TraceLineGo(woWUnit_0.Position, global::A.A.a().Position, 337) && woWUnit_0.Position.DistanceTo(global::A.A.a().Position) <= 15f;
			}

			// Token: 0x0400002C RID: 44
			public static readonly d.A A = new d.A();

			// Token: 0x0400002D RID: 45
			public static Func<WoWPlayer, bool> A;

			// Token: 0x0400002E RID: 46
			public static Func<WoWPlayer, double> A;

			// Token: 0x0400002F RID: 47
			public static Func<WoWUnit, bool> A;

			// Token: 0x04000030 RID: 48
			public static Func<WoWUnit, ulong> A;

			// Token: 0x04000031 RID: 49
			public static Func<WoWUnit, bool> a;

			// Token: 0x04000032 RID: 50
			public static Func<WoWUnit, float> A;

			// Token: 0x04000033 RID: 51
			public static Func<WoWUnit, bool> B;

			// Token: 0x04000034 RID: 52
			public static Func<WoWUnit, bool> b;

			// Token: 0x04000035 RID: 53
			public static Func<WoWUnit, float> a;

			// Token: 0x04000036 RID: 54
			public static Func<WoWUnit, bool> C;

			// Token: 0x04000037 RID: 55
			public static Func<WoWUnit, float> B;

			// Token: 0x04000038 RID: 56
			public static Func<WoWUnit, bool> c;

			// Token: 0x04000039 RID: 57
			public static Func<WoWUnit, ulong> a;

			// Token: 0x0400003A RID: 58
			public static Func<WoWUnit, float> b;

			// Token: 0x0400003B RID: 59
			public static Func<WoWUnit, bool> D;
		}

		// Token: 0x02000012 RID: 18
		[CompilerGenerated]
		private sealed class a
		{
			// Token: 0x0600006E RID: 110 RVA: 0x000085FB File Offset: 0x000067FB
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.GetDistance < this.A && woWPlayer_0.IsValid && woWPlayer_0.IsAlive;
			}

			// Token: 0x0400003C RID: 60
			public float A;
		}
	}
}
