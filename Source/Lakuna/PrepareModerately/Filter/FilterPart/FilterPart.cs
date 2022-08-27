using System.Collections.Generic;
using Lakuna.PrepareModerately.UI;
using Verse;

namespace Lakuna.PrepareModerately.Filter.FilterPart {
	public abstract class FilterPart : IExposable {
		[TranslationHandle]
		public FilterPartDef def;

		public bool visible;

		public bool summarized;

		public static float RowHeight => Text.LineHeight;

		public virtual string Label => this.def.label;

		public virtual void ExposeData() {
			Scribe_Defs.Look(ref this.def, nameof(this.def));
		}

		public FilterPart CopyForEditing() {
			FilterPart filterPart = this.CopyForEditingInner();
			filterPart.def = this.def;
			return filterPart;
		}

		protected virtual FilterPart CopyForEditingInner() {
			return (FilterPart)this.MemberwiseClone();
		}

		public virtual void DoEditInterface(FilterEditListing listing) {
			listing.GetFilterPartRect(this, FilterPart.RowHeight);
		}

		public virtual string Summary(Filter filter) {
			return this.def.description;
		}

		public virtual IEnumerable<string> GetSummaryListEntries(string tag) {
			yield break;
		}

		public virtual void Randomize() { }

		public virtual bool TryMerge(FilterPart other) {
			return false;
		}

		public virtual bool CanCoexistWith(FilterPart other) {
			return true;
		}

		public virtual bool Matches(Pawn pawn) {
			return true;
		}

		public virtual IEnumerable<string> ConfigErrors() {
			if (this.def == null) {
				yield return "TypeHasNullDef".Translate(this.GetType().ToString());
			}
		}

		public virtual bool HasNullDefs() {
			return this.def == null;
		}

		public FilterPart() {
			this.visible = true;
		}
	}
}
