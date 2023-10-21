﻿using System;
using UnityEditor;
using UnityEngine;

namespace OALProgramControl
{
    public class EXEValueReal : EXEValuePrimitive
    {
        public decimal Value { get; protected set; }

        public override string TypeName => EXETypes.RealTypeName;

        public EXEValueReal(EXEValueReal original)
        {
            CopyValues(original, this);
        }
        public EXEValueReal(EXEValueInt value)
        {
            this.Value = value.Value;
        }
        public EXEValueReal(string value)
        {
            if (!EXETypes.IsValidRealValue(value))
            {
                throw new ArgumentException(string.Format("\"{0}\" is not a valid real value.", value));
            }

            this.Value = decimal.Parse(value);
        }
        public EXEValueReal(decimal value)
        {
            this.Value = value;
        }
        public override EXEValueBase DeepClone()
        {
            return new EXEValueReal(this);
        }
        public override string ToText()
        {
            return this.Value.ToString();
        }
        public override EXEExecutionResult AssignValueFrom(EXEValueBase assignmentSource)
        {
            return assignmentSource.AssignValueTo(this);
        }
        public override EXEExecutionResult AssignValueTo(EXEValueReal assignmentTarget)
        {
            if (!this.WasInitialized)
            {
                return UninitializedError();
            }

            CopyValues(this, assignmentTarget);

            return EXEExecutionResult.Success();
        }
        public override EXEExecutionResult AssignValueTo(EXEValueInt assignmentTarget)
        {
            if (!this.WasInitialized)
            {
                return UninitializedError();
            }

            if (!EXEExecutionGlobals.AllowLossyAssignmentOfRealToInteger)
            {
                return EXEExecutionResult.Error("Assigning real to integer is not currently allowed.", "XEC2017");
            }

            EXEValueInt.CopyValues(new EXEValueInt(this.Value), assignmentTarget);

            return EXEExecutionResult.Success();
        }
        public static void CopyValues(EXEValueReal source, EXEValueReal target)
        {
            target.Value = source.Value;
        }
        public override EXEExecutionResult ApplyOperator(string operation, EXEValueBase operand)
        {
            if (!this.WasInitialized || !operand.WasInitialized)
            {
                return UninitializedError();
            }

            EXEExecutionResult result = null;

            if ("<=".Equals(operation))
            {
                if (operand is not EXEValueReal)
                {
                    if (operand is EXEValueInt)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Value <= (operand as EXEValueReal).Value);
                return result;
            }
            else if (">=".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Value >= (operand as EXEValueReal).Value);
                return result;
            }
            else if ("<".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Value < (operand as EXEValueReal).Value);
                return result;
            }
            else if (">".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Value > (operand as EXEValueReal).Value);
                return result;
            }
            else if ("==".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Value == (operand as EXEValueReal).Value);
                return result;
            }
            else if ("!=".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Value != (operand as EXEValueReal).Value);
                return result;
            }
            else if ("+".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueReal(this.Value + (operand as EXEValueReal).Value);
                return result;
            }
            else if ("-".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueReal(this.Value - (operand as EXEValueReal).Value);
                return result;
            }
            else if ("*".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueReal(this.Value * (operand as EXEValueReal).Value);
                return result;
            }
            else if ("/".Equals(operation))
            {
                if (operand is not EXEValueInt)
                {
                    if (operand is EXEValueReal)
                    {
                        return this.ApplyOperator(operation, new EXEValueReal(operand as EXEValueInt));
                    }

                    return base.ApplyOperator(operation, operand);
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueReal(this.Value / (operand as EXEValueReal).Value);
                return result;
            }

            return base.ApplyOperator(operation, operand);
        }
    }
}