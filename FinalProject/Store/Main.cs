using FinalProject.DTO;

namespace FinalProject.Store
{
  public static class  Main
    {
        //public static int classCount = 0;
        //public static int psrCount = 0;
        //public static int corridorCount = 0;
        //public static int roomCount = 0;
        //public static int landmarkCount = 0; 
        public static void main(string[] args)
        {

             Landmark building = new Landmark();

            building.LandmarkId = "123";

            building.Corridors = new List<Corridor>();
            building.Corridors[0].CorridorId = "456";
            building.Corridors[0].StartPointX = 1;
            building.Corridors[0].EndPointX = 2;
            building.Corridors[0].StartPointY = 1;
            building.Corridors[0].EndPointY = 2;
            building.Corridors[0].Floor = 0;
            building.Corridors[0].CorridorLandmark.X = 4;
            building.Corridors[0].CorridorLandmark.Y = 6;
            building.Corridors[0].ClassList = new List<Class>();
            building.Corridors[0].ProtectedSpaceRoomList = new List<ProtectedSpaceRoom>();

            building.Corridors[0].ClassList[0].ClassId = "789";
            building.Corridors[0].ClassList[0].ClassRoom.RoomId = "147";
            building.Corridors[0].ClassList[0].ClassRoom.X = 12;
            building.Corridors[0].ClassList[0].ClassRoom.Y = 12;
            building.Corridors[0].ClassList[0].ClassRoom.Amount = 45;

            building.Corridors[0].ProtectedSpaceRoomList[0].PsrId = "258";
            building.Corridors[0].ProtectedSpaceRoomList[0].PsrRoom.RoomId = "369";
            building.Corridors[0].ProtectedSpaceRoomList[0].PsrRoom.X = 9;
            building.Corridors[0].ProtectedSpaceRoomList[0].PsrRoom.Y = 2;
            building.Corridors[0].ProtectedSpaceRoomList[0].PsrRoom.Amount = 50;

        }
    }
}
