using FinalProject.DTO;
using FinalProject.Interfaces;


namespace FinalProject.Store
{
    public class MainProcces : IMainProsses
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

        public List<ResultDto> FuncRun(string id)
        {
            // שליפה מדאטא בייס 
            Landmark l = landmark.Get(id);
            //בונה את מערך הכיתות ומערך הממ"דים
            List<Room> classRooms = new List<Room>();
            List<Room> psrRoons = new List<Room>();
            foreach (var corridor in l.Corridors)
            {
                foreach (var classs in corridor.ClassList)
                {
                    classRooms.Add(classs.ClassRoom);
                }
                foreach (var psr in corridor.ProtectedSpaceRoomList)
                {
                    psrRoons.Add(psr.PsrRoom);
                }
            }
            //מכאן זה בשביל למלא את מטריצת המשקלים
            //שליחה לבניית גרף
            var startId = graph.buildGraph(l);
            //הכנסה למטריצת מסלולים
            var m = mat.buildMat(startId);
            //שליחה לדייקסטרה - מתבצע בתוך הפונקציה של בניית המטריצה 
            //var d = dijkstra.InitailGraph(l, );
            //עד כאן זה בשביל למלא את מטריצת המסלולים
            //שליחה לשיבוץ
            var a = algorithmFunction.FinalyFunction(classRooms, psrRoons, m, 0, 0);
            //חוזר מערך של כיתות ושיבוץ בחדרים
            return a;
        }


        //קונטרולר שמקבל קובץ של JSON
        //פונקציה תציר אותו לאוביקטים ותשמור ב DB
        //תשלח את הID לFUNC
    }
}
