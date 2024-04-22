namespace Unicam.Paradigmi.Progetto.Application.Models.Dtos
{
    public class ListaUtenzeAssociateDto
    {
        public int idListaDistributori {  get; set; }
        public int idDestinatari { get; set; }

        public ListaUtenzeAssociateDto(int idListaDistributori, int idDestinatari)
        {
            this.idListaDistributori = idListaDistributori;
            this.idDestinatari = idDestinatari;
        }
    }
}
