
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_UTD_aplikacja
{
    class Command
    {
        //type of command
        public enum Type
        {
            Null,
            Select,
            Insert
        }

        private String _com;
        private Type _type = Type.Null;
        private String _insertHelper;
        List<String> _resultAttr; //list to store names of result attributes

        public Command()
        {
        }

        public Command(String c, Type t, String a, List<String> r)
        {
            _com = c;
            _type = t;
            _insertHelper = a;
            _resultAttr = r;
        }

        public String GetCommand() { return _com; }
        public Type GetCommandType() { return _type; }
        public String GetInsertHelper() { return _insertHelper; }
        public List<string> GetAttributes() { return _resultAttr; }

    }
}
