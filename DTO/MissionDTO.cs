namespace Inventory_managment.DTO
{
    public class MissionDTO
    {
        public string Name { get; set; }

        public string Gtin { get; set; }

        public string Volume { get; set; }

        public int BoxFormat { get; set; }

        public int PalletFormat { get; set; }

        public MissionDTO(string name, string gtin, string volume, int boxFormat, int palletFormat)
        {
            Name = name;
            Gtin = gtin;
            Volume = volume;
            BoxFormat = boxFormat;
            PalletFormat = palletFormat;
        }

    }

}
