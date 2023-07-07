namespace UnitTests
{
    [TestClass]
    public class UnitTestEdge
    {
        private Vertice verticeFrom = new Vertice(0f);
        private Vertice verticeTo = new Vertice(0f);

        [TestInitialize]
        public void Startup()
        {
            Vertice.ResetLastId();
            verticeFrom = new Vertice(0f);
            verticeTo = new Vertice(0f);

            verticeFrom.ConnectTo(verticeTo);
        }

        [TestMethod]
        public void TestSetWeight()
        {
            Assert.AreEqual(0f, verticeFrom.GetEdge(0).GetWeight());
            Assert.AreEqual(0f, verticeTo.GetEdge(0).GetWeight());

            verticeFrom.GetEdge(0).SetWeight(10f);

            Assert.AreEqual(10f, verticeFrom.GetEdge(0).GetWeight());
            Assert.AreEqual(10f, verticeTo.GetEdge(0).GetWeight());
        }

        [TestMethod]
        public void TestGetDestinationVertice()
        {
            Edge edge = verticeTo.GetEdge(0);
            Assert.AreEqual(0, edge.GetDestinationVertice(1).GetId());
            Assert.AreEqual(1, edge.GetDestinationVertice(0).GetId());
        }
    }
}
