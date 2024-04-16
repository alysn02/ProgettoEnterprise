namespace Unicam.Paradigmi.Progetto.Application.Models.Dtos
{
    public class ListaUtenzeAssociateDto
    {
        int idListaDistributori {  get; set; }
        int idDestinatari { get; set; }

        ListaUtenzeAssociateDto(int idListaDistributori, int idDestinatari)
        {
            this.idListaDistributori = idListaDistributori;
            this.idDestinatari = idDestinatari;
        }
    }
}
