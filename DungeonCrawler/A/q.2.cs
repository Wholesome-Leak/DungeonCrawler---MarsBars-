using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace A
{
	// Token: 0x02000066 RID: 102
	[CompilerGenerated]
	internal static class q
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x0000956F File Offset: 0x0000776F
		private static string A(CultureInfo cultureInfo_0)
		{
			if (cultureInfo_0 == null)
			{
				return "";
			}
			return cultureInfo_0.Name;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0001A6E0 File Offset: 0x000188E0
		private static Assembly A(AssemblyName assemblyName_0)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				AssemblyName name = assembly.GetName();
				if (string.Equals(name.Name, assemblyName_0.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(q.A(name.CultureInfo), q.A(assemblyName_0.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0001A748 File Offset: 0x00018948
		private static void A(Stream stream_0, Stream stream_1)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = stream_0.Read(array, 0, array.Length)) != 0)
			{
				stream_1.Write(array, 0, count);
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0001A77C File Offset: 0x0001897C
		private static Stream A(string string_0)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (string_0.EndsWith(".compressed"))
			{
				Stream result;
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(string_0))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						q.A(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						result = memoryStream;
					}
				}
				return result;
			}
			return executingAssembly.GetManifestResourceStream(string_0);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0001A808 File Offset: 0x00018A08
		private static Stream A(Dictionary<string, string> dictionary_0, string string_0)
		{
			string string_;
			if (dictionary_0.TryGetValue(string_0, out string_))
			{
				return q.A(string_);
			}
			return null;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0001A828 File Offset: 0x00018A28
		private static byte[] A(Stream stream_0)
		{
			byte[] array = new byte[stream_0.Length];
			stream_0.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0001A850 File Offset: 0x00018A50
		private static Assembly A(Dictionary<string, string> dictionary_0, Dictionary<string, string> dictionary_1, AssemblyName assemblyName_0)
		{
			string text = assemblyName_0.Name.ToLowerInvariant();
			if (assemblyName_0.CultureInfo != null && !string.IsNullOrEmpty(assemblyName_0.CultureInfo.Name))
			{
				text = assemblyName_0.CultureInfo.Name + "." + text;
			}
			byte[] rawAssembly;
			using (Stream stream = q.A(dictionary_0, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = q.A(stream);
			}
			using (Stream stream2 = q.A(dictionary_1, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = q.A(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0001A910 File Offset: 0x00018B10
		public static Assembly A(object object_0, ResolveEventArgs resolveEventArgs_0)
		{
			object obj = q.A;
			lock (obj)
			{
				if (q.A.ContainsKey(resolveEventArgs_0.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(resolveEventArgs_0.Name);
			Assembly assembly = q.A(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = q.A(q.A, q.a, assemblyName);
			if (assembly == null)
			{
				obj = q.A;
				lock (obj)
				{
					q.A[resolveEventArgs_0.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00009580 File Offset: 0x00007780
		// Note: this type is marked as 'beforefieldinit'.
		static q()
		{
			q.A.Add("costura", "costura.costura.dll.compressed");
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000095BE File Offset: 0x000077BE
		public static void A()
		{
			if (Interlocked.Exchange(ref q.A, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += q.A;
		}

		// Token: 0x040001D6 RID: 470
		private static object A = new object();

		// Token: 0x040001D7 RID: 471
		private static Dictionary<string, bool> A = new Dictionary<string, bool>();

		// Token: 0x040001D8 RID: 472
		private static Dictionary<string, string> A = new Dictionary<string, string>();

		// Token: 0x040001D9 RID: 473
		private static Dictionary<string, string> a = new Dictionary<string, string>();

		// Token: 0x040001DA RID: 474
		private static int A;
	}
}
