using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestDay.Front.Services
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndIf<T>(this Expression<Func<T, bool>> expression,
            Expression<Func<T, bool>> predicate, bool condition = true)
            => Substitute(expression, predicate, Expression.AndAlso, condition);
        private static Expression<Func<T, bool>> Substitute<T>(Expression<Func<T, bool>> expression,
            Expression<Func<T, bool>> predicate, Func<Expression, Expression, BinaryExpression> combiner, bool condition)
        {
            if (!condition) return expression;

            var parameter = expression.Parameters[0];

            var visitor = new SubstitutionExpressionVisitor { Substitution = { [predicate.Parameters[0]] = parameter } };

            var body = combiner(expression.Body, visitor.Visit(predicate.Body));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }

    public class SubstitutionExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> Substitution { get; set; } = new Dictionary<Expression, Expression>();

        protected override Expression VisitParameter(ParameterExpression node) => Substitution.TryGetValue(node,
            out Expression newValue)
            ? newValue
            : node;
    }
}