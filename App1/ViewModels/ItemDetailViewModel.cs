using App1.Models;

namespace App1.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ZajeciaSzczegoly Szczegoly { get; set; }
        public ItemDetailViewModel(Zajecia item = null)
        {
            Title = item?.Nazwa;
            Szczegoly = new ZajeciaSzczegoly
            {
                Id = item.Id,
                Nazwa = item.Nazwa,
                Godzina = item.Godzina,
                Wykladowca = "ASD ASD",
                Sala = "123",
                Alternatywy = new Zajecia[]
                {
                    new Zajecia{ Nazwa = "To to i to"},
                    new Zajecia{ Nazwa = "Tamto i owo"},
                }
            };


        }


    }
}
