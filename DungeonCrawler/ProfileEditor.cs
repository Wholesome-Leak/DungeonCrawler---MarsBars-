using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using A;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using robotManager.Helpful;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace DungeonCrawler
{
	// Token: 0x02000056 RID: 86
	public class ProfileEditor : MetroWindow, INotifyPropertyChanged, IComponentConnector
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000249 RID: 585 RVA: 0x00017778 File Offset: 0x00015978
		// (remove) Token: 0x0600024A RID: 586 RVA: 0x000177B0 File Offset: 0x000159B0
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.A;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.A, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.A;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.A, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600024B RID: 587 RVA: 0x000177E8 File Offset: 0x000159E8
		// (set) Token: 0x0600024C RID: 588 RVA: 0x0000930F File Offset: 0x0000750F
		public DungeonProfile currentProfile
		{
			get
			{
				return this.A;
			}
			set
			{
				this.A = value;
				this.OnPropertyChanged("currentProfile");
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00009323 File Offset: 0x00007523
		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.A;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs(name));
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0000933D File Offset: 0x0000753D
		// (set) Token: 0x0600024F RID: 591 RVA: 0x00009345 File Offset: 0x00007545
		public ObservableCollection<DungeonStep> dsCollection { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000250 RID: 592 RVA: 0x0000934E File Offset: 0x0000754E
		// (set) Token: 0x06000251 RID: 593 RVA: 0x00009356 File Offset: 0x00007556
		public ObservableCollection<PathFinder.OffMeshConnection> ocCollection { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0000935F File Offset: 0x0000755F
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00009367 File Offset: 0x00007567
		public ObservableCollection<Vector3> drCollection { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00009370 File Offset: 0x00007570
		// (set) Token: 0x06000255 RID: 597 RVA: 0x00009378 File Offset: 0x00007578
		public ObservableCollection<Vector3> ocpCollection { get; set; }

		// Token: 0x06000256 RID: 598 RVA: 0x00017800 File Offset: 0x00015A00
		public ProfileEditor()
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.currentProfile = new DungeonProfile();
			this.openFileDialog1 = new OpenFileDialog
			{
				FileName = "Select a profile",
				Filter = "JSON files (*.json)|*.json",
				Title = "Open profile",
				InitialDirectory = Others.GetCurrentDirectory + "/Profiles/DungeonCrawler"
			};
			ProfileEditor.A = new System.Timers.Timer(200.0);
			ProfileEditor.A.Elapsed += this.A;
			ProfileEditor.A.AutoReset = true;
			ProfileEditor.A.Enabled = true;
			this.A();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x000178C4 File Offset: 0x00015AC4
		protected override void OnClosing(CancelEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(this.currentProfile.Name) && !string.IsNullOrWhiteSpace(this.currentProfile.DungeonName))
			{
				this.currentProfile.DungeonSteps = this.currentProfile.DungeonSteps.OrderBy(new Func<DungeonStep, int>(ProfileEditor.A.A.A)).ToList<DungeonStep>();
				string text = JsonConvert.SerializeObject(this.currentProfile, 1, this.A);
				string path = string.Concat(new string[]
				{
					Others.GetCurrentDirectory,
					"/Profiles/DungeonCrawler/",
					this.currentProfile.DungeonName,
					"/",
					this.currentProfile.Name,
					".json"
				});
				if (File.Exists(path))
				{
					File.ReadAllText(path);
					if (text != path)
					{
						MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("You have unsaved changes, are you sure you wish to close?", "Unsaved Changes", MessageBoxButton.YesNo);
						if (messageBoxResult == MessageBoxResult.No)
						{
							e.Cancel = true;
						}
					}
				}
				else
				{
					MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("You have unsaved changes, are you sure you wish to close?", "Unsaved Changes", MessageBoxButton.YesNo);
					if (messageBoxResult == MessageBoxResult.No)
					{
						e.Cancel = true;
					}
				}
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000179F0 File Offset: 0x00015BF0
		private void A()
		{
			this.dsCollection = new ObservableCollection<DungeonStep>(this.currentProfile.DungeonSteps.OrderBy(new Func<DungeonStep, int>(ProfileEditor.A.A.a)));
			this.A.ItemsSource = this.dsCollection;
			this.ocCollection = new ObservableCollection<PathFinder.OffMeshConnection>(this.currentProfile.offMeshConnections);
			this.B.ItemsSource = this.ocCollection;
			this.drCollection = new ObservableCollection<Vector3>(this.currentProfile.DeathRunPath);
			this.a.ItemsSource = this.drCollection;
			global::A.e.A.Sort(new Comparison<Dungeon>(ProfileEditor.A.A.A));
			this.A.ItemsSource = global::A.e.A;
			this.A.SelectedValuePath = "Name";
			this.A.DisplayMemberPath = "Name";
			this.a.ItemsSource = Enum.GetValues(typeof(PathFinder.OffMeshConnectionType));
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00009381 File Offset: 0x00007581
		private void A(object sender, RoutedEventArgs e)
		{
			this.currentProfile = new DungeonProfile();
			this.A();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00017B0C File Offset: 0x00015D0C
		private void a(object sender, RoutedEventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string fileName = this.openFileDialog1.FileName;
					this.currentProfile = JsonConvert.DeserializeObject<DungeonProfile>(File.ReadAllText(fileName), this.A);
					this.A();
				}
				catch (Exception ex)
				{
					System.Windows.MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
				}
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00017B8C File Offset: 0x00015D8C
		private void B(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.currentProfile.Name))
				{
					DirectoryInfo directoryInfo = Directory.CreateDirectory(Others.GetCurrentDirectory + "/Profiles/DungeonCrawler/" + this.currentProfile.DungeonName);
					this.currentProfile.DungeonSteps = this.currentProfile.DungeonSteps.OrderBy(new Func<DungeonStep, int>(ProfileEditor.A.A.B)).ToList<DungeonStep>();
					string contents = JsonConvert.SerializeObject(this.currentProfile, 1, this.A);
					string text = directoryInfo.FullName + "/" + this.currentProfile.Name + ".json";
					File.WriteAllText(text, contents);
					this.A();
					System.Windows.MessageBox.Show("Saved to " + text);
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00017C9C File Offset: 0x00015E9C
		private void A(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.A.SelectedItem != null)
				{
					if (((DungeonStep)this.A.SelectedItem).Condition == null)
					{
						((DungeonStep)this.A.SelectedItem).Condition = new DungeonStepCondition();
					}
					this.A.SelectedItem = (DungeonStep)this.A.SelectedItem;
					if (this.A.SelectedItem.StepType.StepTypeName == "FollowPathStep")
					{
						this.A.fpsCollection = new ObservableCollection<Vector3>(((FollowPathStep)this.A.SelectedItem.StepType).Path);
						this.A.A.ItemsSource = this.A.fpsCollection;
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00017D94 File Offset: 0x00015F94
		private void a(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.B.SelectedIndex >= 0)
				{
					this.ocpCollection = new ObservableCollection<Vector3>(((PathFinder.OffMeshConnection)this.B.SelectedItem).Path);
					this.b.ItemsSource = this.ocpCollection;
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000083B0 File Offset: 0x000065B0
		private void B(object sender, SelectionChangedEventArgs e)
		{
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00017E08 File Offset: 0x00016008
		private void b(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.ContextMenu.IsOpen = true;
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00017E30 File Offset: 0x00016030
		private void C(object sender, RoutedEventArgs e)
		{
			if (this.A.SelectedItem != null)
			{
				Debugger.Launch();
				foreach (object obj in this.A.SelectedItems)
				{
					this.dsCollection.Remove((DungeonStep)obj);
					this.currentProfile.DungeonSteps = this.dsCollection.ToList<DungeonStep>();
				}
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00017EC4 File Offset: 0x000160C4
		private void c(object sender, RoutedEventArgs e)
		{
			this.ocCollection.Add(new PathFinder.OffMeshConnection
			{
				Name = (Usefuls.SubMapZoneName ?? Usefuls.MapZoneName),
				ContinentId = global::A.e.A.FirstOrDefault(new Func<Dungeon, bool>(this.A)).MapId,
				TryToUseEvenIfCanFindPathSuccess = true,
				Type = 0
			});
			this.currentProfile.offMeshConnections = this.ocCollection.ToList<PathFinder.OffMeshConnection>();
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00017F3C File Offset: 0x0001613C
		private void D(object sender, RoutedEventArgs e)
		{
			if (this.B.SelectedItem != null)
			{
				this.ocCollection.Remove((PathFinder.OffMeshConnection)this.B.SelectedItem);
				this.currentProfile.offMeshConnections = this.ocCollection.ToList<PathFinder.OffMeshConnection>();
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00009394 File Offset: 0x00007594
		private void d(object sender, RoutedEventArgs e)
		{
			this.drCollection.Add(ObjectManager.Me.Position);
			this.currentProfile.DeathRunPath = this.drCollection.ToList<Vector3>();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00017F8C File Offset: 0x0001618C
		private void E(object sender, RoutedEventArgs e)
		{
			if (this.a.SelectedItem != null)
			{
				this.drCollection.Remove((Vector3)this.a.SelectedItem);
				this.currentProfile.DeathRunPath = this.drCollection.ToList<Vector3>();
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00017FDC File Offset: 0x000161DC
		private void e(object sender, RoutedEventArgs e)
		{
			this.ocpCollection.Add(ObjectManager.Me.Position);
			this.currentProfile.offMeshConnections.FirstOrDefault(new Func<PathFinder.OffMeshConnection, bool>(this.A)).Path = this.ocpCollection.ToList<Vector3>();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0001802C File Offset: 0x0001622C
		private void F(object sender, RoutedEventArgs e)
		{
			if (this.b.SelectedItem != null)
			{
				this.ocpCollection.Remove((Vector3)this.b.SelectedItem);
				this.currentProfile.offMeshConnections.FirstOrDefault(new Func<PathFinder.OffMeshConnection, bool>(this.a)).Path = this.ocpCollection.ToList<Vector3>();
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00018094 File Offset: 0x00016294
		private void A(object sender, ElapsedEventArgs e)
		{
			try
			{
				base.Dispatcher.Invoke(new Action(this.a));
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000180F0 File Offset: 0x000162F0
		private void f(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.A.SelectedItem != null)
				{
					ProfileEditor.a a = new ProfileEditor.a();
					a.A = ((DungeonStep)this.A.SelectedItem).Order;
					DungeonStep dungeonStep = this.currentProfile.DungeonSteps.OrderByDescending(new Func<DungeonStep, int>(ProfileEditor.A.A.b)).FirstOrDefault(new Func<DungeonStep, bool>(a.A));
					if (dungeonStep != null)
					{
						int order = dungeonStep.Order;
						dungeonStep.Order = a.A;
						((DungeonStep)this.A.SelectedItem).Order = order;
						this.dsCollection = new ObservableCollection<DungeonStep>(this.currentProfile.DungeonSteps.OrderBy(new Func<DungeonStep, int>(ProfileEditor.A.A.C)));
						this.A.ItemsSource = this.dsCollection;
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00018228 File Offset: 0x00016428
		private void G(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.A.SelectedItem != null)
				{
					ProfileEditor.B b = new ProfileEditor.B();
					b.A = ((DungeonStep)this.A.SelectedItem).Order;
					DungeonStep dungeonStep = this.currentProfile.DungeonSteps.OrderBy(new Func<DungeonStep, int>(ProfileEditor.A.A.c)).FirstOrDefault(new Func<DungeonStep, bool>(b.A));
					if (dungeonStep != null)
					{
						int order = dungeonStep.Order;
						dungeonStep.Order = b.A;
						((DungeonStep)this.A.SelectedItem).Order = order;
						this.dsCollection = new ObservableCollection<DungeonStep>(this.currentProfile.DungeonSteps.OrderBy(new Func<DungeonStep, int>(ProfileEditor.A.A.D)));
						this.A.ItemsSource = this.dsCollection;
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00018360 File Offset: 0x00016560
		private void g(object sender, RoutedEventArgs e)
		{
			this.dsCollection.Add(new DungeonStep
			{
				Order = this.A.Items.Count,
				StepName = "New Step",
				StepType = new FollowPathStep(),
				Condition = new DungeonStepCondition()
			});
			this.currentProfile.DungeonSteps = this.dsCollection.ToList<DungeonStep>();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x000183CC File Offset: 0x000165CC
		private void H(object sender, RoutedEventArgs e)
		{
			this.dsCollection.Add(new DungeonStep
			{
				Order = this.A.Items.Count,
				StepName = "New Step",
				StepType = new InteractStep(),
				Condition = new DungeonStepCondition()
			});
			this.currentProfile.DungeonSteps = this.dsCollection.ToList<DungeonStep>();
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00018438 File Offset: 0x00016638
		private void h(object sender, RoutedEventArgs e)
		{
			this.dsCollection.Add(new DungeonStep
			{
				Order = this.A.Items.Count,
				StepName = "New Step",
				StepType = new GossipNpcStep(),
				Condition = new DungeonStepCondition()
			});
			this.currentProfile.DungeonSteps = this.dsCollection.ToList<DungeonStep>();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x000184A4 File Offset: 0x000166A4
		private void I(object sender, RoutedEventArgs e)
		{
			this.dsCollection.Add(new DungeonStep
			{
				Order = this.A.Items.Count,
				StepName = "New Step",
				StepType = new RunCodeStep(),
				Condition = new DungeonStepCondition()
			});
			this.currentProfile.DungeonSteps = this.dsCollection.ToList<DungeonStep>();
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00018510 File Offset: 0x00016710
		private void i(object sender, RoutedEventArgs e)
		{
			this.dsCollection.Add(new DungeonStep
			{
				Order = this.A.Items.Count,
				StepName = "New Step",
				StepType = new FollowNPCStep(),
				Condition = new DungeonStepCondition()
			});
			this.currentProfile.DungeonSteps = this.dsCollection.ToList<DungeonStep>();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0001857C File Offset: 0x0001677C
		private void J(object sender, RoutedEventArgs e)
		{
			WoWUnit target = ObjectManager.Target;
			if (target != null)
			{
				this.A.Value = new double?((double)target.Entry);
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000185AC File Offset: 0x000167AC
		private void j(object sender, RoutedEventArgs e)
		{
			if (!Radar3D.IsLaunched)
			{
				this.A = MD5.Create();
				Radar3D.Pulse();
				Radar3D.OnDrawEvent += new Radar3D.OnDrawHandler(this.Monitor);
			}
			else
			{
				Radar3D.OnDrawEvent -= new Radar3D.OnDrawHandler(this.Monitor);
				Radar3D.Stop();
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00018600 File Offset: 0x00016800
		public void Monitor()
		{
			try
			{
				if (Conditions.InGameAndConnected)
				{
					foreach (DungeonStep dungeonStep in this.currentProfile.DungeonSteps.Where(new Func<DungeonStep, bool>(ProfileEditor.A.A.d)))
					{
						byte[] array = this.A.ComputeHash(Encoding.UTF8.GetBytes(dungeonStep.StepName));
						Color color = Color.FromArgb((int)array[0], (int)array[1], (int)array[2]);
						Vector3 vector = new Vector3();
						foreach (Vector3 vector2 in ((FollowPathStep)dungeonStep.StepType).Path)
						{
							if (vector == new Vector3())
							{
								vector = vector2;
							}
							Radar3D.DrawCircle(vector2, 1f, color, true, 200);
							Radar3D.DrawLine(vector2, vector, color, 200);
							vector = vector2;
						}
					}
					Color red = Color.Red;
					Vector3 vector3 = new Vector3();
					foreach (Vector3 vector4 in this.currentProfile.DeathRunPath)
					{
						if (vector3 == new Vector3())
						{
							vector3 = vector4;
						}
						Radar3D.DrawCircle(vector4, 1f, red, true, 200);
						Radar3D.DrawLine(vector4, vector3, red, 200);
						vector3 = vector4;
					}
					foreach (PathFinder.OffMeshConnection offMeshConnection in this.currentProfile.offMeshConnections)
					{
						Color green = Color.Green;
						Vector3 vector5 = new Vector3();
						foreach (Vector3 vector6 in offMeshConnection.Path)
						{
							if (vector5 == new Vector3())
							{
								vector5 = vector6;
							}
							Radar3D.DrawCircle(vector6, 1f, green, true, 200);
							Radar3D.DrawLine(vector6, vector5, green, 200);
							vector5 = vector6;
						}
					}
				}
			}
			catch
			{
				Main.logError("Failed to run the Monitor() function.");
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000188F4 File Offset: 0x00016AF4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.A)
			{
				this.A = true;
				Uri resourceLocator = new Uri("/DungeonCrawler;component/gui/profileeditor.xaml", UriKind.Relative);
				System.Windows.Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00018924 File Offset: 0x00016B24
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate A(Type type_0, string string_0)
		{
			return Delegate.CreateDelegate(type_0, this, string_0);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0001893C File Offset: 0x00016B3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.A(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.A = (ProfileEditor)target;
				break;
			case 2:
				this.A = (System.Windows.Controls.Button)target;
				this.A.Click += this.A;
				break;
			case 3:
				this.a = (System.Windows.Controls.Button)target;
				this.a.Click += this.a;
				break;
			case 4:
				this.B = (System.Windows.Controls.Button)target;
				this.B.Click += this.B;
				break;
			case 5:
				this.b = (System.Windows.Controls.Button)target;
				this.b.Click += this.j;
				break;
			case 6:
				this.A = (System.Windows.Controls.TextBox)target;
				break;
			case 7:
				this.A = (System.Windows.Controls.ComboBox)target;
				this.A.SelectionChanged += this.B;
				break;
			case 8:
				this.A = (NumericUpDown)target;
				break;
			case 9:
				this.C = (System.Windows.Controls.Button)target;
				this.C.Click += this.J;
				break;
			case 10:
				this.A = (System.Windows.Controls.DataGrid)target;
				this.A.SelectionChanged += this.A;
				break;
			case 11:
				this.c = (System.Windows.Controls.Button)target;
				this.c.Click += this.b;
				break;
			case 12:
				this.A = (System.Windows.Controls.MenuItem)target;
				this.A.Click += this.g;
				break;
			case 13:
				this.a = (System.Windows.Controls.MenuItem)target;
				this.a.Click += this.H;
				break;
			case 14:
				this.B = (System.Windows.Controls.MenuItem)target;
				this.B.Click += this.h;
				break;
			case 15:
				this.b = (System.Windows.Controls.MenuItem)target;
				this.b.Click += this.I;
				break;
			case 16:
				this.C = (System.Windows.Controls.MenuItem)target;
				this.C.Click += this.i;
				break;
			case 17:
				this.D = (System.Windows.Controls.Button)target;
				this.D.Click += this.C;
				break;
			case 18:
				this.d = (System.Windows.Controls.Button)target;
				this.d.Click += this.f;
				break;
			case 19:
				this.E = (System.Windows.Controls.Button)target;
				this.E.Click += this.G;
				break;
			case 20:
				this.A = (System.Windows.Controls.GroupBox)target;
				break;
			case 21:
				this.a = (System.Windows.Controls.DataGrid)target;
				break;
			case 22:
				this.e = (System.Windows.Controls.Button)target;
				this.e.Click += this.d;
				break;
			case 23:
				this.F = (System.Windows.Controls.Button)target;
				this.F.Click += this.E;
				break;
			case 24:
				this.A = (ToggleSwitch)target;
				break;
			case 25:
				this.A = (ProfileStep)target;
				break;
			case 26:
				this.B = (System.Windows.Controls.DataGrid)target;
				this.B.SelectionChanged += this.a;
				break;
			case 27:
				this.f = (System.Windows.Controls.Button)target;
				this.f.Click += this.c;
				break;
			case 28:
				this.G = (System.Windows.Controls.Button)target;
				this.G.Click += this.D;
				break;
			case 29:
				this.a = (System.Windows.Controls.GroupBox)target;
				break;
			case 30:
				this.a = (System.Windows.Controls.ComboBox)target;
				break;
			case 31:
				this.b = (System.Windows.Controls.DataGrid)target;
				break;
			case 32:
				this.g = (System.Windows.Controls.Button)target;
				this.g.Click += this.e;
				break;
			case 33:
				this.H = (System.Windows.Controls.Button)target;
				this.H.Click += this.F;
				break;
			default:
				this.A = true;
				break;
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000093C1 File Offset: 0x000075C1
		[CompilerGenerated]
		private bool A(Dungeon dungeon_0)
		{
			return dungeon_0.Name == this.currentProfile.DungeonName;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000093D9 File Offset: 0x000075D9
		[CompilerGenerated]
		private bool A(PathFinder.OffMeshConnection offMeshConnection_0)
		{
			return offMeshConnection_0 == this.B.SelectedItem;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000093D9 File Offset: 0x000075D9
		[CompilerGenerated]
		private bool a(PathFinder.OffMeshConnection offMeshConnection_0)
		{
			return offMeshConnection_0 == this.B.SelectedItem;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00018E64 File Offset: 0x00017064
		[CompilerGenerated]
		private void a()
		{
			if (this.A.IsVisible && this.A.IsChecked.Value && (this.drCollection.Count == 0 || this.drCollection.LastOrDefault<Vector3>().DistanceTo(ObjectManager.Me.Position) > 8f))
			{
				this.drCollection.Add(ObjectManager.Me.Position);
				this.currentProfile.DeathRunPath = this.drCollection.ToList<Vector3>();
			}
		}

		// Token: 0x04000139 RID: 313
		public OpenFileDialog openFileDialog1;

		// Token: 0x0400013A RID: 314
		private DungeonProfile A;

		// Token: 0x0400013B RID: 315
		private static System.Timers.Timer A;

		// Token: 0x0400013C RID: 316
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PropertyChangedEventHandler A;

		// Token: 0x0400013D RID: 317
		private JsonSerializerSettings A = new JsonSerializerSettings
		{
			TypeNameHandling = 4
		};

		// Token: 0x0400013E RID: 318
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<DungeonStep> A;

		// Token: 0x0400013F RID: 319
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<PathFinder.OffMeshConnection> A;

		// Token: 0x04000140 RID: 320
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<Vector3> A;

		// Token: 0x04000141 RID: 321
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<Vector3> a;

		// Token: 0x04000142 RID: 322
		public static List<string> StepTypes = new List<string>
		{
			"FollowPathStep",
			"InteractStep",
			"FollowNPCStep",
			"GossipNpcStep",
			"RunCodeStep"
		};

		// Token: 0x04000143 RID: 323
		private MD5 A;

		// Token: 0x04000144 RID: 324
		internal ProfileEditor A;

		// Token: 0x04000145 RID: 325
		internal System.Windows.Controls.Button A;

		// Token: 0x04000146 RID: 326
		internal System.Windows.Controls.Button a;

		// Token: 0x04000147 RID: 327
		internal System.Windows.Controls.Button B;

		// Token: 0x04000148 RID: 328
		internal System.Windows.Controls.Button b;

		// Token: 0x04000149 RID: 329
		internal System.Windows.Controls.TextBox A;

		// Token: 0x0400014A RID: 330
		internal System.Windows.Controls.ComboBox A;

		// Token: 0x0400014B RID: 331
		internal NumericUpDown A;

		// Token: 0x0400014C RID: 332
		internal System.Windows.Controls.Button C;

		// Token: 0x0400014D RID: 333
		internal System.Windows.Controls.DataGrid A;

		// Token: 0x0400014E RID: 334
		internal System.Windows.Controls.Button c;

		// Token: 0x0400014F RID: 335
		internal System.Windows.Controls.MenuItem A;

		// Token: 0x04000150 RID: 336
		internal System.Windows.Controls.MenuItem a;

		// Token: 0x04000151 RID: 337
		internal System.Windows.Controls.MenuItem B;

		// Token: 0x04000152 RID: 338
		internal System.Windows.Controls.MenuItem b;

		// Token: 0x04000153 RID: 339
		internal System.Windows.Controls.MenuItem C;

		// Token: 0x04000154 RID: 340
		internal System.Windows.Controls.Button D;

		// Token: 0x04000155 RID: 341
		internal System.Windows.Controls.Button d;

		// Token: 0x04000156 RID: 342
		internal System.Windows.Controls.Button E;

		// Token: 0x04000157 RID: 343
		internal System.Windows.Controls.GroupBox A;

		// Token: 0x04000158 RID: 344
		internal System.Windows.Controls.DataGrid a;

		// Token: 0x04000159 RID: 345
		internal System.Windows.Controls.Button e;

		// Token: 0x0400015A RID: 346
		internal System.Windows.Controls.Button F;

		// Token: 0x0400015B RID: 347
		internal ToggleSwitch A;

		// Token: 0x0400015C RID: 348
		internal ProfileStep A;

		// Token: 0x0400015D RID: 349
		internal System.Windows.Controls.DataGrid B;

		// Token: 0x0400015E RID: 350
		internal System.Windows.Controls.Button f;

		// Token: 0x0400015F RID: 351
		internal System.Windows.Controls.Button G;

		// Token: 0x04000160 RID: 352
		internal System.Windows.Controls.GroupBox a;

		// Token: 0x04000161 RID: 353
		internal System.Windows.Controls.ComboBox a;

		// Token: 0x04000162 RID: 354
		internal System.Windows.Controls.DataGrid b;

		// Token: 0x04000163 RID: 355
		internal System.Windows.Controls.Button g;

		// Token: 0x04000164 RID: 356
		internal System.Windows.Controls.Button H;

		// Token: 0x04000165 RID: 357
		private bool A;

		// Token: 0x02000057 RID: 87
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x0600027C RID: 636 RVA: 0x00008F01 File Offset: 0x00007101
			internal int A(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x0600027D RID: 637 RVA: 0x00008F01 File Offset: 0x00007101
			internal int a(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x0600027E RID: 638 RVA: 0x000093F5 File Offset: 0x000075F5
			internal int A(Dungeon dungeon_0, Dungeon dungeon_1)
			{
				return dungeon_0.Name.CompareTo(dungeon_1.Name);
			}

			// Token: 0x0600027F RID: 639 RVA: 0x00008F01 File Offset: 0x00007101
			internal int B(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x06000280 RID: 640 RVA: 0x00008F01 File Offset: 0x00007101
			internal int b(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x06000281 RID: 641 RVA: 0x00008F01 File Offset: 0x00007101
			internal int C(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x06000282 RID: 642 RVA: 0x00008F01 File Offset: 0x00007101
			internal int c(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x06000283 RID: 643 RVA: 0x00008F01 File Offset: 0x00007101
			internal int D(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x06000284 RID: 644 RVA: 0x00009408 File Offset: 0x00007608
			internal bool d(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.StepType.StepTypeName == "FollowPathStep";
			}

			// Token: 0x04000166 RID: 358
			public static readonly ProfileEditor.A A = new ProfileEditor.A();

			// Token: 0x04000167 RID: 359
			public static Func<DungeonStep, int> A;

			// Token: 0x04000168 RID: 360
			public static Func<DungeonStep, int> a;

			// Token: 0x04000169 RID: 361
			public static Comparison<Dungeon> A;

			// Token: 0x0400016A RID: 362
			public static Func<DungeonStep, int> B;

			// Token: 0x0400016B RID: 363
			public static Func<DungeonStep, int> b;

			// Token: 0x0400016C RID: 364
			public static Func<DungeonStep, int> C;

			// Token: 0x0400016D RID: 365
			public static Func<DungeonStep, int> c;

			// Token: 0x0400016E RID: 366
			public static Func<DungeonStep, int> D;

			// Token: 0x0400016F RID: 367
			public static Func<DungeonStep, bool> A;
		}

		// Token: 0x02000058 RID: 88
		[CompilerGenerated]
		private sealed class a
		{
			// Token: 0x06000286 RID: 646 RVA: 0x0000941F File Offset: 0x0000761F
			internal bool A(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order < this.A;
			}

			// Token: 0x04000170 RID: 368
			public int A;
		}

		// Token: 0x02000059 RID: 89
		[CompilerGenerated]
		private sealed class B
		{
			// Token: 0x06000288 RID: 648 RVA: 0x0000942F File Offset: 0x0000762F
			internal bool A(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order > this.A;
			}

			// Token: 0x04000171 RID: 369
			public int A;
		}
	}
}
