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
            Assert.AreEqual(0f, verticeFrom.GetEdgeTo(verticeTo).GetWeight());
            Assert.AreEqual(0f, verticeTo.GetEdgeTo(verticeFrom).GetWeight());

            verticeFrom.GetEdgeTo(verticeTo).SetWeight(10f);

            Assert.AreEqual(10f, verticeFrom.GetEdgeTo(verticeTo).GetWeight());
            Assert.AreEqual(10f, verticeTo.GetEdgeTo(verticeFrom).GetWeight());
        }

        [TestMethod]
        public void TestGetDestinationVertice()
        {
            Edge edge = verticeTo.GetEdgeTo(verticeFrom);
            Assert.AreEqual(0, edge.GetDestinationVertice(1).GetId());
            Assert.AreEqual(1, edge.GetDestinationVertice(0).GetId());
        }

        /**
         * TODO Test directed edges
         */

    }
}
