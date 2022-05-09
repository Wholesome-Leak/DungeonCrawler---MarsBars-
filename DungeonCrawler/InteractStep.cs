using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000020 RID: 32
public class InteractStep : StepType
{
	// Token: 0x17000026 RID: 38
	// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000899D File Offset: 0x00006B9D
	// (set) Token: 0x060000D6 RID: 214 RVA: 0x000089A5 File Offset: 0x00006BA5
	public int GameObjectId { get; set; }

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x060000D7 RID: 215 RVA: 0x000089AE File Offset: 0x00006BAE
	// (set) Token: 0x060000D8 RID: 216 RVA: 0x000089B6 File Offset: 0x00006BB6
	public int? ItemId { get; set; }

	// Token: 0x04000072 RID: 114
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int A;

	// Token: 0x04000073 RID: 115
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? A;
}
