using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KT.Utils
{
    public class ExpressionUtils
    {
        public enum SearchCombineOperator
        {
            AndOperator = 1,
            OrOperator = 2
        }

        public static Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, SearchCombineOperator combineOperator)
        {
            
            if (first == null) return second;
            if (second == null) return first;

            var toInvoke = Expression.Invoke(second, first.Parameters.ToArray());

            if (combineOperator == SearchCombineOperator.AndOperator)
            {
                return (Expression<Func<T, bool>>)Expression.Lambda(Expression.AndAlso(first.Body, toInvoke), first.Parameters.ToArray());
            }
            else
            {
                return (Expression<Func<T, bool>>)Expression.Lambda(Expression.OrElse(first.Body, toInvoke), first.Parameters.ToArray());
            }

        }

        //public static Func<T, bool> CombineExpressions<T>(Func<T, bool> first, Func<T, bool> second, SearchCombineOperator combineOperator)
        //{

        //    if (first == null) return second;
        //    if (second == null) return first;
                        
        //    var toInvoke = Expression.Invoke(second, first.Parameters.ToArray());

        //    if (combineOperator == SearchCombineOperator.AndOperator)
        //    {
        //        return (Expression<Func<T, bool>>)Expression.Lambda(Expression.AndAlso(first.Body, toInvoke), first.Parameters.ToArray());
        //    }
        //    else
        //    {
        //        return (Expression<Func<T, bool>>)Expression.Lambda(Expression.OrElse(first.Body, toInvoke), first.Parameters.ToArray());
        //    }

        //}

        public static MemberExpression GetMemberExpression(Expression expression)
        {
          if (expression is MemberExpression)
          {
            return (MemberExpression)expression;
          }
          else if (expression is LambdaExpression)
          {
            var lambdaExpression = expression as LambdaExpression;
            if (lambdaExpression.Body is MemberExpression)
            {
              return (MemberExpression)lambdaExpression.Body;
            }
            else if (lambdaExpression.Body is UnaryExpression)
            {
              return ((MemberExpression)((UnaryExpression)lambdaExpression.Body).Operand);
            }
          }
          return null;
        }

    }
}
