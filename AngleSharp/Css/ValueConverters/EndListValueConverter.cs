﻿namespace AngleSharp.Css.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AngleSharp.Extensions;
    using AngleSharp.Parser.Css;

    sealed class EndListValueConverter : IValueConverter
    {
        readonly IValueConverter _listConverter;
        readonly IValueConverter _endConverter;

        public EndListValueConverter(IValueConverter listConverter, IValueConverter endConverter)
        {
            _listConverter = listConverter;
            _endConverter = endConverter;
        }

        public IPropertyValue Convert(IEnumerable<CssToken> value)
        {
            var items = value.ToList();
            var n = items.Count - 1;
            var values = new IPropertyValue[n + 1];

            for (int i = 0; i < n; i++)
            {
                values[i] = _listConverter.Convert(items[i]);

                if (values[i] == null)
                    return null;
            }

            values[n] = _endConverter.Convert(items[n]);
            return values[n] != null ? new ListValue(values) : null;
        }

        sealed class ListValue : IPropertyValue
        {
            readonly IPropertyValue[] _values;

            public ListValue(IPropertyValue[] values)
            {
                _values = values;
            }

            public String CssText
            {
                get { return String.Join(", ", _values.Select(m => m.CssText)); }
            }
        }
    }
}
