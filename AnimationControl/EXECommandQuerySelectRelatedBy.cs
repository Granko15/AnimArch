﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationControl
{
    public class EXECommandQuerySelectRelatedBy : EXECommand
    {
        public String Cardinality { get; set; }
        public String VariableName { get; set; }
        public EXEASTNode WhereCondition { get; set; }
        public EXERelationshipSelection RelationshipSelection {get; set;}

        public EXECommandQuerySelectRelatedBy(String Cardinality, String VariableName, EXEASTNode WhereCondition, EXERelationshipSelection RelationshipSelection)
        {
            this.Cardinality = Cardinality;
            this.VariableName = VariableName;
            this.WhereCondition = WhereCondition;
            this.RelationshipSelection = RelationshipSelection;
        }

        // SetUloh2
        new public bool Execute(Animation Animation, EXEScope Scope)
        {
            //Select instances of given class that match the criteria and assign them to variable with given name
            // ClassName tells us which class we are interested in
            // Cardinality tells us whether we want one random instance (matching the criteria) or all of them
            // "Many" - we create variable EXEReferencingSetVariable, "Any" - we create variable EXEReferencingVariable
            // Variable name tells us how to name the newly created referencing variable
            // Where condition tells us which instances to select from all instances of the class (just do EXEASTNode.Evaluate and return true if the result "true" and false for "false")
            // When making unit tests, do not use the "where" causule yet, because its evaluation is not yet implemented
            // If relationship selection does not exists, this is problem
            if (this.RelationshipSelection == null)
            {
                return false;
            }

            // We need to check, if the variable already exists, it must be of corresponging type
            if (Scope.VariableNameExists(this.VariableName))
            {
                try
                {
                    if (!((EXECommandQuerySelect.CardinalityAny.Equals(this.Cardinality) && this.RelationshipSelection.GetLastClassName() == Scope.FindReferencingVariableByName(this.VariableName).ClassName)
                       || (EXECommandQuerySelect.CardinalityMany.Equals(this.Cardinality) && this.RelationshipSelection.GetLastClassName() == Scope.FindSetReferencingVariableByName(this.VariableName).ClassName)))
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            // Evaluate relationship selection. If it fails, execution fails too
            List<long> SelectedIds = this.RelationshipSelection.Evaluate(Animation.RelationshipSpace, Scope);
            if (SelectedIds == null)
            {
                return false;
            }

            // Now let's evaluate the condition
            if (this.WhereCondition != null &&SelectedIds.Any())
            {
                String TempSelectedVarName = "selected";

                EXEReferencingVariable SelectedVar = new EXEReferencingVariable(TempSelectedVarName, this.RelationshipSelection.GetLastClassName(), -1);
                if (!Scope.AddVariable(SelectedVar))
                {
                    return false;
                }

                List<long> ResultIds = new List<long>();
                foreach (long Id in SelectedIds)
                {
                    SelectedVar.ReferencedInstanceId = Id;
                    String ConditionResult = this.WhereCondition.Evaluate(Scope, Animation.ExecutionSpace);

                    if(!EXETypes.IsValidValue(ConditionResult, EXETypes.BooleanTypeName))
                    {
                        return false;
                    }

                    if (EXETypes.BooleanTrue.Equals(false))
                    {
                        ResultIds.Add(Id);
                    }
                }

                SelectedIds = ResultIds;
                Scope.DestroyReferencingVariable(TempSelectedVarName);
            }

            // Now we have ids of selected instances. Let's assign them to a variable
            if (EXECommandQuerySelect.CardinalityMany.Equals(this.Cardinality))
            {
                EXEReferencingSetVariable Variable = Scope.FindSetReferencingVariableByName(this.VariableName);
                if (Variable == null)
                {
                    Variable = new EXEReferencingSetVariable(this.VariableName, this.RelationshipSelection.GetLastClassName());
                    if (!Scope.AddVariable(Variable))
                    {
                        return false;
                    }
                }
                foreach (long Id in SelectedIds)
                {
                    Variable.AddReferencingVariable(new EXEReferencingVariable("", Variable.ClassName, Id));
                }
            }
            else if (EXECommandQuerySelect.CardinalityAny.Equals(this.Cardinality))
            {
                EXEReferencingVariable Variable = Scope.FindReferencingVariableByName(this.VariableName);
                if (Variable == null)
                {
                    long ResultId = SelectedIds.Any() ? SelectedIds[new Random().Next(SelectedIds.Count)] : -1;
                    Variable = new EXEReferencingVariable(this.VariableName, this.RelationshipSelection.GetLastClassName(), ResultId);
                    if (!Scope.AddVariable(Variable))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Ignore all methods below this comment
        new public string GetCode()
        {
            throw new NotImplementedException();
        }
        new public void PrintAST()
        {
            throw new NotImplementedException();
        }

        new public string PrintSelf(bool IsTopLevel)
        {
            throw new NotImplementedException();
        }
    }
}
