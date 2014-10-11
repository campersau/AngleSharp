﻿namespace AngleSharp.DOM.Css
{
    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-bottom
    /// </summary>
    sealed class CSSPaddingBottomProperty : CSSPaddingPartProperty, ICssPaddingBottomProperty
    {
        #region ctor

        internal CSSPaddingBottomProperty()
            : base(PropertyNames.PaddingBottom)
        {
        }

        #endregion

        #region Property

        public IDistance Bottom
        {
            get { return Padding; }
        }

        #endregion
    }
}
