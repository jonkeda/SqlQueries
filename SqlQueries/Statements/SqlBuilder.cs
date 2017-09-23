using System;
using System.Text;

namespace SqlQueries.Statements
{
    public class SqlBuilder
    {
        public SqlBuilder(Type connectionType)
        {
            ConnectionType = connectionType;
        }

        private readonly StringBuilder _sb = new StringBuilder();
        private int _count;

        public void Append(string text)
        {
            _sb.Append(text);
        }

        //public string Statement
        //{
        //    get { return _sb.ToString(); }
        //}

        public Type ConnectionType { get; }

        public void AppendParameter(object wvValue)
        {
            _sb.Append(" @p");
            _sb.Append(_count);
            _count++;
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}