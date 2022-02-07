using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Generics.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_CreatesSingleNode_Success()
        {
            Node<string> myNodes = new("test");
            Assert.AreEqual(1, myNodes.Count());
        }

        [TestMethod]
        public void Constructor_WithClassAsValue_Success()
        {
            Node<Junk> myJunkNodes = new(new Junk("Fubar", "Big Description"));
            Assert.AreEqual(1, myJunkNodes.Count());
        }

        [TestMethod]
        public void Constructor_SingleNodeNextIsItself_Success()
        {
            Node<int> myNodes = new(123);
            Assert.AreEqual(myNodes, myNodes.Next);
        }

        [TestMethod]
        public void Append_TwoNodeListFirstNodeNextIsItself_Fails()
        {
            Node<int> myNodes = new(123);
            myNodes.Append(456);
            Assert.AreEqual(false, myNodes == myNodes.Next);
        }

        [TestMethod]
        public void Append_AddsOneNode_Success()
        {
            Node<string> myNodes = new("test");
            myNodes.Append("Another One");
            Assert.AreEqual(2, myNodes.Count());
        }

        [TestMethod]
        public void Append_AddsTwoNodes_Success()
        {
            Node<string> myNodes = new("test");
            myNodes.Append("Second One");
            myNodes.Append("Third One");
            Assert.AreEqual(3, myNodes.Count());
        }

        [TestMethod]
        public void Exists_WithMultipleNodesFindsNode_Success()
        {
            Node<double> myNodes = new(45.67);
            myNodes.Append(22);
            myNodes.Append(33.34);
            Assert.AreEqual(true,myNodes.Exists(22));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Append_ThrowsExceptionOnDuplicateNodeValue()
        {
            Node<string> myNodes = new("test");
            myNodes.Append("Second One");
            myNodes.Append("Second One");
        }

        [TestMethod]
        public void DeleteSingleNode_DeletesSingleNodeFromList_Success()
        {
            Node<string> myNodes = new("test");
            myNodes.Append("Second One");
            myNodes.Append("Third One");
            myNodes.DeleteSingleNode("Second One");
            Assert.AreEqual(false,myNodes.Exists("Second One"));
        }

        [TestMethod]
        public void Clear_WithMultipleNodesRemovesAllButOne_Success()
        {
            Node<string> myNodes = new("test");
            myNodes.Append("Second One");
            myNodes.Append("Third One");
            myNodes.Clear();
            Assert.AreEqual(1, myNodes.Count());
            Assert.AreEqual(true, myNodes.Exists("test"));
        }

        [TestMethod]
        public void ToString_ReturnsString_Success()
        {
            Node<int> myNodes = new(123);
            var test = myNodes.ToString();
            Assert.AreEqual("String", test?.GetType().Name);
        }

        [TestMethod]
        public void ToString_WithClassTypeReturnsString_Success()
        {
            Node<Junk> myJunkNodes = new(new Junk("Fubar", "Big Description"));
            var test = myJunkNodes.ToString();
            string expectedString = "Fubar, Big Description";
            Assert.AreEqual("String", test?.GetType().Name);
            Assert.AreEqual(test, expectedString);
        }

        [TestMethod]
        public void ToString_FullNodesTraversalShowsCircularList_Success()
        {
            // Arrange
            string expectedResult = "one, two, three, one";
            string actualResult = "";
            Node<string> myNodes = new("one");
            myNodes.Append("two");
            myNodes.Append("three");

            // Act
            Node<string> currentNode = myNodes;
            for (int i = 0; i < 4; i++)
            {
                if (!string.IsNullOrEmpty(actualResult))
                {
                    actualResult += ", ";
                }
                actualResult += currentNode.ToString();
                currentNode = currentNode.Next;
            }

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    public class Junk
    {
        private string Name { get; set; }
        private string Description { get; set; }

        public Junk (string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public override string ToString()
        {
            return Name + ", " + Description;
        }
    }
}