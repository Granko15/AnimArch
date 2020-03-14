﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationControl
{
    public class EXEScopeCondition : EXEScope
    {
        public EXEASTNode Condition { get; set; }
        private List<EXEScopeCondition> ElifScopes;
        public EXEScope ElseScope { get; set; }

        public EXEScopeCondition() : base()
        {
            this.Condition = null;
            this.ElifScopes = null;
            this.ElseScope = null;
        }

        public void AddElifScope(EXEScopeCondition ElifScope)
        {
            if (this.ElifScopes == null)
            {
                this.ElifScopes = new List<EXEScopeCondition>();
            }

            this.ElifScopes.Add(ElifScope);
        }

        // should evaluate to true only if base "if" is true
        public Boolean EvaluateCondition(EXEScope Scope, CDClassPool ExecutionSpace)
        {
            String Result = this.Condition.Evaluate(Scope, ExecutionSpace);

            return EXETypes.BooleanTrue.Equals(Result) ? true : false;
        }

        new public Boolean Execute(Animation Animation, EXEScope Scope)
        {
            Boolean Result = true;
            Boolean AScopeWasExecuted = false;

            if (this.EvaluateCondition(Scope, Animation.ExecutionSpace))
            {
                Result = base.Execute(Animation, this);
                AScopeWasExecuted = true;
            }

            if (AScopeWasExecuted)
            {
                return Result;
            }

            if (this.ElifScopes != null)
            {
                foreach (EXEScopeCondition CurrentElif in this.ElifScopes)
                {
                    if (CurrentElif.EvaluateCondition(Scope, Animation.ExecutionSpace))
                    {
                        Result = CurrentElif.Execute(Animation, CurrentElif);
                        AScopeWasExecuted = true;
                        break;
                    }
                }
            }

            if (AScopeWasExecuted)
            {
                return Result;
            }

            if (this.ElseScope != null)
            {
                Result = this.ElseScope.Execute(Animation, ElseScope);
            }

            return Result;
        }
    }
}
