//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from OAL.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="OALParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IOALVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.lines"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLines([NotNull] OALParser.LinesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLine([NotNull] OALParser.LineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.parCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParCommand([NotNull] OALParser.ParCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.ifCommnad"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfCommnad([NotNull] OALParser.IfCommnadContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.whileCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileCommand([NotNull] OALParser.WhileCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.foreachCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForeachCommand([NotNull] OALParser.ForeachCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.continueCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContinueCommand([NotNull] OALParser.ContinueCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.breakCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreakCommand([NotNull] OALParser.BreakCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandQueryCreate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryCreate([NotNull] OALParser.ExeCommandQueryCreateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandQueryRelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryRelate([NotNull] OALParser.ExeCommandQueryRelateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandQuerySelect"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQuerySelect([NotNull] OALParser.ExeCommandQuerySelectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandQuerySelectRelatedBy"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQuerySelectRelatedBy([NotNull] OALParser.ExeCommandQuerySelectRelatedByContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandQueryDelete"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryDelete([NotNull] OALParser.ExeCommandQueryDeleteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandQueryUnrelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryUnrelate([NotNull] OALParser.ExeCommandQueryUnrelateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandAssignment([NotNull] OALParser.ExeCommandAssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.exeCommandCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandCall([NotNull] OALParser.ExeCommandCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.commands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommands([NotNull] OALParser.CommandsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.relationshipLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationshipLink([NotNull] OALParser.RelationshipLinkContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.instanceHandle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInstanceHandle([NotNull] OALParser.InstanceHandleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.keyLetter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKeyLetter([NotNull] OALParser.KeyLetterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.whereExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhereExpression([NotNull] OALParser.WhereExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] OALParser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.className"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassName([NotNull] OALParser.ClassNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.variableName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableName([NotNull] OALParser.VariableNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.methodName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMethodName([NotNull] OALParser.MethodNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.anyOrMany"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnyOrMany([NotNull] OALParser.AnyOrManyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.atribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtribute([NotNull] OALParser.AtributeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] OALParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OALParser.relationshipSpecification"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationshipSpecification([NotNull] OALParser.RelationshipSpecificationContext context);
}
