using FinalProject.DTO;
using FinalProject.Interfaces;
using System;
using System.IO;
namespace FinalProject.Store
{
    public class AlgorithmFunction : IAlgorithmFunction
    {
        int i = 0, j = 0,r=0;
        List<ResultDto> result = new List<ResultDto>();

        public List<ResultDto> FinalyFunction(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[] mat, int i, int j)
        {
            if (IsCan(normalRooms, safeRoom, i, j)==false)
            {
                Console.WriteLine("Sorry");
            }
           // IsCan(normalRooms, safeRoom, i, j);
            return result;
        }
        public bool IsCan(List<Room> normalRooms, List<Room> safeRoom, int i, int j)
        {
            if (i >= normalRooms.Count || j >= safeRoom.Count)
            {
                Console.WriteLine("The operation cannot be performed!");//failure
                return false;
            
            }
            //if (j > normalRooms.Count)
            //{
            //    Console.WriteLine("הפעולה לא יכולה להתבצע!");//כשל
            //    return false;
            //}
            if (normalRooms[i].Amount <= safeRoom[j].Amount)
            {
                safeRoom[j].Amount -= normalRooms[i].Amount;
                ResultDto rd = new ResultDto();
                rd.Class = normalRooms[i].RoomId;
                rd.psrRoom = safeRoom[j].RoomId;
                //  result[r] = rd;
                result.Add( rd);
                r++;
                i++;

            }
            else
            {
                j++;
            }
            IsCan(normalRooms, safeRoom, i, j);
            return true;
        }
    }
}
