﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Core.DataStructures;
using UnityEngine;
using Visualization.ClassDiagram.ClassComponents;

namespace OALProgramControl
{
    public class CDMethod
    {
        public CDClass OwningClass { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<CDParameter> Parameters { get; set; }
        public string OALCode { get; set; }
        public int CallCountInOALProgram { get; set; }
        public int HighlightLevel { get; private set;}
        public void IncrementHighlightLevel() {
            HighlightLevel++;
        }
        public void DecrementHighlightLevel() {
            if (HighlightLevel == 0)
            {
                Debug.LogError("TODO");
                return;
            }
            HighlightLevel--;
        }

        private CDMethod ParentCaller { get; set; }
        private Set<CDMethod> ChildrenCalled { get; }

        // public void EndHighlighting() {
        //     if (ChildrenCalled.Count > 0) {
        //         return;
        //     }


        // }

        public void AddChildCalled(CDMethod child) {
            ChildrenCalled.Append(child);
            child.ParentCaller = this;
        }
        public void RemoveChildCalled(CDMethod child) {
            
            ChildrenCalled.Remove(child);
            child.ParentCaller = null;
        }

        private EXEScopeMethod _ExecutableCode;
        public EXEScopeMethod ExecutableCode
        {
            get
            {
                if (_ExecutableCode == null)
                {
                    _ExecutableCode = new EXEScopeMethod(this);
                }

                return (EXEScopeMethod)_ExecutableCode.CreateClone();
            }
            set
            {
                _ExecutableCode = value;
                if (_ExecutableCode != null)
                {
                    _ExecutableCode.MethodDefinition = this;
                }
            }
        }

        public CDMethod(CDClass OwningClass, String Name, String Type)
        {
            this.OwningClass = OwningClass;
            this.Name = Name;
            this.ReturnType = Type;
            this.CallCountInOALProgram = 0;
            this.OALCode = "";
            this.Parameters = new List<CDParameter>();
            this.ExecutableCode = null;
            this.HighlightLevel = 0;
            this.ParentCaller = null;
            this.ChildrenCalled = new Set<CDMethod>();
        }
        public void IncementCallCount()
        {
            this.CallCountInOALProgram++;
        }

        public void UpdateMethod(CDClass owningClass, Method method)
        {
            this.OwningClass = owningClass;
            this.Name = method.Name;
            this.ReturnType = EXETypes.ConvertEATypeName(method.ReturnValue);
        }

        public void Reset()
        {
            this.OwningClass = null;
            this.Name = null;
            this.ReturnType = null;
            this.CallCountInOALProgram = 0;
            this.OALCode = "";
            this.Parameters = new List<CDParameter>();
            this.ExecutableCode = null;
        }
    }
}
