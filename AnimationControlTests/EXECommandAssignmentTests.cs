﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimationControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimationControl.Tests
{
    [TestClass]
    public class EXECommandAssignmentTests
    {
        [TestMethod]
        public void Execute_Normal_Int_01()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15")));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","15"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_02()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("6")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z", new EXEASTNodeLeaf("-56")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("a", new EXEASTNodeLeaf("-13")));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","15"},
                {"y","6"},
                {"z","-56"},
                {"a","-13"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_03()
        {
            Animation Animation = new Animation();
            CDClass Class1 = Animation.ExecutionSpace.SpawnClass("SwampMonster");
            Class1.AddAttribute(new CDAttribute("health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("mana", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_mana", EXETypes.IntegerTypeName));

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("0")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z", new EXEASTNodeLeaf("-56")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("a", new EXEASTNodeLeaf("-13")));
            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("SwampMonster", "swamp_monster1"));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "health",new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_health", new EXEASTNodeLeaf("1024")));
            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","15"},
                {"y","0"},
                {"z","-56"},
                {"a","-13"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
                { "swamp_monster1.health", "1024"},
                { "swamp_monster1.max_health", "1024"},
                { "swamp_monster1.mana", EXETypes.UnitializedName},
                { "swamp_monster1.max_mana", EXETypes.UnitializedName}
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_04()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("150")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("-15")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("-150")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("0")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("223344")));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","223344"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_05()
        {
            Animation Animation = new Animation();
            CDClass Class1 = Animation.ExecutionSpace.SpawnClass("SwampMonster");
            Class1.AddAttribute(new CDAttribute("health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("mana", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_mana", EXETypes.IntegerTypeName));

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("321")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("123")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z", new EXEASTNodeLeaf("750000")));
            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("SwampMonster", "swamp_monster1"));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "health", new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_health", new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "mana", new EXEASTNodeLeaf("2")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_mana", new EXEASTNodeLeaf("2")));
            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","321"},
                {"y","123"},
                {"z","750000"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
                { "swamp_monster1.health", "1024"},
                { "swamp_monster1.max_health", "1024"},
                { "swamp_monster1.mana", "2"},
                { "swamp_monster1.max_mana", "2"}
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_06()
        {
            Animation Animation = new Animation();
            CDClass Class1 = Animation.ExecutionSpace.SpawnClass("SwampMonster");
            Class1.AddAttribute(new CDAttribute("health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("mana", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_mana", EXETypes.IntegerTypeName));

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("321")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("123")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z", new EXEASTNodeLeaf("750000")));
            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("SwampMonster", "swamp_monster1"));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "health", new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_health", new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "mana", new EXEASTNodeLeaf("2")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_mana", new EXEASTNodeLeaf("2")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "health", new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_health", new EXEASTNodeLeaf("4048")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "mana", new EXEASTNodeLeaf("20")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_mana", new EXEASTNodeLeaf("500")));
            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","321"},
                {"y","123"},
                {"z","750000"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
                { "swamp_monster1.health", "1024"},
                { "swamp_monster1.max_health", "4048"},
                { "swamp_monster1.mana", "20"},
                { "swamp_monster1.max_mana", "500"},
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_07()
        {
            Animation Animation = new Animation();
            CDClass Class1 = Animation.ExecutionSpace.SpawnClass("SwampMonster");
            Class1.AddAttribute(new CDAttribute("health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_health", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("mana", EXETypes.IntegerTypeName));
            Class1.AddAttribute(new CDAttribute("max_mana", EXETypes.IntegerTypeName));

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("321")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("123")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z", new EXEASTNodeLeaf("750000")));
            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("SwampMonster", "swamp_monster1"));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "health", new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_health", new EXEASTNodeLeaf("1024")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "mana", new EXEASTNodeLeaf("2")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("swamp_monster1", "max_mana", new EXEASTNodeLeaf("2")));
            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("SwampMonster", "swamp_monster2"));
            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","321"},
                {"y","123"},
                {"z","750000"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
                { "swamp_monster1.health", "1024"},
                { "swamp_monster1.max_health", "1024"},
                { "swamp_monster1.mana", "2"},
                { "swamp_monster1.max_mana", "2"},
                { "swamp_monster2.health", EXETypes.UnitializedName},
                { "swamp_monster2.max_health", EXETypes.UnitializedName},
                { "swamp_monster2.mana", EXETypes.UnitializedName},
                { "swamp_monster2.max_mana", EXETypes.UnitializedName}
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_08()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15.0")));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","15"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_09()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("16.0")));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","16"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_10()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("15")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("21.2")));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","21"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_11()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x",
                new EXEASTNodeComposite("+", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("15"), new EXEASTNodeLeaf("25") } )
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","40"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_12()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("1")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x",
                new EXEASTNodeComposite("+", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("1") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","2"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_13()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("5")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("x",
                new EXEASTNodeComposite("*", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("x") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","25"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_14()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("100")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("1000")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z",
                new EXEASTNodeComposite("+", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("y") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","100"},
                {"y","1000"},
                {"z","1100"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_15()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("66")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("33")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z", new EXEASTNodeLeaf("1")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum",
                new EXEASTNodeComposite("+", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("y"), new EXEASTNodeLeaf("z") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","66"},
                {"y","33"},
                {"z","1"},
                {"sum","100"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_16()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("66.4")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("33.3")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("z", new EXEASTNodeLeaf("1.3")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum",
                new EXEASTNodeComposite("+", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("y"), new EXEASTNodeLeaf("z") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","66.4"},
                {"y","33.3"},
                {"z","1.3"},
                {"sum","101"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_17()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("60.5")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum",
                new EXEASTNodeComposite("*", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("2") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","60.5"},
                {"sum","121"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_18()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("60.6")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum", new EXEASTNodeLeaf("2")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum",
                new EXEASTNodeComposite("*", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("4") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","60.6"},
                {"sum","242"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_19()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("3.6")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum", new EXEASTNodeLeaf("2")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum",
                new EXEASTNodeComposite("*", new EXEASTNodeLeaf[] { new EXEASTNodeLeaf("x"), new EXEASTNodeLeaf("4.2") })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"x","3.6"},
                {"sum","15"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_21()
        {
            Animation Animation = new Animation();
            CDClass Class = Animation.ExecutionSpace.SpawnClass("GameObject");
            Class.AddAttribute(new CDAttribute("x", EXETypes.IntegerTypeName));
            Class.AddAttribute(new CDAttribute("y", EXETypes.IntegerTypeName));
            Class.AddAttribute(new CDAttribute("z", EXETypes.IntegerTypeName));

            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("GameObject", "obj"));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("obj", "x", new EXEASTNodeLeaf("66")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("xo",
                    new EXEASTNodeComposite(".", new EXEASTNode[] {
                        new EXEASTNodeLeaf("obj"), new EXEASTNodeLeaf("x")
                    })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"xo", "66"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
                {"obj.x", "66"},
                {"obj.y", EXETypes.UnitializedName},
                {"obj.z", EXETypes.UnitializedName}
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_22()
        {
            Animation Animation = new Animation();
            CDClass Class = Animation.ExecutionSpace.SpawnClass("GameObject");
            Class.AddAttribute(new CDAttribute("x", EXETypes.IntegerTypeName));
            Class.AddAttribute(new CDAttribute("y", EXETypes.IntegerTypeName));
            Class.AddAttribute(new CDAttribute("z", EXETypes.IntegerTypeName));

            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("GameObject", "obj"));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("obj", "x", new EXEASTNodeLeaf("66.4")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("obj", "y", new EXEASTNodeLeaf("33.3")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("obj", "z", new EXEASTNodeLeaf("1.3")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum",
                new EXEASTNodeComposite("+", new EXEASTNode[] {
                    new EXEASTNodeComposite(".", new EXEASTNode[] {
                        new EXEASTNodeLeaf("obj"), new EXEASTNodeLeaf("x")
                    }),
                    new EXEASTNodeLeaf("5")
                })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {
                {"sum", "71"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
                {"obj.x","66.4"},
                {"obj.y","33.3"},
                {"obj.z","1.3"},
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
        [TestMethod]
        public void Execute_Normal_Int_200()
        {
            Animation Animation = new Animation();
            CDClass Class = Animation.ExecutionSpace.SpawnClass("GameObject");
            Class.AddAttribute(new CDAttribute("x", EXETypes.IntegerTypeName));
            Class.AddAttribute(new CDAttribute("y", EXETypes.IntegerTypeName));
            Class.AddAttribute(new CDAttribute("z", EXETypes.IntegerTypeName));

            Animation.SuperScope.AddCommand(new EXECommandQueryCreate("GameObject", "obj"));
           Animation.SuperScope.AddCommand(new EXECommandAssignment("obj", "x", new EXEASTNodeLeaf("66.4")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("obj", "y", new EXEASTNodeLeaf("33.3")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("obj", "z", new EXEASTNodeLeaf("1.3")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("sum",
                new EXEASTNodeComposite("+", new EXEASTNode[] {
                    new EXEASTNodeComposite(".", new EXEASTNode[] {
                        new EXEASTNodeLeaf("obj"), new EXEASTNodeLeaf("x")
                    }),
                    new EXEASTNodeComposite(".", new EXEASTNode[] {
                        new EXEASTNodeLeaf("obj"), new EXEASTNodeLeaf("y")
                    }),
                    new EXEASTNodeComposite(".", new EXEASTNode[] {
                        new EXEASTNodeLeaf("obj"), new EXEASTNodeLeaf("z")
                    })
                })
            ));

            Boolean Success = Animation.Execute();

            Dictionary<String, String> ExpectedPrimitiveVarState = new Dictionary<string, string>
            {   
                {"sum","101"}
            };
            Dictionary<String, String> ExpectedReferencingVarState = new Dictionary<string, string>
            {
                {"obj.x","66.4"},
                {"obj.y","33.3"},
                {"obj.z","1.3"},
            };

            Dictionary<String, String> ActualPrimitiveVarState = Animation.SuperScope.GetStateDictRecursive();
            Dictionary<String, String> ActualReferencingVarState = Animation.SuperScope.GetRefStateAttrsDictRecursive(Animation.ExecutionSpace);

            Assert.IsTrue(Success);
            CollectionAssert.AreEquivalent(ExpectedPrimitiveVarState, ActualPrimitiveVarState);
            CollectionAssert.AreEquivalent(ExpectedReferencingVarState, ActualReferencingVarState);
        }
    }
}