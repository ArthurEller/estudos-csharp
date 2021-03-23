using System;
using Xunit;
namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = getInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int getInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }
          [Fact]
           public void TwoVarsCanReferenceSameObjetct()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

    }
}
