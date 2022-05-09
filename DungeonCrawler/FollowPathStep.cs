using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using robotManager.Helpful;

// Token: 0x0200001F RID: 31
public class FollowPathStep : StepType
{
	// Token: 0x17000025 RID: 37
	// (get) Token: 0x060000D2 RID: 210 RVA: 0x00008979 File Offset: 0x00006B79
	// (set) Token: 0x060000D3 RID: 211 RVA: 0x00008981 File Offset: 0x00006B81
	public List<Vector3> Path { get; set; }

	// Token: 0x060000D4 RID: 212 RVA: 0x0000898A File Offset: 0x00006B8A
	public FollowPathStep()
	{
		this.Path = new List<Vector3>();
	}

	// Token: 0x04000071 RID: 113
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Vector3> A;
}
