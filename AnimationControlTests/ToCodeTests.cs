﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimationControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimationControl.Tests
{
    [TestClass]
    public class ToCodeTests
    {
        [TestMethod]
        public void ToCode_Normal_01()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("20")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("1")));
            Animation.SuperScope.AddCommand(new EXEScopeCondition(
                Animation.SuperScope,
                new EXECommand[]
                {
                    new EXECommandAssignment("y", new EXEASTNodeLeaf("11"))
                },
                new EXEASTNodeComposite
                (
                    ">",
                    new EXEASTNode[]
                    {
                        new EXEASTNodeLeaf("x"),
                        new EXEASTNodeLeaf("10")
                    }
                )
            ));

            String ExpectedCode = 
                "x = 20;\n" +
                "y = 1;\n" +
                "if (x > 10)\n" +
                "\ty = 11;\n" +
                "end if;\n";

            String ActualCode = Animation.SuperScope.ToCode();

            Assert.AreEqual(ExpectedCode, ActualCode);
        }
        [TestMethod]
        public void ToCode_Normal_02()
        {
            Animation Animation = new Animation();

            StringBuffer StringBuffer = new StringBuffer();
            EXEScope[] Threads = new EXEScope[10];
            for (int i = 0; i < 10; i++)
            {
                Threads[i] =
                        new EXEScope
                        (
                            Animation.SuperScope,
                            new EXECommand[]
                            {
                                new EXECommandCallTestDecorator
                                (
                                    new EXECommandCall("Observer", "init", "R1", "Subject", "register"),
                                    StringBuffer
                                ),
                                new EXECommandAssignment
                                (
                                    "x",
                                    new EXEASTNodeComposite
                                    (
                                        "+",
                                        new EXEASTNode[]
                                        {
                                            new EXEASTNodeLeaf("x"),
                                            new EXEASTNodeLeaf("1")
                                        }
                                    )
                                )
                            }
                        );
            }

            Animation.SuperScope.AddCommand
            (
                new EXECommandAssignment("x", new EXEASTNodeLeaf("0"))
            );
            Animation.SuperScope.AddCommand
            (
                new EXEScopeParallel
                (
                   Threads
                )
            );

            String ExpectedCode =
                "x = 0;\n" +
                "par\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "\tthread\n" +
                "\t\tcall from Observer::init() to Subject::register() across R1;\n" +
                "\t\tx = x + 1;\n" +
                "\tend thread;\n" +
                "end par;\n";

            String ActualCode = Animation.SuperScope.ToCode();

            Assert.AreEqual(ExpectedCode, ActualCode);
        }
        [TestMethod]
        public void ToCode_Normal_03()
        {
            Animation Animation = new Animation();

            Animation.SuperScope.AddCommand(new EXECommandAssignment("x", new EXEASTNodeLeaf("1")));
            Animation.SuperScope.AddCommand(new EXECommandAssignment("y", new EXEASTNodeLeaf("\"\"")));
            Animation.SuperScope.AddCommand(new EXEScopeCondition(
                Animation.SuperScope,
                new EXECommand[]
                {
                    new EXECommandAssignment("y", new EXEASTNodeLeaf("\"Zero\""))
                },
                new EXEASTNodeComposite
                (
                    "==",
                    new EXEASTNode[]
                    {
                        new EXEASTNodeLeaf("x"),
                        new EXEASTNodeLeaf("0")
                    }
                ),
                new EXEScopeCondition[]
                {
                    new EXEScopeCondition
                    (
                        Animation.SuperScope,
                        new EXECommand[]
                        {
                            new EXECommandAssignment("y", new EXEASTNodeLeaf("\"One\""))
                        },
                        new EXEASTNodeComposite(
                            "==",
                            new EXEASTNode[]
                            {
                                new EXEASTNodeLeaf("x"),
                                new EXEASTNodeLeaf("1")
                            }
                        )
                    ),
                    new EXEScopeCondition
                    (
                        Animation.SuperScope,
                        new EXECommand[]
                        {
                            new EXECommandAssignment("y", new EXEASTNodeLeaf("\"Two\""))
                        },
                        new EXEASTNodeComposite(
                            "==",
                            new EXEASTNode[]
                            {
                                new EXEASTNodeLeaf("x"),
                                new EXEASTNodeLeaf("2")
                            }
                        )
                    )
                },
                new EXEScope
                (
                    Animation.SuperScope,
                    new EXECommand[]
                    {
                        new EXECommandAssignment("y", new EXEASTNodeLeaf("\"None\""))
                    }
                )
            ));

            String ExpectedCode =
                "x = 1;\n" +
                "y = \"\";\n" +
                "if (x == 0)\n" +
                "\ty = \"Zero\";\n" +
                "elif (x == 1)\n" +
                "\ty = \"One\";\n" +
                "elif (x == 2)\n" +
                "\ty = \"Two\";\n" +
                "else\n" +
                "\ty = \"None\";\n" +
                "end if;\n";

            String ActualCode = Animation.SuperScope.ToCode();

            Assert.AreEqual(ExpectedCode, ActualCode);
        }
    }
}
