﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationControl
{
    class EXEScopeLoopWhile : EXEScope
    {
        public EXEASTNode Condition;

        public EXEScopeLoopWhile(EXEASTNode Condition) : base()
        {
            this.Condition = Condition;
        }

        public Boolean EvaluateCondition(EXEScope Scope, CDClassPool ExecutionSpace)
        {
            String Result = this.Condition.Evaluate(Scope, ExecutionSpace);

            return EXETypes.BooleanTrue.Equals(Result) ? true : false;
        }

        new public Boolean Execute(Animation Animation , EXEScope Scope)
        {
            Boolean Success = true;

            while (this.EvaluateCondition(Scope, Animation.ExecutionSpace))
            {
                Success = base.Execute(Animation, this);
                if (!Success)
                {
                    break;
                }
            }

            return Success;
        }
    }
}
