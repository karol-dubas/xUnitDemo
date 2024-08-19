using System;
using Xunit;
using Xunit.Abstractions;

namespace xUnitDemo
{
    // IClassFixture with constructor injection.
    // Creates a shared context between all tests in class.
    // Both methods will share the same GUID value.
    
    public class GuidGeneratorTestsOne : IClassFixture<GuidGenerator>
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestsOne(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid value was: {guid}");
        }

        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid value was: {guid}");
        }
    }
}
