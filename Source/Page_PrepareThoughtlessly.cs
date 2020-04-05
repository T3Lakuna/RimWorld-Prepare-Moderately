﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RimWorld;
using Verse;

namespace PrepareThoughtlessly {
	public class Page_PrepareThoughtlessly : Page {
		public Page_PrepareThoughtlessly() : base() {

		}

		public override void DoWindowContents(Rect inRect) {
			this.DrawPageTitle(inRect);

			Rect mainRect = this.GetMainRect(inRect);
			Widgets.DrawMenuSection(mainRect);

		}
	}
}
