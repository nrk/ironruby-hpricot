using System;
using System.IO;
using System.Collections;
using System.Runtime.CompilerServices;
using IronRuby.Builtins;
using IronRuby.Runtime;
using IronRuby.Runtime.Calls;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Libraries.Hpricot {
    using RubyIOReadCallSite = CallSite<Func<CallSite, RubyContext, Object, Int32, MutableString>>;

    public class HpricotScanner {
        #region fields

        private static String NO_WAY_SERIOUSLY = "*** This should not happen, please send a bug report with the HTML you're parsing to why@whytheluckystiff.net.  So sorry!";

        private static Int32? _bufferSize;

        private RubyContext/*!*/ _currentContext;
        private BlockParam/*!*/ _blockParam;
        private RespondToStorage/*!*/ _respondToStorage;
        private ConversionStorage<MutableString> _toMutableString;

        #endregion

        #region fields - hpricot symbols

        private static Object xmldecl = SymbolTable.StringToId("xmldecl");
        private static Object doctype = SymbolTable.StringToId("doctype");
        private static Object procins = SymbolTable.StringToId("procins");
        private static Object stag = SymbolTable.StringToId("stag");
        private static Object etag = SymbolTable.StringToId("etag");
        private static Object emptytag = SymbolTable.StringToId("emptytag");
        private static Object comment = SymbolTable.StringToId("comment");
        private static Object cdata = SymbolTable.StringToId("cdata");
        private static Object sym_text = SymbolTable.StringToId("text");

        #endregion

        #region fields - used by the ragel-generated code

        private const int DEFAULT_BUFFER_SIZE = 32768;

        int cs, act, have = 0, nread = 0, curline = 1, p = -1;
        bool text = false;
        int ts = -1, te;
        int eof = -1;
        char[] buf;
        Object attr;
        Object[] tag, akey, aval;
        int mark_tag, mark_akey, mark_aval;
        bool done = false, ele_open = false;
        int buffer_size = 0;
        bool taint = false;

        #endregion


        #region constructors 

        public HpricotScanner(RespondToStorage/*!*/ respondToStorage, ConversionStorage<MutableString>/*!*/ toMutableString, 
            RubyContext/*!*/ context, BlockParam/*!*/ block) {
            _respondToStorage = respondToStorage;
            _toMutableString = toMutableString;
            _currentContext = context;
            _blockParam = block;
        }

        #endregion


%%{
  machine hpricot_scan;

  action newEle {
    if (text) {
        CAT(tag, p);
        ELE(sym_text);
        text = false;
    }
    attr = null;
    tag[0] = null;
    mark_tag = -1;
    ele_open = true;
  }

  action _tag { mark_tag = p; }
  action _aval { mark_aval = p; }
  action _akey { mark_akey = p; }
  action tag { SET(tag, p); }
  action tagc { SET(tag, p - 1); }
  action aval { SET(aval, p); }
  action aunq { 
    if (buf[p - 1] == '"' || buf[p - 1] == '\'') { SET(aval, p - 1); }
    else { SET(aval, p); }
  }
  action akey { SET(akey, p); }
  action xmlver { SET(aval, p); ATTR(rb_str_new2("version"), aval); }
  action xmlenc { SET(aval, p); ATTR(rb_str_new2("encoding"), aval); }
  action xmlsd  { SET(aval, p); ATTR(rb_str_new2("standalone"), aval); }
  action pubid  { SET(aval, p); ATTR(rb_str_new2("public_id"), aval); }
  action sysid  { SET(aval, p); ATTR(rb_str_new2("system_id"), aval); }

  action new_attr { 
    akey[0] = null;
    aval[0] = null;
    mark_akey = -1;
    mark_aval = -1;
  }

  action save_attr { 
    ATTR(akey, aval);
  }

  include hpricot_common "HpricotScanner.common.rl";

}%%

        #region code generated by ragel

%% write data nofinal;

        #endregion


        #region mimic a few ruby core APIs

        private static MutableString rb_str_new2(String s) {
            return MutableString.Create(s);
        }

        private void rb_yield_tokens(Object sym, Object tag, Object attr, Object raw, bool taint) {
            if (sym_text.Equals(sym)) {
                raw = tag;
            }

            RubyArray ary = new RubyArray(4);
            ary.Add(sym);
            ary.Add(tag);
            ary.Add(attr);
            ary.Add(raw);

            if (taint) {
                _currentContext.SetObjectTaint(ary, true);
                _currentContext.SetObjectTaint(tag, true);
                _currentContext.SetObjectTaint(attr, true);
                _currentContext.SetObjectTaint(raw, true);
            }

            Object result = null;
            _blockParam.Yield(ary, out result);
        }

        #endregion

        #region parser callbacks

        private void ELE(Object N) {
            if (te > ts || text) {
                Object raw_string = null;
                ele_open = false;
                text = false;

                if (ts != -1 && N != cdata && N != sym_text && N != procins && N != comment) {
                    raw_string = MutableString.Create(new String(buf, ts, te - ts));
                }

                rb_yield_tokens(N, tag[0], attr, raw_string, taint);
            }
        }

        private void SET(Object[] N, int E) {
            if (N == tag) {
                if (mark_tag == -1 || E == mark_tag) {
                    tag[0] = MutableString.Empty;
                }
                else if (E > mark_tag) {
                    tag[0] = MutableString.Create(new String(buf, mark_tag, E - mark_tag));
                }
            }
            else if (N == akey) {
                if (mark_akey == -1 || E == mark_akey) {
                    akey[0] = MutableString.Empty;
                }
                else if (E > mark_akey) {
                    akey[0] = MutableString.Create(new String(buf, mark_akey, E - mark_akey));
                }
            }
            else if (N == aval) {
                if (mark_aval == -1 || E == mark_aval) {
                    aval[0] = MutableString.Empty;
                }
                else if (E > mark_aval) {
                    aval[0] = MutableString.Create(new String(buf, mark_aval, E - mark_aval));
                }
            }
        }

        private void CAT(Object[] N, int E) {
            if (N[0] == null) {
                SET(N, E);
            }
            else {
                int mark = 0;
                if (N == tag) {
                    mark = mark_tag;
                }
                else if (N == akey) {
                    mark = mark_akey;
                }
                else if (N == aval) {
                    mark = mark_aval;
                }
                (N[0] as MutableString).Append(new String(buf, mark, E - mark));
            }
        }

        private void SLIDE(Object N) {
            int mark = 0;
            if (N == tag) {
                mark = mark_tag;
            }
            else if (N == akey) {
                mark = mark_akey;
            }
            else if (N == aval) {
                mark = mark_aval;
            }
            if (mark > ts) {
                if (N == tag) {
                    mark_tag -= ts;
                }
                else if (N == akey) {
                    mark_akey -= ts;
                }
                else if (N == aval) {
                    mark_aval -= ts;
                }
            }
        }

        private void ATTR(Object K, Object V) {
            if (K != null) {
                if (attr == null) {
                    attr = new Hash(_currentContext);
                }
                (attr as Hash).Add(K, V);
            }
        }

        private void ATTR(Object[] K, Object V) {
            ATTR(K[0], V);
        }

        private void ATTR(Object K, Object[] V) {
            ATTR(K, V[0]);
        }

        private void ATTR(Object[] K, Object[] V) {
            ATTR(K[0], V[0]);
        }

        private void TEXT_PASS() {
            if (!text) {
                if (ele_open) {
                    ele_open = false;
                    if (ts > -1) {
                        mark_tag = ts;
                    }
                }
                else {
                    mark_tag = p;
                }
                attr = null;
                tag[0] = null;
                text = true;
            }
        }

        private void EBLK(Object N, int T) {
            CAT(tag, p - T + 1);
            ELE(N);
        }

        #endregion


        public static Int32? BufferSize {
            get { return _bufferSize; }
            set { _bufferSize = value; }
        }

        public Object Scan(Object/*!*/ source) {
            tag = new Object[1];
            akey = new Object[1];
            aval = new Object[1];

            taint = _currentContext.IsObjectTainted(source);

            bool sourceRespondsToRead = Protocols.RespondTo(_respondToStorage, _currentContext, source, "read");

            RubyIOReadCallSite readCallSite = null;
            if (sourceRespondsToRead) {
                readCallSite = RubyIOReadCallSite.Create(RubyCallAction.Make("read", 3));
            }
            else if (Protocols.RespondTo(_respondToStorage, _currentContext, source, "to_str")) {
                source = Protocols.CastToString(_toMutableString, _currentContext, source);
            }
            else {
                throw RubyExceptions.CreateArgumentError("bad Hpricot argument, String or IO only please.");
            }

            buffer_size = BufferSize.HasValue ? BufferSize.Value : DEFAULT_BUFFER_SIZE;
            buf = new char[buffer_size];

            #region code generated by ragel

  %% write init;

            #endregion

            while (!done) {
                p = have;
                int pe;
                int space = buffer_size - have;

                if (space == 0) {
                    buffer_size += DEFAULT_BUFFER_SIZE;
                    Array.Resize<char>(ref buf, buffer_size);
                    space = buffer_size - have;
                }

                char[] chars;
                if (sourceRespondsToRead) {
                    chars = BinaryEncoding.Instance.GetChars(readCallSite.Target(readCallSite, _currentContext, source, space).ToByteArray());
                }
                else {
                    MutableString str = source as MutableString;
                    int end = Math.Min(str.Length, nread + space);
                    chars = str.Encoding.GetChars(str.GetBinarySlice(nread, end - nread));
                }

                Array.Copy(chars, 0, buf, p, chars.Length);

                int len = chars.Length;
                nread += len;

                if (len < space) {
                    len++;
                    done = true;
                }

                pe = p + len;
                char[] data = buf;

                #region code generated by ragel

    %% write exec;

                #endregion

                if (cs == hpricot_scan_error) {
                    String exceptionMessage;
                    if (tag[0] != null) {
                        exceptionMessage = String.Format("parse error on element <{0}>, starting on line {1}.\n{2}", tag.ToString(), curline, NO_WAY_SERIOUSLY);
                    }
                    else {
                        exceptionMessage = String.Format("parse error on line {0}.\n{1}", curline, NO_WAY_SERIOUSLY);
                    }
                    throw new Hpricot.ParserException(exceptionMessage);
                }

                if (done && ele_open) {
                    ele_open = false;
                    if (ts > -1) {
                        mark_tag = ts;
                        ts = -1;
                        text = true;
                    }
                }

                if (ts == -1) {
                    have = 0;
                    /* text nodes have no ts because each byte is parsed alone */
                    if (mark_tag != -1 && text) {
                        if (done) {
                            if (mark_tag < p - 1) {
                                CAT(tag, p - 1);
                                ELE(sym_text);
                            }
                        }
                        else {
                            CAT(tag, p);
                        }
                    }
                    mark_tag = 0;
                }
                else {
                    have = pe - ts;
                    Array.Copy(buf, ts, buf, 0, have);
                    SLIDE(tag);
                    SLIDE(akey);
                    SLIDE(aval);
                    te = (te - ts);
                    ts = 0;
                }
            }

            return 0;
        }
    }
}