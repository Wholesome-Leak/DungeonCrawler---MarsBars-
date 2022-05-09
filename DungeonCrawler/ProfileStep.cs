using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MahApps.Metro.Controls;
using robotManager.Helpful;
using wManager.Wow.ObjectManager;

namespace DungeonCrawler
{
	// Token: 0x0200005B RID: 91
	public class ProfileStep : UserControl, INotifyPropertyChanged, IComponentConnector
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00018F18 File Offset: 0x00017118
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00009446 File Offset: 0x00007646
		public DungeonStep SelectedItem
		{
			get
			{
				return this.A;
			}
			set
			{
				this.A = value;
				this.OnPropertyChanged("SelectedItem");
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000945A File Offset: 0x0000765A
		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.A;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs(name));
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600028F RID: 655 RVA: 0x00009474 File Offset: 0x00007674
		// (set) Token: 0x06000290 RID: 656 RVA: 0x0000947C File Offset: 0x0000767C
		public ObservableCollection<Vector3> fpsCollection { get; set; }

		// Token: 0x06000291 RID: 657 RVA: 0x00018F30 File Offset: 0x00017130
		public ProfileStep()
		{
			this.InitializeComponent();
			this.SelectedItem = new DungeonStep();
			base.DataContext = this;
			ProfileStep.A = new System.Timers.Timer(200.0);
			ProfileStep.A.Elapsed += this.A;
			ProfileStep.A.AutoReset = true;
			ProfileStep.A.Enabled = true;
			this.A.ItemsSource = Enum.GetValues(typeof(ConditionType));
			if (this.A.SelectedItem != null)
			{
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00018FC4 File Offset: 0x000171C4
		private void A(object sender, ElapsedEventArgs e)
		{
			try
			{
				base.Dispatcher.Invoke(new Action(this.A));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000293 RID: 659 RVA: 0x00019020 File Offset: 0x00017220
		// (remove) Token: 0x06000294 RID: 660 RVA: 0x00019058 File Offset: 0x00017258
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

		// Token: 0x06000295 RID: 661 RVA: 0x00019090 File Offset: 0x00017290
		private void A(object sender, RoutedEventArgs e)
		{
			try
			{
				this.fpsCollection.Add(ObjectManager.Me.Position);
				((FollowPathStep)this.SelectedItem.StepType).Path = this.fpsCollection.ToList<Vector3>();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0001910C File Offset: 0x0001730C
		private void a(object sender, RoutedEventArgs e)
		{
			if (this.A.SelectedItem != null)
			{
				this.fpsCollection.Remove((Vector3)this.A.SelectedItem);
				((FollowPathStep)this.SelectedItem.StepType).Path = this.fpsCollection.ToList<Vector3>();
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00019168 File Offset: 0x00017368
		private void B(object sender, RoutedEventArgs e)
		{
			WoWGameObject nearestWoWGameObject = ObjectManager.GetNearestWoWGameObject(ObjectManager.GetObjectWoWGameObject(), true, true);
			if (nearestWoWGameObject != null)
			{
				this.c.Value = new double?((double)nearestWoWGameObject.Entry);
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000191A0 File Offset: 0x000173A0
		private void b(object sender, RoutedEventArgs e)
		{
			WoWUnit target = ObjectManager.Target;
			if (target != null)
			{
				this.D.Value = new double?((double)target.Entry);
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x000083B0 File Offset: 0x000065B0
		private void A(object sender, SelectionChangedEventArgs e)
		{
		}

		// Token: 0x0600029A RID: 666 RVA: 0x000191D0 File Offset: 0x000173D0
		private void C(object sender, RoutedEventArgs e)
		{
			WoWGameObject nearestWoWGameObject = ObjectManager.GetNearestWoWGameObject(ObjectManager.GetObjectWoWGameObject(), true, true);
			if (nearestWoWGameObject != null)
			{
				this.A.Value = new double?((double)nearestWoWGameObject.FlagsInt);
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00019208 File Offset: 0x00017408
		private void c(object sender, RoutedEventArgs e)
		{
			WoWGameObject nearestWoWGameObject = ObjectManager.GetNearestWoWGameObject(ObjectManager.GetObjectWoWGameObject(), true, true);
			if (nearestWoWGameObject != null)
			{
				this.a.Value = new double?((double)nearestWoWGameObject.Entry);
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00019240 File Offset: 0x00017440
		private void D(object sender, RoutedEventArgs e)
		{
			WoWUnit target = ObjectManager.Target;
			if (target != null)
			{
				this.d.Value = new double?((double)target.Entry);
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00019270 File Offset: 0x00017470
		private void d(object sender, RoutedEventArgs e)
		{
			WoWUnit target = ObjectManager.Target;
			if (target != null)
			{
				this.a.Text = string.Format("{0},{1},{2}", target.Position.X, target.Position.Y, target.Position.Z);
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x000192D0 File Offset: 0x000174D0
		private void E(object sender, RoutedEventArgs e)
		{
			WoWUnit target = ObjectManager.Target;
			if (target != null)
			{
				this.B.Value = new double?((double)target.Entry);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00019300 File Offset: 0x00017500
		private void e(object sender, RoutedEventArgs e)
		{
			WoWUnit target = ObjectManager.Target;
			if (target != null)
			{
				this.b.Value = new double?((double)target.Entry);
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00019330 File Offset: 0x00017530
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.A)
			{
				this.A = true;
				Uri resourceLocator = new Uri("/DungeonCrawler;component/gui/profilestep.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00019360 File Offset: 0x00017560
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.A(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.A = (ProfileStep)target;
				break;
			case 2:
				this.A = (TextBox)target;
				break;
			case 3:
				this.A = (ToggleSwitch)target;
				break;
			case 4:
				this.A = (StackPanel)target;
				break;
			case 5:
				this.A = (ComboBox)target;
				this.A.SelectionChanged += this.A;
				break;
			case 6:
				this.a = (StackPanel)target;
				break;
			case 7:
				this.B = (StackPanel)target;
				break;
			case 8:
				this.A = (NumericUpDown)target;
				break;
			case 9:
				this.A = (Button)target;
				this.A.Click += this.C;
				break;
			case 10:
				this.b = (StackPanel)target;
				break;
			case 11:
				this.a = (NumericUpDown)target;
				break;
			case 12:
				this.a = (Button)target;
				this.a.Click += this.c;
				break;
			case 13:
				this.C = (StackPanel)target;
				break;
			case 14:
				this.B = (NumericUpDown)target;
				break;
			case 15:
				this.B = (Button)target;
				this.B.Click += this.E;
				break;
			case 16:
				this.c = (StackPanel)target;
				break;
			case 17:
				this.a = (TextBox)target;
				break;
			case 18:
				this.b = (Button)target;
				this.b.Click += this.d;
				break;
			case 19:
				this.D = (StackPanel)target;
				break;
			case 20:
				this.b = (NumericUpDown)target;
				break;
			case 21:
				this.C = (Button)target;
				this.C.Click += this.e;
				break;
			case 22:
				this.C = (NumericUpDown)target;
				break;
			case 23:
				this.A = (DataGrid)target;
				break;
			case 24:
				this.c = (Button)target;
				this.c.Click += this.A;
				break;
			case 25:
				this.D = (Button)target;
				this.D.Click += this.a;
				break;
			case 26:
				this.a = (ToggleSwitch)target;
				break;
			case 27:
				this.c = (NumericUpDown)target;
				break;
			case 28:
				this.d = (Button)target;
				this.d.Click += this.B;
				break;
			case 29:
				this.D = (NumericUpDown)target;
				break;
			case 30:
				this.E = (Button)target;
				this.E.Click += this.b;
				break;
			case 31:
				this.d = (NumericUpDown)target;
				break;
			case 32:
				this.e = (Button)target;
				this.e.Click += this.D;
				break;
			default:
				this.A = true;
				break;
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00019714 File Offset: 0x00017914
		[CompilerGenerated]
		private void A()
		{
			if (base.IsVisible && this.a.IsChecked.Value && (this.fpsCollection.Count == 0 || this.fpsCollection.LastOrDefault<Vector3>().DistanceTo(ObjectManager.Me.Position) > 8f))
			{
				this.fpsCollection.Add(ObjectManager.Me.Position);
				((FollowPathStep)this.SelectedItem.StepType).Path = this.fpsCollection.ToList<Vector3>();
			}
		}

		// Token: 0x04000172 RID: 370
		private DungeonStep A;

		// Token: 0x04000173 RID: 371
		private static System.Timers.Timer A;

		// Token: 0x04000174 RID: 372
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<Vector3> A;

		// Token: 0x04000175 RID: 373
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PropertyChangedEventHandler A;

		// Token: 0x04000176 RID: 374
		internal ProfileStep A;

		// Token: 0x04000177 RID: 375
		internal TextBox A;

		// Token: 0x04000178 RID: 376
		internal ToggleSwitch A;

		// Token: 0x04000179 RID: 377
		internal StackPanel A;

		// Token: 0x0400017A RID: 378
		internal ComboBox A;

		// Token: 0x0400017B RID: 379
		internal StackPanel a;

		// Token: 0x0400017C RID: 380
		internal StackPanel B;

		// Token: 0x0400017D RID: 381
		internal NumericUpDown A;

		// Token: 0x0400017E RID: 382
		internal Button A;

		// Token: 0x0400017F RID: 383
		internal StackPanel b;

		// Token: 0x04000180 RID: 384
		internal NumericUpDown a;

		// Token: 0x04000181 RID: 385
		internal Button a;

		// Token: 0x04000182 RID: 386
		internal StackPanel C;

		// Token: 0x04000183 RID: 387
		internal NumericUpDown B;

		// Token: 0x04000184 RID: 388
		internal Button B;

		// Token: 0x04000185 RID: 389
		internal StackPanel c;

		// Token: 0x04000186 RID: 390
		internal TextBox a;

		// Token: 0x04000187 RID: 391
		internal Button b;

		// Token: 0x04000188 RID: 392
		internal StackPanel D;

		// Token: 0x04000189 RID: 393
		internal NumericUpDown b;

		// Token: 0x0400018A RID: 394
		internal Button C;

		// Token: 0x0400018B RID: 395
		internal NumericUpDown C;

		// Token: 0x0400018C RID: 396
		internal DataGrid A;

		// Token: 0x0400018D RID: 397
		internal Button c;

		// Token: 0x0400018E RID: 398
		internal Button D;

		// Token: 0x0400018F RID: 399
		internal ToggleSwitch a;

		// Token: 0x04000190 RID: 400
		internal NumericUpDown c;

		// Token: 0x04000191 RID: 401
		internal Button d;

		// Token: 0x04000192 RID: 402
		internal NumericUpDown D;

		// Token: 0x04000193 RID: 403
		internal Button E;

		// Token: 0x04000194 RID: 404
		internal NumericUpDown d;

		// Token: 0x04000195 RID: 405
		internal Button e;

		// Token: 0x04000196 RID: 406
		private bool A;
	}
}
