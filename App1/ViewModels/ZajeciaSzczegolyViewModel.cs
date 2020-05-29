using App1.Models;

namespace App1.ViewModels
{
    public class ZajeciaSzczegolyViewModel : BaseViewModel
    {
        public ZajeciaSzczegoly Szczegoly { get; set; }

        public ZajeciaSzczegolyViewModel(Zajecia item = null)
        {
            Title = item?.Nazwa;

            Szczegoly = new ZajeciaSzczegoly
            {
                Id = item.Id,
                Nazwa = item.Nazwa,
                Godzina = item.Godzina,
                Wykladowca = "Jan Kowalski",
                Sala = "123",
                Alternatywy = new Zajecia[]
                {
                    new Zajecia{ Nazwa = "Sztuczna Inteligencja", Godzina = item.Godzina},
                    new Zajecia{ Nazwa = "Grafika", Godzina = item.Godzina},
                }
            };
        }
    }
}
