using System;
using Machine.Specifications;

namespace NeverNull.Tests.Combinators {
    [Subject(typeof (NeverNull.Combinators))]
    public class When_I_convert_a_none_of_type_int_to_an_option_of_type_string_with_flatmap {
        private static IOption<int> _none;
        private static Func<int, IOption<string>> _toString;
        private static IOption<string> _anotherNone;

        private Establish context = () => {
            _none = new None<int>();

            _toString = i => Option.Create(i.ToString());
        };

        private Because of = () => _anotherNone = _none.FlatMap(_toString);

        private It should_return_a_none =
            () => _anotherNone.HasValue.ShouldBeFalse();
    }
}