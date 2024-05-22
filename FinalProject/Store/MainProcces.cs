using FinalProject.DTO;

namespace FinalProject.Store
{
    public class MainProcces
    {
        private ILandmarkFunction landmark;
        private IGraph graph;
        private IDijkstra dijkstra;
        private IMat mat;
        private IAlgorithmFunction algorithmFunction;
        public MainProcces(ILandmarkFunction landmark, IGraph graph, IDijkstra dijkstra, IMat mat, IAlgorithmFunction algorithmFunction)
        {
            this.landmark = landmark;
            this.graph = graph;
            this.dijkstra = dijkstra;
            this.mat = mat;
            this.algorithmFunction = algorithmFunction;
        }
        public List<ResultDto> Func(string id)
        {
            //aשליפה מDB
            Landmark l = landmark.Get(id);
            //שליחה לבניית גרף
            var startId = graph.buildGraph(l);
            //שליחה לדייקסטרה
            var d = dijkstra.InitailGraph(l, startId);
            //הכנסה למטריצת מסלולים
            var m = mat.buildMat(d);
            //שליחה לשיבוץ
            var a = algorithmFunction.FinalyFunction(m);
            //חוזר מערך של כיתות ושיבוץ בחדרים
            return a;
        }


        //קונטרולר שמקבל קובץ של JSON
        //פונקציה תציר אותו לאוביקטים ותשמור ב DB
        //תשלח את הID לFUNC
    }
}
