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

        public List<ResultDto> FinalyFunction(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[] mat, int i, int j,double time,Landmark l)
        {

            IsCan(normalRooms, safeRoom,  mat, i, j,l);
            if (b == false)
            {
                Console.WriteLine("Sorry");
            }
            return result;
        }
        public bool IsCan(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[]mat, int i, int j,Landmark l)
        {
            if (i >= normalRooms.Count || j >= safeRoom.Count)
            {
                Console.WriteLine("The operation cannot be performed!");//failure
                b= false;
                return b;
            }

            //if (j > normalRooms.Count)
            //{
            //    Console.WriteLine("הפעולה לא יכולה להתבצע!");//כשל
            //    return false;
            //}
            //כל שניה אדם הולך מטר נקודה 4 לפי מחקרים
            if (normalRooms[i].Amount <= safeRoom[j].Amount)
            {
                safeRoom[j].Amount -= normalRooms[i].Amount;
                ResultDto rd = new ResultDto();
                rd.Class = normalRooms[i].RoomId;
                rd.psrRoom = safeRoom[j].RoomId;
                rd.remarks = "החדר שובץ בהצלחה";
                //תריך לבדוק את המשקל בהתאם לזמן
                //משקל = דרך במטרים
                result.Add(rd);
                r++;
                i++;

            }
            else
            {
                ResultDto rd = new ResultDto();
                rd.Class = normalRooms[i].RoomId;
                rd.psrRoom = "החדר לא שובץ";
                rd.remarks = "החדר לא שובץ מכיון שחסר לו מקום במבנה";
                j++;
            }
            IsCan(normalRooms, safeRoom,mat, i, j,l);
            return b;

        }
       
        
    }
}
