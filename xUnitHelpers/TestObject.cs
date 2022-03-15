namespace xUnitHelpers
{
    internal class TestObject<T1, T2>
    {
        public T1 Data { get; set; } = default!;

        public T2 Result { get; set; } = default!;
    }
}
