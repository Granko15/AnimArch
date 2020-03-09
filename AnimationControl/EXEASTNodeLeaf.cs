﻿using System;

namespace AnimationControl
{
    public class EXEASTNodeLeaf : EXEASTNode
    {
        public String Value { get; set; }

        public EXEASTNodeLeaf(String Value)
        {
            this.Value = Value;
        }

        public String GetNodeValue()
        {
            return this.Value;
        }
        public String Evaluate(EXEScope Scope)
        {
            String Result = null;
            if (!EXETypes.ReferenceTypeName.Equals(EXETypes.DetermineVariableType("", this.Value)))
            {
                Result = this.Value;
            }
            else if(EXETypes.ReferenceTypeName.Equals(EXETypes.DetermineVariableType("", this.Value)))
            {
                EXEPrimitiveVariable ThisVariable = Scope.FindPrimitiveVariableByName(this.Value);
                if(ThisVariable != null)
                {
                    Result = ThisVariable.Value;
                }
            }

            return Result;
        }

        //https://stackoverflow.com/questions/1649027/how-do-i-print-out-a-tree-structure
        public void PrintPretty(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(this.Value);
        }
    }
}
