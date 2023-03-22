namespace EZAB
{
    using System.Dynamic;

    public class Dynamic : DynamicObject
    {
        public readonly object _value;

        public Dynamic(object value)
        {
            _value = value;
        }

        public readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                _properties.Remove(binder.Name);
                return true;
            }

            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _properties[binder.Name] = value;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            // Implement custom behavior for invoking members
            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            // Implement custom behavior for type conversion
            return base.TryConvert(binder, out result);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                _properties.Remove(binder.Name);
                return true;
            }

            return false;
        }

        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result)
        {
            // Implement custom behavior for binary operations
            return base.TryBinaryOperation(binder, arg, out result);
        }

        public void PrintMethodInvocation(string methodName, object[] args)
        {
            Console.WriteLine($"Invoking method {methodName} with arguments [{string.Join(", ", args)}]");
        }

        public void PrintFunctionInvocation(object[] args)
        {
            Console.WriteLine($"Invoking with arguments [{string.Join(", ", args)}]");
        }

        public void PrintConversionAttempt(Type targetType)
        {
            Console.WriteLine($"Converting to {targetType}");
        }
    }
}