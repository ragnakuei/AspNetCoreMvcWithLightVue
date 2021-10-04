namespace AspNetCoreMvcWithLightVue.Models
{
    public class Category
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public Item[] Items { get; set; }
    }
}