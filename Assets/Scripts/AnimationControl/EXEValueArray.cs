﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace OALProgramControl
{
    public class EXEValueArray : EXEValueBase
    {
        public string ElementTypeName { get; private set; }
        public override string TypeName => ElementTypeName + "[]";
        private List<EXEValueBase> Elements;

        public EXEValueArray(string type)
        {
            if (!EXETypes.IsValidArrayType(type))
            {
                throw new Exception(string.Format("\"{0}\" is not a valid array type."));
            }

            this.ElementTypeName = type.Substring(0, type.Length - 2);
            this.Elements = null;
        }
        public EXEValueArray(string type, List<EXEValueBase> elements) : this(type)
        {
            foreach (EXEValueBase element in elements)
            {
                if (!string.Equals(type, element.TypeName))
                {
                    throw new Exception(string.Format("Element \"{0}\" of type \"{1}\" cannot be stored in an array of type \"{2}\".", element.ToText(), element.TypeName, type));
                }
            }

            this.Elements = elements;
        }
        public static EXEExecutionResult CreateArray(string type)
        {
            if (!EXETypes.IsValidArrayType(type))
            {
                return EXEExecutionResult.Error(string.Format("Cannot create an array. \"{0}\" is not a valid array type.", type), "XEC2023");
            }

            EXEExecutionResult result = EXEExecutionResult.Success();

            EXEValueArray createdArray = new EXEValueArray(type);
            result.ReturnedOutput = createdArray;

            return result;
        }
        public void InitializeEmptyArray()
        {
            if (this.Elements != null)
            {
                throw new Exception("Tried to initialize non-empty array.");
            }

            this.Elements = new List<EXEValueBase>();
        }
        public override EXEValueBase DeepClone()
        {
            return new EXEValueArray(this.TypeName, this.Elements.Select(element => element.DeepClone()).ToList());
        }

        public override string ToText()
        {
            return Elements == null
                ?
                EXETypes.UnitializedName
                :
                ("[" + string.Join(", ", this.Elements.Select(element => element.ToText())) + "]");
        }
        public override EXEExecutionResult AssignValueFrom(EXEValueBase assignmentSource)
        {
            return assignmentSource.AssignValueTo(this);
        }
        public override EXEExecutionResult AssignValueTo(EXEValueArray assignmentTarget)
        {
            if (!this.WasInitialized)
            {
                return UninitializedError();
            }

            if (!string.Equals(this.TypeName, assignmentTarget.TypeName))
            {
                return base.AssignValueTo(assignmentTarget);
            }

            CopyValues(this, assignmentTarget);

            return EXEExecutionResult.Success();
        }
        public override EXEExecutionResult AppendElement(EXEValueBase appendedElement, CDClassPool classPool)
        {
            if (!this.WasInitialized)
            {
                return UninitializedError();
            }

            if (!EXETypes.CanBeAssignedTo(appendedElement, this.ElementTypeName, classPool))
            {
                return base.AppendElement(appendedElement, classPool);
            }

            if (this.Elements == null)
            {
                return base.AppendElement(appendedElement, classPool);
            }

            this.Elements.Append(appendedElement);
            return EXEExecutionResult.Success();
        }
        public override EXEExecutionResult RemoveElement(EXEValueBase removedElement, CDClassPool classPool)
        {
            if (!this.WasInitialized)
            {
                return UninitializedError();
            }

            if (!string.Equals(this.ElementTypeName, removedElement.TypeName))
            {
                return base.RemoveElement(removedElement, classPool);
            }

            if (this.Elements == null)
            {
                return EXEExecutionResult.Error("Tried to remove an element from an uninitialized array.", "XEC2027");
            }

            this.Elements.RemoveAll(element => element.Equals(removedElement));

            return EXEExecutionResult.Success();
        }
        public EXEValueBase GetElementAt(int index)
        {
            return this.Elements[index];
        }
        private void CopyValues(EXEValueArray source, EXEValueArray target)
        {
            target.ElementTypeName = source.ElementTypeName;
            target.Elements = source.Elements?.Select(element => element.DeepClone()).ToList();
        }
        public override EXEExecutionResult ApplyOperator(string operation)
        {
            if (!this.WasInitialized)
            {
                return UninitializedError();
            }

            EXEExecutionResult result = null;

            if ("cardinality".Equals(operation))
            {
                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueInt(this.Elements == null ? 0 : this.Elements.Count);
                return result;
            }
            else if ("empty".Equals(operation))
            {
                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Elements == null || !this.Elements.Any());
                return result;
            }
            else if ("not_empty".Equals(operation))
            {
                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(this.Elements == null || this.Elements.Any());
                return result;
            }

            return base.ApplyOperator(operation);
        }
        public override EXEExecutionResult ApplyOperator(string operation, EXEValueBase operand)
        {
            if (!this.WasInitialized || !operand.WasInitialized)
            {
                return UninitializedError();
            }

            EXEExecutionResult result = null;

            if ("==".Equals(operation))
            {
                if (operand is not EXEValueArray)
                {
                    return base.ApplyOperator(operation, operand);
                }

                bool areEqual = false;
                EXEValueArray typedOperand = operand as EXEValueArray;

                if (this.Elements == null)
                {
                    areEqual = this.Elements == typedOperand.Elements;
                }
                else if (typedOperand.Elements == null)
                {
                    areEqual = false;
                }
                else if (this.Elements.Count != typedOperand.Elements.Count)
                {
                    areEqual = false;
                }
                else
                {
                    areEqual = true;

                    for (int i = 0; i < this.Elements.Count; i++)
                    {
                        if (!(this.Elements[i].IsEqualTo(typedOperand.Elements[i]).ReturnedOutput as EXEValueBool).Value)
                        {
                            areEqual = false;
                            break;
                        }
                    }
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(areEqual);
                return result;
            }
            else if ("!=".Equals(operation))
            {
                bool areEqual = true;
                EXEValueArray typedOperand = operand as EXEValueArray;

                if (this.Elements == null)
                {
                    areEqual = this.Elements != typedOperand.Elements;
                }
                else if (typedOperand.Elements == null)
                {
                    areEqual = true;
                }
                else if (this.Elements.Count != typedOperand.Elements.Count)
                {
                    areEqual = true;
                }
                else
                {
                    areEqual = false;

                    for (int i = 0; i < this.Elements.Count; i++)
                    {
                        if ((this.Elements[i].IsEqualTo(typedOperand.Elements[i]).ReturnedOutput as EXEValueBool).Value)
                        {
                            areEqual = true;
                            break;
                        }
                    }
                }

                result = EXEExecutionResult.Success();
                result.ReturnedOutput = new EXEValueBool(areEqual);
                return result;
            }

            return base.ApplyOperator(operation, operand);
        }
        public override string ToObjectDiagramText()
        {
            return string.Format("[{0} ]", string.Join(", ", this.Elements.Select(element => element.ToObjectDiagramText())));
        }
    }
}