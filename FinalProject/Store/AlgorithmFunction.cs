using FinalProject.DTO;
using FinalProject.Interfaces;
using System;
using System.IO;
namespace FinalProject.Store
{
    public class AlgorithmFunction : IAlgorithmFunction
    {
        int i = 0, j = 0, r = 0;
        bool b = true;
        List<ResultDto> result = new List<ResultDto>();
        Node index = null;
        double way = 0;
        ResultDto w = null;
        public List<ResultDto> FinalyFunction(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[] mat, int i, int j, double time, Node graph)
        {

            IsCan(normalRooms, safeRoom, mat, i, j, time, graph);
            if (b == false)
            {
                Console.WriteLine("Sorry");
            }
            //לבדוק שאין חדר שלא שובץ ושובץ שוב
            RemoveDual(result);
            //לבדוק האם אין שום התאמה בין כל החדרים
            if (result.Find(x=>x.remarks=="החדר שובץ בהצלחה")==null)
            {
                ResultDto rd = new ResultDto();
                rd.Class = "";
                rd.psrRoom = "";
                rd.remarks = "המערכת לא מצליחה לערוך שיבוץ במבנה";
                result.Clear();
                result.Add(rd);
            }
            return result;
        }
        public bool IsCan(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[] mat, int i, int j, double time, Node graph)
        {
            if (i >= normalRooms.Count || j >= safeRoom.Count)
            {
                Console.WriteLine("The operation cannot be performed!");//failure
                b = false;
                return b;
            }

            if (normalRooms[i].Amount <= safeRoom[j].Amount)
            {
                safeRoom[j].Amount -= normalRooms[i].Amount;
                ResultDto rd = new ResultDto();
                rd.Class = normalRooms[i].RoomId;
                rd.psrRoom = safeRoom[j].RoomId;
                //לחפש את ההחדר בגרף
                if (graph != null && graph.Neighbors != null)
                {
                    foreach (var item in graph.Neighbors)
                    {
                        var foundNeighbor = item.nodeNeighbor?.Neighbors?.Find(x => x.nodeNeighbor.NodeId == normalRooms[i].RoomId);
                        if (foundNeighbor != null)
                        {
                            index = foundNeighbor.nodeNeighbor;
                            break;
                        }
                    }
                }
                //צריך לבדוק את המשקל בהתאם לזמן
                //משקל = דרך במטרים
                if (index != null && mat[index.indexMat].Item1.TryGetValue(normalRooms[i].RoomId, out double distances))
                {
                    //כל שניה אדם הולך מטר נקודה 4 לפי מחקרים

                    way = distances / 1.4;
                    if (time >= way)
                    {
                        rd.remarks = "החדר שובץ בהצלחה";
                        result.Add(rd);
                        r++;
                        i++;
                    }
                    else
                    {
                        rd.psrRoom = "החדר לא שובץ";
                        rd.remarks = "מכיון שהחדר רחוק מהממד!";
                        result.Add(rd);
                        r++;
                        j++;
                    }
                }

                //mat[index.indexMat].Item1.TryGetValue(normalRooms[i].RoomId, out double distances);

            }
            else
            {
                ResultDto rd = new ResultDto();
                rd.Class = normalRooms[i].RoomId;
                rd.psrRoom = "החדר לא שובץ";
                rd.remarks = "החדר לא שובץ מכיון שחסר לו מקום במבנה";
                result.Add(rd);
                r++;
                j++;
            }
            IsCan(normalRooms, safeRoom, mat, i, j, time, graph);
            return b;

        }
        public void RemoveDual(List<ResultDto> result)
        {
            foreach (var item in result)
            {
                w = result.Find(x => x.Class == item.Class && x.psrRoom == "החדר לא שובץ" && item.remarks == "החדר שובץ בהצלחה");
                if (w != null)
                {
                    result.Remove(w);
                    RemoveDual(result);
                    break;
                }
            }
        }

    }
}
