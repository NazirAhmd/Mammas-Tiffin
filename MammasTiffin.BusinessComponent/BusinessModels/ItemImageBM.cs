namespace MammasTiffin.BusinessComponent.BusinessModels
{
    public class ItemImageBM
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int ImageSize { get; set; }
        public byte[] ImageData { get; set; }
    }
}
