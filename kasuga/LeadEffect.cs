using System;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	[Serializable]
	public class LeadEffect
	{
		public static LeadEffect SlideLeadIn;

		public static LeadEffect SlideLeadOut;

		public PlayTimeSpan Duration
		{
			get;
			set;
		}

		public string Expression
		{
			get;
			set;
		}

		public PlayTimeSpan Offset
		{
			get;
			set;
		}

		public double Speed
		{
			get;
			set;
		}

		static LeadEffect()
		{
			LeadEffect.SlideLeadIn = new LeadEffect(new PlayTimeSpan(new double?(0.4)), new PlayTimeSpan(new double?(0.2)), 1.5, "{\\fad(200,0)}{\\move(!$Center-40!,$Middle,$Center,$Middle)}{\\fscx150\\fscy80\\1c&HFFFFFF&\\3c&H00D7FF&}{\\t(\\fscx100\\fscy100\\1c$PrimaryColor\\3c$BorderColor)}");
			LeadEffect.SlideLeadOut = new LeadEffect(new PlayTimeSpan(new double?(-0.3)), new PlayTimeSpan(new double?(0.2)), 1.5, "{\\fad(0,200)}{\\move($Center,$Middle,!$Center+40!,$Middle)}{\\t(\\fscx150\\fscy80\\1c&HFFFFFF&\\3c&H00D7FF)}");
		}

		public LeadEffect()
		{
		}

		public LeadEffect(PlayTimeSpan offset, PlayTimeSpan duration, double speed, string expression)
		{
			this.Offset = offset;
			this.Duration = duration;
			this.Speed = speed;
			this.Expression = expression;
		}
	}
}