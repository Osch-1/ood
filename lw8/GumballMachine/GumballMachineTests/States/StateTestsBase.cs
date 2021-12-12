using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace GumballMachineTests.States
{
    public class StateTestsBase
    {
        protected StringBuilder Output;
        private StringWriter _tempOutputWriter;
        private TextWriter _originalOutputWriter;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _originalOutputWriter = Console.Out;
            _tempOutputWriter = new StringWriter();
            Console.SetOut( _tempOutputWriter );
            Output = _tempOutputWriter.GetStringBuilder();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.SetOut( _originalOutputWriter );
            _tempOutputWriter.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            Output.Clear();
        }
    }
}
