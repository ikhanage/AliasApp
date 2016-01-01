using Xamarin.Forms;

namespace Alia
{
	public abstract class CachedCell : ViewCell
	{
		public bool IsInitialized {
			get;
			private set;
		}
			
		public void PrepareCell ()
		{
			InitializeCell ();
			if (BindingContext != null) {
				SetupCell (false);
			}
			IsInitialized = true;
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			if (IsInitialized) {
				SetupCell (true);
			}
		}

		protected abstract void InitializeCell ();

		protected abstract void SetupCell (bool isRecycled);

		internal object OriginalBindingContext;
	}
}