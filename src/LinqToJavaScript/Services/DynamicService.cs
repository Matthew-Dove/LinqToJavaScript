using System;
using System.Linq.Expressions;
using System.Text;

namespace LinqToJavaScript.Services
{
    public class DynamicService
    {
        public string CreateFunction<T1, T2, T3>(Expression<Func<T1, T2, T3>> expression)
        {
            var param1 = expression.Parameters[0];
            var param2 = expression.Parameters[1];

            var binaryExpression = (BinaryExpression)expression.Body;

            var left = (ParameterExpression)binaryExpression.Left;
            var right = (ParameterExpression)binaryExpression.Right;

            string binaryOperator = null;

            switch (binaryExpression.NodeType)
            {
                case ExpressionType.Add:
                    binaryOperator = "+";
                    break;
                case ExpressionType.Divide:
                    binaryOperator = "/";
                    break;
                default:
                    throw new NotImplementedException();
            }

return $@"({param1.Name}, {param2.Name}) {{
    return {left.Name} {binaryOperator} {right.Name};
}}";
        }

        public string CreateScript(params Expression<Func<string>>[] expressions)
        {
            var script = new StringBuilder();

            foreach (var expression in expressions)
            {
                var memberExpression = (MemberExpression)expression.Body;
                var body = expression.Compile()();

                script.AppendFormat("function {0}{1}\r\n", memberExpression.Member.Name, body);
            }

            return script.Remove(script.Length - 2, 2).ToString();
        }
    }
}