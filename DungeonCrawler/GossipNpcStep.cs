using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000022 RID: 34
public class GossipNpcStep : StepType
{
	// Token: 0x17000029 RID: 41
	// (get) Token: 0x060000DD RID: 221 RVA: 0x000089D8 File Offset: 0x00006BD8
	// (set) Token: 0x060000DE RID: 222 RVA: 0x000089E0 File Offset: 0x00006BE0
	public int NpcId { get; set; }

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x060000DF RID: 223 RVA: 0x000089E9 File Offset: 0x00006BE9
	// (set) Token: 0x060000E0 RID: 224 RVA: 0x000089F1 File Offset: 0x00006BF1
	public int GossipIndex { get; set; }

	// Token: 0x04000075 RID: 117
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int A;

	// Token: 0x04000076 RID: 118
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int a;
}
