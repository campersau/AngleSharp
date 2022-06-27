namespace AngleSharp.Dom.Html
{
    using AngleSharp.Dom.Collections;
    using AngleSharp.Dom.Css;
    using AngleSharp.Dom.Events;
    using AngleSharp.Extensions;
    using AngleSharp.Html;
    using AngleSharp.Network;
    using AngleSharp.Services;
    using AngleSharp.Services.Scripting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a standard HTML element in the node tree.
    /// </summary>
    class HtmlElement : Element, IHtmlElement
    {
        #region Fields

        private StringMap _dataset;
        private IHtmlMenuElement _menu;
        private SettableTokenList _dropZone;

        #endregion

        #region Events

        public event DomEventHandler Aborted
        {
            add { AddEventListener(EventNames.Abort, value); }
            remove { RemoveEventListener(EventNames.Abort, value); }
        }

        public event DomEventHandler Blurred
        {
            add { AddEventListener(EventNames.Blur, value); }
            remove { RemoveEventListener(EventNames.Blur, value); }
        }

        public event DomEventHandler Cancelled
        {
            add { AddEventListener(EventNames.Cancel, value); }
            remove { RemoveEventListener(EventNames.Cancel, value); }
        }

        public event DomEventHandler CanPlay
        {
            add { AddEventListener(EventNames.CanPlay, value); }
            remove { RemoveEventListener(EventNames.CanPlay, value); }
        }

        public event DomEventHandler CanPlayThrough
        {
            add { AddEventListener(EventNames.CanPlayThrough, value); }
            remove { RemoveEventListener(EventNames.CanPlayThrough, value); }
        }

        public event DomEventHandler Changed
        {
            add { AddEventListener(EventNames.Change, value); }
            remove { RemoveEventListener(EventNames.Change, value); }
        }

        public event DomEventHandler Clicked
        {
            add { AddEventListener(EventNames.Click, value); }
            remove { RemoveEventListener(EventNames.Click, value); }
        }

        public event DomEventHandler CueChanged
        {
            add { AddEventListener(EventNames.CueChange, value); }
            remove { RemoveEventListener(EventNames.CueChange, value); }
        }

        public event DomEventHandler DoubleClick
        {
            add { AddEventListener(EventNames.DblClick, value); }
            remove { RemoveEventListener(EventNames.DblClick, value); }
        }

        public event DomEventHandler Drag
        {
            add { AddEventListener(EventNames.Drag, value); }
            remove { RemoveEventListener(EventNames.Drag, value); }
        }

        public event DomEventHandler DragEnd
        {
            add { AddEventListener(EventNames.DragEnd, value); }
            remove { RemoveEventListener(EventNames.DragEnd, value); }
        }

        public event DomEventHandler DragEnter
        {
            add { AddEventListener(EventNames.DragEnter, value); }
            remove { RemoveEventListener(EventNames.DragEnter, value); }
        }

        public event DomEventHandler DragExit
        {
            add { AddEventListener(EventNames.DragExit, value); }
            remove { RemoveEventListener(EventNames.DragExit, value); }
        }

        public event DomEventHandler DragLeave
        {
            add { AddEventListener(EventNames.DragLeave, value); }
            remove { RemoveEventListener(EventNames.DragLeave, value); }
        }

        public event DomEventHandler DragOver
        {
            add { AddEventListener(EventNames.DragOver, value); }
            remove { RemoveEventListener(EventNames.DragOver, value); }
        }

        public event DomEventHandler DragStart
        {
            add { AddEventListener(EventNames.DragStart, value); }
            remove { RemoveEventListener(EventNames.DragStart, value); }
        }

        public event DomEventHandler Dropped
        {
            add { AddEventListener(EventNames.Drop, value); }
            remove { RemoveEventListener(EventNames.Drop, value); }
        }

        public event DomEventHandler DurationChanged
        {
            add { AddEventListener(EventNames.DurationChange, value); }
            remove { RemoveEventListener(EventNames.DurationChange, value); }
        }

        public event DomEventHandler Emptied
        {
            add { AddEventListener(EventNames.Emptied, value); }
            remove { RemoveEventListener(EventNames.Emptied, value); }
        }

        public event DomEventHandler Ended
        {
            add { AddEventListener(EventNames.Ended, value); }
            remove { RemoveEventListener(EventNames.Ended, value); }
        }

        public event DomEventHandler Error
        {
            add { AddEventListener(EventNames.Error, value); }
            remove { RemoveEventListener(EventNames.Error, value); }
        }

        public event DomEventHandler Focused
        {
            add { AddEventListener(EventNames.Focus, value); }
            remove { RemoveEventListener(EventNames.Focus, value); }
        }

        public event DomEventHandler Input
        {
            add { AddEventListener(EventNames.Input, value); }
            remove { RemoveEventListener(EventNames.Input, value); }
        }

        public event DomEventHandler Invalid
        {
            add { AddEventListener(EventNames.Invalid, value); }
            remove { RemoveEventListener(EventNames.Invalid, value); }
        }

        public event DomEventHandler KeyDown
        {
            add { AddEventListener(EventNames.Keydown, value); }
            remove { RemoveEventListener(EventNames.Keydown, value); }
        }

        public event DomEventHandler KeyPress
        {
            add { AddEventListener(EventNames.Keypress, value); }
            remove { RemoveEventListener(EventNames.Keypress, value); }
        }

        public event DomEventHandler KeyUp
        {
            add { AddEventListener(EventNames.Keyup, value); }
            remove { RemoveEventListener(EventNames.Keyup, value); }
        }

        public event DomEventHandler Loaded
        {
            add { AddEventListener(EventNames.Load, value); }
            remove { RemoveEventListener(EventNames.Load, value); }
        }

        public event DomEventHandler LoadedData
        {
            add { AddEventListener(EventNames.LoadedData, value); }
            remove { RemoveEventListener(EventNames.LoadedData, value); }
        }

        public event DomEventHandler LoadedMetadata
        {
            add { AddEventListener(EventNames.LoadedMetaData, value); }
            remove { RemoveEventListener(EventNames.LoadedMetaData, value); }
        }

        public event DomEventHandler Loading
        {
            add { AddEventListener(EventNames.LoadStart, value); }
            remove { RemoveEventListener(EventNames.LoadStart, value); }
        }

        public event DomEventHandler MouseDown
        {
            add { AddEventListener(EventNames.Mousedown, value); }
            remove { RemoveEventListener(EventNames.Mousedown, value); }
        }

        public event DomEventHandler MouseEnter
        {
            add { AddEventListener(EventNames.Mouseenter, value); }
            remove { RemoveEventListener(EventNames.Mouseenter, value); }
        }

        public event DomEventHandler MouseLeave
        {
            add { AddEventListener(EventNames.Mouseleave, value); }
            remove { RemoveEventListener(EventNames.Mouseleave, value); }
        }

        public event DomEventHandler MouseMove
        {
            add { AddEventListener(EventNames.Mousemove, value); }
            remove { RemoveEventListener(EventNames.Mousemove, value); }
        }

        public event DomEventHandler MouseOut
        {
            add { AddEventListener(EventNames.Mouseout, value); }
            remove { RemoveEventListener(EventNames.Mouseout, value); }
        }

        public event DomEventHandler MouseOver
        {
            add { AddEventListener(EventNames.Mouseover, value); }
            remove { RemoveEventListener(EventNames.Mouseover, value); }
        }

        public event DomEventHandler MouseUp
        {
            add { AddEventListener(EventNames.Mouseup, value); }
            remove { RemoveEventListener(EventNames.Mouseup, value); }
        }

        public event DomEventHandler MouseWheel
        {
            add { AddEventListener(EventNames.Wheel, value); }
            remove { RemoveEventListener(EventNames.Wheel, value); }
        }

        public event DomEventHandler Paused
        {
            add { AddEventListener(EventNames.Pause, value); }
            remove { RemoveEventListener(EventNames.Pause, value); }
        }

        public event DomEventHandler Played
        {
            add { AddEventListener(EventNames.Play, value); }
            remove { RemoveEventListener(EventNames.Play, value); }
        }

        public event DomEventHandler Playing
        {
            add { AddEventListener(EventNames.Playing, value); }
            remove { RemoveEventListener(EventNames.Playing, value); }
        }

        public event DomEventHandler Progress
        {
            add { AddEventListener(EventNames.Progress, value); }
            remove { RemoveEventListener(EventNames.Progress, value); }
        }

        public event DomEventHandler RateChanged
        {
            add { AddEventListener(EventNames.RateChange, value); }
            remove { RemoveEventListener(EventNames.RateChange, value); }
        }

        public event DomEventHandler Resetted
        {
            add { AddEventListener(EventNames.Reset, value); }
            remove { RemoveEventListener(EventNames.Reset, value); }
        }

        public event DomEventHandler Resized
        {
            add { AddEventListener(EventNames.Resize, value); }
            remove { RemoveEventListener(EventNames.Resize, value); }
        }

        public event DomEventHandler Scrolled
        {
            add { AddEventListener(EventNames.Scroll, value); }
            remove { RemoveEventListener(EventNames.Scroll, value); }
        }

        public event DomEventHandler Seeked
        {
            add { AddEventListener(EventNames.Seeked, value); }
            remove { RemoveEventListener(EventNames.Seeked, value); }
        }

        public event DomEventHandler Seeking
        {
            add { AddEventListener(EventNames.Seeking, value); }
            remove { RemoveEventListener(EventNames.Seeking, value); }
        }

        public event DomEventHandler Selected
        {
            add { AddEventListener(EventNames.Select, value); }
            remove { RemoveEventListener(EventNames.Select, value); }
        }

        public event DomEventHandler Shown
        {
            add { AddEventListener(EventNames.Show, value); }
            remove { RemoveEventListener(EventNames.Show, value); }
        }

        public event DomEventHandler Stalled
        {
            add { AddEventListener(EventNames.Stalled, value); }
            remove { RemoveEventListener(EventNames.Stalled, value); }
        }

        public event DomEventHandler Submitted
        {
            add { AddEventListener(EventNames.Submit, value); }
            remove { RemoveEventListener(EventNames.Submit, value); }
        }

        public event DomEventHandler Suspended
        {
            add { AddEventListener(EventNames.Suspend, value); }
            remove { RemoveEventListener(EventNames.Suspend, value); }
        }

        public event DomEventHandler TimeUpdated
        {
            add { AddEventListener(EventNames.TimeUpdate, value); }
            remove { RemoveEventListener(EventNames.TimeUpdate, value); }
        }

        public event DomEventHandler Toggled
        {
            add { AddEventListener(EventNames.Toggle, value); }
            remove { RemoveEventListener(EventNames.Toggle, value); }
        }

        public event DomEventHandler VolumeChanged
        {
            add { AddEventListener(EventNames.VolumeChange, value); }
            remove { RemoveEventListener(EventNames.VolumeChange, value); }
        }

        public event DomEventHandler Waiting
        {
            add { AddEventListener(EventNames.Waiting, value); }
            remove { RemoveEventListener(EventNames.Waiting, value); }
        }

        #endregion

        #region ctor

        public HtmlElement(Document owner, String localName, String prefix = null, NodeFlags flags = NodeFlags.None)
            : base(owner, Combine(prefix, localName), localName, prefix, NamespaceNames.HtmlUri, flags | NodeFlags.HtmlMember)
        {
        }

        #endregion

        #region Properties

        public Boolean IsHidden
        {
            get { return this.GetBoolAttribute(AttributeNames.Hidden); }
            set { this.SetBoolAttribute(AttributeNames.Hidden, value); }
        }

        public IHtmlMenuElement ContextMenu
        {
            get
            {
                if (_menu == null)
                {
                    var id = this.GetOwnAttribute(AttributeNames.ContextMenu);

                    if (!String.IsNullOrEmpty(id))
                    {
                        return Owner.GetElementById(id) as IHtmlMenuElement;
                    }
                }

                return _menu;
            }
            set { _menu = value; }
        }

        public ISettableTokenList DropZone
        {
            get
            {
                if (_dropZone == null)
                {
                    _dropZone = new SettableTokenList(this.GetOwnAttribute(AttributeNames.DropZone));
                    _dropZone.Changed += value => UpdateAttribute(AttributeNames.DropZone, value);
                }

                return _dropZone;
            }
        }

        public Boolean IsDraggable
        {
            get { return this.GetOwnAttribute(AttributeNames.Draggable).ToBoolean(false); }
            set { this.SetOwnAttribute(AttributeNames.Draggable, value.ToString()); }
        }

        public String AccessKey
        {
            get { return this.GetOwnAttribute(AttributeNames.AccessKey) ?? String.Empty; }
            set { this.SetOwnAttribute(AttributeNames.AccessKey, value); }
        }

        public String AccessKeyLabel
        {
            get { return AccessKey; }
        }

        public String Language
        {
            get { return this.GetOwnAttribute(AttributeNames.Lang) ?? GetDefaultLanguage(); }
            set { this.SetOwnAttribute(AttributeNames.Lang, value); }
        }

        public String Title
        {
            get { return this.GetOwnAttribute(AttributeNames.Title); }
            set { this.SetOwnAttribute(AttributeNames.Title, value); }
        }

        public String Direction
        {
            get { return this.GetOwnAttribute(AttributeNames.Dir); }
            set { this.SetOwnAttribute(AttributeNames.Dir, value); }
        }

        public Boolean IsSpellChecked
        {
            get { return this.GetOwnAttribute(AttributeNames.Spellcheck).ToBoolean(false); }
            set { this.SetOwnAttribute(AttributeNames.Spellcheck, value.ToString()); }
        }

        public Int32 TabIndex
        {
            get { return this.GetOwnAttribute(AttributeNames.TabIndex).ToInteger(0); }
            set { this.SetOwnAttribute(AttributeNames.TabIndex, value.ToString()); }
        }

        public IStringMap Dataset
        {
            get { return _dataset ?? (_dataset = new StringMap("data-", this)); }
        }

        public String ContentEditable
        {
            get { return this.GetOwnAttribute(AttributeNames.ContentEditable); }
            set { this.SetOwnAttribute(AttributeNames.ContentEditable, value); }
        }

        public Boolean IsContentEditable
        {
            get
            {
                var value = ContentEditable.ToEnum(ContentEditableMode.Inherited);

                if (value != ContentEditableMode.True)
                {
                    var parent = ParentElement as IHtmlElement;

                    if (value == ContentEditableMode.Inherited && parent != null)
                    {
                        return parent.IsContentEditable;
                    }

                    return false;
                }

                return true;
            }
        }

        public Boolean IsTranslated
        {
            get { return this.GetOwnAttribute(AttributeNames.Translate).ToEnum(SimpleChoice.Yes) == SimpleChoice.Yes; }
            set { this.SetOwnAttribute(AttributeNames.Translate, value ? Keywords.Yes : Keywords.No); }
        }

        public String InnerText
        {
            get
            {
                var sb = Pool.NewStringBuilder();
                var result = new ElementInnerTextCollector(sb).RunOn(this);
                sb.ToPool();
                return result;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    ReplaceAll(null, false);
                }
                else
                {
                    var fragment = new DocumentFragment(Owner);

                    var sb = Pool.NewStringBuilder();
                    for (var i = 0; i < value.Length; i++)
                    {
                        var c = value[i];

                        if (c == Symbols.LineFeed || c == Symbols.CarriageReturn)
                        {
                            if (c == Symbols.CarriageReturn && i + 1 < value.Length && value[i + 1] == Symbols.LineFeed)
                            {
                                continue; // ignore carriage return if the next char is a line feed
                            }

                            if (sb.Length > 0)
                            {
                                fragment.AppendChild(new TextNode(Owner, sb.ToPool()));
                                sb = Pool.NewStringBuilder();
                            }
                            fragment.AppendChild(new HtmlBreakRowElement(Owner));
                        }
                        else
                        {
                            sb.Append(c);
                        }
                    }

                    var remaining = sb.ToPool();
                    if (remaining.Length > 0)
                    {
                        fragment.Append(new TextNode(Owner, remaining));
                    }

                    ReplaceAll(fragment, false);
                }
            }
        }

        private class ElementInnerTextStringBuilder
        {
            private readonly StringBuilder _stringBuilder;
            private int _requiredLineBreakCount;
            private char _lastWhiteSpaceChar;

            public ElementInnerTextStringBuilder(StringBuilder stringBuilder)
            {
                _stringBuilder = stringBuilder;
            }

            public void EmitNewline()
            {
                FlushRequiredLineBreak();
                _stringBuilder.Append(Symbols.LineFeed);
                _lastWhiteSpaceChar = Symbols.LineFeed;
            }

            public void EmitRequiredLineBreak(int count)
            {
                if (count == 0)
                {
                    return;
                }
                if (_stringBuilder.Length == 0)
                {
                    return;
                }
                _requiredLineBreakCount = Math.Max(_requiredLineBreakCount, count);
            }

            public void EmitTab()
            {
                FlushRequiredLineBreak();
                _stringBuilder.Append(Symbols.Tab);
                _lastWhiteSpaceChar = Symbols.Tab;
            }

            public void EmitText(String text, string whiteSpace = null, string textTransform = null)
            {
                if (text.Length == 0)
                {
                    return;
                }

                var lastWhiteSpaceChar = _lastWhiteSpaceChar;

                for (var i = 0; i < text.Length; i++)
                {
                    var c = text[i];

                    if (Char.IsWhiteSpace(c) && c != Symbols.NoBreakSpace)
                    {
                        // https://drafts.csswg.org/css-text/#white-space-property
                        switch (whiteSpace)
                        {
                            case "pre":
                            case "pre-wrap":
                            case "break-spaces":
                                break;
                            case "pre-line":
                                if (c == Symbols.Space || c == Symbols.Tab)
                                {
                                    lastWhiteSpaceChar = Symbols.Space;
                                    continue;
                                }
                                break;
                            case "nowrap":
                            case "normal":
                            default:
                                lastWhiteSpaceChar = Symbols.Space;
                                continue;
                        }
                    }
                    else
                    {
                        // https://drafts.csswg.org/css-text/#propdef-text-transform
                        switch (textTransform)
                        {
                            case "uppercase":
                                c = Char.ToUpperInvariant(c);
                                break;
                            case "lowercase":
                                c = Char.ToLowerInvariant(c);
                                break;
                            case "capitalize":
                                if (i == 0 || Char.IsWhiteSpace(text[i - 1]))
                                {
                                    c = Char.ToUpperInvariant(c);
                                }
                                break;
                            case "none":
                            default:
                                break;
                        }

                        if (lastWhiteSpaceChar != '\0')
                        {
                            FlushRequiredLineBreak();
                            if (_stringBuilder.Length > 0 && (_lastWhiteSpaceChar == '\0' || _lastWhiteSpaceChar == Symbols.Space))
                            {
                                _stringBuilder.Append(lastWhiteSpaceChar);
                            }
                            lastWhiteSpaceChar = '\0';
                        }
                        _lastWhiteSpaceChar = '\0';
                    }

                    FlushRequiredLineBreak();
                    _stringBuilder.Append(c);
                }

                switch (whiteSpace)
                {
                    case "pre":
                    case "pre-wrap":
                    case "break-spaces":
                    case "pre-line":
                        _lastWhiteSpaceChar = '\0';
                        break;
                    default:
                        if (_stringBuilder.Length >= 0)
                        {
                            _lastWhiteSpaceChar = lastWhiteSpaceChar;
                        }
                        break;
                }
            }

            private void FlushRequiredLineBreak()
            {
                if (_requiredLineBreakCount == 0)
                {
                    return;
                }
                _stringBuilder.Append(Symbols.LineFeed, _requiredLineBreakCount);
                _requiredLineBreakCount = 0;
                _lastWhiteSpaceChar = Symbols.LineFeed;
            }

            public string Finish()
            {
                return _stringBuilder.ToString();
            }
        }

        private class ElementInnerTextCollector
        {
            private readonly ElementInnerTextStringBuilder _result;

            public ElementInnerTextCollector(StringBuilder stringBuilder)
            {
                _result = new ElementInnerTextStringBuilder(stringBuilder);
            }

            public string RunOn(IHtmlElement element)
            {
                // 1. If this element is locked or a part of a locked subtree, then it is
                // hidden from view (and also possibly not laid out) and innerText should be
                // empty.

                // 2. If this element is not being rendered, or if the user agent is a non-CSS
                // user agent, then return the same value as the textContent IDL attribute on
                // this element.
                if (element.Owner == null)
                {
                    return element.TextContent;
                }
                var style = element.ComputeCurrentStyle();
                if (!IsBeingRendered(element, style))
                {
                    return element.TextContent;
                }

                // 3. Let results be a new empty list.
                // 4. For each child node node of this element:
                //   1. Let current be the list resulting in running the inner text collection
                //      steps with node. Each item in results will either be a JavaScript
                //      string or a positive integer (a required line break count).
                //   2. For each item item in current, append item to results.
                if (element is IHtmlSelectElement selectElement)
                {
                    ProcessSelectElement(selectElement);
                }
                else if (element is IHtmlOptionElement optionElement)
                {
                    ProcessOptionElement(optionElement);
                }
                else
                {
                    ProcessChildren(element, style);
                }

                return _result.Finish();
            }

            public void ProcessChildren(INode node, ICssStyleDeclaration style)
            {
                foreach (var child in node.ChildNodes)
                {
                    ProcessNode(child, style);
                }
            }

            public void ProcessChildrenWithRequiredLineBreaks(INode node, int requiredLineBreakCount, ICssStyleDeclaration style)
            {
                _result.EmitRequiredLineBreak(requiredLineBreakCount);
                ProcessChildren(node, style);
                _result.EmitRequiredLineBreak(requiredLineBreakCount);
            }

            public void ProcessNode(INode node, ICssStyleDeclaration parentCss)
            {
                // 1. Let items be the result of running the inner text collection steps with
                // each child node of node in tree order, and then concatenating the results
                // to a single list.

                // 2. If the node is display locked, then we should not process it or its
                // children, since they are not visible or accessible via innerText.


                // 3. If node's computed value of 'visibility' is not 'visible', then return
                // items.

                // 4. If node is not being rendered, then return items. For the purpose of
                // this step, the following elements must act as described if the computed
                // value of the 'display' property is not 'none':
                var style = (node as IElement)?.ComputeCurrentStyle();
                if (!IsBeingRendered(node, style))
                {
                    // ProcessChildren(node, style);
                    return;
                }

                // * select elements have an associated non-replaced inline CSS box whose
                //   child boxes include only those of optgroup and option element child
                //   nodes;
                // * optgroup elements have an associated non-replaced block-level CSS box
                //   whose child boxes include only those of option element child nodes; and
                // * option element have an associated non-replaced block-level CSS box whose
                //   child boxes are as normal for non-replaced block-level CSS boxes.
                if (node is IHtmlSelectElement selectElement)
                {
                    ProcessSelectElement(selectElement);
                    return;
                }
                if (node is IHtmlOptionElement optionElement)
                {
                    ProcessOptionElement(optionElement);
                    return;
                }

                // 5. If node is a Text node, then for each CSS text box produced by node.
                if (node is IText text)
                {
                    ProcessTextNode(text, parentCss);
                    return;
                }

                // 6. If node is a br element, then append a string containing a single U+000A
                // LINE FEED (LF) character to items.
                if (node is IHtmlBreakRowElement)
                {
                    ProcessChildren(node, style);
                    _result.EmitNewline();
                    return;
                }

                // 7. If node's computed value of 'display' is 'table-cell', and node's CSS
                // box is not the last 'table-cell' box of its enclosing 'table-row' box, then
                // append a string containing a single U+0009 CHARACTER TABULATION (tab)
                // character to items.
                if ((node is IHtmlTableCellElement && String.IsNullOrEmpty(style?.Display)) || style?.Display == "table-cell")
                {
                    ProcessChildren(node, style);
                    if (((IElement)node).NextElementSibling != null)
                    {
                        _result.EmitTab();
                    }
                    return;
                }

                // 8. If node's computed value of 'display' is 'table-row', and node's CSS box
                // is not the last 'table-row' box of the nearest ancestor 'table' box, then
                // append a string containing a single U+000A LINE FEED (LF) character to
                // items.
                if ((node is IHtmlTableRowElement && String.IsNullOrEmpty(style?.Display)) || style?.Display == "table-row")
                {
                    ProcessChildren(node, style);
                    if (((IElement)node).NextElementSibling != null)
                    {
                        _result.EmitNewline();
                    }
                    return;
                }

                // 9. If node is a p element, then append 2 (a required line break count) at
                // the beginning and end of items.
                if (node is IHtmlParagraphElement)
                {
                    ProcessChildrenWithRequiredLineBreaks(node, 2, style);
                    return;
                }

                // 10. If node's used value of 'display' is block-level or 'table-caption',
                // then append 1 (a required line break count) at the beginning and end of
                // items.
                if (String.IsNullOrEmpty(style?.Display) ? IsBlockLevel(node) : IsBlockLevelDisplay(style?.Display))
                {
                    ProcessChildrenWithRequiredLineBreaks(node, 1, style);
                    return;
                }

                ProcessChildren(node, style);
            }

            public void ProcessOptionElement(IHtmlOptionElement element)
            {
                _result.EmitRequiredLineBreak(1);
                _result.EmitText(element.Text);
                _result.EmitRequiredLineBreak(1);
            }

            public void ProcessSelectElement(IHtmlSelectElement element)
            {
                foreach (var child in element.ChildNodes)
                {
                    if (child is IHtmlOptionElement optionElement)
                    {
                        ProcessOptionElement(optionElement);
                        continue;
                    }

                    if (child is IHtmlOptionsGroupElement optionsGroupElement)
                    {
                        _result.EmitRequiredLineBreak(1);
                        foreach (var optionGroupChild in child.ChildNodes)
                        {
                            if (optionGroupChild is IHtmlOptionElement optionsGroupOptionElement)
                            {
                                ProcessOptionElement(optionsGroupOptionElement);
                            }
                        }
                        _result.EmitRequiredLineBreak(1);
                    }
                }
            }

            public void ProcessTextNode(IText text, ICssStyleDeclaration style)
            {
                var whiteSpace = style?.WhiteSpace;
                if (String.IsNullOrEmpty(whiteSpace) && text.Parent is IHtmlPreElement)
                {
                    whiteSpace = "pre";
                }
                _result.EmitText(text.Data, whiteSpace, style?.TextTransform);
            }

            private static Boolean IsBeingRendered(INode node, ICssStyleDeclaration style)
            {
                if (!HasCssBox(node))
                {
                    return false;
                }

                if (style != null)
                {
                    bool? hidden = null;
                    if (!String.IsNullOrEmpty(style.Display))
                    {
                        hidden = style.Display == "none";
                    }
                    if (!String.IsNullOrEmpty(style.Visibility) && hidden != true && style.Visibility != "visible")
                    {
                        hidden = true;
                    }
                    if (hidden.HasValue)
                    {
                        return !hidden.Value;
                    }
                }

                if ((node as IHtmlElement)?.IsHidden == true)
                {
                    return false;
                }

                return true;
            }

        }

        private static Boolean HasCssBox(INode node)
        {
            switch (node.NodeName)
            {
                case "CANVAS":
                case "COL":
                case "COLGROUP":
                case "DETAILS":
                case "FRAME":
                case "FRAMESET":
                case "IFRAME":
                case "IMG":
                case "INPUT":
                case "LINK":
                case "METER":
                case "PROGRESS":
                case "TEMPLATE":
                case "TEXTAREA":
                case "VIDEO":
                case "WBR":
                case "SCRIPT":
                case "STYLE":
                case "NOSCRIPT":
                    return false;
                default:
                    return true;
            }
        }

        private static bool IsBlockLevelDisplay(String display)
        {
            // https://www.w3.org/TR/css-display-3/#display-value-summary
            // https://hg.mozilla.org/mozilla-central/file/0acceb224b7d/servo/components/layout/query.rs#l1016
            switch (display)
            {
                case "block":
                case "flow-root":
                case "flex":
                case "grid":
                case "table":
                case "table-caption":
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsBlockLevel(INode node)
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTML/Block-level_elements
            switch (node.NodeName)
            {
                case "ADDRESS":
                case "ARTICLE":
                case "ASIDE":
                case "BLOCKQUOTE":
                case "CANVAS":
                case "DD":
                case "DIV":
                case "DL":
                case "DT":
                case "FIELDSET":
                case "FIGCAPTION":
                case "FIGURE":
                case "FOOTER":
                case "FORM":
                case "H1":
                case "H2":
                case "H3":
                case "H4":
                case "H5":
                case "H6":
                case "HEADER":
                case "GROUP":
                case "HR":
                case "LI":
                case "MAIN":
                case "NAV":
                case "NOSCRIPT":
                case "OL":
                case "OPTION":
                case "OUTPUT":
                case "P":
                case "PRE":
                case "SECTION":
                case "TABLE":
                case "TFOOT":
                case "UL":
                case "VIDEO":
                    return true;
                default:
                    return false;
            }
        }

        #endregion

        #region Methods

        public void DoSpellCheck()
        {
            var spellcheck = Owner.Options.GetSpellCheck(Language);

            if (spellcheck != null)
            {
                //TODO
                //Go through all elements, finding single text nodes, then split
                //on word boundaries etc.
                //Finally check the single words, one by one.
                //Provide additional information on the Text Nodes which words
                //(if any) have errors.
            }
        }

        public virtual void DoClick()
        {
            IsClickedCancelled();
        }

        public virtual void DoFocus()
        {
            //Only certain elements can be focused
        }

        public virtual void DoBlur()
        {
            //Only certain elements can be focused
        }

        public override INode Clone(Boolean deep = true)
        {
            var factory = Owner.Options.GetFactory<IElementFactory<HtmlElement>>();
            var node = factory.Create(Owner, LocalName, Prefix);
            CloneElement(node, deep);
            return node;
        }

        #endregion

        #region Internal Methods

        internal override void SetupElement()
        {
            base.SetupElement();

            var style = this.GetOwnAttribute(AttributeNames.Style);

            if (style != null)
            {
                UpdateStyle(style);
            }
        }

        internal void UpdateDropZone(String value)
        {
            _dropZone?.Update(value);
        }

        protected Boolean IsClickedCancelled()
        {
            return this.Fire<MouseEvent>(m => m.Init(EventNames.Click, true, true, Owner.DefaultView, 0, 0, 0, 0, 0, false, false, false, false, MouseButton.Primary, this));
        }

        protected IHtmlFormElement GetAssignedForm()
        {
            var parent = Parent as INode;

            while (parent != null && parent is IHtmlFormElement == false)
            {
                parent = parent.ParentElement;
            }

            if (parent == null)
            {
                var formid = this.GetOwnAttribute(AttributeNames.Form);
                var owner = Owner;

                if (owner == null || parent != null || String.IsNullOrEmpty(formid))
                {
                    return null;
                }

                parent = owner.GetElementById(formid);
            }

            return parent as IHtmlFormElement;
        }

        #endregion

        #region Helpers

        private String GetDefaultLanguage()
        {
            var parent = ParentElement as IHtmlElement;
            return parent != null ? parent.Language : Owner.Options.GetLanguage();
        }

        private static String Combine(String prefix, String localName)
        {
            return (prefix != null ? String.Concat(prefix, ":", localName) : localName).ToUpperInvariant();
        }

        #endregion
    }
}
