namespace SiteQuestaoEventHub.EventHubs
{
    public class InstanciaVoto
    {
        public string IdVoto { get; set; }
        public string Horario { get; set; }
        public string Instancia { get; set; }
    }

    public class Voto
    {
        public string IdVoto { get; set; }
        public string Horario { get; set; }
        public string Tecnologia { get; set; }
    }
}