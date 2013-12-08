using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace 春日
{
	public class OutlineTextControl : FrameworkElement
	{
		private Geometry _textGeometry;

		private Geometry _textHighLightGeometry;

		public readonly static DependencyProperty EnableFillProperty;

		public readonly static DependencyProperty OverFillProperty;

		public readonly static DependencyProperty OutlineJoinProperty;

		public readonly static DependencyProperty OutlineMiterLimitProperty;

		public readonly static DependencyProperty EnabledShadowProperty;

		public readonly static DependencyProperty ShadowProperty;

		public readonly static DependencyProperty ShadowDepthProperty;

		public readonly static DependencyProperty UnderlineProperty;

		public readonly static DependencyProperty StrikeoutProperty;

		public readonly static DependencyProperty ScaleXProperty;

		public readonly static DependencyProperty ScaleYProperty;

		public readonly static DependencyProperty CenterXProperty;

		public readonly static DependencyProperty CenterYProperty;

		public readonly static DependencyProperty AngleProperty;

		public readonly static DependencyProperty BoldProperty;

		public readonly static DependencyProperty FillProperty;

		public readonly static DependencyProperty FontProperty;

		public readonly static DependencyProperty FontSizeProperty;

		public readonly static DependencyProperty HighlightProperty;

		public readonly static DependencyProperty ItalicProperty;

		public readonly static DependencyProperty StrokeProperty;

		public readonly static DependencyProperty StrokeThicknessProperty;

		public readonly static DependencyProperty TextProperty;

		public double Angle
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.AngleProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.AngleProperty, value);
			}
		}

		public bool Bold
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.BoldProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.BoldProperty, value);
			}
		}

		public double CenterX
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.CenterXProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.CenterXProperty, value);
			}
		}

		public double CenterY
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.CenterYProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.CenterYProperty, value);
			}
		}

		public bool EnabledShadow
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.EnabledShadowProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.EnabledShadowProperty, value);
			}
		}

		public bool EnableFill
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.EnableFillProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.EnableFillProperty, value);
			}
		}

		public Brush Fill
		{
			get
			{
				return (Brush)base.GetValue(OutlineTextControl.FillProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.FillProperty, value);
			}
		}

		public FontFamily Font
		{
			get
			{
				return (FontFamily)base.GetValue(OutlineTextControl.FontProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.FontProperty, value);
			}
		}

		public double FontSize
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.FontSizeProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.FontSizeProperty, value);
			}
		}

		public bool Highlight
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.HighlightProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.HighlightProperty, value);
			}
		}

		public bool Italic
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.ItalicProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.ItalicProperty, value);
			}
		}

		public PenLineJoin OutlineJoin
		{
			get
			{
				return (PenLineJoin)base.GetValue(OutlineTextControl.OutlineJoinProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.OutlineJoinProperty, value);
			}
		}

		public double OutlineMiterLimit
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.OutlineMiterLimitProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.OutlineMiterLimitProperty, value);
			}
		}

		public bool OverFill
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.OverFillProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.OverFillProperty, value);
			}
		}

		public double ScaleX
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.ScaleXProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.ScaleXProperty, value);
			}
		}

		public double ScaleY
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.ScaleYProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.ScaleYProperty, value);
			}
		}

		public Brush Shadow
		{
			get
			{
				return (Brush)base.GetValue(OutlineTextControl.ShadowProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.ShadowProperty, value);
			}
		}

		public double ShadowDepth
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.ShadowDepthProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.ShadowDepthProperty, value);
			}
		}

		public bool Strikeout
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.StrikeoutProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.StrikeoutProperty, value);
			}
		}

		public Brush Stroke
		{
			get
			{
				return (Brush)base.GetValue(OutlineTextControl.StrokeProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.StrokeProperty, value);
			}
		}

		public double StrokeThickness
		{
			get
			{
				return (double)base.GetValue(OutlineTextControl.StrokeThicknessProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.StrokeThicknessProperty, value);
			}
		}

		public string Text
		{
			get
			{
				return (string)base.GetValue(OutlineTextControl.TextProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.TextProperty, value);
			}
		}

		public bool Underline
		{
			get
			{
				return (bool)base.GetValue(OutlineTextControl.UnderlineProperty);
			}
			set
			{
				base.SetValue(OutlineTextControl.UnderlineProperty, value);
			}
		}

		static OutlineTextControl()
		{
			OutlineTextControl.EnableFillProperty = DependencyProperty.Register("EnableFill", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.OverFillProperty = DependencyProperty.Register("OverFill", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.OutlineJoinProperty = DependencyProperty.Register("OutlineJoin", typeof(PenLineJoin), typeof(OutlineTextControl), new FrameworkPropertyMetadata((object)PenLineJoin.Round, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.OutlineMiterLimitProperty = DependencyProperty.Register("OutlineMiterLimit", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.EnabledShadowProperty = DependencyProperty.Register("EnabledShadow", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.ShadowProperty = DependencyProperty.Register("Shadow", typeof(Brush), typeof(OutlineTextControl), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
            OutlineTextControl.ShadowDepthProperty = DependencyProperty.Register("ShadowDepth", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.UnderlineProperty = DependencyProperty.Register("Underline", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.StrikeoutProperty = DependencyProperty.Register("Strikeout", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
            OutlineTextControl.ScaleXProperty = DependencyProperty.Register("ScaleX", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)1, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
            OutlineTextControl.ScaleYProperty = DependencyProperty.Register("ScaleY", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)1, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
            OutlineTextControl.CenterXProperty = DependencyProperty.Register("CenterX", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
            OutlineTextControl.CenterYProperty = DependencyProperty.Register("CenterY", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
            OutlineTextControl.AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.BoldProperty = DependencyProperty.Register("Bold", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(OutlineTextControl), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.LightSteelBlue), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.FontProperty = DependencyProperty.Register("Font", typeof(FontFamily), typeof(OutlineTextControl), new FrameworkPropertyMetadata(new FontFamily("Arial"), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)48, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.HighlightProperty = DependencyProperty.Register("Highlight", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.ItalicProperty = DependencyProperty.Register("Italic", typeof(bool), typeof(OutlineTextControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(OutlineTextControl), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Teal), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
            OutlineTextControl.StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(OutlineTextControl), new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
			OutlineTextControl.TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(OutlineTextControl), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OutlineTextControl.OnOutlineTextInvalidated), null));
		}

		public OutlineTextControl()
		{
		}

		public void CreateText()
		{
			FontStyle normal = FontStyles.Normal;
			FontWeight medium = FontWeights.Medium;
			if (this.Bold)
			{
				medium = FontWeights.Bold;
			}
			if (this.Italic)
			{
				normal = FontStyles.Italic;
			}
			FormattedText formattedText = new FormattedText(this.Text, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, new Typeface(this.Font, normal, medium, FontStretches.Normal), this.FontSize, Brushes.Black);
			TextDecorationCollection textDecorationCollections = new TextDecorationCollection();
			if (this.Underline)
			{
				textDecorationCollections.Add(TextDecorations.Underline);
			}
			if (this.Strikeout)
			{
				textDecorationCollections.Add(TextDecorations.Strikethrough);
			}
			formattedText.SetTextDecorations(textDecorationCollections);
			this._textGeometry = formattedText.BuildGeometry(new Point(0, 0));
			this._textHighLightGeometry = formattedText.BuildHighlightGeometry(new Point(0, 0));
		}

		protected override Size MeasureOverride(Size a)
		{
			if (this._textHighLightGeometry == null)
			{
				return new Size(0, 0);
			}
			Size size = this._textHighLightGeometry.Bounds.Size;
			return this._textHighLightGeometry.Bounds.Size;
		}

		private static void OnOutlineTextInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((OutlineTextControl)d).CreateText();
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			Pen pen = new Pen(this.Stroke, this.StrokeThickness);
			Pen outlineJoin = new Pen(this.Shadow, this.StrokeThickness);
			pen.LineJoin = this.OutlineJoin;
			outlineJoin.LineJoin = this.OutlineJoin;
			if (pen.LineJoin == PenLineJoin.Miter)
			{
				pen.MiterLimit = this.OutlineMiterLimit;
			}
			if (outlineJoin.LineJoin == PenLineJoin.Miter)
			{
				outlineJoin.MiterLimit = this.OutlineMiterLimit;
			}
			drawingContext.PushTransform(new ScaleTransform(this.ScaleX, this.ScaleY, this.CenterX, this.CenterY));
			drawingContext.PushTransform(new RotateTransform(this.Angle));
			if (this.EnabledShadow)
			{
				drawingContext.PushTransform(new TranslateTransform(this.ShadowDepth, this.ShadowDepth));
				drawingContext.DrawGeometry(this.Shadow, outlineJoin, this._textGeometry);
				drawingContext.Pop();
			}
			if (!this.EnableFill)
			{
				drawingContext.DrawGeometry(null, pen, this._textGeometry);
			}
			else if (!this.OverFill)
			{
				drawingContext.DrawGeometry(this.Fill, pen, this._textGeometry);
			}
			else
			{
				drawingContext.DrawGeometry(null, pen, this._textGeometry);
				drawingContext.DrawGeometry(this.Fill, null, this._textGeometry);
			}
			if (this.Highlight)
			{
				drawingContext.DrawGeometry(null, new Pen(this.Stroke, this.StrokeThickness), this._textHighLightGeometry);
			}
		}
	}
}