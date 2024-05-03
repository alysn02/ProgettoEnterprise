namespace Unicam.Paradigmi.Progetto.Application.Models.Dtos
{
    public class ListaUtenzeAssociateDto
    {
        public int IdListaDistributori {  get; set; }
        public int IdDestinatari { get; set; }

        public ListaUtenzeAssociateDto(int idListaDistributori, int idDestinatari)
        {
            this.IdListaDistributori = idListaDistributori;
            this.IdDestinatari = idDestinatari;
        }
    }
}
