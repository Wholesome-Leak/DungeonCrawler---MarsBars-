using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// Token: 0x02000025 RID: 37
public class ItemStats
{
	// Token: 0x1700002C RID: 44
	// (get) Token: 0x060000E5 RID: 229 RVA: 0x00008A0B File Offset: 0x00006C0B
	// (set) Token: 0x060000E6 RID: 230 RVA: 0x00008A13 File Offset: 0x00006C13
	public double Strength { get; set; }

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x060000E7 RID: 231 RVA: 0x00008A1C File Offset: 0x00006C1C
	// (set) Token: 0x060000E8 RID: 232 RVA: 0x00008A24 File Offset: 0x00006C24
	public double Agility { get; set; }

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x060000E9 RID: 233 RVA: 0x00008A2D File Offset: 0x00006C2D
	// (set) Token: 0x060000EA RID: 234 RVA: 0x00008A35 File Offset: 0x00006C35
	public double Intellect { get; set; }

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x060000EB RID: 235 RVA: 0x00008A3E File Offset: 0x00006C3E
	// (set) Token: 0x060000EC RID: 236 RVA: 0x00008A46 File Offset: 0x00006C46
	public double Stamina { get; set; }

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x060000ED RID: 237 RVA: 0x00008A4F File Offset: 0x00006C4F
	// (set) Token: 0x060000EE RID: 238 RVA: 0x00008A57 File Offset: 0x00006C57
	public double Spirit { get; set; }

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x060000EF RID: 239 RVA: 0x00008A60 File Offset: 0x00006C60
	// (set) Token: 0x060000F0 RID: 240 RVA: 0x00008A68 File Offset: 0x00006C68
	[JsonProperty("Attack Power")]
	public double AttackPower { get; set; }

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060000F1 RID: 241 RVA: 0x00008A71 File Offset: 0x00006C71
	// (set) Token: 0x060000F2 RID: 242 RVA: 0x00008A79 File Offset: 0x00006C79
	[JsonProperty("Spell Power")]
	public double SpellPower { get; set; }

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x060000F3 RID: 243 RVA: 0x00008A82 File Offset: 0x00006C82
	// (set) Token: 0x060000F4 RID: 244 RVA: 0x00008A8A File Offset: 0x00006C8A
	[JsonProperty("Damage Per Second")]
	public double DamagePerSecond { get; set; }

	// Token: 0x04000095 RID: 149
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double A;

	// Token: 0x04000096 RID: 150
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double a;

	// Token: 0x04000097 RID: 151
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double B;

	// Token: 0x04000098 RID: 152
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double b;

	// Token: 0x04000099 RID: 153
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double C;

	// Token: 0x0400009A RID: 154
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double c;

	// Token: 0x0400009B RID: 155
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double D;

	// Token: 0x0400009C RID: 156
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double d;
}
