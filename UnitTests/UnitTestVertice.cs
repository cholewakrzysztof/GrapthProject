
namespace UnitTests
{
    [TestClass]
    public class UnitTestVertice
    {
        private Vertice verticeFrom = new Vertice(0f); 
        private Vertice verticeTo = new Vertice(0f);

        [TestInitialize]
        public void Startup() 
        {
            Vertice.ResetLastId();
            verticeFrom = new Vertice(0f);
            verticeTo = new Vertice(0f);
        }

        [TestMethod]
        public void TestVerticeId()
        {
            Assert.AreEqual(0, verticeFrom.GetId());
            Assert.AreEqual(1, verticeTo.GetId());
        }

        [TestMethod]
        public void TestNumberOfNeiboughrsAfterConnect() 
        {
            verticeFrom.ConnectTo(verticeTo);

            Assert.AreEqual(1, verticeFrom.GetNeiboughrs().Count);
            Assert.AreEqual(1, verticeTo.GetNeiboughrs().Count);
        }
        [TestMethod]
        public void TestConnectToYourself() 
        {
            Assert.IsFalse(verticeFrom.ConnectTo(verticeFrom));
            Assert.AreEqual(0, verticeFrom.GetNeiboughrs().Count);
        }

        [TestMethod]
        public void TestDoubleConnection() 
        {
            verticeFrom.ConnectTo(verticeTo);
            Assert.IsFalse(verticeFrom.ConnectTo(verticeTo));
            Assert.AreEqual(1, verticeFrom.GetNeiboughrs().Count);
        }

        [TestMethod]
        public void TestVisit() 
        {
            verticeTo.Visit();

            Assert.IsTrue(verticeTo.isVisited());
            Assert.IsFalse(verticeFrom.isVisited());
        }

        [TestMethod]
        public void TestUnVisit() 
        {
            verticeFrom.Visit();
            verticeFrom.UnVisit();
            Assert.IsFalse(verticeFrom.isVisited());
        }

        [TestMethod]
        public void TestResetLastId() 
        {
            Assert.AreEqual(0, verticeFrom.GetId());
            Assert.AreEqual(1, verticeTo.GetId());
            
            Vertice.ResetLastId();
            verticeTo = new Vertice(0f);
            verticeFrom = new Vertice(0f);

            Assert.AreEqual(0, verticeTo.GetId());
            Assert.AreEqual(1, verticeFrom.GetId());
        }

        [TestMethod]
        public void TestSearchForEdge() 
        {
            verticeFrom.ConnectTo(verticeTo);

            Assert.AreEqual(0, verticeFrom.GetEdgeIndex(1));
            Assert.AreEqual(0, verticeTo.GetEdgeIndex(0));
            Assert.AreEqual(-1, verticeTo.GetEdgeIndex(3));
        }

        [TestMethod]
        public void TestGetEdge() 
        {
            verticeFrom.ConnectTo(verticeTo);
            Assert.AreEqual(verticeTo.GetEdge(verticeTo.GetEdgeIndex(0)), verticeFrom.GetEdge(verticeFrom.GetEdgeIndex(1)));
        }
    }
}